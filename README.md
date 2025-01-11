# Expense Tracker Application

This project is an ASP.NET Core application that includes the following features:

- **User Login/Logout System**
- **CRUD Operations for Expenses**
- **Data Visualization of Monthly Spending**

---

## **Features Implemented**

### **1. Login/Logout System**

- Users can register, log in, and log out securely.
- The application uses ASP.NET Core Identity for user authentication.
- Registered users can manage their own expenses.

#### **Endpoints**

- `/Account/Register`: User registration.
- `/Account/Login`: User login.
- `/Account/Logout`: User logout.

---

### **2. CRUD Operations for Expenses**

- Allows users to add, edit, view, and delete expenses.
- Each expense includes the following details:
  - **Category**
  - **Amount**
  - **Date**
  - **Description**

#### **Endpoints**

- `/Expense/Index`: View all expenses.
- `/Expense/Create`: Add a new expense.
- `/Expense/Edit/{id}`: Edit an existing expense.
- `/Expense/Delete/{id}`: Delete an expense.

---

### **3. Monthly Spending Visualization**

- Visualizes monthly spending data using Chart.js.
- Displays a bar chart showing total spending per month.
- Data is dynamically retrieved from the database and grouped by month.

#### **Endpoint**

- `/Expense/MonthlySpending`: View the monthly spending chart.

---

## **Installation**

### **Prerequisites**

- .NET 6.0 SDK or later
- PostgreSQL (or another compatible database)
- A web browser

### **Steps to Run the Application**

1. Clone the repository:
   ```bash
   git clone [https://github.com/AvaniVaidya/Expense-Tracker-DOT-NET.git]
   cd <project_directory>
   ```
2. Configure the database connection:
   - Update the connection string in `appsettings.json`:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=ExpenseTracker;Username=<username>;Password=<password>"
     }
     ```
3. Apply database migrations:
   ```bash
   dotnet ef database update
   ```
4. Run the application:
   ```bash
   dotnet run
   ```
5. Open the application in your browser:
   - Navigate to `http://localhost:5000` (or the specified port).

---

## **Project Structure**

### **Controllers**

- **AccountController**: Handles user registration, login, and logout.
- **ExpenseController**: Manages CRUD operations and the monthly spending graph.

### **Views**

- **Account**:
  - `Register.cshtml`: User registration form.
  - `Login.cshtml`: User login form.
- **Expense**:
  - `Index.cshtml`: View all expenses.
  - `Create.cshtml`: Add a new expense.
  - `Edit.cshtml`: Edit an existing expense.
  - `MonthlySpending.cshtml`: Displays the monthly spending chart.

### **Models**

- **Expense**: Represents an expense with properties like `Category`, `Amount`, `Date`, and `Description`.

---

## **Technologies Used**

- **ASP.NET Core 6.0**: For web application development.
- **Entity Framework Core**: For database interaction.
- **Chart.js**: For data visualization.
- **Bootstrap**: For styling and responsiveness.
- **PostgreSQL**: Database backend.

---

## **Future Enhancements**

- Role-based access control (e.g., admin and user roles).
- Enhanced data visualization (e.g., pie charts for category spending).
- Exporting data to CSV or PDF.
- Mobile-friendly UI enhancements.

---

## **Troubleshooting**

- **Database Issues**: Ensure the database server is running and the connection string is correctly configured.
- **Migration Errors**: Delete existing migrations and recreate them:
  ```bash
  dotnet ef migrations remove
  dotnet ef migrations add InitialCreate
  ```
- **Chart Not Displaying**: Ensure the Chart.js library is included and the data passed to the view is correct.

---

## **License**

This project is licensed under the [MIT License](LICENSE).

---

## **Contributors**

- [Your Name]
