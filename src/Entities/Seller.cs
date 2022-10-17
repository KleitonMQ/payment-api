using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.src.Entities
{
    public class Seller
    {
        public Seller(string sellerCpf, string sellerName, string sellerEmail, string sellerTelephone)
        {
            this.SellerCpf = sellerCpf;
            this.SellerEmail = sellerEmail;
            this.SellerName = sellerName;
            this.SellerTelephone = sellerTelephone;
        }
        public int SellerId { get; set; }
        public string SellerCpf { get; set; }
        public string SellerName { get; set; }
        public string SellerEmail { get; set; }
        public string SellerTelephone { get; set; }
    }
}