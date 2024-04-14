using Bookify.Application.Apartments.AssignApartmentsTask;
using Bookify.Application.Apartments.SearchApartments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace Bookify.Api.Controllers.Apartments;

//[Authorize]
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
        [FromForm] IFormFile file,
        CancellationToken cancellationToken)
    {
        if (file is null)
            return BadRequest(); //TODO: create new Result Object Error in Domain Layer

        using var memoryStream = new MemoryStream();

        await file.CopyToAsync(memoryStream, cancellationToken);

        var command = new AssignApartmentsTaskCommand(file.FileName, memoryStream.ToArray());

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
}
