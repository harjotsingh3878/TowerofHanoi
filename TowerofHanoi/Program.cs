using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerofHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            Input inp = new Input();
            // read the number of discs in the game (3, 4 or 5)
            int Flag = 1;
            int nDisc = 0;
            while (Flag == 1)
            {
                nDisc = inp.GetDiscCount();
                if (nDisc == 3 || nDisc == 4 || nDisc == 5)
                    Flag = 0;
            }
            Game game = new Game(nDisc);
            game.Draw();
            do
            {
                // Get source and destination pegs 
                game.SrcPegPrompt();
                int src = inp.GetPosition();
                if (src < 0)
                    break;
                game.DstPegPrompt();
                int dst = inp.GetPosition();
                if (dst < 0)
                    break;
                // Try to move a disc from src to dst

                bool success = game.Move(src, dst);
                // Redraw the game board game.Draw();
                game.Draw();
                if (!success)
                {
                    game.Message("Invalid Move " + (src + 1) + " -> " + (dst + 1));
                }
            } while (!game.Win());//while (!game.Win());
            game.Message("Press any key to exit!");
            Console.ReadLine();
        }
    }
}
