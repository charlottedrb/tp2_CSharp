using System;


namespace Exo1
{
    class Program
    {
        static void Main(string[] args)
        {
            Ville v1 = new Ville("Annecy", 40000, 70, "74000");
            Ville v2 = new Ville("Chambéry", 20000, 50, "73000");
            Console.WriteLine(v1.CalculDensite());
            v1.EstPlusDense(v2);
            v1.EstDansLeMemeDepartement(v2);
            
        }
    }
}
