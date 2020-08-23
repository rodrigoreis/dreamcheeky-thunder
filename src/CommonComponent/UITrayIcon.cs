// Decompiled with JetBrains decompiler
// Type: CommonComponent.UITrayIcon
// Assembly: THUNDER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 06011ABE-59E1-47C7-BE89-C6760127171E
// Assembly location: C:\Program Files (x86)\Dream Cheeky\Thunder\THUNDER.exe

using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CommonComponent
{
  internal class UITrayIcon
  {
    private Form myForm;
    public AboutBox myAboutBox;
    public NotifyIcon myNotifyIcon;
    public ContextMenuStrip myContextMenuStrip;
    private FormWindowState m_previousWindowState;

    public UITrayIcon(
      Form aForm,
      AboutBox aAboutBox,
      NotifyIcon aNotifyIcon,
      ContextMenuStrip aContextMenuStrip)
    {
      this.myForm = aForm;
      this.myAboutBox = aAboutBox;
      this.myNotifyIcon = aNotifyIcon;
      this.myContextMenuStrip = aContextMenuStrip;
      this.myForm.Resize += new EventHandler(this.Form_Resize);
      ToolStripMenuItem toolStripMenuItem1 = new ToolStripMenuItem();
      ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
      ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem();
      ToolStripMenuItem toolStripMenuItem4 = new ToolStripMenuItem();
      ToolStripSeparator toolStripSeparator1 = new ToolStripSeparator();
      ToolStripSeparator toolStripSeparator2 = new ToolStripSeparator();
      this.myNotifyIcon.ContextMenuStrip = this.myContextMenuStrip;
      this.myNotifyIcon.Visible = true;
      this.myNotifyIcon.MouseDoubleClick += new MouseEventHandler(this.notifyIcon_tray_MouseDoubleClick);
      this.myContextMenuStrip.Items.AddRange(new ToolStripItem[6]
      {
        (ToolStripItem) toolStripMenuItem2,
        (ToolStripItem) toolStripSeparator1,
        (ToolStripItem) toolStripMenuItem3,
        (ToolStripItem) toolStripMenuItem4,
        (ToolStripItem) toolStripSeparator2,
        (ToolStripItem) toolStripMenuItem1
      });
      this.myContextMenuStrip.Name = "contextMenuStrip_tray";
      this.myContextMenuStrip.Size = new Size(104, 104);
      toolStripMenuItem2.Name = "toolStripMenuItem_Show";
      toolStripMenuItem2.Size = new Size(103, 22);
      toolStripMenuItem2.Text = "Open THUNDER";
      toolStripMenuItem2.Click += new EventHandler(this.toolStripMenuItem_Show_Click);
      toolStripSeparator1.Name = "toolStripSeparator2";
      toolStripSeparator1.Size = new Size(100, 6);
      toolStripMenuItem3.Name = "toolStripMenuItem_Help";
      toolStripMenuItem3.Size = new Size(103, 22);
      toolStripMenuItem3.Text = "Help";
      toolStripMenuItem3.Click += new EventHandler(this.toolStripMenuItem_Help_Click);
      toolStripMenuItem4.Name = "toolStripMenuItem_About";
      toolStripMenuItem4.Size = new Size(103, 22);
      toolStripMenuItem4.Text = "About";
      toolStripMenuItem4.Click += new EventHandler(this.toolStripMenuItem_About_Click);
      toolStripSeparator2.Name = "toolStripSeparator1";
      toolStripSeparator2.Size = new Size(100, 6);
      toolStripMenuItem1.Name = "toolStripMenuItem_Close";
      toolStripMenuItem1.Size = new Size(103, 22);
      toolStripMenuItem1.Text = "Exit";
      toolStripMenuItem1.Click += new EventHandler(this.toolStripMenuItem_Close_Click);
    }

    public void Form_Resize(object sender, EventArgs e)
    {
      if (this.myForm.WindowState != FormWindowState.Minimized)
      {
        this.m_previousWindowState = this.myForm.WindowState;
        this.myForm.Visible = true;
      }
      else
      {
        if (this.myForm.WindowState != FormWindowState.Minimized)
          return;
        this.myForm.Visible = false;
        this.myForm.ShowInTaskbar = false;
      }
    }

    public void notifyIcon_tray_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      this.myForm.Visible = true;
      this.myForm.WindowState = this.m_previousWindowState;
      this.myForm.Activate();
    }

    public void toolStripMenuItem_Show_Click(object sender, EventArgs e)
    {
      this.myForm.Visible = true;
      this.myForm.WindowState = this.m_previousWindowState;
      this.myForm.Activate();
    }

    public void toolStripMenuItem_Close_Click(object sender, EventArgs e)
    {
      this.myForm.Close();
    }

    public void toolStripMenuItem_Help_Click(object sender, EventArgs e)
    {
      try
      {
        Process.Start("http://www.dreamcheeky.com/download-support");
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
        ExceptionHandle.Exception_Log(ex);
      }
    }

    private void toolStripMenuItem_About_Click(object sender, EventArgs e)
    {
      this.myAboutBox.Show();
      this.myAboutBox.Focus();
    }
  }
}
