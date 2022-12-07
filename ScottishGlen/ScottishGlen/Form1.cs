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


        List<scottishGlen> AllData = new List<scottishGlen>();// empty list of Hardware All Data from DB

        List<scottishGlenSoftware> AllSWData = new List<scottishGlenSoftware>();// empty list of software All Data from DB


        IQueryable<scottishGlen> AllDataa = from d in scGlenDB.scottishGlens select d;


        IQueryable<scottishGlenSoftware> AllSWDataa = from d in scGlenDB.scottishGlenSoftwares select d;




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

        private void UpdateSWListView()
        {
            AllSWData.Clear();

            IQueryable<scottishGlenSoftware> AllSWDataa = from d in scGlenDB.scottishGlenSoftwares select d;

            foreach (var data in AllSWDataa)
            {
                AllSWData.Add(data);
            }

            ListSWInformationFromTable(AllSWData);


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pcinfo.Text = "Your current PC stats: \n" + "Name: " + getName() + "\n"
                + "Model: " + getModel() + "\n" + "Manufacturer: " + getManu() + "\n"
                + "IP Address: " + getAddress() + "\n"
                + "Operating System: " + getOSName() + "\n"
                + "Operating System Version: " + getOSVersion() + "\n"
                + "Operating System Manufcaturer: " + getOSManu() + "\n";
        }

        private void addAssetBTN_Click(object sender, EventArgs e)
        {
            addAssetPanel.Visible = true;

            setButtonAccoprdingly("Add");

            iname.Text = getName();
            imodel.Text = getModel();
            imanufacturer.Text = getManu();
            itype.Text = "Type";
            iIpAddress.Text = getAddress();
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

        private void setButtonSWAccoprdingly(string button)
        {
            switch (button)
            {
                case "Add":
                    addbuttonsw.Visible = true;
                    deleteBtnsw.Visible = false;
                    updatebtnsw.Visible = false;
                    break;
                case "Update":
                    addbuttonsw.Visible = false;
                    deleteBtnsw.Visible = false;
                    updatebtnsw.Visible = true;
                    break;
                case "Delete":
                    addbuttonsw.Visible = false;
                    deleteBtnsw.Visible = true;
                    updatebtnsw.Visible = false;
                    break;
                default:
                    addbuttonsw.Visible = false;
                    deleteBtnsw.Visible = false;
                    updatebtnsw.Visible = false;
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

        //get OS Manufcaturer
        public string getOSManu()
        {
            OperatingSystem os = Environment.OSVersion;

            return os.ToString();


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



        //List Software all info from DB
        void ListSWInformationFromTable(List<scottishGlenSoftware> Glen)
        {
            listView2.Items.Clear();
            foreach (var g in Glen)
            {
                ListViewItem newitem = new ListViewItem(g.id.ToString(), 0);

                //Check if data is null, to prevent errors

                if (g.operatingSystemName != null)
                {
                    newitem.SubItems.Add(g.operatingSystemName.ToString());
                }

                if (g.version != null)
                {
                    newitem.SubItems.Add(g.version.ToString());
                }

                if (g.manufacturer != null)
                {
                    newitem.SubItems.Add(g.manufacturer.ToString());
                }

                listView2.Items.Add(newitem);
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


        private void DisplaySWSelectedItemInField()
        {
            if (listView2.SelectedIndices.Count > 0)
            {

                int i = (int.Parse(listView2.SelectedItems[0].Text));
                scottishGlenSoftware inforlookup = (from p in scGlenDB.scottishGlenSoftwares where p.id == i select p).FirstOrDefault<scottishGlenSoftware>();

                iname.Text = inforlookup.operatingSystemName;
                imodel.Text = inforlookup.version.ToString();
                imanufacturer.Text = inforlookup.manufacturer.ToString();

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

        //Add Software INFO
        private void button4_Click(object sender, EventArgs e)
        {
            addAssetPanel2.Visible = true;

            setButtonSWAccoprdingly("Add");

            inamesw.Text = getOSName();
            iversionsw.Text = getOSVersion();
            imanusw.Text = getOSManu();

            UpdateSWListView();
        }

        //View Software INFO
        private void button5_Click(object sender, EventArgs e)
        {
            addAssetPanel2.Visible = true;
            ListSWInformationFromTable(AllSWData);
            UpdateSWListView();
        }

        //Update Software INFO
        private void button10_Click(object sender, EventArgs e)
        {
            //Edit Item
            UpdateSWListView();
            setButtonSWAccoprdingly("Update");
            addAssetPanel2.Visible = true;
            DisplaySWSelectedItemInField();
        }

        //Delete Software INFO
        private void button9_Click(object sender, EventArgs e)
        {
            setButtonSWAccoprdingly("Delete");
            UpdateSWListView();
            addAssetPanel2.Visible = true;
        }

        //Addtrigger Button
        private void button8_Click(object sender, EventArgs e)
        {
            scottishGlenSoftware newAsset = new scottishGlenSoftware();

            newAsset.operatingSystemName = inamesw.Text;
            newAsset.version = iversionsw.Text;
            newAsset.manufacturer = imanusw.Text;


            scGlenDB.scottishGlenSoftwares.Add(newAsset);

            scGlenDB.SaveChanges();


            MessageBox.Show("You have successfully added an asset");

            iname.Text = "OS Name";
            imodel.Text = "OS Version";
            imanufacturer.Text = "OS Manufacturer";
           

            UpdateSWListView();
        }


        //Update Trigger Button
        private void button7_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedIndices.Count > 0)
            {
                int i = (int.Parse(listView2.SelectedItems[0].Text));
                scottishGlenSoftware inforlookup = (from p in scGlenDB.scottishGlenSoftwares where p.id == i select p).FirstOrDefault<scottishGlenSoftware>();

                inforlookup.operatingSystemName = inamesw.Text;
                inforlookup.version = iversionsw.Text;
                inforlookup.manufacturer = imanusw.Text;



                scGlenDB.SaveChanges();

                UpdateSWListView();

                MessageBox.Show("You have successfully updated an asset");
            }
            else
            {
                MessageBox.Show("You must select an asset");
            }
        }

        //Delete Trigger Button
        private void button6_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedIndices.Count > 0)
            {

                int i = (int.Parse(listView2.SelectedItems[0].Text));
                scottishGlenSoftware productLookUp = (from p in scGlenDB.scottishGlenSoftwares
                                              where p.id == i
                                              select p).FirstOrDefault<scottishGlenSoftware>();
                scGlenDB.scottishGlenSoftwares.Remove(productLookUp);
                scGlenDB.SaveChanges();

                MessageBox.Show("You have successfully deleted an asset");

            }
            else
            {
                MessageBox.Show("You must select an asset");
            }

            UpdateSWListView();
        }

        private void hardwarebtn_Click(object sender, EventArgs e)
        {
            hardwarePanel.Visible = true;
            softwarePanel.Visible = false;
        }

        private void softwarebtn_Click(object sender, EventArgs e)
        {
            hardwarePanel.Visible = false;
            softwarePanel.Visible = true;
        }
    }
}
