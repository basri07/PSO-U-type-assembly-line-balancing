using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO_UTYPE
{
    public class Gorevler : ICloneable
    {
        int _ID;
        int _GorevSuresi;
        
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public Gorevler()
        {

        }
        public Gorevler(int ID, int GorevSuresi)
        {
            this.ID = ID;
            this.GorevSuresi = GorevSuresi;
        }

        public int ID { get; set; }
        public int GorevSuresi { get; set; }
    }
}
