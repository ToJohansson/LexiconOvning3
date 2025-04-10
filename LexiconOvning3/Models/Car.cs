using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconOvning3.Models;

public class Car : Vehicle
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
}
