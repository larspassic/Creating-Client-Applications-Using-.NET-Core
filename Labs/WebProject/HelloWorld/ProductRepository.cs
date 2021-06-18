using HelloWorld.Models;
using Microsoft.Extensions.Caching.Memory; //Need to have this
using System.Collections.Generic;

namespace HelloWorld
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }

    public class ProductRepository : IProductRepository
    {
        private IMemoryCache memoryCache; //Dependency injection for memory cache

        public ProductRepository(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public IEnumerable<Product> Products
        {
            get
            {
                Product[] items;

                if (!memoryCache.TryGetValue("MyProducts", out items)) //If we do have a cache called "MyProducts" then use it
                {
                    items = new[]
                        {
                        new Product{ ProductId=101, Name = "Baseball", Description="balls", Price=14.20m},
                        new Product{ ProductId=102, Name="Football", Description="nfl", Price=9.24m},
                        new Product{ Name="Tennis ball"} ,
                        new Product{ Name="Golf ball"},
                    };

                    //Excercise - sliding memory cache
                    memoryCache.Set("MyProducts", items, new MemoryCacheEntryOptions().SetSlidingExpiration(System.TimeSpan.FromSeconds(5)));
                }

                return (Product[])memoryCache.Get("MyProducts"); ;
            }
        }
    }
}