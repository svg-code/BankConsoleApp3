using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp3
{
    class Amount
    {
        public string Name { get; set; }
        public int AccountNumber { get; set; }
        private string accountType;
        public string AccountType
        {
            get { return accountType; }
            set
            {
                if (value == "savings" || value == "current" || value == "corporate" || value == "fixed")
                {
                    accountType = value;
                }
                else
                {
                    Console.WriteLine("Invalid Account Type");    
                }
            }
        }
        public double Rate { get; set; }
        public double CompoundInterest { get; set; }
        public double Principal { get; set; }
       


        public void CalcAmount()

        {
            Console.WriteLine("Please enter your full name");
            Name = Console.ReadLine();
            Console.WriteLine("Please enter your account number");
            AccountNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter your account type: Savings, Current, Corporate or Fixed");
            AccountType = Console.ReadLine().ToLower();
            Console.WriteLine("Please enter principal");
            Principal = Convert.ToDouble(Console.ReadLine());



            switch (AccountType)
            {
                case "savings":
                    Rate = 0.006;
                    break;
                case "current":
                    Rate = 0.012;
                    break;
                case "corporate":
                    Rate = 0.024;
                    break;
                case "fixed":
                    Rate = 0.048;
                    break;
            }
            //Rate accrues per month

            //Am = Principal * (1 + R / n) ^ nt
            int[] numArray = { 6, 9, 12, 24, 60 };
            double Am;
            double finalAm;
            string output;
            for (int i = 0; i < numArray.Length; i++)
            {
                Am = Principal * Math.Pow((1 + Rate / numArray[i]), numArray[i] * numArray[i]);
                finalAm = DeductVAT(Am);
                output = $"Hi {Name}, In {numArray[i]} months, you will have {finalAm}";
                Console.WriteLine(output);
            }
        }

       public double DeductVAT(double num2)
        {
            return 0.925 * num2;
        } 
    }
}