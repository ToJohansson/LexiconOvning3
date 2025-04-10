using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconOvning3.Models;

public class Motorcycle : Vehicle
{
    public string EngineDisplacement { get; set; }
    public Motorcycle(string brand, string model, int year, double weight, string engineDisplacement) : base(brand, model, year, weight)
    {
        EngineDisplacement = engineDisplacement;
    }
    public override string Stats()
    {
        return base.Stats() + $"Engine Displacement (cc): {EngineDisplacement,-6} ";
    }
    public override void StartEngine()
    {
        Console.WriteLine("Motorcycle starts, Bopp BOppppp bbbboppppp bbbbooooooppppppp!");
    }
}
