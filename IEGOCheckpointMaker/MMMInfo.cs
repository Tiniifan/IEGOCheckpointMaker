using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEGOCheckpointMaker
{
    public class MMMConfig
    {
        public int Id { get; set; }
        public string Condition { get; set; }
        public int StartIndex { get; set; }

        public int Count { get; set; }
    }

    public class MMMAppear
    {
        public int Index { get; set; }
        public int Type { get; set; }
        public int PosX { get; set; }

        public int PosY { get; set; }

        public int Rot { get; set; }
    }
}
