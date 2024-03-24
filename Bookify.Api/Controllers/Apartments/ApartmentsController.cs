using Bookify.Application.Apartments.SearchApartments;
using Bookify.Application.Apartments.UploadApartments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Bookify.Api.Controllers.Apartments;

[Authorize]
[ApiController]
[Route("api/apartments")]
public class ApartmentsController : ControllerBase
{
    private readonly ISender _sender;

    public ApartmentsController(ISender sender)
        => _sender = sender;

    [HttpGet]
    public async Task<IActionResult> SearchApartments(
        DateOnly startDate,
        DateOnly endDate,
        CancellationToken cancellationToken)
    {
        var query = new SearchApartmentsQuery(startDate, endDate);

        var result = await _sender.Send(query, cancellationToken);

        return Ok(result.Value);
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadApartments(
        [FromBody] IFormFile file,
        CancellationToken cancellationToken)
    {
        if (file is null)
            return BadRequest(); //TODO: create new Result Object Error in Domain Layer

        using var memoryStream = new MemoryStream();

        await file.CopyToAsync(memoryStream, cancellationToken);

        var query = new UploadApartmentsCommand(file.FileName, memoryStream.ToArray());

        var result = await _sender.Send(query, cancellationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result);
    }
}
