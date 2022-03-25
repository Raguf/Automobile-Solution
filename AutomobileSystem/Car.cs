using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileSystem
{
    public class Car
    {
        static int counter = 0;

        public Car()
        {
            this.IdC = ++counter;
        }

        public int IdC { get; private set; }
        public string BodyType { get; set; }
        public int ProductYear { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public double Engine { get; set; }
        public string FuelType { get; set; }
        public int ModelId { get; set; }

        public override string ToString()
        {
            return $"Model ID: {ModelId} " +
                $"\nID: {IdC}. " +
                $"\nBody type: {this.BodyType} " +
                $"\nProductYear: {ProductYear} " +
                $"\nPrice: {Price} " +
                $"\nColor: {Color} " +
                $"\nEngine: {Engine} " +
                $"\nFuel type: {this.FuelType} \n" +
                $"\n**********************************";

        }
    }
}
