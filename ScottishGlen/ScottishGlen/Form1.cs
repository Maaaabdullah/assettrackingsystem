using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Management;
using System.Net;

namespace ScottishGlen
{
    public partial class Form1 : Form
    {

        static mssql2002690Entities3 scGlenDB = new mssql2002690Entities3();


        List<scottishGlen> AllData = new List<scottishGlen>();// empty list of All Data from DB


        IQueryable<scottishGlen> AllDataa = from d in scGlenDB.scottishGlens select d;





        public Form1()
        {
            InitializeComponent();
            setButtonAccoprdingly("");
            UpdateListView();


        }

        private void UpdateListView()
        {
            AllData.Clear();

            IQueryable<scottishGlen> AllDataa = from d in scGlenDB.scottishGlens select d;

            foreach (var data in AllDataa)
            {
                AllData.Add(data);
            }

            ListInformationFromTable(AllData);



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pcinfo.Text = "Your current PC stats: \n" + "Name: " + getName() + "\n"
                + "Model: " + getModel() + "\n" + "Manufacturer: " + getManu() + "\n"
                + "IP Address: " + getAddress() + "\n"
                + "Operating System: " + getOSName() + "\n"
                + "Operating System Version: " + getOSVersion() + "\n";
        }

        private void addAssetBTN_Click(object sender, EventArgs e)
        {
            addAssetPanel.Visible = true;

            setButtonAccoprdingly("Add");

            iname.Text = "System Name";
            imodel.Text = "Model";
            imanufacturer.Text = "Manufacturer";
            itype.Text = "Type";
            iIpAddress.Text = "IP Address";
            iPurchaseDate.Text = "Purchase Date";
            iExtraInfo.Text = "Extra Information";

            UpdateListView();

        }


        private void setButtonAccoprdingly(string button)
        {
            switch (button)
            {
                case "Add":
                    addbutton.Visible = true;
                    deleteBtn.Visible = false;
                    updatebtn.Visible = false;
                    break;
                case "Update":
                    addbutton.Visible = false;
                    deleteBtn.Visible = false;
                    updatebtn.Visible = true;
                    break;
                case "Delete":
                    addbutton.Visible = false;
                    deleteBtn.Visible = true;
                    updatebtn.Visible = false;
                    break;
                default:
                    addbutton.Visible = false;
                    deleteBtn.Visible = false;
                    updatebtn.Visible = false;
                    break;
            }
        }

        private void submitNewAssetForm_Click(object sender, EventArgs e)
        {
            scottishGlen newAsset = new scottishGlen();

            newAsset.name = iname.Text;
            newAsset.model = imodel.Text;
            newAsset.manufacturer = imanufacturer.Text;
            newAsset.type = itype.Text;
            newAsset.ipAddress = iIpAddress.Text;
            newAsset.purchaseDate = iPurchaseDate.Text;
            newAsset.extraInfo = iExtraInfo.Text;

            scGlenDB.scottishGlens.Add(newAsset);

            scGlenDB.SaveChanges();


            MessageBox.Show("You have successfully added an asset");

            iname.Text = "System Name";
            imodel.Text = "Model";
            imanufacturer.Text = "Manufacturer";
            itype.Text = "Type";
            iIpAddress.Text = "IP Address";
            iPurchaseDate.Text = "Purchase Date";
            iExtraInfo.Text = "Extra Information";

            UpdateListView();

        }


        //Get Name Function
        public string getName()
        {
            string name;

            name = Environment.MachineName;

            if (name != null)
            {
                return name;
            }
            else
            {
                return "Name: Unknown";
            }


        }


        //Get Model Function

        public string getModel()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");

            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Product").ToString();
                }

                catch { }

            }

            return "Model: Unknown";
        }


        //Get Manufacturer Function
        public string getManu()
        {

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");

            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Manufacturer").ToString();
                }

                catch { }

            }

            return "Board Maker: Unknown";


        }

        //Get IP ADDRESS Function

        public string getAddress()
        {

            // Get the Name of HOST  
            string hostName = Dns.GetHostName();

            // Get the IP from GetHostByName method
            string IP = Dns.GetHostByName(hostName).AddressList[0].ToString();

            if (IP != null)
            {
                return IP;
            }
            else
            {
                return "IP Address: Uknown";
            }
        }

        //Get operating system
        public string getOSName()
        {
         
            OperatingSystem os = Environment.OSVersion;

            return os.Platform.ToString();
        }

        //get OS Version
        public string getOSVersion()
        {
            OperatingSystem os = Environment.OSVersion;

            return os.Version.ToString();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            addAssetPanel.Visible = true;
            ListInformationFromTable(AllData);
            UpdateListView();

        }



        //List all info from DB
        void ListInformationFromTable(List<scottishGlen> Glen)
        {
            listView1.Items.Clear();
            foreach (var g in Glen)
            {
                ListViewItem newitem = new ListViewItem(g.id.ToString(), 0);

                //Check if data is null, to prevent errors

                if (g.name != null)
                {
                    newitem.SubItems.Add(g.name.ToString());
                }

                if (g.model != null)
                {
                    newitem.SubItems.Add(g.model.ToString());
                }

                if (g.manufacturer != null)
                {
                    newitem.SubItems.Add(g.manufacturer.ToString());
                }

                if (g.type != null)
                {
                    newitem.SubItems.Add(g.type.ToString());
                }

                if (g.ipAddress != null)
                {
                    newitem.SubItems.Add(g.ipAddress.ToString());
                }

                if (g.purchaseDate != null)
                {
                    newitem.SubItems.Add(g.purchaseDate.ToString());
                }

                if (g.extraInfo != null)
                {
                    newitem.SubItems.Add(g.extraInfo.ToString());
                }

                listView1.Items.Add(newitem);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                DisplaySelectedItemInField();

                string name = AllData[listView1.SelectedIndices[0]].name;
                string model = AllData[listView1.SelectedIndices[0]].model;
                string manufacturer = AllData[listView1.SelectedIndices[0]].manufacturer;
                string type = AllData[listView1.SelectedIndices[0]].type;
                string ipAddress = AllData[listView1.SelectedIndices[0]].ipAddress;
                string purchaseDate = AllData[listView1.SelectedIndices[0]].purchaseDate;
                string extraInfo = AllData[listView1.SelectedIndices[0]].extraInfo;

                //Diplay Stats in text
                rowInfotxt.Text = "Name: " + name
                + "\n Model: " + model + "\n Manufacturer: " +
                manufacturer + "\n Type : " + type + "\n IP Address: " + ipAddress +
                "\n Purchase Date: " + purchaseDate + "\n Extra Information: " + extraInfo;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Edit Item
            UpdateListView();
            setButtonAccoprdingly("Update");
            addAssetPanel.Visible = true;
            DisplaySelectedItemInField();
        }


        private void DisplaySelectedItemInField()
        {
            if (listView1.SelectedIndices.Count > 0)
            {

                int i = (int.Parse(listView1.SelectedItems[0].Text));
                scottishGlen inforlookup = (from p in scGlenDB.scottishGlens where p.id == i select p).FirstOrDefault<scottishGlen>();

                iname.Text = inforlookup.name;
                imodel.Text = inforlookup.model.ToString();
                imanufacturer.Text = inforlookup.manufacturer.ToString();
                itype.Text = inforlookup.type.ToString();
                iIpAddress.Text = inforlookup.ipAddress;
                iPurchaseDate.Text = inforlookup.purchaseDate;
                iExtraInfo.Text = inforlookup.extraInfo;



            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setButtonAccoprdingly("Delete");
            UpdateListView();
            addAssetPanel.Visible = true;
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            int i = (int.Parse(listView1.SelectedItems[0].Text));
            scottishGlen inforlookup = (from p in scGlenDB.scottishGlens where p.id == i select p).FirstOrDefault<scottishGlen>();

            inforlookup.name = iname.Text;
            inforlookup.model = imodel.Text;
            inforlookup.manufacturer = imanufacturer.Text;
            inforlookup.type = itype.Text;
            inforlookup.ipAddress = iIpAddress.Text;
            inforlookup.purchaseDate = iPurchaseDate.Text;
            inforlookup.extraInfo = iExtraInfo.Text;

            scGlenDB.SaveChanges();

            UpdateListView();

            MessageBox.Show("You have successfully updated an asset");

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {

                int i = (int.Parse(listView1.SelectedItems[0].Text));
                scottishGlen productLookUp = (from p in scGlenDB.scottishGlens
                                              where p.id == i
                                              select p).FirstOrDefault<scottishGlen>();
                scGlenDB.scottishGlens.Remove(productLookUp);
                scGlenDB.SaveChanges();

                MessageBox.Show("You have successfully deleted an asset");

            }

            UpdateListView();
        }
    }
}
