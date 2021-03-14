using System.Collections.Generic;
using System.Linq;

namespace UniSales.API.Models
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Products.Any())
            {
                context.AddRange
                (
                    new Product { Name = "Proizvod 1", Price = 12.95M, ShortDescription = "Kratak opis proizvoda", LongDescription = "Detaljan opis proizvoda", Category = Categories["Kategorija 1"], ImageUrl = "https://www.pizzacorner.rs/imgs_android/1.jpg", InStock = true, IsProductOfTheWeek = true, ImageThumbnailUrl = "https://www.pizzacorner.rs/imgs_android/1.jpg" },
                    new Product { Name = "Proizvod 2", Price = 18.95M, ShortDescription = "Kratak opis proizvoda", LongDescription = "Detaljan opis proizvoda", Category = Categories["Kategorija 1"], ImageUrl = "https://www.pizzacorner.rs/imgs_android/2.jpg", InStock = true, IsProductOfTheWeek = false, ImageThumbnailUrl = "https://www.pizzacorner.rs/imgs_android/2.jpg" },
                    new Product { Name = "Proizvod 3", Price = 18.95M, ShortDescription = "Kratak opis proizvoda", LongDescription = "Detaljan opis proizvoda", Category = Categories["Kategorija 1"], ImageUrl = "https://www.pizzacorner.rs/imgs_android/3.jpg", InStock = true, IsProductOfTheWeek = false, ImageThumbnailUrl = "https://www.pizzacorner.rs/imgs_android/3.jpg" },
                    new Product { Name = "Proizvod 4", Price = 15.95M, ShortDescription = "Kratak opis proizvoda", LongDescription = "Detaljan opis proizvoda", Category = Categories["Kategorija 2"], ImageUrl = "https://www.pizzacorner.rs/imgs_android/4.jpg", InStock = true, IsProductOfTheWeek = false, ImageThumbnailUrl = "https://www.pizzacorner.rs/imgs_android/4.jpg" },
                    new Product { Name = "Proizvod 5", Price = 13.95M, ShortDescription = "Kratak opis proizvoda", LongDescription = "Detaljan opis proizvoda", Category = Categories["Kategorija 2"], ImageUrl = "https://www.pizzacorner.rs/imgs_android/5.jpg", InStock = true, IsProductOfTheWeek = false, ImageThumbnailUrl = "https://www.pizzacorner.rs/imgs_android/5.jpg" },
                    new Product { Name = "Proizvod 6", Price = 17.95M, ShortDescription = "Kratak opis proizvoda", LongDescription = "Detaljan opis proizvoda", Category = Categories["Kategorija 2"], ImageUrl = "https://www.pizzacorner.rs/imgs_android/6.jpg", InStock = true, IsProductOfTheWeek = false, ImageThumbnailUrl = "https://www.pizzacorner.rs/imgs_android/6.jpg" },
                    new Product { Name = "Proizvod 7", Price = 15.95M, ShortDescription = "Kratak opis proizvoda", LongDescription = "Detaljan opis proizvoda", Category = Categories["Kategorija 2"], ImageUrl = "https://www.pizzacorner.rs/imgs_android/7.jpg", InStock = false, IsProductOfTheWeek = false, ImageThumbnailUrl = "https://www.pizzacorner.rs/imgs_android/7.jpg" },
                    new Product { Name = "Proizvod 8", Price = 12.95M, ShortDescription = "Kratak opis proizvoda", LongDescription = "Detaljan opis proizvoda", Category = Categories["Kategorija 3"], ImageUrl = "https://www.pizzacorner.rs/imgs_android/8.jpg", InStock = true, IsProductOfTheWeek = true, ImageThumbnailUrl = "https://www.pizzacorner.rs/imgs_android/8.jpg" },
                    new Product { Name = "Proizvod 9", Price = 15.95M, ShortDescription = "Kratak opis proizvoda", LongDescription = "Detaljan opis proizvoda", Category = Categories["Kategorija 3"], ImageUrl = "https://www.pizzacorner.rs/imgs_android/9.jpg", InStock = true, IsProductOfTheWeek = true, ImageThumbnailUrl = "https://www.pizzacorner.rs/imgs_android/9.jpg" },
                    new Product { Name = "Proizvod 10", Price = 15.95M, ShortDescription = "Kratak opis proizvoda", LongDescription = "Detaljan opis proizvoda", Category = Categories["Kategorija 3"], ImageUrl = "https://www.pizzacorner.rs/imgs_android/10.jpg", InStock = true, IsProductOfTheWeek = false, ImageThumbnailUrl = "https://www.pizzacorner.rs/imgs_android/10.jpg" },
                    new Product { Name = "Proizvod 11", Price = 18.95M, ShortDescription = "Kratak opis proizvoda", LongDescription = "Detaljan opis proizvoda", Category = Categories["Kategorija 3"], ImageUrl = "https://www.pizzacorner.rs/imgs_android/12.jpg", InStock = false, IsProductOfTheWeek = false, ImageThumbnailUrl = "https://www.pizzacorner.rs/imgs_android/11.jpg" }
                );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Category> _categories;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    var genresList = new[]
                    {
                        new Category { CategoryName = "Kategorija 1" },
                        new Category { CategoryName = "Kategorija 2" },
                        new Category { CategoryName = "Kategorija 3" }
                    };

                    _categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        _categories.Add(genre.CategoryName, genre);
                    }
                }

                return _categories;
            }
        }
    }
}