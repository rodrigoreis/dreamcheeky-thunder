// Decompiled with JetBrains decompiler
// Type: Missile_Launcher.Program
// Assembly: THUNDER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 06011ABE-59E1-47C7-BE89-C6760127171E
// Assembly location: C:\Program Files (x86)\Dream Cheeky\Thunder\THUNDER.exe

using CommonComponent;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Missile_Launcher
{
  internal static class Program
  {
    private static Mutex onlyOne;

    [STAThread]
    private static void Main()
    {
      using (SingleProgramInstance singleProgramInstance = new SingleProgramInstance("THUNDER"))
      {
        if (singleProgramInstance.IsSingleInstance)
        {
          AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(ExceptionHandle.CurrentDomain_UnhandledException);
          Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
          string[] commandLineArgs = Environment.GetCommandLineArgs();
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
          if (commandLineArgs.Length == 2 && commandLineArgs[1] == "/hide")
            Application.Run((Form) new Form_Fidget(true));
          else
            Application.Run((Form) new Form_Fidget(false));
        }
        else
          singleProgramInstance.RaiseOtherProcess();
      }
    }
  }
}
