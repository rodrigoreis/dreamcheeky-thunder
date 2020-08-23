// Decompiled with JetBrains decompiler
// Type: CommonComponent.ExceptionHandle
// Assembly: THUNDER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 06011ABE-59E1-47C7-BE89-C6760127171E
// Assembly location: C:\Program Files (x86)\Dream Cheeky\Thunder\THUNDER.exe

using System;
using System.IO;
using System.Threading;

namespace CommonComponent
{
  internal class ExceptionHandle
  {
    private static string NamePath = "Thunder";

    public static void CurrentDomain_UnhandledException(
      object sender,
      UnhandledExceptionEventArgs e)
    {
      string path = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ExceptionHandle.NamePath), "crash.log");
      try
      {
        using (StreamWriter streamWriter = new StreamWriter(path, true))
        {
          streamWriter.WriteLine(DateTime.Now.ToString("G"));
          streamWriter.WriteLine("/********************************/");
          for (Exception exception = e.ExceptionObject as Exception; exception != null; exception = exception.InnerException)
          {
            streamWriter.WriteLine(exception.Message);
            streamWriter.WriteLine(exception.StackTrace);
            streamWriter.WriteLine(exception.Source);
            streamWriter.WriteLine((object) exception.TargetSite);
          }
        }
      }
      catch (Exception ex)
      {
      }
    }

    public static void Application_ThreadException(object a, ThreadExceptionEventArgs e)
    {
      string path = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ExceptionHandle.NamePath), "exception.log");
      try
      {
        using (StreamWriter streamWriter = new StreamWriter(path, true))
        {
          streamWriter.WriteLine(DateTime.Now.ToString("G"));
          streamWriter.WriteLine("/********************************/");
          for (Exception exception = e.Exception; exception != null; exception = exception.InnerException)
          {
            streamWriter.WriteLine(exception.Message);
            streamWriter.WriteLine(exception.StackTrace);
            streamWriter.WriteLine(exception.Source);
            streamWriter.WriteLine((object) exception.TargetSite);
          }
        }
      }
      catch (Exception ex)
      {
      }
    }

    public static void Exception_Log(Exception exp)
    {
      string path = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ExceptionHandle.NamePath), "CatchedException.log");
      try
      {
        using (StreamWriter streamWriter = new StreamWriter(path, true))
        {
          streamWriter.WriteLine(DateTime.Now.ToString("G"));
          streamWriter.WriteLine("/********************************/");
          for (; exp != null; exp = exp.InnerException)
          {
            streamWriter.WriteLine(exp.Message);
            streamWriter.WriteLine(exp.StackTrace);
            streamWriter.WriteLine(exp.Source);
            streamWriter.WriteLine((object) exp.TargetSite);
          }
        }
      }
      catch (Exception ex)
      {
      }
    }
  }
}
