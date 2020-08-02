using System;
using System.Collections.Generic;
using System.Text;

namespace testConsole
{
    class Proizv : Base
    {
        public int ProizvNumber { get; set; }
        public Proizv(string name, int age, int proizvNumber) : base(name,age)
        {
            ProizvNumber = proizvNumber;
        }
        public Proizv(string name, int proizvNumber) : base(name)
        {
            ProizvNumber = proizvNumber;
        }
    }
}
