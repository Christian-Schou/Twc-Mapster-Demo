# .NET 7 Web API Mapster Demo
TwcMapster is a demonstration of how easily you can implement Mapster in your .NET 7 Web API project.

## Getting Started
1. Clone the repository.
2. Open the solution in Visual Studio 2019+.
3. Update the connection string in appsettings.json.
4. Update the database.
5. Run the project.

## Update the database
1. Open the Package Manager Console.
2. Select the TwcMapster.Data project.
3. Run the following commands:
```PowerShell
Update-Database
```

## Usage of BaseDto
The BaseDto class is a base class for all DTOs. It contains methods to map between the DTOs and models. Here is an example of how to use it:

```C#
public class UserDto : BaseDto<UserDto, User>
{
	public int Id { get; set; }
	public string FullName { get; set; }
	public string Email { get; set; }

	public override void AddCustomMappings()
    {
        SetCustomMappingsReverse()
            .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}")
            .Map(dest => dest.Email, src => src.Email);
    }
}
```

## Built With
* .NET 7
* Mapster
* Entity Framework Core
* Microsoft SQL Server

## License
This project is Licensed under the GPU 3.0 License - see the [LICENSE.txt](LICENSE.txt) file for details.
