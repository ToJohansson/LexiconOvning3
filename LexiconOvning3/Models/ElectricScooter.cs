using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconOvning3.Models;

public class ElectricScooter : Vehicle
{
    public int Range { get; set; }
    public ElectricScooter(string brand, string model, int year, double weight, int range) : base(brand, model, year, weight)
    {
        Range = range;
    }
    public override string Stats()
    {
        return base.Stats() + $"Range: {Range,-6} ";
    }
    public override void StartEngine()
    {
        Console.WriteLine("Scooter starts, zzzzzzzeeeee !");
    }
}
