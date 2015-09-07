using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiaiWine.Model
{
    public class WineVectors
    {
        public IEnumerable<double> AlcoholVector { get; internal set; }
        public IEnumerable<double> ChloridesVector { get; internal set; }
        public IEnumerable<double> CitricAcidVector { get; internal set; }
        public IEnumerable<double> DensityVector { get; internal set; }
        public IEnumerable<double> FixedAcidityVector { get; internal set; }
        public IEnumerable<double> FreeSulfurDioxideVector { get; internal set; }
        public IEnumerable<double> pHVector { get; internal set; }
        public IEnumerable<double> ResidualSugarVector { get; internal set; }
        public IEnumerable<double> SulphatesVector { get; internal set; }
        public IEnumerable<double> TotalSulfurDioxideVector { get; internal set; }
        public IEnumerable<double> VolatileAcidityVector { get; internal set; }
    }
}
