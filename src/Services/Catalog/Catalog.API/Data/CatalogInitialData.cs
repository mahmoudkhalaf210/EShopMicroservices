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
                  Id = new Guid("01900ee4-0be4-4797-8222-494d7131f325"),
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
                  Id = new Guid("01900ee4-0be6-4797-8332-494d7131f325"),
                  Name = "Google Pixel 6 Pro",
                  Description = "The Google Pixel 6 Pro is a great phone for anyone who wants a powerful camera, a clean software experience, and long battery life. It has a unique design with a camera bar on the back, and a large, smooth display.",
                  ImageFile = "google-pixel-6-pro.jpg",
                  Price = 899.99M,
                  Category = new List<string> { "Smart Phone" }
                },
                new Product()
                {
                  Id = new Guid("01900ee4-0be4-4797-8332-594d7131f325"),
                  Name = "Wireless Noise Cancelling Headphones",
                  Description = "Immerse yourself in your music or shut out the world with these comfortable wireless headphones featuring active noise cancellation technology.",
                  ImageFile = "product-2.jpg",
                  Price = 199.99M,
                  Category = new List<string> { "Electronics", "Audio" }
                },

                new Product()
                {
                  Id = new Guid("01911ee4-0be4-4797-8332-494d7131f325"),
                  Name = "Smart Fitness Watch",
                  Description = "Track your workouts, monitor your sleep, and stay connected with this sleek smartwatch featuring heart rate tracking, GPS, and built-in notifications.",
                  ImageFile = "product-3.jpg",
                  Price = 249.99M,
                  Category = new List<string> { "Electronics", "Fitness" }
                },

                new Product()
                {
                  Id = new Guid("01901ee4-0be4-4797-8332-494d7131f325"),
                  Name = "High-Performance Laptop",
                  Description = "Power through your work or creative projects with this powerful laptop featuring a high-resolution display, long battery life, and a sleek design.",
                  ImageFile = "product-4.jpg",
                  Price = 1499.99M,
                  Category = new List<string> { "Electronics", "Computers" }
                },

                new Product()
                {
                  Id = new Guid("01900ee4-0be4-4797-8332-494d8131f325"),
                  Name = "Mechanical Keyboard",
                  Description = "Experience the satisfying click-clack of a mechanical keyboard, perfect for gamers and writers alike.",
                  ImageFile = "product-5.jpg",
                  Price = 129.99M,
                  Category = new List<string> { "Electronics", "Computer Accessories" }
                },

                new Product()
                {
                  Id = new Guid("01900ee4-0be4-4797-8332-494d7131f325"),
                  Name = "Coffee Maker",
                  Description = "Brew your perfect cup of coffee every time with this user-friendly coffee maker featuring programmable settings and a sleek design.",
                  ImageFile = "product-6.jpg",
                  Price = 79.99M,
                  Category = new List<string> { "Kitchen Appliances", "Coffee & Tea" }
                }
        };



    }
}
