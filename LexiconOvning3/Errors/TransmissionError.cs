using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconOvning3.Errors
{
    public class TransmissionError : SystemError
    {
        public override void ErrorMessage()
        {
            Console.WriteLine("Växellådsproblem: Reparation krävs!");
        }
    }
}
