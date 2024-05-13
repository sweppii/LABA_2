using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA_2
{
    internal class Carriage
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }
        public Carriage(string type, string id)
        {
            Id = id;
            Type = type;
            Weight = 20;
            Length = 30;
        }

    }
}
