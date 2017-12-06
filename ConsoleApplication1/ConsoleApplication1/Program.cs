using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Role admin = new Role();
            admin.Name = "vasia";
            admin.Permis.SetAllTrue();

            Role guest = new Role();
            guest.Permis.Read = true;

            Role user = new Role();
            user.Permis.Read = true;
            user.Permis.Update = true;

            Console.WriteLine(admin.ToString());
            Console.WriteLine(guest);
            Console.ReadKey();
        }
    }
}