using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LexiconOvning3.DTO;
using LexiconOvning3.Models;

namespace LexiconOvning3.Helpers;


public class VehicleHandler
{
    private List<Vehicle> _vehicles = new List<Vehicle>();

    // display list 
    public List<Vehicle> DisplayVehicles()
    {
        return _vehicles;

    }
    // create new vehicle and add to list
    public void CreateVehicle(VehicleData data)
    {
        Vehicle vehicle = data switch
        {
            CarData c => new Car(c.Brand, c.Model, c.Year.Value, c.Weight.Value, c.CarType.Value),
            ElectricScooterData e => new ElectricScooter(e.Brand, e.Model, e.Year.Value, e.Weight.Value, e.Range.Value),
            MotorcycleData m => new Motorcycle(m.Brand, m.Model, m.Year.Value, m.Weight.Value, m.EngineDisplacement),
            TruckData t => new Truck(t.Brand, t.Model, t.Year.Value, t.Weight.Value, t.CargoType.Value),
            _ => throw new ArgumentException("Unsupported vehicle type")
        };

        _vehicles.Add(vehicle);
    }



    // search for and get vehicle
    private Vehicle GetVehicle(string brand, string model)
    {
        return _vehicles.FirstOrDefault(v => v.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase)
                                                && v.Model.Equals(model, StringComparison.OrdinalIgnoreCase));
    }

    // update / change values
    public bool UpdateVehicle(string searchBrand, string searchModel, string? newBrand = null, string? newModel = null,
        int? newYear = null, double? newWeight = null)
    {
        Vehicle vehicleToUpdate = GetVehicle(searchBrand, searchModel);
        bool exists = vehicleToUpdate != null ? true : false;
        if (exists)
        {
            if (newBrand != null)
            {
                vehicleToUpdate.Brand = newBrand;
            }
            if (newModel != null)
            {
                vehicleToUpdate.Model = newModel;
            }
            if (newYear != null)
            {
                vehicleToUpdate.Year = newYear.Value;
            }
            if (newWeight != null)
            {
                vehicleToUpdate.Weight = newWeight.Value;
            }
            return exists;
        }
        return exists;

    }

}
