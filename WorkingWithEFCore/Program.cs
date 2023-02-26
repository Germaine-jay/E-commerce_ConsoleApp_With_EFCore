using EFCoreApp.DAL.Data;
using EFCoreApp.DAL.Models;
using Microsoft.EntityFrameworkCore;

public class Program
{
    static async Task Main()
    {
        GermaineStoresDbContextFactory toDoAppDbContextFactory = new GermaineStoresDbContextFactory();
        var dbcontext = toDoAppDbContextFactory.CreateDbContext(null);

        bool anyCustomer = dbcontext.Customers.Any();


        if (!anyCustomer)
        {
            var customer = new List<Customer>()
          {
              new Customer()
              {
                  FirstName= "ositadimma",
                  LastName= "sanchez",
                  Address = "15 Ibiyeye street",
                  Phone = "09130045685",
                  Email = "ositadimma.jay@outlook.com",
                  Orders =  new List<EFCoreApp.DAL.Models.Order>()
                  {
                        new Order()
                        {
                            OrderPlaced = DateTime.Now,
                            OrderFufilled = new DateTime(2023,2,23),
                            //Customer = new Customer(),
                            OrderDetails= new List<EFCoreApp.DAL.Models.OrderDetail>()
                            {
                                new OrderDetail()
                                {
                                    Quantity = "3",
                                    Product = new Product()
                                    {
                                        Name = "Joy soap",
                                        Price= 1000
                                    },
                                },
                            },

                        },
                  }
              },
              new Customer()
              {
                  FirstName= "chisom",
                  LastName= "chukwu",
                  Address = "15 Ezechime street",
                  Phone = "09131145645",
                  Email = "chisom.chukwu@outlook.com",
                  Orders =  new List<EFCoreApp.DAL.Models.Order>()
                  {
                    new Order()
                    {
                        OrderPlaced = DateTime.Now,
                        OrderFufilled = new DateTime(2023,2,23),
                        //Customer = new Customer(),
                        OrderDetails= new List<EFCoreApp.DAL.Models.OrderDetail>()
                        {
                            new OrderDetail()
                            {
                                Quantity = "5",
                                Product = new Product()
                                {
                                    Name = "Lexus jeep",
                                    Price= 1000
                                },
                            },
                        },

                    },
                  }
              },
              new Customer()
              {
                  FirstName= "Kayla",
                  LastName= "Okoli",
                  Address = "10 Adedeji street",
                  Phone = "09133345685",
                  Email = "Kayla.okoli@jonzing.com",
                  Orders =  new List<EFCoreApp.DAL.Models.Order>()
                  {
                    new Order()
                    {
                        OrderPlaced = DateTime.Now,
                        OrderFufilled = new DateTime(2023,2,23),
                        //Customer = new Customer(),
                        OrderDetails= new List<EFCoreApp.DAL.Models.OrderDetail>()
                        {
                            new OrderDetail()
                            {
                                Quantity = "2",
                                Product = new Product()
                                {
                                    Name= "Dell Laptop",
                                    Price = 4000
                                },
                            },
                        },

                    },
                  }
              },
              new Customer()
              {
                  FirstName= "germane",
                  LastName= "jay",
                  Address = "7 Ibiyeye street",
                  Phone = "09133345685",
                  Email = "germane.jay@outlook.com",
                  Orders =  new List<EFCoreApp.DAL.Models.Order>()
                  {
                    new Order()
                    {
                        OrderPlaced = DateTime.Now,
                        OrderFufilled = new DateTime(2023,2,23),
                        Customer = new Customer(),
                        OrderDetails= new List<EFCoreApp.DAL.Models.OrderDetail>()
                        {
                            new OrderDetail()
                            {
                                Quantity = "5",
                                Product = new Product()
                                {
                                    Name = "dre headphones",
                                    Price = 2000
                                },
                            },
                        },

                    },
                  }
              },
              new Customer()
              {
                  FirstName= "johnson",
                  LastName= "osita",
                  Address = "23 odogwu street",
                  Phone = "09133355685",
                  Email = "johnson.osita@jonzing.com",
                  Orders =  new List<EFCoreApp.DAL.Models.Order>()
                  {
                    new Order()
                    {
                        OrderPlaced = DateTime.Now,
                        OrderFufilled = new DateTime(2023,2,23),
                        Customer = new Customer(),
                        OrderDetails= new List<EFCoreApp.DAL.Models.OrderDetail>()
                        {
                            new OrderDetail()
                            {
                                Quantity = "5",
                                Product = new Product()
                                {
                                    Name = "Nike airforce",
                                    Price = 1000
                                },
                            },
                        },

                    },
                  }
              },
          };
            dbcontext.AddRange(customer);
            Console.WriteLine(dbcontext.SaveChanges());
        }


        Console.WriteLine("Fetch All Customers and Orders==========");
        Console.WriteLine();
        var AllCustomerAndProduct = dbcontext.Customers.OrderBy(u => u.Id).Include(i => i.Orders).ThenInclude(i => i.OrderDetails).ThenInclude(i => i.Product).ToList();

        foreach(var user in AllCustomerAndProduct)
        {
            foreach(var order in user.Orders)
            {
                foreach(var orderDetail in order.OrderDetails)
                {
                    Console.WriteLine($" Customer =>ID:{user.Id}  FIRSTNAME: {user.FirstName}  LASTNAME: {user.LastName}  EMAIL : {user.Email}  PHONE : {user.Phone}\n Order => ID: {order.Id} PLACED : {order.OrderPlaced}\n OrderDetails => QUANTITY : {orderDetail.Quantity} {orderDetail.Product.Name} FUFILLED : {orderDetail.Order.OrderFufilled}");
                    Console.WriteLine();
                }
            }         
        }

    }

}

 