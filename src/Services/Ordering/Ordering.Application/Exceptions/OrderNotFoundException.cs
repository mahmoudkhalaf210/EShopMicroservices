namespace Ordering.Application.Exceptions
{
    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException(string message) : base(message)
        {

        }

        public OrderNotFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) was not Found")
        {
            
        }

    }
}
