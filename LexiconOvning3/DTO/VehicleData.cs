using LexiconOvning3.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconOvning3.DTO;

public abstract class VehicleData
{

    public string Brand { get; init; }
    public string? Model { get; init; }
    public int? Year { get; init; }
    public double? Weight { get; init; }
    protected VehicleData(string brand, string? model, int? year, double? weight)
    {
        Brand = brand;
        Model = model;
        Year = year;
        Weight = weight;
    }
}

public class CarData : VehicleData
{

    public TypeOfCar? CarType { get; init; }
    public CarData(string brand, string? model, int? year, double? weight, TypeOfCar carType) : base(brand, model, year, weight)
    {
        CarType = carType;
    }

}

public class MotorcycleData : VehicleData
{

    public string? EngineDisplacement { get; init; }
    public MotorcycleData(string brand, string? model, int? year, double? weight, string? engineDisplacement) : base(brand, model, year, weight)
    {
        EngineDisplacement = engineDisplacement;
    }
}

public class TruckData : VehicleData
{

    public TypeOfCargo? CargoType { get; init; }
    public TruckData(string brand, string? model, int? year, double? weight, TypeOfCargo? cargoType) : base(brand, model, year, weight)
    {
        CargoType = cargoType;
    }
}

public class ElectricScooterData : VehicleData
{
    public int? Range { get; init; }
    public ElectricScooterData(string brand, string? model, int? year, double? weight, int? range) : base(brand, model, year, weight)
    {
        Range = range;
    }
}

