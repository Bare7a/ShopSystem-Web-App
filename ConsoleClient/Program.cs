using Data;
using System.Linq;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new ShopContext();

            System.Console.WriteLine(db.Products.Count());
        }
    }
}
