using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LemonWayChallenge.Services
{
    public class FibonacciService
    {
        public FibonacciService()
        {

        }

        public int Fibonacci(int n)
        {
            if (n < 1 || n > 100)
            {
                return -1;
            }
            else
            {
                int a = 0;
                int b = 1;
                // In N steps compute Fibonacci sequence iteratively.
                for (int i = 0; i < n; i++)
                {
                    int temp = a;
                    a = b;
                    b = temp + b;
                }
                return a;
            }

        }

    }
}