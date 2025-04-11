using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class Data
    {
        public static List<Book> Books { get; } = new()
        {
           new Book()
                {
                    Id = 1,
                    Title = "C# in Depth",
                    Author = "Jon Skeet",
                    Price = 49.99,
                    ISBN = "38347001",
                    NbrOfCopy= 5,
                    PublishDate = new DateTime(2023, 10, 1, 14, 30, 0,DateTimeKind.Utc)
                },
           new Book()
                {
                    Id = 2,
                    Title = "Clean Code",
                    Author = "Robert C. Martin",
                    Price = 39.99,
                    ISBN = "Clean001",
                    PublishDate = new DateTime(2023, 9, 15, 10, 0, 0,DateTimeKind.Utc)
                },
           new Book()
                {
                    Id = 3,
                    Title = "The Pragmatic Programmer",
                    Author = "Andrew Hunt and David Thomas",
                    Price = 45.50,
                    ISBN = "93893001",
                    PublishDate = new DateTime(2023, 8, 20, 9, 45, 0, DateTimeKind.Utc)
                },
           new Book()
                {
                    Id = 4,
                    Title = "Introduction to Algorithms",
                    Author = "Thomas H. Cormen",
                    Price = 59.99,
                    ISBN = "20283001",
                    PublishDate = new DateTime(2023, 7, 10, 8, 20, 0, DateTimeKind.Utc)
                },
           new Book()
                {
                    Id = 5,
                    Title = "Design Patterns: Elements of Reusable Object-Oriented Software",
                    Author = "Erich Gamma & Richard Hel",
                    Price = 55.90,
                    ISBN = "389339001",
                    NbrOfCopy = 4,
                    PublishDate = new DateTime(2023, 6, 5, 7, 15, 0, DateTimeKind.Utc)
                }

        };
    }
}
