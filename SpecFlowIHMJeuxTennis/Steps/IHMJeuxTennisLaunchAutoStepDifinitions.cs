using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V85.Network;
using Xunit;

namespace SpecFlowJeuxTennisApi;

[Binding]
public class IHMJeuxTennisLaunchAutoStepDifinitions : IDisposable
{
    private Process _aspNetProcess;
    private string projectPath;
    public IWebDriver driver = new ChromeDriver();

    private string B_CREER_MATCH = "/html/body/div/button";

    public void LaunchIHM()
    {
        string baseDirectory = AppContext.BaseDirectory;

        // Naviguer vers le répertoire parent de SpecFlowIHMJeuxTennis
        string projectRoot = Path.GetFullPath(Path.Combine(baseDirectory, "../../../.."));

        // Construire le chemin du projet ASP.NET
        projectPath = Path.Combine(projectRoot, "Jeux-IHM");

        // Vérifier si le chemin du projet existe
        if (!Directory.Exists(projectPath))
        {
            throw new DirectoryNotFoundException($"Le répertoire du projet ASP.NET n'existe pas : {projectPath}");
        }

        // Configurer le démarrage du processus ASP.NET
        var startInfo = new ProcessStartInfo
        {
            FileName = "dotnet",
            Arguments = "run",
            WorkingDirectory = projectPath,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        // Démarrer le processus ASP.NET
        _aspNetProcess = new Process { StartInfo = startInfo };
        _aspNetProcess.OutputDataReceived += (sender, args) => Console.WriteLine(args.Data);
        _aspNetProcess.ErrorDataReceived += (sender, args) => Console.WriteLine("ERROR: " + args.Data);
        _aspNetProcess.Start();
        _aspNetProcess.BeginOutputReadLine();
        _aspNetProcess.BeginErrorReadLine();


        Thread.Sleep(10000);
    }

    private void KillProcessesUsingFile(string filePath)
    {
        var processes = Process.GetProcesses()
            .Where(p => !p.HasExited)
            .Select(p =>
            {
                try
                {
                    return new
                    {
                        Process = p,
                        Modules = p.Modules.Cast<ProcessModule>()
                    };
                }
                catch
                {
                    return null;
                }
            })
            .Where(x => x != null &&
                        x.Modules.Any(m => string.Equals(m.FileName, filePath, StringComparison.OrdinalIgnoreCase)))
            .Select(x => x.Process);

        foreach (var process in processes)
        {
            try
            {
                Console.WriteLine($"Killing process {process.Id} using {filePath}");
                process.Kill();
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to kill process {process.Id}: {ex.Message}");
            }
        }
    }

    public void Dispose()
    {
        if (_aspNetProcess != null)
        {
            if (!_aspNetProcess.HasExited)
            {
                _aspNetProcess.CloseMainWindow();
                if (!_aspNetProcess.WaitForExit(5000))
                {
                    _aspNetProcess.Kill();
                }
            }

            _aspNetProcess.Dispose();
        }

        // Assurez-vous de tuer les processus utilisant le fichier après avoir arrêté le processus ASP.NET
        string filePath = Path.Combine(projectPath, "bin/Debug/net6.0/Jeux-IHM");
        KillProcessesUsingFile(filePath);
    }

    [Given(@"Je suis en ""(.*)""")]
    public void GivenJeSuisEn(string host)
    {
        LaunchIHM();

        driver.Navigate().GoToUrl(host);
        Thread.Sleep(1000);
    }

    [When(@"Je clique ""(.*)"" pour")]
    public void WhenJeClique(string element, Table table)
    {
        switch (element)
        {
            case "Créer match":
                CreerMatch(table);
                break;
            case "Gagné point":
                GagnePoint(table);
                break;
            default:
                throw new Exception($"L'élément {element} n'est pas pris en charge");
        }
        
        Thread.Sleep(1000);
    }

    private void CreerMatch(Table table)
    {
        var row1 = table.Rows[0];
        var row2 = table.Rows[1];

        var player1Firstname = row1["Nom"];
        var player1Lastname = row1["Prenom"];
        var player2Firstname = row2["Nom"];
        var player2Lastname = row2["Prenom"];

        driver.FindElement(By.Id("player1-firstname")).SendKeys(player1Firstname);
        driver.FindElement(By.Id("player1-lastname")).SendKeys(player1Lastname);
        driver.FindElement(By.Id("player2-firstname")).SendKeys(player2Firstname);
        driver.FindElement(By.Id("player2-lastname")).SendKeys(player2Lastname);

        driver.FindElement(By.XPath(B_CREER_MATCH)).Click();
    }

    private void GagnePoint(Table table)
    {
        var row1 = table.Rows[0];

        var playerId = row1["idJoueur"];

        if (playerId == "1")
            driver.FindElement(By.Id("player1-button")).Click();
        else
            driver.FindElement(By.Id("player2-button")).Click();
    }


    [Then(@"Je dois avoir une vue ""(.*)""")]
    public void ThenJeDoisAvoirUnePage(string match, Table table)
    {
        Thread.Sleep(2000);
        string page = "/html/body/div/div/h2";

        // Verify the page title
        IWebElement pageTitle = driver.FindElement(By.XPath(page));
        Assert.Equal(match, pageTitle.Text);

        // Verify the table data
        var rows = table.Rows;
        for (int i = 0; i < rows.Count; i++)
        {
            var row = rows[i];
            var playerName = row["Joueur"];
            var previousSets = row["SETS PRÉCÉDENTS"];
            var sets = row["Sets"];
            var games = row["Jeux"];
            var points = row["Points"];

            var tablePlayerName =
                driver.FindElement(By.XPath($"/html/body/div/div/table/tbody/tr[{i + 1}]/td[1]")).Text;
            var tablePreviousSets =
                driver.FindElement(By.XPath($"/html/body/div/div/table/tbody/tr[{i + 1}]/td[2]")).Text;
            var tableSets = driver.FindElement(By.XPath($"/html/body/div/div/table/tbody/tr[{i + 1}]/td[3]")).Text;
            var tableGames = driver.FindElement(By.XPath($"/html/body/div/div/table/tbody/tr[{i + 1}]/td[4]")).Text;
            var tablePoints = driver.FindElement(By.XPath($"/html/body/div/div/table/tbody/tr[{i + 1}]/td[5]")).Text;

            Assert.Equal(playerName, tablePlayerName);
            Assert.Equal(previousSets, tablePreviousSets);
            Assert.Equal(sets, tableSets);
            Assert.Equal(games, tableGames);
            Assert.Equal(points, tablePoints);
        }
    }
}