using Assignment4;
using System.Text;

namespace Assignment4Main
{
    public static class CustomExtensions
    {
        public static List<int> EvenNumbers(this NumericFunctions numericFunctions ,int startRange, int endRange)
        {
            List<int> evenNum = Enumerable.Range(startRange, endRange - startRange + 1).Where(x=>x%2==0).ToList();
            return evenNum;
        }
        public static List<int> OddNumbers(this NumericFunctions numericFunctions, int startRange, int endRange)
        {
            List<int> oddNum = Enumerable.Range(startRange, endRange - startRange + 1).Where(x => x % 2 != 0).ToList();
            return oddNum;
        }
        public static List<int> PrimeNumbers(this NumericFunctions numericFunctions, int startRange, int endRange)
        {
            List<int> primeNum = new List<int>();
            for (int i = startRange; i < endRange; i++)
            {
                if ( NumericFunctions.IsPrime(i))
                {
                    primeNum.Add(i);
                }
            }
            return primeNum;
        }
        public static string Table( this NumericFunctions numericFunctions, int num)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= 10; i++)
            {
                sb.AppendLine($"{num} x {i} = {num * i}");
            }
            return sb.ToString();
        }
        public static List<string> TableRange( this NumericFunctions numericFunctions, int startRange, int endRange)
        {
            NumericFunctions num = new NumericFunctions();
            StringBuilder sb = new StringBuilder();
            List<string> tables = new List<string>();
            for (int i = startRange; i < endRange; i++)
            {
                sb.AppendLine($"table of {i}");
                sb.AppendLine(num.Table(i));
                tables.Add(sb.ToString());
            }
            return tables;
        }
        public static int RevNum(this NumericFunctions numericFunctions, int num)
        {
            int ans = 0;
            while (num > 0)
            {
                ans = ans * 10 + (ans % 10);
            }
            return ans;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = 10, num2 = 10;
            Console.WriteLine("enter first number");
            int.TryParse(Console.ReadLine(), out num1);
            Console.WriteLine("enter second number");
            int.TryParse(Console.ReadLine(), out num2);

            Console.WriteLine("sum: " + NumericFunctions.Add(num1, num2));
            Console.WriteLine("diffrence: " + NumericFunctions.Subtract(num1, num2));
            Console.WriteLine("product: " + NumericFunctions.Multiply(num1, num2));
            Console.WriteLine("quotient: " + NumericFunctions.Divide(num1, num2));

            Console.WriteLine("Max out of 231410 and 202123 is " + NumericFunctions.FindMax(231410, 202123));
            Console.WriteLine("Min out of 231410 and 202123 is " + NumericFunctions.FindMin(231410, 202123));

            int num = 8;
            if (NumericFunctions.CheckEven(num))
            {
                Console.WriteLine($"{num} is even");
            }
            else if (NumericFunctions.CheckOdd(num))
            {
                Console.WriteLine($"{num} is odd");
            }

            num = 35;
            if (NumericFunctions.IsPrime(num))
            {
                Console.WriteLine($"{num} is prime");
            }
            else
            {
                Console.WriteLine("not prime");
            }
            NumericFunctions numeric = new NumericFunctions();

            num1 = 2;
            num2 = 34;
            var ans = numeric.EvenNumbers(num1, num2);
            Console.WriteLine($"the even numbers between {num1} and {num2} are: ");
            foreach (var i in ans)
            {
                Console.Write(i + " ");
            }
            ans = numeric.OddNumbers(num1, num2);
            Console.WriteLine($"the odd numbers between {num1} and {num2} are: ");
            foreach (var i in ans)
            {
                Console.Write(i + " ");
            }
            ans = numeric.PrimeNumbers(num1, num2);
            Console.WriteLine($"the prime numbers between {num1} and {num2} are: ");
            foreach (var i in ans)
            {
                Console.Write(i + " ");
            }
            int n;
            Console.WriteLine("enter the number whose table you want to be displayed");
            n = byte.Parse(Console.ReadLine());
            string table = numeric.Table(n);
            Console.WriteLine(table);

            Console.WriteLine($"the tables from 1 to 10 of numbers between {num1} and {num2} are: ");
            List<string>allTables = numeric.TableRange(num1, num2);

            foreach(string tab in allTables)
            {
                Console.WriteLine(tab);
            }

            Console.WriteLine("enter number to reverse");
            int originalNum=int.Parse(Console.ReadLine());
            Console.WriteLine("reversed number is " + numeric.RevNum(originalNum));


            string sentence = "this is a test sentence 1234";
            Console.WriteLine($"the {sentence} has {StringFunctions.FindChars(sentence)} characters");

            string chkPalindrome = "NamaN";
            bool chk = StringFunctions.CheckPalindrome(chkPalindrome);
            if (chk == true)
            {
                Console.WriteLine($"the string {chkPalindrome} is palindrome");
            }
            else
            {
                Console.WriteLine("not palindrome");
            }

            Console.WriteLine($"this is sentence before reversing {sentence}");
            Console.WriteLine($"{StringFunctions.Reverse(sentence)} -----is after reversing");

            string countValues = StringFunctions.Counts(sentence);
            Console.WriteLine($"the {sentence} has following counts: ");
            Console.WriteLine(countValues);

            Console.WriteLine($"the {sentence} before using Upper method");
            Console.WriteLine($"after using the upper method\n{StringFunctions.Upper(sentence)}");


            Console.WriteLine($"the {sentence} before using Proper method");
            Console.WriteLine($"after using the Proper Mehtod\n{StringFunctions.Proper(sentence)}");

            string sentence2 = "this is another sentence to be joined";

            Console.WriteLine($"joining {sentence} and {sentence2} together using combine {StringFunctions.Combine(sentence,sentence2)}");

            string sentence3 = "This  is a sentence  with  a lot   of extra   spave";
            Console.WriteLine($"before removing extra spaces \n{sentence3}");

            Console.WriteLine($"After removing extra spaces ");

            string findingPat = "this";
            string statement = "this is my world, this world belongs to everyone";
            int repAns = StringFunctions.SubstringOccurances(statement,findingPat);
            Console.WriteLine($"the{findingPat} has {repAns} copies in {statement}");


        }
    }
}