// Decompiled with JetBrains decompiler
// Type: CommonComponent.FormSetting
// Assembly: THUNDER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 06011ABE-59E1-47C7-BE89-C6760127171E
// Assembly location: C:\Program Files (x86)\Dream Cheeky\Thunder\THUNDER.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CommonComponent
{
    public class FormSetting : Form
    {
        public bool SettingClose;
        private IContainer components;
        public CheckBox checkBox_Start;
        public CheckBox checkBox_Mute;
        public Button button_Res;
        public Button button_OK;
        public Button button_Cancel;

        public FormSetting()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (!this.SettingClose)
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
            this.checkBox_Start = new System.Windows.Forms.CheckBox();
            this.checkBox_Mute = new System.Windows.Forms.CheckBox();
            this.button_Res = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBox_Start
            // 
            this.checkBox_Start.AutoSize = true;
            this.checkBox_Start.Location = new System.Drawing.Point(16, 15);
            this.checkBox_Start.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox_Start.Name = "checkBox_Start";
            this.checkBox_Start.Size = new System.Drawing.Size(308, 21);
            this.checkBox_Start.TabIndex = 0;
            this.checkBox_Start.Text = "Run USB Soccer Fidget when Windows start";
            this.checkBox_Start.UseVisualStyleBackColor = true;
            // 
            // checkBox_Mute
            // 
            this.checkBox_Mute.AutoSize = true;
            this.checkBox_Mute.Location = new System.Drawing.Point(16, 43);
            this.checkBox_Mute.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox_Mute.Name = "checkBox_Mute";
            this.checkBox_Mute.Size = new System.Drawing.Size(104, 21);
            this.checkBox_Mute.TabIndex = 1;
            this.checkBox_Mute.Text = "Mute sound";
            this.checkBox_Mute.UseVisualStyleBackColor = true;
            // 
            // button_Res
            // 
            this.button_Res.Location = new System.Drawing.Point(16, 71);
            this.button_Res.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Res.Name = "button_Res";
            this.button_Res.Size = new System.Drawing.Size(157, 28);
            this.button_Res.TabIndex = 2;
            this.button_Res.Text = "Reset highest score";
            this.button_Res.UseVisualStyleBackColor = true;
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(205, 71);
            this.button_OK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(100, 28);
            this.button_OK.TabIndex = 3;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(313, 71);
            this.button_Cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(100, 28);
            this.button_Cancel.TabIndex = 4;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 117);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.button_Res);
            this.Controls.Add(this.checkBox_Mute);
            this.Controls.Add(this.checkBox_Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSetting";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Setting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
