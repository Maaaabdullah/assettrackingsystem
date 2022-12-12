using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Net;
using System.Security.Cryptography;
using System.ServiceModel.Syndication;
using System.Xml;
using RestSharp;
using BCrypt.Net;

namespace ScottishGlen
{

    public partial class Form1 : Form
    {

        static mssql2002690Entities3 scGlenDB = new mssql2002690Entities3();


        List<scottishGlen> AllData = new List<scottishGlen>();// empty list of Hardware All Data from DB

        List<scottishGlenSoftware> AllSWData = new List<scottishGlenSoftware>();// empty list of software All Data from DB


        IQueryable<scottishGlen> AllDataa = from d in scGlenDB.scottishGlens select d; //query with HW data


        IQueryable<scottishGlenSoftware> AllSWDataa = from d in scGlenDB.scottishGlenSoftwares select d; //query with sw data


        scottishGlenAccount loggedinAccount = null;

        bool addSfowtareTrigger = false;
        string hwName = null;
        int lastId = 0;


        public Form1()
        {
            //Init
            InitializeComponent();
            setButtonAccoprdingly("");
            UpdateListView();
            UpdateSWListView();
            AccountPanel.Visible = false;

           

        }

        private void verificateAccouting()
        {
            //verificate account
            if(loggedinAccount != null)
            {
                mmpanel.Visible = true;
                loginPanel.Visible = false;
                registerPanel.Visible = false;
            }
        }

        private void UpdateListView()
        {
            //Update HW Assets list
            AllData.Clear();

            IQueryable<scottishGlen> AllDataa = from d in scGlenDB.scottishGlens select d;

            //add to list
            foreach (var data in AllDataa)
            {
                AllData.Add(data);
            }

            //display at listview (refresh)
            ListInformationFromTable(AllData);


        }

        private void UpdateSWListView()
        {
            //Update SW Assets list

            AllSWData.Clear();

            IQueryable<scottishGlenSoftware> AllSWDataa = from d in scGlenDB.scottishGlenSoftwares select d;

            //add to list
            foreach (var data in AllSWDataa)
            {
                AllSWData.Add(data);
            }

            //display at listview (refresh)
            ListSWInformationFromTable(AllSWData);


        }

        private void UpdateSWLNVDistView()
        {
            //display at NVD section (if user wants to check against NVD a specific stored asset)

            AllSWData.Clear();

            IQueryable<scottishGlenSoftware> AllSWDataa = from d in scGlenDB.scottishGlenSoftwares select d;

            foreach (var data in AllSWDataa)
            {
                AllSWData.Add(data);
            }

            //display at listview (refresh)
            ListSWInformationFromTableNVD(AllSWData);


        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //State current pc stats
            pcinfo.Text = "Your current PC stats: \n" + "Name: " + getName() + "\n"
                + "Model: " + getModel() + "\n" + "Manufacturer: " + getManu() + "\n"
                + "IP Address: " + getAddress() + "\n"
                + "Operating System: " + getOSName() + "\n"
                + "Operating System Version: " + getOSVersion() + "\n"
                + "Operating System Manufcaturer: " + getOSManu() + "\n";
        }

        private void addAssetBTN_Click(object sender, EventArgs e)
        {

            //Add HW asset

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
            //Sett buttons for HW Panel
            switch (button)
            {
                case "Add":
                    addbutton.Visible = true;
                    deleteBtn.Visible = false;
                    updatebtn.Visible = false;
                    addsftbtn.Visible = false;
                    break;
                case "Update":
                    addbutton.Visible = false;
                    deleteBtn.Visible = false;
                    updatebtn.Visible = true;
                    addsftbtn.Visible = true;
                    break;
                case "Delete":
                    addbutton.Visible = false;
                    deleteBtn.Visible = true;
                    updatebtn.Visible = false;
                    addsftbtn.Visible = false;
                    break;
                default:
                    addbutton.Visible = false;
                    deleteBtn.Visible = false;
                    updatebtn.Visible = false;
                    addsftbtn.Visible = false;
                    break;
            }
        }

        private void setButtonSWAccoprdingly(string button)
        {
            //Sett buttons for SW Panel

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
            //Adding an Asset (Trigger Function)

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
         
          //  OperatingSystem os = Environment.Version;

          //  return os.Platform.ToString();

            var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().OfType<ManagementObject>()
                        select x.GetPropertyValue("Caption")).FirstOrDefault();
            return name != null ? name.ToString() : "Unknown";
        }

        //get OS Version
        public string getOSVersion()
        {
            OperatingSystem os = Environment.OSVersion;

            if(os.Version == null)
            {
                return "Unknown";
            }

            return os.Version.ToString();


        }

        //get OS Manufcaturer
        public string getOSManu()
        {
            OperatingSystem os = Environment.OSVersion;

            if (os == null)
            {
                return "Unknown";
            }


            return os.ToString();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Add asset panel

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
                if (g.softwareId != null)
                {
                    newitem.SubItems.Add(g.softwareId.ToString());
                }
                else
                {
                    newitem.SubItems.Add("");
                }

                if (g.name != null)
                {
                    newitem.SubItems.Add(g.name.ToString());
                }
                else
                {
                    newitem.SubItems.Add("");
                }

                if (g.model != null)
                {
                    newitem.SubItems.Add(g.model.ToString());
                }
                else
                {
                    newitem.SubItems.Add("");
                }

                if (g.manufacturer != null)
                {
                    newitem.SubItems.Add(g.manufacturer.ToString());
                }
                else
                {
                    newitem.SubItems.Add("");
                }

                if (g.type != null)
                {
                    newitem.SubItems.Add(g.type.ToString());
                }
                else
                {
                    newitem.SubItems.Add("");
                }

                if (g.ipAddress != null)
                {
                    newitem.SubItems.Add(g.ipAddress.ToString());
                }

                if (g.purchaseDate != null)
                {
                    newitem.SubItems.Add(g.purchaseDate.ToString());
                }
                else
                {
                    newitem.SubItems.Add("");
                }

                if (g.extraInfo != null)
                {
                    newitem.SubItems.Add(g.extraInfo.ToString());
                }
                else
                {
                    newitem.SubItems.Add("");
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
                else
                {
                    newitem.SubItems.Add("");
                }

                if (g.version != null)
                {
                    newitem.SubItems.Add(g.version.ToString());
                }
                else
                {
                    newitem.SubItems.Add("");
                }

                if (g.manufacturer != null)
                {
                    newitem.SubItems.Add(g.manufacturer.ToString());
                }
                else
                {
                    newitem.SubItems.Add("");
                }

                if (g.hardwareName != null)
                {
                    newitem.SubItems.Add(g.hardwareName.ToString());
                }
                else
                {
                    newitem.SubItems.Add("");
                }


                listView2.Items.Add(newitem);
            }
        }

        //List Software all info from DB TO NVD Panel
        void ListSWInformationFromTableNVD(List<scottishGlenSoftware> Glen)
        {
            listView4.Items.Clear();
            foreach (var g in Glen)
            {
                ListViewItem newitem = new ListViewItem(g.id.ToString(), 0);

                //Check if data is null, to prevent errors

                if (g.operatingSystemName != null)
                {
                    newitem.SubItems.Add(g.operatingSystemName.ToString());
                }
                else
                {
                    newitem.SubItems.Add("");
                }

                if (g.version != null)
                {
                    newitem.SubItems.Add(g.version.ToString());
                }
                else
                {
                    newitem.SubItems.Add("");
                }

                if (g.manufacturer != null)
                {
                    newitem.SubItems.Add(g.manufacturer.ToString());
                }
                else
                {
                    newitem.SubItems.Add("");
                }

                if (g.hardwareName != null)
                {
                    newitem.SubItems.Add(g.hardwareName.ToString());
                }
                else
                {
                    newitem.SubItems.Add("");
                }


                listView4.Items.Add(newitem);
            }
        }

        //Update which item the user has selected
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

                lastId = (int.Parse(listView1.SelectedItems[0].Text));
            }
        }


        //Edit Item
        private void button2_Click(object sender, EventArgs e)
        {
          
            if (listView1.SelectedIndices.Count > 0)
            {
                //Edit Item
                UpdateListView();
                setButtonAccoprdingly("Update");
                addAssetPanel.Visible = true;
                DisplaySelectedItemInField();

                scottishGlen inforlookup = (from p in scGlenDB.scottishGlens where p.id == lastId select p).FirstOrDefault<scottishGlen>();

                hwName = inforlookup.name;
            }
            else
            {
                MessageBox.Show("You must select an asset");
            }
        }

        //Display item in field
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


        //Display SW item in field
        private void DisplaySWSelectedItemInField()
        {
            if (listView2.SelectedIndices.Count > 0)
            {

                int i = (int.Parse(listView2.SelectedItems[0].Text));
                scottishGlenSoftware inforlookup = (from p in scGlenDB.scottishGlenSoftwares where p.id == i select p).FirstOrDefault<scottishGlenSoftware>();

                inamesw.Text = inforlookup.operatingSystemName;
                iversionsw.Text = inforlookup.version.ToString();
                imanusw.Text = inforlookup.manufacturer.ToString();

            }
        }


        //Delete Panel
        private void button3_Click(object sender, EventArgs e)
        {
            setButtonAccoprdingly("Delete");
            UpdateListView();
            addAssetPanel.Visible = true;
        }

        //Updaet trigger funcionality
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

        //Delete Button Functionality
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
            addSfowtareTrigger = false;

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
           

            if (listView2.SelectedIndices.Count > 0)
            {
                int i = (int.Parse(listView2.SelectedItems[0].Text));
                scottishGlenSoftware inforlookup = (from p in scGlenDB.scottishGlenSoftwares where p.id == i select p).FirstOrDefault<scottishGlenSoftware>();
               
                //Edit Item
                UpdateSWListView();
                setButtonSWAccoprdingly("Update");
                addAssetPanel2.Visible = true;

                inamesw.Text = inforlookup.operatingSystemName;
                iversionsw.Text = inforlookup.version;
                imanusw.Text = inforlookup.manufacturer;

                DisplaySWSelectedItemInField();
            }
            else
            {
                MessageBox.Show("You must select an asset");
            }
            

            
        }

        //Delete Software INFO
        private void button9_Click(object sender, EventArgs e)
        {
            if(listView2.SelectedIndices.Count > 0)
            {
                setButtonSWAccoprdingly("Delete");
                UpdateSWListView();
                addAssetPanel2.Visible = true;
            }
            else
            {

                MessageBox.Show("You must select an asset");

            }
        }

        //Addtrigger Button
        private void button8_Click(object sender, EventArgs e)
        {
            scottishGlenSoftware newAsset = new scottishGlenSoftware();

            if (addSfowtareTrigger)
            {
                newAsset.hardwareName = hwName;
            }
            
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

            if(addSfowtareTrigger)
            {
                //Set software panel
                hardwarePanel.Visible = true;
                softwarePanel.Visible = false;


                scottishGlenSoftware sofwtarelookup = (from p in scGlenDB.scottishGlenSoftwares where p.hardwareName == hwName select p).FirstOrDefault<scottishGlenSoftware>();

                int sftId = sofwtarelookup.id;

                scottishGlen hardwarelookup = (from p in scGlenDB.scottishGlens where p.name == hwName select p).FirstOrDefault<scottishGlen>();

                hardwarelookup.softwareId = sftId;

                hardwarelookup.extraInfo = "This HW has Software attached";

                scGlenDB.SaveChanges();

                UpdateListView();

                MessageBox.Show("You have successfully updated an asset");
            }
        }


        //Update Trigger Button
        private void button7_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedIndices.Count > 0)
            {
                int i = (int.Parse(listView2.SelectedItems[0].Text));
                scottishGlenSoftware inforlookup = (from p in scGlenDB.scottishGlenSoftwares where p.id == i select p).FirstOrDefault<scottishGlenSoftware>();

                inamesw.Text = inforlookup.operatingSystemName;
                iversionsw.Text = inforlookup.version;
                imanusw.Text = inforlookup.manufacturer;

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

        //Hardware Panel
        private void hardwarebtn_Click(object sender, EventArgs e)
        {
            hardwarePanel.Visible = true;
            softwarePanel.Visible = false;
            nvdPanel.Visible = false;
        }


        //Software Panel
        private void softwarebtn_Click(object sender, EventArgs e)
        {
            hardwarePanel.Visible = false;
            softwarePanel.Visible = true;
            nvdPanel.Visible = false;

        }

        //Register an Account
        private void registerbtn_Click(object sender, EventArgs e)
        {
            //All fields must have inputs and password must be >= 8 characters
            if (usernamergst.Text != null && psswdrgst.Text != null && confpsswdrgst.Text != null && psswdrgst.TextLength >= 8 && confpsswdrgst.TextLength >= 8)
            {

                //Password must match
                if (psswdrgst.Text == confpsswdrgst.Text)
                {

                    scottishGlenAccount newAccount = new scottishGlenAccount(); //can also overload the constructor


                    string hashedpass = EncryptPassword(psswdrgst.Text);

                    newAccount.username = usernamergst.Text;
                    newAccount.password = hashedpass;


                    scGlenDB.scottishGlenAccounts.Add(newAccount);

                    scGlenDB.SaveChanges();

                    LogIn(usernamergst.Text, hashedpass);

                    MessageBox.Show("You Have Successfully Created An Account And Logged In!");

                    verificateAccouting();

                }
                else
                {

                    MessageBox.Show("Password don't match!");
                    //Password don't match
                }

            }
            else
            {
                MessageBox.Show("Please fill in all fields with *");
                //Please fill in all fields with *
            }
        }


        //Assign to accvount
        public void LogIn(string username, string password)
        {

            loggedinAccount = new scottishGlenAccount()
            {
                username = username,
                password = password,
            };


        }

        //Log In
        private void loginBtn_Click(object sender, EventArgs e)
        {

            scottishGlenAccount logged = (from c in scGlenDB.scottishGlenAccounts
                                    where c.username == usernameLog.Text
                                    select c).FirstOrDefault<scottishGlenAccount>();


            if (logged != null)
            {
               //Verifiy salted hashed password
               bool verification = BCrypt.Net.BCrypt.Verify(passwordLog.Text, logged.password);

                if (verification)
                {
                    LogIn(logged.username, logged.password);

                    MessageBox.Show("You Have Successfully Logged In!");
                    verificateAccouting();

                }
                else
                {
                    MessageBox.Show("Wrong Username or Password!");
                }
            }
            else
            {
                MessageBox.Show("Account does not exist!");
            }
           
        }

        //Register Panel
        private void button6_Click_1(object sender, EventArgs e)
        {
            loginPanel.Visible = false;
            registerPanel.Visible = true;
        }

        //Sw Panel items
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                DisplaySWSelectedItemInField();

                string name = AllSWData[listView2.SelectedIndices[0]].operatingSystemName;
                string model = AllSWData[listView2.SelectedIndices[0]].version;
                string manufacturer = AllSWData[listView2.SelectedIndices[0]].manufacturer;


            }
        }

        // Log Out Trigger
        private void logtoutBtn_Click(object sender, EventArgs e)
        {
            //Delete account from memory
            loggedinAccount = null;

            mmpanel.Visible = false;
            loginPanel.Visible = true;
            registerPanel.Visible = false;
            AccountPanel.Visible = false;
            passchng.Visible = false;

        }

        //Go To Account Panel
        private void accountbtn_Click(object sender, EventArgs e)
        {
            mmpanel.Visible = false;
            loginPanel.Visible = false;
            registerPanel.Visible = false;
            AccountPanel.Visible = true;
        }

        //Change Password Panel
        private void chgnpssBtn_Click(object sender, EventArgs e)
        {
            passchng.Visible = true;
        }


        private void changepassbtn_Click(object sender, EventArgs e)
        {

          

        }



        private string EncryptPassword(string pass)
        {
            //Salt And Hash Password
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(pass);

            return hashedPassword;
        }

        private void addsftbtn_Click(object sender, EventArgs e)
        {
            //Know that we should return to HW
            addSfowtareTrigger = true;

            //Set software panel
            hardwarePanel.Visible = false;
            softwarePanel.Visible = true;


            //add information + Hadware ID
            addAssetPanel2.Visible = true;

            setButtonSWAccoprdingly("Add");

            hdwname.Text = getName();
            inamesw.Text = getOSName();
            iversionsw.Text = getOSVersion();
            imanusw.Text = getOSManu();

            UpdateSWListView();


        }


        public void RequestResponseFromCurrentPC()
        {

            //This function checks vulnerabilities via NIST National Vulnerability Database (NVD)

            try
            {
                string osversion = getOSVersion();
                string os = getOSName();
                os = os[18] + "" + os[19];
                string fullparamter = "microsoft:windows_" + os + ":" + osversion;


                var client = new RestClient("https://services.nvd.nist.gov/rest/json/cves/2.0?cpeName=cpe:2.3:o:" + fullparamter);

                Console.WriteLine(client.ToString());

                var response = client.Execute(new RestRequest());

                var jsonString = response.Content;


                Rootobject myRootOject = Newtonsoft.Json.JsonConvert.DeserializeObject<Rootobject>(jsonString);

                List<Vulnerability> vv = new List<Vulnerability>(myRootOject.vulnerabilities);

                ListInformationFromNVD(vv);
            }
            catch
            { }



        }

        public bool RequestResponseFromCurrentAsset(string OsVersion, string OsName)
        {
            //Tries from selected asset from DB, will return false if data inputed is not valid

            bool request = false;
            //This function checks vulnerabilities via NIST National Vulnerability Database (NVD)

            try
            {
                string osversion = OsVersion;
                string os = OsName;
                os = os[18] + "" + os[19];
                string fullparamter = "microsoft:windows_" + os + ":" + osversion;


                var client = new RestClient("https://services.nvd.nist.gov/rest/json/cves/2.0?cpeName=cpe:2.3:o:" + fullparamter);

                Console.WriteLine(client.ToString());

                var response = client.Execute(new RestRequest());

                var jsonString = response.Content;


                Rootobject myRootOject = Newtonsoft.Json.JsonConvert.DeserializeObject<Rootobject>(jsonString);

                List<Vulnerability> vv = new List<Vulnerability>(myRootOject.vulnerabilities);

                ListInformationFromNVD(vv);

                request = true;
            }
            catch
            { request = false; }

            return request;

        }

        public void RequestResponseFromWindows8()
        {

            //This function checks vulnerabilities via NIST National Vulnerability Database (NVD)

            try
            {
                string osVersion = getOSVersion();

                string fullparamter = "microsoft:windows_8" + ":" + osVersion;


                var client = new RestClient("https://services.nvd.nist.gov/rest/json/cves/2.0?cpeName=cpe:2.3:o:" + fullparamter);

                Console.WriteLine(client.ToString());

                var response = client.Execute(new RestRequest());

                var jsonString = response.Content;


                Rootobject myRootOject = Newtonsoft.Json.JsonConvert.DeserializeObject<Rootobject>(jsonString);

                List<Vulnerability> vv = new List<Vulnerability>(myRootOject.vulnerabilities);

                ListInformationFromNVD(vv);
            }
            catch { }

        }

        public void RequestResponseFromWindows10()
        {

            //This function checks vulnerabilities via NIST National Vulnerability Database (NVD)

            try
            {
                string osVersion = getOSVersion();

                string fullparamter = "microsoft:windows_10" + ":" + osVersion;


                var client = new RestClient("https://services.nvd.nist.gov/rest/json/cves/2.0?cpeName=cpe:2.3:o:" + fullparamter);

                Console.WriteLine(client.ToString());

                var response = client.Execute(new RestRequest());

                var jsonString = response.Content;


                Rootobject myRootOject = Newtonsoft.Json.JsonConvert.DeserializeObject<Rootobject>(jsonString);

                List<Vulnerability> vv = new List<Vulnerability>(myRootOject.vulnerabilities);

                ListInformationFromNVD(vv);
            }
            catch { }



        }

        public void RequestResponseFromWindows11()
        {

            //This function checks vulnerabilities via NIST National Vulnerability Database (NVD)

            try
            {
                string osVersion = getOSVersion();

                string fullparamter = "microsoft:windows_11" + ":" + osVersion;

                var client = new RestClient("https://services.nvd.nist.gov/rest/json/cves/2.0?cpeName=cpe:2.3:o:" + fullparamter);

                Console.WriteLine(client.ToString());

                var response = client.Execute(new RestRequest());

                var jsonString = response.Content;


                Rootobject myRootOject = Newtonsoft.Json.JsonConvert.DeserializeObject<Rootobject>(jsonString);

                List<Vulnerability> vv = new List<Vulnerability>(myRootOject.vulnerabilities);

                ListInformationFromNVD(vv);
            }
            catch { }



        }
        //List all info from DB
        void ListInformationFromNVD(List<Vulnerability> vv)
        {
            listView3.Items.Clear();
            foreach (var g in vv)
            {
                ListViewItem newitem = new ListViewItem(g.cve.id.ToString(), 0);

                //Check if data is null, to prevent errors
                if (g.cve.sourceIdentifier != null)
                {
                    newitem.SubItems.Add(g.cve.sourceIdentifier.ToString());
                }
                else
                {
                    newitem.SubItems.Add("");
                }

                if (g.cve.descriptions[0] != null)
                {
                    newitem.SubItems.Add(g.cve.descriptions[0].value.ToString());
                }
                else
                {
                    newitem.SubItems.Add("");
                }

                if (g.cve.published != null)
                {
                    newitem.SubItems.Add(g.cve.published.Date.ToString());
                }
                else
                {
                    newitem.SubItems.Add("");
                }

                listView3.Items.Add(newitem);
            }
        }

        //get from current pc stats
        private void button14_Click(object sender, EventArgs e)
        {
            RequestResponseFromCurrentPC();
        }

        //get from windows 11
        private void button15_Click(object sender, EventArgs e)
        {
            RequestResponseFromWindows11();
        }

        //get from windows 10
        private void button17_Click(object sender, EventArgs e)
        {
            RequestResponseFromWindows10();
        }


        //get from windows 8
        private void button16_Click(object sender, EventArgs e)
        {
            RequestResponseFromWindows8();
        }


        //NVD Panel
        private void button7_Click_1(object sender, EventArgs e)
        {
            hardwarePanel.Visible = false;
            softwarePanel.Visible = false;
            nvdPanel.Visible = true;

            UpdateSWLNVDistView();
        }

        //Back Button (Cancel)
        private void button8_Click_1(object sender, EventArgs e)
        {
            mmpanel.Visible = true;
            loginPanel.Visible = false;
            registerPanel.Visible = false;
            AccountPanel.Visible = false;
        }

        //Get from current asset, if data is valid
        private void button11_Click(object sender, EventArgs e)
        {
            if (listView4.SelectedIndices.Count > 0)
            {
                bool response = false;

                int i = (int.Parse(listView4.SelectedItems[0].Text));
                scottishGlenSoftware productLookUp = (from p in scGlenDB.scottishGlenSoftwares
                                                      where p.id == i
                                                      select p).FirstOrDefault<scottishGlenSoftware>();


                response = RequestResponseFromCurrentAsset(productLookUp.version, productLookUp.operatingSystemName);

                if(!response)
                {
                    MessageBox.Show("Something went wrong! Maybe data is not valid");
                }


            }
            else
            {
                MessageBox.Show("You must select an asset");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AccountPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        //change password
        private void button12_Click(object sender, EventArgs e)
        {


            scottishGlenAccount accountlogin = (from c in scGlenDB.scottishGlenAccounts
                                                where c.username == loggedinAccount.username
                                                select c).FirstOrDefault<scottishGlenAccount>();


            bool verification = BCrypt.Net.BCrypt.Verify(currntps.Text, accountlogin.password);
            //If current passsword is valid
            if (verification)
            {
                //Passwords match and are long enough
                if ((newpss.Text == newpsscnf.Text) && newpss.Text.Length >= 8)
                {
                    var hashedpasswrd = EncryptPassword(newpss.Text);
                    accountlogin.password = hashedpasswrd;
                    scGlenDB.SaveChanges();

                    MessageBox.Show("Password succesfully changed!");

                }
                else
                {
                    MessageBox.Show("Make sure new password is valid!");
                }

            }
            else
            {
                MessageBox.Show("Current Password is wrong!");
            }
        }

        private void cncbttn_Click(object sender, EventArgs e)
        {
            passchng.Visible = false;
        }

        private void passchng_Paint(object sender, PaintEventArgs e)
        {

        }

        //Cancel Account Panel (Back)
        private void cnclaccount_Click(object sender, EventArgs e)
        {
            mmpanel.Visible = true;
            AccountPanel.Visible = false;
        }
    }



}
