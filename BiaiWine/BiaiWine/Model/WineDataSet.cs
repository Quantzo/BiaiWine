using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiaiWine.Model
{
    public class WineDataSet
    {
        public List<Wine> DataSet { get; set; }
     



        public void LoadData()
        {
            CsvConfiguration config = new CsvConfiguration();
            config.Delimiter = ";";
            config.CultureInfo = CultureInfo.InvariantCulture;



            var csv = new CsvReader(new StreamReader("winequality-white.csv"),config);
            DataSet = csv.GetRecords<Wine>().ToList();
            DataSet.Select(r => r.Quality).Distinct();

            

        }


        public void NormalizeData(bool ZScore)
        {
            var vectors = new WineVectors
            {
                FixedAcidityVector = DataSet.Select(r => r.FixedAcidity),
                VolatileAcidityVector = DataSet.Select(r => r.VolatileAcidity),
                CitricAcidVector = DataSet.Select(r => r.CitricAcid),
                ResidualSugarVector = DataSet.Select(r => r.ResidualSugar),
                ChloridesVector = DataSet.Select(r => r.Chlorides),
                FreeSulfurDioxideVector = DataSet.Select(r => r.FreeSulfurDioxide),
                TotalSulfurDioxideVector = DataSet.Select(r => r.TotalSulfurDioxide),
                DensityVector = DataSet.Select(r => r.Density),
                pHVector = DataSet.Select(r => r.pH),
                SulphatesVector = DataSet.Select(r => r.Sulphates),
                AlcoholVector = DataSet.Select(r => r.Alcohol),
            };
            if (ZScore)
            {
                DataSet.ForEach(i => i.NormalizeZScore(vectors));
            }
            else
            {
                DataSet.ForEach(i => i.NormalizeMinMax(vectors));
            }


            

        }



    }

  
}
