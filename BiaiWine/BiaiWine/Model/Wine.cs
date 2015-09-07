using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiaiWine.Model
{
    public class Wine
    {
        public double FixedAcidity { get; set; }
        public double VolatileAcidity { get; set; }
        public double CitricAcid { get; set; }
        public double ResidualSugar { get; set; }
        public double Chlorides { get; set; }
        public double FreeSulfurDioxide { get; set; }
        public double TotalSulfurDioxide { get; set; }
        public double Density { get; set; }
        public double pH { get; set; }
        public double Sulphates { get; set; }
        public double Alcohol { get; set; }
        public int Quality { get; set; }

        internal void NormalizeZScore(WineVectors vectors)
        {
            FixedAcidity = FixedAcidity.NormalizeZScore(vectors.FixedAcidityVector.Average(), vectors.FixedAcidityVector.StdDev());
            VolatileAcidity = VolatileAcidity.NormalizeZScore(vectors.VolatileAcidityVector.Average(), vectors.VolatileAcidityVector.StdDev());
            CitricAcid = CitricAcid.NormalizeZScore(vectors.CitricAcidVector.Average(), vectors.CitricAcidVector.StdDev());
            ResidualSugar = ResidualSugar.NormalizeZScore(vectors.ResidualSugarVector.Average(), vectors.ResidualSugarVector.StdDev());
            Chlorides = Chlorides.NormalizeZScore(vectors.ChloridesVector.Average(), vectors.ChloridesVector.StdDev());
            FreeSulfurDioxide = FreeSulfurDioxide.NormalizeZScore(vectors.FreeSulfurDioxideVector.Average(), vectors.FreeSulfurDioxideVector.StdDev());
            TotalSulfurDioxide = TotalSulfurDioxide.NormalizeZScore(vectors.TotalSulfurDioxideVector.Average(), vectors.TotalSulfurDioxideVector.StdDev());
            Density = Density.NormalizeZScore(vectors.DensityVector.Average(), vectors.DensityVector.StdDev());
            pH = pH.NormalizeZScore(vectors.pHVector.Average(), vectors.pHVector.StdDev());
            Sulphates = Sulphates.NormalizeZScore(vectors.SulphatesVector.Average(), vectors.SulphatesVector.StdDev());
            Alcohol = Alcohol.NormalizeZScore(vectors.AlcoholVector.Average(), vectors.AlcoholVector.StdDev());

        }

        internal void NormalizeMinMax(WineVectors vectors)
        {
            FixedAcidity = FixedAcidity.NormalizeMinMax(vectors.FixedAcidityVector.Max(), vectors.FixedAcidityVector.Min());
            VolatileAcidity = VolatileAcidity.NormalizeMinMax(vectors.VolatileAcidityVector.Max(), vectors.VolatileAcidityVector.Min());
            CitricAcid = CitricAcid.NormalizeMinMax(vectors.CitricAcidVector.Max(), vectors.CitricAcidVector.Min());
            ResidualSugar = ResidualSugar.NormalizeMinMax(vectors.ResidualSugarVector.Max(), vectors.ResidualSugarVector.Min());
            Chlorides = Chlorides.NormalizeMinMax(vectors.ChloridesVector.Max(), vectors.ChloridesVector.Min());
            FreeSulfurDioxide = FreeSulfurDioxide.NormalizeMinMax(vectors.FreeSulfurDioxideVector.Max(), vectors.FreeSulfurDioxideVector.Min());
            TotalSulfurDioxide = TotalSulfurDioxide.NormalizeMinMax(vectors.TotalSulfurDioxideVector.Max(), vectors.TotalSulfurDioxideVector.Min());
            Density = Density.NormalizeMinMax(vectors.DensityVector.Max(), vectors.DensityVector.Min());
            pH = pH.NormalizeMinMax(vectors.pHVector.Max(), vectors.pHVector.Min());
            Sulphates = Sulphates.NormalizeMinMax(vectors.SulphatesVector.Max(), vectors.SulphatesVector.Min());
            Alcohol = Alcohol.NormalizeMinMax(vectors.AlcoholVector.Max(), vectors.AlcoholVector.Min());
        }
    }

    
}
