// Decompiled with JetBrains decompiler
// Type: CommonComponent.UI
// Assembly: THUNDER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 06011ABE-59E1-47C7-BE89-C6760127171E
// Assembly location: C:\Program Files (x86)\Dream Cheeky\Thunder\THUNDER.exe

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.XPath;

namespace CommonComponent
{
  internal class UI
  {
    private const string ButtonType = "button";
    private const string CheckType = "check";
    private const string StaticType = "static";
    private const string RadioType = "radio";
    private const string TrackbarType = "trackbar";
    private const string CustomType = "custom";
    private const string Control = "control";
    private Form myForm;
    public PictureBox myPictureBox;
    public ToolTip myToolTip;
    private string uiPath;
    private string xmlPath;
    private Bitmap picForeground;
    private Bitmap picHighlight;
    private Bitmap picBackground;
    private Point cursorPos;
    private bool isFormMoving;
    private int ToolTipCnt;
    public List<UI.Element> elementlist;

    public UI(
      Form aForm,
      PictureBox aPictureBox,
      ToolTip aToolTip,
      string path,
      string xmlFileName)
    {
      this.cursorPos = new Point();
      this.myForm = aForm;
      this.myPictureBox = aPictureBox;
      this.myToolTip = aToolTip;
      this.uiPath = path;
      this.xmlPath = Path.Combine(this.uiPath, xmlFileName);
      this.elementlist = new List<UI.Element>();
      this.Init_FormUI();
    }

    public void AddEvent(string name, UI.FunctionPointer fn)
    {
      foreach (UI.Element element in this.elementlist)
      {
        if (element.Name == name)
          element.Exec = fn;
      }
    }

    public UI.Element GetElementByName(string name)
    {
      UI.Element element1 = (UI.Element) null;
      foreach (UI.Element element2 in this.elementlist)
      {
        if (element2.Name == name)
          element1 = element2;
      }
      return element1;
    }

    public void AddElement(string name, string type, Point aPoint, Size aSize, string tooltip)
    {
      UI.Element element = new UI.Element()
      {
        Name = name,
        Type = type,
        Tooltip = tooltip,
        Rect = {
          Location = aPoint,
          Size = aSize
        }
      };
      element.Rect2 = element.Rect;
      element.ImageHighlight = this.picHighlight.Clone(element.Rect, this.picHighlight.PixelFormat);
      element.ImageForeground = this.picForeground.Clone(element.Rect, this.picForeground.PixelFormat);
      element.hasToolTip = tooltip != null;
      if (type == "static")
        element.isDisplayFore = true;
      element.Exec = (UI.FunctionPointer) null;
      this.elementlist.Add(element);
    }

    public void Paint(object sender, PaintEventArgs e)
    {
      foreach (UI.Element element in this.elementlist)
      {
        if (element.isDisplayFore)
        {
          e.Graphics.DrawImage((Image) element.ImageForeground, element.Rect);
          element.isDisplay = false;
        }
        else if (element.isDisplay)
        {
          e.Graphics.DrawImage((Image) element.ImageHighlight, element.Rect);
          element.isDisplayFore = false;
        }
      }
    }

    public void ShowToolTip(Point point)
    {
      if (this.ToolTipCnt != -1)
        ++this.ToolTipCnt;
      if (this.ToolTipCnt < 5)
        return;
      foreach (UI.Element element in this.elementlist)
      {
        if (element.isEnter && element.hasToolTip)
          this.myToolTip.Show(element.Tooltip, (IWin32Window) this.myForm, point);
      }
      this.ToolTipCnt = -1;
    }

    private string GetInnerContent(XPathNodeIterator parent, string xpath)
    {
      XPathNodeIterator xpathNodeIterator = parent.Current.Select(xpath);
      return xpathNodeIterator.MoveNext() ? xpathNodeIterator.Current.InnerXml : (string) null;
    }

    public void Init_FormUI()
    {
      try
      {
        XPathNavigator navigator = new XPathDocument(this.xmlPath).CreateNavigator();
        navigator.MoveToRoot();
        XPathNodeIterator parent1 = navigator.Select("/form/property");
        while (parent1.MoveNext())
        {
          switch (this.GetInnerContent(parent1, "name"))
          {
            case "picBackground":
              this.picBackground = new Bitmap(Path.Combine(this.uiPath, this.GetInnerContent(parent1, "value")));
              this.myPictureBox.Image = (Image) this.picBackground;
              this.myForm.Size = this.picBackground.Size;
              this.myPictureBox.Size = this.picBackground.Size;
              continue;
            case "picForeground":
              this.picForeground = new Bitmap(Path.Combine(this.uiPath, this.GetInnerContent(parent1, "value")));
              continue;
            case "picHighlight":
              this.picHighlight = new Bitmap(Path.Combine(this.uiPath, this.GetInnerContent(parent1, "value")));
              continue;
            default:
              continue;
          }
        }
        navigator.MoveToRoot();
        XPathNodeIterator parent2 = navigator.Select("/form/region");
        Size aSize = new Size();
        Point aPoint = new Point();
        while (parent2.MoveNext())
        {
          string innerContent1 = this.GetInnerContent(parent2, "name");
          string innerContent2 = this.GetInnerContent(parent2, "type");
          aPoint.X = Convert.ToInt32(this.GetInnerContent(parent2, "X"));
          aPoint.Y = Convert.ToInt32(this.GetInnerContent(parent2, "Y"));
          aSize.Width = Convert.ToInt32(this.GetInnerContent(parent2, "Width"));
          aSize.Height = Convert.ToInt32(this.GetInnerContent(parent2, "Height"));
          string innerContent3 = this.GetInnerContent(parent2, "tooltip");
          if (innerContent2 != "control")
          {
            this.AddElement(innerContent1, innerContent2, aPoint, aSize, innerContent3);
            if (innerContent2 == "trackbar")
            {
              this.elementlist[this.elementlist.Count - 1].ImageForeground = new Bitmap(Path.Combine(this.uiPath, this.GetInnerContent(parent2, "value")));
              aSize.Width = Convert.ToInt32(this.GetInnerContent(parent2, "Widthbar"));
              aSize.Height = Convert.ToInt32(this.GetInnerContent(parent2, "Heightbar"));
              this.elementlist[this.elementlist.Count - 1].Rect2.Size = aSize;
              this.elementlist[this.elementlist.Count - 1].isDisplayFore = true;
            }
            else
            {
              string innerContent4 = this.GetInnerContent(parent2, "value");
              if (innerContent4 != null)
              {
                this.elementlist[this.elementlist.Count - 1].ImageForeground = new Bitmap(Path.Combine(this.uiPath, innerContent4));
                this.elementlist[this.elementlist.Count - 1].isDisplayFore = true;
              }
            }
          }
          else
          {
            System.Windows.Forms.Control control = this.myForm.Controls[innerContent1];
            control.Size = aSize;
            control.Location = aPoint;
          }
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
        Environment.Exit(0);
      }
    }

    public void MouseUp(object sender, MouseEventArgs e)
    {
      this.isFormMoving = false;
      foreach (UI.Element element in this.elementlist)
      {
        if (element.Rect.Contains(e.Location))
        {
          if (element.isDown)
          {
            switch (element.Type)
            {
              case "button":
                element.isDisplayFore = false;
                element.isDisplay = true;
                break;
              case "check":
                element.checkstate = !element.checkstate;
                element.isDisplayFore = element.checkstate;
                element.isDisplay = true;
                break;
            }
            if (element.Exec != null)
            {
              element.Exec(element.Name, nameof (MouseUp));
              element.isDisplay = false;
            }
          }
          else
          {
            switch (element.Type)
            {
              case "radio":
                if (!element.checkstate)
                {
                  element.isDisplayFore = false;
                  element.isDisplay = false;
                  break;
                }
                break;
              default:
                element.isDisplayFore = false;
                element.isDisplay = false;
                break;
            }
          }
        }
        element.isDown = false;
      }
      this.myPictureBox.Invalidate();
    }

    public void MouseDown(object sender, MouseEventArgs e)
    {
      bool flag = false;
      foreach (UI.Element element in this.elementlist)
      {
        if (element.Rect.Contains(e.Location))
        {
          flag = true;
          element.isDown = true;
          switch (element.Type)
          {
            case "button":
              element.isDisplayFore = true;
              break;
            case "radio":
              element.isDisplayFore = true;
              break;
          }
          if (element.Exec != null)
            element.Exec(element.Name, nameof (MouseDown));
        }
      }
      this.myPictureBox.Invalidate();
      if (flag)
        return;
      this.isFormMoving = true;
      this.cursorPos.X = e.X;
      this.cursorPos.Y = e.Y;
    }

    public void MouseMove(object sender, MouseEventArgs e)
    {
      if (this.isFormMoving)
      {
        this.myForm.Location = new Point(this.myForm.Left + e.X - this.cursorPos.X, this.myForm.Top + e.Y - this.cursorPos.Y);
        this.myForm.Refresh();
      }
      else
      {
        foreach (UI.Element element in this.elementlist)
        {
          if (element.Rect.Contains(e.Location) && !element.isEnter)
          {
            element.isEnter = true;
            if (element.isDown)
            {
              switch (element.Type)
              {
                case "button":
                  element.isDisplayFore = true;
                  break;
                case "radio":
                  element.isDisplayFore = true;
                  break;
              }
            }
            else if (element.Type != "custom" && element.Type != "static")
              element.isDisplay = true;
            else if (element.Type == "custom" && !element.isDisplayFore)
              element.isDisplay = true;
            if (element.Exec != null)
              element.Exec(element.Name, "MouseEnter");
            this.ToolTipCnt = 0;
          }
          else if (!element.Rect.Contains(e.Location) && element.isEnter)
          {
            element.isDisplay = false;
            element.isEnter = false;
            switch (element.Type)
            {
              case "button":
                element.isDisplayFore = false;
                break;
              case "radio":
                if (!element.checkstate)
                {
                  element.isDisplayFore = false;
                  break;
                }
                break;
            }
            if (element.Exec != null)
              element.Exec(element.Name, "MouseLeave");
            this.myToolTip.Hide((IWin32Window) this.myForm);
          }
          if (element.isDown)
          {
            switch (element.Type)
            {
              case "trackbar":
                if (e.X - element.Rect.Width / 2 >= element.Rect2.X && e.X - element.Rect.Width / 2 <= element.Rect2.X + element.Rect2.Width)
                {
                  element.Rect.X = e.X - element.Rect.Width / 2;
                  if (element.Exec != null)
                  {
                    element.Exec(element.Name, nameof (MouseMove));
                    continue;
                  }
                  continue;
                }
                continue;
              default:
                continue;
            }
          }
        }
        this.myPictureBox.Invalidate();
      }
    }

    public delegate void FunctionPointer(string sender, string type);

    public class Element
    {
      public string Name;
      public string Tooltip;
      public string Type;
      public Bitmap ImageHighlight;
      public Bitmap ImageForeground;
      public Rectangle Rect;
      public Rectangle Rect2;
      public bool checkstate;
      public bool isDisplay;
      public bool isDisplayFore;
      public bool isDown;
      public bool isEnter;
      public bool hasToolTip;
      public UI.FunctionPointer Exec;
    }
  }
}
