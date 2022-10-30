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

        mssql2002690Entities3 scGlenDB = new mssql2002690Entities3();
       

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pcinfo.Text = "Your current PC stats: \n" + "Name: " + getName() + "\n"
                + "Model: " + getModel() + "\n" + "Manufacturer: " + getManu() + "\n"
                + "IP Address: " + getAddress() + "\n";
        }

        private void addAssetBTN_Click(object sender, EventArgs e)
        {
            addAssetPanel.Visible = true;
           
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

        }


        //Get Name Function
        public string getName()
        {
            string name;

            name = Environment.MachineName;

            if(name != null)
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

            if(IP != null)
            {
                return IP;
            }
            else
            {
                return "IP Address: Uknown";
            }
        }
    }
}
