# README: Beyond Sports .NET 8 Assignment

This README provides instructions on how to run a .NET 8 project for the assignment. The project includes Swagger documentation accessible at [http://localhost:8080/swagger/index.html](http://localhost:8080/swagger/index.html) and can also be run using Docker Compose, with the   ```compose.yaml ``` file located under the root directory.

For the test sake I decided to use InMemoryDB in care docker is not installed on the host machine. Follow "Running the Project Locally" section in that case.
If the application is running with docker, a MySql database container is fired up along with the app.

## Prerequisites

Before getting started, ensure you have the following prerequisites installed on your machine:

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/get-started)

##### Running with Docker Compose
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
  
   ```yaml
   ports:
      - "<host_port>:3306"
   ```

 3 **Call the REST API:**

   ```bash
   curl -X 'GET' \'http://localhost:5000/Player/1' \ -H 'accept: application/json'
   ```

## Running the Project Locally

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

3. **Testing**

   I set up a couple of tests for demonstration and they are not exaustive. (I left also one that will be skipped because I could not make it work and I thought to ask you guys in case).
   You can run the tests with 

   ```bash
   dotnet test
    ```