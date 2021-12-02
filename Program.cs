using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Dev_Test_Nov_2021
{
    public class DataObject
    {
        public string name { get; set; }
        public string age { get; set; }
        public string count { get; set; }
    }
    //Write your name here
    class Program
    {
        private const string URL = "https://sub.domain.com/objects.json";
        const string urlParameters = "?name=bella";

        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
           // var dataObjects = response.Content.ReadAsStringAsync<IEnumerable<DataObject>>().Result;
            if (response.IsSuccessStatusCode)
            {
 
              //  foreach (var d in dataObjects)
                {
                    //Console.WriteLine("{0}", d.Age);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            client.Dispose();

            //Part 2
            List<Product> products = new List<Product> {
                new Product {Id = "B091NE9K3", Price =59.96, Quantity = 5},
                new Product {Id = "B091NEGU3", Price =7.05, Quantity = 10},
                new Product {Id = "B091NEEC3", Price =6.38, Quantity = 15},
                new Product {Id = "B091NE9S3", Price =13.25, Quantity = 23},
                new Product {Id = "B091NE9K4", Price =99.96, Quantity = 2},
                new Product {Id = "B091NEGU4", Price =22.83, Quantity = 150},
                new Product {Id = "B091NEEC4", Price =19.18, Quantity = 45},
                new Product {Id = "B091NE9S4", Price =28.88, Quantity = 345},
                new Product {Id = "B091NE9K5", Price =49.99, Quantity = 589},
                new Product {Id = "B091NEGU5", Price =12.05, Quantity = 25},
            };

            double totalPrice = 0;
            Console.WriteLine("Ids low stock");
            foreach (var item in products)
            {
                if(item.Quantity < 10)
                {
                    Console.WriteLine(item.Id);
                }

                totalPrice += item.Price;

                if (item.Id.Equals("B091NE9K4"))
                {
                    item.Price = item.Price * 0.7;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Avg Price: $" + (totalPrice / products.Count).ToString("0.##"));
            Console.WriteLine();
            Console.WriteLine("Updated List");

            foreach (var item in products)
            {
                Console.WriteLine(item.Id + " $" + (item.Price).ToString("0.##"));
            }

            //Part 3 
            int[] ordersIds = { 1, 2, 3, 4, 5};
            double[] ordersValues = { 25.5, 92.5, 78.23, 12.95, 83.67 };
            string[] ordersCustomers = { "Tracy Erkut", "Arvin Aitken", "Ryan Mae", "Sherri Smith", "Adam Weller" };

            string fmt = "{0,-10} {1,-10:c2} {2, 2}";
           Order order = new Order();
           List<Order> orderList = new List<Order>();

            for (int i=0; i < ordersValues.Length; i++)
            {
                order = new Order(ordersIds[i], ordersValues[i], ordersCustomers[i]);
                orderList.Add(order);
            }

            orderList = orderList.OrderBy(x => x.orderValue).ToList();

            Console.WriteLine(String.Format(fmt, "OrderId", "Value", "Customer"));
            foreach (var item in orderList)
            {
                Console.WriteLine(String.Format(fmt, item.id, item.orderValue, item.customer));
            }

            Console.ReadLine();
        }
    }

    class Order
    {

        public int id;
        public double orderValue;
        public string customer;

        public Order()
        {

        }

        public Order(int id, double orderValue, string customer){

            this.id = id;
            this.orderValue = orderValue;
            this.customer = customer;
        }

        public int OrderId
        {
            get { return id; }
            set { id = value; }
        }

        public double OrderValue
        {
            get { return orderValue; }
            set { orderValue = value; }
        }

        public string OrderCustomer
        {
            get { return customer; }
            set { customer = value; }
        }
    }

    class Product
    {
        public string Id { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }
    }
}
