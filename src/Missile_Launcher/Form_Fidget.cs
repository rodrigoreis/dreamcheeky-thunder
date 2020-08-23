// Decompiled with JetBrains decompiler
// Type: Missile_Launcher.Form_Fidget
// Assembly: THUNDER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 06011ABE-59E1-47C7-BE89-C6760127171E
// Assembly location: C:\Program Files (x86)\Dream Cheeky\Thunder\THUNDER.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using CommonComponent;
using Microsoft.Win32;
using UsbLibrary;

namespace Missile_Launcher
{
    public class Form_Fidget : Form
    {
        private byte[] CMD = new byte[9]
        {
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 2
        };
        private byte[] UP0 = new byte[2] { (byte)0, (byte)2 };
        private byte[] DOWN0 = new byte[2] { (byte)0, (byte)1 };
        private byte[] LEFT0 = new byte[2] { (byte)0, (byte)4 };
        private byte[] RIGHT0 = new byte[2]
        {
      (byte) 0,
      (byte) 8
        };
        private byte[] FIRE0 = new byte[2]
        {
      (byte) 0,
      (byte) 16
        };
        private byte[] GET_STATUS0 = new byte[2]
        {
      (byte) 0,
      (byte) 64
        };
        private byte[] STOP0 = new byte[2]
        {
      (byte) 0,
      (byte) 32
        };
        private byte[] UP1 = new byte[10]
        {
      (byte) 0,
      (byte) 2,
      (byte) 2,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0
        };
        private byte[] DOWN1 = new byte[10]
        {
      (byte) 0,
      (byte) 2,
      (byte) 1,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0
        };
        private byte[] LEFT1 = new byte[10]
        {
      (byte) 0,
      (byte) 2,
      (byte) 4,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0
        };
        private byte[] RIGHT1 = new byte[10]
        {
      (byte) 0,
      (byte) 2,
      (byte) 8,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0
        };
        private byte[] FIRE1 = new byte[10]
        {
      (byte) 0,
      (byte) 2,
      (byte) 16,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0
        };
        private byte[] STOP1 = new byte[10]
        {
      (byte) 0,
      (byte) 2,
      (byte) 32,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0
        };
        private byte[] GET_STATUS1 = new byte[9]
        {
      (byte) 0,
      (byte) 1,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0
        };
        private byte[] LED_ON = new byte[9]
        {
      (byte) 0,
      (byte) 3,
      (byte) 1,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0
        };
        private byte[] LED_OFF = new byte[9]
        {
      (byte) 0,
      (byte) 3,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0,
      (byte) 0
        };
        private bool SoundOn = true;
        private TimeSpan[] TestTime = new TimeSpan[30];
        private bool NoVideo = true;
        private Random Rand = new Random();
        private string appPath;
        private string uiPath;
        private byte[] UP;
        private byte[] DOWN;
        private byte[] LEFT;
        private byte[] RIGHT;
        private byte[] FIRE;
        private byte[] STOP;
        private byte[] GET_STATUS;
        private bool DebugMode;
        private bool Firing;
        private bool Fired;
        private bool nFire;
        private bool ReSet;
        private bool ReSeted;
        private bool Calibrate;
        private bool Action;
        private bool DelayStop;
        private bool FireCheck;
        private int FireCnt;
        private int FireTimeCnt;
        private int FireTimeout;
        private int ResetTimeout;
        private int ReSet_Status;
        private DateTime start;
        private TimeSpan Vertical;
        private TimeSpan Horizon;
        private TimeSpan stop;
        private int TestTimeCnt;
        private Setting UserSetting;
        private UI myUI;
        private UITrayIcon myUITrayIcon;
        private AboutBox about;
        private Icon IconOff;
        private Icon IconActive;
        private byte Current_Status;
        private SoundPlayer Wavplayer;
        private string mask_picture;
        private Point CenterPoint;
        private Bitmap mask;
        private bool DevicePresent;
        private int MoveHeight;
        private int MoveWidth;
        private Form_Fidget.STATUS CurrentAction;
        private int timerCnt;
        private Rectangle SrcRect;
        private Rectangle DesRect;
        private Bitmap FirePic0;
        private Bitmap FirePic1;
        private Bitmap FirePic2;
        private Bitmap FirePic3;
        private Bitmap Boom;
        private int VersionProfile;
        private bool UpPress;
        private bool DownPress;
        private int UpCnt;
        private int DownCnt;
        private bool FireAniEn;
        private int SquareCnt;
        private int RedCnt;
        private int BlueCnt1;
        private int BlueCnt2;
        private int FireButtonCnt;
        private int RedRandCnt;
        private int BlueRandCnt1;
        private int BlueRandCnt2;
        private int SpeedCnt;
        private IContainer components;
        private PictureBox pictureBox1;
        private ToolTip toolTip1;
        private System.Windows.Forms.Timer timer1;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private UsbHidPort USB;
        public Panel panel1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;

        public Form_Fidget(bool IsHide)
        {
            this.InitializeComponent();
            if (!IsHide)
                return;
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form_Fidget_Load(object sender, EventArgs e)
        {
            Application.ThreadException += new ThreadExceptionEventHandler(ExceptionHandle.Application_ThreadException);
            if (File.Exists("debug"))
                this.DebugMode = true;
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Thunder");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            this.appPath = Application.StartupPath;
            this.uiPath = Path.Combine(this.appPath, "Skin");
            this.Wavplayer = new SoundPlayer();
            this.Vertical = TimeSpan.Parse("00:00:00.8720499");
            this.Horizon = TimeSpan.Parse("00:00:08.1919686");
            this.about = new AboutBox();
            this.myUI = new UI((Form)this, this.pictureBox1, this.toolTip1, this.uiPath, "Launcher.xml");
            this.myUITrayIcon = new UITrayIcon((Form)this, this.about, this.notifyIcon1, this.contextMenuStrip1);
            this.FirePic0 = new Bitmap((Image)this.myUI.GetElementByName("Fire").ImageForeground);
            this.FirePic1 = new Bitmap(Path.Combine(this.uiPath, "fire1.png"));
            this.FirePic2 = new Bitmap(Path.Combine(this.uiPath, "fire2.png"));
            this.FirePic3 = new Bitmap(Path.Combine(this.uiPath, "fire3.png"));
            this.IconOff = new Icon(this.uiPath + "\\icon2.ico");
            this.IconActive = new Icon(this.uiPath + "\\icon1.ico");
            this.myUITrayIcon.myNotifyIcon.Text = "THUNDER";
            this.myUITrayIcon.myNotifyIcon.Icon = this.IconOff;
            this.myUI.AddEvent("Close", new UI.FunctionPointer(this.onClose));
            this.myUI.AddEvent("Minimize", new UI.FunctionPointer(this.onMinimize));
            this.myUI.AddEvent("Up", new UI.FunctionPointer(this.KeyHandle));
            this.myUI.AddEvent("Down", new UI.FunctionPointer(this.KeyHandle));
            this.myUI.AddEvent("Left", new UI.FunctionPointer(this.KeyHandle));
            this.myUI.AddEvent("Right", new UI.FunctionPointer(this.KeyHandle));
            this.myUI.AddEvent("Fire", new UI.FunctionPointer(this.KeyHandle));
            this.myUI.AddEvent("Exit", new UI.FunctionPointer(this.onClose));
            this.myUI.AddEvent("Sound", new UI.FunctionPointer(this.onSound));
            this.myUI.AddEvent("Reset", new UI.FunctionPointer(this.onReset));
            this.myUI.AddEvent("logo", new UI.FunctionPointer(this.onLogo));
            this.pictureBox1.MouseMove += new MouseEventHandler(this.myUI.MouseMove);
            this.pictureBox1.MouseDown += new MouseEventHandler(this.myUI.MouseDown);
            this.pictureBox1.MouseUp += new MouseEventHandler(this.myUI.MouseUp);
            this.pictureBox1.Paint += new PaintEventHandler(this.myUI.Paint);
            this.MoveHeight = 12;
            this.MoveWidth = 8;
            this.RedCnt = this.Rand.Next(0, 40);
            this.BlueCnt1 = this.Rand.Next(0, 40);
            this.BlueCnt2 = this.Rand.Next(0, 40);
            this.RedRandCnt = this.Rand.Next(40, 80);
            this.BlueRandCnt1 = this.Rand.Next(40, 80);
            this.BlueRandCnt2 = this.Rand.Next(40, 80);
            this.SpeedCnt = 5;
            this.USB.VID_List[0] = 2689;
            this.USB.PID_List[0] = 1793;
            this.USB.VID_List[1] = 8483;
            this.USB.PID_List[1] = 4112;
            this.USB.ID_List_Cnt = 2;
            this.USB.RegisterHandle(this.Handle);
            this.timer1.Start();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.Style |= 131072;
                createParams.Style &= -12582913;
                return createParams;
            }
        }

        protected override void WndProc(ref Message m)
        {
            this.USB.ParseMessages(ref m);
            if (m.Msg == (int)SingleProgramInstance.WakeupMessage)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.Visible = true;
                    this.WindowState = FormWindowState.Normal;
                }
                this.Activate();
            }
            base.WndProc(ref m);
        }

        public void onClose(string sender, string type)
        {
            if (!(type == "MouseUp"))
                return;
            this.Close();
        }

        public void onSound(string sender, string type)
        {
            if (!(type == "MouseUp"))
                return;
            this.SoundOn = !this.SoundOn;
            UI.Element elementByName = this.myUI.GetElementByName("Sound");
            elementByName.isDisplayFore = !elementByName.isDisplayFore;
            this.myUI.myPictureBox.Invalidate();
        }

        public void onReset(string sender, string type)
        {
            if (!(type == "MouseUp"))
                return;
            if (!this.ReSet && !this.Firing && !this.Action)
            {
                this.ReSet = true;
                this.ResetTimeout = 0;
                this.ReSet_Status = 0;
                this.myUI.GetElementByName("Reset").isDisplayFore = true;
                this.myUI.myPictureBox.Invalidate();
                if (!this.SoundOn)
                    return;
                this.Wavplayer.Stop();
                this.Wavplayer.SoundLocation = Path.Combine(this.uiPath, "reset.wav");
                this.Wavplayer.Play();
            }
            else
            {
                if (!this.ReSet)
                    return;
                this.SendUSBData(this.STOP);
                this.ReSet = false;
                this.ReSeted = false;
                this.myUI.GetElementByName("Reset").isDisplayFore = false;
                this.myUI.myPictureBox.Invalidate();
            }
        }

        public void onMinimize(string sender, string type)
        {
            if (!(type == "MouseUp"))
                return;
            this.Visible = false;
        }

        public void onLogo(string sender, string type)
        {
            if (type == "MouseUp")
            {
                try
                {
                    Process.Start("http://www.dreamcheeky.com");
                }
                catch (Exception ex)
                {
                }
            }
            else if (type == "MouseEnter")
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                if (!(type == "MouseLeave"))
                    return;
                this.Cursor = Cursors.Default;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point position = Cursor.Position;
            position.X -= this.Left;
            position.Y -= this.Top - 20;
            this.myUI.ShowToolTip(position);
            ++this.timerCnt;
            if (this.timerCnt > 1)
            {
                this.timerCnt = 0;
                if (this.DelayStop)
                {
                    this.DelayStop = false;
                    this.SendUSBData(this.STOP);
                    this.FireTimeCnt = 0;
                    this.Firing = false;
                    this.Fired = true;
                    this.FireCheck = false;
                    if (this.VersionProfile == 0)
                    {
                        if (this.SoundOn)
                        {
                            this.Wavplayer.Stop();
                            this.Wavplayer.SoundLocation = Path.Combine(this.uiPath, "fired.wav");
                            this.Wavplayer.Play();
                        }
                        this.FireAniEn = false;
                        this.FireButtonCnt = 1000;
                    }
                    else if (this.VersionProfile == 1 && this.SoundOn && (this.FireTimeout < 30 || this.FireTimeout > 125))
                        this.Wavplayer.Stop();
                }
                if (this.Firing)
                {
                    ++this.FireTimeout;
                    if (this.FireTimeout < 15 && this.FireTimeout % 2 == 0)
                        this.SendUSBData(this.FIRE);
                    if (this.FireTimeout == 33 && this.VersionProfile == 1)
                    {
                        if (this.SoundOn)
                        {
                            this.Wavplayer.Stop();
                            this.Wavplayer.SoundLocation = Path.Combine(this.uiPath, "fired.wav");
                            this.Wavplayer.Play();
                        }
                        this.FireAniEn = false;
                        this.FireButtonCnt = 1000;
                    }
                    if (this.FireTimeout > 125)
                        this.DelayStop = true;
                }
                if (this.ReSet)
                {
                    ++this.ResetTimeout;
                    if (this.ResetTimeout > 1500)
                    {
                        this.CurrentAction = Form_Fidget.STATUS.FIRED;
                        this.ReSet = false;
                        this.ReSeted = true;
                    }
                }
                if (this.ReSeted)
                {
                    this.ReSeted = false;
                    this.myUI.GetElementByName("Reset").isDisplayFore = false;
                    this.myUI.myPictureBox.Invalidate();
                }
                if (this.Firing || this.Fired || (this.Action || this.ReSet))
                    this.SendUSBData(this.GET_STATUS);
            }
            if (!this.Action)
            {
                int num1 = this.ReSet ? 1 : 0;
            }
            int num2 = this.Firing ? 1 : 0;
            if (this.UpPress)
            {
                ++this.UpCnt;
                if (this.UpCnt == 8)
                    this.SendUSBData(this.UP);
            }
            if (this.DownPress)
            {
                ++this.DownCnt;
                if (this.DownCnt == 8)
                    this.SendUSBData(this.DOWN);
            }
            this.ThunderAnimation();
        }

        public void LoadSetting()
        {
            using (Registry.CurrentUser.OpenSubKey("Software\\Dream Cheeky\\USB Soccer Fidget"))
                ;
        }

        public void SaveSetting()
        {
            using (RegistryKey subKey = Registry.CurrentUser.CreateSubKey("Software\\Dream Cheeky\\USB Soccer Fidget"))
            {
                if (subKey != null)
                {
                    if (this.UserSetting.IsMute)
                        subKey.SetValue("IsMute", (object)1);
                    else
                        subKey.SetValue("IsMute", (object)0);
                    if (this.UserSetting.WindowStart)
                        subKey.SetValue("WindowStart", (object)1);
                    else
                        subKey.SetValue("WindowStart", (object)0);
                    subKey.SetValue("HighScore", (object)this.UserSetting.HighSocre);
                    subKey.SetValue("HighScoreInsane", (object)this.UserSetting.HighScoreInsane);
                }
            }
            string str = "\"" + Application.ExecutablePath + "\" /hide";
            using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                if (registryKey == null)
                    return;
                try
                {
                    if (this.UserSetting.WindowStart)
                    {
                        registryKey.SetValue("USB Soccer Fidget", (object)str);
                    }
                    else
                    {
                        if (registryKey.GetValue("USB Soccer Fidget") == null)
                            return;
                        registryKey.DeleteValue("USB Soccer Fidget");
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        public void ShowForm()
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
            }
            this.Activate();
        }

        private void SendUSBData(byte[] Data)
        {
            if (this.USB.SpecifiedDevice == null)
                return;
            try
            {
                this.USB.SpecifiedDevice.SendData(Data);
            }
            catch (Exception ex)
            {
            }
        }

        private void USB_OnDataRecieved(object sender, DataRecievedEventArgs args)
        {
            this.CMDHandle(args.data);
        }

        private void USB_OnSpecifiedDeviceArrived(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((Delegate)new EventHandler(this.USB_OnSpecifiedDeviceArrived), sender, (object)e);
            }
            else
            {
                this.myUITrayIcon.myNotifyIcon.Icon = this.IconActive;
                this.DevicePresent = true;
                if (this.USB.ProductId == 4112)
                {
                    this.VersionProfile = 1;
                    this.SendUSBData(this.LED_ON);
                    this.Vertical = TimeSpan.Parse("00:00:00.1959375");
                    this.Horizon = TimeSpan.Parse("00:00:02.9640925");
                }
                else
                {
                    this.VersionProfile = 0;
                    this.Vertical = TimeSpan.Parse("00:00:00.8720499");
                    this.Horizon = TimeSpan.Parse("00:00:08.1919686");
                }
                this.SetCMDProfile();
            }
        }

        private void USB_OnSpecifiedDeviceRemoved(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((Delegate)new EventHandler(this.USB_OnSpecifiedDeviceRemoved), sender, (object)e);
            }
            else
            {
                this.DevicePresent = false;
                this.myUITrayIcon.myNotifyIcon.Icon = this.IconOff;
            }
        }

        private void Form_Fidget_KeyDown(object sender, KeyEventArgs e)
        {
            this.KeyHandle(true, e);
        }

        private void Form_Fidget_KeyUp(object sender, KeyEventArgs e)
        {
            this.KeyHandle(false, e);
        }

        private void Form_Fidget_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Firing || this.Fired || (this.Action || this.ReSet))
                this.SendUSBData(this.STOP);
            if (this.VersionProfile != 1)
                return;
            this.SendUSBData(this.LED_OFF);
        }

        private void KeyHandle(string sender, string type)
        {
            if (this.ReSet || !this.DevicePresent)
            {
                if (!(sender == "Fire"))
                    return;
                this.myUI.GetElementByName("Fire").isDisplayFore = false;
                this.myUI.myPictureBox.Invalidate();
            }
            else if (type == "MouseDown")
            {
                switch (sender)
                {
                    case "Up":
                        if (((int)this.Current_Status & 2) != 2 && !this.Firing && !this.Fired)
                        {
                            Thread.Sleep(150);
                            if (this.SoundOn)
                            {
                                this.Wavplayer.SoundLocation = Path.Combine(this.uiPath, "move.wav");
                                this.Wavplayer.PlayLooping();
                            }
                            this.SendUSBData(this.UP);
                            this.CurrentAction = Form_Fidget.STATUS.UP_LIMIT;
                        }
                        this.Action = true;
                        break;
                    case "Down":
                        if (((int)this.Current_Status & 1) != 1 && !this.Firing && !this.Fired)
                        {
                            Thread.Sleep(150);
                            if (this.SoundOn)
                            {
                                this.Wavplayer.SoundLocation = Path.Combine(this.uiPath, "move.wav");
                                this.Wavplayer.PlayLooping();
                            }
                            this.SendUSBData(this.DOWN);
                            this.CurrentAction = Form_Fidget.STATUS.DOWN_LIMIT;
                        }
                        this.Action = true;
                        break;
                    case "Left":
                        if (((int)this.Current_Status & 4) != 4 && !this.Firing && !this.Fired)
                        {
                            Thread.Sleep(150);
                            if (this.SoundOn)
                            {
                                this.Wavplayer.SoundLocation = Path.Combine(this.uiPath, "move.wav");
                                this.Wavplayer.PlayLooping();
                            }
                            this.SendUSBData(this.LEFT);
                            this.CurrentAction = Form_Fidget.STATUS.LEFT_LIMIT;
                        }
                        this.Action = true;
                        break;
                    case "Right":
                        if (((int)this.Current_Status & 8) != 8 && !this.Firing && !this.Fired)
                        {
                            Thread.Sleep(150);
                            if (this.SoundOn)
                            {
                                this.Wavplayer.SoundLocation = Path.Combine(this.uiPath, "move.wav");
                                this.Wavplayer.PlayLooping();
                            }
                            this.SendUSBData(this.RIGHT);
                            this.CurrentAction = Form_Fidget.STATUS.RIGHT_LIMIT;
                        }
                        this.Action = true;
                        break;
                }
            }
            else if (type == "MouseUp")
            {
                this.Action = false;
                if (sender == "Fire" && !this.Firing && (!this.Fired && !this.nFire))
                {
                    if (this.SoundOn)
                    {
                        this.Wavplayer.SoundLocation = Path.Combine(this.uiPath, "firing.wav");
                        this.Wavplayer.PlayLooping();
                    }
                    this.Firing = true;
                    this.FireCheck = false;
                    this.FireTimeout = 0;
                    this.SendUSBData(this.FIRE);
                    this.FireCnt = 0;
                    this.FireAniEn = true;
                    this.SpeedCnt = 2;
                    this.myUI.GetElementByName("Fire").isDisplayFore = true;
                    this.myUI.myPictureBox.Invalidate();
                }
                if (this.Firing || this.nFire || (this.ReSet || this.Calibrate))
                    return;
                if (this.SoundOn)
                    this.Wavplayer.Stop();
                this.SendUSBData(this.STOP);
                this.CurrentAction = Form_Fidget.STATUS.IDLE;
            }
            else if (type == "MouseEnter" && sender == "Fire")
            {
                if (this.Firing)
                    return;
                this.FireAniEn = true;
                this.SpeedCnt = 5;
            }
            else
            {
                if (!(type == "MouseLeave") || !(sender == "Fire") || this.Firing)
                    return;
                this.FireAniEn = false;
                this.FireButtonCnt = 1000;
                this.SpeedCnt = 5;
            }
        }

        private void KeyHandle(bool IsDown, KeyEventArgs e)
        {
            UI.Element element = (UI.Element)null;
            if (IsDown)
            {
                switch (e.KeyCode)
                {
                    case Keys.Space:
                        if (!this.Firing && !this.Fired && (!this.nFire && !this.ReSet) && this.DevicePresent)
                        {
                            if (this.SoundOn)
                            {
                                this.Wavplayer.SoundLocation = Path.Combine(this.uiPath, "firing.wav");
                                this.Wavplayer.PlayLooping();
                            }
                            element = this.myUI.GetElementByName("Fire");
                            this.Firing = true;
                            this.FireCheck = false;
                            this.FireTimeout = 0;
                            this.SendUSBData(this.FIRE);
                            this.FireCnt = 0;
                            this.FireAniEn = true;
                            this.SpeedCnt = 2;
                        }
                        this.Action = true;
                        break;
                    case Keys.Left:
                        if (((int)this.Current_Status & 4) != 4 && !this.Firing && (!this.Fired && !this.Action) && (!this.ReSet && this.DevicePresent))
                        {
                            Thread.Sleep(100);
                            this.Action = true;
                            element = this.myUI.GetElementByName("Left");
                            if (this.SoundOn)
                            {
                                this.Wavplayer.SoundLocation = Path.Combine(this.uiPath, "move.wav");
                                this.Wavplayer.PlayLooping();
                            }
                            this.SendUSBData(this.LEFT);
                            this.CurrentAction = Form_Fidget.STATUS.LEFT_LIMIT;
                        }
                        this.Action = true;
                        break;
                    case Keys.Up:
                        if (((int)this.Current_Status & 2) != 2 && !this.Firing && (!this.Fired && !this.Action) && (!this.ReSet && this.DevicePresent))
                        {
                            this.UpPress = true;
                            this.UpCnt = 0;
                            this.Action = true;
                            element = this.myUI.GetElementByName("Up");
                            if (this.SoundOn)
                            {
                                this.Wavplayer.SoundLocation = Path.Combine(this.uiPath, "move.wav");
                                this.Wavplayer.PlayLooping();
                            }
                            this.SendUSBData(this.UP);
                            Thread.Sleep(40);
                            this.SendUSBData(this.STOP);
                            this.start = DateTime.Now;
                            this.CurrentAction = Form_Fidget.STATUS.UP_LIMIT;
                        }
                        this.Action = true;
                        break;
                    case Keys.Right:
                        if (((int)this.Current_Status & 8) != 8 && !this.Firing && (!this.Fired && !this.Action) && (!this.ReSet && this.DevicePresent))
                        {
                            Thread.Sleep(100);
                            this.Action = true;
                            element = this.myUI.GetElementByName("Right");
                            if (this.SoundOn)
                            {
                                this.Wavplayer.SoundLocation = Path.Combine(this.uiPath, "move.wav");
                                this.Wavplayer.PlayLooping();
                            }
                            this.SendUSBData(this.RIGHT);
                            this.CurrentAction = Form_Fidget.STATUS.RIGHT_LIMIT;
                        }
                        this.Action = true;
                        break;
                    case Keys.Down:
                        if (((int)this.Current_Status & 1) != 1 && !this.Firing && (!this.Fired && !this.Action) && (!this.ReSet && this.DevicePresent))
                        {
                            this.DownPress = true;
                            this.DownCnt = 0;
                            this.Action = true;
                            element = this.myUI.GetElementByName("Down");
                            if (this.SoundOn)
                            {
                                this.Wavplayer.SoundLocation = Path.Combine(this.uiPath, "move.wav");
                                this.Wavplayer.PlayLooping();
                            }
                            this.SendUSBData(this.DOWN);
                            Thread.Sleep(40);
                            this.SendUSBData(this.STOP);
                            this.start = DateTime.Now;
                            this.CurrentAction = Form_Fidget.STATUS.DOWN_LIMIT;
                        }
                        this.Action = true;
                        break;
                }
                if (element == null)
                    return;
                element.isDisplayFore = true;
                this.myUI.myPictureBox.Invalidate();
            }
            else
            {
                this.Action = false;
                this.CurrentAction = Form_Fidget.STATUS.IDLE;
                if (this.Firing || this.nFire || (this.ReSet || this.Calibrate))
                    return;
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        element = this.myUI.GetElementByName("Left");
                        break;
                    case Keys.Up:
                        this.UpPress = false;
                        element = this.myUI.GetElementByName("Up");
                        break;
                    case Keys.Right:
                        element = this.myUI.GetElementByName("Right");
                        break;
                    case Keys.Down:
                        this.DownPress = false;
                        element = this.myUI.GetElementByName("Down");
                        break;
                }
                if (element != null)
                {
                    if (this.SoundOn)
                        this.Wavplayer.Stop();
                    element.isDisplayFore = false;
                    this.myUI.myPictureBox.Invalidate();
                }
                this.SendUSBData(this.STOP);
                this.TestTime[this.TestTimeCnt] = DateTime.Now.Subtract(this.start);
                ++this.TestTimeCnt;
                if (this.TestTimeCnt < 10)
                    return;
                this.TestTimeCnt = 0;
            }
        }

        private void CMDHandle(byte[] Data)
        {
            byte num = this.VersionProfile != 1 ? Data[1] : Data[2];
            this.Current_Status = num;
            if (this.Firing && ((int)num & 16) == 16)
            {
                this.DelayStop = true;
                this.timerCnt = 0;
            }
            if (this.Fired && ((int)num & 16) == 0)
            {
                ++this.FireTimeCnt;
                if (this.FireTimeCnt > 25)
                {
                    this.myUI.GetElementByName("Fire").isDisplayFore = false;
                    this.myUI.myPictureBox.Invalidate();
                    this.Fired = false;
                }
            }
            if (!this.ReSet)
                return;
            if (this.ReSet_Status == 0)
            {
                if (((int)num & 1) != 1)
                {
                    this.SendUSBData(this.DOWN);
                    this.CurrentAction = Form_Fidget.STATUS.DOWN_LIMIT;
                    this.ReSet_Status = 1;
                    this.ResetTimeout = 0;
                }
                else
                    this.ReSet_Status = 2;
            }
            if (this.ReSet_Status == 1 && ((int)num & 1) == 1)
            {
                this.ReSet_Status = 2;
                this.ResetTimeout = 0;
            }
            if (this.ReSet_Status == 2)
            {
                if (((int)num & 4) != 4)
                {
                    this.SendUSBData(this.LEFT);
                    this.CurrentAction = Form_Fidget.STATUS.LEFT_LIMIT;
                    this.ReSet_Status = 3;
                    this.ResetTimeout = 0;
                }
                else
                    this.ReSet_Status = 4;
            }
            if (this.ReSet_Status == 3 && ((int)num & 4) == 4)
            {
                this.ReSet_Status = 4;
                this.ResetTimeout = 0;
            }
            if (this.ReSet_Status == 4)
            {
                this.ReSet_Status = 5;
                this.SendUSBData(this.RIGHT);
                this.CurrentAction = Form_Fidget.STATUS.RIGHT_LIMIT;
                this.start = DateTime.Now;
                this.ResetTimeout = 0;
            }
            if (this.ReSet_Status == 5 && ((int)num & 8) == 8)
            {
                this.ReSet_Status = 6;
                this.Horizon = DateTime.Now.Subtract(this.start);
                this.Horizon = TimeSpan.FromMilliseconds(this.Horizon.TotalMilliseconds / 2.0 * 0.9);
                this.ResetTimeout = 0;
            }
            if (this.ReSet_Status == 6)
            {
                this.ReSet_Status = 7;
                this.SendUSBData(this.LEFT);
                this.CurrentAction = Form_Fidget.STATUS.LEFT_LIMIT;
                this.ResetTimeout = 0;
            }
            if (this.ReSet_Status == 7 && ((int)num & 4) == 4)
            {
                this.ReSet_Status = 8;
                this.start = DateTime.Now;
                this.SendUSBData(this.RIGHT);
                this.CurrentAction = Form_Fidget.STATUS.RIGHT_LIMIT;
                this.ResetTimeout = 0;
            }
            if (this.ReSet_Status == 8)
            {
                this.stop = DateTime.Now.Subtract(this.start);
                if (this.stop > this.Horizon)
                {
                    this.ReSet_Status = 9;
                    this.SendUSBData(this.UP);
                    this.CurrentAction = Form_Fidget.STATUS.UP_LIMIT;
                    this.start = DateTime.Now;
                    this.ResetTimeout = 0;
                }
            }
            if (this.ReSet_Status == 9 && ((int)num & 2) == 2)
            {
                this.ReSet_Status = 10;
                this.Vertical = DateTime.Now.Subtract(this.start);
                this.Vertical = TimeSpan.FromMilliseconds(this.Vertical.TotalMilliseconds / 2.0);
                this.ResetTimeout = 0;
            }
            if (this.ReSet_Status == 10)
            {
                this.ReSet_Status = 11;
                this.SendUSBData(this.DOWN);
                this.CurrentAction = Form_Fidget.STATUS.DOWN_LIMIT;
                this.ResetTimeout = 0;
            }
            if (this.ReSet_Status == 11 && ((int)num & 1) == 1)
            {
                this.ReSet_Status = 12;
                this.start = DateTime.Now;
                this.SendUSBData(this.UP);
                this.CurrentAction = Form_Fidget.STATUS.UP_LIMIT;
                this.ResetTimeout = 0;
            }
            if (this.ReSet_Status != 12)
                return;
            this.stop = DateTime.Now.Subtract(this.start);
            if (!(this.stop > this.Vertical))
                return;
            this.SendUSBData(this.STOP);
            this.CurrentAction = Form_Fidget.STATUS.FIRED;
            this.ResetTimeout = 0;
            this.ReSet = false;
            this.ReSeted = true;
        }

        private void MovePicture()
        {
            if (this.CurrentAction != Form_Fidget.STATUS.FIRED)
                return;
            this.CurrentAction = Form_Fidget.STATUS.IDLE;
            this.ReSet = false;
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            if (this.Firing || this.Fired)
                return;
            this.SrcRect.Location = this.CenterPoint;
            e.Graphics.DrawImage((Image)this.mask, this.DesRect, this.SrcRect, GraphicsUnit.Pixel);
        }

        private void SetCMDProfile()
        {
            if (this.VersionProfile == 0)
            {
                this.UP = this.UP0;
                this.DOWN = this.DOWN0;
                this.LEFT = this.LEFT0;
                this.RIGHT = this.RIGHT0;
                this.FIRE = this.FIRE0;
                this.STOP = this.STOP0;
                this.GET_STATUS = this.GET_STATUS0;
            }
            else
            {
                if (this.VersionProfile != 1)
                    return;
                this.UP = this.UP1;
                this.DOWN = this.DOWN1;
                this.LEFT = this.LEFT1;
                this.RIGHT = this.RIGHT1;
                this.FIRE = this.FIRE1;
                this.STOP = this.STOP1;
                this.GET_STATUS = this.GET_STATUS1;
            }
        }

        private void ThunderAnimation()
        {
            ++this.SquareCnt;
            ++this.RedCnt;
            ++this.BlueCnt1;
            ++this.BlueCnt2;
            if (this.FireAniEn)
                ++this.FireButtonCnt;
            if (this.SquareCnt == 8)
            {
                this.myUI.GetElementByName("Square1").isDisplayFore = false;
                this.myUI.GetElementByName("Square2").isDisplayFore = false;
                this.myUI.GetElementByName("Square3").isDisplayFore = false;
            }
            else if (this.SquareCnt == 16)
            {
                this.myUI.GetElementByName("Square1").isDisplayFore = false;
                this.myUI.GetElementByName("Square2").isDisplayFore = false;
                this.myUI.GetElementByName("Square3").isDisplayFore = true;
            }
            else if (this.SquareCnt == 24)
            {
                this.myUI.GetElementByName("Square1").isDisplayFore = false;
                this.myUI.GetElementByName("Square2").isDisplayFore = true;
                this.myUI.GetElementByName("Square3").isDisplayFore = true;
            }
            else if (this.SquareCnt >= 32)
            {
                this.myUI.GetElementByName("Square1").isDisplayFore = true;
                this.myUI.GetElementByName("Square2").isDisplayFore = true;
                this.myUI.GetElementByName("Square3").isDisplayFore = true;
                this.SquareCnt = 0;
            }
            if (this.FireButtonCnt == this.SpeedCnt)
            {
                UI.Element elementByName = this.myUI.GetElementByName("Fire");
                elementByName.ImageForeground = this.FirePic1;
                elementByName.isDisplayFore = true;
            }
            else if (this.FireButtonCnt == this.SpeedCnt * 2)
            {
                UI.Element elementByName = this.myUI.GetElementByName("Fire");
                elementByName.ImageForeground = this.FirePic2;
                elementByName.isDisplayFore = true;
            }
            else if (this.FireButtonCnt == this.SpeedCnt * 3)
            {
                UI.Element elementByName = this.myUI.GetElementByName("Fire");
                elementByName.ImageForeground = this.FirePic3;
                elementByName.isDisplayFore = true;
            }
            else if (this.FireButtonCnt >= this.SpeedCnt * 4)
            {
                UI.Element elementByName = this.myUI.GetElementByName("Fire");
                elementByName.ImageForeground = this.FirePic0;
                elementByName.isDisplayFore = false;
                this.FireButtonCnt = 0;
            }
            if (this.RedCnt > this.RedRandCnt)
            {
                UI.Element elementByName = this.myUI.GetElementByName("RedRect1");
                elementByName.isDisplayFore = !elementByName.isDisplayFore;
                this.RedCnt = 0;
                this.RedRandCnt = elementByName.isDisplayFore ? this.Rand.Next(20, 50) : this.Rand.Next(10, 20);
            }
            if (this.BlueCnt1 > this.BlueRandCnt1)
            {
                UI.Element elementByName = this.myUI.GetElementByName("BlueRect1");
                elementByName.isDisplayFore = !elementByName.isDisplayFore;
                this.BlueCnt1 = 0;
                this.BlueRandCnt1 = elementByName.isDisplayFore ? this.Rand.Next(30, 70) : this.Rand.Next(5, 20);
            }
            if (this.BlueCnt2 > this.BlueRandCnt2)
            {
                UI.Element elementByName = this.myUI.GetElementByName("BlueRect2");
                elementByName.isDisplayFore = !elementByName.isDisplayFore;
                this.BlueCnt2 = 0;
                this.BlueRandCnt2 = elementByName.isDisplayFore ? this.Rand.Next(50, 120) : this.Rand.Next(5, 10);
            }
            this.myUI.myPictureBox.Invalidate();
        }

        private void ClearAni()
        {
            this.myUI.GetElementByName("Square1").isDisplayFore = true;
            this.myUI.GetElementByName("Square2").isDisplayFore = true;
            this.myUI.GetElementByName("Square3").isDisplayFore = true;
            this.myUI.GetElementByName("RedRect1").isDisplayFore = true;
            this.myUI.GetElementByName("BlueRect1").isDisplayFore = true;
            this.myUI.GetElementByName("BlueRect2").isDisplayFore = true;
            this.myUI.myPictureBox.Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.about.AboutClose = true;
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Fidget));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.USB = new UsbLibrary.UsbHidPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(356, 708);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(35, 357);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 210);
            this.panel1.TabIndex = 1;
            this.panel1.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(287, 210);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(321, 357);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(35, 210);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // USB
            // 
            this.USB.ProductId = 0;
            this.USB.SpecifiedDevice = null;
            this.USB.VendorId = 0;
            this.USB.OnSpecifiedDeviceArrived += new System.EventHandler(this.USB_OnSpecifiedDeviceArrived);
            this.USB.OnSpecifiedDeviceRemoved += new System.EventHandler(this.USB_OnSpecifiedDeviceRemoved);
            this.USB.OnDataRecieved += new UsbLibrary.DataRecievedEventHandler(this.USB_OnDataRecieved);
            // 
            // Form_Fidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 708);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Fidget";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Missile Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Fidget_FormClosing);
            this.Load += new System.EventHandler(this.Form_Fidget_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_Fidget_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_Fidget_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        private enum STATUS
        {
            IDLE = 0,
            DOWN_LIMIT = 1,
            UP_LIMIT = 2,
            LEFT_LIMIT = 4,
            RIGHT_LIMIT = 8,
            FIRED = 16, // 0x00000010
        }
    }
}
