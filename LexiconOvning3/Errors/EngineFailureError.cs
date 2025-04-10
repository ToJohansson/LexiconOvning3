using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconOvning3.Errors
{
    public class EngineFailureError : SystemError
    {
        public override void ErrorMessage()
        {
            Console.WriteLine("Motorfel: Kontrollera motorstatus!");
        }
    }
}
