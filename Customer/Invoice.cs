using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public String Name { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueTime { get; set; } //vencimento
        public bool? IsPaid { get; set; } //pago? 

        //analise de dados

        public decimal Amount { get; set; }
        public int NumberOfUnits { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal TotalAmount
        {
            get
            {//o valor será de acordo que tiver montante menos desconto
                return Amount - (Amount * (DiscountPercent / 100));
            }
        }
    }
}
