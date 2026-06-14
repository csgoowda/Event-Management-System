# Event Management System - Academic Mini Project Report

**A Desktop Application built using C# Windows Forms and Object-Oriented Programming**

---

## 1. Introduction

### 1.1 Project Overview
The **Event Management System** is a lightweight, responsive desktop application developed using **C# Windows Forms** (.NET Framework). It provides a complete administrative and user portal to manage campus events, student participants, and registration schedules.

Designed specifically as a 6th-semester computer science and engineering mini-project, the application does not rely on external SQL databases, network APIs, or cloud services. Instead, it utilizes **in-memory data models** stored in strongly-typed collections (`List<T>`). This makes it extremely fast, portable, and easy to deploy on any system running Visual Studio without complex database setup configurations.

### 1.2 Target Audience and Roles
The system accommodates two distinct user roles, implementing role-based access control:
1. **Administrator (Admin):** Has full read, write, update, and delete access. The admin manages scheduled events, participant registers, approves or rejects registrations, views system-wide statistics, and manages user accounts.
2. **Student User (User):** Register accounts, browse/search event details, register for events, view personal registration status updates, and update profile passwords.

---

## 2. System Architecture & OOP Design

This project serves as a practical implementation of fundamental and advanced Object-Oriented Programming concepts under the .NET Framework:

| OOP Concept | Project Implementation Details | Source Reference |
| :--- | :--- | :--- |
| **Classes & Objects** | Defined standalone blueprints for system entities: `User`, `Event`, `Registration`, and `Person`. | `User.cs`, `Event.cs`, `Registration.cs` |
| **Inheritance** | Base class `Person` encapsulates common attributes like `Name`. Derived class `Participant` extends `Person` with extra properties. `Admin` inherits from `User`. | `Person.cs` & `Participant.cs` |
| **Interfaces** | The `IManage` interface defines contracts `Add()`, `Delete()`, and `Display()`. | `IManage.cs` |
| **Polymorphism** | `Person` defines a virtual `DisplayInfo()` method, which is overridden in `Participant`. Also, form constructor overloading implements static polymorphism. | `Person.cs`, `Participant.cs` |
| **Encapsulation** | Private fields and auto-implemented public properties protect state data. | All models |
| **Generics** | A static generic query method `FindItems<T>` in `Database` dynamically filters collections. | `Database.cs` |
| **Collections** | Strong typed generic Lists (`List<T>`) store active records dynamically. | `Database.cs` |
| **Exception Handling**| Structured `try-catch-finally` blocks isolate data parsing and UI failures. | All Forms |

---

## 3. System Requirements

### 3.1 Functional Requirements
- **FR1: Authentication Portal** - Login with role selection (Admin/User). Input validation on blank textboxes.
- **FR2: Student Registration** - Create a new user account with duplicate username checks and password matching validation.
- **FR3: Event Management (Admin)** - Create, read, update, and delete events. Display schedule in a DataGridView.
- **FR4: Participant Management (Admin)** - Add, edit, list, and delete participant directories.
- **FR5: Registration Approval (Admin)** - View all student event registrations and click buttons to Approve or Reject them.
- **FR6: Event Enrollment (User)** - Browse events, search by title/location, and submit registration.
- **FR7: Track Registrations (User)** - View personal registration status (Pending/Approved/Rejected).
- **FR8: Profile Management (User)** - View username details and update account password.
- **FR9: System Analytics Panel** - Display counts of all records in real-time.

### 3.2 Non-Functional Requirements
- **NFR1: Portability** - Zero database configuration. Can be built and run on any machine with MSBuild/.NET Framework.
- **NFR2: Performance** - In-memory access compiles and queries data under 10 milliseconds.
- **NFR3: Aesthetics** - A modern flat UI, custom colors (slate navy & emerald accent), consistent fonts, padded elements, and hover micro-animations.

---

## 4. Database Schema (In-Memory Structures)

The in-memory database is defined in `Database.cs`. It initializes sample rows for demonstration on startup:

```csharp
// Users Table
public static List<User> Users;
// Events Table
public static List<Event> Events;
// Participants Table
public static List<Participant> Participants;
// Registrations Table
public static List<Registration> Registrations;
```

### Initial Data Models:
1. **User:** `Username` (string), `Password` (string).
2. **Person:** `Name` (string).
3. **Participant : Person:** `ParticipantId` (int), `PhoneNumber` (string).
4. **Event:** `EventId` (int), `EventName` (string), `EventDate` (DateTime), `Venue` (string).
5. **Registration:** `RegistrationId` (int), `Username` (string), `EventName` (string), `Status` (string: "Pending", "Approved", "Rejected").

---

## 5. UI Design & Navigation Layout

The application utilizes a master-detail shell design to load forms dynamically:

```
[Main Application Executable]
  │
  ├─> LoginForm (Auth Gate)
  │     └─> UserRegistrationForm (Modal Popup Dialog)
  │
  ├─> AdminDashboardForm (Sidebar Shell Layout)
  │     ├─> ReportsForm (Default View)
  │     ├─> EventManagementForm (Dynamic Inner Load)
  │     ├─> ParticipantManagementForm (Dynamic Inner Load)
  │     ├─> RegistrationManagementForm (Dynamic Inner Load)
  │     └─> UserManagementForm (Dynamic Inner Load)
  │
  └─> UserDashboardForm (Sidebar Shell Layout)
        ├─> UserEventRegistrationForm (Default View)
        ├─> RegistrationManagementForm (Inner Load - User Filtered)
        └─> UserProfileForm (Dynamic Inner Load)
```

---

## 6. How to Build and Run the Application

The project is structured with a standard Visual Studio compilation format:

### 6.1 Using Microsoft Visual Studio:
1. Open Visual Studio.
2. Select **File > Open > Project/Solution** and select the `EventManagementSystem.csproj` file.
3. Verify that the project configuration is set to **Debug / AnyCPU**.
4. Press **F5** or click the **Start** button to compile and execute the application.

### 6.2 Using Command Line Compiler (MSBuild):
If compiling via command prompt:
```powershell
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe /t:Rebuild /p:Configuration=Debug EventManagementSystem.csproj
```
Run the compiled executable located at:
`bin\Debug\EventManagementSystem.exe`
