using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    public class Garage<T> : IEnumerable<T> where T: IVehicle
    {
        private T[] vehicles;

        public int Capacity { get;  private set; }

        public Garage()
        {

        }

        public Garage(int capacity)
        {
            Capacity = capacity;
            vehicles = new T[capacity];
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var vehicle in vehicles)
            {
                //Add nullcheck
                yield return vehicle;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal bool Park(T newVehicle)
        {
            for (int i = 0; i < Capacity; i++)
            {
                if (vehicles[i] == null)
                {
                    vehicles[i] = newVehicle;
                    return true;
                }
            }
            return false;
        }

        internal bool Unpark(string regNo)
        {
            for (int i = 0; i < Capacity; i++)
            {
                if (vehicles[i] != null)
                {
                    var temp = (IVehicle)vehicles[i];

                    if (temp.RegNo == regNo)
                    {
                        vehicles[i] = default(T);
                        return true;
                    }
                }
            }
            return false;
        }

        internal void Print()
        {
            for (int i = 0; i < Capacity; i++)
            {
                var temp = (IVehicle)vehicles[i];

                if (vehicles[i] != null)
                {
                    Console.WriteLine(temp.Props());
                }
            }
        }

        internal void SearchRegNo(string searchRegNo)
        {
            for (int i = 0; i < Capacity; i++)
            {
                var temp = (IVehicle)vehicles[i];

                if (searchRegNo == vehicles[i].RegNo)
                {
                    Console.WriteLine(temp.Props());
                    break;
                }
            }
        }
    }
}
