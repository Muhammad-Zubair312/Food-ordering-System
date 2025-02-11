using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace Food_Ordering_System
{


    class Customer
    {
        private string name;
        private int age;
        private string location;
        private int id;


        public void addCustomer(Customer C)
        {
            this.name = C.name;
            this.age = C.age;
            this.location = C.location;
            this.id = C.id;

            FileStream fin = new FileStream("Customer.txt", FileMode.Append);
            StreamWriter finW = new StreamWriter(fin);
            string data = $"{this.name}, {this.age}, {this.location}, {this.id}";
            finW.WriteLine(data);
            finW.Close();
            fin.Close();
        }

        public List<Customer> getAll()
        {
            List<Customer> list = new List<Customer>();
            FileStream fout = new FileStream("Customer.txt", FileMode.Open);
            StreamReader foutR = new StreamReader(fout);

            string data;

            while ((data = foutR.ReadLine()) != null)
            {

                string[] customerData = data.Split(',');

                Customer customer1 = new Customer();
                customer1.Name = customerData[0];
                customer1.Age = int.Parse(customerData[1]);
                customer1.Location = customerData[2];
                customer1.Id = int.Parse(customerData[3]);

                list.Add(customer1);
            }
            foutR.Close();
            fout.Close();


            return list;
        }



        public override string ToString()
        {
            return $"Name: {this.name} Age: {this.age} Address: {this.location} Id: {this.id}";
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }



    }

    class Item
    {
        private string name;
        private string description;
        private int id;
        private int quantity;


        public void addItem(Item I)
        {
            //this.name = I.name;
            //this.description = I.description;
            //this.id = I.id;
            //this.quantity = I.quantity;

            FileStream fin = new FileStream("Item.txt", FileMode.Append);
            StreamWriter finW = new StreamWriter(fin);
            string data = $"{this.name}, {this.description}, {this.id}, {this.quantity}";
            finW.WriteLine(data);
            finW.Close();
            fin.Close();
        }


        public List<Item> getAll()
        {
            List<Item> list = new List<Item>();
            FileStream fout = new FileStream("Item.txt", FileMode.Open);
            StreamReader foutR = new StreamReader(fout);

            string data = foutR.ReadLine();

            while (data != null)
            {
                string[] itemData = data.Split(',');

                Item item1 = new Item();
                item1.Name = itemData[0];
                item1.Description = itemData[1];
                item1.Id = int.Parse(itemData[2]);
                item1.Quantity = int.Parse(itemData[3]);

                list.Add(item1);
                data = foutR.ReadLine();
            }

            foutR.Close();
            fout.Close();


            return list;
        }


        public List<Item> getByNames(string name)
        {
            List<Item> list = new List<Item>();
            FileStream fout = new FileStream("Item.txt", FileMode.Open);
            StreamReader foutR = new StreamReader(fout);

            string data = foutR.ReadLine();

            while (data != null)
            {
                string[] itemData = data.Split(',');

                if (itemData[0] == name)
                {
                    Item item1 = new Item();
                    item1.Name = itemData[0];
                    item1.Description = itemData[1];
                    item1.Id = int.Parse(itemData[2]);
                    item1.Quantity = int.Parse(itemData[3]);

                    list.Add(item1);
                }
                data = foutR.ReadLine();
            }

            foutR.Close();
            fout.Close();

            return list;
        }
        
        public Item Check(string name)
        {
            List<Item> list = new List<Item>();
            FileStream fout = new FileStream("Item.txt", FileMode.Open);
            StreamReader foutR = new StreamReader(fout);

            string data = foutR.ReadLine();

            Item item1 = new Item();

            while (data != null)
            {
                string[] itemData = data.Split(',');
                

                if (itemData[0] == name)
                {
                    item1.Name = itemData[0];
                    item1.Description = itemData[1];
                    item1.Id = int.Parse(itemData[2]);
                    item1.Quantity = int.Parse(itemData[3]);

                    }
                data = foutR.ReadLine();
            }

            foutR.Close();
            fout.Close();

            return item1;

        }
        public override string ToString()
        {
            return $"Item Name: {this.name} Item-Description: {this.description} Item-Id: {this.id} Item-Quantity: {this.quantity}";
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
    }

    class OrderProcessing
    {
        public void order(Customer c, List<Item> list)
        {
            FileStream fin = new FileStream("Confirm-order.txt", FileMode.Append);
            StreamWriter finW = new StreamWriter(fin);
            string data = $"The Customer-Name {c.Name} Customer-Age {c.Age} Customer-Location {c.Location} Customer-Id {c.Id}";
            foreach (Item item in list)
            {
                data += $"{item.Name}  {item.Id}";
            }
            finW.WriteLine(data);
            finW.Close();
            fin.Close();
        }

        public void printOrders()
        {
            FileStream fout = new FileStream("Confirm-order.txt", FileMode.Open);
            StreamReader fR = new StreamReader(fout);
            string data = fR.ReadLine();
            
            while (data != null)
            {
                string[] order = data.Split(',');

                Console.WriteLine($"Customer Name: {order[0]}");
                Console.WriteLine($"Customer Age: {int.Parse(order[1])}");
                Console.WriteLine($"Customer Location: {order[2]}");
                Console.WriteLine($"Customer Id: {int.Parse(order[3])}");
                Console.WriteLine($"Item Name: {order[4]}");
                Console.WriteLine($"Item Price: {order[5]}");
                data = fR.ReadLine();
            }
        }
        
    }

    class Program
    {

        static void Main(string[] args)
        {

            
            Console.WriteLine("Type: =>Add Customer\n=>Check All Customer\n=>Add Item\n=>Check Item By Name\n=>Check All Item\n=>Place Order\n=>Check All Order");
            Console.Write("Enter Your Choice: ");
            string option = Console.ReadLine();

            if (option.ToUpper() == "ADD CUSTOMER")
            {

                Console.Write("Enter Customer Name: ");
                string cName = Console.ReadLine();
                Console.Write("Enter Customer Age: ");
                string cAge = Console.ReadLine();
                Console.Write("Enter Customer Location: ");
                string cLocation = Console.ReadLine();
                Console.Write("Enter Customer ID: ");
                string cId = Console.ReadLine();

                Customer customer = new Customer();
                customer.Name = cName;
                customer.Age = int.Parse(cAge);
                customer.Location = cLocation;
                customer.Id = int.Parse(cId);


                customer.addCustomer(customer);
            }

            else if (option.ToUpper() == "CHECK ALL CUSTOMER")
            {
                Customer customer = new Customer();
                List<Customer> cso = customer.getAll();
                foreach (Customer cs in cso)
                {
                    Console.WriteLine($"The Customer-Name {cs.Name} Customer-Age {cs.Age} Customer-Location {cs.Location} Customer-Id {cs.Id}");
                }
            }

            else if (option.ToUpper() == "ADD ITEM")
            {
                Console.Write("Enter Item Name: ");
                string iName = Console.ReadLine();
                Console.Write("Enter Item Description: ");
                string iDescription = Console.ReadLine();
                Console.Write("Enter Item ID: ");
                string iId = Console.ReadLine();
                Console.Write("Enter Item Quantity: ");
                string iQuantity = Console.ReadLine();

                Item item = new Item();
                item.Name = iName;
                item.Description = iDescription;
                item.Id = int.Parse(iId);
                item.Quantity = int.Parse(iQuantity);

                item.addItem(item);
            }
            
            else if (option.ToUpper() == "CHECK ITEM BY NAME")
            {
                Console.Write("Enter Item name");
                string name = Console.ReadLine();
                Item item = new Item();
                item.getByNames(name);
            }

            else if (option.ToUpper() == "CHECK ALL ITEM")
            {
                Item item = new Item();
                List<Item> iso = item.getAll();
                foreach (Item itm in iso)
                {
                    Console.WriteLine($"The Item-Name {itm.Name} Item-Description {itm.Description} Item-Id {itm.Id} Item-Quantity {itm.Quantity}");
                }
            }

            else if (option.ToUpper() == "PLACE ORDER")
            {

                Console.Write("Enter Customer Name for order processing: ");
                string c1 = Console.ReadLine();
                Console.Write("Enter Customer Age: ");
                string c2 = Console.ReadLine();
                Console.Write("Enter Customer Location: ");
                string c3 = Console.ReadLine();
                Console.Write("Enter Customer ID: ");
                string c4 = Console.ReadLine();

                Customer customer1 = new Customer();
                customer1.Name = c1;
                customer1.Age = int.Parse(c2);
                customer1.Location = c3;
                customer1.Id = int.Parse(c4);

                Console.WriteLine("Enter All the items you want to Order: ");
                List<Item> list = new List<Item>();
                Item i = new Item();
                while (true)
                {
                    Console.Write("Enter Item Name You Want to Order: ");
                    string i1 = Console.ReadLine();
                    Item obj = i.Check(i1);
                    list.Add(obj);
                    Console.Write("Are you want to Continue(Yes/No): ");
                    String choice = Console.ReadLine();
                    if (choice.ToLower() == "No")
                    {
                        break;
                    }
                }

                OrderProcessing ord = new OrderProcessing();
                ord.order(customer1, list);
            }

            else if (option.ToUpper() == "CHECK ALL ORDER")
            {
                OrderProcessing ord = new OrderProcessing();
                ord.printOrders();
            }
            else
            {
                Console.WriteLine("Invalid Choice!");
            }

        }
    } } 

