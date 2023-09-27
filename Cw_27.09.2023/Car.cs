using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw_27._09._2023
{
    [Serializable]
    public class Car
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string VIN { get; set; }
        public string Model { get; set; }
    }
}
