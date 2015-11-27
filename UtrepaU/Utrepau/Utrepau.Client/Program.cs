using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Utrepau.Data;

namespace Utrepau.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var db=new UtrepauContext();
            
            Console.WriteLine(db.Users.Count());
        }
    }
}
