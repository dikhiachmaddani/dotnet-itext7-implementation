using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.Application.Interfaces;
using Project.Domain.Interfaces;
using Project.Application.UseCases;
using Project.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddScoped<IGenerateInvoiceUseCase, GenerateInvoiceUseCase>();
builder.Services.AddScoped<IInvoiceGenerator, InvoiceGenerator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
