 
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace W2___Strdef_Editor.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (W2___Strdef_Editor.Properties.Resources.resourceMan == null)
          W2___Strdef_Editor.Properties.Resources.resourceMan = new ResourceManager("W2___Strdef_Editor.Properties.Resources", typeof (W2___Strdef_Editor.Properties.Resources).Assembly);
        return W2___Strdef_Editor.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return W2___Strdef_Editor.Properties.Resources.resourceCulture;
      }
      set
      {
        W2___Strdef_Editor.Properties.Resources.resourceCulture = value;
      }
    }
  }
}
