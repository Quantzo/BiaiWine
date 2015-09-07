namespace BiaiWine.Neural
{
    interface IActivationFunction
    {
        double Calculate(double input);
        double CalculatePrime(double output);
    }
}
