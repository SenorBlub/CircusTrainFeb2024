using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrainFeb2024
{
    public class Carnivore : IAnimal
    {
        public Diet diet { get; }

        public int size { get; }

        public Carnivore(int _size)
        {
            diet = Diet.Carnivore;
            size = _size;
        }
    }
}
