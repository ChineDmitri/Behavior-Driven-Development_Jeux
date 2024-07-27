namespace MastermindApi
{
    public class Mastermind
    {
        public string secretCode { get; private set; }
        private int codeLength;
        private int colorCount;

        public Mastermind(int length, int colors)
        {
            codeLength = length;
            colorCount = colors;
        }

        public void GenerateCode()
        {
            Random random = new Random();
            secretCode = new string(Enumerable.Repeat(0, codeLength)
                .Select(_ => (char)('0' + random.Next(0, colorCount)))
                .ToArray());
        }

        public void SetCode(string code)
        {
            if (code.Length != codeLength || !code.All(c => char.IsDigit(c) && c - '0' < colorCount))
            {
                throw new ArgumentException("Code invalide");
            }

            secretCode = code;
        }

        public (int ExactMatches, int ColorMatches) CheckGuess(string guess)
        {
            if (guess.Length != codeLength)
            {
                throw new ArgumentException("La longueur de la supposition est incorrecte");
            }

            int exactMatches = 0;
            int colorMatches = 0;

            int[] secretCount = new int[colorCount];
            int[] guessCount = new int[colorCount];

            for (int i = 0; i < codeLength; i++)
            {
                if (guess[i] == secretCode[i])
                {
                    exactMatches++;
                }
                else
                {
                    secretCount[secretCode[i] - '0']++;
                    guessCount[guess[i] - '0']++;
                }
            }

            for (int i = 0; i < colorCount; i++)
            {
                colorMatches += Math.Min(secretCount[i], guessCount[i]);
            }

            return (exactMatches, colorMatches);
        }
    }
}