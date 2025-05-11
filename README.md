# Invoice Generator Project

A .NET Core application for generating PDF invoices using iText7 HTML to PDF conversion.

## Prerequisites

- .NET 9.0
- Visual Studio 2022 or VS Code
- iText7 library (installed via NuGet)

## Project Structure

The solution consists of 5 projects:

- **Project** - Main web API project
- **Project.Application** - Application business logic and use cases
- **Project.Common** - Shared utilities and constants
- **Project.Domain** - Domain entities and interfaces
- **Project.Infrastructure** - External dependencies and implementations

## Getting Started

### Installation

1. Clone the repository:
   ```
   git clone https://github.com/yourusername/invoice-generator.git
   ```

2. Navigate to the project directory:
   ```
   cd invoice-generator
   ```

3. Restore dependencies:
   ```
   dotnet restore
   ```

4. Build the solution:
   ```
   dotnet build
   ```

5. Run the application:
   ```
   dotnet run --project Project
   ```

### Configuration

1. Update `appsettings.json` with your database connection strings and other environment-specific settings.

## Features

- PDF invoice generation from HTML templates
- Customizable invoice templates

## API Endpoints

### Invoice Endpoints

- `POST /api/invoice/generate` - Create new invoice

## PDF Template Customization

Templates are stored in the `Templates` folder and can be customized:

1. Edit the HTML templates in the `Templates` directory
2. Use placeholders like `{{CompanyName}}`, `{{InvoiceNumber}}`, etc.
3. Style using CSS within the template

## Dependency Injection

The application uses built-in .NET dependency injection:

```csharp
// Example of service registration in Program.cs
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IPdfGenerator, IText7PdfGenerator>();
builder.Services.AddScoped<ITemplateRenderer, RazorTemplateRenderer>();
```

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgments

- iText7 for PDF generation
- .NET team for the excellent framework

## Preview

[Lihat contoh PDF Invoice](Project/assets/itext7-output.pdf)