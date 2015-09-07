using System;

namespace BiaiWine.Neural
{
    public class SigmoidActivationFunction : IActivationFunction
    {
        private double _beta;

        public SigmoidActivationFunction()
        {
            this._beta = 1.0;
        }
        public SigmoidActivationFunction(double beta)
        {
            this._beta = beta;
        }

        public double Calculate(double input)
        {
            return (1.0 / (1.0 + Math.Pow(Math.E, -(_beta * input))));
        }
        public double CalculatePrime(double output)
        {
            return output * (1.0 - output);
        }
    }
}
