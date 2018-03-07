using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class InvoiceArray
    {
        public List<Invoice> retrieve(int customerId)
        {
            List<Invoice> listInvoice = new List<Invoice>
            {
                new Invoice()
                {
                    InvoiceId =1,
                    CustomerId = 1,
                    Name = "Agua",
                    InvoiceDate = new DateTime(2013, 6, 20),
                    DueTime = new DateTime(2014, 7, 24),
                    IsPaid = null
                },
                new Invoice()
                {
                    InvoiceId =2,
                    CustomerId = 1,
                    Name = "Energia",
                    InvoiceDate = new DateTime(2016, 1, 2),
                    DueTime = new DateTime(2017, 1, 13),
                    IsPaid = null
                },
                new Invoice()
                {
                    InvoiceId =3,
                    CustomerId = 2,
                    Name = "Condomínio",
                    InvoiceDate = new DateTime(2006, 1, 9),
                    DueTime = new DateTime(2009, 1, 21),
                    IsPaid = null
                },
                new Invoice()
                {
                    InvoiceId =4,
                    CustomerId = 5,
                    Name = "Gasolina",
                    InvoiceDate = new DateTime(2013, 6, 20),
                    DueTime = new DateTime(2014, 7, 24),
                    IsPaid = null
                },
                new Invoice()
                {
                    InvoiceId =1,
                    CustomerId = 3,
                    Name = "Aluguel",
                    InvoiceDate = new DateTime(2013, 6, 20),
                    DueTime = new DateTime(2014, 7, 24),
                    IsPaid = true
                },
            };
            //(.toList) para ser uma Lista, isso para identificar e pegar somente o que for 
            //do cliente;
            var query = listInvoice.Where(c => c.CustomerId == customerId).ToList();
            return query;
        }
    }
}

