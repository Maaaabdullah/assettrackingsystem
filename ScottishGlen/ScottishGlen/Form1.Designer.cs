
namespace ScottishGlen
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.initialTitle = new System.Windows.Forms.Label();
            this.addAssetBTN = new System.Windows.Forms.Button();
            this.addAssetPanel = new System.Windows.Forms.Panel();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.updatebtn = new System.Windows.Forms.Button();
            this.iPurchaseDate = new System.Windows.Forms.TextBox();
            this.iname = new System.Windows.Forms.TextBox();
            this.addbutton = new System.Windows.Forms.Button();
            this.iExtraInfo = new System.Windows.Forms.TextBox();
            this.iIpAddress = new System.Windows.Forms.TextBox();
            this.itype = new System.Windows.Forms.TextBox();
            this.imanufacturer = new System.Windows.Forms.TextBox();
            this.imodel = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Model = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Manu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IpAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PurchaseDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ExtraInfo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addAssetPanelLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pcinfo = new System.Windows.Forms.Label();
            this.rowInfotxt = new System.Windows.Forms.Label();
            this.addAssetPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // initialTitle
            // 
            this.initialTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.initialTitle.Location = new System.Drawing.Point(12, 9);
            this.initialTitle.Name = "initialTitle";
            this.initialTitle.Size = new System.Drawing.Size(589, 50);
            this.initialTitle.TabIndex = 7;
            this.initialTitle.Text = "Scottish Glen - Asset Tracker";
            // 
            // addAssetBTN
            // 
            this.addAssetBTN.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAssetBTN.Location = new System.Drawing.Point(24, 114);
            this.addAssetBTN.Name = "addAssetBTN";
            this.addAssetBTN.Size = new System.Drawing.Size(223, 50);
            this.addAssetBTN.TabIndex = 1;
            this.addAssetBTN.Text = "ADD ASSET";
            this.addAssetBTN.UseVisualStyleBackColor = true;
            this.addAssetBTN.Click += new System.EventHandler(this.addAssetBTN_Click);
            // 
            // addAssetPanel
            // 
            this.addAssetPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.addAssetPanel.Controls.Add(this.deleteBtn);
            this.addAssetPanel.Controls.Add(this.updatebtn);
            this.addAssetPanel.Controls.Add(this.iPurchaseDate);
            this.addAssetPanel.Controls.Add(this.iname);
            this.addAssetPanel.Controls.Add(this.addbutton);
            this.addAssetPanel.Controls.Add(this.iExtraInfo);
            this.addAssetPanel.Controls.Add(this.iIpAddress);
            this.addAssetPanel.Controls.Add(this.itype);
            this.addAssetPanel.Controls.Add(this.imanufacturer);
            this.addAssetPanel.Controls.Add(this.imodel);
            this.addAssetPanel.Location = new System.Drawing.Point(296, 84);
            this.addAssetPanel.Name = "addAssetPanel";
            this.addAssetPanel.Size = new System.Drawing.Size(294, 390);
            this.addAssetPanel.TabIndex = 2;
            this.addAssetPanel.Visible = false;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(83, 328);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(112, 40);
            this.deleteBtn.TabIndex = 16;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // updatebtn
            // 
            this.updatebtn.Location = new System.Drawing.Point(83, 328);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(112, 40);
            this.updatebtn.TabIndex = 15;
            this.updatebtn.Text = "Update";
            this.updatebtn.UseVisualStyleBackColor = true;
            this.updatebtn.Click += new System.EventHandler(this.updatebtn_Click);
            // 
            // iPurchaseDate
            // 
            this.iPurchaseDate.Location = new System.Drawing.Point(18, 185);
            this.iPurchaseDate.Name = "iPurchaseDate";
            this.iPurchaseDate.Size = new System.Drawing.Size(254, 22);
            this.iPurchaseDate.TabIndex = 14;
            this.iPurchaseDate.Text = "Purchase Date";
            this.iPurchaseDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // iname
            // 
            this.iname.Location = new System.Drawing.Point(18, 44);
            this.iname.Name = "iname";
            this.iname.Size = new System.Drawing.Size(254, 22);
            this.iname.TabIndex = 13;
            this.iname.Text = "Name";
            this.iname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // addbutton
            // 
            this.addbutton.Location = new System.Drawing.Point(83, 328);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(112, 40);
            this.addbutton.TabIndex = 8;
            this.addbutton.Text = "Add";
            this.addbutton.UseVisualStyleBackColor = true;
            this.addbutton.Click += new System.EventHandler(this.submitNewAssetForm_Click);
            // 
            // iExtraInfo
            // 
            this.iExtraInfo.Location = new System.Drawing.Point(18, 213);
            this.iExtraInfo.Multiline = true;
            this.iExtraInfo.Name = "iExtraInfo";
            this.iExtraInfo.Size = new System.Drawing.Size(254, 109);
            this.iExtraInfo.TabIndex = 6;
            this.iExtraInfo.Text = "Extra Information";
            this.iExtraInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // iIpAddress
            // 
            this.iIpAddress.Location = new System.Drawing.Point(18, 155);
            this.iIpAddress.Name = "iIpAddress";
            this.iIpAddress.Size = new System.Drawing.Size(254, 22);
            this.iIpAddress.TabIndex = 5;
            this.iIpAddress.Text = "IP Address";
            this.iIpAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // itype
            // 
            this.itype.Location = new System.Drawing.Point(18, 127);
            this.itype.Name = "itype";
            this.itype.Size = new System.Drawing.Size(254, 22);
            this.itype.TabIndex = 4;
            this.itype.Text = "Type";
            this.itype.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // imanufacturer
            // 
            this.imanufacturer.Location = new System.Drawing.Point(18, 99);
            this.imanufacturer.Name = "imanufacturer";
            this.imanufacturer.Size = new System.Drawing.Size(254, 22);
            this.imanufacturer.TabIndex = 3;
            this.imanufacturer.Text = "Manufacturer";
            this.imanufacturer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // imodel
            // 
            this.imodel.Location = new System.Drawing.Point(18, 71);
            this.imodel.Name = "imodel";
            this.imodel.Size = new System.Drawing.Size(254, 22);
            this.imodel.TabIndex = 2;
            this.imodel.Text = "Model";
            this.imodel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Name,
            this.Model,
            this.Manu,
            this.Type,
            this.IpAddress,
            this.PurchaseDate,
            this.ExtraInfo});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(628, 84);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(407, 287);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Name
            // 
            this.Name.Text = "Name";
            // 
            // Model
            // 
            this.Model.Text = "Model";
            // 
            // Manu
            // 
            this.Manu.Text = "Manufacturer";
            this.Manu.Width = 89;
            // 
            // Type
            // 
            this.Type.Text = "Type";
            // 
            // IpAddress
            // 
            this.IpAddress.Text = "IP Address";
            this.IpAddress.Width = 89;
            // 
            // PurchaseDate
            // 
            this.PurchaseDate.Text = "Purchase Date";
            this.PurchaseDate.Width = 113;
            // 
            // ExtraInfo
            // 
            this.ExtraInfo.Text = "ExtraInformation";
            this.ExtraInfo.Width = 110;
            // 
            // addAssetPanelLabel
            // 
            this.addAssetPanelLabel.Location = new System.Drawing.Point(0, 0);
            this.addAssetPanelLabel.Name = "addAssetPanelLabel";
            this.addAssetPanelLabel.Size = new System.Drawing.Size(100, 23);
            this.addAssetPanelLabel.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(24, 182);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(223, 50);
            this.button1.TabIndex = 3;
            this.button1.Text = "VIEW ASSET";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(24, 249);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(223, 50);
            this.button2.TabIndex = 4;
            this.button2.Text = "UPDATE ASSET";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(24, 321);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(223, 50);
            this.button3.TabIndex = 5;
            this.button3.Text = "DELETE ASSET";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pcinfo
            // 
            this.pcinfo.AutoSize = true;
            this.pcinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pcinfo.Location = new System.Drawing.Point(20, 398);
            this.pcinfo.Name = "pcinfo";
            this.pcinfo.Size = new System.Drawing.Size(61, 24);
            this.pcinfo.TabIndex = 6;
            this.pcinfo.Text = "pcinfo";
            // 
            // rowInfotxt
            // 
            this.rowInfotxt.AutoSize = true;
            this.rowInfotxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rowInfotxt.Location = new System.Drawing.Point(640, 398);
            this.rowInfotxt.Name = "rowInfotxt";
            this.rowInfotxt.Size = new System.Drawing.Size(71, 24);
            this.rowInfotxt.TabIndex = 10;
            this.rowInfotxt.Text = "rowInfo";
            this.rowInfotxt.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 678);
            this.Controls.Add(this.rowInfotxt);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.pcinfo);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.addAssetPanel);
            this.Controls.Add(this.addAssetBTN);
            this.Controls.Add(this.initialTitle);
            this.Controls.Add(this.addAssetPanelLabel);
           // this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.addAssetPanel.ResumeLayout(false);
            this.addAssetPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label initialTitle;
        private System.Windows.Forms.Button addAssetBTN;
        private System.Windows.Forms.Panel addAssetPanel;
        private System.Windows.Forms.Label addAssetPanelLabel;
        private System.Windows.Forms.TextBox iExtraInfo;
        private System.Windows.Forms.TextBox iIpAddress;
        private System.Windows.Forms.TextBox itype;
        private System.Windows.Forms.TextBox imanufacturer;
        private System.Windows.Forms.TextBox imodel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button addbutton;
        private System.Windows.Forms.TextBox iname;
        private System.Windows.Forms.TextBox iPurchaseDate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label pcinfo;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Name;
        private System.Windows.Forms.ColumnHeader Model;
        private System.Windows.Forms.ColumnHeader Manu;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader IpAddress;
        private System.Windows.Forms.ColumnHeader PurchaseDate;
        private System.Windows.Forms.ColumnHeader ExtraInfo;
        private System.Windows.Forms.Label rowInfotxt;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button updatebtn;
    }
}

