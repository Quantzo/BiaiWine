using BiaiWine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiaiWine
{
    class Program
    {
        static void Main(string[] args)
        {
            var ww = new WineDataSet();
            ww.LoadData();

        }
    }
}
