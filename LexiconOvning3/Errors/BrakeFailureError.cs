using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconOvning3.Errors
{
    public class BrakeFailureError : SystemError
    {
        public override void ErrorMessage()
        {
            Console.WriteLine("Bromsfel: Fordonet är osäkert att köra!");
        }
    }
}
