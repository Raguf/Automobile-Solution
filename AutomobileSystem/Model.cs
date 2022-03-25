using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileSystem
{
    public class Model
    {
        static int counter = 0;

        public Model()
        {
            this.IdM = ++counter;
        }
        public int IdM { get; private set; }
        public string Name { get; set; }
        public int BrandId { get; set; }

        public override string ToString()
        {
            return $"Model ID: {IdM}. Model name:{Name} Brand ID:{BrandId}";
        }
    }
}
