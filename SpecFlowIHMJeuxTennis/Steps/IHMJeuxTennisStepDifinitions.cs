using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace SpecFlowJeuxTennisApi;

[Binding]
public class IHMJeuxTennisStepDifinitions
{
    IWebDriver driver = new ChromeDriver();

    private string B_CREER_MATCH = "/html/body/div/button";

    private string LINE_PLAYER_1 = "/html/body/div/div/table/tbody/tr[1]/td";
    private string LINE_PLAYER_2 = "/html/body/div/div/table/tbody/tr[2]/td";

    [Given(@"Je suis en ""(.*)""")]
    public void GivenJeSuisEn(string host)
    {
        driver.Navigate().GoToUrl(host);
    }

    [When(@"Je clique ""(.*)""")]
    public void WhenJeClique(string element, Table table)
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

    [Then(@"Je dois avoir une page ""(.*)""")]
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