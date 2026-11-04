using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUni2
{
    public class ComicStock
    {
        public string ThemeName { get; set; }
        public int Price { get; set; }   // $ per book
        public int Stock { get; set; }   // books currently in stock

        public ComicStock(string themeName, int price, int stock)
        {
            ThemeName = themeName;
            Price = price;
            Stock = stock;
        }

        public int TotalValue()
        {
            return Stock * Price;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Processor processor = new Processor();
            processor.Process();
        }
    }

    class Processor
    {
        private const string ValidUsername = "admin";
        private const string ValidPassword = "adminpass";

        private List<ComicStock> comics = new List<ComicStock>();

        public void Process()
        {
            // Starting data
            comics.Add(new ComicStock("Joker", 13, 398));
            comics.Add(new ComicStock("Batman", 22, 1203));
            comics.Add(new ComicStock("Cat", 11, 452));
            comics.Add(new ComicStock("Riddler", 15, 100));
            comics.Add(new ComicStock("Penguin", 19, 201));

            // Login: one attempt and exit if not authorized
            if (!Login())
            {
                Console.WriteLine("You are not authorized to access this service");
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
                return;
            }

            // Menu loop
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine(
                    "****** Here are your options ******\n" +
                    "Please select the action.\n" +
                    "1. Show stock count for each theme of books.\n" +
                    "2. Show total value of each theme type for all comic books in stock.\n" +
                    "3. Register one comic book sold for a given theme.\n" +
                    "4. Get stock status // veryLow, Low, Normal, Over\n" +
                    "5. Exit"
                );

                int option = ReadInt("Your choice: ");

                switch (option)
                {
                    case 1:
                        ShowStockCounts();
                        break;
                    case 2:
                        ShowStockValues();
                        break;
                    case 3:
                        RegisterSale();
                        break;
                    case 4:
                        ShowStockStatus();
                        break;
                    case 5:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("\nInvalid option, please choose between 1 and 5.");
                        WaitForEnter();
                        break;
                }
            }

            Console.WriteLine("Goodbye!");
        }

        // ---------- Login ----------

        private bool Login()
        {
            Console.Write("Please provide username to access the ComicX system (test user: admin): ");
            string username = Console.ReadLine();

            Console.Write("Please provide password (test user: adminpass): ");
            string password = Console.ReadLine();

            return username == ValidUsername && password == ValidPassword;
        }

        // ---------- Menu actions ----------

        private void ShowStockCounts()
        {
            Console.Clear();
            foreach (ComicStock comic in comics)
            {
                Console.WriteLine($"{comic.ThemeName} comic book stock: {comic.Stock}");
            }
            WaitForEnter();
        }

        private void ShowStockValues()
        {
            Console.Clear();
            foreach (ComicStock comic in comics)
            {
                Console.WriteLine($"Total value of {comic.ThemeName} comics: ${comic.TotalValue()}");
            }
            WaitForEnter();
        }

        private void RegisterSale()
        {
            Console.Clear();
            Console.WriteLine("Register one comic book sold, themes are below.");
            for (int i = 0; i < comics.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {comics[i].ThemeName} (stock: {comics[i].Stock})");
            }

            int choice = ReadInt("Your choice: ");

            if (choice < 1 || choice > comics.Count)
            {
                Console.WriteLine("\nInvalid theme.");
                WaitForEnter();
                return;
            }

            string theme = comics[choice - 1].ThemeName;

            if (OneBookSold(theme))
            {
                Console.WriteLine($"\nA {theme} comic has been sold!");
            }
            else
            {
                Console.WriteLine($"\nCannot register sale: no {theme} comics left in stock.");
            }
            WaitForEnter();
        }

        private void ShowStockStatus()
        {
            Console.Clear();
            Console.WriteLine($"Total stock of every comic book is...\n{TotalStock()}");
            Console.WriteLine($"Stock status is...\n{GetStockStatus()}");
            WaitForEnter();
        }

        // ---------- Logic methods ----------

        public bool OneBookSold(string themeType)
        {
            ComicStock comic = comics.FirstOrDefault(
                c => c.ThemeName.Equals(themeType, StringComparison.OrdinalIgnoreCase));

            if (comic == null || comic.Stock <= 0)
            {
                return false;
            }

            comic.Stock--;
            return true;
        }

        public int TotalStock()
        {
            return comics.Sum(c => c.Stock);
        }

        // veryLow: < 1000, Low: 1000-1500, Normal: > 1500, Over: > 5000
        public string GetStockStatus()
        {
            int total = TotalStock();

            if (total > 5000) return "Over";
            if (total > 1500) return "Normal";
            if (total >= 1000) return "Low";
            return "Very Low";
        }

        // ---------- Helpers ----------
        private int ReadInt(string prompt)
        {
            int value;
            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Please enter a number: ");
            }
            return value;
        }

        private void WaitForEnter()
        {
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }
    }
}