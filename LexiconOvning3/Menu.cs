using LexiconOvning3.DTO;
using LexiconOvning3.Errors;
using LexiconOvning3.Helpers;
using LexiconOvning3.Models;
using LexiconOvning3.Models.Enums;
using LexiconOvning3.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconOvning3;

public class Menu
{
    /**
        F: Vad händer om du försöker lägga till en Car i en lista av Motorcycle?
        S: Jag kommer få ett kompilering fel då Car inte går att konvertera till en motorcycle.

        F: Vilken typ bör en lista vara för att rymma alla fordonstyper?
        S: Så som jag har gjort i min kod ärver alla subklasser av den abstrakta klassen Vehicle.

        F: Kommer du åt metoden Clean() från en lista med typen List<Vehicle>?
        S: Nej inte direkt, MEN med att casta om de subklasser av Vehicle som ärver av interfacet ICleanable
           så kommer det att fungera. 

        F: Vad är fördelarna med att använda ett interface här istället för arv?
        S: Större flexbilitet, eftersom vi bara kan arva från en klass, gör interface det mycket mer flexibelt. Interface innehåller bara "kontraktet" medans en abstrakt klass kan innehålla så mycket mer, props, metoder med logik osv. De klasser som inte ska/behöver ska inte tvingas använda Clean(). Vi behöver inte bry oss vilka arv som finns där.

     * */
    public void Run()
    {
        VehicleHandler _vehicleHandler = new VehicleHandler();

        ConsoleHelper.MessageOutput("*****************");

        bool isRunning = true;

        do
        {
            ConsoleHelper.MessageOutput("1. Create a new Vehicle.\n" +
                "2. Update a vehicle.\n" +
                "3. Display all vehicles.\n" +
                "4. Show error messages.\n" +
                "5. List and call methods.\n" +
                "0. Exit program.");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    CreateNewVehicle();
                    break;
                case "2":
                    UpdateVehicle();
                    break;
                case "3":
                    DisplayAllVehicles();
                    break;
                case "4":
                    ShowErrorMessages();
                    break;
                case "5":
                    ListAndCallMethods();
                    break;
                case "0":
                    isRunning = false;
                    break;
                default:
                    ConsoleHelper.MessageOutput("Please try again.");
                    break;
            }
            Console.ReadKey();
            Console.Clear();
        } while (isRunning);

        void UpdateVehicle()
        {
            ConsoleHelper.MessageOutput("*** Update a Vehicle ***\nSearch by Brand and Model.");

            Console.Write("Search Brand: ");
            string searchBrand = Console.ReadLine();

            Console.Write("Search Model: ");
            string searchModel = Console.ReadLine();

            ConsoleHelper.MessageOutput("\nNow enter new values (or leave blank to keep current):");
            var updatedData = PromptVehicleInput(isUpdate: true);

            bool isSuccess = _vehicleHandler.UpdateVehicle(
                searchBrand,
                searchModel,
                updatedData.Brand,
                updatedData.Model,
                updatedData.Year,
                updatedData.Weight
            );

            ConsoleHelper.MessageOutput(isSuccess ? "Vehicle is now updated." : "Vehicle does not exists.");
        }


        void CreateNewVehicle()
        {
            int type = AskForTypeOfVehicle();

            VehicleData data = type switch
            {
                1 => CreateCarData(),
                2 => CreateElectricScooterData(),
                3 => CreateMotorcycleData(),
                4 => CreateTruckData(),
                _ => null
            };

            if (data is null)
            {
                ConsoleHelper.MessageOutput("Invalid input.");
                return;
            }

            _vehicleHandler.CreateVehicle(data);
            ConsoleHelper.MessageOutput("Vehicle created successfully.");
        }


        void DisplayAllVehicles()
        {
            List<Vehicle> vehicles = _vehicleHandler.DisplayVehicles();

            foreach (Vehicle vehicle in vehicles)
            {
                ConsoleHelper.MessageOutput(vehicle.Stats());
            }
        }

        VehicleRecordHelper PromptVehicleInput(bool isUpdate = false)
        {
            ConsoleHelper.MessageOutput(isUpdate ? "*** Update Vehicle Info ***" : "*** Create a New Vehicle ***");

            string PromptString(string prompt)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                return input == "" ? null : input;
            }

            int? PromptInt(string prompt)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out int result)) return result;
                return null;
            }

            double? PromptDouble(string prompt)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (double.TryParse(input, out double result)) return result;
                return null;
            }

            string brand = PromptString(isUpdate ? "Enter brand (or leave blank): " : "Enter brand");
            string model = PromptString(isUpdate ? "Enter model (or leave blank): " : "Enter model");
            int? year = PromptInt(isUpdate ? "Enter year (or leave blank): " : "Enter year");
            double? weight = PromptDouble(isUpdate ? "Enter weight (or leave blank): " : "Enter weight");

            return new VehicleRecordHelper(
                string.IsNullOrWhiteSpace(brand) ? null : brand,
                string.IsNullOrWhiteSpace(model) ? null : model,
                year,
                weight
             );
        }

        void ListAndCallMethods()
        {
            List<Vehicle> vList = _vehicleHandler.DisplayVehicles();
            foreach (Vehicle v in vList)
            {
                Console.WriteLine(v.Stats());
                v.StartEngine();
                if (v is ICleanable cleanable)
                    cleanable.Clean();
            }
        }

    }

    private TruckData CreateTruckData()
    {
        ConsoleHelper.MessageOutput("*** Create a truck ***");
        return new TruckData(
            ConsoleHelper.AskRequired("Brand"),
            ConsoleHelper.AskRequired("Model"),
            ConsoleHelper.AskInt("Year"),
            ConsoleHelper.AskDouble("Weight"),
            ConsoleHelper.AskEnum<TypeOfCargo>("Cargo type")
            );
    }

    private MotorcycleData CreateMotorcycleData()
    {
        ConsoleHelper.MessageOutput("*** Create a motorcycle ***");
        return new MotorcycleData(
            ConsoleHelper.AskRequired("Brand"),
            ConsoleHelper.AskRequired("Model"),
            ConsoleHelper.AskInt("Year"),
            ConsoleHelper.AskDouble("Weight"),
            ConsoleHelper.Ask("Engine displacement (cc)")
            );
    }

    private ElectricScooterData CreateElectricScooterData()
    {
        ConsoleHelper.MessageOutput("*** Create a electric scooter ***");
        return new ElectricScooterData(
            ConsoleHelper.AskRequired("Brand"),
            ConsoleHelper.AskRequired("Model"),
            ConsoleHelper.AskInt("Year"),
            ConsoleHelper.AskDouble("Weight"),
            ConsoleHelper.AskInt("Range")
            );
    }

    private CarData CreateCarData()
    {
        ConsoleHelper.MessageOutput("*** Create a new car ***");
        return new CarData(
            ConsoleHelper.AskRequired("Brand"),
            ConsoleHelper.AskRequired("Model"),
            ConsoleHelper.AskInt("Year"),
            ConsoleHelper.AskDouble("Weight"),
            ConsoleHelper.AskEnum<TypeOfCar>("Type of Car")
            );
    }

    private int AskForTypeOfVehicle()
    {
        do
        {
            ConsoleHelper.MessageOutput("What type of vehicle do you want to create?\n" +
                              "1. Car.\n" +
                              "2. Electric Scooter.\n" +
                              "3. Motorcycle.\n" +
                              "4. Truck.");
            string typeOfVehicle = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(typeOfVehicle) && int.TryParse(typeOfVehicle, out int result))
            {
                return result;
            }
            else
            {
                ConsoleHelper.MessageOutput("Invalid input. Please enter a number between 1 and 4.");
            }
        } while (true);
    }


    private void ShowErrorMessages()
    {
        List<SystemError> errors = new List<SystemError>
        {
            new TransmissionError(),
            new BrakeFailureError(),
            new EngineFailureError()
        };

        foreach (var error in errors)
        {
            error.ErrorMessage();
        }
    }

}
