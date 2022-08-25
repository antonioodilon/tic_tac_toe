using System;
using System.Collections.Generic;
using Packt.Shared;

// Main()
TicTacToeBoard gameBoard = new TicTacToeBoard
{
    board = new string[,]
    {
        {"[]", "[]", "[]"},
        {"[]", "[]", "[]"},
        {"[]", "[]", "[]"},
    },
};

ticTacToe(gameBoard);

// ============== Functions ===================
void displayBoard(TicTacToeBoard boardParam)
{
    //const int amountRows = 3;
    //const int amountColumns = 3;

    Console.WriteLine("Current Tic-Tac-Toe board:\n");
    Console.WriteLine("  1   2   3");
    for (int i = 0; i < boardParam.board.GetLength(0); ++i)
    {
        for (int j = 0; j < boardParam.board.GetLength(1); ++j)
        {
            if ((i == 0 && j == 0) || (i == 1 && j == 0) || (i == 2 && j == 0))
            {
                Console.Write($"{i + 1} {boardParam.board[i,j]} ");
            } else
            {
                Console.Write($" {boardParam.board[i,j]} ");
            }
        }
        Console.Write("\n");
    }
}

(int, int) playerInput(TypePlayerClass player, TicTacToeBoard gameBoardParam) // (int, int) shorthand for tuple!
// See: https://www.delftstack.com/howto/csharp/return-multiple-values-from-a-function-in-csharp/
{
    bool successParseRow = false;
    bool successParseColumn = false;
    bool validInput = false;
    int playerInputIntRow = 0;
    int playerInputIntColumn = 0;

    Console.WriteLine($"\n====Player {player.name}'s turn!====\n");

    while (validInput == false)
    {
        displayBoard(gameBoardParam);

        Console.Write($"What row position are you going to place your {player.name}in? ");
        string? playerInputStrRow = Console.ReadLine();
        Console.Write("What column? ");
        string? playerInputStrColumn = Console.ReadLine();

        successParseRow = Int32.TryParse(playerInputStrRow, out playerInputIntRow);
        successParseColumn = Int32.TryParse(playerInputStrColumn, out playerInputIntColumn);
        if ((successParseRow == true) && (successParseColumn == true))
        {
            if (playerInputIntRow < 1 || playerInputIntRow > 3 ||
            playerInputIntColumn < 1 || playerInputIntColumn > 3)
            {
                Console.WriteLine("\n====Invalid input. Please choose valid row and column positions.====\n");
            } else
            {
                string chosenPosition = gameBoardParam.board[playerInputIntRow - 1, playerInputIntColumn - 1];
                //string? chosenPosition;

                if (chosenPosition != "[]")
                {
                    Console.WriteLine("\n====Position already taken. Choose a different one.====\n");
                } else
                {
                    chosenPosition = player.name;
                    gameBoardParam.board[playerInputIntRow - 1, playerInputIntColumn - 1] = chosenPosition;
                    validInput = true;
                }
            }
        } else
        {
            Console.WriteLine("\n====Error while parsing. Are you sure you only entered numbers?====\n");
        }
    }
        return (playerInputIntRow, playerInputIntColumn);
}

bool ticTacToe(TicTacToeBoard gameBoardParam)
{
    TypePlayerEnum xEnum = TypePlayerEnum.X;
    TypePlayerClass xClass = new();
    xClass.CreateNameForBoard(xEnum);

    TypePlayerEnum oEnum = TypePlayerEnum.O;
    TypePlayerClass oClass = new();
    oClass.CreateNameForBoard(oEnum);

    int roundNumber = 1;
    bool gameOver = false;
    while (gameOver == false)
    {
        Console.WriteLine($"\n=============Round {roundNumber}!=============\n");

        (int rowX, int columnX) = playerInput(xClass, gameBoardParam);
        Console.WriteLine($"{xClass.name}has chosen row {rowX} and column {columnX}");
        gameOver = conditionGameEnds(gameBoardParam, xClass);
        if (gameOver)
            break;

        (int rowO, int columnO) = playerInput(oClass, gameBoardParam);
        Console.WriteLine($"{oClass.name}has chosen row {rowO} and column {columnO}");
        gameOver = conditionGameEnds(gameBoardParam, oClass);

        ++roundNumber;
    }

    return gameOver;
}

//bool conditionGameEnds(TicTacToeBoard gameBoardParam, TypePlayer player)
bool conditionGameEnds(TicTacToeBoard gameBoardParam, TypePlayerClass player)
{
    int counterCondition1 = 0;
    int pointsCondition1 = 0;
    int pointsCondition2 = 0;
    int pointsCondition3 = 0;
    int pointsCondition4 = 0;
    int pointsCondition5 = 0;
    int pointsCondition6 = 0;
    int pointsCondition7 = 0;
    int pointsCondition8 = 0;
    int pointsConditionDraw = 0;

    for (int k = 0; k < gameBoardParam.board.GetLength(0); ++k)
    {
        for (int l = 0; l < gameBoardParam.board.GetLength(1); ++l)
        {
            // Condition 1 OK! Diagonal from right to left and from top to bottom
            if ((counterCondition1 % (gameBoardParam.board.GetLength(1) - 1) == 0) &&
            (counterCondition1 != 0) && (counterCondition1 < (gameBoardParam.board.Length - 1)))
            {
                if (gameBoardParam.board[k,l] == player.ToString())
                    pointsCondition1 += 1;
            }
            ++counterCondition1;
            
            if (k == l) //Condition 2 OK! Diagonal from left to right and from top to bottom
            {
                if (gameBoardParam.board[k,l] == player.name)
                    pointsCondition2 += 1;
            }
            
            if (l == 0) //Condition 3 OK! Straight line from row at index 0 and column at index 0
            //to row at index 2 and column at index 0
            {
                if (gameBoardParam.board[k,l] == player.name)
                    pointsCondition3 += 1;
            }

            if (l == 1)//Condition 4 OK! Straight line from row at index 0 and column at index 1
            //to row at index 2 and column at index 1
            {
                if (gameBoardParam.board[k,l] == player.name)
                    pointsCondition4 += 1;
            }

            if (l == 2)//Condition 5 OK! Straight line from row at index 0 and column at index 2
            //to row at index 2 and column at index 2
            {
                if (gameBoardParam.board[k,l] == player.name)
                    pointsCondition5 += 1;
            }

            if (k == 0)//Condition 6 OK! Straight line from row at index 0 and column at index 0
            //to row at index 0 and column at index 2
            {
                if (gameBoardParam.board[k,l] == player.name)
                    pointsCondition6 += 1;
            }

            if (k == 1)//Condition 7 OK! Straight line from row at index 1 and column at index 0
            //to row at index 1 and column at index 2
            {
                if (gameBoardParam.board[k,l] == player.ToString())
                    pointsCondition7 += 1;
            }

            if (k == 2)//Condition 8 OK! Straight line from row at index 2 and column at index 0
            //to row at index 0 and column at index 2
            {
                if (gameBoardParam.board[k,l] == player.name)
                    pointsCondition8 += 1;
            }

            if (gameBoardParam.board[k,l] != "[]")
            {
                pointsConditionDraw += 1;
            }
        }
    }

    if (pointsCondition1 == 3 || pointsCondition2 == 3 || pointsCondition3 == 3 ||
    pointsCondition4 == 3 || pointsCondition5 == 3 || pointsCondition6 == 3 ||
    pointsCondition7 == 3 || pointsCondition8 == 3)
    {
        Console.WriteLine($"\n===={player.name}has won!====\n");
        displayBoard(gameBoardParam);
        return true;
    } else if (pointsConditionDraw == 9)
    {
        Console.WriteLine($"\n====The match is a draw, and there is no winner!\n====");
        return true;
    } else
    {
        Console.WriteLine("\n====The match is still on!\n====");
        return false;
    }
}