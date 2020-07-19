using System;
using System.Collections.Generic;

namespace TestNarcissisticNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            SuccessfulMessage();
            string str;
            long number;
            List<long> results = new List<long>();
            while(true)
            {
                StartMessage();

                str = Console.ReadLine();
                switch (str)
                {
                    case "0":
                        break;
                    case "1":
                        Console.Write("Enter your number: ");
                        number = EnterNumber();
                        Console.WriteLine(TestNarcissiticString(
                            TestNarcissiticBoolean(StringToLongArray(number.ToString()))));
                        continue;
                    case "2":
                        var myArray = ArrayAlreadyExists();
                        PrintArray(myArray);
                        continue;
                    case "3":
                        FourthAndThirdPart(false);
                        continue;
                    case "4":
                        FourthAndThirdPart(true);
                        continue;
                    default:
                        continue;
                }
                break;
            }
        }
        private static void FourthAndThirdPart(bool flag)
        {
            long order;
            long limit = 0;
            long limitPower = 0;
            long startPoint;
            List<long> results = new List<long>();
            while (true)
            {
                Console.Write("Enter order (order >= 3): ");
                order = EnterNumber();
                if (order >= 3)
                    break;
            }
            while (flag == false)
            {
                Console.Write("Enter limit (limit > order || limit is a 10Power): ");
                limitPower = EnterNumber(); // 100000000000000000
                limit = (long)Math.Pow(10, limitPower);
                if (limit > order)
                    break;
            }
            if (flag == true)
                limit = 100000000000000000;
            startPoint = (long)Math.Pow(10, order - 1);
            for (long k = startPoint; k < limit; k++)
            {
                if (TestNarcissiticBoolean(StringToLongArray(k.ToString())) == true)
                    results.Add(k);
            }
            PrintList(results);
        }
        private static string TestNarcissiticString(bool flag)
        {
            if (flag == true)
                return "This is a narcissitic number.";
            else 
                return "This is not a narcissitic number!!!!";
        }
        private static bool TestNarcissiticBoolean(long[] array)
        {
            long first = FirstPart(array);
            long second = SecondPart(array);
            if (first == second)
                return true;
            else return false;
        }
        private static long SecondPart(long[] array)
        {
            long n = array.Length;
            long[] arr = new long[n];
            long sum = 0;
            for (long i = 0; i < arr.Length; i++)
            {
                arr[i] = (long)Math.Pow(10, n - 1 - i) * array[i];
                sum = sum + arr[i];
            }
            return sum;
        }
        private static long FirstPart(long[] array)
        {
            long n = array.Length;
            long[] arr = new long[n];
            long sum = 0;
            for (long i = 0; i < arr.Length; i++)
            {
                arr[i] = (long)Math.Pow(array[i], n);
                sum = sum + arr[i];
            }
            return sum;
        }
        private static long[] StringToLongArray(string str)
        {
            var tempStr = " ";
            var nums = new long[str.Length];
            try
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    tempStr = str[i].ToString();
                    nums[i] = long.Parse(tempStr);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message+": FATAL ERROR!!!!");
                return nums;
            }
            return nums;
        }
        
        private static long EnterNumber()
        {
            long a = 0;
            try
            {
                a = long.Parse(Console.ReadLine());
                if (a < 1)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message +": Enter number >1");
                return EnterNumber();
            }
            return a;
        }
        private static string[] ArrayAlreadyExists()
        {
            string[] arr = new string[19];
            arr[0] = "146511208";
            arr[1] = "472335975";
            arr[2] = "534494836";
            arr[3] = "912985153";
            arr[4] = "4679307774";
            arr[5] = "123456789";
            arr[6] = "1234056789";
            arr[7] = "9753124680";
            arr[8] = "32164049650";
            arr[9] = "44708635679";
            arr[10] = "28116440335967";
            arr[11] = "4338281769391371";         // --> Last successful naracissitic number
            arr[12] = "1517841543307505039";      // ???? this is a naracissitic number
            arr[13] = "4498128791164624869";      // ???? this is a naracissitic number
            arr[14] = "63105425988599693916";     // ???? this is a naracissitic number
            arr[15] = "128468643043731391252";    // ???? this is a naracissitic number
            arr[16] = "21887696841122916288858";  // ???? this is a naracissitic number
            arr[17] = "188451485447897896036875"; // ???? this is a naracissitic number
            arr[18] = "4338281769391370";         // --> Last successful naracissitic number
            return arr;
        }
        private static void PrintArray(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i] + "         " + TestNarcissiticString(TestNarcissiticBoolean(
                    StringToLongArray(arr[i]))));
                Console.WriteLine(" ");
            }
        }
        private static void PrintList(List<long> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        private static void StartMessage()
        {
            Console.WriteLine(" ");
            Console.WriteLine("(0)........................Exit");
            Console.WriteLine("(1)........................Test your number");
            Console.WriteLine("(2)........................Test an array already exists");
            Console.WriteLine("(3)........................Show list of narcissitic numbers(order >= 3)");
            Console.WriteLine("(4)........................Show list of narcissitic numbers(order >= 3) with a max limit");
            Console.WriteLine(" ");
        }
        private static void SuccessfulMessage()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Last successful naracissitic number(4338281769391371 , 4338281769391370)");
            Console.WriteLine($"It fails after order = ({"4338281769391371".Length}) for already array exist");
            Console.WriteLine($"It fails after order = (9) for other parts .. I waited for 3 hours for order = (10)");
            Console.WriteLine(",and the program still running!!!!!!!!!!!!!!!");
            Console.WriteLine(" ");
        }
    }
}
