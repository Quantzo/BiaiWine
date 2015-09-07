namespace BiaiWine.Neural
{
    class Connection
    {
        private Neuron _neuron;
        private double _weight;

        public Connection(Neuron neuron, double weight)
        {
            if(neuron == null)
            {
                throw (new NetworkException());
            }
            this._neuron = neuron;
            this._weight = weight;
        }

        #region Get&Set
        public Neuron Neuron
        {
            get
            {
                return _neuron;
            }
            set
            {
                _neuron = value;
            }
        }

        public double Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
            }
        }
        #endregion
    }
}
