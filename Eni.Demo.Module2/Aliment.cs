using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2
{
    public abstract class Aliment : INourriture
    {
        public DateTime DatePeremption { get; set; }

        public bool EstPerime()
        {
            return DateTime.Now > this.DatePeremption;
        }

        public abstract void Conserver();
    }
}
