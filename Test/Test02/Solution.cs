
class Solution
{

    public static void Q1(ExamContext db, string Name)
    {
        //Find customers whose part of FirstName or LastName is (john). List down all information of such customer
        var details = db.Customers.Where(c => c.FirstName.Contains(Name) || c.LastName.Contains(Name)).OrderBy(c => c.ID).Select(c => c);

        foreach (var item in details)
        {
            Console.WriteLine($"ID: {item.ID}, FirstName: {item.FirstName}, LastName:{item.LastName}");
        }

    }

    public static void Q2(ExamContext db, int ProductID)
    {
        //Find infromation for given Product ID, the information should include Company Name, Product Name and Price. Use of reference navigation properties is strictly prohibited for all exercises
        var details = db.Products.Where(p => p.ID == ProductID).Select(p => new { comp_name = p._Company.Name, p.Name, p.Price });

        foreach (var item in details)
        {
            Console.WriteLine($"Company: {item.comp_name}, Prodcut: {item.Name}, Price: {item.Price}");
        }
    }

    public static void Q3(ExamContext db)
    {
        //List down county name, and total number of companies per country, along with the company info (Id, Name and Country of the companies for each country) Country can have null value
        var details = db.Companies.GroupBy(c => c.Country.ToUpper() ?? "NULL").Select(c => new { Country = c.Key, Count = c.Count(), Companies = c.Select(c => new { c.ID, c.Name, c.Country }) });


        foreach (var item in details)
        {
            Console.WriteLine($"{item.Country}, {item.Count}");
            foreach (var company in item.Companies)
            {
                Console.WriteLine($"{company.ID}, {company.Name}, {company.Country}");
            }
        }
    }

    public static void Q4(ExamContext db, int OrderID)
    {
        //Create a complete bill for a given order, include customer name, ordered, date, total and order details, each product name, quentity, unit price and total price

        var customerOrder = from customer in db.Customers
                            join order in db.Orders on customer.ID equals order.CustomerID
                            join shoppingCart in db.ShoppingCarts on order.ID equals shoppingCart.OrderID
                            join product in db.Products on shoppingCart.ProductID equals product.ID
                            where order.ID == OrderID
                            select new { customer, order, shoppingCart, product };


        Console.WriteLine($"Customer: {customerOrder.FirstOrDefault()?.customer.FirstName} {customerOrder.FirstOrDefault()?.customer.LastName}");
        Console.WriteLine($"OrderID: {customerOrder.FirstOrDefault()?.order.ID}");
        foreach (var item in customerOrder)
        {
            Console.WriteLine($"{item.product.Name}, {item.product.Price} x {item.shoppingCart.Quantity} = {item.product.Price * item.shoppingCart.Quantity}");
        }
        Console.WriteLine($"Grand total: {customerOrder.Sum(c => c.product.Price * c.shoppingCart.Quantity)}");
    }

    public static void Q5(ExamContext db)
    {
        //List down all products, an unsold product is the one which never appear in any order/shoppingcart
        //var details = db.Products.Where(p => p.ShoppingCarts.Count == 0).Select(p => p);
        var details = db.Products.Where(p => db.ShoppingCarts.Select(p => p.ProductID).OrderBy(p => p).Contains(p.ID) == false).Select(p => p); //this is the same as above (I think

        foreach (var item in details)
        {
            Console.WriteLine($"Product:{item.ID}, {item.Name}, {item.Price}");
        }
    }

    public static void Q6(ExamContext db)
    {

    }
    public static void Q7(ExamContext db, string Country, decimal fraction)
    {


    }
    public static void Q8(ExamContext db, int OrderID)
    {

    }

}