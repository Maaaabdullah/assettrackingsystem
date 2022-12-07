
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.hardwarePanel = new System.Windows.Forms.Panel();
            this.softwarePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button5 = new System.Windows.Forms.Button();
            this.addAssetPanel2 = new System.Windows.Forms.Panel();
            this.deleteBtnsw = new System.Windows.Forms.Button();
            this.updatebtnsw = new System.Windows.Forms.Button();
            this.inamesw = new System.Windows.Forms.TextBox();
            this.addbuttonsw = new System.Windows.Forms.Button();
            this.imanusw = new System.Windows.Forms.TextBox();
            this.iversionsw = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.hardwarebtn = new System.Windows.Forms.Button();
            this.softwarebtn = new System.Windows.Forms.Button();
            this.addAssetPanel.SuspendLayout();
            this.hardwarePanel.SuspendLayout();
            this.softwarePanel.SuspendLayout();
            this.addAssetPanel2.SuspendLayout();
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
            this.addAssetBTN.Location = new System.Drawing.Point(29, 60);
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
            this.addAssetPanel.Location = new System.Drawing.Point(295, 35);
            this.addAssetPanel.Name = "addAssetPanel";
            this.addAssetPanel.Size = new System.Drawing.Size(294, 390);
            this.addAssetPanel.TabIndex = 2;
            this.addAssetPanel.Visible = false;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(-8, 328);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(112, 40);
            this.deleteBtn.TabIndex = 16;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // updatebtn
            // 
            this.updatebtn.Location = new System.Drawing.Point(182, 328);
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
            this.listView1.Location = new System.Drawing.Point(633, 35);
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
            this.button1.Location = new System.Drawing.Point(29, 134);
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
            this.button2.Location = new System.Drawing.Point(29, 201);
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
            this.button3.Location = new System.Drawing.Point(29, 272);
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
            this.pcinfo.Location = new System.Drawing.Point(16, 536);
            this.pcinfo.Name = "pcinfo";
            this.pcinfo.Size = new System.Drawing.Size(61, 24);
            this.pcinfo.TabIndex = 6;
            this.pcinfo.Text = "pcinfo";
            // 
            // rowInfotxt
            // 
            this.rowInfotxt.AutoSize = true;
            this.rowInfotxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rowInfotxt.Location = new System.Drawing.Point(629, 342);
            this.rowInfotxt.Name = "rowInfotxt";
            this.rowInfotxt.Size = new System.Drawing.Size(71, 24);
            this.rowInfotxt.TabIndex = 10;
            this.rowInfotxt.Text = "rowInfo";
            this.rowInfotxt.Click += new System.EventHandler(this.label1_Click);
            // 
            // hardwarePanel
            // 
            this.hardwarePanel.Controls.Add(this.rowInfotxt);
            this.hardwarePanel.Controls.Add(this.addAssetBTN);
            this.hardwarePanel.Controls.Add(this.listView1);
            this.hardwarePanel.Controls.Add(this.button1);
            this.hardwarePanel.Controls.Add(this.addAssetPanel);
            this.hardwarePanel.Controls.Add(this.button3);
            this.hardwarePanel.Controls.Add(this.button2);
            this.hardwarePanel.Location = new System.Drawing.Point(12, 101);
            this.hardwarePanel.Name = "hardwarePanel";
            this.hardwarePanel.Size = new System.Drawing.Size(1097, 398);
            this.hardwarePanel.TabIndex = 11;
            this.hardwarePanel.Visible = false;
            // 
            // softwarePanel
            // 
            this.softwarePanel.Controls.Add(this.label1);
            this.softwarePanel.Controls.Add(this.button4);
            this.softwarePanel.Controls.Add(this.listView2);
            this.softwarePanel.Controls.Add(this.button5);
            this.softwarePanel.Controls.Add(this.addAssetPanel2);
            this.softwarePanel.Controls.Add(this.button9);
            this.softwarePanel.Controls.Add(this.button10);
            this.softwarePanel.Location = new System.Drawing.Point(12, 101);
            this.softwarePanel.Name = "softwarePanel";
            this.softwarePanel.Size = new System.Drawing.Size(1097, 393);
            this.softwarePanel.TabIndex = 12;
            this.softwarePanel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(629, 342);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "rowInfo";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(29, 60);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(223, 50);
            this.button4.TabIndex = 1;
            this.button4.Text = "ADD ASSET";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(615, 35);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(407, 287);
            this.listView2.TabIndex = 9;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "OS Name";
            this.columnHeader1.Width = 109;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "OS Version";
            this.columnHeader2.Width = 132;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "OS Manufacturer";
            this.columnHeader3.Width = 246;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(29, 134);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(223, 50);
            this.button5.TabIndex = 3;
            this.button5.Text = "VIEW ASSET";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // addAssetPanel2
            // 
            this.addAssetPanel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.addAssetPanel2.Controls.Add(this.deleteBtnsw);
            this.addAssetPanel2.Controls.Add(this.updatebtnsw);
            this.addAssetPanel2.Controls.Add(this.inamesw);
            this.addAssetPanel2.Controls.Add(this.addbuttonsw);
            this.addAssetPanel2.Controls.Add(this.imanusw);
            this.addAssetPanel2.Controls.Add(this.iversionsw);
            this.addAssetPanel2.Location = new System.Drawing.Point(295, 35);
            this.addAssetPanel2.Name = "addAssetPanel2";
            this.addAssetPanel2.Size = new System.Drawing.Size(294, 243);
            this.addAssetPanel2.TabIndex = 2;
            this.addAssetPanel2.Visible = false;
            // 
            // deleteBtnsw
            // 
            this.deleteBtnsw.Location = new System.Drawing.Point(179, 166);
            this.deleteBtnsw.Name = "deleteBtnsw";
            this.deleteBtnsw.Size = new System.Drawing.Size(112, 40);
            this.deleteBtnsw.TabIndex = 16;
            this.deleteBtnsw.Text = "Delete";
            this.deleteBtnsw.UseVisualStyleBackColor = true;
            this.deleteBtnsw.Click += new System.EventHandler(this.button6_Click);
            // 
            // updatebtnsw
            // 
            this.updatebtnsw.Location = new System.Drawing.Point(91, 166);
            this.updatebtnsw.Name = "updatebtnsw";
            this.updatebtnsw.Size = new System.Drawing.Size(112, 40);
            this.updatebtnsw.TabIndex = 15;
            this.updatebtnsw.Text = "Update";
            this.updatebtnsw.UseVisualStyleBackColor = true;
            this.updatebtnsw.Click += new System.EventHandler(this.button7_Click);
            // 
            // inamesw
            // 
            this.inamesw.Location = new System.Drawing.Point(18, 44);
            this.inamesw.Name = "inamesw";
            this.inamesw.Size = new System.Drawing.Size(254, 22);
            this.inamesw.TabIndex = 13;
            this.inamesw.Text = "OS Name";
            this.inamesw.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // addbuttonsw
            // 
            this.addbuttonsw.Location = new System.Drawing.Point(91, 166);
            this.addbuttonsw.Name = "addbuttonsw";
            this.addbuttonsw.Size = new System.Drawing.Size(112, 40);
            this.addbuttonsw.TabIndex = 8;
            this.addbuttonsw.Text = "Add";
            this.addbuttonsw.UseVisualStyleBackColor = true;
            this.addbuttonsw.Click += new System.EventHandler(this.button8_Click);
            // 
            // imanusw
            // 
            this.imanusw.Location = new System.Drawing.Point(18, 99);
            this.imanusw.Name = "imanusw";
            this.imanusw.Size = new System.Drawing.Size(254, 22);
            this.imanusw.TabIndex = 3;
            this.imanusw.Text = "OS Manufacturer";
            this.imanusw.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // iversionsw
            // 
            this.iversionsw.Location = new System.Drawing.Point(18, 71);
            this.iversionsw.Name = "iversionsw";
            this.iversionsw.Size = new System.Drawing.Size(254, 22);
            this.iversionsw.TabIndex = 2;
            this.iversionsw.Text = "OS Version";
            this.iversionsw.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(29, 272);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(223, 50);
            this.button9.TabIndex = 5;
            this.button9.Text = "DELETE ASSET";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(29, 201);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(223, 50);
            this.button10.TabIndex = 4;
            this.button10.Text = "UPDATE ASSET";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // hardwarebtn
            // 
            this.hardwarebtn.Location = new System.Drawing.Point(12, 67);
            this.hardwarebtn.Name = "hardwarebtn";
            this.hardwarebtn.Size = new System.Drawing.Size(148, 28);
            this.hardwarebtn.TabIndex = 13;
            this.hardwarebtn.Text = "Hardware";
            this.hardwarebtn.UseVisualStyleBackColor = true;
            this.hardwarebtn.Click += new System.EventHandler(this.hardwarebtn_Click);
            // 
            // softwarebtn
            // 
            this.softwarebtn.Location = new System.Drawing.Point(198, 67);
            this.softwarebtn.Name = "softwarebtn";
            this.softwarebtn.Size = new System.Drawing.Size(148, 28);
            this.softwarebtn.TabIndex = 14;
            this.softwarebtn.Text = "Software";
            this.softwarebtn.UseVisualStyleBackColor = true;
            this.softwarebtn.Click += new System.EventHandler(this.softwarebtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 1055);
            this.Controls.Add(this.softwarebtn);
            this.Controls.Add(this.hardwarebtn);
            this.Controls.Add(this.softwarePanel);
            this.Controls.Add(this.initialTitle);
            this.Controls.Add(this.addAssetPanelLabel);
            this.Controls.Add(this.hardwarePanel);
            this.Controls.Add(this.pcinfo);
            //this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.addAssetPanel.ResumeLayout(false);
            this.addAssetPanel.PerformLayout();
            this.hardwarePanel.ResumeLayout(false);
            this.hardwarePanel.PerformLayout();
            this.softwarePanel.ResumeLayout(false);
            this.softwarePanel.PerformLayout();
            this.addAssetPanel2.ResumeLayout(false);
            this.addAssetPanel2.PerformLayout();
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
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel hardwarePanel;
        private System.Windows.Forms.Panel softwarePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel addAssetPanel2;
        private System.Windows.Forms.Button deleteBtnsw;
        private System.Windows.Forms.Button updatebtnsw;
        private System.Windows.Forms.TextBox inamesw;
        private System.Windows.Forms.Button addbuttonsw;
        private System.Windows.Forms.TextBox imanusw;
        private System.Windows.Forms.TextBox iversionsw;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button hardwarebtn;
        private System.Windows.Forms.Button softwarebtn;
    }
}

