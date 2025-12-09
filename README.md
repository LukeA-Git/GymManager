# GymManager – Final Project (Milestone 6)

## 1. Project Overview

GymManager is a console-based application developed in C# that supports the daily operations of a gym. The system allows users to load equipment, member, and user data from text files and interact with the application through a role-based menu interface. Different user roles (Admin, Owner, Employee) are provided with unique menu functionality through dynamic menu strategies.

This project demonstrates core object-oriented programming principles including inheritance, interfaces, polymorphism, encapsulation, data structures, and file I/O. It also implements multiple industry-standard design patterns.

### Core Features
- Role-based menu system (Admin, Owner, Employee)
- Equipment, member, and user repositories
- CSV-based file input using adapter pattern
- Dynamic menu switching using strategy pattern
- Console-based user interface

### Assumptions & Constraints
- Input data must be stored in comma-separated `.txt` files
- The program runs strictly as a console application
- Only one user session is supported at a time

---

## 2. Build & Run Instructions

### Tools Used
- Language: C#
- Framework: .NET 9.0
- IDE: JetBrains Rider or Microsoft Visual Studio

### How to Run
1. Open the project in Rider or Visual Studio.
2. Click **Run** (or **Start**) in the IDE.
3. The program will launch in the console.

### Input Test Files
When the program runs, it will prompt for file paths for:
- Equipment data file  
- Member data file  
- User data file  

All test files are located in the `/docs` folder.  
Copy and paste the absolute file paths into the console when prompted.

---

## 3. Required OOP Features (With File & Line References)

| OOP Feature | File Name | Line Numbers | Reasoning / Purpose |
|------------|-----------|--------------|----------------------|
| Inheritance | GymUser.cs | 7-25 | Base class defining shared properties across all users |
| Inheritance | AdminUser.cs, OwnerUser.cs, EmployeeUser.cs | All | Specialized user types inherit from GymUser |
| Interface | IMenuStrategy.cs | All | Defines common behavior for all menus |
| Interface | IRepository.cs | 10-18 | Enforces consistent data access across repositories |
| Interface | IFileAdapter.cs | All | Standardizes file read/write operations |
| Polymorphism | MenuFactory.cs | 7-14 | Returns different menu strategies at runtime based on user |
| Polymorphism | HandleChoice() in all MenuStrategy classes | All | Same method signature produces different runtime behavior |
| Access Modifiers | Entire project | All | Private fields enforce encapsulation; public methods allow controlled access |
| Struct | Schedule.cs | 5-23 | Represents maintenance scheduling as a value type |
| Enum | EQType.cs | All | Defines valid equipment categories |
| Data Structure | EquipmentRepository.cs | 10-57 | Stores equipment using List<Equipment> |
| Console I/O | Program.cs | All | Handles all console input and output |

---

## 4. Design Patterns (With File & Line References)

| Pattern Name | Category | File Name | Line Numbers | Rationale |
|-------------|----------|------------|--------------|-----------|
| Strategy | Behavioral | AdminMenuStrategy.cs, OwnerMenuStrategy.cs, EmployeeMenuStrategy.cs | All | The Strategy Pattern is used to allow different menu behaviors to be selected at runtime based on the logged-in user’s role. Each role has its own menu implementation that follows the same interface, which eliminates large conditional statements and keeps the system flexible and easy to extend. |
| Repository | Structural | EquipmentRepository.cs, MemberRepository.cs, UserRepository.cs | All | The Repository Pattern is used to separate data storage logic from the rest of the application’s business logic. This allows the system to manage equipment, members, and users in a clean, organized way while making future data source changes easier. |
| Adapter | Structural | FileAdapter.cs | All | The Adapter Pattern allows the application to read CSV text files and convert them into internal objects without tightly coupling file input logic to the rest of the system. This makes it easier to change file formats in the future without modifying core application logic. |


---

## 5. Design Decisions

The Strategy pattern was chosen to eliminate large conditional blocks when switching between user roles and to provide clean separation between menu behaviors. The Repository pattern isolates data storage from business logic and improves system organization. The Adapter pattern keeps file parsing logic independent from the core application logic and simplifies maintenance. The Schedule struct was implemented as a value type for date handling efficiency. Enums restrict equipment types to valid predefined values. A console-based interface was chosen to maintain simplicity and focus on object-oriented design principles.

---

## 6. UML Diagram

The final UML diagram is located in the `/uml` folder.

The diagram includes:
- Domain models
- Repository structure
- Strategy pattern relationships
- Adapter pattern structure

The UML diagram accurately reflects the final implementation.

---

## 7. Individual Reflection

Each team member has completed the required **Individual Reflection & OPP Showcase Google Form**.

