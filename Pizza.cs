namespace UML2
{
    public class Pizza
    {
        int _number;
        string _name;
        double _price;


        public Pizza()
        {
            _number = 0;
        }


        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }


        public override string ToString()
        {
            return $"Number of pizza : {Number}, Name of pizza : {Name}, Price of pizza : {Price}";
        }

    }

}