using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectConsoleApp
{
    public class MyBloodBank : BloodBank
    {
        string type;

        public MyBloodBank()
        {
        }

        public MyBloodBank(string type)
        {
            this.type = type;
        }

        public MyBloodBank(string name, string gender, string address, string city, string country, string phoneNumber, int age, int weight, string bloodGroup, string donorType) : base(name, gender, address, city, country, phoneNumber, age, weight, bloodGroup, donorType)
        {
        }

        public string Type { get => type; set => type = value; }

        public override void AdditionalAction()
        {
            Console.WriteLine("");
        }
    }
}
