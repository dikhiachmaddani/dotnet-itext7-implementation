using Project.Domain.Entities;

namespace Project.Application.Interfaces;

public interface IGenerateInvoiceUseCase
{
    Task<string> ExecuteAsync();
} 