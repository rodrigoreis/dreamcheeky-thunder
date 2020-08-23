// Decompiled with JetBrains decompiler
// Type: CommonComponent.AboutBox
// Assembly: THUNDER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 06011ABE-59E1-47C7-BE89-C6760127171E
// Assembly location: C:\Program Files (x86)\Dream Cheeky\Thunder\THUNDER.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CommonComponent
{
    public class AboutBox : Form
    {
        public string WebLink = "http://www.dreamcheeky.com/";
        public int ItemCnt = 2;
        public Rectangle[] ItemRect = new Rectangle[2];
        private bool[] ItemEnter = new bool[2];
        public bool AboutClose;
        private IContainer components;
        private Label label_ProgramName;
        private Label label_ProgramVersion;
        private Label label_CopyRight;
        private Label label_TM;

        public AboutBox()
        {
            this.InitializeComponent();
            this.ItemRect[0].Location = new Point(6, 18);
            this.ItemRect[0].Size = new Size(335, 51);
            this.ItemRect[1].Location = new Point(120, 225);
            this.ItemRect[1].Size = new Size(108, 12);
            this.Text = "About THUNDER" + (object)'™';
            this.label_ProgramName.Text = "THUNDER";
            this.label_TM.Text = "" + (object)'™';
            this.label_ProgramVersion.Text = "v1.0 Build 2";
            this.label_CopyRight.Text = "Copyright(c) 2010 Dream Cheeky Ltd. All rights reserved.";
            Point location1 = this.label_ProgramName.Location;
            location1.X = (this.Width - this.label_ProgramName.Width) / 2;
            this.label_ProgramName.Location = location1;
            Point location2 = this.label_ProgramVersion.Location;
            location2.X = (this.Width - this.label_ProgramVersion.Width) / 2;
            this.label_ProgramVersion.Location = location2;
            Point location3 = this.label_TM.Location;
            location3.X = this.label_ProgramName.Location.X + this.label_ProgramName.Width - 12;
            this.label_TM.Location = location3;
            Point location4 = this.label_CopyRight.Location;
            location4.X = (this.Width - this.label_CopyRight.Width) / 2;
            this.label_CopyRight.Location = location4;
        }

        private void AboutBox_MouseMove(object sender, MouseEventArgs e)
        {
            for (int index = 0; index < this.ItemCnt; ++index)
            {
                if (this.ItemRect[index].Contains(e.Location) && !this.ItemEnter[index])
                {
                    this.Cursor = Cursors.Hand;
                    this.ItemEnter[index] = true;
                }
                else if (!this.ItemRect[index].Contains(e.Location) && this.ItemEnter[index])
                {
                    this.Cursor = Cursors.Default;
                    this.ItemEnter[index] = false;
                }
            }
        }

        private void AboutBox_Click(object sender, EventArgs e)
        {
            for (int index = 0; index < this.ItemCnt; ++index)
            {
                if (this.ItemEnter[index])
                    Process.Start(this.WebLink);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!this.AboutClose)
            {
                this.Visible = false;
            }
            else
            {
                if (disposing && this.components != null)
                    this.components.Dispose();
                base.Dispose(disposing);
            }
        }

        private void InitializeComponent()
        {
            this.label_ProgramName = new System.Windows.Forms.Label();
            this.label_CopyRight = new System.Windows.Forms.Label();
            this.label_ProgramVersion = new System.Windows.Forms.Label();
            this.label_TM = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_ProgramName
            // 
            this.label_ProgramName.AutoSize = true;
            this.label_ProgramName.BackColor = System.Drawing.Color.Transparent;
            this.label_ProgramName.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ProgramName.ForeColor = System.Drawing.Color.White;
            this.label_ProgramName.Location = new System.Drawing.Point(117, 95);
            this.label_ProgramName.Margin = new System.Windows.Forms.Padding(0);
            this.label_ProgramName.Name = "label_ProgramName";
            this.label_ProgramName.Size = new System.Drawing.Size(75, 40);
            this.label_ProgramName.TabIndex = 1;
            this.label_ProgramName.Text = "USB";
            // 
            // label_CopyRight
            // 
            this.label_CopyRight.AutoSize = true;
            this.label_CopyRight.BackColor = System.Drawing.Color.Transparent;
            this.label_CopyRight.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CopyRight.ForeColor = System.Drawing.Color.White;
            this.label_CopyRight.Location = new System.Drawing.Point(14, 158);
            this.label_CopyRight.Margin = new System.Windows.Forms.Padding(0);
            this.label_CopyRight.Name = "label_CopyRight";
            this.label_CopyRight.Size = new System.Drawing.Size(392, 19);
            this.label_CopyRight.TabIndex = 2;
            this.label_CopyRight.Text = "Copyright(c) 2009 Dream Cheeky Ltd. All rights reserved.";
            // 
            // label_ProgramVersion
            // 
            this.label_ProgramVersion.AutoSize = true;
            this.label_ProgramVersion.BackColor = System.Drawing.Color.Transparent;
            this.label_ProgramVersion.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ProgramVersion.ForeColor = System.Drawing.Color.White;
            this.label_ProgramVersion.Location = new System.Drawing.Point(140, 134);
            this.label_ProgramVersion.Margin = new System.Windows.Forms.Padding(0);
            this.label_ProgramVersion.Name = "label_ProgramVersion";
            this.label_ProgramVersion.Size = new System.Drawing.Size(86, 19);
            this.label_ProgramVersion.TabIndex = 3;
            this.label_ProgramVersion.Text = "v1.0 Build 1";
            // 
            // label_TM
            // 
            this.label_TM.AutoSize = true;
            this.label_TM.BackColor = System.Drawing.Color.Transparent;
            this.label_TM.ForeColor = System.Drawing.Color.White;
            this.label_TM.Location = new System.Drawing.Point(181, 100);
            this.label_TM.Name = "label_TM";
            this.label_TM.Size = new System.Drawing.Size(28, 17);
            this.label_TM.TabIndex = 4;
            this.label_TM.Text = "TM";
            // 
            // AboutBox
            // 
            this.BackgroundImage = global::Properties.Resources.BackgroundImage;
            this.ClientSize = new System.Drawing.Size(348, 245);
            this.Controls.Add(this.label_TM);
            this.Controls.Add(this.label_ProgramVersion);
            this.Controls.Add(this.label_ProgramName);
            this.Controls.Add(this.label_CopyRight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.Click += new System.EventHandler(this.AboutBox_Click);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AboutBox_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
