using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileSystem.Managers
{
    public class BrandManager
    {
        Brand[] data = new Brand[0];

        public void Add(Brand entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
        }
        public void Edit(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].IdB == value)
                {
                    Console.WriteLine("Please,change the brand's name");
                    string newBrand = ScanerManager.ReadString("Please add the new brand's name: ");
                    data[i].Name = data[i].Name.Replace(data[i].Name, newBrand);
                    break;
                }
            }
        }
        public void Remove(Brand entity)
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
        public void SingleBrand(int value)
        {
            
            string singleBrand = "";
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].IdB == value)
                {
                    singleBrand = $"Brand ID: {data[i].IdB} | Brand name: {data[i].Name} ";
                    
                    break;
                }
            }
            Console.WriteLine("******************** Selected brand ********************");
            Console.WriteLine(singleBrand);
            
        }
        public Brand[] GetAll()
        {
            return data;
        }
    }
}
