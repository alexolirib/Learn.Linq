using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DAO.TEST
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void QueryById()
        {
            CustomerArray newCustomerArray = new CustomerArray();
            var test = newCustomerArray.InitialData();

            var result = newCustomerArray.findById(test, 2);

            var resultNull = newCustomerArray.findById(test, 50);

            Assert.AreEqual(2, result.id);
            Assert.AreEqual("Davi", result.Nome);

            Assert.IsNull(resultNull);

        }
        [TestMethod]
        public void TestandoFunc()
        {
            //ultimo valor é o retorno 
            Func<int, int, int> ates = (y, x) => x * y;

            //aqui deve fazer uma ação e o retorno é void
            Action<int> add = x => Console.WriteLine(x);


            int result = ates(2, 5);

            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void TestSort()
        {
            var customer = new CustomerArray();

            var test = customer.InitialData();

            var resultName = customer.sortByListByName(test);

            var resultTypeId = customer.sortByListByTypeId(test);

            Assert.AreEqual(3, resultName.First().id);

            Assert.AreEqual(null, resultTypeId.Last().TypeId);
            Assert.AreEqual(1, resultTypeId.First().TypeId);

        }

        [TestMethod]
        public void buildTest()
        {
            var newBuild = new Build();

            var result = newBuild.testRange();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void comparingTest()
        {
            var newBuild = new Build();

            var result = newBuild.testComparing();

            foreach (var result1 in result)
            {
                Console.WriteLine(result1);
            }

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void testSelectINameIdade()
        {
            var newCustomerArray = new CustomerArray();
            var list = newCustomerArray.InitialData();

            var result = newCustomerArray.GetNameAndOld(list);

        }

        [TestMethod]
        public void testSelectINameIdadeVerson2()
        {
            var newCustomerArray = new CustomerArray();
            var list = newCustomerArray.InitialData();

            var result = newCustomerArray.GetNameAndOldVerson2(list);

        }
    }

}

