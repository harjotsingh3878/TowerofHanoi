using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerofHanoi
{
    class Input
    {
        /* Reads a position from the user as follows: 
        -- valid inputs are 1, 2, 3 or q with return values 0, 1, 2 or -1, respectively.
        -- typed characters are not display on screen until the user types a valid character*/

        public int GetPosition()
        {
            ConsoleKeyInfo k = Console.ReadKey(true);
            switch (k.KeyChar)
            {

                case '1':
                    Console.Write("1");
                    return 0;
                case '2':
                    Console.Write("2");
                    return 1;
                case '3':
                    Console.Write("3");
                    return 2;
                case 'q':
                    Console.Write("quit");
                    return -1;
                default:
                    return -1;
            }
        }

        /* Reads the number of discs as follows: 
        -- Prompt with "How many discs (3...5)?" 
        -- Valid input is between 3 to 5 
        -- Should take care of invalid input*/

        public int GetDiscCount()
        {
            int ndiscs;
            Console.Write("How many discs (3...5)?");
            ndiscs = Convert.ToInt32(Console.ReadLine());
            if (ndiscs == 3 || ndiscs == 4 || ndiscs == 5)
                return ndiscs;
            else
                return 0;
        }
    }
}
