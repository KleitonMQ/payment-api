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
    public class UpdateSaleController : ControllerBase
    {
        private readonly DataBaseContext _context;
        public UpdateSaleController(DataBaseContext context)
        {
            _context = context;
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStatus(int id, string status)
        {
            var DBsale = _context.Sales.Find(id);
            if (DBsale == null)
                return NotFound();

            if (checkStatus(DBsale.Status, status) == false)
                return BadRequest($"A alteração de status desta compra para {status} não é permitida.");

            DBsale.Status = status;
            _context.Sales.Update(DBsale);
            _context.SaveChanges();

            var result = _context.Sales.Where(p => p.Id == id).Include(p => p.Product).Include(s => s.Seller);

            return Ok(result);
        }

        private bool checkStatus(string currentStatus, string newStatus)
        {
            if (currentStatus != "Enviado para transportadora" && newStatus == "Cancelada")
            {
                return true;
            }
            if (currentStatus == "Aguardando pagamento" && newStatus == "Pagamento aprovado")
            {
                return true;
            }
            if (currentStatus == "Pagamento aprovado" && newStatus == "Enviado para transportadora")
            {
                return true;
            }
            if (currentStatus == "Enviado para transportadora" && newStatus == "Entregue")
            {
                return true;
            }

            return false;
        }
    }
}