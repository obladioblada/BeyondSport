# README: Beyond Sports .NET 8 Assignment

This README provides instructions on how to run a .NET 8 project for the assignment. The project includes Swagger documentation accessible at [http://localhost:8080/swagger/index.html](http://localhost:8080/swagger/index.html) and can also be run using Docker Compose, with the   ```compose.yaml ``` file located under the root directory.

## Prerequisites

Before getting started, ensure you have the following prerequisites installed on your machine:

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/get-started)

## Running with Docker Compose

1. **Navigate to Project Directory:**

   ```bash
   cd BeyondSport

2. **Run Docker Compose command**

   ```bash
   docker compose up

  This will start a mysql container for storage mapped to host port ```3306``` and the .NET application mapped to host port  ```8080```

  If needed, ports can be changed in ```compose.yaml```
  
    ```bash
   ports:
      - "<host_port>:3306"

 3 **Call the REST API:**

   ```bash
   curl -X 'GET' \'http://localhost:5000/Player/1' \ -H 'accept: application/json'

## Running the Project Locally

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/obladioblada/BeyondSport.git

2. **Navigate to .NET project Directory:**

   ```bash
   cd BeyondSport/BeyondSport

3. **Build and Run the Project:**

   ```bash
   dotnet clean
   dotnet build
   dotnet run

  The application should now be running at http://localhost:5000

3. **Call the REST API:**

   ```bash
   curl -X 'GET' \'http://localhost:5000/Player/1' \ -H 'accept: application/json'


