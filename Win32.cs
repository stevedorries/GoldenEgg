
// Type: Win32

// MVID: 7AA6A484-F524-42F2-9571-0947D386B578
// Assembly location: C:\Documents and Settings\THE RAIN\Desktop\ge.exe

using System;
using System.Runtime.InteropServices;

public class Win32
{
  public const int WS_HSCROLL = 1048576;
  public const int WS_VSCROLL = 2097152;
  public const int CS_VREDRAW = 1;
  public const int CS_HREDRAW = 2;
  public const int CS_DBLCLKS = 8;
  public const int CS_OWNDC = 20;
  public const int CS_CLASSDC = 40;
  public const int CS_PARENTDC = 80;
  public const int CS_NOCLOSE = 200;
  public const int CS_SAVEBITS = 800;
  public const int CS_BYTEALIGNCLIENT = 1000;
  public const int CS_BYTEALIGNWINDOW = 2000;
  public const int CS_GLOBALCLASS = 4000;
  public const int WM_NULL = 0;
  public const int WM_CREATE = 1;
  public const int WM_DESTROY = 2;
  public const int WM_MOVE = 3;
  public const int WM_SIZE = 5;
  public const int WM_ACTIVATE = 6;
  public const int WM_SETFOCUS = 7;
  public const int WM_KILLFOCUS = 8;
  public const int WM_ENABLE = 10;
  public const int WM_SETREDRAW = 11;
  public const int WM_SETTEXT = 12;
  public const int WM_GETTEXT = 13;
  public const int WM_GETTEXTLENGTH = 14;
  public const int WM_PAINT = 15;
  public const int WM_CLOSE = 16;
  public const int WM_QUERYENDSESSION = 17;
  public const int WM_QUIT = 18;
  public const int WM_QUERYOPEN = 19;
  public const int WM_ERASEBKGND = 20;
  public const int WM_SYSCOLORCHANGE = 21;
  public const int WM_ENDSESSION = 22;
  public const int WM_SHOWWINDOW = 24;
  public const int WM_WININICHANGE = 26;
  public const int WM_SETTINGCHANGE = 26;
  public const int WM_DEVMODECHANGE = 27;
  public const int WM_ACTIVATEAPP = 28;
  public const int WM_FONTCHANGE = 29;
  public const int WM_TIMECHANGE = 30;
  public const int WM_CANCELMODE = 31;
  public const int WM_SETCURSOR = 32;
  public const int WM_MOUSEACTIVATE = 33;
  public const int WM_CHILDACTIVATE = 34;
  public const int WM_QUEUESYNC = 35;
  public const int WM_GETMINMAXINFO = 36;
  public const int WM_PAINTICON = 38;
  public const int WM_ICONERASEBKGND = 39;
  public const int WM_NEXTDLGCTL = 40;
  public const int WM_SPOOLERSTATUS = 42;
  public const int WM_DRAWITEM = 43;
  public const int WM_MEASUREITEM = 44;
  public const int WM_DELETEITEM = 45;
  public const int WM_VKEYTOITEM = 46;
  public const int WM_CHARTOITEM = 47;
  public const int WM_SETFONT = 48;
  public const int WM_GETFONT = 49;
  public const int WM_SETHOTKEY = 50;
  public const int WM_GETHOTKEY = 51;
  public const int WM_QUERYDRAGICON = 55;
  public const int WM_COMPAREITEM = 57;
  public const int WM_GETOBJECT = 61;
  public const int WM_COMPACTING = 65;
  public const int WM_COMMNOTIFY = 68;
  public const int WM_WINDOWPOSCHANGING = 70;
  public const int WM_WINDOWPOSCHANGED = 71;
  public const int WM_POWER = 72;
  public const int WM_COPYDATA = 74;
  public const int WM_CANCELJOURNAL = 75;
  public const int WM_NOTIFY = 78;
  public const int WM_INPUTLANGCHANGEREQUEST = 80;
  public const int WM_INPUTLANGCHANGE = 81;
  public const int WM_TCARD = 82;
  public const int WM_HELP = 83;
  public const int WM_USERCHANGED = 84;
  public const int WM_NOTIFYFORMAT = 85;
  public const int WM_CONTEXTMENU = 123;
  public const int WM_STYLECHANGING = 124;
  public const int WM_STYLECHANGED = 125;
  public const int WM_DISPLAYCHANGE = 126;
  public const int WM_GETICON = 127;
  public const int WM_SETICON = 128;
  public const int WM_NCCREATE = 129;
  public const int WM_NCDESTROY = 130;
  public const int WM_NCCALCSIZE = 131;
  public const int WM_NCHITTEST = 132;
  public const int WM_NCPAINT = 133;
  public const int WM_NCACTIVATE = 134;
  public const int WM_GETDLGCODE = 135;
  public const int WM_SYNCPAINT = 136;
  public const int WM_NCMOUSEMOVE = 160;
  public const int WM_NCLBUTTONDOWN = 161;
  public const int WM_NCLBUTTONUP = 162;
  public const int WM_NCLBUTTONDBLCLK = 163;
  public const int WM_NCRBUTTONDOWN = 164;
  public const int WM_NCRBUTTONUP = 165;
  public const int WM_NCRBUTTONDBLCLK = 166;
  public const int WM_NCMBUTTONDOWN = 167;
  public const int WM_NCMBUTTONUP = 168;
  public const int WM_NCMBUTTONDBLCLK = 169;
  public const int WM_KEYDOWN = 256;
  public const int WM_KEYUP = 257;
  public const int WM_CHAR = 258;
  public const int WM_DEADCHAR = 259;
  public const int WM_SYSKEYDOWN = 260;
  public const int WM_SYSKEYUP = 261;
  public const int WM_SYSCHAR = 262;
  public const int WM_SYSDEADCHAR = 263;
  public const int WM_KEYLAST = 264;
  public const int WM_IME_STARTCOMPOSITION = 269;
  public const int WM_IME_ENDCOMPOSITION = 270;
  public const int WM_IME_COMPOSITION = 271;
  public const int WM_IME_KEYLAST = 271;
  public const int WM_INITDIALOG = 272;
  public const int WM_COMMAND = 273;
  public const int WM_SYSCOMMAND = 274;
  public const int WM_TIMER = 275;
  public const int WM_HSCROLL = 276;
  public const int WM_VSCROLL = 277;
  public const int WM_INITMENU = 278;
  public const int WM_INITMENUPOPUP = 279;
  public const int WM_MENUSELECT = 287;
  public const int WM_MENUCHAR = 288;
  public const int WM_ENTERIDLE = 289;
  public const int WM_MENURBUTTONUP = 290;
  public const int WM_MENUDRAG = 291;
  public const int WM_MENUGETOBJECT = 292;
  public const int WM_UNINITMENUPOPUP = 293;
  public const int WM_MENUCOMMAND = 294;
  public const int WM_CTLCOLORMSGBOX = 306;
  public const int WM_CTLCOLOREDIT = 307;
  public const int WM_CTLCOLORLISTBOX = 308;
  public const int WM_CTLCOLORBTN = 309;
  public const int WM_CTLCOLORDLG = 310;
  public const int WM_CTLCOLORSCROLLBAR = 311;
  public const int WM_CTLCOLORSTATIC = 312;
  public const int WM_MOUSEMOVE = 512;
  public const int WM_LBUTTONDOWN = 513;
  public const int WM_LBUTTONUP = 514;
  public const int WM_LBUTTONDBLCLK = 515;
  public const int WM_RBUTTONDOWN = 516;
  public const int WM_RBUTTONUP = 517;
  public const int WM_RBUTTONDBLCLK = 518;
  public const int WM_MBUTTONDOWN = 519;
  public const int WM_MBUTTONUP = 520;
  public const int WM_MBUTTONDBLCLK = 521;
  public const int WM_MOUSEWHEEL = 522;
  public const int WM_PARENTNOTIFY = 528;
  public const int WM_ENTERMENULOOP = 529;
  public const int WM_EXITMENULOOP = 530;
  public const int WM_NEXTMENU = 531;
  public const int WM_SIZING = 532;
  public const int WM_CAPTURECHANGED = 533;
  public const int WM_MOVING = 534;
  public const int WM_DEVICECHANGE = 537;
  public const int WM_MDICREATE = 544;
  public const int WM_MDIDESTROY = 545;
  public const int WM_MDIACTIVATE = 546;
  public const int WM_MDIRESTORE = 547;
  public const int WM_MDINEXT = 548;
  public const int WM_MDIMAXIMIZE = 549;
  public const int WM_MDITILE = 550;
  public const int WM_MDICASCADE = 551;
  public const int WM_MDIICONARRANGE = 552;
  public const int WM_MDIGETACTIVE = 553;
  public const int WM_MDISETMENU = 560;
  public const int WM_ENTERSIZEMOVE = 561;
  public const int WM_EXITSIZEMOVE = 562;
  public const int WM_DROPFILES = 563;
  public const int WM_MDIREFRESHMENU = 564;
  public const int WM_IME_SETCONTEXT = 641;
  public const int WM_IME_NOTIFY = 642;
  public const int WM_IME_CONTROL = 643;
  public const int WM_IME_COMPOSITIONFULL = 644;
  public const int WM_IME_SELECT = 645;
  public const int WM_IME_CHAR = 646;
  public const int WM_IME_REQUEST = 648;
  public const int WM_IME_KEYDOWN = 656;
  public const int WM_IME_KEYUP = 657;
  public const int WM_MOUSEHOVER = 673;
  public const int WM_MOUSELEAVE = 675;
  public const int WM_CUT = 768;
  public const int WM_COPY = 769;
  public const int WM_PASTE = 770;
  public const int WM_CLEAR = 771;
  public const int WM_UNDO = 772;
  public const int WM_RENDERFORMAT = 773;
  public const int WM_RENDERALLFORMATS = 774;
  public const int WM_DESTROYCLIPBOARD = 775;
  public const int WM_DRAWCLIPBOARD = 776;
  public const int WM_PAINTCLIPBOARD = 777;
  public const int WM_VSCROLLCLIPBOARD = 778;
  public const int WM_SIZECLIPBOARD = 779;
  public const int WM_ASKCBFORMATNAME = 780;
  public const int WM_CHANGECBCHAIN = 781;
  public const int WM_HSCROLLCLIPBOARD = 782;
  public const int WM_QUERYNEWPALETTE = 783;
  public const int WM_PALETTEISCHANGING = 784;
  public const int WM_PALETTECHANGED = 785;
  public const int WM_HOTKEY = 786;
  public const int WM_PRINT = 791;
  public const int WM_PRINTCLIENT = 792;
  public const int WM_HANDHELDFIRST = 856;
  public const int WM_HANDHELDLAST = 863;
  public const int WM_AFXFIRST = 864;
  public const int WM_AFXLAST = 895;
  public const int WM_PENWINFIRST = 896;
  public const int WM_PENWINLAST = 911;
  public const int WM_APP = 32768;
  public const int WM_USER = 1024;
  public const int TTM_ACTIVATE = 1025;
  public const int TTM_SETDELAYTIME = 1027;
  public const int TTM_ADDTOOLA = 1028;
  public const int TTM_ADDTOOLW = 1074;
  public const int TTM_DELTOOLA = 1029;
  public const int TTM_DELTOOLW = 1075;
  public const int TTM_NEWTOOLRECTA = 1030;
  public const int TTM_NEWTOOLRECTW = 1076;
  public const int TTM_RELAYEVENT = 1031;
  public const int TTM_GETTOOLINFOA = 1032;
  public const int TTM_GETTOOLINFOW = 1077;
  public const int TTM_SETTOOLINFOA = 1033;
  public const int TTM_SETTOOLINFOW = 1078;
  public const int TTM_HITTESTA = 1034;
  public const int TTM_HITTESTW = 1079;
  public const int TTM_GETTEXTA = 1035;
  public const int TTM_GETTEXTW = 1080;
  public const int TTM_UPDATETIPTEXTA = 1036;
  public const int TTM_UPDATETIPTEXTW = 1081;
  public const int TTM_GETTOOLCOUNT = 1037;
  public const int TTM_ENUMTOOLSA = 1038;
  public const int TTM_ENUMTOOLSW = 1082;
  public const int TTM_GETCURRENTTOOLA = 1039;
  public const int TTM_GETCURRENTTOOLW = 1083;
  public const int TTM_WINDOWFROMPOINT = 1040;
  public const int TTM_TRACKACTIVATE = 1041;
  public const int TTM_TRACKPOSITION = 1042;
  public const int TTM_SETTIPBKCOLOR = 1043;
  public const int TTM_SETTIPTEXTCOLOR = 1044;
  public const int TTM_GETDELAYTIME = 1045;
  public const int TTM_GETTIPBKCOLOR = 1046;
  public const int TTM_GETTIPTEXTCOLOR = 1047;
  public const int TTM_SETMAXTIPWIDTH = 1048;
  public const int TTM_GETMAXTIPWIDTH = 1049;
  public const int TTM_SETMARGIN = 1050;
  public const int TTM_GETMARGIN = 1051;
  public const int TTM_POP = 1052;
  public const int TTM_GETBUBBLESIZE = 1054;
  public const int TTM_ADJUSTRECT = 1055;
  public const int TTM_SETTITLEA = 1056;
  public const int TTM_SETTITLEW = 1057;
  public const int TTM_POPUP = 1058;
  public const int TTM_GETTITLE = 1059;
  public const int EM_REPLACESEL = 194;
  public const int SIZE_RESTORED = 0;
  public const int SIZE_MINIMIZED = 1;
  public const int SIZE_MAXIMIZED = 2;
  public const int SIZE_MAXSHOW = 3;
  public const int SIZE_MAXHIDE = 4;
  public const int SC_SIZE = 61440;
  public const int SC_MOVE = 61456;
  public const int SC_MINIMIZE = 61472;
  public const int SC_MAXIMIZE = 61488;
  public const int SC_NEXTWINDOW = 61504;
  public const int SC_PREVWINDOW = 61520;
  public const int SC_CLOSE = 61536;
  public const int SC_VSCROLL = 61552;
  public const int SC_HSCROLL = 61568;
  public const int SC_MOUSEMENU = 61584;
  public const int SC_KEYMENU = 61696;
  public const int SC_ARRANGE = 61712;
  public const int SC_RESTORE = 61728;
  public const int SC_TASKLIST = 61744;
  public const int SC_SCREENSAVE = 61760;
  public const int SC_HOTKEY = 61776;
  public const int SC_DEFAULT = 61792;
  public const int SC_MONITORPOWER = 61808;
  public const int SC_CONTEXTHELP = 61824;
  public const int SC_SEPARATOR = 61455;
  public const int SW_PARENTCLOSING = 1;
  public const int SW_OTHERZOOM = 2;
  public const int SW_PARENTOPENING = 3;
  public const int SW_OTHERUNZOOM = 4;
  public const int WMSZ_LEFT = 1;
  public const int WMSZ_RIGHT = 2;
  public const int WMSZ_TOP = 3;
  public const int WMSZ_TOPLEFT = 4;
  public const int WMSZ_TOPRIGHT = 5;
  public const int WMSZ_BOTTOM = 6;
  public const int WMSZ_BOTTOMLEFT = 7;
  public const int WMSZ_BOTTOMRIGHT = 8;
  public const int LB_SETTABSTOPS = 402;
  public const int SIF_RANGE = 1;
  public const int SIF_PAGE = 2;
  public const int SIF_POS = 4;
  public const int SIF_DISABLENOSCROLL = 8;
  public const int SIF_TRACKPOS = 16;
  public const int SIF_ALL = 23;
  public const int SB_LINEUP = 0;
  public const int SB_LINELEFT = 0;
  public const int SB_LINEDOWN = 1;
  public const int SB_LINERIGHT = 1;
  public const int SB_PAGEUP = 2;
  public const int SB_PAGELEFT = 2;
  public const int SB_PAGEDOWN = 3;
  public const int SB_PAGERIGHT = 3;
  public const int SB_THUMBPOSITION = 4;
  public const int SB_THUMBTRACK = 5;
  public const int SB_TOP = 6;
  public const int SB_LEFT = 6;
  public const int SB_BOTTOM = 7;
  public const int SB_RIGHT = 7;
  public const int SB_ENDSCROLL = 8;
  public const uint ESB_ENABLE_BOTH = 0U;
  public const uint ESB_DISABLE_BOTH = 3U;
  public const uint ESB_DISABLE_LEFT = 1U;
  public const uint ESB_DISABLE_RIGHT = 2U;
  public const uint ESB_DISABLE_UP = 1U;
  public const uint ESB_DISABLE_DOWN = 2U;
  public const uint ESB_DISABLE_LTUP = 1U;
  public const uint ESB_DISABLE_RTDN = 2U;
  public const int SB_HORZ = 0;
  public const int SB_VERT = 1;
  public const int SB_CTL = 2;
  public const int SB_BOTH = 3;
  public const int SM_CXSCREEN = 0;
  public const int SM_CYSCREEN = 1;
  public const int SM_CXVSCROLL = 2;
  public const int SM_CYHSCROLL = 3;
  public const int SM_CYCAPTION = 4;
  public const int SM_CXBORDER = 5;
  public const int SM_CYBORDER = 6;
  public const int SM_CXDLGFRAME = 7;
  public const int SM_CYDLGFRAME = 8;
  public const int SM_CYVTHUMB = 9;
  public const int SM_CXHTHUMB = 10;
  public const int SM_CXICON = 11;
  public const int SM_CYICON = 12;
  public const int SM_CXCURSOR = 13;
  public const int SM_CYCURSOR = 14;
  public const int SM_CYMENU = 15;
  public const int SM_CXFULLSCREEN = 16;
  public const int SM_CYFULLSCREEN = 17;
  public const int SM_CYKANJIWINDOW = 18;
  public const int SM_MOUSEPRESENT = 19;
  public const int SM_CYVSCROLL = 20;
  public const int SM_CXHSCROLL = 21;
  public const int SM_DEBUG = 22;
  public const int SM_SWAPBUTTON = 23;
  public const int SM_RESERVED1 = 24;
  public const int SM_RESERVED2 = 25;
  public const int SM_RESERVED3 = 26;
  public const int SM_RESERVED4 = 27;
  public const int SM_CXMIN = 28;
  public const int SM_CYMIN = 29;
  public const int SM_CXSIZE = 30;
  public const int SM_CYSIZE = 31;
  public const int SM_CXFRAME = 32;
  public const int SM_CYFRAME = 33;
  public const int SM_CXMINTRACK = 34;
  public const int SM_CYMINTRACK = 35;
  public const int SM_CXDOUBLECLK = 36;
  public const int SM_CYDOUBLECLK = 37;
  public const int SM_CXICONSPACING = 38;
  public const int SM_CYICONSPACING = 39;
  public const int SM_MENUDROPALIGNMENT = 40;
  public const int SM_PENWINDOWS = 41;
  public const int SM_DBCSENABLED = 42;
  public const int SM_CMOUSEBUTTONS = 43;
  public const int SM_SECURE = 44;
  public const int SM_CXEDGE = 45;
  public const int SM_CYEDGE = 46;
  public const int SM_CXMINSPACING = 47;
  public const int SM_CYMINSPACING = 48;
  public const int SM_CXSMICON = 49;
  public const int SM_CYSMICON = 50;
  public const int SM_CYSMCAPTION = 51;
  public const int SM_CXSMSIZE = 52;
  public const int SM_CYSMSIZE = 53;
  public const int SM_CXMENUSIZE = 54;
  public const int SM_CYMENUSIZE = 55;
  public const int SM_ARRANGE = 56;
  public const int SM_CXMINIMIZED = 57;
  public const int SM_CYMINIMIZED = 58;
  public const int SM_CXMAXTRACK = 59;
  public const int SM_CYMAXTRACK = 60;
  public const int SM_CXMAXIMIZED = 61;
  public const int SM_CYMAXIMIZED = 62;
  public const int SM_NETWORK = 63;
  public const int SM_CLEANBOOT = 67;
  public const int SM_CXDRAG = 68;
  public const int SM_CYDRAG = 69;
  public const int SM_SHOWSOUNDS = 70;
  public const int SM_CXMENUCHECK = 71;
  public const int SM_CYMENUCHECK = 72;
  public const int SM_SLOWMACHINE = 73;
  public const int SM_MIDEASTENABLED = 74;
  public const int SM_MOUSEWHEELPRESENT = 75;
  public const int SM_XVIRTUALSCREEN = 76;
  public const int SM_YVIRTUALSCREEN = 77;
  public const int SM_CXVIRTUALSCREEN = 78;
  public const int SM_CYVIRTUALSCREEN = 79;
  public const int SM_CMONITORS = 80;
  public const int SM_SAMEDISPLAYFORMAT = 81;
  public const int SM_IMMENABLED = 82;
  public const int SM_CXFOCUSBORDER = 83;
  public const int SM_CYFOCUSBORDER = 84;
  public const int SM_TABLETPC = 86;
  public const int SM_MEDIACENTER = 87;
  public const int SM_STARTER = 88;
  public const int SM_SERVERR2 = 89;
  public const int SM_MOUSEHORIZONTALWHEELPRESENT = 91;
  public const int SM_CXPADDEDBORDER = 92;
  public const int SM_CMETRICS = 93;
  public const int SM_REMOTESESSION = 4096;
  public const int SM_SHUTTINGDOWN = 8192;
  public const int SM_REMOTECONTROL = 8193;
  public const int SM_CARETBLINKINGENABLED = 8194;
  public const int SW_SCROLLCHILDREN = 1;
  public const int SW_INVALIDATE = 2;
  public const int SW_ERASE = 4;
  public const int SW_SMOOTHSCROLL = 16;
  public const int SW_HIDE = 0;
  public const int SW_SHOWNORMAL = 1;
  public const int SW_NORMAL = 1;
  public const int SW_SHOWMINIMIZED = 2;
  public const int SW_SHOWMAXIMIZED = 3;
  public const int SW_MAXIMIZE = 3;
  public const int SW_SHOWNOACTIVATE = 4;
  public const int SW_SHOW = 5;
  public const int SW_MINIMIZE = 6;
  public const int SW_SHOWMINNOACTIVE = 7;
  public const int SW_SHOWNA = 8;
  public const int SW_RESTORE = 9;
  public const int SW_SHOWDEFAULT = 10;
  public const int SW_FORCEMINIMIZE = 11;
  public const int SW_MAX = 11;
  public const uint SRCCOPY = 13369376U;
  public const uint SRCPAINT = 15597702U;
  public const uint SRCAND = 8913094U;
  public const uint SRCINVERT = 6684742U;
  public const uint SRCERASE = 4457256U;
  public const uint NOTSRCCOPY = 3342344U;
  public const uint NOTSRCERASE = 1114278U;
  public const uint MERGECOPY = 12583114U;
  public const uint MERGEPAINT = 12255782U;
  public const uint PATCOPY = 15728673U;
  public const uint PATPAINT = 16452105U;
  public const uint PATINVERT = 5898313U;
  public const uint DSTINVERT = 5570569U;
  public const uint BLACKNESS = 66U;
  public const uint WHITENESS = 16711778U;
  public const int WHITE_BRUSH = 0;
  public const int LTGRAY_BRUSH = 1;
  public const int GRAY_BRUSH = 2;
  public const int DKGRAY_BRUSH = 3;
  public const int BLACK_BRUSH = 4;
  public const int NULL_BRUSH = 5;
  public const int HOLLOW_BRUSH = 5;
  public const int WHITE_PEN = 6;
  public const int BLACK_PEN = 7;
  public const int NULL_PEN = 8;
  public const int OEM_FIXED_FONT = 10;
  public const int ANSI_FIXED_FONT = 11;
  public const int ANSI_VAR_FONT = 12;
  public const int SYSTEM_FONT = 13;
  public const int DEVICE_DEFAULT_FONT = 14;
  public const int DEFAULT_PALETTE = 15;
  public const int SYSTEM_FIXED_FONT = 16;
  public const int PS_SOLID = 0;
  public const int PS_DASH = 1;
  public const int PS_DOT = 2;
  public const int PS_DASHDOT = 3;
  public const int PS_DASHDOTDOT = 4;
  public const int PS_NULL = 5;
  public const int PS_INSIDEFRAME = 6;
  public const int PS_USERSTYLE = 7;
  public const int PS_ALTERNATE = 8;
  public const int PS_STYLE_MASK = 15;
  public const int PS_ENDCAP_ROUND = 0;
  public const int PS_ENDCAP_SQUARE = 256;
  public const int PS_ENDCAP_FLAT = 512;
  public const int PS_ENDCAP_MASK = 3840;
  public const int PS_JOIN_ROUND = 0;
  public const int PS_JOIN_BEVEL = 4096;
  public const int PS_JOIN_MITER = 8192;
  public const int PS_JOIN_MASK = 61440;
  public const int PS_COSMETIC = 0;
  public const int PS_GEOMETRIC = 65536;
  public const int PS_TYPE_MASK = 983040;
  public const uint DIB_RGB_COLORS = 0U;
  public const uint DIB_PAL_COLORS = 1U;
  public const int FW_DONTCARE = 0;
  public const int FW_THIN = 100;
  public const int FW_EXTRALIGHT = 200;
  public const int FW_LIGHT = 300;
  public const int FW_NORMAL = 400;
  public const int FW_MEDIUM = 500;
  public const int FW_SEMIBOLD = 600;
  public const int FW_BOLD = 700;
  public const int FW_EXTRABOLD = 800;
  public const int FW_HEAVY = 900;
  public const int FW_ULTRALIGHT = 200;
  public const int FW_REGULAR = 400;
  public const int FW_DEMIBOLD = 600;
  public const int FW_ULTRABOLD = 800;
  public const int FW_BLACK = 900;
  public const int ANSI_CHARSET = 0;
  public const int DEFAULT_CHARSET = 1;
  public const int SYMBOL_CHARSET = 2;
  public const int SHIFTJIS_CHARSET = 128;
  public const int HANGEUL_CHARSET = 129;
  public const int HANGUL_CHARSET = 129;
  public const int GB2312_CHARSET = 134;
  public const int CHINESEBIG5_CHARSET = 136;
  public const int OEM_CHARSET = 255;
  public const int JOHAB_CHARSET = 130;
  public const int HEBREW_CHARSET = 177;
  public const int ARABIC_CHARSET = 178;
  public const int GREEK_CHARSET = 161;
  public const int TURKISH_CHARSET = 162;
  public const int VIETNAMESE_CHARSET = 163;
  public const int THAI_CHARSET = 222;
  public const int EASTEUROPE_CHARSET = 238;
  public const int RUSSIAN_CHARSET = 204;
  public const int MAC_CHARSET = 77;
  public const int BALTIC_CHARSET = 186;
  public const int OUT_DEFAULT_PRECIS = 0;
  public const int OUT_STRING_PRECIS = 1;
  public const int OUT_CHARACTER_PRECIS = 2;
  public const int OUT_STROKE_PRECIS = 3;
  public const int OUT_TT_PRECIS = 4;
  public const int OUT_DEVICE_PRECIS = 5;
  public const int OUT_RASTER_PRECIS = 6;
  public const int OUT_TT_ONLY_PRECIS = 7;
  public const int OUT_OUTLINE_PRECIS = 8;
  public const int OUT_SCREEN_OUTLINE_PRECIS = 9;
  public const int OUT_PS_ONLY_PRECIS = 10;
  public const int CLIP_DEFAULT_PRECIS = 0;
  public const int CLIP_CHARACTER_PRECIS = 1;
  public const int CLIP_STROKE_PRECIS = 2;
  public const int CLIP_MASK = 15;
  public const int CLIP_LH_ANGLES = 16;
  public const int CLIP_TT_ALWAYS = 32;
  public const int CLIP_DFA_DISABLE = 64;
  public const int CLIP_EMBEDDED = 128;
  public const int DEFAULT_QUALITY = 0;
  public const int DRAFT_QUALITY = 1;
  public const int PROOF_QUALITY = 2;
  public const int NONANTIALIASED_QUALITY = 3;
  public const int ANTIALIASED_QUALITY = 4;
  public const int CLEARTYPE_QUALITY = 5;
  public const int CLEARTYPE_NATURAL_QUALITY = 6;
  public const int DEFAULT_PITCH = 0;
  public const int FIXED_PITCH = 1;
  public const int VARIABLE_PITCH = 2;
  public const int FF_DONTCARE = 0;
  public const int FF_ROMAN = 16;
  public const int FF_SWISS = 32;
  public const int FF_MODERN = 48;
  public const int FF_SCRIPT = 64;
  public const int FF_DECORATIVE = 80;
  public const int TRANSPARENT = 1;
  public const int OPAQUE = 2;
  public const int BKMODE_LAST = 2;

  [DllImport("user32.dll")]
  public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

  [DllImport("user32.dll")]
  public static extern IntPtr SendMessageW(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

  [DllImport("user32.dll")]
  public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

  [DllImport("user32.dll")]
  public static extern bool ValidateRect(IntPtr hWnd, ref Win32.RECT lpRect);

  [DllImport("user32.dll")]
  public static extern bool ValidateRect(IntPtr hWnd, IntPtr lpRect);

  [DllImport("user32.dll")]
  public static extern bool UpdateWindow(IntPtr hWnd);

  [DllImport("user32.dll")]
  public static extern bool EnableScrollBar(IntPtr hWnd, uint wSBflags, uint wArrows);

  [DllImport("user32.dll")]
  public static extern int GetScrollInfo(IntPtr hWnd, int fnBar, ref Win32.SCROLLINFO info);

  [DllImport("user32.dll")]
  public static extern int GetSystemMetrics(int nIndex);

  [DllImport("user32.dll")]
  public static extern int ScrollWindowEx(IntPtr hWnd, int dx, int dy, ref Win32.RECT prcScroll, ref Win32.RECT prcClip, IntPtr hrgnUpdate, ref Win32.RECT prcUpdate, uint flags);

  [DllImport("user32.dll")]
  public static extern int ScrollWindowEx(IntPtr hWnd, int dx, int dy, IntPtr prcScroll, IntPtr prcClip, IntPtr hrgnUpdate, IntPtr prcUpdate, uint flags);

  [DllImport("user32.dll")]
  public static extern int SetScrollInfo(IntPtr hwnd, int bar, ref Win32.SCROLLINFO si, bool fRedraw);

  [DllImport("user32.dll")]
  public static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);

  [DllImport("user32.dll")]
  public static extern IntPtr GetFocus();

  [DllImport("user32.dll")]
  public static extern IntPtr SetFocus(IntPtr hWnd);

  [DllImport("user32.dll")]
  public static extern bool SetWindowText(IntPtr hWnd, string lpString);

  [DllImport("user32.dll")]
  public static extern bool GetWindowRect(IntPtr hWnd, ref Win32.RECT lpRect);

  [DllImport("user32.dll")]
  public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

  [DllImport("user32.dll")]
  public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

  [DllImport("user32.dll")]
  public static extern IntPtr BeginPaint(IntPtr hwnd, ref Win32.PAINTSTRUCT lpPaint);

  [DllImport("user32.dll")]
  public static extern bool EndPaint(IntPtr hwnd, ref Win32.PAINTSTRUCT lpPaint);

  [DllImport("gdi32.dll")]
  public static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);

  [DllImport("user32.dll")]
  public static extern IntPtr GetDC(IntPtr hWnd);

  [DllImport("user32.dll")]
  public static extern bool ReleaseDC(IntPtr hWnd, IntPtr hdc);

  [DllImport("gdi32.dll")]
  public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

  [DllImport("user32.dll")]
  public static extern bool ScrollDC(IntPtr hdc, int dx, int dy, IntPtr lprcScroll, IntPtr lprcClip, IntPtr hrgnUpdate, IntPtr lprcUpdate);

  [DllImport("gdi32.dll")]
  public static extern bool DeleteDC(IntPtr hdc);

  [DllImport("gdi32.dll")]
  public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

  [DllImport("gdi32.dll")]
  public static extern bool DeleteObject(IntPtr hObject);

  [DllImport("gdi32.dll")]
  public static extern IntPtr GetStockObject(int fnObject);

  [DllImport("gdi32.dll")]
  public static extern IntPtr CreatePen(int fnPenStyle, int nWidth, uint crColor);

  [DllImport("gdi32.dll")]
  public unsafe static extern IntPtr CreateDIBSection(IntPtr hdc, ref Win32.BITMAPINFO pbmi, uint iUsage, ref void* ppvBits, IntPtr hSection, uint dwOffset);

  [DllImport("gdi32.dll")]
  public static extern IntPtr SelectPalette(IntPtr hdc, IntPtr hpal, int bForceBackground);

  [DllImport("gdi32.dll")]
  public static extern bool RealizePalette(IntPtr hdc);

  [DllImport("gdi32.dll")]
  public static extern IntPtr CreateFont(int nHeight, int nWidth, int nEscapement, int nOrientation, int fnWeight, uint fdwItalic, uint fdwUnderline, uint fdwStrikeOut, uint fdwCharSet, uint fdwOutputPrecision, uint fdwClipPrecision, uint fdwQuality, uint fdwPitchAndFamily, string lpszFace);

  [DllImport("gdi32.dll")]
  public static extern uint SetTextColor(IntPtr hdc, uint crColor);

  [DllImport("gdi32.dll")]
  public static extern uint SetBkColor(IntPtr hdc, uint crColor);

  [DllImport("gdi32.dll")]
  public static extern uint SetBkMode(IntPtr hdc, int iBkMode);

  [DllImport("gdi32.dll")]
  public static extern bool TextOut(IntPtr hdc, int nXStart, int nYStart, string lpString, int cbString);

  [DllImport("gdi32.dll")]
  public static extern bool Rectangle(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

  public struct RECT
  {
    public int left;
    public int top;
    public int right;
    public int bottom;

    public int Width
    {
      get
      {
        return this.right - this.left;
      }
    }

    public int Height
    {
      get
      {
        return this.bottom - this.top;
      }
    }

    public RECT(int left, int top, int right, int bottom)
    {
      this.left = left;
      this.top = top;
      this.right = right;
      this.bottom = bottom;
    }
  }

  public struct SCROLLINFO
  {
    public uint cbSize;
    public uint fMask;
    public int nMin;
    public int nMax;
    public uint nPage;
    public int nPos;
    public int nTrackPos;

    public SCROLLINFO(uint Mask, int Max)
    {
        unsafe
        {
            this.cbSize = (uint)sizeof(Win32.SCROLLINFO);
        }
      this.fMask = Mask;
      this.nMin = 0;
      this.nMax = Max;
      this.nPage = 0U;
      this.nPos = 0;
      this.nTrackPos = 0;
    }

    public int Scroll(IntPtr WParam)
    {
      int num = this.nPos;
      switch ((ushort) (int) WParam)
      {
        case (ushort) 0:
          --this.nPos;
          break;
        case (ushort) 1:
          ++this.nPos;
          break;
        case (ushort) 2:
          this.nPos -= (int) this.nPage;
          break;
        case (ushort) 3:
          this.nPos += (int) this.nPage;
          break;
        case (ushort) 4:
        case (ushort) 5:
          this.nPos = (int) WParam >> 16;
          break;
        case (ushort) 6:
          this.nPos = this.nMin;
          break;
        case (ushort) 7:
          this.nPos = this.nMax;
          break;
      }
      if (this.nPos < this.nMin)
        this.nPos = this.nMin;
      if ((long) this.nPos > (long) (this.nMax + 1) - (long) this.nPage)
        this.nPos = (int) ((long) (this.nMax + 1) - (long) this.nPage);
      return this.nPos - num;
    }
  }

  public struct BITMAPINFO
  {
    public Win32.BITMAPINFOHEADER bmiHeader;
    public unsafe fixed uint bmiColors[1];
  }

  public struct BITMAPINFOHEADER
  {
    public const uint BI_RGB = 0U;
    public const uint BI_RLE8 = 1U;
    public const uint BI_RLE4 = 2U;
    public const uint BI_BITFIELDS = 3U;
    public const uint BI_JPEG = 4U;
    public const uint BI_PNG = 5U;
    public uint biSize;
    public int biWidth;
    public int biHeight;
    public ushort biPlanes;
    public ushort biBitCount;
    public uint biCompression;
    public uint biSizeImage;
    public int biXPelsPerMeter;
    public int biYPelsPerMeter;
    public uint biClrUsed;
    public uint biClrImportant;
  }

  public struct PAINTSTRUCT
  {
    public IntPtr hdc;
    public int fErase;
    public Win32.RECT rcPaint;
    public int fRestore;
    public int fIncUpdate;
    public unsafe fixed byte rgbReserved[32];
  }
}
