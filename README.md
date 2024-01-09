# README: Beyond Sports

   This README provides instructions on how to run a .NET 8 project for the assignment. 
   The project includes [Swagger](https://swagger.io/) documentation and can be run using Docker Compose, with the  ```compose.yaml``` file located under the root directory.

   For the test sake I decided to use InMemoryDB in case docker is not installed on the host machine. Jump to the "Running the Project Locally" section in that case.  
   If the application is running with docker, a MySql database container is fired up along with the app.  
   Both ways, the application is pre-populated with some data.

## Prerequisites

   Before getting started, ensure you have the following prerequisites installed on your machine:

   - [.NET 8 SDK](https://dotnet.microsoft.com/download)
   - [Docker](https://www.docker.com/get-started)

   Download the project 

   ```bash
   git clone https://github.com/obladioblada/BeyondSport.git
   ```


## Running with Docker Compose

1. **Navigate to Project root Directory:**

   ```bash
   cd BeyondSport
   ```

2. **Run Docker Compose command**

   ```bash
   docker compose up
   ```

      This will start a mysql container for storage mapped to host port ```3306``` and the .NET application mapped to host port  ```8080```

      If needed, ports can be changed in ```compose.yaml```
  
   ```bash
   ports:
      - "<host_port>:3306"
   ```

3. **Call the REST API:**

   Check the Swagger documentation accessible at [http://localhost:8080/swagger/index.html](http://localhost:8080/swagger/index.html) 

   ```bash
   curl -X 'GET' \'http://localhost:8080/Player/1' \ -H 'accept: application/json'
   ```

## Running locally with .NET 8

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/obladioblada/BeyondSport.git
   ```

2. **Navigate to .NET app directory:**

   ```bash
   cd BeyondSport/BeyondSport
   ```

3. **Build and Run the Project:**

   ```bash
   dotnet clean
   dotnet build
   dotnet run
   ```

  The application should now be running at http://localhost:5000

4. **Testing**

   I set up a couple of tests for demonstration and they are not exaustive.  
   You can run the tests with 

   ```bash
   dotnet test
   ```
