# Employee List Management System (C# Console App)

## 📌 Overview

**Application**.
It allows the user to perform basic **CRUD operations** on employees using a dynamic approach with **Reflection**.

The system supports:

* Add new employees
* Edit employee data
* Remove employees (by index, range, or value)
* Display all employees
* Manage nested Address object

This project was created as a **practice project for learning Lists, OOP, Interfaces, and Reflection in C#**.

---

## 🧠 Concepts Used

* Object Oriented Programming (OOP)
* Classes & Objects
* Interfaces
* Lists (Generic Collections)
* Reflection
* Console Input/Output
* Dynamic Property Handling
* CRUD Operations

---

## 🏗️ Project Structure

* `Employee` Class

  * FirstName
  * LastName
  * Job
  * Salary
  * Address

* `Address` Class

  * Street
  * City
  * State
  * Country

* `IJob` Interface

  * Job
  * Salary

* `Program`

  * AddEmployee()
  * EditEmployee()
  * RemoveEmployee()
  * PrintEmployee()

---

## ⚙️ Features

✔ Dynamic property editing using Reflection
✔ Remove employee by property name and value
✔ Nested object handling (Address inside Employee)
✔ Console-based menu system
✔ Multiple delete options (Index / Range / Value)
✔ Clean separation of responsibilities

---

## 🚀 How to Run

1. Open the project in **Visual Studio**
2. Build the solution
3. Run the application
4. Follow the console instructions

---

## 📚 Learning Purpose

This project is intended for:

* Practicing **C# fundamentals**
* Understanding **List operations**
* Learning **Reflection basics**
* Implementing **CRUD in Console Apps**

---

## 👩‍💻 Author

H.Ahmed
Student learning **.NET Development & Software Engineering**

---

## ⭐ Future Improvements

* Add Validation Layer
* Add LINQ optimization
* Convert to Windows Form / Web API
* Add File or Database Storage
* Improve UI/UX
