# e4-academic

![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![ASP.NET Web API](https://img.shields.io/badge/ASP.NET%20Web%20API-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)
![JSON](https://img.shields.io/badge/JSON-000000?style=for-the-badge&logo=json&logoColor=white)
![Time Taken](https://img.shields.io/badge/Time%20Taken-~5%20hours-blue?style=for-the-badge&logo=clockify&logoColor=white)

Test 3 : A C# REST API service that uses the GET , POST and DELETE verbs . the Api saves Simple Student Data. Retrieve
and Delete Student Data.

## Demo

![e4-academic-demo](https://github.com/user-attachments/assets/75d21183-cdeb-4b8f-a920-4ff9763eb62f)

## API Endpoints

| Method   | Endpoint             | Description              |
|----------|----------------------|--------------------------|
| `GET`    | `/Students`      | Retrieve all students    |
| `GET`    | `/Students/{id}` | Retrieve a student by ID |
| `POST`   | `/Students`      | Add a new student        |
| `DELETE` | `/Students/{id}` | Delete a student by ID   |

For full request/response examples and schemas, see the [API Definition](Docs/Api.md).

## Assumptions & Business Rules

- Each student is assigned a `Guid` as their primary identifier instead of a sequential integer.
  as sequential `Ids` are predictable, a user could guess another student's record by simply
  incrementing the `Id` in the URL.


- The student number is a `generated string` rather than a numeric type. A string allows for
  a combination of letters and numbers, which greatly increases the pool of unique values that
  can be generated. Usuallay student volumes are typically high the student number must be unique and could potentially
  be generated at the database level in a production environment.


- Since this is a simple CRUD application with only 4 endpoints and a small data set,
  a `Dictionary` was chosen as the data store. This also removed the need for `async/await`, as dictionary operations
  provide constant-time reads and writes.


## Decisions & Technical Considerations

- **Project Structure** : All code currently lives within the API project since the scope is small and manageable.
  Should the application grow, I would move toward a clean architecture layout with separate projects (e.g., Domain,
  Application, Infrastructure, Presentation) to enforce clearer boundaries.


- **Data Modelling Considerations** : Currently, student data (including extracurricular activities and courses) is kept
  simple. In a scaled version, these would be modelled as **separate entities** with **many-to-many
  relationships**, each with their own tables and join tables managed through EF Core.


- **Manual Mapping** : Request-to-model mappings are done **manually** since the data models are simple and the
  number of mappings is small. This keeps the project lightweight with fewer dependencies.
  If the application were to grow with more complex or repetitive mappings, I would consider
  introducing **AutoMapper** to reduce boilerplate and centralise mapping configurations.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Installation

These instructions will get you a copy of the project up and running on your local machine for development and testing
purposes.

1. **Clone the repository**

```bash
   git clone https://github.com/KgotsoKP/e4-academic.git
   cd e4-academic
```

2 **Run the application**

```bash
   dotnet run --project ./Academic.Api
```

> Note: `dotnet restore` runs implicitly with `dotnet run` in .NET 8.

3 **Launch Swagger UI**

Navigate to `https://localhost:5001/swagger` to explore the API endpoints.
