using System;
using System.Collections.Generic;
using System.Text;

namespace testConsole
{
    class Proizv<T> : Base<T>
    {
        public T ProizvNumber { get; set; }
        public Proizv(string name, T age,T proizvNumber) : base(name,age)
        {
            ProizvNumber = proizvNumber;
        }
        public Proizv(string name,T proizvNumber) : base(name)
        {
            ProizvNumber = proizvNumber;
        }
    }
}
