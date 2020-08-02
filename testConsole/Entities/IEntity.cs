using System;
using System.Collections.Generic;
using System.Text;

namespace testConsole
{
    interface IEntity
    {
        public double Health { get; set; }
        public decimal Money { get; set; }
        public int Damage { get; set; }
    }
}
