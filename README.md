# Project Overview
MakeMeUpzz is a web-based application designed for selling makeup and skincare products. This project is part of a course assignment to build a simplified version of the application using ASP.NET and Domain Driven Design principles.

# Project Structure
The project consists of several layers to ensure a clean separation of concerns and maintainable code:
- View Layer: Responsible for displaying information to users and interpreting their commands.
- Controller Layer: Validates input from the view layer and delegates requests for further processing.
- Handler Layer: Handles business logic and interacts with the repository layer for database operations.
- Repository Layer: Provides access to the database and models, encapsulating data manipulation.
- Factory Layer: Manages the creation of complex objects, ensuring consistent state.
- Model Layer: Represents business concepts and handles data using the Entity Framework tool.

# User Roles and Permissions
There are three types of users in the application:
- Admin: Can manage products, view and handle orders, and manage customer data.
- Customer: Can browse products, place orders, view order history, and manage their profile.
- Guest: Can register and log in to the application.

# Features and Pages
**General Features**
- Navigation Bar: Provides easy navigation for logged-in users based on their role.
  
**Admin Features**
- Manage Makeup: View, insert, update, and delete makeup products, types, and brands.
- Handle Transactions: View and manage ongoing transactions.
- View Transaction Reports: Generate and view sales reports using Crystal Reports.
  
**Customer Features**
- Order Makeup: Browse and order makeup products.
- View Transactions History: View past orders and transaction details.
- Profile Management: Update profile information and change password.
  
**Guest Features**
- Login: Access the application by logging in with valid credentials.
- Register: Create a new customer account.
