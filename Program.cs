using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Hotel hotel = new Hotel("Luxury Palace");

            // Hardcoded management staff for simulation
            Manager manager = new Manager("Ali Rehman", 27);
            Receptionist receptionist = new Receptionist("Fatima", 25);
            hotel.AddEmployee(manager);
            hotel.AddEmployee(receptionist);

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("     HOTEL MANAGEMENT SYSTEM");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Book a Room");
                Console.WriteLine("2. View All Booked Rooms");
                Console.WriteLine("3. View Hotel Employees");
                Console.WriteLine("4. View System Statistics");
                Console.WriteLine("5. Exit");
                Console.WriteLine("=================================");
                Console.Write("Select Option (1-5): ");

                string choiceStr = Console.ReadLine()!;
                Console.WriteLine();

                switch (choiceStr)
                {
                    case "1":
                        BookRoomFlow(hotel);
                        break;

                    case "2":
                        Console.WriteLine("===== BOOKED ROOM DETAILS =====");
                        hotel.ShowRooms();
                        Pause();
                        break;

                    case "3":
                        Console.WriteLine("===== EMPLOYEE DETAILS =====");
                        hotel.ShowEmployees();
                        Pause();
                        break;

                    case "4":
                        Console.WriteLine("===== SYSTEM DETAILS =====");
                        Console.WriteLine("Total Customers Registered: " + Customer.TotalCustomers);
                        Console.WriteLine($"Total Rooms Currently Booked: {Hotel.TotalRooms} / 100");
                        Pause();
                        break;

                    case "5":
                        exit = true;
                        Console.WriteLine("Exiting System... Thank you!");
                        break;

                    default:
                        Console.WriteLine("Invalid selection! Please choose options 1 to 5.");
                        Pause();
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nUnexpected Error: " + ex.Message);
            Pause();
        }
    }

    static void BookRoomFlow(Hotel hotel)
    {
        try
        {
            // Total capacity check
            if (Hotel.TotalRooms >= 100)
            {
                Console.WriteLine("Error: Hotel is fully booked! (100/100 rooms occupied).");
                Pause();
                return;
            }

            // ==========================
            // ROOM INPUT & VALIDATION
            // ==========================
            Console.Write("Enter Room Number (1 - 100): ");
            int roomNo = Convert.ToInt32(Console.ReadLine());

            if (roomNo < 1 || roomNo > 100)
            {
                throw new Exception("Invalid Room Number! Must be between 1 and 100.");
            }

            // Check if room is already booked
            if (hotel.IsRoomAlreadyBooked(roomNo))
            {
                throw new Exception($"Room {roomNo} is already booked! Please choose another room.");
            }

            Console.WriteLine("\n===== ROOM CATEGORIES =====");
            Console.WriteLine("1. Standard Room      - Rs. 3,000");
            Console.WriteLine("2. Deluxe Room        - Rs. 5,000");
            Console.WriteLine("3. Executive Room     - Rs. 7,000");
            Console.WriteLine("4. Luxury Suite       - Rs. 10,000");
            Console.WriteLine("5. Presidential Suite - Rs. 20,000");

            Console.Write("\nSelect Room Category (1-5): ");
            int categoryChoice = Convert.ToInt32(Console.ReadLine());

            string roomType = "";
            double roomPrice = 0;

            switch (categoryChoice)
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
                    throw new Exception("Invalid Room Category choice!");
            }

            Room room = new Room(roomNo, roomType, roomPrice);

            // ==========================
            // CUSTOMER INPUT
            // ==========================
            Console.Write("\nEnter Customer Name: ");
            string customerName = Console.ReadLine()!;

            Console.Write("Enter Customer Age: ");
            int customerAge = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Customer CNIC (13 Digits): ");
            string cnic = Console.ReadLine()!;

            int customerId = Customer.GenerateCustomerID(customerAge, cnic, categoryChoice);
            Console.WriteLine("\nGenerated Customer ID: " + customerId);

            Customer customer = new Customer(customerId, customerName, customerAge, cnic);

            // ==========================
            // BOOKING & DURATION
            // ==========================
            Booking booking = new Booking(customer, room);

            Console.Write("\nEnter Number of Days to Stay: ");
            int days = Convert.ToInt32(Console.ReadLine());

            booking.BookRoom(days);
            hotel.AddRoom(room); // Commit room booking to state

            // ==========================
            // BILL CALCULATION & PAYMENT
            // ==========================
            double totalBill = booking.CalculateBill(days);
            Console.WriteLine("\nCalculated Bill: Rs. " + totalBill);

            Console.Write("Enter Payment Amount: ");
            double payment = Convert.ToDouble(Console.ReadLine());

            customer.MakePayment(payment, totalBill);

            // ==========================
            // DISPLAY SUMMARY
            // ==========================
            Console.WriteLine("\n--- BOOKING SUCCESSFUL ---");
            customer.DisplayInfo();
            Pause();
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nBooking Failed: " + ex.Message);
            Pause();
        }
    }

    static void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}