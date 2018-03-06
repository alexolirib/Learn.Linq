using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Build
    {
        public IEnumerable<int> testRange()
        {
            var test = Enumerable.Range(0, 10)
                        .Select(c => c * 5);
            foreach (var test1 in test)
            {
                Console.WriteLine(test1);
            }

            return test;
        }


        public IEnumerable<int> testComparing()
        {
            var set1 = Enumerable.Range(0, 10);
            var set2 = Enumerable.Range(0, 10)
                        .Select(c => c * c);

            //intersect - interseção
            //Exception - diferença entre conjunto 
            //concat - concatena os conjunto (repete)
            //unian  concat.distinct -junta dois conjuntos sem repetir
            return set1.Intersect(set2);
        }
    }
}
