
// Type: GE.Properties.Resources

// MVID: 7AA6A484-F524-42F2-9571-0947D386B578
// Assembly location: C:\Documents and Settings\THE RAIN\Desktop\ge.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace GE.Properties
{
  [DebuggerNonUserCode]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals( Resources.resourceMan,  null))
          Resources.resourceMan = new ResourceManager("GE.Properties.Resources", typeof (Resources).Assembly);
        return Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return Resources.resourceCulture;
      }
      set
      {
        Resources.resourceCulture = value;
      }
    }

    internal static Bitmap BG2Viewer
    {
      get
      {
        return (Bitmap) Resources.ResourceManager.GetObject("BG2Viewer", Resources.resourceCulture);
      }
    }

    internal static Bitmap BG3Viewer
    {
      get
      {
        return (Bitmap) Resources.ResourceManager.GetObject("BG3Viewer", Resources.resourceCulture);
      }
    }

    internal static Bitmap ExitEditor
    {
      get
      {
        return (Bitmap) Resources.ResourceManager.GetObject("ExitEditor", Resources.resourceCulture);
      }
    }

    internal static Bitmap HeaderEditor
    {
      get
      {
        return (Bitmap) Resources.ResourceManager.GetObject("HeaderEditor", Resources.resourceCulture);
      }
    }

    internal static string level_name_list
    {
      get
      {
        return Resources.ResourceManager.GetString("level_name_list", Resources.resourceCulture);
      }
    }

    internal static Bitmap LevelSelect
    {
      get
      {
        return (Bitmap) Resources.ResourceManager.GetObject("LevelSelect", Resources.resourceCulture);
      }
    }

    internal static Bitmap map
    {
      get
      {
        return (Bitmap) Resources.ResourceManager.GetObject("map", Resources.resourceCulture);
      }
    }

    internal static Bitmap Map16Editor
    {
      get
      {
        return (Bitmap) Resources.ResourceManager.GetObject("Map16Editor", Resources.resourceCulture);
      }
    }

    internal static Bitmap New
    {
      get
      {
        return (Bitmap) Resources.ResourceManager.GetObject("New", Resources.resourceCulture);
      }
    }

    internal static Bitmap ObjectEditMode
    {
      get
      {
        return (Bitmap) Resources.ResourceManager.GetObject("ObjectEditMode", Resources.resourceCulture);
      }
    }

    internal static string objects_info
    {
      get
      {
        return Resources.ResourceManager.GetString("objects_info", Resources.resourceCulture);
      }
    }

    internal static Bitmap Open
    {
      get
      {
        return (Bitmap) Resources.ResourceManager.GetObject("Open", Resources.resourceCulture);
      }
    }

    internal static Bitmap PaletteEditor
    {
      get
      {
        return (Bitmap) Resources.ResourceManager.GetObject("PaletteEditor", Resources.resourceCulture);
      }
    }

    internal static Bitmap Redo
    {
      get
      {
        return (Bitmap) Resources.ResourceManager.GetObject("Redo", Resources.resourceCulture);
      }
    }

    internal static Bitmap Save
    {
      get
      {
        return (Bitmap) Resources.ResourceManager.GetObject("Save", Resources.resourceCulture);
      }
    }

    internal static Bitmap Selector
    {
      get
      {
        return (Bitmap) Resources.ResourceManager.GetObject("Selector", Resources.resourceCulture);
      }
    }

    internal static Bitmap SpriteEditMode
    {
      get
      {
        return (Bitmap) Resources.ResourceManager.GetObject("SpriteEditMode", Resources.resourceCulture);
      }
    }

    internal static Bitmap Undo
    {
      get
      {
        return (Bitmap) Resources.ResourceManager.GetObject("Undo", Resources.resourceCulture);
      }
    }

    internal Resources()
    {
    }
  }
}
