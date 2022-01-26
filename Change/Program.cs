using System;
using System.Collections;

namespace ChangeApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        private static readonly int[] coins = new int[] { 100, 50, 20, 10, 5, 2, 1 };
        static void Main(string[] args)
        {
            //Testing see debug command args 
            //Array.Resize(ref args, args.Length + 1);
            //args[0] = "488";

            if (args.Length == 0 || string.IsNullOrWhiteSpace(args[0]))
            {
                throw new ArgumentNullException("No change provided");
            }

            if (!int.TryParse(args[0], out int n))
            {
                throw new ArgumentException("Received letters not number");
            }

            var changeDemoninations = GetChangeDenominations(n);
            for (int i = 0; i < changeDemoninations.Length; i++)
            {
                Console.WriteLine($"Number of {coins[i]} coins reqiured {changeDemoninations[i]}");
            }
            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }

        static int[] GetChangeDenominations(int change)
        {
            List<int> denominations = new();
            int howMany = 0;
            int currentChangevalue = change;
            for (int i = 0; i < coins.Length; i++)
            {
                // need to assign to new variable
                
                if (coins[i]<=currentChangevalue)
                {
                    
                    denominations.Add(GetChangeDenomination(coins[i],ref currentChangevalue, ref howMany));
                   currentChangevalue -= (coins[i]*howMany);



                }
                else
                {
                    denominations.Add(0);
                }
            }
            
            return denominations.ToArray();
        }
        
        static int GetChangeDenomination(int denomination, ref int change, ref int howMany )
        {
            howMany = Convert.ToInt32(change / denomination);
            return Convert.ToInt32((change)/denomination);                
        }

    }
}
