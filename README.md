# 🏨 Hotel Management System (C# Console Application)

A console-based **Hotel Management System** developed in **C#** as an Object-Oriented Programming (OOP) semester project. The application simulates the basic operations of a hotel, including room booking, customer registration, bill calculation, payment processing, and employee management while demonstrating the core concepts of Object-Oriented Programming.

---

## 📌 Project Overview

The Hotel Management System is designed to simplify hotel room booking and customer management. It allows users to:

- Register customers
- Select room categories
- Book rooms for multiple days
- Calculate total bills
- Process payments
- Return change (if payment exceeds the bill)
- Manage hotel employees

The project focuses on implementing major **OOP concepts** in C# rather than creating a graphical user interface.

---

## ✨ Features

- 🛏️ Multiple room categories with predefined prices
- 👤 Customer registration
- 🆔 Automatic Customer ID generation
- 🪪 CNIC validation
- 📅 Room booking for multiple days
- 💰 Automatic bill calculation
- 💵 Payment processing with change calculation
- 👨‍💼 Predefined Manager and Receptionist details
- 📋 Display customer, room, and employee information
- ⚠️ Input validation and exception handling

---

## 🛏️ Room Categories

| Category | Price Per Day |
|----------|---------------:|
| Standard Room | Rs. 3,000 |
| Deluxe Room | Rs. 5,000 |
| Executive Room | Rs. 7,000 |
| Luxury Suite | Rs. 10,000 |
| Presidential Suite | Rs. 20,000 |

---

## 🏗️ OOP Concepts Implemented

This project demonstrates the following Object-Oriented Programming concepts:

- ✅ Classes & Objects
- ✅ Encapsulation
- ✅ Inheritance
- ✅ Polymorphism
- ✅ Abstraction
- ✅ Constructors
- ✅ Properties
- ✅ Method Overriding
- ✅ Method Overloading
- ✅ Static Members
- ✅ Interfaces
- ✅ Abstract Classes
- ✅ Collections
- ✅ Exception Handling
- ✅ Association
- ✅ Aggregation
- ✅ Composition

---

## 📂 Project Structure

```
HotelManagement/
│
├── Program.cs          # Main execution file
├── Person.cs           # All classes
│
├── Person
├── Customer
├── Employee
├── Manager
├── Receptionist
├── Room
├── Booking
├── Hotel
│
└── README.md
```

---

## 🧩 Class Relationships

- **Person** → Abstract Base Class
- **Customer** → Inherits Person
- **Employee** → Inherits Person
- **Manager** → Inherits Employee
- **Receptionist** → Inherits Employee
- **Customer** → Implements `IPayment`
- **Booking** → Association between Customer and Room
- **Hotel** → Composition with Rooms
- **Hotel** → Aggregation with Employees

---

## 🛠️ Technologies Used

- Language: **C#**
- Framework: **.NET**
- IDE: **Microsoft Visual Studio**
- Application Type: **Console Application**

---

## 🚀 How to Run

1. Clone the repository

```bash
git clone https://github.com/your-username/HotelManagement.git
```

2. Open the project in **Visual Studio**.

3. Build the solution.

4. Run the project using:

```
Ctrl + F5
```

or

```
F5
```

---

## 📸 Sample Workflow

1. Enter Room Number
2. Select Room Category
3. Enter Customer Details
4. Customer ID is generated automatically
5. Enter Number of Days
6. Bill is calculated
7. Enter Payment
8. System returns remaining balance (if applicable)
9. Display Customer, Room, and Employee Details

---

## 📖 Learning Outcomes

Through this project, we gained practical experience with:

- Object-Oriented Programming
- Class Design
- Inheritance Hierarchies
- Interfaces and Abstract Classes
- Collections
- Exception Handling
- UML Class Diagrams
- Console-Based Application Development

---

## 👨‍💻 Team Members

| Name | Registration No. | Responsibilities |
|------|------------------|------------------|
| **Muhammad Huzaifa Siddiqui** *(Team Lead)* | **CS251331** | UML Diagrams, Abstract Class, Interface, Customer Class, Employee Class |
| **Syed Ammar Ali Shah** | **CS251324** | Manager, Receptionist, Room, Booking, Hotel Classes |
| **Ayan Akhtar** | **CS251009** | Main Program (`Program.cs`), Console Workflow |

---

## 📚 Future Improvements

- Database Integration (SQL Server/MySQL)
- Login System
- Room Availability Tracking
- Booking Cancellation
- Check-In / Check-Out Module
- Receipt Generation
- GUI using Windows Forms or WPF
- Online Reservation System

---

## 🤝 Contributing

This project was developed for academic purposes. Suggestions and improvements are always welcome.

---

## 📄 License

This project is intended for **educational and learning purposes only**.

---

⭐ If you found this project helpful, consider giving it a **star** on GitHub!
