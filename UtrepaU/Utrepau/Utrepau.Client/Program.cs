namespace Utrepau.Client
{
    using System;
    using System.Linq;
    using Data;

    class Program
    {
        static void Main(string[] args)
        {
            var db=new UtrepauContext();
            
            Console.WriteLine(db.Users.Count());
        }
    }
}
