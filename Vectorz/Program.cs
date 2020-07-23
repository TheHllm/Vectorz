using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Vectorz
{
    class Program
    {
        static int scale = 50;
        static void Main(string[] args)
        {
            Console.SetBufferSize(1080,1920);
            Console.SetWindowSize(239,63);
            #region init
            //Create our vectors..
            Vector3[] arr = new Vector3[18];
            arr[0]  = new Vector3(-1, -1, -1);
            arr[1]  = new Vector3(-1, -1,  1);
            arr[2]  = new Vector3(-1, -1, -1);
            arr[3]  = new Vector3( 1, -1, -1);
            arr[4]  = new Vector3( 1, -1,  1);
            arr[5]  = new Vector3( 1, -1, -1);
            arr[6]  = new Vector3( 1,  1, -1);
            arr[7]  = new Vector3( 1,  1,  1);
            arr[8]  = new Vector3( 1,  1, -1);
            arr[9]  = new Vector3(-1,  1, -1);
            arr[10] = new Vector3(-1,  1,  1);
            arr[11] = new Vector3(-1,  1, -1);
            arr[12] = new Vector3(-1, -1, -1);
            arr[13] = new Vector3(-1, -1,  1);
            arr[14] = new Vector3( 1, -1,  1);
            arr[15] = new Vector3( 1,  1,  1);
            arr[16] = new Vector3(-1,  1,  1);
            arr[17] = new Vector3(-1, -1,  1);
            arr.Scale(scale);
            #endregion
            #region Rendering
            Vector3 angle = new Vector3();
            while (true)
            {
            Vector3[] ar = arr.Clone() as Vector3[];
                //rotate it
                ar.Rotate(angle);
                //Move so it is on the Screen:
                ar = ar + new Vector3(2 * scale, 2 * scale, 2 * scale);
                //transform to 2d
                Vector2[] trans = ar.Transform();

                //draw each vector....
                Console.BackgroundColor = ConsoleColor.White;
                var a = new Exception();
                Parallel.For (0,trans.Length-1, i=>
                {
                    Draw(trans[i],trans[i+1],a,i);
                });
                Console.BackgroundColor = ConsoleColor.Black;
                Thread.Sleep(250);
                Console.Clear();
                angle = angle + new Vector3(0.20,0.20,0.20);
            }
            #endregion
        }
        #region helperfunctions
        public static void Draw(Vector2 v1, Vector2 v2, object dummy, int color)
        {
            int dist = Convert.ToInt32(v1.Distance(v2));
            for (int i = 0;i<dist;i++)
            {
                Vector2 v = (v2 - v1);
                v.Normalize();
                Vector2 pos = v1+ v * i;
                int x = Convert.ToInt32(pos.x) + Convert.ToInt32(scale);
                int y = Convert.ToInt32(pos.y) + Convert.ToInt32(scale);
                if (x > 0 && y > 0)
                {
                    lock (dummy)
                    {
                        Console.SetCursorPosition(x*2, y);
                        Console.BackgroundColor = (ConsoleColor)(color%15+1);
                        Console.Write("  ");
                    }
                }
            }
        }
        #endregion
    }
}
