using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Explorer0
{
   public class Controller
    {
        
        string[] _loc;
        string _order;

        public Controller( string[] loc, string order)
        {
            _loc = loc;
            _order = order;
        }
        public void Calculate()
        {
            int dimX = Dimension.DimX;
            int dimY = Dimension.DimY;

            int locX =Convert.ToInt32(_loc[0]);
            int locY = Convert.ToInt32(_loc[1]);
            int locD2 = Convert.ToInt32(_loc[2]);
            string locD1 = "";



            string direktif = _order;
          
            for (int i = 0; i < direktif.Length; i++)
            {
                if (direktif[i].ToString().ToUpper() == "L")
                {
                    locD2 -= 90;
                }
                if (direktif[i].ToString().ToUpper() == "R")
                {
                    locD2 += 90;
                }
                if (direktif[i].ToString().ToUpper() == "M")
                {
                    if (locD2 % 360 == 0 && locY < dimY)
                    {
                        locD1 = "N";
                        locY += 1;
                    }
                    if ((locD2 % 360 == 90 && locX < dimX) || (locD2 % 360 == -270 && locX < dimX))
                    {
                        locD1 = "E";
                        locX += 1;
                    }
                    if ((locD2 % 360 == 180 && locY > 0) || (locD2 % 360 == -180 && locY > 0))
                    {
                        locD1 = "S";
                        locY -= 1;
                    }
                    if ((locD2 % 360 == -90 && locX > 0) || (locD2 % 360 == 270 && locX > 0))
                    {
                        locD1 = "W";
                        locX -= 1;
                    }
                }
            }
            Console.WriteLine(string.Format("{0} , {1} , {2}", locX, locY, locD1));
           
        }

    }
}
