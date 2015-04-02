namespace Chapter15_Async_Await
{
  using System;

  using MiscUtil;

  class Program
  {
    [STAThread]
    static void Main(string[] args)
    {
      ApplicationChooser.Run(typeof(Program), args);
    }
  }
}