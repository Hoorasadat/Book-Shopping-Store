// See https://aka.ms/new-console-template for more information
using System;
namespace Book_Shopping_Store
{
    class Program
    {
        public static List<Book> ourBooks = new List<Book>
        {
            new Book() { Title = "Coding Fundamentals", Price = 10.23m },
            new Book() { Title = "Jobs/Careers in Tech", Price = 18.53m },
            new Book() { Title = "HTML and CSS", Price = 30.13m },
            new Book() { Title = "JavaScript", Price = 12.04m },
            new Book() { Title = "Java", Price = 23.53m },
            new Book() { Title = "PHP", Price = 28.25m },
            new Book() { Title = "Ruby", Price = 17.45m },
            new Book() { Title = "Python", Price = 16.73m },
            new Book() { Title = "C#", Price = 35.03m },
            new Book() { Title = "Objective C", Price = 32.09m },
            new Book() { Title = "C", Price = 29.73m },
            new Book() { Title = "C++", Price = 27.20m },
            new Book() { Title = "R", Price = 19.73m },
            new Book() { Title = "SQL", Price = 22.23m },
            new Book() { Title = "Android", Price = 34.20m },
            new Book() { Title = "iOS/Swift", Price = 23.83m },
            new Book() { Title = "TypeScript", Price = 17.45m },
            new Book() { Title = "Rust", Price = 9.89m },
            new Book() { Title = "Go", Price = 7.00m },
        };

        public static List<Book> selectedBooks = new List<Book>();

        static void Main(string[] arg)
        {
            Console.WriteLine("Welcome to our online book store!");
            Console.WriteLine("Would you like to see the list of our books?");
            var showList = GetAnswer(Console.ReadLine());
            if (showList == true)
            {
                Console.WriteLine("********************************");
                ShowBooks(ourBooks);
                Console.WriteLine("********************************");
            }
            Console.WriteLine("Would you like to buy books from us?");
            var isShopping = GetAnswer(Console.ReadLine());
            while(isShopping)
            {
                Shopping("buy");
                Console.WriteLine("Are you done with your shopping?");
                var doneShopping = GetAnswer(Console.ReadLine());
                if (doneShopping == true)
                {
                    isShopping = false;
                }
            }
            Console.WriteLine("Well Done! These are the list of books that you have choosen:");
            ShowBooks(selectedBooks);
            Console.WriteLine("Would you like to edit your shopping bag?");
            var isNotConfirmed = GetAnswer(Console.ReadLine());
            while(isNotConfirmed)
            {
                Shopping("remove");
                Console.WriteLine("Are you done with your shopping?");
                var doneShopping = GetAnswer(Console.ReadLine());
                if (doneShopping == true)
                {
                    isNotConfirmed = false;
                }
            }
            Console.WriteLine("Well Done! These are the list of books that you have choosen:");
            ShowBooks(selectedBooks);
            Console.WriteLine($"You are supposed to pay ${TotalPrice()} to us upon pickup. See you again!");
        }

        static bool GetAnswer(string? answer)
        {
            bool boolAnswer = false;
            if (answer != null)
            {
                if (answer.ToLower() == "yes")
                {
                    boolAnswer = true;
                }
            }
            return boolAnswer;
        }

        static void ShowBooks(List<Book> books)
        {
            foreach (var item in books)
            {
                Console.WriteLine($"{item.Title} for the price of ${item.Price}");
            }
        }

        static void Shopping(string action)
        {
            Console.WriteLine($"Which book would you like to {action}?");
            var wantedBook = Console.ReadLine();
            List<Book> editingList = new List<Book>();
            if (action == "buy")
            {
                editingList = ourBooks;
            }
            else
            {
                editingList = selectedBooks;
            }
            foreach(var item in SearchBooks(wantedBook, editingList))
            {
                Console.WriteLine($"Do you mean {item.Title}?");
                var IsBookCorrect = GetAnswer(Console.ReadLine());
                if (IsBookCorrect)
                {
                    if (action == "buy")
                    {
                        selectedBooks.Add(item);
                    }
                    else
                    {
                        selectedBooks.Remove(item);
                    }
                    return;
                }
            }
        }

        static List<Book> SearchBooks(string book, List<Book> books)
        {
            if (book != null && books != null)
            {
                List<Book> foundBooks = books.Where(b => b.Title.ToLower().Contains(book)).ToList();
                return foundBooks;
            }
            return books;
        }

        static decimal TotalPrice()
        {
            decimal totalPrice = 0;
            foreach (Book item in selectedBooks)
            {
                totalPrice += item.Price;
            }
            return totalPrice;
        }
        public class Book
        {
            public string? Title { get; set; }
            public decimal Price { get; set; }
        }
    }
}
