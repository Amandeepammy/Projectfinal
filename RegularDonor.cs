using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectConsoleApp
{
    public class RegularDonor : BloodBank
    {
        public RegularDonor()
        {
        }

        public RegularDonor(string name, string gender, string address, string city, string country, string phoneNumber, int age, int weight, string bloodGroup, string donorType) : base(name, gender, address, city, country, phoneNumber, age, weight, bloodGroup, donorType)
        {
        }

        public override void AdditionalAction()
        {
            Console.WriteLine("Free Medical Treatment provided, if necessary");
        }
        public override string ToString()
        {
            return PrepareString();
        }
    }
}
