using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconOvning3.Models;

public abstract class Vehicle
{
    private const int inventionOfCar = 1886;
    private string brand;
    private string model;
    private int year;
    private double weight;

    public string Brand
    {
        get { return brand; }
        set
        {
            if (value.Length >= 2 && value.Length <= 20)
            {
                brand = value;
            }
            else
                throw new ArgumentException("Argument must be between 2 to 20 characters.");
        }
    }
    public string Model
    {
        get { return model; }
        set
        {
            if (value.Length >= 2 && value.Length <= 20)
                model = value;
            else
                throw new ArgumentException("Argument must be between 2 to 20 characters.");
        }
    }
    public int Year
    {
        get { return year; }
        set
        {
            if (value > inventionOfCar && value <= DateTime.Now.Year)
                year = value;
            else
                throw new ArgumentException($"Year of the car must be between {inventionOfCar} and {DateTime.Now.Year} ");
        }
    }
    public double Weight
    {
        get { return weight; }
        set
        {
            if (value > 0)
                weight = value;
            else
                throw new ArgumentException("Weight can not be a negative number.");

        }
    }
    public Vehicle(string brand, string model, int year, double weight)
    {
        Brand = brand;
        Model = model;
        Year = year;
        Weight = weight;
    }
    public abstract void StartEngine();
    public virtual string Stats()
    {
        return $"Brand: {Brand,-10} | Model: {Model,-10} | Year: {Year,-6} | Weight: {Weight,-6} | ";
    }
}
