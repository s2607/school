using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqConsole
{
    class Program
    {
        delegate int Numbers(int[] numbers);    //-< Ignore this for now <<<

        static void Main(string[] args)
        {
            //--< Populate our data >--//
            var names = GetNames();
            var numbers = GetNumbers();
            #region Get Inventory Objects
            var parts = Part.SelectAll();
            var receipts = Receipt.SelectAll();
            var customers = Customer.SelectAll();
            var orders = SalesOrder.SelectAll();
            #endregion

            //--< Modify method SumNumbers( ) to return the sum of the numbers in the array >--//
            Console.WriteLine("The sum of the numbers is {0}", SumNumbers(numbers));

            //--< Modify method LargestNumber( ) to return the largest number in the array >--//
            Console.WriteLine("The largest number is {0}", LargestNumber(numbers));

            #region Anonymous Methods
            //--< These are "anonymous methods" because the methods have no names >--//
            Numbers firstNum = delegate(int[] num) { return num[0]; };      //--< Uses delegate <<<
            Numbers lastNum = (num) => { return num[num.Length - 1]; };     //--< Same but uses a lambda "(num) =>" <<<

            Console.WriteLine("The first number in the array is {0}", firstNum(numbers));
            Console.WriteLine("The last number in the array is {0}", lastNum(numbers));
            #endregion
            Console.ReadLine();
        }

        private static int SumNumbers(int[] numbers)
        {
            return 0;       //--< Change this to return the sum of the numbers in the collection
        }
        private static int LargestNumber(int[] numbers)
        {
            return 0;       //--< Change this to return the largest number in the collection
        }


        #region Populate Data Methods
        private static List<string> GetNames()
        {
            List<String> Names = new List<string>() { "James River", "Annabelle Lee", "Glen Syde", "Hugh Gaknot", "Skip Wythe" };
            return Names;
        }

        private static int[] GetNumbers()
        {
            int[] amounts = { 7, 42, 14, 56, 21, 0, 14, 28, 35, 42 };
            return amounts;
        }
        #endregion
    }

    #region Internal Classes
    public class Part
    {
        public int PartID;
        public string Name;
        public int Quantity;
        public decimal CurrentValue;
        public List<Receipt> Receipts;

        public static List<Part> SelectAll()
        {
            List<Part> Parts = new List<Part>(){
		new Part(){ PartID = 1, Name="Mr. Fusion Home Energy Reactor", Quantity=10, CurrentValue=125.00m,
			Receipts = new List<Receipt>(){
				new Receipt(){ReceiptID = 101, PartID=1, Quantity=3, TotalCost=30.10m},
				new Receipt(){ReceiptID = 102, PartID=1, Quantity=4, TotalCost=42.22m}
			}
		},
		new Part(){ PartID = 2, Name="Paulie's Robot", Quantity=20, CurrentValue=1235.39m,
			Receipts = new List<Receipt>(){
				new Receipt(){ReceiptID = 201, PartID=2, Quantity=5, TotalCost=518.10m},
				new Receipt(){ReceiptID = 202, PartID=2, Quantity=7, TotalCost=782.22m},
				new Receipt(){ReceiptID = 203, PartID=2, Quantity=3, TotalCost=384.12m}
			}
		},
		new Part(){ PartID = 3, Name="Organic Air", Quantity=40, CurrentValue=4125.75m,
			Receipts = new List<Receipt>(){
				new Receipt(){ReceiptID = 301, PartID=3, Quantity=2, TotalCost=818.10m},
				new Receipt(){ReceiptID = 302, PartID=3, Quantity=3, TotalCost=1182.22m},
				new Receipt(){ReceiptID = 303, PartID=3, Quantity=5, TotalCost=3184.12m}
			}		
		}
	};
            return Parts;
        }
    }
    public class Receipt
    {
        public int ReceiptID;
        public int PartID;
        public int Quantity;
        public decimal TotalCost;

        public static List<Receipt> SelectAll()
        {
            var parts = Part.SelectAll();
            List<Receipt> receipts = (from c in parts
                                      from r in c.Receipts
                                      select r).ToList();
            return receipts;
        }
    }

    public class SalesOrder
    {
        public int OrderNumber;
        public int CustomerID;
        public decimal Amount;

        public static List<SalesOrder> SelectAll()
        {
            var customers = Customer.SelectAll();
            return (from c in customers
                    from o in c.Orders
                    select o).ToList();
        }
    }
    public class Customer
    {
        public int CustomerID;
        public string Name;
        public decimal Balance;
        public List<SalesOrder> Orders;
        public static List<Customer> SelectAll()
        {
            List<Customer> Customers = new List<Customer>(){
		new Customer(){ CustomerID = 1, Name="James River", Balance=100,
			Orders = new List<SalesOrder>(){
				new SalesOrder(){OrderNumber = 101, CustomerID=1, Amount=10.10m},
				new SalesOrder(){OrderNumber = 102, CustomerID=1, Amount=12.22m}
			}
		},
		new Customer(){ CustomerID = 2, Name="Annabelle Lee", Balance=200,
			Orders = new List<SalesOrder>(){
				new SalesOrder(){OrderNumber = 201, CustomerID=2, Amount=118.10m},
				new SalesOrder(){OrderNumber = 202, CustomerID=2, Amount=182.22m},
				new SalesOrder(){OrderNumber = 203, CustomerID=2, Amount=84.12m}
			}
		},
		new Customer(){ CustomerID = 3, Name="Glen Syde", Balance=400,
			Orders = new List<SalesOrder>(){
				new SalesOrder(){OrderNumber = 301, CustomerID=3, Amount=18.18m},
				new SalesOrder(){OrderNumber = 302, CustomerID=3, Amount=18.12m},
				new SalesOrder(){OrderNumber = 303, CustomerID=3, Amount=53.24m},
				new SalesOrder(){OrderNumber = 304, CustomerID=3, Amount=192.12m}
			}		
		}
	};
            return Customers;
        }
    }
    #endregion
}
