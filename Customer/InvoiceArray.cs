using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class InvoiceArray
    {
        public List<Invoice> retrieve()
        {//não terá campo total pois será feito de acordo com os dados
            List<Invoice> listInvoice = new List<Invoice>
            {
                new Invoice()
                {
                    InvoiceId =1,
                    CustomerId = 1,
                    Name = "Agua",
                    InvoiceDate = new DateTime(2013, 6, 20),
                    DueTime = new DateTime(2014, 7, 24),
                    IsPaid = null,
                    Amount = 199.99m,//(m) formata que vou trabalhar com dinheiro
                    NumberOfUnits=20,
                    DiscountPercent = 0m
                },
                new Invoice()
                {
                    InvoiceId =2,
                    CustomerId = 1,
                    Name = "Energia",
                    InvoiceDate = new DateTime(2016, 1, 2),
                    DueTime = new DateTime(2017, 1, 13),
                    IsPaid = null,
                    Amount = 100m,//(m) formata que vou trabalhar com dinheiro
                    NumberOfUnits=15,
                    DiscountPercent = 0m
                },
                new Invoice()
                {
                    InvoiceId =3,
                    CustomerId = 2,
                    Name = "Condomínio",
                    InvoiceDate = new DateTime(2006, 1, 9),
                    DueTime = new DateTime(2009, 1, 21),
                    IsPaid = null,
                    Amount = 1100.50m,//(m) formata que vou trabalhar com dinheiro
                    NumberOfUnits=2,
                    DiscountPercent = 0m
                },
                new Invoice()
                {
                    InvoiceId =4,
                    CustomerId = 5,
                    Name = "Gasolina",
                    InvoiceDate = new DateTime(2013, 6, 20),
                    DueTime = new DateTime(2014, 7, 24),
                    IsPaid = null,
                    Amount = 250m,//(m) formata que vou trabalhar com dinheiro
                    NumberOfUnits=10,
                    DiscountPercent = 0m
                },
                new Invoice()
                {
                    InvoiceId =5,
                    CustomerId = 3,
                    Name = "Aluguel",
                    InvoiceDate = new DateTime(2013, 6, 20),
                    DueTime = new DateTime(2014, 7, 24),
                    IsPaid = true,
                    Amount = 650.49m,//(m) formata que vou trabalhar com dinheiro
                    NumberOfUnits= 5,
                    DiscountPercent = 0m
                },
                new Invoice()
                {
                    InvoiceId =6,
                    CustomerId = 4,
                    Name = "Escola",
                    InvoiceDate = new DateTime(2020, 6, 20),
                    DueTime = new DateTime(2024, 7, 24),
                    IsPaid = null,
                    Amount = 1650.49m,//(m) formata que vou trabalhar com dinheiro
                    NumberOfUnits= 2,
                    DiscountPercent = 0m
                },
                new Invoice()
                {
                    InvoiceId =7,
                    CustomerId = 1,
                    Name = "Empregado",
                    InvoiceDate = new DateTime(2010, 2, 10),
                    DueTime = new DateTime(2012, 3, 20),
                    IsPaid = true,
                    Amount = 986.49m,//(m) formata que vou trabalhar com dinheiro
                    NumberOfUnits= 50,
                    DiscountPercent = 0m
                },
                new Invoice()
                {
                    InvoiceId =8,
                    CustomerId = 3,
                    Name = "Imposto",
                    InvoiceDate = new DateTime(2013, 6, 20),
                    DueTime = new DateTime(2014, 7, 24),
                    IsPaid = null,
                    Amount = 3650.49m,//(m) formata que vou trabalhar com dinheiro
                    NumberOfUnits= 40,
                    DiscountPercent = 0m
                },


            };
            return listInvoice;
            
        }
        public List<Invoice> retrieve(int customerId)
        {

            var listInvoice = this.retrieve();
            //(.toList) para ser uma Lista, isso para identificar e pegar somente o que for 
            //do cliente;
            var query = listInvoice.Where(c => c.CustomerId == customerId).ToList();
            return query;
        }

        public decimal CalculateTotalAmountInvoice(List<Invoice> listInvoice)
        {

            return listInvoice.Sum(c => c.TotalAmount); //definido o que queremos somar
        }

        public int CalculateTotalUnits(List<Invoice> listInvoice)
        {
            return listInvoice.Sum(c => c.NumberOfUnits);
        }
    }
}

