using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using FinalProjectConsoleApp;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Program p = new Program();
        ObservableCollection<MyBloodBank> displayDonors = null;
        DonorList list = new DonorList();
        MyBloodBank aDonor = new MyBloodBank();


        int age = 0, weight = 0, index=0;
        string donorTypes = string.Empty;


        public ObservableCollection<MyBloodBank> DisplayDonors { get => displayDonors; set => displayDonors = value; }
        public MyBloodBank ADonor { get => aDonor; set => aDonor = value; }

        public MainWindow()
        {
            InitializeComponent();
            ClearAllInputValues();
            comboGender.Items.Add("Male");
            comboGender.Items.Add("Female");

            comboBloodGroup.Items.Add("A+");
            comboBloodGroup.Items.Add("A-");
            comboBloodGroup.Items.Add("B+");
            comboBloodGroup.Items.Add("B-");
            comboBloodGroup.Items.Add("O+");
            comboBloodGroup.Items.Add("O-");
            comboBloodGroup.Items.Add("AB+");
            comboBloodGroup.Items.Add("AB-");

            comboBloodGroup1.Items.Add("A+");
            comboBloodGroup1.Items.Add("A-");
            comboBloodGroup1.Items.Add("B+");
            comboBloodGroup1.Items.Add("B-");
            comboBloodGroup1.Items.Add("O+");
            comboBloodGroup1.Items.Add("O-");
            comboBloodGroup1.Items.Add("AB+");
            comboBloodGroup1.Items.Add("AB-");

            string[] names = Enum.GetNames(typeof(DonorTypes));
            foreach (string name in names)
            {
                comboDonorType.Items.Add(name);
            }

            DisplayDonors = new ObservableCollection<MyBloodBank>();
            DataContext = this;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == string.Empty || txtAge.Text == string.Empty || txtAddress.Text == string.Empty || txtCity.Text == string.Empty || txtCountry.Text == string.Empty || txtPhoneNumber.Text == string.Empty || txtWeight.Text == string.Empty)
            {
                MessageBox.Show("Please fill-up all the TextBoxes");
            }
            else if (comboGender.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select the Gender");
            }
            else if (comboBloodGroup.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select the Blood Group");
            }
            else if (comboDonorType.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select The Donor Type");
            }
            else
            {
                bool result = true;
                if (!(p.CheckName(txtName.Text)))
                {
                    MessageBox.Show("Please Enter a Valid Name");
                    result = false;
                }
                else if (!(int.TryParse(txtAge.Text, out age) && age<=100))
                {
                    MessageBox.Show("Please enter Age Between 18-50 Years");
                    result = false;
                }
                else if (!(txtAddress.Text.Length >2))
                {
                    MessageBox.Show("Please enter a valid address");
                    result = false;
                }
                else if (!(p.CheckName(txtCity.Text)))
                {
                    MessageBox.Show("Please enter a valid City Name");
                    result = false;
                }
                else if (!(p.CheckName(txtCountry.Text)))
                {
                    MessageBox.Show("Please enter a valid Country Name");
                    result = false;
                }
                else if (!(p.MoblieNumberValidation(txtPhoneNumber.Text)))
                {
                    MessageBox.Show("Please Enter a Valid Phone Number of 10 Digits");
                    result = false;
                }
                else if (!(int.TryParse(txtWeight.Text, out weight) && weight <= 200))
                {
                    MessageBox.Show("Please enter weight between 45-200 Kgs");
                    result = false;
                }
                else if(result)
                {

                    string gender= (string)comboGender.Text;
                    string bloodGroups = (string)comboBloodGroup.Text;
                    MyBloodBank newDonor = new MyBloodBank();
                    newDonor.Name = txtName.Text;
                    newDonor.Age = age;
                    newDonor.Gender = (string)comboGender.Text;
                    newDonor.Address = txtAddress.Text;
                    newDonor.City = txtCity.Text;
                    newDonor.Country = txtCountry.Text;
                    newDonor.PhoneNumber = txtPhoneNumber.Text;
                    newDonor.Weight = weight;
                    newDonor.BloodGroup = (string)comboBloodGroup.Text;
                    newDonor.Type = donorTypes;                
                    BloodBank donorss = null;
                    switch (comboDonorType.SelectedIndex)
                    {
                        case 0:
                            donorss = new YetToDonate(txtName.Text,gender,txtAddress.Text, txtCity.Text, txtCountry.Text,txtPhoneNumber.Text,age,weight,bloodGroups, donorTypes);
                            break;
                        case 1:
                        donorss = new RegularDonor(txtName.Text, gender, txtAddress.Text, txtCity.Text, txtCountry.Text, txtPhoneNumber.Text, age, weight, bloodGroups, donorTypes);
                            break;
                        case 2:
                        donorss = new DonateOnNeedBasis(txtName.Text, gender, txtAddress.Text, txtCity.Text, txtCountry.Text, txtPhoneNumber.Text, age, weight, bloodGroups, donorTypes);
                            break;
                        default:
                            MessageBox.Show("Program Error");
                            return;
                    }
                    DisplayDonors.Add(newDonor);
                    MyGrid.IsEnabled = true;
                    ClearAllInputValues();

                    if (age < 18 || age > 50 || weight < 45)
                    {

                        label1.Content = "Donors of Age Below 18 Years and Above 50 Years are consider as weak donors \nAlso, Donors having Weight Below 45 Kgs are consider as Weak Donors \nPerson who are not considered as Donor are marked with Red Color in the Grid ";
                    }

                }
            }

        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (MyGrid.IsEnabled == true)
            {
                SaveButton();
                MessageBox.Show("Entries saved to XML file");
            }
            else
            {
                MessageBox.Show("There is no entry in the grid to save!");
            }
        }

        private void BtnDisplay_Click(object sender, RoutedEventArgs e)
        {
            MyGrid.IsEnabled = true;
            list.Clear();
            ReadFromFile();
            DisplayDonors.Clear();
            for (int i = 0; i < list.Count(); i++)
            {
                MyBloodBank donors = list[i];
                DisplayDonors.Add(donors);
            }
            MyGrid.ItemsSource = DisplayDonors;
            index = -1;
        }

        private void WriteToFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DonorList));
            TextWriter tw = new StreamWriter("Donors.xml");
            serializer.Serialize(tw, list);
            tw.Close();
        }

        private void ComboDonorType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DonorTypes myEnum = (DonorTypes)comboDonorType.SelectedIndex + 1;
            switch (myEnum)
            {
                case DonorTypes.YetToDonate:
                    donorTypes = "Yet To Donate";
                    break;

                case DonorTypes.RegularDonor:
                    donorTypes = "Regular Donor";
                    break;

                case DonorTypes.DonateOnNeedBasis:
                    donorTypes = "Donate On Need Basis";
                    break;

                default:
                    //MessageBox.Show("Wrong choice");
                    break;
            }
        }

        private void BtnSearch1_Click(object sender, RoutedEventArgs e)
        {
            MyGrid.IsEnabled = true;
            if (txtSearch.Text == String.Empty)
            {
                MessageBox.Show("Please type name to search");
            }
            else
            {
                list.Clear();
                ReadFromFile();
                DisplayDonors.Clear();
                for (int i = 0; i < list.Count(); i++)
                {
                    MyBloodBank donors = list[i];
                    DisplayDonors.Add(donors);
                }
                //MyGrid.ItemsSource = DisplayDonors;
                var query = from donors in DisplayDonors
                            where donors.Name.ToLower() == txtSearch.Text.ToLower().Trim()
                            select donors;
                MyGrid.ItemsSource = query;
            }

        }

        private void BtnSearch2_Click(object sender, RoutedEventArgs e)
        {
            MyGrid.IsEnabled = true;
            if (comboBloodGroup1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select blood group to search");
            }
            else
            {
                list.Clear();
                ReadFromFile();
                DisplayDonors.Clear();
                for (int i = 0; i < list.Count(); i++)
                {
                    MyBloodBank donors = list[i];
                    DisplayDonors.Add(donors);
                }
                //MyGrid.ItemsSource = DisplayDonors;
                var query = from donors in DisplayDonors
                            where donors.BloodGroup == comboBloodGroup1.Text
                            select donors;
                MyGrid.ItemsSource = query;
            }
        }

        private void ReadFromFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DonorList));
            TextReader tr = new StreamReader("Donors.xml");
            list = (DonorList)serializer.Deserialize(tr);
            tr.Close();
        }

        private void MyGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MyGrid.SelectedIndex >= 0)
            {            
                index = MyGrid.SelectedIndex;
 
            aDonor = DisplayDonors[MyGrid.SelectedIndex];
            txtName.Text = aDonor.Name;
            txtAge.Text = aDonor.Age.ToString();
            comboGender.Text = aDonor.Gender;
            txtAddress.Text = aDonor.Address;
            txtCity.Text = aDonor.City;
            txtCountry.Text = aDonor.Country;
            txtPhoneNumber.Text = aDonor.PhoneNumber;
            txtWeight.Text = aDonor.Weight.ToString();
            comboBloodGroup.Text = aDonor.BloodGroup;
            string abc = aDonor.Type;
            if (abc == "Yet To Donate")
            {
                comboDonorType.Text = "YetToDonate";
            }
            else if (abc == "Regular Donor")
            {
                comboDonorType.Text = "RegularDonor";
            }
            else if (abc == "Donate On Need Basis")
            {
                comboDonorType.Text = "DonateOnNeedBasis";
            }
            
            btnAdd.Visibility = Visibility.Collapsed;
            btnUpdate.Visibility = Visibility.Visible;
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

            if (MyGrid.IsEnabled == true)
            {
                if (index >= 0)
                {
                    if (MessageBox.Show("Do you want to delete this entry", "Alert", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        displayDonors.Remove(displayDonors[index]);
                        SaveButton();
                        ClearAllInputValues();
                        btnAdd.Visibility = Visibility.Visible;
                        btnUpdate.Visibility = Visibility.Collapsed;
                        index = -1;
                    }
                    else
                    {
                        BtnDisplay_Click(null, null);
                        ClearAllInputValues();
                        btnAdd.Visibility = Visibility.Visible;
                        btnUpdate.Visibility = Visibility.Collapsed;
                    }
                }
                else
                {
                    MessageBox.Show("Please select an entry to delete");
                }
            }
            else
            {
                MessageBox.Show("Data Grid doesn't have any entry to delete");
            }
            
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (index >=0)
            {
                MyGrid.IsEnabled = true;
                displayDonors.Remove(displayDonors[MyGrid.SelectedIndex]);
                BtnAdd_Click(null,null);
                BtnSave_Click(null, null);
                btnAdd.Visibility = Visibility.Visible;
                btnUpdate.Visibility = Visibility.Collapsed;
                index = -1;
            }
        }

        public void ClearAllInputValues()
        {
            txtName.Text = "";
            txtAge.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtCountry.Text = "";
            txtPhoneNumber.Text = "";
            txtWeight.Text = "";
            comboDonorType.SelectedIndex = -1;
            comboBloodGroup.SelectedIndex = -1;
            comboGender.SelectedIndex = -1;
        }
        public void SaveButton()
        {
            list.Clear();
            foreach (MyBloodBank donors in DisplayDonors)
            {
                BloodBank bloodBank = null;

                switch (donors.Type)
                {
                    case "Yet To Donate":
                        bloodBank = new YetToDonate(donors.Name, donors.Gender, donors.Address, donors.City, donors.Country, donors.PhoneNumber, donors.Age, donors.Weight, donors.BloodGroup, donors.DonorType);
                        break;
                    case "Regular Donor":
                        bloodBank = new RegularDonor(donors.Name, donors.Gender, donors.Address, donors.City, donors.Country, donors.PhoneNumber, donors.Age, donors.Weight, donors.BloodGroup, donors.DonorType);
                        break;
                    case "Donate On Need Basis":
                        bloodBank = new DonateOnNeedBasis(donors.Name, donors.Gender, donors.Address, donors.City, donors.Country, donors.PhoneNumber, donors.Age, donors.Weight, donors.BloodGroup, donors.DonorType);
                        break;
                    default:
                        MessageBox.Show("Program Error");
                        return;
                }
                list.Add(donors);
            }
            WriteToFile();
        }
    }
}
