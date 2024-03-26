using System;

class TicTacToe
{
    private char[,] board;
    private char currentPlayer;
    private bool gameEnd;

    public TicTacToe()
    {
        board = new char[3, 3];
        currentPlayer = 'X';
        gameEnd = false;
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                board[row, col] = '-';
            }
        }
    }

    public void PlayGame()
    {
        while (!gameEnd)
        {
            DrawBoard();
            if (currentPlayer == 'X')
            {
                UserMove();
            }
            else
            {
                ComputerMove();
            }
            CheckForWinner();
            SwitchPlayer();
        }
    }

    private void DrawBoard()
    {
        Console.WriteLine("-------------");
        for (int row = 0; row < 3; row++)
        {
            Console.Write("| ");
            for (int col = 0; col < 3; col++)
            {
                Console.Write(board[row, col] + " | ");
            }
            Console.WriteLine();
            Console.WriteLine("-------------");
        }
    }

    private void UserMove()
    {
        Console.WriteLine("Your move. Enter row and column (e.g., 1 1 for the first row, first column):");
        string[] input = Console.ReadLine().Split();
        int row = int.Parse(input[0]) - 1;
        int col = int.Parse(input[1]) - 1;
        if (IsValidMove(row, col))
        {
            board[row, col] = 'X';
        }
        else
        {
            Console.WriteLine("Invalid move. Try again.");
            UserMove();
        }
    }

    private bool IsValidMove(int row, int col)
    {
        return row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == '-';
    }

    private void ComputerMove()
    {
        Random random = new Random();
        int row, col;
        do
        {
            row = random.Next(0, 3);
            col = random.Next(0, 3);
        } while (!IsValidMove(row, col));
        board[row, col] = 'O';
        Console.WriteLine("Computer chose row " + (row + 1) + " and column " + (col + 1) + ".");
    }

    private void CheckForWinner()
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] != '-')
            {
                Console.WriteLine(board[i, 0] + " wins!");
                gameEnd = true;
                return;
            }
            if (board[0, i] == board[1, i] && board[1, i] == board[2, i] && board[0, i] != '-')
            {
                Console.WriteLine(board[0, i] + " wins!");
                gameEnd = true;
                return;
            }
        }

        if ((board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] ||
            board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0]) && board[1, 1] != '-')
        {
            Console.WriteLine(board[1, 1] + " wins!");
            gameEnd = true;
            return;
        }

        bool isTie = true;
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (board[row, col] == '-')
                {
                    isTie = false;
                    break;
                }
            }
        }
        if (isTie)
        {
            Console.WriteLine("It's a tie!");
            gameEnd = true;
        }
    }

    private void SwitchPlayer()
    {
        currentPlayer = GetCurrentPlayer() == 'X' ? 'O' : 'X';
    }

    private char GetCurrentPlayer()
    {
        return currentPlayer;
    }
}

class Program
{
    static void Main(string[] args)
    {
        TicTacToe game = new TicTacToe();
        game.PlayGame();
    }
}