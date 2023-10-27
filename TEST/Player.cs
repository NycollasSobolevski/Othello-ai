using System.Runtime.InteropServices.ObjectiveC;

public class Player
{
    public ulong CurrentPlays { get; set; }
    public Player Enemy { get; set; }
    public List<ulong> PossibleMoves = new();

    public List<ulong> Plays (int column, int row) {
        List<ulong> possibleResults = new() ;
        int table = 64;
        int width = (int)Math.Sqrt(table);
        column --;
        row --;
        int objectivePosition = (width * column) + row;
        ulong binResult = CurrentPlays >>> objectivePosition;

        bool top    = Enemy.HavePiece(column, row - 1);
        bool bottom = Enemy.HavePiece(column, row + 1);
        bool left   = Enemy.HavePiece(column-1, row);
        bool right  = Enemy.HavePiece(column+1, row);
        bool Diag1  = Enemy.HavePiece(column-1, row - 1);
        bool Diag2  = Enemy.HavePiece(column+1, row - 1);
        bool Diag3  = Enemy.HavePiece(column-1, row + 1);
        bool Diag4  = Enemy.HavePiece(column+1, row + 1);

        if (top)
        {
            int qtd = 0;
            while(top){
                top = Enemy.HavePiece(column, row -1 -qtd);
                qtd++;
            }
            System.Console.WriteLine($"Top possibles move {qtd}");
            // CurrentPlays + (ulong)(1 << objectivePosition) //movendo 1 
            PossibleMoves.Add(CurrentPlays + (ulong)(1 << (width * column) + (row -qtd)));
            
        }
        if (bottom)
        {
            int qtd = 0;
            while(bottom){
                bottom = Enemy.HavePiece(column, row +1 +qtd);
                qtd++;
            }
            System.Console.WriteLine($"Bottom possibles move {qtd}");
            ulong move = CurrentPlays + (ulong)(1 << (width * column) + row + qtd);
            PossibleMoves.Add(move);
        }
        if (right)
        {
            int qtd = 0;
            while(right){
                right = Enemy.HavePiece(column +1 +qtd, row );
                qtd++;
            }
            System.Console.WriteLine($"Right possibles move {qtd}");
            PossibleMoves.Add(CurrentPlays + (ulong)(1 << (width * (column + 1)) + row));
        }
        if (left)
        {
            int qtd = 0;
            while(left){
                left = Enemy.HavePiece(column -1 -qtd, row );
                qtd++;
            }
            System.Console.WriteLine($"Left possibles move {qtd}");
            PossibleMoves.Add(CurrentPlays + (ulong)(1 << (width * (column - 1)) + row));
        }
        return possibleResults;
    } 

    public bool HavePiece (int column, int row) {
        int table = 64;
        int width = (int)Math.Sqrt(table);

        int objectivePosition = (width * column) + row;
        ulong binResult = CurrentPlays >>> objectivePosition - 1;
        bool isOcupped = (CurrentPlays & ((ulong)1 << objectivePosition)) > 0; 

        return isOcupped;
    }

    public void SearchPiece () {
        ulong clone = CurrentPlays;

        for(int i =0; i <= 63; i++){
            bool index = ((clone >>> i) & 1) > 0;
            if(index){
                int x = (i / 8) + 1;
                int y = (i % 8) + 1;
                System.Console.WriteLine($"------Peça {i} x:{x}, y:{y}");
                Plays(y,x);
            }
        }
    }

}