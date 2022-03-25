using AutomobileSystem.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileSystem.Managers
{
    public class CarManager
    {
        Car[] data = new Car[0];

        public void Add(Car entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
        }
        public void EditCarModel(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].IdC == value)
                {
                    Console.WriteLine("Change the car's model");
                    int newModel = ScanerManager.ReadInteger("Please add the new model ID: ");
                    data[i].ModelId = newModel;
                    break;
                }
            }
        }
        public void EditYearCar(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].IdC == value)
                {
                    Console.WriteLine("Change the car's year");
                    int newYear = ScanerManager.ReadInteger("Please add the new car's year: ");
                    data[i].ProductYear = newYear;
                    break;
                }
            }
        }
        public void EditPriceCar(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].IdC == value)
                {
                    Console.WriteLine("Change the car's price");
                    int newPrice = ScanerManager.ReadInteger("Please add the new car's price: ");
                    data[i].Price = newPrice;
                    break;
                }
            }
        }
        public void EditColorCar(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].IdC == value)
                {
                    Console.WriteLine("Change the car's color");
                    string newColor = ScanerManager.ReadString("Please add the new car's color: ");
                    data[i].Color = newColor;
                    break;
                }
            }
        }
        public void EditEngineCar(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].IdC == value)
                {
                    Console.WriteLine("Change the car's engine");
                    double newEngine = ScanerManager.ReadDouble("Please add the new car's engine: ");
                    data[i].Engine = newEngine;
                    break;
                }
            }
        }
        public void EditFuelType(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].IdC == value)
                {
                    Console.WriteLine("You are changing the fuel type of car...");
                    FuelType numFuel = ScanerManager.ReadFuelMenu("Select the type of fuel: ");
                    switch (numFuel)
                    {
                        case FuelType.Gasoline:
                            data[i].FuelType = nameof(FuelType.Gasoline);
                            break;
                        case FuelType.Diesel:
                            data[i].FuelType = nameof(FuelType.Diesel);
                            break;
                        case FuelType.Hybrid:
                            data[i].FuelType = nameof(FuelType.Hybrid);
                            break;
                        case FuelType.Electro:
                            data[i].FuelType = nameof(FuelType.Electro);
                            break;
                        case FuelType.Gas:
                            data[i].FuelType = nameof(FuelType.Gas);
                            break;
                        default:
                            break;
                    }
                    break;
                }
            }
        }
        public void EditBodyType(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].IdC == value)
                {
                    Console.WriteLine("You are changing the body type of car...");
                    BodyType numFuel = ScanerManager.ReadBodyMenu("Select the type of body: ");
                    switch (numFuel)
                    {
                        case BodyType.Sedan:
                            data[i].BodyType = nameof(BodyType.Sedan);
                            break;
                        case BodyType.Hatchback:
                            data[i].FuelType = nameof(BodyType.Hatchback);
                            break;
                        case BodyType.Coupe:
                            data[i].FuelType = nameof(BodyType.Coupe);
                            break;
                        case BodyType.SportCar:
                            data[i].FuelType = nameof(BodyType.SportCar);
                            break;
                        case BodyType.StationWagon:
                            data[i].FuelType = nameof(BodyType.StationWagon);
                            break;
                        case BodyType.Minivan:
                            data[i].FuelType = nameof(BodyType.Minivan);
                            break;
                        case BodyType.PickupTrack:
                            data[i].FuelType = nameof(BodyType.PickupTrack);
                            break;
                        default:
                            break;
                    }
                    break;
                }
            }
        }
        public void Remove(Car entity)
        {
            int len = data.Length;
            int index = Array.IndexOf(data, entity);

            if (index == -1)
                return;
            for (int i = index; i < len - 1; i++)
            {
                data[i] = data[i + 1];
            }

            if (len > 0)

                Array.Resize(ref data, len - 1);
        }
        public void SingleCar(int value)
        {
            string singleCar = "";
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].IdC == value)
                {
                    singleCar = $"Car ID: {data[i].IdC} \n" +
                         $"Body type: {data[i].BodyType}\n" +
                        $"ProductYear: {data[i].ProductYear}\n" +
                        $"Price: {data[i].Price}\n" +
                        $"Color: {data[i].Color}\n" +
                        $"Engine: {data[i].Engine}\n" +
                        $"Fuel Type: {data[i].FuelType}\n" +
                        $"Model ID: {data[i].ModelId}";
                    break;
                }
            }
            Console.WriteLine("******************** Selected car ********************");
            Console.WriteLine(singleCar);
        }
        public Car[] GetAll()
            {
                return data; 
            }
             
    }
}
