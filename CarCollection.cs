using System;
using System.Collections.Generic;
using System.Text;

namespace GenericTask
{
    interface ICar
    {
        int Year { get; set; }
        int Name { get; set; }
    }
    class CarCollection<T> where T : ICar, new() 
    {
        List<T> cars = new List<T>();

        public void AddCar(T toAdd)
        {
            cars.Add(new T { Year = toAdd.Year,Name = toAdd.Name });
        }
        public int GetLenght { get { return cars.Count; } }
        public T this[int index]
        {
            get
            {
                return cars[index];
            }
        }
    }
}
