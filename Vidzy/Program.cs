using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {

            var dbContext = new VidzyDbContext();

            dbContext.AddVideo("1123", DateTime.Now, 1, Classification.Platinum);
            dbContext.AddVideo("12323", DateTime.Now, 2, Classification.Gold);
            dbContext.AddVideo("123", DateTime.Now, 4, Classification.Silver);
        }
    }
}
