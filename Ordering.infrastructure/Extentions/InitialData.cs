

namespace Ordering.infrastructure.Extentions
{
    public class InitialData
    {
        public static IEnumerable<Customer> Customers => new List<Customer>
        { 
            Customer.Create(CustomerId.Of(new Guid("01900ee4-0be4-5897-8222-494d7131f325")) , "Mahmoud" , "Mahmoud@gmail.com"),
            Customer.Create(CustomerId.Of(new Guid("01900ee4-0be4-4797-8222-494d7131f333")) , "Khalifa" , "Khalifa@gmail.com")
        };


        public static IEnumerable<Product> Products => new List<Product>
        {
            Product.Create(ProductId.Of(new Guid("01900ee4-0be4-4797-8222-494d7131f325")) , "iPhone X" ,950),
        };


        public static IEnumerable<Order> OrdersWithItems {
            get {
                var address1 = Address.Of("Mahmoud", "Khalifa", "Mahmoud@gamil.com", "Nasr City", "Cairo", "sssssss", "12234");
                var payment1 = Payment.Of("Mahmoud", "1111222233334444", "10/26", "123", 1);

                var order1 = Order.Create(
                    OrderId.Of(new Guid("01900ee4-0be4-4797-8444-494d7123f325"))
                    ,CustomerId.Of(new Guid("01900ee4-0be4-5897-8222-494d7131f325")),
                    OrderName.Of("orde1"), address1, address1, payment1
                    );

                order1.Add(ProductId.Of(new Guid("01900ee4-0be4-4797-8222-494d7131f325")), 1, 950);

                return new List<Order> { order1 };
            }
        }


    }
}
