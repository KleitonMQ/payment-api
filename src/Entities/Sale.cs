using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace tech_test_payment_api.src.Entities
{
    public class Sale
    {
        public Sale()
        {
            // this.SellerCpf = sellerCpf;
            // this.SellerEmail = sellerEmail;
            // this.SellerName = sellerName;
            // this.SellerTelephone = sellerTelephone;
            this.Date = DateTime.Now;
            this.Status = "Aguardando Pagamento.";
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Seller Seller { get; set; }
        public List<Product> Product { get; set; }
        public string Status { get; set; }
    }
}