using System;
using System.Collections.Generic;

class PrimeFactorization
{
    static void Main()
    {
        uint n = uint.Parse(Console.ReadLine());
        uint originalNumber = n;
        uint divisor = 2;
        List<uint> primeFactors = new List<uint>();

        while (n != 1)
        {
            if(n % divisor == 0)
            {
                n /= divisor;
                primeFactors.Add(divisor);
            }
            else
            {
                divisor++;
            }
        }
        Console.WriteLine("{0} = {1}",originalNumber, string.Join(" * ", primeFactors));
    }
}

