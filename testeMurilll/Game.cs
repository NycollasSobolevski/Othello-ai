// public class Game
// {
//     int boards = 0;
//     int lastBoard = 0;
//     int lastPosition = 0;
//     bool[] data;
//     byte[] sums;

//     public (int board, int position) GetLast()
//         => (lastBoard, lastPosition);

//     public void Play()
//     {
//         //ToDo
//     }

//     public bool CanPlay()
//     {
//         //ToDo
//         return true;
//     }

//     public bool GameEnded()
//     {
//         //ToDo
//         if (CanPlay())
//             return false;

//         return true;
//     }

//     public Game Clone()
//     {
//         Game copy = new Game();
//         Array.Copy(
//             this.data,
//             copy.data,
//             this.data.Length
//         );
//         Array.Copy(
//             this.sums,
//             copy.sums,
//             this.sums.Length
//         );
//         return copy;
//     }

//     public IEnumerable<Game> Next()
//     {
//         var clone = this.Clone();

//         if (!CanPlay())

//         for (int p = 0; p < 9; p++)
//         {
//             if (data[2 * 9 + p])
//                 continue;

//             clone.Play();
//             yield return clone;
//             clone = this.Clone();
//         }

//     }
// }