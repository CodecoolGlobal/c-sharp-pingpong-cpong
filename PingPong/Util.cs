using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong
{
    class Util
    {

        public static Random random = new Random();

        public static int getRandomNumber(int maxValue)
        {
            return random.Next(maxValue);
        }

       
    }
}
