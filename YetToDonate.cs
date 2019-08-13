using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectConsoleApp
{
    public class YetToDonate : BloodBank
    {
        public YetToDonate()
        {
        }

        public YetToDonate(string name, string gender, string address, string city, string country, string phoneNumber, int age, int weight, string bloodGroup, string donorType) : base(name, gender, address, city, country, phoneNumber, age, weight, bloodGroup, donorType)
        {
        }

        public override void AdditionalAction()
        {
            Console.WriteLine("Membership Card Provided");
        }
        public override string ToString()
        {
            return PrepareString();
        }
    }
}
