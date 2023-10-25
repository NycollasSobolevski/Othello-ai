using System.Runtime.InteropServices.ObjectiveC;

public class Player
{
    public ulong CurrentPlays { get; set; }
    public Player Enemy { get; set; }

    public ulong Play (int column, int row) {
        int table = 64;
        int width = (int)Math.Sqrt(table);
        column --; 
        row --;
        System.Console.WriteLine(column+row);
        int objectivePosition = (width * column) + row;
        ulong binResult = CurrentPlays >>> objectivePosition;
        //TODO verificar canplay do enimigo e sua para ver se nao há prça de ambos
        return CurrentPlays + (ulong)(1 << objectivePosition);;
    } 

    public bool CanPlay (int column, int row) {
        int table = 64;
        int width = (int)Math.Sqrt(table);
        column --; 
        row --;
        System.Console.WriteLine(column+row);
        int objectivePosition = (width * column) + row;
        ulong binResult = CurrentPlays >>> objectivePosition;
        bool objectiveIsOcupped = 
            (binResult & ((ulong)table - (ulong)objectivePosition + 1)) == 0;


        return objectiveIsOcupped;
    }
}