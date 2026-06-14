# Event Management System (C# Windows Forms)

A premium, modern desktop application built using **C# Windows Forms** (.NET Framework) for a 6th-semester college engineering mini-project.

## Features
- **In-Memory database:** Zero database installation or configuration required. Uses strongly-typed C# static lists (`List<T>`).
- **Sidebar-based Master Shell UI:** A modern Single-Window dashboard interface loading child forms dynamically.
- **Academic OOP Demonstration:** Concrete implementations of Inheritance, Polymorphism, Interfaces, Constructors, Collections, Generics, Event Handling, and Exception Handling.
- **Double-Duty Forms:** Form reuse through constructor overloading (e.g. registration grid used by Admin for global approval and by Student for personal tracking).

---

## Default Login Credentials

### Administrator Portal
- **Role Selection:** Admin
- **Username:** `admin`
- **Password:** `admin123`

### Student Portal
- **Role Selection:** User
- **Username:** `rahul` (or create any new user account via the Register button)
- **Password:** `rahul123`

---

## File Structure Overview
- `EventManagementSystem.csproj` - MSBuild project file.
- `App.config` - Runtime configuration.
- `Program.cs` - Entry point.
- `IManage.cs` - CRUD interface contract.
- `Person.cs` / `Participant.cs` - Base/Child classes illustrating inheritance & polymorphism.
- `User.cs` / `Admin.cs` - Authentication models.
- `Event.cs` / `Registration.cs` - Domain entity data structures.
- `Database.cs` - Central static collections container.
- `FormStyle.cs` - Reusable modern UI flat design definitions.
- `Forms` - Visual interface split into `.cs` and `.Designer.cs` code-behinds.

---

## Compilation

Compile using MSBuild:
```powershell
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe /t:Rebuild /p:Configuration=Debug EventManagementSystem.csproj
```

The compiled application executable will be output to:
`bin\Debug\EventManagementSystem.exe`
