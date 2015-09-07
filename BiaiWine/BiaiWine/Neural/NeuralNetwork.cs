using System;

namespace BiaiWine.Neural
{
    class NeuralNetwork
    {
        private Layer inLayer, outLayer;
        private Layer[] hiddenLayer;

        public NeuralNetwork(int inSize, int hiddenSize, int outSize,
               int hiddenCount)
        {
            if((inSize < 1) || (hiddenSize < 1) || (outSize < 1) || (hiddenCount < 1))
            {
                throw (new NetworkException());
            }

            inLayer = new Layer(inSize);
            outLayer = new Layer(outSize);
            hiddenLayer = new Layer[hiddenCount];
            for(int i = 0; i < hiddenCount; i++)
            {
                hiddenLayer[i] = new Layer(hiddenSize);
            }

            outLayer.ConnectWithLayer(hiddenLayer[hiddenCount - 1]);
            for (int i = (hiddenCount - 1); i > 0; i--)
            {
                hiddenLayer[i].ConnectWithLayer(hiddenLayer[i - 1]);
            }
            hiddenLayer[0].ConnectWithLayer(inLayer);
        }

        public void RandowWeight(double min, double max)
        {
            Random rand = new Random();

            outLayer.RandomWeight(min, max, rand);
            for(int i = 0; i < hiddenLayer.Length; i++)
            {
                hiddenLayer[i].RandomWeight(min, max, rand);
            }
        }
        public double[] Calculate(double[] inputs)
        {
            if((inputs == null) || (inputs.Length != inLayer.Neurons.Count))
            {
                throw (new NetworkException());
            }

            inLayer.SetOutputs(inputs);
            for(int i = 0; i < hiddenLayer.Length; i++)
            {
                hiddenLayer[i].Calculate();
            }
            outLayer.Calculate();
            return outLayer.ReturnOutputs();
        }
        public void Learn(double[] correctOuts, double[] inputs, double learnRatio)
        {
            if((correctOuts.Length != outLayer.Neurons.Count) || (inputs.Length != inLayer.Neurons.Count))
            {
                throw (new NetworkException());
            }

            outLayer.ResetErrors();
            for(int i = 0; i < hiddenLayer.Length; i++)
            {
                hiddenLayer[i].ResetErrors();
            }

            Calculate(inputs);

            outLayer.CalculateErrors(correctOuts);
            outLayer.CastErrorBack();
            for(int i = (hiddenLayer.Length -1); i > 0; i--)
            {
                hiddenLayer[i].CastErrorBack();
            }

            outLayer.CorrectWeight(learnRatio);
            for(int i = 0; i < hiddenLayer.Length; i++)
            {
                hiddenLayer[i].CorrectWeight(learnRatio);
            }
        }
    }
}
