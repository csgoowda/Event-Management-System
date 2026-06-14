# Event Management System - Viva Questions and Answers

This guide contains the top 20 questions frequently asked by external examiners during practical viva examinations for Windows Forms (.NET Framework) mini-projects, along with academic and technically precise answers.

---

### Q1: What is the main objective of this Event Management System project?
**Answer:** The objective is to design and develop a multi-role desktop application using C# Windows Forms and Object-Oriented Programming (OOP) principles. It manages events, participants, and student registrations. To keep it lightweight and suitable for academic demonstration, it runs fully in-memory using C# collections (`List<T>`), eliminating database installation bottlenecks.

### Q2: How does the application maintain data state across multiple forms without a database?
**Answer:** State is maintained using **static collections** within the static `Database` class. C# static properties and lists persist in-memory for the entire lifecycle of the application's process execution. When any child form modifies `Database.Events` or `Database.Registrations`, those changes are instantly visible globally.

### Q3: Explain how Inheritance is demonstrated in your source code.
**Answer:** We created a base class `Person` with a property `Name`. The child class `Participant` inherits from `Person` using the inheritance colon syntax:
```csharp
public class Participant : Person { ... }
```
It inherits `Name` and uses constructor chaining via the `base` keyword to initialize the inherited property:
```csharp
public Participant(int id, string name, string phone) : base(name) { ... }
```

### Q4: What is Polymorphism, and where have you implemented it?
**Answer:** Polymorphism allows us to treat derived objects as their base type while executing their specialized behavior at runtime.
- We defined a `public virtual string DisplayInfo()` method in the `Person` base class.
- We overrode this method in the `Participant` class using `public override string DisplayInfo()`.
- During viva, we can call `DisplayInfo()` on a list of `Person` objects containing participants, and C# will dynamically invoke the overridden method.

### Q5: What is the purpose of the `IManage` interface, and how is it used?
**Answer:** An interface defines a structural contract without implementation. Our `IManage` interface declares three operations: `Add()`, `Delete()`, and `Display()`.
We implemented this interface in `EventManagementForm` and `ParticipantManagementForm`. This enforces consistent CRUD (Create, Read, Delete) and rendering signatures across different management controls.

### Q6: How have you used Generics in your project?
**Answer:** We implemented a generic search helper method `FindItems<T>` in the static `Database` class:
```csharp
public static List<T> FindItems<T>(List<T> source, Predicate<T> match)
```
This method filters any list of type `T` using a criteria predicate. For instance, in `RegistrationManagementForm`, it filters the global list to fetch registrations for a specific username:
```csharp
List<Registration> filtered = Database.FindItems(Database.Registrations, r => r.Username == userFilter);
```

### Q7: What collection class did you choose, and why?
**Answer:** We used `System.Collections.Generic.List<T>`. It is a strongly typed, dynamically resizing array that provides efficient methods for addition (`Add`), removal (`Remove`, `RemoveAll`), and searching (`Find`, `Exists`). It is safer than non-generic arrays and ArrayLists because it prevents type casting overhead and runtime exceptions.

### Q8: What are Windows Forms, and how are they structured in C#?
**Answer:** Windows Forms is a graphical class library in .NET for building desktop apps. Each form is structured as a **partial class** split into two files:
- `FormName.Designer.cs`: Auto-generated or programmatically constructed layout instructions (`InitializeComponent()`) handling size, color, anchors, and event-wireup.
- `FormName.cs`: Code-behind file housing control event handlers (e.g., button clicks) and business logic.

### Q9: How does the application handle form transition and dashboard navigation?
**Answer:** Instead of loading multiple pop-up windows, the application uses a **Single-Window Sidebar Layout**.
We created a main container panel (`panelContent`) in the dashboard. Clicking navigation buttons closes the active child form, sets the new form's `TopLevel = false`, sets `Dock = DockStyle.Fill`, adds it to `panelContent.Controls`, and calls `Show()`.

### Q10: How did you implement real-time DataGridView binding?
**Answer:** DataGridView cells are bound by assigning the static List reference to the grid's `DataSource` property. To force a visual refresh when items are added or deleted, we reset the source:
```csharp
dgvEvents.DataSource = null;
dgvEvents.DataSource = Database.Events;
```

### Q11: Explain how Exception Handling is set up in your system.
**Answer:** We wrapped critical user operations in `try-catch` blocks. If input checks fail, we throw specific exceptions (e.g., `ArgumentException`, `InvalidOperationException`). The catch block captures the exception and displays the message to the user safely:
```csharp
catch (Exception ex)
{
    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
```

### Q12: What is constructor overloading or chaining, and where is it used?
**Answer:** It is the definition of multiple constructors with different parameter signatures.
In `RegistrationManagementForm`, we overloaded the constructor:
- Default constructor `RegistrationManagementForm()` is used by the Admin to view all records.
- Overloaded constructor `RegistrationManagementForm(string usernameFilter)` is used by the Student to view only their personal registrations.

### Q13: What credentials are required to log in as an administrator?
**Answer:**
- **Username:** `admin`
- **Password:** `admin123`
These are hardcoded inside the `LoginForm`'s authentication branch.

### Q14: How are student registrations approved or rejected?
**Answer:** Admin registers participants and has access to `RegistrationManagementForm`. Clicking a row in the DataGridView extracts the registration ID. Clicking "Approve" or "Reject" updates the `Status` property of the `Registration` object in the global list to "Approved" or "Rejected", which instantly updates the grid display.

### Q15: How does a user register for an event, and what validation occurs?
**Answer:** The user logs in, goes to "Explore & Register", selects an event from the catalog, and clicks "Register". The program validates:
1. An event is selected.
2. The user has not already registered for this event (prevents duplicate submission using `Database.Registrations.Exists(...)`).
The registration is saved with a default status of `Pending`.

### Q16: How do the reports show real-time stats?
**Answer:** The `ReportsForm` contains four styled cards. On the form's `Load` event, it queries the sizes of the four static lists:
- `Database.Users.Count`
- `Database.Events.Count`
- `Database.Participants.Count`
- `Database.Registrations.Count`
It prints these integer counts directly onto the card labels, reflecting the latest state.

### Q17: What does `InitializeComponent()` do?
**Answer:** It is a method inside the `Designer.cs` file that instantiates all visual controls (TextBoxes, Labels, Buttons, grids), configures their locations, sizes, colors, fonts, tab indexes, and attaches event handler delegates (like click events) to their corresponding code-behind methods.

### Q18: What is the difference between a class and an object?
**Answer:**
- A **Class** is a blueprint or template that defines properties and methods (e.g., `Event` or `Participant`).
- An **Object** is an instance of a class loaded into memory with real values (e.g., `newEvent` with ID `101` and name `"Hackathon"`).

### Q19: What is Encapsulation, and how is it demonstrated?
**Answer:** Encapsulation is the bundling of data and methods into a single class unit, restricting direct access using access modifiers (like `public` or `private`).
Our classes use automatic properties with get/set accessors:
```csharp
public string EventName { get; set; }
```
This protects internal fields and controls read/write access.

### Q20: Why did you target .NET Framework v4.7.2?
**Answer:** .NET Framework is pre-installed on almost all Windows PCs. Targeting v4.7.2 ensures maximum compatibility, allowing the project executable to compile and run out of the box in Visual Studio on any standard laboratory machine without downloading newer .NET Core SDKs.
