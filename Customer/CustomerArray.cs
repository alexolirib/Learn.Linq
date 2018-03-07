using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CustomerArray
    {
        public Customer findById(List<Customer> listCustomer, int id)
        {
            Customer FoundCustomer = null;

            // Metado tradicional
            //foreach (var customer in listCustomer)
            //{
            //    if (customer.id == id)
            //    {
            //        FoundCustomer = customer;
            //        break;
            //    }
            //}

            //Sintaxe de consulta pela a linguagem c#
            //var query = from custumer in listcustomer
            //            where custumer.id == id
            //            select custumer;

            //foundcustomer = query.first();

            //O metodo quando retornar true ele encerra 
            //FoundCustomer = listCustomer.First(c => c.id == id); - não é a melhor forma pois se buscar algum id que não possua na lista da problema

            //Esse é melhor pois se nõa tiver na lista o buscado retorna null
            //FoundCustomer = listCustomer.FirstOrDefault(c => c.id == id);

            //where interessante que pode ter uma lista de resultado , sem ser só o primeiro 
            FoundCustomer = listCustomer.Where(c =>
                                    c.id == id)
                                    .FirstOrDefault(); //no where interessante sempre botar o que deve retornar(seleciona)

            return FoundCustomer;
        }

        //dynamic pois vou vou fazer uma funçao dinamica e vai retornar a  
        public dynamic GetNameAndOld(List<Customer> listCustomer)
        {
            var query = listCustomer.Select(c => "Name - " + c.Nome + ", Idade - " + c.Idade);

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            return query;
        }

        //Como vou usar dois tipos de atributos diferente a forma mais interessante
        //de trabalhar é fazendo um objeto do tipo anônimo
        public dynamic GetNameAndOldVerson2(List<Customer> listCustomer)
        {
            var query = listCustomer.Select(c => new
            {
                Name = c.Nome,
                c.Idade
            });

            foreach (var item in query)
            {
                Console.WriteLine($"Name - {item.Name}, Idade - {item.Idade}");
            }
            return query;
        }


        //select(pai(customer) e filho(invoice)) - selecionar o pai que está devendo
        //retorna uma lista filha do costumer por isso que colocar ienumerable<**>
        public IEnumerable<IEnumerable<Invoice>> peopleShouldSelect(List<Customer> listCustomer)
        {
            var query = listCustomer.Select(c => c.InvoiceList
                                        .Where(i => (i.IsPaid ?? false) == false));// irá verificar o que é false e null para retornar a query e saber que não foi pago

            foreach (var item in query)
            {
                foreach (var CustomerInvoice in item)
                {
                    Console.WriteLine(CustomerInvoice.Name.ToString());
                }
            }
            return query;

        }

        //SelectMany(Pai e filho), faz mesma coisa de forma mais simples
        public dynamic peopleShouldSelectMany(List<Customer> lisCustomer)
        {
            var query = lisCustomer.SelectMany(c => c.InvoiceList
                                    .Where(i => (i.IsPaid ?? false) == false),
                                    (c, i) => new
                                    {
                                        NameCustomar = c.Nome,
                                        NameInvoice = i.Name,
                                        i.DueTime
                                    });

            foreach (var item in query)
            {
                Console.WriteLine($"{item.NameCustomar} está devendo {item.NameInvoice} e tem o vencimento {item.DueTime}");
            }
            return query;
        }

        //SelectMany(Pai e filho), faz mesma coisa de forma mais simples
        public IEnumerable<Customer> peopleShouldSelectMany2(List<Customer> lisCustomer)
        {
            var query = lisCustomer.SelectMany(c => c.InvoiceList
                                    .Where(i => (i.IsPaid ?? false) == false),
                                    (c, i) => c).Distinct();
            //Distinct para não pegar elemento repetido
            foreach (var item in query)
            {
                Console.WriteLine(item.Nome);
            }
            return query;
        }

        //cria 5 novos usuários null
        public IEnumerable<Customer> retrieveEmptyList()
        {
            return Enumerable.Repeat(new Customer(), 5);
        }

        public List<Customer> InitialData()
        {
            InvoiceArray fatura = new InvoiceArray();
            List<Customer> custumer = new List<Customer>()
            {
                new Customer
                {
                    id = 1,
                    Nome = "Alexandre",
                    Idade= 23,
                    TypeId = null,
                    InvoiceList = fatura.retrieve(1)
                },
                new Customer
                {
                    id = 2,
                    Nome = "Davi",
                    Idade= 20,
                    TypeId = 3,
                    InvoiceList = fatura.retrieve(2)
                },
                new Customer
                {
                    id = 3,
                    Nome = "Alexandre",
                    Idade= 22,
                    TypeId = 1,
                    InvoiceList = fatura.retrieve(3)
                },
                new Customer
                {
                    id = 4,
                    Nome = "Daniel",
                    Idade= 25,
                    TypeId = 2,
                    InvoiceList = fatura.retrieve(4)
                },
                new Customer
                {
                    id = 5,
                    Nome = "Amada",
                    Idade= 28,
                    TypeId = null,
                    InvoiceList = fatura.retrieve(5)
                }
            };

            return custumer;
        }

        //fazer um join, junção de duas tabelas do Customer e do typeId,
        //não aparecer o id e sim o nome em vez(sera objeto Anonimo)
        public dynamic joinListByCustomerAndTypeId(List<Customer> listCustomer, List<CustomerTypeId> listTypeId)
        {                              //Join(a lista da tabela que está fazendo chave,
            var query = listCustomer.Join(listTypeId,//tabela chave estrangeira
                                c => c.TypeId,//pegou o typeId do listCustomer
                                c2 => c2.id,//chave do listTypeId
                                (c, c2) => new//o que for a chave igual irá pegar informação desejada de cada
                                {
                                    Name = c.Nome,
                                    NameType = c2.NameTypeId
                                });
            foreach (var item in query)
            {
                Console.WriteLine($"Nome - {item.Name}, NomeTypeId - {item.NameType} ");
            }

            return query;
        }

        //retorna a ordenação da lista
        public IEnumerable<Customer> sortByListByName(List<Customer> customerList)
        {
            //aqui informo com que metodo desejo ordenar essa lista
            return customerList.OrderBy(c => c.Nome)
                                .ThenBy(c => c.Idade);
        }

        public IEnumerable<Customer> sortByListByTypeId(List<Customer> custumerList)
        {
            //forma que deixa os valores nulls no final da list
            //
            return custumerList.OrderByDescending(c => c.TypeId.HasValue)
                                        .ThenBy(c => c.TypeId);
        }

        public dynamic sortGetNameAndId(List<Customer> listCustormer)
        {
            var query = listCustormer.OrderBy(c => c.Nome)
                                        .ThenBy(c => c.id)
                                            .Select(c => new
                                            {
                                                c.Nome,
                                                c.id
                                            });
            foreach (var item in query)
            {
                Console.WriteLine($"tem o id - {item.id} e o nome - {item.Nome}");
            }            

        return query;
        }

    }
}
