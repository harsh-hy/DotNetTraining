# StudentPortal MVC + Web API + EF Core + DTO Example

Flow implemented:

MVC --> Web API --> Controller --> Service --> Repository --> Database

## Projects
- StudentPortal.Api
- StudentPortal.Mvc
- Database scripts

## Database
Run:
1. `Database/01_CreateDatabase.sql`
2. `Database/02_SampleData.sql`

## API connection string
Already configured in:
`StudentPortal.Api/appsettings.json`

```json
"DefaultConnection": "Data Source=DESKTOP-UHSE201\\SQLEXPRESS;Initial Catalog=StudentPortalDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"
```

## Run API
```bash
cd StudentPortal.Api
dotnet restore
dotnet build
dotnet run
```

## Swagger
After running API, check swagger and note the port, for example:
`https://localhost:7001`

## Update MVC base URL
Open:
`StudentPortal.Mvc/appsettings.json`

Set:
```json
"ApiSettings": {
  "BaseUrl": "https://localhost:7001/api/"
}
```

## Run MVC
```bash
cd StudentPortal.Mvc
dotnet restore
dotnet build
dotnet run
```

## DTO design used
- `StudentCreateDto` and `StudentUpdateDto`
- `CourseCreateDto` and `CourseUpdateDto`
- `EnrollmentCreateDto` and `EnrollmentUpdateDto`

Benefits:
- EF entities stay internal
- clean request/response contracts
- easier validation
- safer API surface

## Included CRUD
- Students: insert, update, delete, list
- Courses: insert, update, delete, list
- Enrollments: insert, update, delete, list

## Notes
- Duplicate Student+Course enrollment is blocked in service/repository layer.
- Foreign key delete errors are expected if a Student/Course is already used in Enrollments.
- You can later extend this with AutoMapper, authentication, pagination, stored procedures, and class library layering.
