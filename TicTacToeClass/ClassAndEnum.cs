namespace Packt.Shared;

public class TicTacToeBoard
{
    public string[,]? board;
}

public enum TypePlayerEnum
{
    X, O,
}

public class TypePlayerClass
{
    public string? name;

    public void CreateNameForBoard(TypePlayerEnum typePlayer)
    {
        TypePlayerEnum xPlayer = TypePlayerEnum.X;

        if (typePlayer == xPlayer)
        {
            this.name = "X ";
        } else
        {
            this.name = "O ";
        }
    }
}