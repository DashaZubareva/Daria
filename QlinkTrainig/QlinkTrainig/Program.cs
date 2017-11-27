using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlinkTrainig
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> list = new List<string>();
            list.Add("USA");
            list.Add("MOLDOVA");
            list.Add("CHINA");
            list.Add("FRAnCE");
            list.Add("RUSSIA");

            //list.Where(x => x != "RUSSIA").ToList().ForEach(x=>Console.WriteLine(x));
            //var item = list.ToList().Single(x => x == "RUSSIA");
                       
            list.OrderBy(t => t).ToList().ForEach(x => {
                x.ToUpperInvariant();
                Console.WriteLine(x);
                });

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
