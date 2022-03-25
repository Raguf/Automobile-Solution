using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileSystem
{
    public class Brand
    {
        static int counter = 0;

        public Brand()
        {
            this.IdB = ++counter;
        }

        public int IdB { get; private set; }
        public string  Name { get; set; }

        public override string ToString()
        {
            return $"Brand ID: {IdB}. Brand name: {Name}";
        }
    }
}
