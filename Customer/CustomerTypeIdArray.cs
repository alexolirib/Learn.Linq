using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CustomerTypeIdArray
    {
        public List<CustomerTypeId> InitialDataTypeId()
        {
            List<CustomerTypeId> listCustomerType = new List<CustomerTypeId>
            {
                new CustomerTypeId()
                {
                    id = 1,
                    NameTypeId = "Corporate",
                    DisplayOrder = 2
                },
                new CustomerTypeId()
                {
                    id = 2,
                    NameTypeId = "Individual",
                    DisplayOrder = 1
                },
                new CustomerTypeId()
                {
                    id = 3,
                    NameTypeId = "Educate",
                    DisplayOrder = 4
                },
                new CustomerTypeId()
                {
                    id = 4,
                    NameTypeId = "Gorvernment",
                    DisplayOrder = 3
                }
            };
            return listCustomerType;

        }
    }
}

