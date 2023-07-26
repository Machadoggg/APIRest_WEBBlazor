using APIRest_WEBBlazor.API.Data;
using APIRest_WEBBlazor.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIRest_WEBBlazor.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _context;

        public CustomerController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _context.Customers.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetSingleAsync(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer is null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(customer);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un registro con el mismo número de identificación");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Customer customer)
        {
            _context.Update(customer);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(customer);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un registro con el mismo número de identificación");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer is null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return Ok(customer);
        }
    }
}
