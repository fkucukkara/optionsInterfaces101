# ASP.NET Core Options Pattern Demo

A comprehensive educational project demonstrating the three main Options interfaces in ASP.NET Core: `IOptions<T>`, `IOptionsSnapshot<T>`, and `IOptionsMonitor<T>`.

## 🎯 Purpose

This project showcases the differences between the three Options interfaces and when to use each one:

- **IOptions<T>** - Singleton pattern, configuration read once at startup
- **IOptionsSnapshot<T>** - Scoped pattern, configuration read per request
- **IOptionsMonitor<T>** - Real-time pattern, configuration changes detected immediately

## 🚀 Getting Started

### Prerequisites

- .NET 9.0 SDK
- Visual Studio 2022 or VS Code

### Running the Application

1. Clone the repository
2. Navigate to the project directory
3. Run the application:
   ```bash
   dotnet run
   ```
4. The API will be available at `http://localhost:5132`

## 📋 API Endpoints

| Endpoint | Options Interface | Description |
|----------|------------------|-------------|
| `GET /option` | `IOptions<T>` | Returns configuration values (singleton) |
| `GET /option-snapshot` | `IOptionsSnapshot<T>` | Returns configuration values (per request) |
| `GET /option-monitor` | `IOptionsMonitor<T>` | Returns configuration values with change monitoring |

## 🔧 Configuration

The application uses `appsettings.json` for configuration:

```json
{
  "Position": {
    "Title": "Engineer",
    "Name": "Fatih KUCUKKARA"
  }
}
```

## 🧪 Testing the Differences

1. **Start the application**
2. **Test initial values** by calling all three endpoints
3. **Modify `appsettings.json`** while the app is running
4. **Call endpoints again** to observe the behavior differences:
   - `/option` - Still returns old values (singleton)
   - `/option-snapshot` - Returns new values on next request (scoped)
   - `/option-monitor` - Returns new values immediately + logs changes

## 📁 Project Structure

```
OptionPatterns/
├── Program.cs              # Main application with endpoint definitions
├── PositionOptions.cs      # Configuration model class
├── appsettings.json        # Application configuration
├── OptionPatterns.http     # HTTP test file
└── OptionPatterns.csproj   # Project file
```

## 🔍 Key Learning Points

### IOptions<T>
- **Lifetime**: Singleton
- **Use Case**: Static configuration that doesn't change
- **Performance**: Best (no overhead)
- **Reloading**: No support for configuration reloading

### IOptionsSnapshot<T>
- **Lifetime**: Scoped (per request)
- **Use Case**: Configuration that may change between requests
- **Performance**: Good (cached per request)
- **Reloading**: Supports configuration reloading per request

### IOptionsMonitor<T>
- **Lifetime**: Singleton with change notifications
- **Use Case**: Real-time configuration changes
- **Performance**: Slight overhead for change detection
- **Reloading**: Immediate configuration reloading with notifications

## 🛠️ Technologies Used

- ASP.NET Core 9.0
- Minimal APIs
- Microsoft.Extensions.Options
- Configuration System

## 📖 Additional Resources

- [Options pattern in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options)
- [Configuration in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/)

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.