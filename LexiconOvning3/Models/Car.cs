using LexiconOvning3.Models.Enums;
using LexiconOvning3.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconOvning3.Models;

public class Car : Vehicle, ICleanable
{
    public TypeOfCar Type { get; set; }
    public Car(string brand, string model, int year, double weight, TypeOfCar type) : base(brand, model, year, weight)
    {
        Type = type;
    }

    public override string Stats()
    {
        return base.Stats() + $"Type: {Type,-6} ";
    }
    public override void StartEngine()
    {
        Console.WriteLine("Car starts, vroom vroom!");
    }

    public void Clean()
    {
        Console.WriteLine($"This {Type} really needs a wash!");
    }
}
