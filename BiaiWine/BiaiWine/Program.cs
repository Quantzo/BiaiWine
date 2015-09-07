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
            var wineDataSet = new WineDataSet();
            wineDataSet.LoadData();
            

            Console.WriteLine("Neural Network with sigmoid activation function without normalization");
            wineDataSet.NeuralNetwork();
            Console.WriteLine("Deep Belief Network without normalization");
            wineDataSet.DeepBeliefNetwork();

            Console.WriteLine("Neural Network with sigmoid activation function with min max normalization");
            wineDataSet.LoadData();
            wineDataSet.NormalizeData(false);
            wineDataSet.NeuralNetwork();
            Console.WriteLine("Deep Belief Network with min max normalization");
            wineDataSet.DeepBeliefNetwork();



            Console.WriteLine("Neural Network with sigmoid activation function with Z-Score normalization");
            wineDataSet.LoadData();
            wineDataSet.NormalizeData(true);
            wineDataSet.NeuralNetwork();
            Console.WriteLine("Deep Belief Network with Z-Score normalization");
            wineDataSet.DeepBeliefNetwork();


        }
    }
}
