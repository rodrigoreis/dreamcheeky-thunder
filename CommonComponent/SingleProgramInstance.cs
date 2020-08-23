// Decompiled with JetBrains decompiler
// Type: CommonComponent.SingleProgramInstance
// Assembly: THUNDER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 06011ABE-59E1-47C7-BE89-C6760127171E
// Assembly location: C:\Program Files (x86)\Dream Cheeky\Thunder\THUNDER.exe

using System;
using System.Reflection;
using System.Threading;

namespace CommonComponent
{
  public class SingleProgramInstance : IDisposable
  {
    private static IntPtr HWND_BROADCAST = (IntPtr) (int) ushort.MaxValue;
    public static uint WakeupMessage;
    private Mutex _processSync;
    private bool _owned;

    public SingleProgramInstance()
      : this("")
    {
    }

    public SingleProgramInstance(string identifier)
    {
      SingleProgramInstance.WakeupMessage = NativeMethods.RegisterWindowMessage("MyApplication_Wakeup");
      this._processSync = new Mutex(true, Assembly.GetExecutingAssembly().GetName().Name + identifier, out this._owned);
    }

    ~SingleProgramInstance()
    {
      this.Release();
    }

    public bool IsSingleInstance
    {
      get
      {
        return this._owned;
      }
    }

    public void RaiseOtherProcess()
    {
      NativeMethods.SendNotifyMessage(SingleProgramInstance.HWND_BROADCAST, SingleProgramInstance.WakeupMessage, IntPtr.Zero, IntPtr.Zero);
    }

    private void Release()
    {
      if (!this._owned)
        return;
      this._processSync.ReleaseMutex();
      this._owned = false;
    }

    public void Dispose()
    {
      this.Release();
      GC.SuppressFinalize((object) this);
    }
  }
}
