using System;
using System.Collections.Generic;
using System.Text;

namespace testConsole
{
    [Playable]
    class Player : IEntity
    {
        public double Health { get; set; }
        public decimal Money { get; set; }
        public int Damage { get; set; }

        public override string ToString()
        {
            return $"Player[Health:{Health}]";
        }
    }
}
