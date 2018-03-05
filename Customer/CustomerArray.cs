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

        public List<Customer> InitialData()
        {
            List<Customer> custumer = new List<Customer>()
            {
                new Customer
                {
                    id = 1,
                    Nome = "Alexandre",
                    Idade= 23,
                    TypeId = null
                },
                new Customer
                {
                    id = 2,
                    Nome = "Davi",
                    Idade= 20,
                    TypeId = 3
                },
                new Customer
                {
                    id = 3,
                    Nome = "Alexandre",
                    Idade= 22,
                    TypeId = 1
                },
                new Customer
                {
                    id = 4,
                    Nome = "Daniel",
                    Idade= 25,
                    TypeId = 1
                },
                new Customer
                {
                    id = 5,
                    Nome = "Amada",
                    Idade= 28,
                    TypeId = null
                }
            };
            return custumer;
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
    }
}
