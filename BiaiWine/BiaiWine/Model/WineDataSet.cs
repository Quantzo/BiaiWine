using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Math;
using Accord.Neuro;
using Accord.Neuro.Learning;
using Accord.Neuro.Networks;
using AForge.Neuro.Learning;
using BiaiWine.Neural;

namespace BiaiWine.Model
{
    public class WineDataSet
    {
        public List<Wine> DataSet { get; set; }
     



        public void LoadData()
        {
            var config = new CsvConfiguration
            {
                Delimiter = ";",
                CultureInfo = CultureInfo.InvariantCulture
            };



            var csv = new CsvReader(new StreamReader("winequality-white.csv"),config);
            DataSet = csv.GetRecords<Wine>().ToList();
            
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


        public void DeepBeliefNetwork()
        {
            double[][] inputs, outputs, testInputs, testOutputs;
            DataToArrays(out inputs, out outputs, out testInputs, out testOutputs);

            var network = new DeepBeliefNetwork(inputs.First().Length, 15, 7);
            new GaussianWeights(network, 0.1).Randomize();
            network.UpdateVisibleWeights();

            var teacher = new DeepBeliefNetworkLearning(network)
            {
                Algorithm = (h, v, i) => new ContrastiveDivergenceLearning(h, v)
                {
                    LearningRate = 0.1,
                    Momentum = 0.5,
                    Decay = 0.001,
                }
            };



            int batchCount = Math.Max(1, 11 / 100);

            int[] groups = Accord.Statistics.Tools.RandomGroups(inputs.Length, batchCount);
            double[][][] batches = inputs.Subgroups(groups);


            for (int layerIndex = 0; layerIndex < network.Machines.Count - 1; layerIndex++)
            {
                teacher.LayerIndex = layerIndex;
                var layerData = teacher.GetLayerInput(batches);
                for (int i = 0; i < 5000; i++)
                {
                    double error = teacher.RunEpoch(layerData);
                }
            }

            var teacher2 = new BackPropagationLearning(network)
            {
                LearningRate = 0.1,
                Momentum = 0.5
            };


            for (int i = 0; i < 5000; i++)
            {
                double error = teacher2.RunEpoch(inputs, outputs);

            }


            int correct = 0;
            for (int i = 0; i < testInputs.Length; i++)
            {
                double[] outputValues = network.Compute(testInputs[i]);
                if (Wine.ToQualityFromVector(outputValues) == Wine.ToQualityFromVector(testOutputs[i]))
                {
                    correct++;
                }
            }

            Console.WriteLine("Correct " + correct + "/" + testInputs.Length + ", " + Math.Round(((double)correct / (double)testInputs.Length * 100), 2) + "%");
        }

        private void DataToArrays(out double[][] inputs, out double[][] outputs, out double[][] testInputs, out double[][] testOutputs)
        {
            var testData = DataSet.Take(500).ToList();
            var data = DataSet.Skip(500).ToList();

            inputs = new double[data.Count][];
            outputs = new double[data.Count][];
            for (int i = 0; i < data.Count; i++)
            {
                inputs[i] = data[i].ToInputVector();
                outputs[i] = data[i].ToOutputVector();
            }

            testInputs = new double[testData.Count][];
            testOutputs = new double[testData.Count][];
            for (int i = 0; i < testData.Count; i++)
            {
                testInputs[i] = testData[i].ToInputVector();
                testOutputs[i] = testData[i].ToOutputVector();
            }
        }

        public void NeuralNetwork()
        {
            double[][] inputs, outputs, testInputs, testOutputs;
            DataToArrays(out inputs, out outputs, out testInputs, out testOutputs);


            var network = new NeuralNetwork(11,15,7,2);
            network.RandowWeight(-1.0, 1.0);

            for (int i = 0; i < DataSet.Skip(500).ToList().Count; i++)
            {
                network.Learn(outputs[i], inputs[i], 0.1);
            }


            int correct = 0;
            for (int i = 0; i < testInputs.Length; i++)
            {
                double[] outputValues = network.Calculate(testInputs[i]);
                if (Wine.ToQualityFromVector(outputValues) == Wine.ToQualityFromVector(testOutputs[i]))
                {
                    correct++;
                }
            }

            Console.WriteLine("Correct " + correct + "/" + testInputs.Length + ", " + Math.Round(((double)correct / (double)testInputs.Length * 100), 2) + "%");

        }



    }

  
}
