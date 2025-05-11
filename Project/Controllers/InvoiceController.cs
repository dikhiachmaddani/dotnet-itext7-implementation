using Microsoft.AspNetCore.Mvc;
using Project.Application.Interfaces;
using Project.Domain.Entities;

namespace Project.Controllers;

[ApiController]
[Route("api/invoice")]
public class InvoiceController : ControllerBase
{
    private readonly IGenerateInvoiceUseCase _generateInvoiceUseCase;

    public InvoiceController(IGenerateInvoiceUseCase generateInvoiceUseCase)
    {
        _generateInvoiceUseCase = generateInvoiceUseCase;
    }

    [HttpPost("generate")]
    public async Task<IActionResult> GenerateInvoice()
    {
        try
        {
            var pdfFilePath = await _generateInvoiceUseCase.ExecuteAsync();
            return Ok(new { filePath = pdfFilePath });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
