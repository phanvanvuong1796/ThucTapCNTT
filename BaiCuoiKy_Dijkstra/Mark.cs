using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiCuoiKy_Dijkstra
{
    class Mark
    {
        private int length;
        private int toPoint;
        private bool checkMark;

        public int Length
        {
            get { return length; }
            set { length = value; }
        }

        public int ToPoint
        {
            get { return toPoint; }
            set { toPoint = value; }
        }

        public bool CheckMark
        {
            get { return checkMark; }
            set { checkMark = value; }
        }

        public Mark()
        {
            length = -1;
            checkMark = false;
        }
    }
}
