using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerofHanoi
{
    class Peg
    {
        int capacity = 0;
        public int sp = 0;
        Disc[] Stack; // = new Disc[5];
        int MaxDisc;
        int Left;
        int Top;
        int Bot;

        /*  Create a peg with the following parameters: 
            maxDisc: the maximum number of discs in the game 
            left, top, bot: 
            the peg is draw as a line of two pipes (||) 
            from <left, top> to <left, bot>*/

        public Peg(int maxDisc, int left, int top, int bot)
        {
            Stack = new Disc[maxDisc];
           // MaxDisc = maxDisc;
            Left = left;
            Top = top;
            Bot = bot;
            this.capacity = MaxDisc;
          
        }

        /*Pushes dsc into the peg 
        if the peg is empty 
        or dsc.Size < size of the top disc in peg*/

        public void Push(Disc disc)
        {
            Stack[sp] = disc;

            disc.Move(this.Left, this.Bot-sp);
            ++sp;
        }

        /* Pops a Disc from the peg and return*/

        public Disc Pop()
        {
            --sp;
            return Stack[sp];
        }

        /* Returns the top most Disc without popping*/

        public Disc Peek()
        {

            if(sp>0)
            {
                Disc peekdisc = Stack[this.sp-1];
               return peekdisc;
            }
            return null;
            //return Stack[sp-1];
            
         /*   int stk = sp - 1;
            if (stk >= 0)
                return this.Stack[sp - 1];
            else
                return null;*/
        }

        /* Draw the peg and all the discs in it. */

        public void Draw()
        {
            //Console.ResetColor();
            while (Top < Bot+1)
            {
                Console.SetCursorPosition(Left, Top);
                Console.Write("||");
                Top++;
            }

            for (int i = 0; i < sp; ++i)
            {
                Stack[i].Draw();
            }

            Top = 10;
        }

        /* Returns the number of discs in the peg*/

        public int DiscCount()
        {
           return MaxDisc;
        }


    }
}
