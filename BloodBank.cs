using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FinalProjectConsoleApp
{
    [Serializable]
    public abstract class BloodBank : IBloodBank
    {
        private string name;        
        private string gender;      
        private string address;
        private string city;
        private string country;
        private string phoneNumber;
        private int age;            
        private int weight;
        private string bloodGroup;
        private string donorType;
        private DonorDelegate myDel = null;

        public BloodBank()
        {
            SetupTheDelegate();
        }

        public BloodBank(string name, string gender, string address, string city, string country, string phoneNumber, int age, int weight, string bloodGroup, string donorType)
        {
            this.name = name;
            this.gender = gender;
            this.address = address;
            this.city = city;
            this.country = country;
            this.phoneNumber = phoneNumber;
            this.age = age;
            this.weight = weight;
            this.bloodGroup = bloodGroup;
            this.donorType = donorType;
            SetupTheDelegate();
        }

        public string Name { get => name; set => name = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string Country { get => country; set => country = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public int Age { get => age; set => age = value; }
        public int Weight { get => weight; set => weight = value; }
        public string BloodGroup { get => bloodGroup; set => bloodGroup = value; }
        public string DonorType { get => donorType; set => donorType = value; }
        [XmlIgnore]
        public DonorDelegate MyDel { get => myDel; set => myDel = value; }

        public int CompareTo(IBloodBank other)
        {
            return age.CompareTo(other.Age);    
        }

        public string PrepareString()
        {
            string fullType = GetType().ToString();
            string[] arrType = fullType.Split('.');
            return string.Format("Donor Type {0}, Donor Name: {1}, Age: {2}, Gender: {3}, Address: {4}, City: {5}, Country: {6}, Phone Number: {7}, Weight: {8}, Blood Group: {9}", DonorType, Name, Age, Gender, Address, City, Country, ViewMobileNumber, Weight, BloodGroup);
        }

        public override string ToString()
        {
            return string.Format("Donor Type {0}, Donor Name: {1}, Age: {2}, Gender: {3}, Address: {4}, City: {5}, Country: {6}, Phone Number: {7}, Weight: {8}, Blood Group: {9}", DonorType,Name, Age, Gender, Address, City, Country, ViewMobileNumber, Weight,BloodGroup);
        }
        public abstract void AdditionalAction();

        public void FreeCheckup()
        {
            Console.WriteLine("Free checkup provided to the donor");
        }
        public void RefreshmentProvided()
        {
            Console.WriteLine("Free Refreshment provided to the donor");
        }
        public void CertificationProvided()
        {
            Console.WriteLine("Certification of Donation is provided to the donor");
        }

        private void SetupTheDelegate() // Calling the methods
        {
            myDel += FreeCheckup;
            myDel += RefreshmentProvided;
            myDel += CertificationProvided;
            myDel += AdditionalAction;
        }


        public string ViewMobileNumber { get => MobileNumberMasking(); }

        private string MobileNumberMasking()   
        {
            string output = PhoneNumber;

            char[] mobileArray = output.ToCharArray();

            for (int i = 2; i < 8; i++)        
            {
                mobileArray[i] = 'X';
            }

            return new string(mobileArray);
        }
    }
}
