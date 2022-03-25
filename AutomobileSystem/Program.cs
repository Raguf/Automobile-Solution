using AutomobileSystem.Infrastructure;
using AutomobileSystem.Managers;
using System;
using System.Linq;
using System.Text;

namespace AutomobileSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.Title = "Information about automobile";

            var brandMgr = new BrandManager();
            var modelMgr = new ModelManager();
            var carMgr = new CarManager();

        readMenu:
            PrintMenu();

            Menu m = ScanerManager.ReadMenu("Please, select from menu: ");


            switch (m)
            {
                case Menu.BrandAdd:
                    Console.Clear();
                    Brand b = new Brand();
                    b.Name = ScanerManager.ReadString("Please, add brand's name: ");
                    brandMgr.Add(b);
                    goto case Menu.BrandsAll;

                case Menu.BrandEdit:
                    Console.Clear();
                    ShowAllBrands(brandMgr);
                    Console.WriteLine("Please,add brand's name, which you edit");
                    int value = ScanerManager.ReadInteger("Please, enter the brand's Id, which you want to delete: ");
                    brandMgr.Edit(value);
                    goto case Menu.BrandsAll;

                case Menu.BrandRemove:
                    Console.Clear();
                    ShowAllBrands(brandMgr);
                    int idb = ScanerManager.ReadInteger("Please, enter the brand's Id, which you want to delete: ");
                    Brand br = brandMgr.GetAll().FirstOrDefault(item=>item.IdB == idb );
                    brandMgr.Remove(br);
                    goto case Menu.BrandsAll;

                case Menu.BrandSingle:
                    int idForSingleBrand = ScanerManager.ReadInteger("Please, enter the brand's Id, which you want to look in detail:  ");
                    Brand brSingle = brandMgr.GetAll().FirstOrDefault(item => item.IdB == idForSingleBrand);

                    Console.WriteLine($"-----------------------------------" +
                        $"Brand name: {brSingle.Name}");

                    foreach (var item in modelMgr.GetAll())
                    {
                        if (item.BrandId == brSingle.IdB)
                            Console.WriteLine(item);
                    }
                    goto readMenu;

                case Menu.BrandsAll:
                    Console.Clear();
                    ShowAllBrands(brandMgr);
                    goto readMenu;

                case Menu.ModelAdd:
                    Console.Clear();
                    Model md = new Model();
                    md.Name = ScanerManager.ReadString("Please, add model's name: ");

                    Console.WriteLine("------------");
                    ShowAllBrands(brandMgr);
                    Console.WriteLine("------------");

                    md.BrandId = ScanerManager.ReadInteger("Model's brand: ");
                    modelMgr.Add(md);
                    goto case Menu.ModelsAll;

                case Menu.ModelEdit:
                    Console.Clear();
                    ShowAllModels(modelMgr);
                    Console.WriteLine("Please,add model's name, which you edit");
                    int value1 = ScanerManager.ReadInteger("Please, enter the model's Id, which you want to replace: ");
                    modelMgr.Edit(value1);
                    goto case Menu.ModelsAll;

                case Menu.ModelRemove:
                    Console.Clear();
                    ShowAllModels(modelMgr);
                    int idm = ScanerManager.ReadInteger("Please, enter the name model's Id, which you want to delete: ");
                    Model ml = modelMgr.GetAll().FirstOrDefault(item => item.IdM == idm);
                    modelMgr.Remove(ml);
                    goto case Menu.ModelsAll;

                case Menu.ModelSingle:
                    int idForSingleModel = ScanerManager.ReadInteger("Please, enter the model's Id, which you want to look in detail:  ");
                    Model mdSingle = modelMgr.GetAll().FirstOrDefault(item => item.IdM == idForSingleModel);

                    Console.WriteLine($"-----------------------------------\n" +
                        $"Model name: {mdSingle.Name}");
                    
                    foreach (var item in carMgr.GetAll())
                    {
                        if (item.ModelId == mdSingle.IdM)
                            Console.WriteLine(item);
                    }
                    goto readMenu;

                case Menu.ModelsAll:
                    Console.Clear();
                    ShowAllModels(modelMgr);
                    goto readMenu;

                case Menu.CarAdd:
                    Console.Clear();
                    Car c = new Car();
                    c.ProductYear = ScanerManager.ReadInteger("Year of production: year");
                    c.Price = ScanerManager.ReadDouble("Price: ₼");
                    c.Color = ScanerManager.ReadString("Color:");
                    c.Engine = ScanerManager.ReadDouble("Engine:");

                    PrintFuel();

                    FuelType f = ScanerManager.ReadFuelMenu("Please, select from menu:");

                    switch (f)
                    {
                        case FuelType.Gasoline:
                            c.FuelType = nameof(FuelType.Gasoline);
                            break;
                        case FuelType.Diesel:
                            c.FuelType = nameof(FuelType.Diesel);
                            break;
                        case FuelType.Hybrid:
                            c.FuelType = nameof(FuelType.Hybrid);
                            break;
                        case FuelType.Electro:
                            c.FuelType = nameof(FuelType.Electro);
                            break;
                        case FuelType.Gas:
                            c.FuelType = nameof(FuelType.Gas);
                            break;
                        default:
                            break;
                    }

                    PrintBody();

                    BodyType bt = ScanerManager.ReadBodyMenu("Please, select from menu: ");

                    switch (bt)
                    {
                        case BodyType.Sedan:
                            c.BodyType = nameof(BodyType.Sedan);
                            break;
                        case BodyType.Hatchback:
                            c.BodyType = nameof(BodyType.Hatchback);
                            break;
                        case BodyType.Coupe:
                            c.BodyType = nameof(BodyType.Coupe);
                            break;
                        case BodyType.SportCar:
                            c.BodyType = nameof(BodyType.SportCar);
                            break;
                        case BodyType.StationWagon:
                            c.BodyType = nameof(BodyType.StationWagon);
                            break;
                        case BodyType.Minivan:
                            c.BodyType = nameof(BodyType.Minivan);
                            break;
                        case BodyType.PickupTrack:
                            c.BodyType = nameof(BodyType.PickupTrack);
                            break;
                        default:
                            break;
                    }


                    Console.WriteLine("------------");
                    ShowAllBrands(brandMgr);
                    Console.WriteLine("------------");

                    c.ModelId = ScanerManager.ReadInteger("Car's model: ");


                    carMgr.Add(c);
                    goto case Menu.CarsAll;

                case Menu.CarEdit:
                    Console.Clear();
                    ShowAllCars(carMgr);
                    Console.WriteLine("Please, push button 1, that change car's body type:\n" +
                        "Please, push button 2, that change car's year:\n" +
                        "Please, push button 3, that change car's price:\n" +
                        "Please, push button 4, that change car's color:\n" +
                        "Please, push button 5, that change car's engine:\n" +
                        "Please, push button 6, that change car's fuel type:\n" +
                        "Please, push button 1, that change car's model:\n");

                    bool succes = (int.TryParse(Console.ReadLine(), out int car));
                    if (succes && car == 1)
                    {
                        int valueCar = ScanerManager.ReadInteger("Enter the ID of selected car: ");
                        Console.Clear();
                        PrintBody();
                        carMgr.EditBodyType(valueCar);
                    }
                    else if (succes && car == 2)
                    {
                        int valueCar = ScanerManager.ReadInteger("Enter the ID of selected car: ");
                        carMgr.EditYearCar(valueCar);
                    }
                    else if (succes && car == 3)
                    {
                        int valueCar = ScanerManager.ReadInteger("Enter the ID of selected car: ");
                        carMgr.EditPriceCar(valueCar);
                    }
                    else if (succes && car == 4)
                    {
                        int valueCar = ScanerManager.ReadInteger("Enter the ID of selected car: ");
                        carMgr.EditColorCar(valueCar);
                    }
                    else if (succes && car == 5)
                    {
                        int valueCar = ScanerManager.ReadInteger("Enter the ID of selected car: ");
                        carMgr.EditEngineCar(valueCar);
                    }
                    else if (succes && car == 6)
                    {
                        int valueCar = ScanerManager.ReadInteger("Enter the ID of selected car: ");
                        Console.Clear();
                        PrintFuel();
                        carMgr.EditFuelType(valueCar);                                               
                    }
                    else if (succes && car == 6)
                    {
                        int valueCar = ScanerManager.ReadInteger("Enter the ID of selected car: ");
                        Console.Clear();
                        ShowAllModels(modelMgr);
                        carMgr.EditCarModel(valueCar);
                    }

                    goto case Menu.CarsAll;

                case Menu.CarRemove:
                    Console.Clear();
                    ShowAllCars(carMgr);
                    int idc = ScanerManager.ReadInteger("Please, enter the car's Id, which you want to delete: ");
                    Car cr = carMgr.GetAll().FirstOrDefault(item => item.IdC == idc);
                    carMgr.Remove(cr);
                    goto case Menu.CarsAll;

                case Menu.CarSingle:
                    int idForSingleCar = ScanerManager.ReadInteger("Please, enter the car's Id, which you want to look in detail:  ");
                    Car crSingle = carMgr.GetAll().FirstOrDefault(item => item.IdC == idForSingleCar);

                    Console.WriteLine($"-----------------------------------\n" +
                        $"Year of production: {crSingle.ProductYear} " +
                        $"|Price: {crSingle.Price} " +
                        $"|Color: {crSingle.Color} " +
                        $"|Engine: {crSingle.Engine} ");

                    goto readMenu;                    

                case Menu.CarsAll:
                    Console.Clear();
                    ShowAllCars(carMgr);
                    goto readMenu;

                case Menu.All:
                    Console.Clear();
                    ShowAllBrands(brandMgr);
                    ShowAllModels(modelMgr);
                    ShowAllCars(carMgr);
                    goto readMenu;

                case Menu.Exit:
                    goto lEnd;
                default:
                    break;
            }
        lEnd:
            Console.WriteLine("\n********************* The End *********************\n");
            Console.WriteLine("Please,press any button to exit");
            Console.ReadKey();
        }
        static void PrintMenu()
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
            foreach (var item in Enum.GetNames(typeof(Menu)))
            {
                Menu m = (Menu)Enum.Parse(typeof(Menu), item);
                Console.WriteLine($"{((byte)m).ToString().PadLeft(2)}.{item}");
            }
            Console.WriteLine($"{new string('-', Console.WindowWidth)}\n");
        }
        static void PrintFuel()
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
            foreach (var item in Enum.GetNames(typeof(FuelType)))
            {
                FuelType m = (FuelType)Enum.Parse(typeof(FuelType), item);
                Console.WriteLine($"{((byte)m).ToString().PadLeft(2)}.{item}");
            }
            Console.WriteLine($"{new string('-', Console.WindowWidth)}\n");
        }
        static void PrintBody()
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
            foreach (var item in Enum.GetNames(typeof(BodyType)))
            {
                BodyType m = (BodyType)Enum.Parse(typeof(BodyType), item);
                Console.WriteLine($"{((byte)m).ToString().PadLeft(2)}.{item}");
            }
            Console.WriteLine($"{new string('-', Console.WindowWidth)}\n");
        }
        static void ShowAllBrands(BrandManager brandMgr)
        {
            Console.WriteLine("********************* Brands *********************\n");
            foreach (var item in brandMgr.GetAll())
            {
                Console.WriteLine(item);
            }
        }

        static void ShowAllModels(ModelManager modelMgr)
        {
            Console.WriteLine("\n********************* Models *********************\n");
            foreach (var item in modelMgr.GetAll())
            {
                Console.WriteLine(item);
            }
        }

        static void ShowAllCars(CarManager carMgr)
        {           
            Console.WriteLine("\n********************* Cars *********************\n");
            
            foreach (var item in carMgr.GetAll())
            {
                Console.WriteLine(item);
            }
            
        }
    }
}
