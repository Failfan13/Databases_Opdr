
class Solution
{

    public static void q1Solution(HotelContext db)
    {
        // Exercise 1: Give the booking detail of given guest booking details (for GuestID 10).  
        // The result should include booking date, room number, and number of nights. 
        var details = db.bookings.Where(b => b.GuestID == 10).Select(b => new { b.BookingDate, b.room.Number, b.Nights });


        foreach (var d in details)
        {
            Console.WriteLine($"{d.BookingDate}, {d.Number}, {d.Nights}");
        }
    }

    public static void q2Solution(HotelContext db, DateOnly date)
    {
        // Exercise: 2:  List down all the guest names, and room number, 
        // having booking on specific date (2022 - 01 - 31)
        var details = db.bookings.Where(b => b.BookingDate == date).OrderBy(b => b.guest.Id).Select(b => new { b.guest.Id, b.guest.Name, b.room.Number });

        // var details = db.bookings.Where(b => b.BookingDate == date).Select(b => new { b.guest.Id, b.guest.Name, b.room.Number });

        foreach (var d in details)
        {
            Console.WriteLine($"{d.Id}, {d.Name}, {d.Number}");
        }
    }

    public static void q3Solution(HotelContext db)
    {
        // Exercise 3: List down number of bookings in ordered date per day where there are more than 1 bookings
        var details = db.bookings.GroupBy(b => b.BookingDate).OrderBy(b => b.Key).Select(b => new { b.Key, Count = b.Count() }).Where(b => b.Count > 1);

        foreach (var d in details)
        {
            Console.WriteLine($"{d.Key}, {d.Count}");
        }
    }

    public static void q4Solution(HotelContext db, DateOnly date)
    {
        // Exercise 4. List the rooms that are free on '2022-01-13'.
        var details = db.rooms.Where(r => r.Bookings.All(b => b.BookingDate != date)).Select(r => new { r.Number, r.roomType.Type });

        foreach (var d in details)
        {
            Console.WriteLine($"{d.Number}");
        }
    }

    public static void q5Solution(HotelContext db)
    {
        // Exercise: 5:  List down top 5 valued customers, with their id and spending 
        // HINT: a valued customer is the on with max amount spent, 
        // amount = Nights * Price for each booking of a customer
        var details = db.bookings.GroupBy(b => b.GuestID).Select(b => new { b.Key, Amount = b.Sum(b => b.Nights * b.room.roomType.Price) }).OrderByDescending(b => b.Amount).Take(5);

        foreach (var d in details)
        {
            Console.WriteLine($"{d.Key}, {d.Amount}");
        }

    }

    public static void q6Solution(HotelContext db, DateOnly date)
    {
        // Exercise 6: 

    }

    //     ****  Ex7 in Model.cs  **** 

    public static void q8aSolution(HotelContext db)
    {
        // Exercise 8a: 

    }

    public static void q8bSolution(HotelContext db)
    {
        // Exercise 8b: 

    }

}