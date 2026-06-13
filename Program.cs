using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Hotel hotel = new Hotel("Luxury Palace");

            Console.WriteLine("=================================");
            Console.WriteLine("     HOTEL MANAGEMENT SYSTEM");
            Console.WriteLine("=================================");

            // ==========================
            // ROOM INPUT
            // ==========================
            Console.Write("\nEnter Room Number: ");
            int roomNo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n===== ROOM CATEGORIES =====");
            Console.WriteLine("1. Standard Room      - Rs. 3,000");
            Console.WriteLine("2. Deluxe Room        - Rs. 5,000");
            Console.WriteLine("3. Executive Room     - Rs. 7,000");
            Console.WriteLine("4. Luxury Suite       - Rs. 10,000");
            Console.WriteLine("5. Presidential Suite - Rs. 20,000");

            Console.Write("\nSelect Room Category (1-5): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            string roomType = "";
            double roomPrice = 0;

            switch (choice)
            {
                case 1:
                    roomType = "Standard Room";
                    roomPrice = 3000;
                    break;

                case 2:
                    roomType = "Deluxe Room";
                    roomPrice = 5000;
                    break;

                case 3:
                    roomType = "Executive Room";
                    roomPrice = 7000;
                    break;

                case 4:
                    roomType = "Luxury Suite";
                    roomPrice = 10000;
                    break;

                case 5:
                    roomType = "Presidential Suite";
                    roomPrice = 20000;
                    break;

                default:
                    throw new Exception("Invalid Room Category!");
            }

            Room room = new Room(roomNo, roomType, roomPrice);
            hotel.AddRoom(room);

            // ==========================
            // CUSTOMER INPUT
            // ==========================
            Console.Write("\nEnter Customer ID: ");
            int customerId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Customer Name: ");
            string customerName = Console.ReadLine()!;

            Console.Write("Enter Customer Age: ");
            int customerAge = Convert.ToInt32(Console.ReadLine());

            Customer customer =
                new Customer(customerId,
                             customerName,
                             customerAge);

            // ==========================
            // MANAGER INPUT
            // ==========================
            Console.Write("\nEnter Manager Name: ");
            string managerName = Console.ReadLine()!;

            Console.Write("Enter Manager Age: ");
            int managerAge = Convert.ToInt32(Console.ReadLine());

            Manager manager =
                new Manager(managerName, managerAge);

            hotel.AddEmployee(manager);

            // ==========================
            // RECEPTIONIST INPUT
            // ==========================
            Console.Write("\nEnter Receptionist Name: ");
            string receptionistName = Console.ReadLine()!;

            Console.Write("Enter Receptionist Age: ");
            int receptionistAge =
                Convert.ToInt32(Console.ReadLine());

            Receptionist receptionist =
                new Receptionist(receptionistName,
                                 receptionistAge);

            hotel.AddEmployee(receptionist);

            // ==========================
            // BOOKING
            // ==========================
            Booking booking =
                new Booking(customer, room);

            Console.Write("\nEnter Number of Days: ");
            int days = Convert.ToInt32(Console.ReadLine());

            booking.BookRoom(days);

            // ==========================
            // BILL CALCULATION
            // ==========================
            double totalBill =
                booking.CalculateBill(days);

            Console.WriteLine("\nCalculated Bill: Rs. "
                              + totalBill);

            // ==========================
            // PAYMENT
            // ==========================
            Console.Write("\nEnter Payment Amount: ");
            double payment =
                Convert.ToDouble(Console.ReadLine());

            customer.MakePayment(payment, totalBill);

            // ==========================
            // DISPLAY DETAILS
            // ==========================
            customer.DisplayInfo();

            hotel.ShowRooms();

            hotel.ShowEmployees();

            // ==========================
            // STATIC MEMBERS
            // ==========================
            Console.WriteLine("\n===== SYSTEM DETAILS =====");

            Console.WriteLine("Total Customers: "
                              + Customer.TotalCustomers);

            Console.WriteLine("Total Rooms: "
                              + Hotel.TotalRooms);
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nError: "
                              + ex.Message);
        }
        Console.ReadKey();
    }
}