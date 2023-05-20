using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ServiceRequestController : ControllerBase
{
    private readonly NewContainerDataContext _context;

    public ServiceRequestController(NewContainerDataContext context)
    {
        _context = context;
    }

    // GET: api/ServiceRequest
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServiceRequest>>> GetServiceRequests()
    {
        var serviceRequests = await _context.ServiceRequests.ToListAsync();
        return Ok(serviceRequests);
    }

    // GET: api/ServiceRequest/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceRequest>> GetServiceRequest(int id)
    {
        var serviceRequest = await _context.ServiceRequests.FindAsync(id);

        if (serviceRequest == null)
        {
            return NotFound();
        }

        return Ok(serviceRequest);
    }

    // POST: api/ServiceRequest
    [HttpPost]
    public async Task<ActionResult<ServiceRequest>> CreateServiceRequest(ServiceRequest serviceRequest)
    {
        _context.ServiceRequests.Add(serviceRequest);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetServiceRequest", new { id = serviceRequest.ServiceRequestId }, serviceRequest);
    }

    // PUT: api/ServiceRequest/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateServiceRequest(int id, ServiceRequest serviceRequest)
    {
        if (id != serviceRequest.ServiceRequestId)
        {
            return BadRequest();
        }

        _context.Entry(serviceRequest).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ServiceRequestExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/ServiceRequest/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteServiceRequest(int id)
    {
        var serviceRequest = await _context.ServiceRequests.FindAsync(id);
        if (serviceRequest == null)
        {
            return NotFound();
        }

        _context.ServiceRequests.Remove(serviceRequest);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ServiceRequestExists(int id)
    {
        return _context.ServiceRequests.Any(sr => sr.ServiceRequestId == id);
    }
}