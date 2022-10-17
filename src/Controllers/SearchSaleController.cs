using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.src.Context;
using tech_test_payment_api.src.Entities;

namespace tech_test_payment_api.src.Controllers
{
    [ApiController]
    [Route("api-docs/[controller]")]
    public class SearchSaleController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public SearchSaleController(DataBaseContext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public ActionResult<Sale> SearchSaleId(int id)
        {
            var result = _context.Sales.Where(p=> p.Id == id).Include(p=>p.Product).Include(s=>s.Seller); 

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}