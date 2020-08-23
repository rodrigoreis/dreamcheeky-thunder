// Decompiled with JetBrains decompiler
// Type: CommonComponent.NativeMethods
// Assembly: THUNDER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 06011ABE-59E1-47C7-BE89-C6760127171E
// Assembly location: C:\Program Files (x86)\Dream Cheeky\Thunder\THUNDER.exe

using System;
using System.Runtime.InteropServices;

namespace CommonComponent
{
  internal class NativeMethods
  {
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern uint RegisterWindowMessage(string lpString);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll")]
    public static extern int SendNotifyMessage(
      IntPtr hWnd,
      uint Msg,
      IntPtr wParam,
      IntPtr lParam);
  }
}
