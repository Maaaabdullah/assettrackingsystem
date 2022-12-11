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
using System.Security.Cryptography;
using BCrypt.Net;
using RestSharp;

namespace ScottishGlen
{
    public partial class Form1 : Form
    {

        static mssql2002690Entities3 scGlenDB = new mssql2002690Entities3();


        List<scottishGlen> AllData = new List<scottishGlen>();// empty list of Hardware All Data from DB

        List<scottishGlenSoftware> AllSWData = new List<scottishGlenSoftware>();// empty list of software All Data from DB


        IQueryable<scottishGlen> AllDataa = from d in scGlenDB.scottishGlens select d;


        IQueryable<scottishGlenSoftware> AllSWDataa = from d in scGlenDB.scottishGlenSoftwares select d;


        scottishGlenAccount loggedinAccount = null;

        bool addSfowtareTrigger = false;
        string hwName = null;
        int lastId = 0;


        public Form1()
        {
            //if(loggedinAccount != null)
            //{
            //  //  mmpanel.Visible = true;
            //    loginPanel.Visible = false;
            //    registerPanel.Visible = false;
            //}
            //else
            //{
            //   // mmpanel.Visible = false;
            //    loginPanel.Visible = true;
            //    registerPanel.Visible = true;
            //}


            InitializeComponent();
            setButtonAccoprdingly("");
            UpdateListView();
            UpdateSWListView();
            AccountPanel.Visible = false;

           

        }

        private void verificateAccouting()
        {
            if(loggedinAccount != null)
            {
                mmpanel.Visible = true;
                loginPanel.Visible = false;
                registerPanel.Visible = false;
            }
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

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

                inamesw.Text = inforlookup.operatingSystemName;
                iversionsw.Text = inforlookup.version.ToString();
                imanusw.Text = inforlookup.manufacturer.ToString();

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

                //int i = (int.Parse(listView1.SelectedItems[0].Text));
               // scottishGlen inforlookup = (from p in scGlenDB.scottishGlens where p.id == i select p).FirstOrDefault<scottishGlen>();

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Regsster an Account
        private void registerbtn_Click(object sender, EventArgs e)
        {
            if (usernamergst.Text != null && psswdrgst.Text != null && confpsswdrgst.Text != null && psswdrgst.TextLength >= 8 && confpsswdrgst.TextLength >= 8)
            {

                if (psswdrgst.Text == confpsswdrgst.Text)
                {


                  

                    scottishGlenAccount newAccount = new scottishGlenAccount(); //can also overload the constructor


                    string hashedpass = EncryptPassword(psswdrgst.Text);

                    hashedpass = hashedpass.ToString();

                    newAccount.username = usernamergst.Text;
                    newAccount.password = hashedpass;


                    scGlenDB.scottishGlenAccounts.Add(newAccount);

                    scGlenDB.SaveChanges();

                    LogIn(usernamergst.Text, hashedpass);

                    MessageBox.Show(hashedpass);

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
            RequestResponse();
            scottishGlenAccount logged = (from c in scGlenDB.scottishGlenAccounts
                                    where c.username == usernameLog.Text
                                    select c).FirstOrDefault<scottishGlenAccount>();

            string hashedpass = EncryptPassword(passwordLog.Text);

            if (logged != null)
            {

                if (hashedpass == logged.password.ToString())
                {
                    LogIn(logged.username, hashedpass);

                    MessageBox.Show("You Have Successfully Logged In!");
                    verificateAccouting();

                }
                else
                {
                    MessageBox.Show("Wrong Username or Password!");

                    MessageBox.Show((logged.password + "\n")); //+ (logged.password + "\n"));
                }
            }
            else
            {
                MessageBox.Show("Account does not exist!");
            }
           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            loginPanel.Visible = false;
            registerPanel.Visible = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void confpsswdrgst_TextChanged(object sender, EventArgs e)
        {

        }

        private void psswdrgst_TextChanged(object sender, EventArgs e)
        {

        }

        private void usernamergst_TextChanged(object sender, EventArgs e)
        {

        }

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
            changePassPanel.Visible = true;
        }


        //Change Password Trigger
        private void changepassbtn_Click(object sender, EventArgs e)
        {

            scottishGlenAccount accountlogin = (from c in scGlenDB.scottishGlenAccounts
                                                where c.username == loggedinAccount.username
                                                select c).FirstOrDefault<scottishGlenAccount>();

            string hashedpass = EncryptPassword(accountlogin.password);
            //If current passsword is valid
            if (currentps.Text == hashedpass)
            {
                //Passwords match and are long enough
                if((newpass.Text == newpasscfrm.Text) && newpass.Text.Length >= 8)
                {
                    var hashedpasswrd = EncryptPassword(newpass.Text);
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



        private string EncryptPassword(string pass)
        {
            var sha1 = new SHA1CryptoServiceProvider();

            var passwordInBytes = Encoding.ASCII.GetBytes(pass);

            var passwordSHA1Validated = sha1.ComputeHash(passwordInBytes);

            string hashedPassword = Encoding.ASCII.GetString(passwordSHA1Validated);

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

        public void RequestResponse()
        {

            var client = new RestClient("https://services.nvd.nist.gov/b28aff68-8243-4ed0-b73d-fea61907afed/rest/json/cves/2.0");

            var response = client.Execute(new RestRequest());

            MessageBox.Show(response.Content);


        }
    }



}
