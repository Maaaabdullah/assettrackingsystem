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

        }

        private void initialTitle_Click(object sender, EventArgs e)
        {

        }

        private void addAssetBTN_Click(object sender, EventArgs e)
        {
            addAssetPanel.Visible = true;
        }

       

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
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

        private void addAssetPanelLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
