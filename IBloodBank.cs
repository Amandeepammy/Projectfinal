using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectConsoleApp
{
    public delegate void DonorDelegate();
    public interface IBloodBank : IComparable<IBloodBank>
    {
        string Name { get; set; }
        string Gender { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string Country { get; set; }
        string PhoneNumber { get; set; }
        int Age { get; set; }
        int Weight { get; set; }
        string BloodGroup { get; set; }
        string DonorType { get; set; }

        DonorDelegate MyDel { get; set; }

        void AdditionalAction();
    }
}
