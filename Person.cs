using System;
using System.Collections.Generic;

// ==========================
// ABSTRACT CLASS
// ==========================
abstract class Person
{
    private string name = "";
    private int age;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value > 0)
                age = value;
            else
                throw new Exception("Age must be greater than 0.");
        }
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public abstract void DisplayInfo();
}

// ==========================
// INTERFACE
// ==========================
interface IPayment
{
    void MakePayment(double amount, double bill);
}

// ==========================
// CUSTOMER
// ==========================
class Customer : Person, IPayment
{
    private int customerID;

    public int CustomerID
    {
        get { return customerID; }
        set { customerID = value; }
    }

    public static int TotalCustomers = 0;

    public Customer(int id, string name, int age)
        : base(name, age)
    {
        CustomerID = id;
        TotalCustomers++;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("\n===== CUSTOMER DETAILS =====");
        Console.WriteLine("Customer ID: " + CustomerID);
        Console.WriteLine("Customer Name: " + Name);
        Console.WriteLine("Customer Age: " + Age);
    }

    public void MakePayment(double amount, double bill)
    {
        Console.WriteLine("\n===== PAYMENT DETAILS =====");

        if (amount < bill)
        {
            Console.WriteLine("Insufficient Payment!");
            Console.WriteLine("Remaining Amount: Rs. " + (bill - amount));
        }
        else if (amount == bill)
        {
            Console.WriteLine("Payment Received Successfully.");
            Console.WriteLine("No Change To Return.");
        }
        else
        {
            double change = amount - bill;

            Console.WriteLine("Payment Received Successfully.");
            Console.WriteLine("Total Bill: Rs. " + bill);
            Console.WriteLine("Amount Paid: Rs. " + amount);
            Console.WriteLine("Change Returned By Receptionist: Rs. " + change);
        }
    }
}

// ==========================
// EMPLOYEE
// ==========================
class Employee : Person
{
    private string role = "";

    public string Role
    {
        get { return role; }
        set { role = value; }
    }

    public Employee(string name, int age, string role)
        : base(name, age)
    {
        Role = role;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("\nEmployee Name: " + Name);
        Console.WriteLine("Role: " + Role);
    }
}

// ==========================
// MANAGER
// ==========================
class Manager : Employee
{
    public Manager(string name, int age)
        : base(name, age, "Manager")
    {
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("\nManager Name: " + Name);
    }
}

// ==========================
// RECEPTIONIST
// ==========================
class Receptionist : Employee
{
    public Receptionist(string name, int age)
        : base(name, age, "Receptionist")
    {
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("\nReceptionist Name: " + Name);
    }
}

// ==========================
// ROOM
// ==========================
class Room
{
    private int roomNumber;
    private string roomType = "";
    private double price;

    public int RoomNumber
    {
        get { return roomNumber; }
        set { roomNumber = value; }
    }

    public string RoomType
    {
        get { return roomType; }
        set { roomType = value; }
    }

    public double Price
    {
        get { return price; }
        set { price = value; }
    }

    public Room(int number, string type, double price)
    {
        RoomNumber = number;
        RoomType = type;
        Price = price;
    }

    public void ShowRoom()
    {
        Console.WriteLine("\nRoom Number: " + RoomNumber);
        Console.WriteLine("Room Type: " + RoomType);
        Console.WriteLine("Price Per Day: Rs. " + Price);
    }
}

// ==========================
// BOOKING (Association)
// ==========================
class Booking
{
    public Customer Customer { get; set; }
    public Room Room { get; set; }

    public Booking(Customer customer, Room room)
    {
        Customer = customer;
        Room = room;
    }

    // Method Overloading
    public void BookRoom()
    {
        Console.WriteLine(Customer.Name +
                          " booked Room " +
                          Room.RoomNumber);
    }

    public void BookRoom(int days)
    {
        double bill = Room.Price * days;

        Console.WriteLine("\n===== BOOKING DETAILS =====");
        Console.WriteLine(Customer.Name +
                          " booked " +
                          Room.RoomType);

        Console.WriteLine("Days: " + days);
        Console.WriteLine("Total Bill: Rs. " + bill);
    }

    public double CalculateBill(int days)
    {
        return Room.Price * days;
    }
}

// ==========================
// HOTEL
// ==========================
class Hotel
{
    private string hotelName = "";

    public string HotelName
    {
        get { return hotelName; }
        set { hotelName = value; }
    }

    // Collections
    private List<Room> rooms = new List<Room>();
    private List<Employee> employees = new List<Employee>();

    // Static Member
    public static int TotalRooms = 0;

    public Hotel(string name)
    {
        HotelName = name;
    }

    // Composition
    public void AddRoom(Room room)
    {
        rooms.Add(room);
        TotalRooms++;
    }

    // Aggregation
    public void AddEmployee(Employee emp)
    {
        employees.Add(emp);
    }

    public void ShowRooms()
    {
        Console.WriteLine("\n===== ROOM DETAILS =====");

        foreach (Room room in rooms)
        {
            room.ShowRoom();
        }
    }

    public void ShowEmployees()
    {
        Console.WriteLine("\n===== EMPLOYEE DETAILS =====");

        foreach (Employee emp in employees)
        {
            emp.DisplayInfo();
        }
    }
}