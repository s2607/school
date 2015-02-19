using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiC;

namespace LiC
{
    class Week2
    {
        public static void Main(string[] args)
        {

            var names = Program.GetNames();
            var numbers = Program.GetNumbers();
            var parts = Part.SelectAll();
            var customers = Customer.SelectAll();
            string person = names.FirstOrDefault(delegate(string n)
            {
                return n.Equals("James River");
            })
            ;
            person = names.FirstOrDefault(n => n.Equals("James River"));
            int startWith = 40;
            var subset = numbers
                .Where(n => n >= startWith);
            //          ^lambda ^ less then or equal

            startWith = 50;
            int sum = subset.Sum();
            var sortedNums = numbers.OrderBy(n => n);

            Console.WriteLine("Sum is {0}", sum);
            var partInfo = (
                from part in parts
                select new
                {
                    Name = part.Name,
                    PartQuantity = part.Quantity,
                    ReceiptQuantity = part.Receipts.Sum(r => r.Quantity) //sum the quantitys of the all recipts
                }
                );
            foreach (var pi in partInfo)
            {
                Console.WriteLine("{0} inventory is {1}. Recipts ={2}", pi.Name, pi.PartQuantity, pi.ReceiptQuantity);
            }
            var customerInfo = (
                from customer in customers
                select new
                {
                    name = customer.Name,
                    balance = customer.Balance,
                    totalSales = customer.Orders.Sum(o => o.Amount)
                }
                );
            foreach (var customer in customerInfo)
            {
                Console.WriteLine("{0} Balance is: {1} Total sales is: {2}", customer.name, customer.balance, customer.totalSales);
            }
            Console.ReadKey();
        }
    }
}
