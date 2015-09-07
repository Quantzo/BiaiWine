using System;
using System.Collections;

namespace BiaiWine.Neural
{
    class Neuron
    {
        private IActivationFunction _function;
        private double _output;
        private ArrayList _input;
        private double _biasWeight;
        private double _error;

        public Neuron()
        {
            _error = 0.0;
            _output = 0.0;
            _input = new ArrayList();
            _function = new SigmoidActivationFunction();
            _biasWeight = 0.0;
        }
        #region Get&Set
        public double Output
        {
            get
            {
                return _output;
            }
            set
            {
                _output = value;
            }
        }
        public double Error
        {
            get
            {
                return _error;
            }
            set
            {
                _error = value;
            }
        }
        #endregion

        public void AddInputs(Neuron neuron)
        {
            if(neuron == null)
            {
                throw (new NetworkException());
            }
            _input.Add(new Connection(neuron, 1.0));
        }
        public void AddInputs(Neuron neuron, double weight)
        {
            if (neuron == null)
            {
                throw (new NetworkException());
            }
            _input.Add(new Connection(neuron, weight));
        }
        public void AddInputs(Layer layer)
        {
            if (layer == null)
            {
                throw (new NetworkException());
            }
            foreach(Neuron neuron in layer.Neurons)
            {
                AddInputs(neuron);
            }
        }
        public void RandomWeight(double min, double max, Random random)
        {
            if((random == null) || (max <= min))
            {
                throw (new NetworkException());
            }
            foreach(Connection con in _input)
            {
                con.Weight = (random.NextDouble() * (max - min)) + min;
            }
            _biasWeight = (random.NextDouble() * (max - min)) + min;
        }
        public void Calculate()
        {
            _output = 0.0;
            foreach(Connection con in _input)
            {
                _output += con.Weight * con.Neuron.Output;
            }
            _output += _biasWeight * 1.0;
            _output = _function.Calculate(_output);
        }
        public void CalculateError(double correctOut)
        {
            _error = correctOut - _output;
        }
        public void CorrectWeight(double learnRatio)
        {
            if(learnRatio < 0)
            {
                throw (new NetworkException());
            }
            foreach(Connection con in _input)
            {
                con.Weight += learnRatio * _error * _function.CalculatePrime(_output) * con.Neuron.Output;
            }
            _biasWeight += learnRatio * _error * _function.CalculatePrime(_output) * 1.0;
        }
        public void CastErrorBack()
        {
            foreach(Connection con in _input)
            {
                con.Neuron.Error += _error * con.Weight;
            }
        }
    }
}
