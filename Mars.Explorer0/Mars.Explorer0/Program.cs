using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars.Explorer0
{
    class Program
    {

        static void Main(string[] args)
        {
            Tools.DimensionControl();
           
            Controller Voyager1 = new Controller( Tools.LocationControl(),Tools.OrderControl());
            Controller Voyager2 = new Controller(Tools.LocationControl(), Tools.OrderControl());
            Voyager1.Calculate();
            Voyager2.Calculate();
            Console.ReadLine();

        }
    
    }
}
