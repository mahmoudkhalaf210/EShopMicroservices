using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            // if has any product ==> has any data no need to create data
            if (await session.Query<Product>().AnyAsync())
                return;

            // Marten UPSERT Feature 
            session.Store<Product>(GetPreconfiguredProducts());
            await session.SaveChangesAsync();
        }


        private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>() 
        {
              new Product()
                {
                  Id = new Guid("01902227-efac-47eb-91f7-60cc81be0a35"),
                  Name = "iPhone X",
                  Description = "The iPhone X has a beautiful all-screen design with a Super Retina OLED display. It features a TrueDepth camera system for facial recognition, Animoji, and improved selfies. The rear dual-camera system takes incredible photos and videos.",
                  ImageFile = "iphone-x.jpg",
                  Price = 950.00M,
                  Category = new List<string> { "Smart Phone" }
                },

                new Product()
                {
                  Id = new Guid("0190222b-1568-47d6-a217-e83c3367cfcf"),
                  Name = "Samsung Galaxy S22 Ultra",
                  Description = "The Samsung Galaxy S22 Ultra is a powerful phone with a large, bright display and a long-lasting battery. It has a quad-camera system on the back that takes stunning photos and videos, and a powerful processor that can handle even the most demanding tasks.",
                  ImageFile = "samsung-galaxy-s22-ultra.jpg",
                  Price = 1199.99M,
                  Category = new List<string> { "Smart Phone" }
                },

                new Product()
                {
                  Id = new Guid("C1234567-89AB-CDEF-GHIJ-KLmnopqrstuvwx"),
                  Name = "Google Pixel 6 Pro",
                  Description = "The Google Pixel 6 Pro is a great phone for anyone who wants a powerful camera, a clean software experience, and long battery life. It has a unique design with a camera bar on the back, and a large, smooth display.",
                  ImageFile = "google-pixel-6-pro.jpg",
                  Price = 899.99M,
                  Category = new List<string> { "Smart Phone" }
                },
                new Product()
                {
                  Id = new Guid("01902227-efac-47eb-91f7-60cc81be0a35"),
                  Name = "Wireless Noise Cancelling Headphones",
                  Description = "Immerse yourself in your music or shut out the world with these comfortable wireless headphones featuring active noise cancellation technology.",
                  ImageFile = "product-2.jpg",
                  Price = 199.99M,
                  Category = new List<string> { "Electronics", "Audio" }
                },

                new Product()
                {
                  Id = new Guid("7F4A2C8A-8A8B-44A9-89F7-C2C2702D89D9"),
                  Name = "Smart Fitness Watch",
                  Description = "Track your workouts, monitor your sleep, and stay connected with this sleek smartwatch featuring heart rate tracking, GPS, and built-in notifications.",
                  ImageFile = "product-3.jpg",
                  Price = 249.99M,
                  Category = new List<string> { "Electronics", "Fitness" }
                },

                new Product()
                {
                  Id = new Guid("1F8A7C2A-2C81-47D9-A3F2-2C78C2277899"),
                  Name = "High-Performance Laptop",
                  Description = "Power through your work or creative projects with this powerful laptop featuring a high-resolution display, long battery life, and a sleek design.",
                  ImageFile = "product-4.jpg",
                  Price = 1499.99M,
                  Category = new List<string> { "Electronics", "Computers" }
                },

                new Product()
                {
                  Id = new Guid("9B17234D-A2C8-4321-A87B-C237456291BA"),
                  Name = "Mechanical Keyboard",
                  Description = "Experience the satisfying click-clack of a mechanical keyboard, perfect for gamers and writers alike.",
                  ImageFile = "product-5.jpg",
                  Price = 129.99M,
                  Category = new List<string> { "Electronics", "Computer Accessories" }
                },

                new Product()
                {
                  Id = new Guid("F7349C2B-12C3-412D-A456-789012B34CDE"),
                  Name = "Coffee Maker",
                  Description = "Brew your perfect cup of coffee every time with this user-friendly coffee maker featuring programmable settings and a sleek design.",
                  ImageFile = "product-6.jpg",
                  Price = 79.99M,
                  Category = new List<string> { "Kitchen Appliances", "Coffee & Tea" }
                }
        };



    }
}
