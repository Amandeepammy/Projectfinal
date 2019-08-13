using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectConsoleApp
{
    public enum DonorTypes
    {
        YetToDonate = 1,
        RegularDonor = 2,
        DonateOnNeedBasis = 3
    }
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public bool CheckName(string nameString)
        {
            bool result = true;
            string x = nameString;
            string[] authorsList = nameString.Split(' ');

            for (int i = 0; i < authorsList.Length; i++)
            {
                string s = authorsList[i];
                char[] arrayString = s.ToCharArray();
                for (int j = 0; j < arrayString.Length; j++)
                {
                    if (char.IsLetter(arrayString[j]))
                    {
                        result = true;
                        continue;
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }

            }
            return result;
        }

        public bool MoblieNumberValidation(string mobile)  
        {
            bool result = false;
            if (mobile != null && mobile.Length == 10)
            {
                char[] mobileArray = mobile.ToCharArray();
                int i = 0;
                while (i < mobileArray.Length)
                {
                    if (char.IsDigit(mobileArray[i]))
                    {
                        result = true;                       
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                    i++;
                }
            }
            return result;
        }
    }
}
