using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileSystem.Managers
{
    public class ModelManager
    {
        Model[] data = new Model[0];

        public void Add(Model entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
        }
        public void Edit(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].IdM == value)
                {
                    Console.WriteLine("Please,change the model's brand");
                    string newModel = ScanerManager.ReadString("Please add the new model's name: ");
                    data[i].Name = data[i].Name.Replace(data[i].Name, newModel);
                    break;
                }
            }
        }
        public void Remove(Model entity)
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
        public void SingleModel(int value)
        {
            string singleModel = "";
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].IdM == value)
                {
                    singleModel = $"Model ID: {data[i].IdM} | Model name: {data[i].Name} | Brand ID: {data[i].BrandId} ";
                    break;
                }
            }
            Console.WriteLine("******************** Selected model ********************");
            Console.WriteLine(singleModel);
        }
        public Model[] GetAll()
        {
            return data;
        }
    }
}
