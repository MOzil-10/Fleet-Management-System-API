﻿# Fleet Management API

This is a Fleet Management API that allows you to manage vehicles and their locations. It allows adding vehicles, adding and updating their locations, and retrieving the latest vehicle location or location history.

## Prerequisites

To run this application, you'll need the following:

1. **SQL Server Management Studio (SSMS)**
   - Download and install [SQL Server Management Studio (SSMS)](https://aka.ms/ssmsfullsetup) version 20 or later.
   - Ensure you have access to a running SQL Server instance for database operations.

2. **SQL Server Connection String**
   - Update the connection string in the `appsettings.json` file to point to your SQL Server instance.
   - Example of connection string format:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=your_server;Database=FleetManagementDb;User Id=your_username;Password=your_password;"
     }
     ```

3. **Create Database and Tables**
   - To create the database and necessary tables, you need to create a migration using **Entity Framework**.
   - Follow these steps to create the database:
     1. Open the **Package Manager Console** in Visual Studio.
     2. Run the following command to add a migration:
        ```
        Add-Migration InitialCreate
        ```
     3. Apply the migration and create the database:
        ```
        Update-Database
        ```
     This will create the database and tables defined in your application.

## Running the Application

1. Clone the repository or download the project files.
2. Open the project in Visual Studio.
3. Ensure the correct version of **.NET SDK** is installed on your system. You can download it from the official [Microsoft website](https://dotnet.microsoft.com/download).
4. Run the application using the **IIS Express** option or directly from the terminal using the following command:


## API Endpoints

1. **POST /api/vehicles**  
Adds a new vehicle to the system.
- **Request body**: `VehicleDto` (Make, Model, Year)
- **Response**: `200 OK` with a success message.

2. **POST /api/vehicles/location**  
Adds a new location for a vehicle.
- **Request body**: `VehicleLocationDto` (VehicleId, Latitude, Longitude, Timestamp)
- **Response**: `200 OK` with a success message.

3. **GET /api/vehicles/{vehicleId}/location**  
Retrieves the latest location of a vehicle.
- **Response**: `200 OK` with location data or `404 Not Found` if the vehicle is not found.

4. **PUT /api/vehicles/{vehicleId}/location**  
Updates the location of a vehicle.
- **Request body**: `VehicleLocationDto` (Latitude, Longitude, Timestamp)
- **Response**: `200 OK` or `404 Not Found` if the vehicle is not found.

5. **GET /api/vehicles/{vehicleId}/location/history**  
Retrieves the location history of a vehicle.
- **Response**: `200 OK` with a list of vehicle location history or `404 Not Found` if no history is found.

## Notes

- Ensure your SQL Server is running and that the connection string is correctly configured in `appsettings.json`.
- If you encounter any issues, check the logs for detailed error messages.
- This project uses **Entity Framework** for database operations, which handles migrations and updates to the database schema.

## Have a good day 
