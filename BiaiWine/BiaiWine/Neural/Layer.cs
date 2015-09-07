using System;
using System.Collections;

namespace BiaiWine.Neural
{
    class Layer
    {
        private ArrayList _neurons = new ArrayList();

        public Layer(int neuronCount)
        {
            if(neuronCount < 1)
            {
                throw (new NetworkException());
            }
            for(int i = 0; i < neuronCount; i++)
            {
                AddNeuron(new Neuron());
            }
        }
        #region Get&Set
        public ArrayList Neurons
        {
            get 
            { 
                return _neurons;
            }
        }
        #endregion

        private void AddNeuron(Neuron neuron)
        {
            if(neuron == null)
            {
                throw (new NetworkException());
            }
            _neurons.Add(neuron);
        }

        public void ConnectWithLayer(Layer layer)
        {
            if (layer == null)
            {
                throw (new NetworkException());
            }
            foreach(Neuron neuron in _neurons)
            {
                neuron.AddInputs(layer);
            }
        }
        public void RandomWeight(double min, double max, Random random)
        {
            if (random == null)
            {
                throw (new NetworkException());
            }
            foreach(Neuron neuron in _neurons)
            {
                neuron.RandomWeight(min, max, random);
            }
        }
        public void SetOutputs(double[] outputs)
        {
            if((outputs == null) || (outputs.Length != _neurons.Count))
            {
                throw (new NetworkException());
            }
            for(int i = 0; i < _neurons.Count; i++)
            {
                ((Neuron)_neurons[i]).Output = outputs[i];
            }
        }
        public double[] ReturnOutputs()
        {
            double[] outputs = new double[_neurons.Count];
            for(int i = 0; i < _neurons.Count; i++)
            {
                outputs[i] = ((Neuron)_neurons[i]).Output;
            }
            return outputs;
        }
        public void Calculate()
        {
            foreach(Neuron neuron in _neurons)
            {
                neuron.Calculate();
                neuron.Error = 0.0;
            }
        }
        public void ResetErrors()
        {
            foreach(Neuron neuron in _neurons)
            {
                neuron.Error = 0.0;
            }
        }
        public void CalculateErrors(double[] correctOutputs)
        {
            if(correctOutputs.Length != _neurons.Count)
            {
                throw (new NetworkException());
            }
            for(int i = 0; i < _neurons.Count; i++)
            {
                ((Neuron)_neurons[i]).CalculateError(correctOutputs[i]);
            }
        }
        public void CorrectWeight(double learnRatio)
        {
            if (learnRatio < 0)
            {
                throw (new NetworkException());
            }
            foreach (Neuron neuron in _neurons)
            {
                neuron.CorrectWeight(learnRatio);
            }
        }
        public void CastErrorBack()
        {
            foreach(Neuron neuron in _neurons)
            {
                neuron.CastErrorBack();
            }
        }
    }
}
