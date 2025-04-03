using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace files
{
    class Epitoanyagok
    {
        public double weight { get; set; }
        public string name { get; set; }
        public int price { get; set; }
    }

    class Tegla : Epitoanyagok
    {
        public string type { get; set; }
        public string color { get; set; }
    }

    class Fa : Epitoanyagok
    {
        public string faanyag { get; set; }
        public float hardness { get; set; }
    }

    class Vas : Epitoanyagok
    {
        public string femtipus { get; set; }
        public float density { get; set; }
    }
}
