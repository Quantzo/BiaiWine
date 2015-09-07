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

        public double[] ToInputVector()
        {
            var inputVector =  new double[11];
            inputVector[0] = FixedAcidity;
            inputVector[1] = VolatileAcidity;
            inputVector[2] = CitricAcid;
            inputVector[3] = ResidualSugar;
            inputVector[4] = Chlorides;
            inputVector[5] = FreeSulfurDioxide;
            inputVector[6] = TotalSulfurDioxide;
            inputVector[7] = Density;
            inputVector[8] = pH;
            inputVector[9] = Sulphates;
            inputVector[10] = Alcohol;

            return inputVector;
        }

        public double[] ToOutputVector()
        {
            var inputVector = new double[7];
            if (Quality == 3)
            {
                inputVector[0] = 1;
            }
            else if (Quality == 4)
            {
                inputVector[1] = 1;
            }
            else if (Quality == 5)
            {
                inputVector[2] = 1;
            }
            else if (Quality == 6)
            {
                inputVector[3] = 1;
            }
            else if (Quality == 7)
            {
                inputVector[4] = 1;
            }
            else if (Quality == 8)
            {
                inputVector[5] = 1;
            }
            else if (Quality == 9)
            {
                inputVector[6] = 1;
            }

            return inputVector;
        }

        public static int ToQualityFromVector(double[] vector)
        {

            var index = vector.ToList().IndexOf(vector.Max());

            if (index == 0)
            {
                return  3;
            }
            else if (index == 1)
            {
                return 4;
            }
            else if (index == 2)
            {
                return 5;
            }
            else if (index == 3)
            {
                return 6;
            }
            else if (index == 4)
            {
                return 7;
            }
            else if (index == 5)
            {
                return 8;
            }
            else if (index == 6)
            {
                return  9;

            }
            return 0;
        }

    }

    
}
