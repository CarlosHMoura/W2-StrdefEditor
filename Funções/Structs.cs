 
using System.Runtime.InteropServices;

namespace W2___Strdef_Editor.Funções
{
  internal class Structs
  {
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct STRUCT_STRDEF
    {
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2000)]
      public Structs.stSTRDEF[] Strdef;
    }

    public struct stSTRDEF
    {
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
      public string Value;
    }
  }
}
