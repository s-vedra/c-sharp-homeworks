using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public static class HelperMethods<T> where T : Entity
    {
        public static void PrintEntity(List<T> items)
        {
            items.ForEach(item => Console.WriteLine(item.PrintInfo()));
        }
    }
}
