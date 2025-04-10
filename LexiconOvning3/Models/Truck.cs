using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LexiconOvning3.Models.Enums;
using LexiconOvning3.Models.Interfaces;
namespace LexiconOvning3.Models;

public class Truck : Vehicle, ICleanable
{
    public TypeOfCargo CargoType { get; set; }
    public Truck(string brand, string model, int year, double weight, TypeOfCargo cargoType) : base(brand, model, year, weight)
    {
        CargoType = cargoType;
    }
    public override string Stats()
    {
        return base.Stats() + $"Cargo Type: {CargoType,-6} ";
    }
    public override void StartEngine()
    {
        Console.WriteLine("Truck starts,BRvroom BRvroom!");

    }

    public void Clean()
    {
        Console.WriteLine($"{Brand} {Model} is getting a nice clean from all the mud.");
    }
}

