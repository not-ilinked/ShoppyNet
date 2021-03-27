namespace Shoppy
{
    public class OptionalParameter<T>
    {
        public bool Set { get; private set; }

        private T _val;
        public T Value
        {
            get
            {
                return _val;
            }
            set
            {
                _val = value;
                Set = true;
            }
        }
    }
}
