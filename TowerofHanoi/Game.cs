using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerofHanoi
{
    class Game
    {
        int NDisc;
        int Moves = 0;
        static Peg[] pegs;
        static Disc[] disc;
       

        /*Constructor : 
         takes the number of discs ( nDisc ) in the game. 
         1. Creates 3 pegs 
         2. Creates n discs with size 1, 2, 3 etc. and pushes them to peg 0 
         3. Sets Console size to Map.MaxLeft and Map.MaxTop */
        
        public Game(int nDisc)
        {
            NDisc = nDisc;
            pegs = new Peg[3];
            for (int i = 0; i < 3; i++ )
            
            {
                pegs[i] = new Peg(NDisc, Map.PegLeft[i], Map.PegTop, Map.PegBot);
            }
               /* pegs[0] = new Peg(NDisc, Map.PegLeft[0], Map.PegTop, Map.PegBot);
            pegs[1] = new Peg(NDisc, Map.PegLeft[1], Map.PegTop, Map.PegBot);
            pegs[2] = new Peg(NDisc, Map.PegLeft[2], Map.PegTop, Map.PegBot);
            */
            
          disc = new Disc[NDisc];
          for (int i = 0; i < NDisc; i++)
          {
              disc[i] = new Disc(i+1, Map.PegLeft[0], Map.PegTop, Map.DiskColors[i]);
          }
             /* disc[0] = new Disc(1, 20, 15, Map.DiskColors[0]);
            disc[1] = new Disc(2, 20, 16, Map.DiskColors[1]);
            disc[2] = new Disc(3, 20, 17, Map.DiskColors[2]);
            disc[3] = new Disc(4, 20, 17, Map.DiskColors[3]);
            disc[4] = new Disc(5, 20, 17, Map.DiskColors[4]);*/
            /*
            pegs[0].Push(disc[4]);
            pegs[0].Push(disc[3]);
            pegs[0].Push(disc[2]);
            pegs[0].Push(disc[1]);
            pegs[0].Push(disc[0]);
            */
          for (int i = nDisc - 1; i >= 0; i--)
          {
              pegs[0].Push(disc[i]);
          }
              Console.SetWindowSize(Map.MaxLeft, Map.MaxTop);
        }

        /*Moves top disk of Pegs[src] to Pegs[dst] if … 
          IF src and dst are in [0...2] and 
          Pegs[src] has a disc and 
          (Pegs[dst] is empty or 
          top disc in Pegs[dst] > top disc in Pegs[src])
          returns true if the move*/

        public bool Move(int src, int dst)
        {
            //if (0 <= src && src <= 2 && 0 <= dst && dst <= 2)
            //{
            
            if (pegs[src].Peek() != null && pegs[dst].Peek() == null )
            {
                //if (pegs[dst].Peek().Size1 > pegs[src].Peek().Size1)
                //{
                    pegs[dst].Push(pegs[src].Pop());
                    return true;

                //}
            //    return false;
            }
            else if (pegs[src].Peek() != null && pegs[dst].Peek() != null)
            {
                if(pegs[dst].Peek().Size1 > pegs[src].Peek().Size1)
                {
                    pegs[dst].Push(pegs[src].Pop());
                    return true;
                }
            }
            
                return false;

                //else
                //{
                //    pegs[dst].Push(pegs[src].Pop());
                //    return true;
                //}


            //}
            //return false;
        }

       

        public void Message(string msg)
        {
            Console.SetCursorPosition(Map.MsgLeft, Map.MsgTop);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(msg);
            Console.ResetColor();
        }

        /* Draws the followings:
        0. Clear the screen first 
        1. Base line from <Map.Baseleft, Map.BaseTop> to 
        <Map.BaseRight, Map.BaseTop> 
        2. Three pegs and the discs in them 
        3. Number of moves at <Map.MovesLeft, Map.MovesTop>*/

        public void Draw()
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            int Counter = Map.BaseLeft;
            while (Counter <= Map.BaseRight)
            {
                Console.SetCursorPosition(Counter, Map.BaseTop);
                Console.Write("_");
                Counter++;
            }
            for (int i = 0; i < 3;i++)
            {
                pegs[i].Draw();
            }


            Console.ResetColor();
            Console.SetCursorPosition(Map.MovesLeft, Map.MovesTop);
            Console.Write("Moves:" + Moves);
            Moves++;
        }

        /* Checks if the game is over, 
        i.e. right peg has all the discs*/

        public bool Win()
        {
            if (pegs[2].Peek() != null)
            {
                if (pegs[2].sp == NDisc)
                    return true;
                else
                    return false;
            }
            else
                return false;

           
        }

        /* Prints source peg prompt "Src peg (1,2,3,q): " 
         at position <Map.SrcLeft, Map.SrcTop>*/

        public void SrcPegPrompt()
        {
            Console.SetCursorPosition(Map.SrcLeft, Map.SrcTop);
            Console.Write("Src peg (1,2,3,q): ");
        }

        /* Prints destination peg prompt "Dst peg (1,2,3,q): " 
         at position <Map.DstLeft, Map.DstTop>*/

        public void DstPegPrompt()
        {
            Console.SetCursorPosition(Map.DstLeft, Map.DstTop);
            Console.Write("Dst peg (1,2,3,q): ");
        }
    }
}
