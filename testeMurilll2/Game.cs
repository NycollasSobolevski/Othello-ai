using System;
using System.Collections.Generic;

public class Game
{
    public ulong CurrentPlays { get; set; }
    public Game Enemy { get; set; }

    int lastColumn = 0;
    int lastRow = 0;
    bool[] data;
    byte[] sums;

    public Game()
    {      
        data = new bool[63];
        sums = new byte[63];
    }

    public (int column, int row) GetLast()
        => (lastColumn, lastRow);

    public ulong Play(int column, int row)
    {
        int table = 64;
        int width = (int)Math.Sqrt(table);
        column--;
        row--;
        System.Console.WriteLine(column + row);
        int objectivePosition = (width * column) + row;
        ulong binResult = CurrentPlays >>> objectivePosition;
        //TODO verificar canplay do enimigo e sua para ver se nao há prça de ambos
        return CurrentPlays + (ulong)(1 << objectivePosition); ;
    }


    public bool CanPlay(int column, int row)
    {
        int table = 64;
        int width = (int)Math.Sqrt(table);
        column--;
        row--;
        System.Console.WriteLine(column + row);
        int objectivePosition = (width * column) + row;
        ulong binResult = CurrentPlays >>> objectivePosition;
        bool objectiveIsOcupped =
            (binResult & ((ulong)table - (ulong)objectivePosition + 1)) == 0;


        return objectiveIsOcupped;
    }

    public bool GameEnded()
    {
        //ToDo
        if (CanPlay(1, 1))
            return false;

        return true;
    }

    public Game Clone()
    {
        Game copy = new Game();
        Array.Copy(
            this.data,
            copy.data,
            this.data.Length
        );
        Array.Copy(
            this.sums,
            copy.sums,
            this.sums.Length
        );
        return copy;
    }

    public IEnumerable<Game> Next()
    {
        var clone = this.Clone();

        for (int p = 0; p < 3; p++)
        {
            if (data[p])
                continue;

            clone.Play(1, p);
            yield return clone;
            clone = this.Clone();
        }
    }
}