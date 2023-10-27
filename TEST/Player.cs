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
        ulong constant = 1;
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

            ulong _move = CurrentPlays + (constant << (width * column) + (row -qtd));
            
            PossibleMoves.Add(_move);
        }
        if (bottom)
        {
            int qtd = 0;
            while(bottom){
                bottom = Enemy.HavePiece(column, row +1 +qtd);
                qtd++;
            }
            ulong _move = CurrentPlays + (constant << (width * column) + row + qtd);
            PossibleMoves.Add(_move);
        }
        if (right)
        {
            int qtd = 0;
            while(right){
                right = Enemy.HavePiece(column +1 +qtd, row );
                qtd++;
            }
            ulong _move = CurrentPlays + (constant << (width * (column  + qtd) + row));

            PossibleMoves.Add(_move);
        }
        if (left)
        {
            int qtd = 0;
            while(left){
                left = Enemy.HavePiece(column -qtd, row );
                qtd++;
            }
            PossibleMoves.Add(CurrentPlays + (constant << (width * (column - 1 -qtd)) + row));
        }
        if(Diag1){
            int qtd = 0;
            while (Diag1){
                Diag1 = Enemy.HavePiece(column -1 -qtd, row -1 -qtd);
                qtd++;
            }
            int sla = width * (column -qtd) + (row -qtd);
            ulong _move = CurrentPlays + (constant << sla);
            PossibleMoves.Add(_move);
            // Console.WriteLine($"Diagonal 01 = {_move}");
        }
        if(Diag2){
            int qtd = 0;
            while (Diag2){
                Diag2 = Enemy.HavePiece(column +1 +qtd, row -1 -qtd);
                qtd++;
            }
            ulong _move = CurrentPlays + (constant << (width * (column +qtd) + (row -qtd)));
            PossibleMoves.Add(_move);
            // Console.WriteLine($"Diagonal 02 = {_move}");
        }
        if(Diag3){
            int qtd = 0;
            while (Diag3){
                Diag3 = Enemy.HavePiece(column -1 -qtd, row +1 +qtd);
                qtd++;
            }
            ulong _move = CurrentPlays + (constant << (width * (column -qtd) + row +qtd));
            PossibleMoves.Add(_move);
            // Console.WriteLine($"Diagonal 03 = {_move}");
        }
        if(Diag4){
            int qtd = 0;
            while (Diag4){
                Diag4 = Enemy.HavePiece(column +1 +qtd, row +1 +qtd);
                qtd++;
            }
            ulong _move = CurrentPlays + (constant << (width * (column +qtd) +row +qtd));
            PossibleMoves.Add(_move);
            // Console.WriteLine($"Diagonal 04 = {_move}");
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
                // System.Console.WriteLine($"------Peça {i} x:{x}, y:{y}");
                Plays(y,x);
            }
        }
    }

}