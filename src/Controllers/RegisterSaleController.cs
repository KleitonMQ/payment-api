using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.src.Context;
using tech_test_payment_api.src.Entities;


namespace tech_test_payment_api.src.Controllers
{
    [ApiController]
    [Route("api-docs/[controller]")]
    public class RegisterSaleController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public RegisterSaleController(DataBaseContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Create(string sellerName, string sellerCpf, string sellerTelephone, string sellerEmail, List<Product> product)
        {
            if (product == null)
            return BadRequest("Por favor inserir os produtos vendidos.");
            
            var sale = new Sale();

            sale.Seller = new Seller(sellerCpf, sellerName, sellerEmail, sellerTelephone);

            sale.Product = product;
            sale.Status = "Aguardando pagamento";
            _context.Add(sale);
            _context.SaveChanges();
            return Ok();
        }
    }
}