 
using System;
using System.Windows.Forms;

namespace W2___Strdef_Editor
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new Window());
    }
  }
}
