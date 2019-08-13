using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FinalProjectConsoleApp
{
    [XmlRoot("Donors")]
    [XmlInclude(typeof(RegularDonor))]
    [XmlInclude(typeof(YetToDonate))]
    [XmlInclude(typeof(DonateOnNeedBasis))]

    public class DonorList : IDisposable
    {
        private List<MyBloodBank> donors = null;   //creating the list of Donors

        public DonorList()
        {
            donors = new List<MyBloodBank>();
        }

        [XmlArray("Donor")]
        [XmlArrayItem("Donors", typeof(MyBloodBank))]
        public List<MyBloodBank> Donors { get => donors; set => donors = value; }


        public void Add(MyBloodBank donor)     // method to input value in the list
        {
            Donors.Add(donor);
        }
        public void Remove(MyBloodBank donor)  //method to remove values from list
        {
            Donors.Remove(donor);
        }

        public int Count()          // count the total values in the list
        {
            return Donors.Count();
        }

        public void Dispose()       // Method is used to Speedup the Grabage Collecting Process
        {
            GC.SuppressFinalize(this);
        }

        public MyBloodBank this[int i]     // indexer is used to hold all the events.
        {
            get { return Donors[i]; }
        }

        public void Sort()      // Sort the list
        {
            Donors.Sort();
        }
        public void Clear()
        {
            Donors.Clear();
        }
    }
}
