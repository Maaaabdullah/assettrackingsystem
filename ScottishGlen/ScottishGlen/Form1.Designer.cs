
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
            this.iname = new System.Windows.Forms.TextBox();
            this.bAdd = new System.Windows.Forms.Button();
            this.iExtraInfo = new System.Windows.Forms.TextBox();
            this.iIpAddress = new System.Windows.Forms.TextBox();
            this.itype = new System.Windows.Forms.TextBox();
            this.imanufacturer = new System.Windows.Forms.TextBox();
            this.imodel = new System.Windows.Forms.TextBox();
            this.addAssetPanelLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.iPurchaseDate = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.addAssetPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // initialTitle
            // 
            this.initialTitle.AutoSize = true;
            this.initialTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.initialTitle.Location = new System.Drawing.Point(56, 24);
            this.initialTitle.Name = "initialTitle";
            this.initialTitle.Size = new System.Drawing.Size(555, 38);
            this.initialTitle.TabIndex = 0;
            this.initialTitle.Text = "ScottishGlen - ASSET TRACKING SYSTEM";
            this.initialTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.initialTitle.Click += new System.EventHandler(this.initialTitle_Click);
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
            this.addAssetPanel.Controls.Add(this.iPurchaseDate);
            this.addAssetPanel.Controls.Add(this.iname);
            this.addAssetPanel.Controls.Add(this.bAdd);
            this.addAssetPanel.Controls.Add(this.iExtraInfo);
            this.addAssetPanel.Controls.Add(this.iIpAddress);
            this.addAssetPanel.Controls.Add(this.itype);
            this.addAssetPanel.Controls.Add(this.imanufacturer);
            this.addAssetPanel.Controls.Add(this.imodel);
            this.addAssetPanel.Controls.Add(this.addAssetPanelLabel);
            this.addAssetPanel.Location = new System.Drawing.Point(307, 76);
            this.addAssetPanel.Name = "addAssetPanel";
            this.addAssetPanel.Size = new System.Drawing.Size(294, 390);
            this.addAssetPanel.TabIndex = 2;
            this.addAssetPanel.Visible = false;
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
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(83, 328);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(112, 40);
            this.bAdd.TabIndex = 8;
            this.bAdd.Text = "Add";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.submitNewAssetForm_Click);
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
            // addAssetPanelLabel
            // 
            this.addAssetPanelLabel.AutoSize = true;
            this.addAssetPanelLabel.Location = new System.Drawing.Point(15, 13);
            this.addAssetPanelLabel.Name = "addAssetPanelLabel";
            this.addAssetPanelLabel.Size = new System.Drawing.Size(257, 17);
            this.addAssetPanelLabel.TabIndex = 0;
            this.addAssetPanelLabel.Text = "Fill the data and submit to add new item";
            this.addAssetPanelLabel.Click += new System.EventHandler(this.addAssetPanelLabel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
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
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI Semilight", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(24, 182);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(223, 50);
            this.button1.TabIndex = 3;
            this.button1.Text = "VIEW ASSET";
            this.button1.UseVisualStyleBackColor = true;
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
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 497);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.addAssetPanel);
            this.Controls.Add(this.addAssetBTN);
            this.Controls.Add(this.initialTitle);
            this.Name = "Form1";
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
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.TextBox iname;
        private System.Windows.Forms.TextBox iPurchaseDate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

