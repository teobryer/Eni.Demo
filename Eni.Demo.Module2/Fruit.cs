using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2
{
    class Fruit : Aliment
    {

        public DateTime DateCueillette { get; set; }

        public bool EstPerime()
        {
            return (DateTime.Now - this.DateCueillette).Days > 10;
        }

        public override void Conserver()
        {
            this.RangerDansLeFrigo();
        }

        private void RangerDansLeFrigo()
        {

        }
    }
}
