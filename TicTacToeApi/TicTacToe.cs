namespace TicTacToeApi
{
    public enum Player
    {
        None,
        X,
        O
    }

    public class TicTacToe
    {
        private Player[,] board;
        public Player CurrentPlayer { get; private set; }

        public TicTacToe()
        {
            board = new Player[3, 3];
            CurrentPlayer = Player.X;
        }

        public void PlacePiece(int row, int col)
        {
            if (row < 0 || row > 2 || col < 0 || col > 2)
                throw new ArgumentException("Position invalide");

            if (board[row, col] != Player.None)
                throw new ArgumentException("Position déjà occupée");

            board[row, col] = CurrentPlayer;
            CurrentPlayer = (CurrentPlayer == Player.X) ? Player.O : Player.X;
        }

        public Player GetPiece(int row, int col)
        {
            if (row < 0 || row > 2 || col < 0 || col > 2)
                throw new ArgumentException("Position invalide");

            return board[row, col];
        }

        public Player CheckWin()
        {
            // verif rangées
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] != Player.None)
                    return board[i, 0];
            }

            // verif colonnes 
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == board[1, i] && board[1, i] == board[2, i] && board[0, i] != Player.None)
                    return board[0, i];
            }

            // diagonals
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != Player.None)
                return board[0, 0];
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != Player.None)
                return board[0, 2];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == Player.None)
                    {
                        return Player.None;
                    }
                }
            }

            return Player.None; // L'égalité
        }
    }
}