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
    }
}
