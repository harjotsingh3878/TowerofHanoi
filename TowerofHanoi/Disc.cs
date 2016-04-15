using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerofHanoi
{
    class Disc
    {
        int Size;
        private int Left;
        private int Top;
        ConsoleColor Color;
        /* Returns the size of the disc 
        this is a property with get method only*/
        public int Size1  
        {
            get
            {
                return Size;
            }
            
        }

        /* Constructor takes size, left, top and color. 
         size can be between 1 to 5*/
        public Disc(int size, int left, int top, ConsoleColor color)
        {
            Size = size;
            Left = left;
            Top = top;
            Color = color;
        }

        /* Draws the disc by printing 2*size spaces starting 
         from position <left-size+1, top>, and then drawing 
         2 two pipes (“||”) at position <left, top>*/

        public void Draw()
        {
            int choose = 2 * Size;
            Console.BackgroundColor = Color;
            Console.SetCursorPosition(Left - choose, Top);

            for (int i = 0; i < (choose+1) * 2; ++i)
            {             
                Console.Write(" ");
            }
            Console.SetCursorPosition(Left, Top);
            Console.Write("||");
            Console.ResetColor();
        }

        /*Sets the coordinate of the disc to <left, top>
        without actually drawing the disc on screen*/
        public void Move(int left, int top)
        {
            this.Left = left;
            this.Top = top;
        }
    }
}
