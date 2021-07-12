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
        private int capacity;

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

        internal void Park(T newVehicle)
        {
            for (int i = 0; i < Capacity; i++)
            {
                if (vehicles[i] != null)
                {
                    vehicles[i] = newVehicle;
                    break;
                }
            }
        }

        internal void RemoveVehicle(string regNo)
        {
            for (int i = 0; i < Capacity; i++)
            {
                if (vehicles[i] != null)
                {
                    var temp = (IVehicle)vehicles[i];

                    if (temp.RegNo == regNo)
                    {
                        vehicles[i] = default(T);
                        break;
                    }
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < Capacity; i++)
            {
                if (vehicles[i] != null)
                {
                    Console.WriteLine(vehicles.Props());
                    break;
                }
            }
        }

        public static void SearchRegNo()
        {
            
        }
    }
}
