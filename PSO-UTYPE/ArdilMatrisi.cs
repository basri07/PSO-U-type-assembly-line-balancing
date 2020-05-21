using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO_UTYPE
{
  public  class ArdilMatrisi:ICloneable
    {
        int _ID;
        int _GorevID;
        int _BirOncekiGorevID;
        Boolean _BaslangıcBitis;
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public ArdilMatrisi()
        {

        }
        public ArdilMatrisi(int SIRA, int GorevID, int BirSonrakiGorevID, Boolean BaslangicBitis)
        {
            this.SIRA = SIRA;
            this.GorevID = GorevID;
            this.BirSonrakiGorevID = BirSonrakiGorevID;
            this.BaslangicBitis = BaslangicBitis;

        }
        public int SIRA { get; set; }
        public int GorevID { get; set; }
        public int BirSonrakiGorevID { get; set; }
        public Boolean BaslangicBitis { get; set; }
    }
}
