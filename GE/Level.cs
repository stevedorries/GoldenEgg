
// Type: GE.Level

// MVID: 7AA6A484-F524-42F2-9571-0947D386B578
// Assembly location: C:\Documents and Settings\THE RAIN\Desktop\ge.exe

using Library;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GE
{
  public class Level
  {
    private byte[] _vram = new byte[65536];
    private ushort[] _cgram = new ushort[256];
    private uint[] _gradient = new uint[512];
    private VariableByte[] _ram = new VariableByte[8192];
    private uint random_seed = (uint) Environment.TickCount;
    private byte[] _header = new byte[15];
    private ushort[] _spriteTileRow = new ushort[442];
    private List<Level.Object> _objects = new List<Level.Object>();
    private List<Level.Sprite> _sprites = new List<Level.Sprite>();
    private Level.ScreenExit[] _exits = new Level.ScreenExit[128];
    private Level.LevelTiles _levelTiles = new Level.LevelTiles();
    public bool removeOldObject = true;
    public bool removeOldSprite = true;
    private Level.CustomGradient _customGradient = new Level.CustomGradient();
    private static Level.LoadTiles[] DecompressExObjectInit = new Level.LoadTiles[256];
    private static Level.LoadTiles[] DecompressExObjectMain = new Level.LoadTiles[256];
    private static Level.LoadTiles[] DecompressObjectInit = new Level.LoadTiles[256];
    private static Level.LoadTiles[] DecompressObjectMain = new Level.LoadTiles[256];
    public const int NullID = -1;
    public const int MinLevelNumber = 0;
    public const int MaxLevelNumber = 221;
    public const int ScreenWidth = 256;
    public const int ScreenHeight = 256;
    public const int MaxXScreen = 16;
    public const int MaxYScreen = 8;
    public const int MaxXTile = 256;
    public const int MaxYTile = 128;
    public const int LevelWidth = 4096;
    public const int LevelHeight = 2048;
    public const int LevelPtrStart = 784323;
    public const int HeaderBitLengthTable = 527109;
    public const int TilesetSpecificTileTable = 841242;
    public const int StandardObjectInfo = 591084;
    public const int LoadPaletteTable = 14218;
    public const int BG1PaletteTable1 = 14452;
    public const int BG1PaletteTable2 = 14516;
    public const int BG2PaletteTable = 14580;
    public const int BG3PaletteTable = 14708;
    public const int SprPaletteTable = 14836;
    public const int YoshiPaletteTable = 14868;
    public const int PaletteDataStart = 2072576;
    public const int PaletteAnimation01 = 50303;
    public const int PaletteAnimation02 = 2072976;
    public const int PaletteAnimation03 = 2084074;
    public const int PaletteAnimation04 = 50548;
    public const int PaletteAnimationBG1_3_CAVE = 50740;
    public const int PaletteAnimation05 = 2087424;
    public const int PaletteAnimation06 = 50666;
    public const int PaletteAnimation08 = 50810;
    public const int PaletteAnimation09 = 50859;
    public const int PaletteAnimation0A = 50938;
    public const int PaletteAnimation0B = 50968;
    public const int PaletteAnimation0C = 51059;
    public const int PaletteAnimation0D1 = 51154;
    public const int PaletteAnimation0D2 = 51170;
    public const int PaletteAnimation0E = 51254;
    public const int PaletteAnimation0EPaletteIndex = 51270;
    public const int PaletteAnimation0F = 51343;
    public const int PaletteAnimation10 = 51379;
    public const int PaletteAnimation11 = 2095454;
    public const int PaletteAnimation12 = 2095582;
    public const int GradientColorPtr = 54579;
    public const uint LoadGraphicsTable = 11629U;
    public const uint BG1GraphicTable1 = 12089U;
    public const uint BG1GraphicTable2 = 12137U;
    public const uint BG2GraphicTable = 12185U;
    public const uint BG3GraphicTable = 12249U;
    public const uint SprGraphicTable = 12345U;
    public const uint CompressedGraphicsTable1 = 228473U;
    public const uint CompressedGraphicsTable2 = 227678U;
    public const uint BG2TilemapTable = 59153U;
    public const uint BG2TilemapNumber = 59217U;
    public const uint BG3TilemapTable = 59655U;
    public const uint GameParameterTable = 15338U;
    public const uint GameParameterIndexTable = 15279U;
    public const uint LevelModeIndexTable = 44928U;
    public const int RegularAnimationDest = 21917;
    public const int RegularAnimationSrc = 21981;
    public const int Animation01Src = 22283;
    public const int Animation02Dest = 22325;
    public const int Animation02Src = 22341;
    public const int Animation03Dest = 12032;
    public const int Animation03Src = 22420;
    public const int Animation05Dest = 12032;
    public const int Animation05Src = 22485;
    public const int Animation06Dest1 = 12032;
    public const int Animation06Dest2 = 32512;
    public const int Animation06Src = 22485;
    public const int Animation07Dest1 = 4096;
    public const int Animation07Dest2 = 4352;
    public const int Animation07Dest3 = 4224;
    public const int Animation07Dest4 = 4480;
    public const int Animation07Src1 = 22616;
    public const int Animation07Src2 = 22632;
    public const int Animation07Src3 = 22648;
    public const int Animation07Src4 = 22664;
    public const int Animation08Dest1 = 4096;
    public const int Animation08Dest2 = 4352;
    public const int Animation08Src1 = 22813;
    public const int Animation08Src2 = 22821;
    public const int Animation09Dest = 12032;
    public const int Animation09Src = 32768;
    public const int Animation0ADest = 12032;
    public const int Animation0ASrc = 45056;
    public const int Animation0BDest = 12032;
    public const int Animation0BSrc = 22974;
    public const int Animation0CSrc1 = 23081;
    public const int Animation0CSrc2 = 23105;
    public const int Animation0FDest = 12032;
    public const int Animation0FSrc = 23316;
    public const int Animation10Dest1 = 12032;
    public const int Animation10Dest2 = 12160;
    public const int Animation10Src1 = 22852;
    public const int Animation10Src2 = 22860;
    public const int BG2HorizontalScrollRate = 162670;
    public const int BG2VerticalScrollRate = 162734;
    public const int BG3HorizontalScrollRate = 162798;
    public const int BG3VerticalScrollRate = 162862;
    public const int BG4HorizontalScrollRate = 162926;
    public const int BG4VerticalScrollRate = 162990;
    public const int SpriteGraphicsFileTable = 12345;
    public const int NumberOfStandardSprite = 442;
    public const int SpriteGraphicsFileInfoTable = 337686;
    public const int MiniBattleLevel = 222;
    public const int ExObj00_09Width = 592007;
    public const int ExObj00_09TilePtr = 599132;
    public const int ExObj0A_0BTilePtr = 599237;
    public const int ExObj0CTile = 599268;
    public const int ExObj0D_0ETilePtr = 599563;
    public const int ExObj10Tile = 599637;
    public const int ExObj12Tile = 599708;
    public const int ExObj13Tile = 599736;
    public const int ExObj14_15VerAdj = 592195;
    public const int ExObj14Tile = 599764;
    public const int ExObj15Tile = 599812;
    public const int ExObj18Tile = 599897;
    public const int ExObj19Tile = 600215;
    public const int ExObj1ATile = 600311;
    public const int ExObj19_1ASpecific = 600193;
    public const int ExObj1B_1DTilePtr = 600799;
    public const int ExObj1FTile = 600873;
    public const int ExObj30Tile = 600918;
    public const int ExObj30TileCmp = 600928;
    public const int ExObj31Tile = 600985;
    public const int ExObj32_45Specific = 601017;
    public const int ExObj46Tile = 601079;
    public const int ExObj47Tile = 601145;
    public const int ExObj48Tile = 601269;
    public const int ExObj49Tile = 601293;
    public const int ExObj4DTile = 601399;
    public const int ExObj4ETile = 601433;
    public const int ExObj50_A8Tile = 601465;
    public const int ExObj50_A8Specific = 601469;
    public const int ExObj50_A8BG1Header4Tile = 601493;
    public const int ExObj50_A8BG1HeaderCTile = 601501;
    public const int ExObj52TileCmp = 600928;
    public const int ExObj52Tile = 601644;
    public const int ExObj53Tile = 601714;
    public const int ExObj54_55TilePtr = 601842;
    public const int ExObj56_57TilePtr = 601924;
    public const int ExObj58_5ATilePtr = 601982;
    public const int ExObj5B_5DTilePtr = 602041;
    public const int ExObj5F_66TilePtr = 602337;
    public const int ExObj67TileCmp = 602414;
    public const int ExObj67TilePtr = 602430;
    public const int ExObj68_69Tile = 602485;
    public const int ExObj6ATile = 602545;
    public const int ExObj6BTile = 602563;
    public const int ExObj6CTile = 602591;
    public const int ExObj6D_70Tile = 602642;
    public const int ExObj71_7DWidth = 593141;
    public const int ExObj71_7DHeight = 593154;
    public const int ExObj71Tile = 602672;
    public const int ExObj72Tile = 602702;
    public const int ExObj73Tile = 602725;
    public const int ExObj74Tile = 602748;
    public const int ExObj75Tile = 602771;
    public const int ExObj76Tile = 602811;
    public const int ExObj77Tile = 602844;
    public const int ExObj78Tile = 602890;
    public const int ExObj79Tile = 602937;
    public const int ExObj7ATile = 602970;
    public const int ExObj7BTile = 603003;
    public const int ExObj7CTile = 603044;
    public const int ExObj7DTile = 603085;
    public const int ExObj7E_7FTile = 603101;
    public const int ExObj82Tile = 603148;
    public const int ExObj83_87VerAdj = 593316;
    public const int ExObj83_87Width = 593326;
    public const int ExObj83_87Height = 593336;
    public const int ExObj83_87TilePtr = 604399;
    public const int ExObj83_87IndexAdj = 604409;
    public const int ExObj83_87Specific = 604419;
    public const int ExObj88Ver0Tile1 = 604600;
    public const int ExObj88Ver0Tile2 = 604608;
    public const int ExObj88Ver0TileAdj = 604616;
    public const int ExObj88Ver1Tile1 = 604686;
    public const int ExObj88Ver1Tile2 = 604694;
    public const int ExObj88Ver1TileAdj = 604702;
    public const int ExObj88Ver2Tile1 = 604772;
    public const int ExObj88Ver2Tile2 = 604780;
    public const int ExObj88Ver3Tile1 = 604834;
    public const int ExObj88Ver3Tile2 = 604842;
    public const int ExObj89_8CWidth = 593417;
    public const int ExObj89_8CHeight = 593425;
    public const int ExObj89_8ATile = 604901;
    public const int ExObj89_8ATile2 = 604905;
    public const int ExObj8B_8CTile = 604962;
    public const int ExObj8B_8CTile2 = 604966;
    public const int ExObj92_95TilePtr = 605218;
    public const int ExObj96_99TilePtr = 605517;
    public const int ExObj9A_9DTile1 = 605562;
    public const int ExObj9A_9DTile2 = 605570;
    public const int ExObj9E_9FTile = 605628;
    public const int ExObjA0_A3HorzAdj = 593611;
    public const int ExObjA0_A3VerAdj = 593619;
    public const int ExObjA4Tile = 606023;
    public const int ExObjA5_A6HorzAdj = 593706;
    public const int ExObjA5_A6VerAdj = 593710;
    public const int ExObjA5_A6Width = 593714;
    public const int ExObjA5_A6Height = 593718;
    public const int ExObjA6Tile = 606048;
    public const int ExObjA5Tile = 606078;
    public const int ExObjA6IndexAdj = 606168;
    public const int ExObjA5IndexAdj = 606178;
    public const int ExObjA9_ACHeight = 593796;
    public const int ExObjA9_ACTilePtr = 606268;
    public const int ExObjAD_B2TileAdj = 593829;
    public const int ExObjAD_B2Height = 593837;
    public const int ExObjAD_B2TilePtr = 606373;
    public const int ExObjB4Tile = 606440;
    public const int ExObjB5Tile = 606456;
    public const int ExObjB6_B7TilePtr = 606601;
    public const int ExObjB8_B9Width = 593974;
    public const int ExObjB8_B9Height = 593978;
    public const int ExObjB8_B9TilePtr = 606780;
    public const int ExObjB8_B9AdjPtr = 606784;
    public const int ExObjBA_BFHeight = 594011;
    public const int ExObjBA_BFTilePtr = 606864;
    public const int ExObjC2_C3Tile = 607029;
    public const int ExObjC5_C9Width = 594137;
    public const int ExObjC5_C9Height = 594147;
    public const int ExObjC5_C9TilePtr = 607167;
    public const int ExObjC5_C9IndexAdjPtr = 607177;
    public const int ExObjD4_DFWidth = 594207;
    public const int ExObjD4_DFHeight = 594219;
    public const int ExObjD4_DFTilePtr = 607832;
    public const int ExObjD4_DFVerIndexPtr = 607856;
    public const int ExObjD4_DFCmp = 607880;
    public const int ExObjD4_DFReplace = 607884;
    public const int ExObjE0Tile = 607970;
    public const int Obj01Specific1 = 622661;
    public const int Obj01Specific2 = 622669;
    public const int Obj01Specific3 = 622756;
    public const int Obj01Specific4 = 622764;
    public const int Obj01Specific5 = 622881;
    public const int Obj02_03_0A_0BVerCount = 594592;
    public const int Obj02_03Specific = 623127;
    public const int Obj02_03_0A_0BSpecific = 623272;
    public const int Obj04_05VerAdj = 594616;
    public const int Obj04_05Specific1 = 623416;
    public const int Obj04_05Specific2 = 623424;
    public const int Obj04_05Specific3 = 623445;
    public const int Obj04_05Specific4 = 623453;
    public const int Obj06_09VerCount = 594722;
    public const int Obj06_09VerAdj = 594734;
    public const int Obj06_09SpecificPtr = 623575;
    public const int Obj0A_0BSpecific = 623660;
    public const int Obj0C_0E_0FIndex1 = 623704;
    public const int Obj0C_0E_0FIndex2 = 623712;
    public const int Obj0C_0E_0FIndex3 = 623720;
    public const int Obj10Tile1 = 623809;
    public const int Obj10Tile2 = 623821;
    public const int Obj10VerFlag = 623837;
    public const int Obj11_12Height = 594838;
    public const int Obj11_12VerAdj = 594842;
    public const int Obj11_12Tile1 = 624063;
    public const int Obj11_12Tile2 = 623817;
    public const int Obj11_12Tile3 = 623829;
    public const int Obj14Cmp = 624480;
    public const int Obj14Specific1 = 624516;
    public const int Obj14Specific2 = 624610;
    public const int Obj14Specific3 = 624704;
    public const int Obj14Specific4 = 624798;
    public const int Obj14Specific5 = 624892;
    public const int Obj14Specific6 = 624986;
    public const int Obj14Specific7 = 625080;
    public const int Obj14Specific8 = 625174;
    public const int Obj14Specific9 = 625268;
    public const int Obj14Specific10 = 625362;
    public const int Obj14Specific11 = 625456;
    public const int Obj14Specific12 = 625550;
    public const int Obj14Specific13 = 625644;
    public const int Obj14Specific14 = 625738;
    public const int Obj14Replace = 624472;
    public const int Obj15Tile = 625832;
    public const int Obj17Tile1 = 626009;
    public const int Obj17Tile2 = 626015;
    public const int Obj17Tile3 = 626029;
    public const int Obj17Tile4 = 626143;
    public const int Obj17Replace1 = 626147;
    public const int Obj17Replace2 = 626151;
    public const int Obj18Tile = 626222;
    public const int Obj19Tile1 = 626320;
    public const int Obj19Tile2 = 626344;
    public const int Obj1BTile = 626484;
    public const int Obj1CTile = 626539;
    public const int Obj1D_1ETile = 626571;
    public const int Obj1FTile1 = 626605;
    public const int Obj1FTile2 = 626615;
    public const int Obj20Tile1 = 654327;
    public const int Obj20Tile2 = 654333;
    public const int Obj20Tile3 = 654339;
    public const int Obj20Tile4 = 654345;
    public const int Obj20Tile5 = 654478;
    public const int Obj20Tile6 = 654500;
    public const int Obj20Tile7 = 654610;
    public const int Obj21Cmp = 626639;
    public const int Obj21Tile1 = 626651;
    public const int Obj21Tile2 = 626657;
    public const int Obj21Tile3 = 626915;
    public const int Obj21Replace1 = 626919;
    public const int Obj21Replace2 = 626923;
    public const int Obj21Tile4 = 626783;
    public const int Obj21Replace3 = 626787;
    public const int Obj21Replace4 = 626791;
    public const int Obj21Replace5 = 626795;
    public const int Obj22Tile1 = 627033;
    public const int Obj22Tile2 = 627039;
    public const int Obj23Tile1 = 627112;
    public const int Obj23Tile2 = 627118;
    public const int Obj24Tile = 627236;
    public const int Obj25_26Tile = 627280;
    public const int Obj27Tile1 = 627528;
    public const int Obj27Tile2 = 627532;
    public const int Obj28Tile1 = 627680;
    public const int Obj28Tile2 = 627684;
    public const int Obj29_2ATilePtr = 627912;
    public const int Obj2CTile = 628037;
    public const int Obj2D_2ETile1 = 628102;
    public const int Obj2D_2ETile2 = 628166;
    public const int Obj2D_2ETile3 = 628194;
    public const int Obj2D_2ETilePtr = 628098;
    public const int Obj2FTile1 = 628306;
    public const int Obj2FTile2 = 628310;
    public const int Obj2FTile3 = 628314;
    public const int Obj30Tile = 628394;
    public const int Obj31Replace1 = 628649;
    public const int Obj31Replace2 = 628679;
    public const int Obj34TilePtr = 629098;
    public const int Obj35TilePtr = 629225;
    public const int Obj35Tile = 629233;
    public const int Obj38Tile1 = 629403;
    public const int Obj38Tile2 = 629427;
    public const int Obj38Replace = 629451;
    public const int Obj39Tile = 630643;
    public const int Obj3ASpecific1 = 630694;
    public const int Obj3ASpecific2 = 622881;
    public const int Obj3BSpecific = 630755;
    public const int Obj3CTile1 = 630807;
    public const int ObjF4Tile1 = 630813;
    public const int Obj3CTile2 = 630819;
    public const int ObjF4Tile2 = 630825;
    public const int Obj3DTile1 = 630988;
    public const int Obj3DTile2 = 631000;
    public const int Obj3DTile3 = 631006;
    public const int Obj3ETile = 631068;
    public const int Obj3F_40Tile = 631110;
    public const int Obj41Tile = 631209;
    public const int Obj41Cmp1 = 631215;
    public const int Obj41Replace1 = 631233;
    public const int Obj41Replace2 = 631288;
    public const int Obj41Cmp2 = 631334;
    public const int Obj41Replace3 = 631372;
    public const int Obj41Replace4 = 631585;
    public const int Obj42Tile1 = 631656;
    public const int Obj42Tile2 = 631658;
    public const int Obj43Tile = 631711;
    public const int Obj42_43Tile = 631717;
    public const int Obj42_43Cmp = 631409;
    public const int Obj42_43Replace1 = 631447;
    public const int Obj42_43Replace2 = 631467;
    public const int Obj44Tile1 = 631928;
    public const int Obj44Tile2 = 632048;
    public const int Obj45_46VerAdj = 595730;
    public const int Obj45_46Tile1 = 632238;
    public const int Obj45_46Tile2 = 632246;
    public const int Obj45_46Tile3 = 632334;
    public const int Obj47Tile = 632376;
    public const int Obj47Cmp = 632534;
    public const int Obj47Replace1 = 632526;
    public const int Obj47Replace2 = 632569;
    public const int Obj47Replace3 = 632604;
    public const int Obj48Tile1 = 632649;
    public const int Obj48Tile2 = 632794;
    public const int Obj48Tile3 = 632843;
    public const int Obj48Tile4 = 632997;
    public const int Obj49_4ATile = 633147;
    public const int Obj4B_4DWidth = 595863;
    public const int Obj4B_4DIndex = 633220;
    public const int Obj4B_4DTile1 = 633226;
    public const int Obj4B_4DTile2 = 633262;
    public const int Obj4B_4DTile3 = 633298;
    public const int Obj4ECmp = 633917;
    public const int Obj4ESpecific1 = 633979;
    public const int Obj4ESpecific2 = 634041;
    public const int Obj4ESpecific3 = 634103;
    public const int Obj4ESpecific4 = 634165;
    public const int Obj4ESpecific5 = 634227;
    public const int Obj4ESpecific6 = 634289;
    public const int Obj4ESpecific7 = 634351;
    public const int Obj4ESpecific8 = 634413;
    public const int Obj4ESpecific9 = 634475;
    public const int Obj4ESpecific10 = 634537;
    public const int Obj4ESpecific11 = 634599;
    public const int Obj4ESpecific12 = 634661;
    public const int Obj4ESpecific13 = 634723;
    public const int Obj4ESpecific14 = 634785;
    public const int Obj4ESpecific15 = 634847;
    public const int Obj4ESpecific16 = 634909;
    public const int Obj4FReplace1 = 635312;
    public const int Obj4FReplace2 = 635694;
    public const int Obj4FReplace3 = 636076;
    public const int Obj4FReplace4 = 636458;
    public const int Obj4FSpecific = 636840;
    public const int Obj50_51Specific = 637272;
    public const int Obj52Specific = 637317;
    public const int Obj53Tile1 = 637456;
    public const int Obj53Tile2 = 637464;
    public const int Obj54_56VerAdj = 596052;
    public const int Obj54_56Tile1 = 637586;
    public const int Obj54_56Tile2 = 637592;
    public const int Obj54Tile = 637654;
    public const int Obj55Tile = 637707;
    public const int Obj56Tile = 637753;
    public const int Obj57Specific = 637834;
    public const int Obj58Cmp = 638116;
    public const int Obj58Tile = 638140;
    public const int Obj59_5BVerAdj = 596207;
    public const int Obj59_5CSpecific = 638455;
    public const int Obj5A_5DSpecific = 638576;
    public const int Obj5B_5ESpecific = 638695;
    public const int Obj59_62Specific1 = 639380;
    public const int Obj59_62Specific2 = 639503;
    public const int Obj5C_5EVerAdj = 596280;
    public const int Obj5F_60Specific1 = 638965;
    public const int Obj5F_60Specific2 = 638997;
    public const int Obj61_62Specific1 = 639257;
    public const int Obj61_62Specific2 = 639289;
    public const int Obj7ESpecific = 637848;
    public const int Obj63_65Tile = 639595;
    public const int Obj67Replace1 = 639761;
    public const int Obj67Replace2 = 639380;
    public const int Obj67Replace3 = 639853;
    public const int Obj67Replace4 = 639945;
    public const int Obj67Replace5 = 640037;
    public const int Obj67Replace6 = 640129;
    public const int Obj67Replace7 = 639503;
    public const int Obj67Replace8 = 640221;
    public const int Obj68_8ATile = 640709;
    public const int Obj69Tile1 = 640790;
    public const int Obj69Tile2 = 640796;
    public const int Obj69Tile3 = 640802;
    public const int Obj6BTile1 = 640934;
    public const int Obj6BTile2 = 640940;
    public const int Obj6DSpecific = 640994;
    public const int Obj6E_8BTile = 641036;
    public const int Obj6FTile = 641096;
    public const int Obj70Tile = 641143;
    public const int Obj71Tile = 641164;
    public const int Obj72Tile = 641185;
    public const int Obj73Tile = 641251;
    public const int Obj74Tile = 641281;
    public const int Obj75Tile = 641305;
    public const int Obj76Tile = 641327;
    public const int Obj78Tile = 641357;
    public const int Obj79Tile = 641377;
    public const int Obj7ASpecific1 = 641684;
    public const int Obj7ASpecific2 = 641692;
    public const int Obj7ASpecific3 = 641755;
    public const int Obj7ASpecific4 = 641817;
    public const int Obj7BSpecific1 = 641944;
    public const int Obj7BSpecific2 = 641962;
    public const int Obj7CSpecific1 = 642338;
    public const int Obj7CSpecific2 = 642346;
    public const int Obj7DSpecific1 = 642455;
    public const int Obj7DSpecific2 = 642487;
    public const int Obj7FIndex = 642612;
    public const int Obj7FSpecific1 = 642994;
    public const int Obj7FSpecific2 = 643012;
    public const int Obj80Specific = 643220;
    public const int Obj85Specific = 643372;
    public const int Obj86Specific = 643500;
    public const int Obj87_88Tile = 643654;
    public const int Obj87_88Specific = 643670;
    public const int Obj89Tile1 = 643845;
    public const int Obj89Tile2 = 643868;
    public const int Obj89Tile3 = 643900;
    public const int Obj8CTile = 643964;
    public const int Obj8DTile = 644071;
    public const int Obj8ETile = 644116;
    public const int Obj8FTile1 = 644153;
    public const int Obj8FTile2 = 644165;
    public const int Obj8FTile3 = 644181;
    public const int Obj8FTile4 = 644193;
    public const int Obj90Tile1 = 644444;
    public const int Obj90Tile2 = 644456;
    public const int Obj90Tile3 = 644571;
    public const int Obj91Tile = 644620;
    public const int Obj92Tile = 644711;
    public const int Obj93Tile = 644802;
    public const int Obj94_97Tile = 644889;
    public const int Obj98Tile1 = 645008;
    public const int Obj98Tile2 = 645016;
    public const int Obj98Tile3 = 645054;
    public const int Obj99Tile = 645072;
    public const int Obj9ATile1 = 645133;
    public const int Obj9ATile2 = 645149;
    public const int Obj9ATile3 = 645165;
    public const int Obj9ATile4 = 645173;
    public const int Obj9ATile5 = 645181;
    public const int Obj9BTile1 = 645429;
    public const int Obj9BTile2 = 645437;
    public const int Obj9CTile1 = 645544;
    public const int Obj9CTile2 = 645552;
    public const int Obj9CTile3 = 645560;
    public const int Obj9CTile4 = 645568;
    public const int Obj9DTile1 = 645649;
    public const int Obj9DTile2 = 645655;
    public const int Obj9DTile3 = 645661;
    public const int Obj9DTile4 = 645667;
    public const int Obj9FTile = 645788;
    public const int ObjA0_A2Tile = 645832;
    public const int ObjA3_A4Tile = 645860;
    public const int ObjA5_A6WidthHeight = 597676;
    public const int ObjA5Tile1 = 645966;
    public const int ObjA5Tile2 = 645990;
    public const int ObjA5Tile3 = 646012;
    public const int ObjA6Tile1 = 646072;
    public const int ObjA6Tile2 = 646096;
    public const int ObjA6Tile3 = 646119;
    public const int ObjA6Tile4 = 646174;
    public const int ObjA6Tile5 = 646186;
    public const int ObjA6Tile6 = 646220;
    public const int ObjA5Tile4 = 646232;
    public const int ObjA7Tile = 646271;
    public const int ObjA9Tile1 = 646682;
    public const int ObjA9Tile2 = 646699;
    public const int ObjA9Tile3 = 646725;
    public const int ObjAATile = 646908;
    public const int ObjABTile = 646984;
    public const int ObjAA_ADCmp = 647060;
    public const int ObjAA_ADCmpPtr1 = 647092;
    public const int ObjAA_ADCmpPtr2 = 647108;
    public const int ObjACTile = 646745;
    public const int ObjADTile = 646832;
    public const int ObjAETile = 647488;
    public const int ObjAFTile = 647528;
    public const int ObjB0Tile = 647568;
    public const int ObjB1Cmp = 647678;
    public const int ObjB1Tile1 = 647702;
    public const int ObjB1Tile2 = 647726;
    public const int ObjB2Tile = 647801;
    public const int ObjB3Tile = 647836;
    public const int ObjB5Tile = 647869;
    public const int ObjB6Tile = 647904;
    public const int ObjB7Tile = 647975;
    public const int ObjB9Tile = 648044;
    public const int ObjBATile = 648115;
    public const int ObjBBTile = 648162;
    public const int ObjBDTile = 648209;
    public const int ObjBCTile = 648256;
    public const int ObjBECmp1 = 648303;
    public const int ObjBETile1 = 648391;
    public const int ObjBECmp2 = 648479;
    public const int ObjBETile2 = 648527;
    public const int ObjBECmp3 = 648567;
    public const int ObjBECmp4 = 648693;
    public const int ObjBETile3 = 648721;
    public const int ObjC0Cmp = 648936;
    public const int ObjC0Tile1 = 648962;
    public const int ObjC0Tile2 = 648988;
    public const int ObjC1Tile1 = 649171;
    public const int ObjC1Tile2 = 649197;
    public const int ObjC2Cmp = 649378;
    public const int ObjC3Cmp = 649425;
    public const int ObjCATilePtr = 649714;
    public const int ObjCBTile1 = 650224;
    public const int ObjCBTile2 = 650230;
    public const int ObjCCTile1 = 650078;
    public const int ObjCCTile2 = 650012;
    public const int ObjCCTile3 = 650020;
    public const int ObjCDTile = 649812;
    public const int ObjCFTile = 650338;
    public const int ObjD0Tile = 650365;
    public const int ObjD4Cmp = 650487;
    public const int ObjD4Tile1 = 650463;
    public const int ObjD4Tile2 = 650471;
    public const int ObjD4Tile3 = 650511;
    public const int ObjD4Tile4 = 650708;
    public const int ObjD5Tile1 = 650753;
    public const int ObjD5Tile2 = 650761;
    public const int ObjD5Tile3 = 650777;
    public const int ObjD5Tile4 = 650974;
    public const int ObjD6Cmp = 651043;
    public const int ObjD6Tile1 = 651019;
    public const int ObjD6Tile2 = 651027;
    public const int ObjD6Tile3 = 651069;
    public const int ObjD6Tile4 = 651273;
    public const int ObjD6Tile5 = 651277;
    public const int ObjD7Tile1 = 651322;
    public const int ObjD7Tile2 = 651330;
    public const int ObjD7Tile3 = 651346;
    public const int ObjD7Tile4 = 651550;
    public const int ObjD7Tile5 = 651554;
    public const int ObjD8_D9Height = 598390;
    public const int ObjD8_D9Tile = 651595;
    public const int ObjDBTile1 = 651668;
    public const int ObjDBTile2 = 651676;
    public const int ObjDCTile1 = 651744;
    public const int ObjDCTile2 = 651746;
    public const int ObjDCTile3 = 651762;
    public const int ObjDDTile = 651886;
    public const int ObjDETile1 = 652083;
    public const int ObjDETile2 = 652087;
    public const int ObjDFTile = 652126;
    public const int ObjE1Tile1 = 652232;
    public const int ObjE1Tile2 = 652254;
    public const int ObjE2Tile1 = 652388;
    public const int ObjE2Tile2 = 652452;
    public const int ObjE3Tile = 652555;
    public const int ObjE4TilePtr = 652750;
    public const int ObjE4Tile = 652852;
    public const int ObjE5TilePtr = 652994;
    public const int ObjE6TilePtr = 653159;
    public const int ObjE7TilePtr = 653263;
    public const int ObjE8TilePtr = 653432;
    public const int ObjE9TilePtr = 653631;
    public const int ObjEATilePtr = 653735;
    public const int ObjEBReplace = 653817;
    public const int ObjEBCmp = 653825;
    public const int ObjEDAdj = 654087;
    public const int ObjEDTile = 654198;
    public const int Map16Table = 799730;
    public const int Map16IndexTable = 799396;
    private static int _id;
    private static ushort _maxw;
    private static ushort _maxh;
    private static ushort _vflag;
    private static ushort _vadj;
    private static ushort _vcount;
    private static ushort _h;
    private static ushort _v;
    private static byte _x;
    private static byte _srcy;
    private static byte _y;
    private static bool _error_msg;
    private static Level.Object _obj;
    private static byte[] _sheader;
    private static unsafe byte* _ROM;
    private static unsafe byte* _RAM;
    private static byte _byte;
    private static ushort _ushort;
    private static unsafe byte* _byteptr;
    private static unsafe ushort* _ushortptr;
    private static Level.LevelTiles _lvltiles;
    private static bool _is_command_object;
    private static bool tilePlaced;
    private static uint _random_seed;
    private SNES.ROMFile _YI;
    private byte _number;
    private uint _objectID;
    private uint _spriteID;
    private bool _isWorld6;
    public byte YoshiColor;

    private static Level.LevelTileList[][] sTiles
    {
      get
      {
        return Level._lvltiles.Tiles;
      }
    }

    private static Level.LevelCommandList[] sCommandTiles
    {
      get
      {
        return Level._lvltiles.CommandTiles;
      }
    }

    private static byte HighLoc
    {
      get
      {
        return (byte) ((int) Level._y & 240 | (int) Level._x >> 4);
      }
    }

    private static byte LowLoc
    {
      get
      {
        return (byte) ((int) Level._y << 4 | (int) Level._x & 15);
      }
    }

    private static ushort sTile
    {
      get
      {
        return (int) Level._y < 128 ? Level.sTiles[(int) Level.HighLoc][(int) Level.LowLoc][0].tile : (ushort) 0;
      }
    }

    private static ushort sTileGroup
    {
      get
      {
        return (ushort) ((uint) Level.sTile & 65280U);
      }
    }

    private static int random
    {
      get
      {
        return (int) ((long) (uint) ((int) Level._random_seed + (int) crc32.crc32_table[(int) (byte) ((uint) Level._v % 7U + (uint) Level._h)] + (int) Level._obj.id * 34568) - (long) Level._v * 21411L) >> 13;
      }
    }

    private static int random2
    {
      get
      {
        return ((int) Level._random_seed + (int) Level._obj.id) * 214013 + 2531011 >> 16;
      }
    }

    private static int hindex
    {
      get
      {
        if ((int) Level._h == 0)
          return 0;
        return (int) Level._h + 1 == (int) Level._maxw ? 4 : 2;
      }
    }

    private static int vindex
    {
      get
      {
        if ((int) Level._v == 0)
          return 0;
        return (int) Level._v + 1 == (int) Level._maxh ? 4 : 2;
      }
    }

    public int BG1PaletteTable
    {
      get
      {
        return this.IsWorld6 ? 14516 : 14452;
      }
    }

    public uint BG1GraphicTable
    {
      get
      {
        return this.IsWorld6 ? 12137U : 12089U;
      }
    }

    public byte[] VRAM
    {
      get
      {
        return this._vram;
      }
    }

    public ushort[] CGRAM
    {
      get
      {
        return this._cgram;
      }
    }

    public uint[] Gradient
    {
      get
      {
        return this._gradient;
      }
    }

    public VariableByte[] RAM
    {
      get
      {
        return this._ram;
      }
    }

    public byte Number
    {
      get
      {
        return this._number;
      }
    }

    public byte[] Header
    {
      get
      {
        return this._header;
      }
    }

    public ushort[] SpriteTileRow
    {
      get
      {
        return this._spriteTileRow;
      }
    }

    public uint ObjectID
    {
      get
      {
        return this._objectID;
      }
      set
      {
        this._objectID = value;
      }
    }

    public uint SpriteID
    {
      get
      {
        return this._spriteID;
      }
      set
      {
        this._spriteID = value;
      }
    }

    public List<Level.Object> Objects
    {
      get
      {
        return this._objects;
      }
      set
      {
        this._objects = value;
      }
    }

    public List<Level.Sprite> Sprites
    {
      get
      {
        return this._sprites;
      }
    }

    public Level.ScreenExit[] Exits
    {
      get
      {
        return this._exits;
      }
      set
      {
        this._exits = value;
      }
    }

    public Level.LevelTileList[][] Tiles
    {
      get
      {
        return this._levelTiles.Tiles;
      }
    }

    public Level.LevelTileList[][] InternalTiles
    {
      get
      {
        return this._levelTiles.InternalTiles;
      }
    }

    public Level.LevelCommandList[] CommandTiles
    {
      get
      {
        return this._levelTiles.CommandTiles;
      }
    }

    public int[] PageFirstID
    {
      get
      {
        return this._levelTiles.PageFirstID;
      }
    }

    public int PageCount
    {
      get
      {
        return this._levelTiles.PageCount;
      }
    }

    public int[] OriginalPageFirstID
    {
      get
      {
        return this._levelTiles.OriginalPageFirstID;
      }
    }

    public bool IsWorld6
    {
      get
      {
        return this._isWorld6;
      }
      set
      {
        this._isWorld6 = value;
      }
    }

    public Level.CustomGradient customGradient
    {
      get
      {
        return this._customGradient;
      }
    }

    private SNES.ROMFile YI
    {
      get
      {
        return this._YI;
      }
    }

    static Level()
    {
      Level.DecompressExObjectInit[0] = new Level.LoadTiles(Level.ExObj00Init);
      Level.DecompressExObjectMain[0] = new Level.LoadTiles(Level.ExObj00Main);
      Level.DecompressExObjectInit[1] = new Level.LoadTiles(Level.ExObj00Init);
      Level.DecompressExObjectMain[1] = new Level.LoadTiles(Level.ExObj00Main);
      Level.DecompressExObjectInit[2] = new Level.LoadTiles(Level.ExObj00Init);
      Level.DecompressExObjectMain[2] = new Level.LoadTiles(Level.ExObj00Main);
      Level.DecompressExObjectInit[3] = new Level.LoadTiles(Level.ExObj00Init);
      Level.DecompressExObjectMain[3] = new Level.LoadTiles(Level.ExObj00Main);
      Level.DecompressExObjectInit[4] = new Level.LoadTiles(Level.ExObj00Init);
      Level.DecompressExObjectMain[4] = new Level.LoadTiles(Level.ExObj00Main);
      Level.DecompressExObjectInit[5] = new Level.LoadTiles(Level.ExObj00Init);
      Level.DecompressExObjectMain[5] = new Level.LoadTiles(Level.ExObj00Main);
      Level.DecompressExObjectInit[6] = new Level.LoadTiles(Level.ExObj00Init);
      Level.DecompressExObjectMain[6] = new Level.LoadTiles(Level.ExObj00Main);
      Level.DecompressExObjectInit[7] = new Level.LoadTiles(Level.ExObj00Init);
      Level.DecompressExObjectMain[7] = new Level.LoadTiles(Level.ExObj00Main);
      Level.DecompressExObjectInit[8] = new Level.LoadTiles(Level.ExObj00Init);
      Level.DecompressExObjectMain[8] = new Level.LoadTiles(Level.ExObj00Main);
      Level.DecompressExObjectInit[9] = new Level.LoadTiles(Level.ExObj00Init);
      Level.DecompressExObjectMain[9] = new Level.LoadTiles(Level.ExObj00Main);
      Level.DecompressExObjectInit[10] = new Level.LoadTiles(Level.ExObj0AInit);
      Level.DecompressExObjectMain[10] = new Level.LoadTiles(Level.ExObj0AMain);
      Level.DecompressExObjectInit[11] = new Level.LoadTiles(Level.ExObj0AInit);
      Level.DecompressExObjectMain[11] = new Level.LoadTiles(Level.ExObj0AMain);
      Level.DecompressExObjectInit[12] = new Level.LoadTiles(Level.ExObj0CInit);
      Level.DecompressExObjectMain[12] = new Level.LoadTiles(Level.ExObj0CMain);
      Level.DecompressExObjectInit[13] = new Level.LoadTiles(Level.ExObj0DInit);
      Level.DecompressExObjectMain[13] = new Level.LoadTiles(Level.ExObj0DMain);
      Level.DecompressExObjectInit[14] = new Level.LoadTiles(Level.ExObj0DInit);
      Level.DecompressExObjectMain[14] = new Level.LoadTiles(Level.ExObj0DMain);
      Level.DecompressExObjectInit[15] = new Level.LoadTiles(Level.ExObj0FInit);
      Level.DecompressExObjectMain[15] = new Level.LoadTiles(Level.ExObj0FMain);
      Level.DecompressExObjectInit[16] = new Level.LoadTiles(Level.ExObj10Init);
      Level.DecompressExObjectMain[16] = new Level.LoadTiles(Level.ExObj10Main);
      Level.DecompressExObjectInit[17] = new Level.LoadTiles(Level.ExObj11Init);
      Level.DecompressExObjectMain[17] = new Level.LoadTiles(Level.ExObj11Main);
      Level.DecompressExObjectInit[18] = new Level.LoadTiles(Level.ExObj12Init);
      Level.DecompressExObjectMain[18] = new Level.LoadTiles(Level.ExObj12Main);
      Level.DecompressExObjectInit[19] = new Level.LoadTiles(Level.ExObj12Init);
      Level.DecompressExObjectMain[19] = new Level.LoadTiles(Level.ExObj12Main);
      Level.DecompressExObjectInit[20] = new Level.LoadTiles(Level.ExObj14Init);
      Level.DecompressExObjectMain[20] = new Level.LoadTiles(Level.ExObj14Main);
      Level.DecompressExObjectInit[21] = new Level.LoadTiles(Level.ExObj14Init);
      Level.DecompressExObjectMain[21] = new Level.LoadTiles(Level.ExObj14Main);
      Level.DecompressExObjectInit[22] = new Level.LoadTiles(Level.ExObj16Init);
      Level.DecompressExObjectMain[22] = new Level.LoadTiles(Level.ExObj16Main);
      Level.DecompressExObjectInit[23] = new Level.LoadTiles(Level.ExObj17Init);
      Level.DecompressExObjectMain[23] = new Level.LoadTiles(Level.ExObj17Main);
      Level.DecompressExObjectInit[24] = new Level.LoadTiles(Level.ExObj18Init);
      Level.DecompressExObjectMain[24] = new Level.LoadTiles(Level.ExObj18Main);
      Level.DecompressExObjectInit[25] = new Level.LoadTiles(Level.ExObj19Init);
      Level.DecompressExObjectMain[25] = new Level.LoadTiles(Level.ExObj19Main);
      Level.DecompressExObjectInit[26] = new Level.LoadTiles(Level.ExObj19Init);
      Level.DecompressExObjectMain[26] = new Level.LoadTiles(Level.ExObj19Main);
      Level.DecompressExObjectInit[27] = new Level.LoadTiles(Level.ExObj1BInit);
      Level.DecompressExObjectMain[27] = new Level.LoadTiles(Level.ExObj1BMain);
      Level.DecompressExObjectInit[28] = new Level.LoadTiles(Level.ExObj1BInit);
      Level.DecompressExObjectMain[28] = new Level.LoadTiles(Level.ExObj1BMain);
      Level.DecompressExObjectInit[29] = new Level.LoadTiles(Level.ExObj1BInit);
      Level.DecompressExObjectMain[29] = new Level.LoadTiles(Level.ExObj1BMain);
      Level.DecompressExObjectInit[30] = new Level.LoadTiles(Level.ExObj1EInit);
      Level.DecompressExObjectMain[30] = new Level.LoadTiles(Level.ExObj1EMain);
      Level.DecompressExObjectInit[31] = new Level.LoadTiles(Level.ExObj1FInit);
      Level.DecompressExObjectMain[31] = new Level.LoadTiles(Level.ExObj1FMain);
      Level.DecompressExObjectInit[32] = new Level.LoadTiles(Level.ExObj20Init);
      Level.DecompressExObjectMain[32] = new Level.LoadTiles(Level.ExObj20Main);
      Level.DecompressExObjectInit[33] = new Level.LoadTiles(Level.ExObj20Init);
      Level.DecompressExObjectMain[33] = new Level.LoadTiles(Level.ExObj20Main);
      Level.DecompressExObjectInit[34] = new Level.LoadTiles(Level.ExObj20Init);
      Level.DecompressExObjectMain[34] = new Level.LoadTiles(Level.ExObj20Main);
      Level.DecompressExObjectInit[35] = new Level.LoadTiles(Level.ExObj20Init);
      Level.DecompressExObjectMain[35] = new Level.LoadTiles(Level.ExObj20Main);
      Level.DecompressExObjectInit[36] = new Level.LoadTiles(Level.ExObj20Init);
      Level.DecompressExObjectMain[36] = new Level.LoadTiles(Level.ExObj20Main);
      Level.DecompressExObjectInit[37] = new Level.LoadTiles(Level.ExObj20Init);
      Level.DecompressExObjectMain[37] = new Level.LoadTiles(Level.ExObj20Main);
      Level.DecompressExObjectInit[38] = new Level.LoadTiles(Level.ExObj20Init);
      Level.DecompressExObjectMain[38] = new Level.LoadTiles(Level.ExObj20Main);
      Level.DecompressExObjectInit[39] = new Level.LoadTiles(Level.ExObj20Init);
      Level.DecompressExObjectMain[39] = new Level.LoadTiles(Level.ExObj20Main);
      Level.DecompressExObjectInit[40] = new Level.LoadTiles(Level.ExObj20Init);
      Level.DecompressExObjectMain[40] = new Level.LoadTiles(Level.ExObj20Main);
      Level.DecompressExObjectInit[41] = new Level.LoadTiles(Level.ExObj20Init);
      Level.DecompressExObjectMain[41] = new Level.LoadTiles(Level.ExObj20Main);
      Level.DecompressExObjectInit[42] = new Level.LoadTiles(Level.ExObj20Init);
      Level.DecompressExObjectMain[42] = new Level.LoadTiles(Level.ExObj20Main);
      Level.DecompressExObjectInit[43] = new Level.LoadTiles(Level.ExObj20Init);
      Level.DecompressExObjectMain[43] = new Level.LoadTiles(Level.ExObj20Main);
      Level.DecompressExObjectInit[44] = new Level.LoadTiles(Level.ExObj20Init);
      Level.DecompressExObjectMain[44] = new Level.LoadTiles(Level.ExObj20Main);
      Level.DecompressExObjectInit[45] = new Level.LoadTiles(Level.ExObj20Init);
      Level.DecompressExObjectMain[45] = new Level.LoadTiles(Level.ExObj20Main);
      Level.DecompressExObjectInit[46] = new Level.LoadTiles(Level.ExObj20Init);
      Level.DecompressExObjectMain[46] = new Level.LoadTiles(Level.ExObj20Main);
      Level.DecompressExObjectInit[47] = new Level.LoadTiles(Level.ExObj20Init);
      Level.DecompressExObjectMain[47] = new Level.LoadTiles(Level.ExObj20Main);
      Level.DecompressExObjectInit[48] = new Level.LoadTiles(Level.ExObj30Init);
      Level.DecompressExObjectMain[48] = new Level.LoadTiles(Level.ExObj30Main);
      Level.DecompressExObjectInit[49] = new Level.LoadTiles(Level.ExObj31Init);
      Level.DecompressExObjectMain[49] = new Level.LoadTiles(Level.ExObj31Main);
      Level.DecompressExObjectInit[50] = new Level.LoadTiles(Level.ExObj32Init);
      Level.DecompressExObjectMain[50] = new Level.LoadTiles(Level.ExObj32Main);
      Level.DecompressExObjectInit[51] = new Level.LoadTiles(Level.ExObj32Init);
      Level.DecompressExObjectMain[51] = new Level.LoadTiles(Level.ExObj32Main);
      Level.DecompressExObjectInit[52] = new Level.LoadTiles(Level.ExObj32Init);
      Level.DecompressExObjectMain[52] = new Level.LoadTiles(Level.ExObj32Main);
      Level.DecompressExObjectInit[53] = new Level.LoadTiles(Level.ExObj32Init);
      Level.DecompressExObjectMain[53] = new Level.LoadTiles(Level.ExObj32Main);
      Level.DecompressExObjectInit[54] = new Level.LoadTiles(Level.ExObj32Init);
      Level.DecompressExObjectMain[54] = new Level.LoadTiles(Level.ExObj32Main);
      Level.DecompressExObjectInit[55] = new Level.LoadTiles(Level.ExObj32Init);
      Level.DecompressExObjectMain[55] = new Level.LoadTiles(Level.ExObj32Main);
      Level.DecompressExObjectInit[56] = new Level.LoadTiles(Level.ExObj32Init);
      Level.DecompressExObjectMain[56] = new Level.LoadTiles(Level.ExObj32Main);
      Level.DecompressExObjectInit[57] = new Level.LoadTiles(Level.ExObj32Init);
      Level.DecompressExObjectMain[57] = new Level.LoadTiles(Level.ExObj32Main);
      Level.DecompressExObjectInit[58] = new Level.LoadTiles(Level.ExObj32Init);
      Level.DecompressExObjectMain[58] = new Level.LoadTiles(Level.ExObj32Main);
      Level.DecompressExObjectInit[59] = new Level.LoadTiles(Level.ExObj32Init);
      Level.DecompressExObjectMain[59] = new Level.LoadTiles(Level.ExObj32Main);
      Level.DecompressExObjectInit[60] = new Level.LoadTiles(Level.ExObj32Init);
      Level.DecompressExObjectMain[60] = new Level.LoadTiles(Level.ExObj32Main);
      Level.DecompressExObjectInit[61] = new Level.LoadTiles(Level.ExObj32Init);
      Level.DecompressExObjectMain[61] = new Level.LoadTiles(Level.ExObj32Main);
      Level.DecompressExObjectInit[62] = new Level.LoadTiles(Level.ExObj32Init);
      Level.DecompressExObjectMain[62] = new Level.LoadTiles(Level.ExObj32Main);
      Level.DecompressExObjectInit[63] = new Level.LoadTiles(Level.ExObj32Init);
      Level.DecompressExObjectMain[63] = new Level.LoadTiles(Level.ExObj32Main);
      Level.DecompressExObjectInit[64] = new Level.LoadTiles(Level.ExObj32Init);
      Level.DecompressExObjectMain[64] = new Level.LoadTiles(Level.ExObj32Main);
      Level.DecompressExObjectInit[65] = new Level.LoadTiles(Level.ExObj32Init);
      Level.DecompressExObjectMain[65] = new Level.LoadTiles(Level.ExObj32Main);
      Level.DecompressExObjectInit[66] = new Level.LoadTiles(Level.ExObj32Init);
      Level.DecompressExObjectMain[66] = new Level.LoadTiles(Level.ExObj32Main);
      Level.DecompressExObjectInit[67] = new Level.LoadTiles(Level.ExObj32Init);
      Level.DecompressExObjectMain[67] = new Level.LoadTiles(Level.ExObj32Main);
      Level.DecompressExObjectInit[68] = new Level.LoadTiles(Level.ExObj32Init);
      Level.DecompressExObjectMain[68] = new Level.LoadTiles(Level.ExObj32Main);
      Level.DecompressExObjectInit[69] = new Level.LoadTiles(Level.ExObj32Init);
      Level.DecompressExObjectMain[69] = new Level.LoadTiles(Level.ExObj32Main);
      Level.DecompressExObjectInit[70] = new Level.LoadTiles(Level.ExObj46Init);
      Level.DecompressExObjectMain[70] = new Level.LoadTiles(Level.ExObj46Main);
      Level.DecompressExObjectInit[71] = new Level.LoadTiles(Level.ExObj47Init);
      Level.DecompressExObjectMain[71] = new Level.LoadTiles(Level.ExObj47Main);
      Level.DecompressExObjectInit[72] = new Level.LoadTiles(Level.ExObj48Init);
      Level.DecompressExObjectMain[72] = new Level.LoadTiles(Level.ExObj48Main);
      Level.DecompressExObjectInit[73] = new Level.LoadTiles(Level.ExObj49Init);
      Level.DecompressExObjectMain[73] = new Level.LoadTiles(Level.ExObj49Main);
      Level.DecompressExObjectInit[74] = new Level.LoadTiles(Level.ExObj4AInit);
      Level.DecompressExObjectMain[74] = new Level.LoadTiles(Level.ExObj4AMain);
      Level.DecompressExObjectInit[75] = new Level.LoadTiles(Level.ExObj4BInit);
      Level.DecompressExObjectMain[75] = new Level.LoadTiles(Level.ExObj4BMain);
      Level.DecompressExObjectInit[76] = new Level.LoadTiles(Level.ExObj4CInit);
      Level.DecompressExObjectMain[76] = new Level.LoadTiles(Level.ExObj4CMain);
      Level.DecompressExObjectInit[77] = new Level.LoadTiles(Level.ExObj4DInit);
      Level.DecompressExObjectMain[77] = new Level.LoadTiles(Level.ExObj4DMain);
      Level.DecompressExObjectInit[78] = new Level.LoadTiles(Level.ExObj4EInit);
      Level.DecompressExObjectMain[78] = new Level.LoadTiles(Level.ExObj4EMain);
      Level.DecompressExObjectInit[79] = new Level.LoadTiles(Level.ExObj4FInit);
      Level.DecompressExObjectMain[79] = new Level.LoadTiles(Level.ExObj4FMain);
      Level.DecompressExObjectInit[80] = new Level.LoadTiles(Level.ExObj50Init);
      Level.DecompressExObjectMain[80] = new Level.LoadTiles(Level.ExObj50Main);
      Level.DecompressExObjectInit[81] = new Level.LoadTiles(Level.ExObj51Init);
      Level.DecompressExObjectMain[81] = new Level.LoadTiles(Level.ExObj51Main);
      Level.DecompressExObjectInit[82] = new Level.LoadTiles(Level.ExObj52Init);
      Level.DecompressExObjectMain[82] = new Level.LoadTiles(Level.ExObj52Main);
      Level.DecompressExObjectInit[83] = new Level.LoadTiles(Level.ExObj53Init);
      Level.DecompressExObjectMain[83] = new Level.LoadTiles(Level.ExObj53Main);
      Level.DecompressExObjectInit[84] = new Level.LoadTiles(Level.ExObj54Init);
      Level.DecompressExObjectMain[84] = new Level.LoadTiles(Level.ExObj54Main);
      Level.DecompressExObjectInit[85] = new Level.LoadTiles(Level.ExObj54Init);
      Level.DecompressExObjectMain[85] = new Level.LoadTiles(Level.ExObj54Main);
      Level.DecompressExObjectInit[86] = new Level.LoadTiles(Level.ExObj56Init);
      Level.DecompressExObjectMain[86] = new Level.LoadTiles(Level.ExObj54Main);
      Level.DecompressExObjectInit[87] = new Level.LoadTiles(Level.ExObj56Init);
      Level.DecompressExObjectMain[87] = new Level.LoadTiles(Level.ExObj54Main);
      Level.DecompressExObjectInit[88] = new Level.LoadTiles(Level.ExObj58Init);
      Level.DecompressExObjectMain[88] = new Level.LoadTiles(Level.ExObj54Main);
      Level.DecompressExObjectInit[89] = new Level.LoadTiles(Level.ExObj58Init);
      Level.DecompressExObjectMain[89] = new Level.LoadTiles(Level.ExObj54Main);
      Level.DecompressExObjectInit[90] = new Level.LoadTiles(Level.ExObj58Init);
      Level.DecompressExObjectMain[90] = new Level.LoadTiles(Level.ExObj54Main);
      Level.DecompressExObjectInit[91] = new Level.LoadTiles(Level.ExObj5BInit);
      Level.DecompressExObjectMain[91] = new Level.LoadTiles(Level.ExObj54Main);
      Level.DecompressExObjectInit[92] = new Level.LoadTiles(Level.ExObj5BInit);
      Level.DecompressExObjectMain[92] = new Level.LoadTiles(Level.ExObj54Main);
      Level.DecompressExObjectInit[93] = new Level.LoadTiles(Level.ExObj5BInit);
      Level.DecompressExObjectMain[93] = new Level.LoadTiles(Level.ExObj54Main);
      Level.DecompressExObjectInit[94] = new Level.LoadTiles(Level.ExObj5EInit);
      Level.DecompressExObjectMain[94] = new Level.LoadTiles(Level.ExObj5EMain);
      Level.DecompressExObjectInit[95] = new Level.LoadTiles(Level.ExObj5FInit);
      Level.DecompressExObjectMain[95] = new Level.LoadTiles(Level.ExObj5FMain);
      Level.DecompressExObjectInit[96] = new Level.LoadTiles(Level.ExObj60Init);
      Level.DecompressExObjectMain[96] = new Level.LoadTiles(Level.ExObj5FMain);
      Level.DecompressExObjectInit[97] = new Level.LoadTiles(Level.ExObj61Init);
      Level.DecompressExObjectMain[97] = new Level.LoadTiles(Level.ExObj5FMain);
      Level.DecompressExObjectInit[98] = new Level.LoadTiles(Level.ExObj62Init);
      Level.DecompressExObjectMain[98] = new Level.LoadTiles(Level.ExObj5FMain);
      Level.DecompressExObjectInit[99] = new Level.LoadTiles(Level.ExObj63Init);
      Level.DecompressExObjectMain[99] = new Level.LoadTiles(Level.ExObj5FMain);
      Level.DecompressExObjectInit[100] = new Level.LoadTiles(Level.ExObj64Init);
      Level.DecompressExObjectMain[100] = new Level.LoadTiles(Level.ExObj5FMain);
      Level.DecompressExObjectInit[101] = new Level.LoadTiles(Level.ExObj65Init);
      Level.DecompressExObjectMain[101] = new Level.LoadTiles(Level.ExObj5FMain);
      Level.DecompressExObjectInit[102] = new Level.LoadTiles(Level.ExObj66Init);
      Level.DecompressExObjectMain[102] = new Level.LoadTiles(Level.ExObj5FMain);
      Level.DecompressExObjectInit[103] = new Level.LoadTiles(Level.ExObj67Init);
      Level.DecompressExObjectMain[103] = new Level.LoadTiles(Level.ExObj67Main);
      Level.DecompressExObjectInit[104] = new Level.LoadTiles(Level.ExObj68Init);
      Level.DecompressExObjectMain[104] = new Level.LoadTiles(Level.ExObj68Main);
      Level.DecompressExObjectInit[105] = new Level.LoadTiles(Level.ExObj68Init);
      Level.DecompressExObjectMain[105] = new Level.LoadTiles(Level.ExObj68Main);
      Level.DecompressExObjectInit[106] = new Level.LoadTiles(Level.ExObj6AInit);
      Level.DecompressExObjectMain[106] = new Level.LoadTiles(Level.ExObj6AMain);
      Level.DecompressExObjectInit[107] = new Level.LoadTiles(Level.ExObj6BInit);
      Level.DecompressExObjectMain[107] = new Level.LoadTiles(Level.ExObj6AMain);
      Level.DecompressExObjectInit[108] = new Level.LoadTiles(Level.ExObj6CInit);
      Level.DecompressExObjectMain[108] = new Level.LoadTiles(Level.ExObj6CMain);
      Level.DecompressExObjectInit[109] = new Level.LoadTiles(Level.ExObj6DInit);
      Level.DecompressExObjectMain[109] = new Level.LoadTiles(Level.ExObj6DMain);
      Level.DecompressExObjectInit[110] = new Level.LoadTiles(Level.ExObj6DInit);
      Level.DecompressExObjectMain[110] = new Level.LoadTiles(Level.ExObj6DMain);
      Level.DecompressExObjectInit[111] = new Level.LoadTiles(Level.ExObj6DInit);
      Level.DecompressExObjectMain[111] = new Level.LoadTiles(Level.ExObj6DMain);
      Level.DecompressExObjectInit[112] = new Level.LoadTiles(Level.ExObj6DInit);
      Level.DecompressExObjectMain[112] = new Level.LoadTiles(Level.ExObj6DMain);
      Level.DecompressExObjectInit[113] = new Level.LoadTiles(Level.ExObj71Init);
      Level.DecompressExObjectMain[113] = new Level.LoadTiles(Level.ExObj71Main);
      Level.DecompressExObjectInit[114] = new Level.LoadTiles(Level.ExObj71Init);
      Level.DecompressExObjectMain[114] = new Level.LoadTiles(Level.ExObj72Main);
      Level.DecompressExObjectInit[115] = new Level.LoadTiles(Level.ExObj71Init);
      Level.DecompressExObjectMain[115] = new Level.LoadTiles(Level.ExObj73Main);
      Level.DecompressExObjectInit[116] = new Level.LoadTiles(Level.ExObj71Init);
      Level.DecompressExObjectMain[116] = new Level.LoadTiles(Level.ExObj74Main);
      Level.DecompressExObjectInit[117] = new Level.LoadTiles(Level.ExObj71Init);
      Level.DecompressExObjectMain[117] = new Level.LoadTiles(Level.ExObj75Main);
      Level.DecompressExObjectInit[118] = new Level.LoadTiles(Level.ExObj71Init);
      Level.DecompressExObjectMain[118] = new Level.LoadTiles(Level.ExObj76Main);
      Level.DecompressExObjectInit[119] = new Level.LoadTiles(Level.ExObj71Init);
      Level.DecompressExObjectMain[119] = new Level.LoadTiles(Level.ExObj77Main);
      Level.DecompressExObjectInit[120] = new Level.LoadTiles(Level.ExObj71Init);
      Level.DecompressExObjectMain[120] = new Level.LoadTiles(Level.ExObj78Main);
      Level.DecompressExObjectInit[121] = new Level.LoadTiles(Level.ExObj71Init);
      Level.DecompressExObjectMain[121] = new Level.LoadTiles(Level.ExObj79Main);
      Level.DecompressExObjectInit[122] = new Level.LoadTiles(Level.ExObj71Init);
      Level.DecompressExObjectMain[122] = new Level.LoadTiles(Level.ExObj7AMain);
      Level.DecompressExObjectInit[123] = new Level.LoadTiles(Level.ExObj71Init);
      Level.DecompressExObjectMain[123] = new Level.LoadTiles(Level.ExObj7BMain);
      Level.DecompressExObjectInit[124] = new Level.LoadTiles(Level.ExObj71Init);
      Level.DecompressExObjectMain[124] = new Level.LoadTiles(Level.ExObj7CMain);
      Level.DecompressExObjectInit[125] = new Level.LoadTiles(Level.ExObj71Init);
      Level.DecompressExObjectMain[125] = new Level.LoadTiles(Level.ExObj7DMain);
      Level.DecompressExObjectInit[126] = new Level.LoadTiles(Level.ExObj7EInit);
      Level.DecompressExObjectMain[126] = new Level.LoadTiles(Level.ExObj7EMain);
      Level.DecompressExObjectInit[(int) sbyte.MaxValue] = new Level.LoadTiles(Level.ExObj7EInit);
      Level.DecompressExObjectMain[(int) sbyte.MaxValue] = new Level.LoadTiles(Level.ExObj7EMain);
      Level.DecompressExObjectInit[128] = new Level.LoadTiles(Level.ExObj80Init);
      Level.DecompressExObjectMain[128] = new Level.LoadTiles(Level.ExObj80Main);
      Level.DecompressExObjectInit[129] = new Level.LoadTiles(Level.ExObj81Init);
      Level.DecompressExObjectMain[129] = new Level.LoadTiles(Level.ExObj81Main);
      Level.DecompressExObjectInit[130] = new Level.LoadTiles(Level.ExObj82Init);
      Level.DecompressExObjectMain[130] = new Level.LoadTiles(Level.ExObj82Main);
      Level.DecompressExObjectInit[131] = new Level.LoadTiles(Level.ExObj83Init);
      Level.DecompressExObjectMain[131] = new Level.LoadTiles(Level.ExObj83Main);
      Level.DecompressExObjectInit[132] = new Level.LoadTiles(Level.ExObj83Init);
      Level.DecompressExObjectMain[132] = new Level.LoadTiles(Level.ExObj83Main);
      Level.DecompressExObjectInit[133] = new Level.LoadTiles(Level.ExObj83Init);
      Level.DecompressExObjectMain[133] = new Level.LoadTiles(Level.ExObj83Main);
      Level.DecompressExObjectInit[134] = new Level.LoadTiles(Level.ExObj83Init);
      Level.DecompressExObjectMain[134] = new Level.LoadTiles(Level.ExObj83Main);
      Level.DecompressExObjectInit[135] = new Level.LoadTiles(Level.ExObj83Init);
      Level.DecompressExObjectMain[135] = new Level.LoadTiles(Level.ExObj83Main);
      Level.DecompressExObjectInit[136] = new Level.LoadTiles(Level.ExObj88Init);
      Level.DecompressExObjectMain[136] = new Level.LoadTiles(Level.ExObj88Main);
      Level.DecompressExObjectInit[137] = new Level.LoadTiles(Level.ExObj89Init);
      Level.DecompressExObjectMain[137] = new Level.LoadTiles(Level.ExObj89Main);
      Level.DecompressExObjectInit[138] = new Level.LoadTiles(Level.ExObj89Init);
      Level.DecompressExObjectMain[138] = new Level.LoadTiles(Level.ExObj89Main);
      Level.DecompressExObjectInit[139] = new Level.LoadTiles(Level.ExObj89Init);
      Level.DecompressExObjectMain[139] = new Level.LoadTiles(Level.ExObj89Main);
      Level.DecompressExObjectInit[140] = new Level.LoadTiles(Level.ExObj89Init);
      Level.DecompressExObjectMain[140] = new Level.LoadTiles(Level.ExObj89Main);
      Level.DecompressExObjectInit[141] = new Level.LoadTiles(Level.ExObj8DInit);
      Level.DecompressExObjectMain[141] = new Level.LoadTiles(Level.ExObj8DMain);
      Level.DecompressExObjectInit[142] = new Level.LoadTiles(Level.ExObj8EInit);
      Level.DecompressExObjectMain[142] = new Level.LoadTiles(Level.ExObj8EMain);
      Level.DecompressExObjectInit[143] = new Level.LoadTiles(Level.ExObj8EInit);
      Level.DecompressExObjectMain[143] = new Level.LoadTiles(Level.ExObj8EMain);
      Level.DecompressExObjectInit[144] = new Level.LoadTiles(Level.ExObj8EInit);
      Level.DecompressExObjectMain[144] = new Level.LoadTiles(Level.ExObj8EMain);
      Level.DecompressExObjectInit[145] = new Level.LoadTiles(Level.ExObj8EInit);
      Level.DecompressExObjectMain[145] = new Level.LoadTiles(Level.ExObj8EMain);
      Level.DecompressExObjectInit[146] = new Level.LoadTiles(Level.ExObj92Init);
      Level.DecompressExObjectMain[146] = new Level.LoadTiles(Level.ExObj92Main);
      Level.DecompressExObjectInit[147] = new Level.LoadTiles(Level.ExObj92Init);
      Level.DecompressExObjectMain[147] = new Level.LoadTiles(Level.ExObj92Main);
      Level.DecompressExObjectInit[148] = new Level.LoadTiles(Level.ExObj92Init);
      Level.DecompressExObjectMain[148] = new Level.LoadTiles(Level.ExObj92Main);
      Level.DecompressExObjectInit[149] = new Level.LoadTiles(Level.ExObj92Init);
      Level.DecompressExObjectMain[149] = new Level.LoadTiles(Level.ExObj92Main);
      Level.DecompressExObjectInit[150] = new Level.LoadTiles(Level.ExObj96Init);
      Level.DecompressExObjectMain[150] = new Level.LoadTiles(Level.ExObj96Main);
      Level.DecompressExObjectInit[151] = new Level.LoadTiles(Level.ExObj96Init);
      Level.DecompressExObjectMain[151] = new Level.LoadTiles(Level.ExObj96Main);
      Level.DecompressExObjectInit[152] = new Level.LoadTiles(Level.ExObj96Init);
      Level.DecompressExObjectMain[152] = new Level.LoadTiles(Level.ExObj96Main);
      Level.DecompressExObjectInit[153] = new Level.LoadTiles(Level.ExObj96Init);
      Level.DecompressExObjectMain[153] = new Level.LoadTiles(Level.ExObj96Main);
      Level.DecompressExObjectInit[154] = new Level.LoadTiles(Level.ExObj9AInit);
      Level.DecompressExObjectMain[154] = new Level.LoadTiles(Level.ExObj9AMain);
      Level.DecompressExObjectInit[155] = new Level.LoadTiles(Level.ExObj9AInit);
      Level.DecompressExObjectMain[155] = new Level.LoadTiles(Level.ExObj9AMain);
      Level.DecompressExObjectInit[156] = new Level.LoadTiles(Level.ExObj9AInit);
      Level.DecompressExObjectMain[156] = new Level.LoadTiles(Level.ExObj9AMain);
      Level.DecompressExObjectInit[157] = new Level.LoadTiles(Level.ExObj9AInit);
      Level.DecompressExObjectMain[157] = new Level.LoadTiles(Level.ExObj9AMain);
      Level.DecompressExObjectInit[158] = new Level.LoadTiles(Level.ExObj9EInit);
      Level.DecompressExObjectMain[158] = new Level.LoadTiles(Level.ExObj9EMain);
      Level.DecompressExObjectInit[159] = new Level.LoadTiles(Level.ExObj9EInit);
      Level.DecompressExObjectMain[159] = new Level.LoadTiles(Level.ExObj9EMain);
      Level.DecompressExObjectInit[160] = new Level.LoadTiles(Level.ExObjA0Init);
      Level.DecompressExObjectMain[160] = new Level.LoadTiles(Level.ExObjA0Main);
      Level.DecompressExObjectInit[161] = new Level.LoadTiles(Level.ExObjA0Init);
      Level.DecompressExObjectMain[161] = new Level.LoadTiles(Level.ExObjA1Main);
      Level.DecompressExObjectInit[162] = new Level.LoadTiles(Level.ExObjA0Init);
      Level.DecompressExObjectMain[162] = new Level.LoadTiles(Level.ExObjA2Main);
      Level.DecompressExObjectInit[163] = new Level.LoadTiles(Level.ExObjA0Init);
      Level.DecompressExObjectMain[163] = new Level.LoadTiles(Level.ExObjA3Main);
      Level.DecompressExObjectInit[164] = new Level.LoadTiles(Level.ExObjA4Init);
      Level.DecompressExObjectMain[164] = new Level.LoadTiles(Level.ExObjA4Main);
      Level.DecompressExObjectInit[165] = new Level.LoadTiles(Level.ExObjA5Init);
      Level.DecompressExObjectMain[165] = new Level.LoadTiles(Level.ExObjA5Main);
      Level.DecompressExObjectInit[166] = new Level.LoadTiles(Level.ExObjA5Init);
      Level.DecompressExObjectMain[166] = new Level.LoadTiles(Level.ExObjA5Main);
      Level.DecompressExObjectInit[167] = new Level.LoadTiles(Level.ExObjA7Init);
      Level.DecompressExObjectMain[167] = new Level.LoadTiles(Level.ExObjA7Main);
      Level.DecompressExObjectInit[168] = new Level.LoadTiles(Level.ExObj50Init);
      Level.DecompressExObjectMain[168] = new Level.LoadTiles(Level.ExObj50Main);
      Level.DecompressExObjectInit[169] = new Level.LoadTiles(Level.ExObjA9Init);
      Level.DecompressExObjectMain[169] = new Level.LoadTiles(Level.ExObjA9Main);
      Level.DecompressExObjectInit[170] = new Level.LoadTiles(Level.ExObjA9Init);
      Level.DecompressExObjectMain[170] = new Level.LoadTiles(Level.ExObjA9Main);
      Level.DecompressExObjectInit[171] = new Level.LoadTiles(Level.ExObjA9Init);
      Level.DecompressExObjectMain[171] = new Level.LoadTiles(Level.ExObjA9Main);
      Level.DecompressExObjectInit[172] = new Level.LoadTiles(Level.ExObjA9Init);
      Level.DecompressExObjectMain[172] = new Level.LoadTiles(Level.ExObjA9Main);
      Level.DecompressExObjectInit[173] = new Level.LoadTiles(Level.ExObjADInit);
      Level.DecompressExObjectMain[173] = new Level.LoadTiles(Level.ExObjADMain);
      Level.DecompressExObjectInit[174] = new Level.LoadTiles(Level.ExObjADInit);
      Level.DecompressExObjectMain[174] = new Level.LoadTiles(Level.ExObjADMain);
      Level.DecompressExObjectInit[175] = new Level.LoadTiles(Level.ExObjADInit);
      Level.DecompressExObjectMain[175] = new Level.LoadTiles(Level.ExObjADMain);
      Level.DecompressExObjectInit[176] = new Level.LoadTiles(Level.ExObjADInit);
      Level.DecompressExObjectMain[176] = new Level.LoadTiles(Level.ExObjADMain);
      Level.DecompressExObjectInit[177] = new Level.LoadTiles(Level.ExObjADInit);
      Level.DecompressExObjectMain[177] = new Level.LoadTiles(Level.ExObjADMain);
      Level.DecompressExObjectInit[178] = new Level.LoadTiles(Level.ExObjADInit);
      Level.DecompressExObjectMain[178] = new Level.LoadTiles(Level.ExObjADMain);
      Level.DecompressExObjectInit[179] = new Level.LoadTiles(Level.ExObjB3Init);
      Level.DecompressExObjectMain[179] = new Level.LoadTiles(Level.ExObjB3Main);
      Level.DecompressExObjectInit[180] = new Level.LoadTiles(Level.ExObjB4Init);
      Level.DecompressExObjectMain[180] = new Level.LoadTiles(Level.ExObjB4Main);
      Level.DecompressExObjectInit[181] = new Level.LoadTiles(Level.ExObjB4Init);
      Level.DecompressExObjectMain[181] = new Level.LoadTiles(Level.ExObjB4Main);
      Level.DecompressExObjectInit[182] = new Level.LoadTiles(Level.ExObjB6Init);
      Level.DecompressExObjectMain[182] = new Level.LoadTiles(Level.ExObjB6Main);
      Level.DecompressExObjectInit[183] = new Level.LoadTiles(Level.ExObjB6Init);
      Level.DecompressExObjectMain[183] = new Level.LoadTiles(Level.ExObjB6Main);
      Level.DecompressExObjectInit[184] = new Level.LoadTiles(Level.ExObjB8Init);
      Level.DecompressExObjectMain[184] = new Level.LoadTiles(Level.ExObjB8Main);
      Level.DecompressExObjectInit[185] = new Level.LoadTiles(Level.ExObjB8Init);
      Level.DecompressExObjectMain[185] = new Level.LoadTiles(Level.ExObjB8Main);
      Level.DecompressExObjectInit[186] = new Level.LoadTiles(Level.ExObjBAInit);
      Level.DecompressExObjectMain[186] = new Level.LoadTiles(Level.ExObjBAMain);
      Level.DecompressExObjectInit[187] = new Level.LoadTiles(Level.ExObjBAInit);
      Level.DecompressExObjectMain[187] = new Level.LoadTiles(Level.ExObjBAMain);
      Level.DecompressExObjectInit[188] = new Level.LoadTiles(Level.ExObjBAInit);
      Level.DecompressExObjectMain[188] = new Level.LoadTiles(Level.ExObjBAMain);
      Level.DecompressExObjectInit[189] = new Level.LoadTiles(Level.ExObjBAInit);
      Level.DecompressExObjectMain[189] = new Level.LoadTiles(Level.ExObjBAMain);
      Level.DecompressExObjectInit[190] = new Level.LoadTiles(Level.ExObjBAInit);
      Level.DecompressExObjectMain[190] = new Level.LoadTiles(Level.ExObjBAMain);
      Level.DecompressExObjectInit[191] = new Level.LoadTiles(Level.ExObjBAInit);
      Level.DecompressExObjectMain[191] = new Level.LoadTiles(Level.ExObjBAMain);
      Level.DecompressExObjectInit[192] = new Level.LoadTiles(Level.ExObjC0Init);
      Level.DecompressExObjectMain[192] = new Level.LoadTiles(Level.ExObjC0Main);
      Level.DecompressExObjectInit[193] = new Level.LoadTiles(Level.ExObjC1Init);
      Level.DecompressExObjectMain[193] = new Level.LoadTiles(Level.ExObjC1Main);
      Level.DecompressExObjectInit[194] = new Level.LoadTiles(Level.ExObjC2Init);
      Level.DecompressExObjectMain[194] = new Level.LoadTiles(Level.ExObjC2Main);
      Level.DecompressExObjectInit[195] = new Level.LoadTiles(Level.ExObjC2Init);
      Level.DecompressExObjectMain[195] = new Level.LoadTiles(Level.ExObjC2Main);
      Level.DecompressExObjectInit[196] = new Level.LoadTiles(Level.ExObjC4Init);
      Level.DecompressExObjectMain[196] = new Level.LoadTiles(Level.ExObjC4Main);
      Level.DecompressExObjectInit[197] = new Level.LoadTiles(Level.ExObjC5Init);
      Level.DecompressExObjectMain[197] = new Level.LoadTiles(Level.ExObjC5Main);
      Level.DecompressExObjectInit[198] = new Level.LoadTiles(Level.ExObjC5Init);
      Level.DecompressExObjectMain[198] = new Level.LoadTiles(Level.ExObjC5Main);
      Level.DecompressExObjectInit[199] = new Level.LoadTiles(Level.ExObjC5Init);
      Level.DecompressExObjectMain[199] = new Level.LoadTiles(Level.ExObjC5Main);
      Level.DecompressExObjectInit[200] = new Level.LoadTiles(Level.ExObjC5Init);
      Level.DecompressExObjectMain[200] = new Level.LoadTiles(Level.ExObjC5Main);
      Level.DecompressExObjectInit[201] = new Level.LoadTiles(Level.ExObjC5Init);
      Level.DecompressExObjectMain[201] = new Level.LoadTiles(Level.ExObjC5Main);
      Level.DecompressExObjectInit[202] = new Level.LoadTiles(Level.ExObjCAInit);
      Level.DecompressExObjectMain[202] = new Level.LoadTiles(Level.ExObjCAMain);
      Level.DecompressExObjectInit[203] = new Level.LoadTiles(Level.ExObjCAInit);
      Level.DecompressExObjectMain[203] = new Level.LoadTiles(Level.ExObjCAMain);
      Level.DecompressExObjectInit[204] = new Level.LoadTiles(Level.ExObjCAInit);
      Level.DecompressExObjectMain[204] = new Level.LoadTiles(Level.ExObjCAMain);
      Level.DecompressExObjectInit[205] = new Level.LoadTiles(Level.ExObjCAInit);
      Level.DecompressExObjectMain[205] = new Level.LoadTiles(Level.ExObjCAMain);
      Level.DecompressExObjectInit[206] = new Level.LoadTiles(Level.ExObjCAInit);
      Level.DecompressExObjectMain[206] = new Level.LoadTiles(Level.ExObjCAMain);
      Level.DecompressExObjectInit[207] = new Level.LoadTiles(Level.ExObjCAInit);
      Level.DecompressExObjectMain[207] = new Level.LoadTiles(Level.ExObjCAMain);
      Level.DecompressExObjectInit[208] = new Level.LoadTiles(Level.ExObjCAInit);
      Level.DecompressExObjectMain[208] = new Level.LoadTiles(Level.ExObjCAMain);
      Level.DecompressExObjectInit[209] = new Level.LoadTiles(Level.ExObjCAInit);
      Level.DecompressExObjectMain[209] = new Level.LoadTiles(Level.ExObjCAMain);
      Level.DecompressExObjectInit[210] = new Level.LoadTiles(Level.ExObjCAInit);
      Level.DecompressExObjectMain[210] = new Level.LoadTiles(Level.ExObjCAMain);
      Level.DecompressExObjectInit[211] = new Level.LoadTiles(Level.ExObjCAInit);
      Level.DecompressExObjectMain[211] = new Level.LoadTiles(Level.ExObjCAMain);
      Level.DecompressExObjectInit[212] = new Level.LoadTiles(Level.ExObjD4Init);
      Level.DecompressExObjectMain[212] = new Level.LoadTiles(Level.ExObjD4Main);
      Level.DecompressExObjectInit[213] = new Level.LoadTiles(Level.ExObjD4Init);
      Level.DecompressExObjectMain[213] = new Level.LoadTiles(Level.ExObjD4Main);
      Level.DecompressExObjectInit[214] = new Level.LoadTiles(Level.ExObjD4Init);
      Level.DecompressExObjectMain[214] = new Level.LoadTiles(Level.ExObjD4Main);
      Level.DecompressExObjectInit[215] = new Level.LoadTiles(Level.ExObjD4Init);
      Level.DecompressExObjectMain[215] = new Level.LoadTiles(Level.ExObjD4Main);
      Level.DecompressExObjectInit[216] = new Level.LoadTiles(Level.ExObjD4Init);
      Level.DecompressExObjectMain[216] = new Level.LoadTiles(Level.ExObjD4Main);
      Level.DecompressExObjectInit[217] = new Level.LoadTiles(Level.ExObjD4Init);
      Level.DecompressExObjectMain[217] = new Level.LoadTiles(Level.ExObjD4Main);
      Level.DecompressExObjectInit[218] = new Level.LoadTiles(Level.ExObjD4Init);
      Level.DecompressExObjectMain[218] = new Level.LoadTiles(Level.ExObjD4Main);
      Level.DecompressExObjectInit[219] = new Level.LoadTiles(Level.ExObjD4Init);
      Level.DecompressExObjectMain[219] = new Level.LoadTiles(Level.ExObjD4Main);
      Level.DecompressExObjectInit[220] = new Level.LoadTiles(Level.ExObjD4Init);
      Level.DecompressExObjectMain[220] = new Level.LoadTiles(Level.ExObjD4Main);
      Level.DecompressExObjectInit[221] = new Level.LoadTiles(Level.ExObjD4Init);
      Level.DecompressExObjectMain[221] = new Level.LoadTiles(Level.ExObjD4Main);
      Level.DecompressExObjectInit[222] = new Level.LoadTiles(Level.ExObjD4Init);
      Level.DecompressExObjectMain[222] = new Level.LoadTiles(Level.ExObjD4Main);
      Level.DecompressExObjectInit[223] = new Level.LoadTiles(Level.ExObjD4Init);
      Level.DecompressExObjectMain[223] = new Level.LoadTiles(Level.ExObjD4Main);
      Level.DecompressExObjectInit[224] = new Level.LoadTiles(Level.ExObjE0Init);
      Level.DecompressExObjectMain[224] = new Level.LoadTiles(Level.ExObjE0Main);
      Level.DecompressExObjectInit[225] = new Level.LoadTiles(Level.ExObjE1Init);
      Level.DecompressExObjectMain[225] = new Level.LoadTiles(Level.ExObjE1Main);
      Level.DecompressExObjectInit[226] = new Level.LoadTiles(Level.ExObjE1Init);
      Level.DecompressExObjectMain[226] = new Level.LoadTiles(Level.ExObjE1Main);
      Level.DecompressExObjectInit[227] = new Level.LoadTiles(Level.ExObjE1Init);
      Level.DecompressExObjectMain[227] = new Level.LoadTiles(Level.ExObjE1Main);
      Level.DecompressExObjectInit[228] = new Level.LoadTiles(Level.ExObjE1Init);
      Level.DecompressExObjectMain[228] = new Level.LoadTiles(Level.ExObjE1Main);
      Level.DecompressExObjectInit[229] = new Level.LoadTiles(Level.ExObjE1Init);
      Level.DecompressExObjectMain[229] = new Level.LoadTiles(Level.ExObjE1Main);
      Level.DecompressExObjectInit[230] = new Level.LoadTiles(Level.ExObjE1Init);
      Level.DecompressExObjectMain[230] = new Level.LoadTiles(Level.ExObjE1Main);
      Level.DecompressExObjectInit[231] = new Level.LoadTiles(Level.ExObjE1Init);
      Level.DecompressExObjectMain[231] = new Level.LoadTiles(Level.ExObjE1Main);
      Level.DecompressExObjectInit[232] = new Level.LoadTiles(Level.ExObjE1Init);
      Level.DecompressExObjectMain[232] = new Level.LoadTiles(Level.ExObjE1Main);
      Level.DecompressExObjectInit[233] = new Level.LoadTiles(Level.ExObjE1Init);
      Level.DecompressExObjectMain[233] = new Level.LoadTiles(Level.ExObjE1Main);
      Level.DecompressExObjectInit[234] = new Level.LoadTiles(Level.ExObjE1Init);
      Level.DecompressExObjectMain[234] = new Level.LoadTiles(Level.ExObjE1Main);
      Level.DecompressExObjectInit[235] = new Level.LoadTiles(Level.ExObjE1Init);
      Level.DecompressExObjectMain[235] = new Level.LoadTiles(Level.ExObjE1Main);
      Level.DecompressExObjectInit[236] = new Level.LoadTiles(Level.ExObjE1Init);
      Level.DecompressExObjectMain[236] = new Level.LoadTiles(Level.ExObjE1Main);
      Level.DecompressExObjectInit[237] = new Level.LoadTiles(Level.ExObjE1Init);
      Level.DecompressExObjectMain[237] = new Level.LoadTiles(Level.ExObjE1Main);
      Level.DecompressExObjectInit[238] = new Level.LoadTiles(Level.ExObjE1Init);
      Level.DecompressExObjectMain[238] = new Level.LoadTiles(Level.ExObjE1Main);
      Level.DecompressExObjectInit[239] = new Level.LoadTiles(Level.ExObjE1Init);
      Level.DecompressExObjectMain[239] = new Level.LoadTiles(Level.ExObjE1Main);
      Level.DecompressExObjectInit[240] = new Level.LoadTiles(Level.ExObjE1Init);
      Level.DecompressExObjectMain[240] = new Level.LoadTiles(Level.ExObjE1Main);
      Level.DecompressExObjectInit[241] = new Level.LoadTiles(Level.ExObjE1Init);
      Level.DecompressExObjectMain[241] = new Level.LoadTiles(Level.ExObjE1Main);
      Level.DecompressExObjectInit[242] = new Level.LoadTiles(Level.ExObjE1Init);
      Level.DecompressExObjectMain[242] = new Level.LoadTiles(Level.ExObjE1Main);
      Level.DecompressExObjectInit[243] = new Level.LoadTiles(Level.ExObjE1Init);
      Level.DecompressExObjectMain[243] = new Level.LoadTiles(Level.ExObjE1Main);
      Level.DecompressExObjectInit[244] = new Level.LoadTiles(Level.ExObjE1Init);
      Level.DecompressExObjectMain[244] = new Level.LoadTiles(Level.ExObjE1Main);
      Level.DecompressExObjectInit[245] = new Level.LoadTiles(Level.ExObjE1Init);
      Level.DecompressExObjectMain[245] = new Level.LoadTiles(Level.ExObjE1Main);
      Level.DecompressExObjectInit[246] = new Level.LoadTiles(Level.ExObjE1Init);
      Level.DecompressExObjectMain[246] = new Level.LoadTiles(Level.ExObjE1Main);
      Level.DecompressExObjectInit[247] = new Level.LoadTiles(Level.ExObjE1Init);
      Level.DecompressExObjectMain[247] = new Level.LoadTiles(Level.ExObjE1Main);
      Level.DecompressExObjectInit[248] = new Level.LoadTiles(Level.ExObjE1Init);
      Level.DecompressExObjectMain[248] = new Level.LoadTiles(Level.ExObjE1Main);
      Level.DecompressExObjectInit[249] = new Level.LoadTiles(Level.ExObjE1Init);
      Level.DecompressExObjectMain[249] = new Level.LoadTiles(Level.ExObjE1Main);
      Level.DecompressExObjectInit[250] = new Level.LoadTiles(Level.ExObjE1Init);
      Level.DecompressExObjectMain[250] = new Level.LoadTiles(Level.ExObjE1Main);
      Level.DecompressExObjectInit[251] = new Level.LoadTiles(Level.ExObjFBInit);
      Level.DecompressExObjectMain[251] = new Level.LoadTiles(Level.ExObjFBMain);
      Level.DecompressExObjectInit[252] = new Level.LoadTiles(Level.ExObjFCInit);
      Level.DecompressExObjectMain[252] = new Level.LoadTiles(Level.ExObjFCMain);
      Level.DecompressExObjectInit[253] = new Level.LoadTiles(Level.ExObjFDInit);
      Level.DecompressExObjectMain[253] = new Level.LoadTiles(Level.ExObjFDMain);
      Level.DecompressExObjectInit[254] = new Level.LoadTiles(Level.ExObjFEInit);
      Level.DecompressExObjectMain[254] = new Level.LoadTiles(Level.ExObjFEMain);
      Level.DecompressExObjectInit[(int) byte.MaxValue] = new Level.LoadTiles(Level.ExObjFFInit);
      Level.DecompressExObjectMain[(int) byte.MaxValue] = new Level.LoadTiles(Level.ExObjFFMain);
      Level.DecompressObjectInit[1] = new Level.LoadTiles(Level.Obj01Init);
      Level.DecompressObjectMain[1] = new Level.LoadTiles(Level.Obj01Main);
      Level.DecompressObjectInit[2] = new Level.LoadTiles(Level.Obj02Init);
      Level.DecompressObjectMain[2] = new Level.LoadTiles(Level.Obj02Main);
      Level.DecompressObjectInit[3] = new Level.LoadTiles(Level.Obj02Init);
      Level.DecompressObjectMain[3] = new Level.LoadTiles(Level.Obj02Main);
      Level.DecompressObjectInit[4] = new Level.LoadTiles(Level.Obj04Init);
      Level.DecompressObjectMain[4] = new Level.LoadTiles(Level.Obj04Main);
      Level.DecompressObjectInit[5] = new Level.LoadTiles(Level.Obj04Init);
      Level.DecompressObjectMain[5] = new Level.LoadTiles(Level.Obj04Main);
      Level.DecompressObjectInit[6] = new Level.LoadTiles(Level.Obj06Init);
      Level.DecompressObjectMain[6] = new Level.LoadTiles(Level.Obj06Main);
      Level.DecompressObjectInit[7] = new Level.LoadTiles(Level.Obj06Init);
      Level.DecompressObjectMain[7] = new Level.LoadTiles(Level.Obj06Main);
      Level.DecompressObjectInit[8] = new Level.LoadTiles(Level.Obj06Init);
      Level.DecompressObjectMain[8] = new Level.LoadTiles(Level.Obj06Main);
      Level.DecompressObjectInit[9] = new Level.LoadTiles(Level.Obj06Init);
      Level.DecompressObjectMain[9] = new Level.LoadTiles(Level.Obj06Main);
      Level.DecompressObjectInit[10] = new Level.LoadTiles(Level.Obj02Init);
      Level.DecompressObjectMain[10] = new Level.LoadTiles(Level.Obj02Main);
      Level.DecompressObjectInit[11] = new Level.LoadTiles(Level.Obj02Init);
      Level.DecompressObjectMain[11] = new Level.LoadTiles(Level.Obj02Main);
      Level.DecompressObjectInit[12] = new Level.LoadTiles(Level.Obj0CInit);
      Level.DecompressObjectMain[12] = new Level.LoadTiles(Level.Obj0CMain);
      Level.DecompressObjectInit[13] = new Level.LoadTiles(Level.Obj0DInit);
      Level.DecompressObjectMain[13] = new Level.LoadTiles(Level.Obj0DMain);
      Level.DecompressObjectInit[14] = new Level.LoadTiles(Level.Obj0CInit);
      Level.DecompressObjectMain[14] = new Level.LoadTiles(Level.Obj0CMain);
      Level.DecompressObjectInit[15] = new Level.LoadTiles(Level.Obj0CInit);
      Level.DecompressObjectMain[15] = new Level.LoadTiles(Level.Obj0CMain);
      Level.DecompressObjectInit[16] = new Level.LoadTiles(Level.Obj10Init);
      Level.DecompressObjectMain[16] = new Level.LoadTiles(Level.Obj10Main);
      Level.DecompressObjectInit[17] = new Level.LoadTiles(Level.Obj11Init);
      Level.DecompressObjectMain[17] = new Level.LoadTiles(Level.Obj11Main);
      Level.DecompressObjectInit[18] = new Level.LoadTiles(Level.Obj11Init);
      Level.DecompressObjectMain[18] = new Level.LoadTiles(Level.Obj11Main);
      Level.DecompressObjectInit[19] = new Level.LoadTiles(Level.Obj13Init);
      Level.DecompressObjectMain[19] = new Level.LoadTiles(Level.Obj13Main);
      Level.DecompressObjectInit[20] = new Level.LoadTiles(Level.Obj14Init);
      Level.DecompressObjectMain[20] = new Level.LoadTiles(Level.Obj14Main);
      Level.DecompressObjectInit[21] = new Level.LoadTiles(Level.Obj15Init);
      Level.DecompressObjectMain[21] = new Level.LoadTiles(Level.Obj15Main);
      Level.DecompressObjectInit[22] = new Level.LoadTiles(Level.Obj16Init);
      Level.DecompressObjectMain[22] = new Level.LoadTiles(Level.Obj16Main);
      Level.DecompressObjectInit[23] = new Level.LoadTiles(Level.Obj17Init);
      Level.DecompressObjectMain[23] = new Level.LoadTiles(Level.Obj17Main);
      Level.DecompressObjectInit[24] = new Level.LoadTiles(Level.Obj18Init);
      Level.DecompressObjectMain[24] = new Level.LoadTiles(Level.Obj18Main);
      Level.DecompressObjectInit[25] = new Level.LoadTiles(Level.Obj19Init);
      Level.DecompressObjectMain[25] = new Level.LoadTiles(Level.Obj19Main);
      Level.DecompressObjectInit[26] = new Level.LoadTiles(Level.Obj1AInit);
      Level.DecompressObjectMain[26] = new Level.LoadTiles(Level.Obj1AMain);
      Level.DecompressObjectInit[27] = new Level.LoadTiles(Level.Obj1BInit);
      Level.DecompressObjectMain[27] = new Level.LoadTiles(Level.Obj1BMain);
      Level.DecompressObjectInit[28] = new Level.LoadTiles(Level.Obj1CInit);
      Level.DecompressObjectMain[28] = new Level.LoadTiles(Level.Obj1CMain);
      Level.DecompressObjectInit[29] = new Level.LoadTiles(Level.Obj1DInit);
      Level.DecompressObjectMain[29] = new Level.LoadTiles(Level.Obj1DMain);
      Level.DecompressObjectInit[30] = new Level.LoadTiles(Level.Obj1DInit);
      Level.DecompressObjectMain[30] = new Level.LoadTiles(Level.Obj1DMain);
      Level.DecompressObjectInit[31] = new Level.LoadTiles(Level.Obj1FInit);
      Level.DecompressObjectMain[31] = new Level.LoadTiles(Level.Obj1FMain);
      Level.DecompressObjectInit[32] = new Level.LoadTiles(Level.Obj20Init);
      Level.DecompressObjectMain[32] = new Level.LoadTiles(Level.Obj20Main);
      Level.DecompressObjectInit[33] = new Level.LoadTiles(Level.Obj21Init);
      Level.DecompressObjectMain[33] = new Level.LoadTiles(Level.Obj21Main);
      Level.DecompressObjectInit[34] = new Level.LoadTiles(Level.Obj22Init);
      Level.DecompressObjectMain[34] = new Level.LoadTiles(Level.Obj22Main);
      Level.DecompressObjectInit[35] = new Level.LoadTiles(Level.Obj23Init);
      Level.DecompressObjectMain[35] = new Level.LoadTiles(Level.Obj23Main);
      Level.DecompressObjectInit[36] = new Level.LoadTiles(Level.Obj24Init);
      Level.DecompressObjectMain[36] = new Level.LoadTiles(Level.Obj24Main);
      Level.DecompressObjectInit[37] = new Level.LoadTiles(Level.Obj25Init);
      Level.DecompressObjectMain[37] = new Level.LoadTiles(Level.Obj25Main);
      Level.DecompressObjectInit[38] = new Level.LoadTiles(Level.Obj25Init);
      Level.DecompressObjectMain[38] = new Level.LoadTiles(Level.Obj25Main);
      Level.DecompressObjectInit[39] = new Level.LoadTiles(Level.Obj27Init);
      Level.DecompressObjectMain[39] = new Level.LoadTiles(Level.Obj27Main);
      Level.DecompressObjectInit[40] = new Level.LoadTiles(Level.Obj27Init);
      Level.DecompressObjectMain[40] = new Level.LoadTiles(Level.Obj28Main);
      Level.DecompressObjectInit[41] = new Level.LoadTiles(Level.Obj29Init);
      Level.DecompressObjectMain[41] = new Level.LoadTiles(Level.Obj29Main);
      Level.DecompressObjectInit[42] = new Level.LoadTiles(Level.Obj29Init);
      Level.DecompressObjectMain[42] = new Level.LoadTiles(Level.Obj29Main);
      Level.DecompressObjectInit[43] = new Level.LoadTiles(Level.Obj2BInit);
      Level.DecompressObjectMain[43] = new Level.LoadTiles(Level.Obj2BMain);
      Level.DecompressObjectInit[44] = new Level.LoadTiles(Level.Obj2CInit);
      Level.DecompressObjectMain[44] = new Level.LoadTiles(Level.Obj2CMain);
      Level.DecompressObjectInit[45] = new Level.LoadTiles(Level.Obj2DInit);
      Level.DecompressObjectMain[45] = new Level.LoadTiles(Level.Obj2DMain);
      Level.DecompressObjectInit[46] = new Level.LoadTiles(Level.Obj2DInit);
      Level.DecompressObjectMain[46] = new Level.LoadTiles(Level.Obj2DMain);
      Level.DecompressObjectInit[47] = new Level.LoadTiles(Level.Obj2FInit);
      Level.DecompressObjectMain[47] = new Level.LoadTiles(Level.Obj2FMain);
      Level.DecompressObjectInit[48] = new Level.LoadTiles(Level.Obj30Init);
      Level.DecompressObjectMain[48] = new Level.LoadTiles(Level.Obj30Main);
      Level.DecompressObjectInit[49] = new Level.LoadTiles(Level.Obj30Init);
      Level.DecompressObjectMain[49] = new Level.LoadTiles(Level.Obj31Main);
      Level.DecompressObjectInit[50] = new Level.LoadTiles(Level.Obj32Init);
      Level.DecompressObjectMain[50] = new Level.LoadTiles(Level.Obj32Main);
      Level.DecompressObjectInit[51] = new Level.LoadTiles(Level.Obj32Init);
      Level.DecompressObjectMain[51] = new Level.LoadTiles(Level.Obj32Main);
      Level.DecompressObjectInit[52] = new Level.LoadTiles(Level.Obj34Init);
      Level.DecompressObjectMain[52] = new Level.LoadTiles(Level.Obj34Main);
      Level.DecompressObjectInit[53] = new Level.LoadTiles(Level.Obj35Init);
      Level.DecompressObjectMain[53] = new Level.LoadTiles(Level.Obj35Main);
      Level.DecompressObjectInit[54] = new Level.LoadTiles(Level.Obj36Init);
      Level.DecompressObjectMain[54] = new Level.LoadTiles(Level.Obj31Main);
      Level.DecompressObjectInit[55] = new Level.LoadTiles(Level.Obj37Init);
      Level.DecompressObjectMain[55] = new Level.LoadTiles(Level.Obj37Main);
      Level.DecompressObjectInit[56] = new Level.LoadTiles(Level.Obj38Init);
      Level.DecompressObjectMain[56] = new Level.LoadTiles(Level.Obj38Main);
      Level.DecompressObjectInit[57] = new Level.LoadTiles(Level.Obj39Init);
      Level.DecompressObjectMain[57] = new Level.LoadTiles(Level.Obj38Main);
      Level.DecompressObjectInit[58] = new Level.LoadTiles(Level.Obj3AInit);
      Level.DecompressObjectMain[58] = new Level.LoadTiles(Level.Obj3AMain);
      Level.DecompressObjectInit[59] = new Level.LoadTiles(Level.Obj3BInit);
      Level.DecompressObjectMain[59] = new Level.LoadTiles(Level.Obj3BMain);
      Level.DecompressObjectInit[60] = new Level.LoadTiles(Level.Obj3CInit);
      Level.DecompressObjectMain[60] = new Level.LoadTiles(Level.Obj3CMain);
      Level.DecompressObjectInit[61] = new Level.LoadTiles(Level.Obj3DInit);
      Level.DecompressObjectMain[61] = new Level.LoadTiles(Level.Obj3DMain);
      Level.DecompressObjectInit[62] = new Level.LoadTiles(Level.Obj3EInit);
      Level.DecompressObjectMain[62] = new Level.LoadTiles(Level.Obj3EMain);
      Level.DecompressObjectInit[63] = new Level.LoadTiles(Level.Obj3FInit);
      Level.DecompressObjectMain[63] = new Level.LoadTiles(Level.Obj3FMain);
      Level.DecompressObjectInit[64] = new Level.LoadTiles(Level.Obj3FInit);
      Level.DecompressObjectMain[64] = new Level.LoadTiles(Level.Obj3FMain);
      Level.DecompressObjectInit[65] = new Level.LoadTiles(Level.Obj41Init);
      Level.DecompressObjectMain[65] = new Level.LoadTiles(Level.Obj41Main);
      Level.DecompressObjectInit[66] = new Level.LoadTiles(Level.Obj42Init);
      Level.DecompressObjectMain[66] = new Level.LoadTiles(Level.Obj42Main);
      Level.DecompressObjectInit[67] = new Level.LoadTiles(Level.Obj42Init);
      Level.DecompressObjectMain[67] = new Level.LoadTiles(Level.Obj42Main);
      Level.DecompressObjectInit[68] = new Level.LoadTiles(Level.Obj44Init);
      Level.DecompressObjectMain[68] = new Level.LoadTiles(Level.Obj44Main);
      Level.DecompressObjectInit[69] = new Level.LoadTiles(Level.Obj45Init);
      Level.DecompressObjectMain[69] = new Level.LoadTiles(Level.Obj45Main);
      Level.DecompressObjectInit[70] = new Level.LoadTiles(Level.Obj45Init);
      Level.DecompressObjectMain[70] = new Level.LoadTiles(Level.Obj45Main);
      Level.DecompressObjectInit[71] = new Level.LoadTiles(Level.Obj47Init);
      Level.DecompressObjectMain[71] = new Level.LoadTiles(Level.Obj47Main);
      Level.DecompressObjectInit[72] = new Level.LoadTiles(Level.Obj48Init);
      Level.DecompressObjectMain[72] = new Level.LoadTiles(Level.Obj48Main);
      Level.DecompressObjectInit[73] = new Level.LoadTiles(Level.Obj49Init);
      Level.DecompressObjectMain[73] = new Level.LoadTiles(Level.Obj49Main);
      Level.DecompressObjectInit[74] = new Level.LoadTiles(Level.Obj49Init);
      Level.DecompressObjectMain[74] = new Level.LoadTiles(Level.Obj49Main);
      Level.DecompressObjectInit[75] = new Level.LoadTiles(Level.Obj4BInit);
      Level.DecompressObjectMain[75] = new Level.LoadTiles(Level.Obj4BMain);
      Level.DecompressObjectInit[76] = new Level.LoadTiles(Level.Obj4BInit);
      Level.DecompressObjectMain[76] = new Level.LoadTiles(Level.Obj4BMain);
      Level.DecompressObjectInit[77] = new Level.LoadTiles(Level.Obj4BInit);
      Level.DecompressObjectMain[77] = new Level.LoadTiles(Level.Obj4BMain);
      Level.DecompressObjectInit[78] = new Level.LoadTiles(Level.Obj4EInit);
      Level.DecompressObjectMain[78] = new Level.LoadTiles(Level.Obj4EMain);
      Level.DecompressObjectInit[79] = new Level.LoadTiles(Level.Obj4FInit);
      Level.DecompressObjectMain[79] = new Level.LoadTiles(Level.Obj4FMain);
      Level.DecompressObjectInit[80] = new Level.LoadTiles(Level.Obj50Init);
      Level.DecompressObjectMain[80] = new Level.LoadTiles(Level.Obj50Main);
      Level.DecompressObjectInit[81] = new Level.LoadTiles(Level.Obj50Init);
      Level.DecompressObjectMain[81] = new Level.LoadTiles(Level.Obj50Main);
      Level.DecompressObjectInit[82] = new Level.LoadTiles(Level.Obj52Init);
      Level.DecompressObjectMain[82] = new Level.LoadTiles(Level.Obj52Main);
      Level.DecompressObjectInit[83] = new Level.LoadTiles(Level.Obj53Init);
      Level.DecompressObjectMain[83] = new Level.LoadTiles(Level.Obj53Main);
      Level.DecompressObjectInit[84] = new Level.LoadTiles(Level.Obj54Init);
      Level.DecompressObjectMain[84] = new Level.LoadTiles(Level.Obj54Main);
      Level.DecompressObjectInit[85] = new Level.LoadTiles(Level.Obj54Init);
      Level.DecompressObjectMain[85] = new Level.LoadTiles(Level.Obj54Main);
      Level.DecompressObjectInit[86] = new Level.LoadTiles(Level.Obj54Init);
      Level.DecompressObjectMain[86] = new Level.LoadTiles(Level.Obj54Main);
      Level.DecompressObjectInit[87] = new Level.LoadTiles(Level.Obj57Init);
      Level.DecompressObjectMain[87] = new Level.LoadTiles(Level.Obj57Main);
      Level.DecompressObjectInit[88] = new Level.LoadTiles(Level.Obj58Init);
      Level.DecompressObjectMain[88] = new Level.LoadTiles(Level.Obj58Main);
      Level.DecompressObjectInit[89] = new Level.LoadTiles(Level.Obj59Init);
      Level.DecompressObjectMain[89] = new Level.LoadTiles(Level.Obj59Main);
      Level.DecompressObjectInit[90] = new Level.LoadTiles(Level.Obj59Init);
      Level.DecompressObjectMain[90] = new Level.LoadTiles(Level.Obj5AMain);
      Level.DecompressObjectInit[91] = new Level.LoadTiles(Level.Obj59Init);
      Level.DecompressObjectMain[91] = new Level.LoadTiles(Level.Obj5BMain);
      Level.DecompressObjectInit[92] = new Level.LoadTiles(Level.Obj5CInit);
      Level.DecompressObjectMain[92] = new Level.LoadTiles(Level.Obj59Main);
      Level.DecompressObjectInit[93] = new Level.LoadTiles(Level.Obj5CInit);
      Level.DecompressObjectMain[93] = new Level.LoadTiles(Level.Obj5AMain);
      Level.DecompressObjectInit[94] = new Level.LoadTiles(Level.Obj5CInit);
      Level.DecompressObjectMain[94] = new Level.LoadTiles(Level.Obj5BMain);
      Level.DecompressObjectInit[95] = new Level.LoadTiles(Level.Obj5FInit);
      Level.DecompressObjectMain[95] = new Level.LoadTiles(Level.Obj5FMain);
      Level.DecompressObjectInit[96] = new Level.LoadTiles(Level.Obj5FInit);
      Level.DecompressObjectMain[96] = new Level.LoadTiles(Level.Obj5FMain);
      Level.DecompressObjectInit[97] = new Level.LoadTiles(Level.Obj61Init);
      Level.DecompressObjectMain[97] = new Level.LoadTiles(Level.Obj61Main);
      Level.DecompressObjectInit[98] = new Level.LoadTiles(Level.Obj61Init);
      Level.DecompressObjectMain[98] = new Level.LoadTiles(Level.Obj61Main);
      Level.DecompressObjectInit[99] = new Level.LoadTiles(Level.Obj63Init);
      Level.DecompressObjectMain[99] = new Level.LoadTiles(Level.Obj63Main);
      Level.DecompressObjectInit[100] = new Level.LoadTiles(Level.Obj63Init);
      Level.DecompressObjectMain[100] = new Level.LoadTiles(Level.Obj63Main);
      Level.DecompressObjectInit[101] = new Level.LoadTiles(Level.Obj63Init);
      Level.DecompressObjectMain[101] = new Level.LoadTiles(Level.Obj63Main);
      Level.DecompressObjectInit[102] = new Level.LoadTiles(Level.Obj66Init);
      Level.DecompressObjectMain[102] = new Level.LoadTiles(Level.Obj66Main);
      Level.DecompressObjectInit[103] = new Level.LoadTiles(Level.Obj67Init);
      Level.DecompressObjectMain[103] = new Level.LoadTiles(Level.Obj67Main);
      Level.DecompressObjectInit[104] = new Level.LoadTiles(Level.Obj68Init);
      Level.DecompressObjectMain[104] = new Level.LoadTiles(Level.Obj68Main);
      Level.DecompressObjectInit[105] = new Level.LoadTiles(Level.Obj69Init);
      Level.DecompressObjectMain[105] = new Level.LoadTiles(Level.Obj69Main);
      Level.DecompressObjectInit[106] = new Level.LoadTiles(Level.Obj6AInit);
      Level.DecompressObjectMain[106] = new Level.LoadTiles(Level.Obj6AMain);
      Level.DecompressObjectInit[107] = new Level.LoadTiles(Level.Obj6BInit);
      Level.DecompressObjectMain[107] = new Level.LoadTiles(Level.Obj6BMain);
      Level.DecompressObjectInit[108] = new Level.LoadTiles(Level.Obj6CInit);
      Level.DecompressObjectMain[108] = new Level.LoadTiles(Level.Obj6CMain);
      Level.DecompressObjectInit[109] = new Level.LoadTiles(Level.Obj6DInit);
      Level.DecompressObjectMain[109] = new Level.LoadTiles(Level.Obj6DMain);
      Level.DecompressObjectInit[110] = new Level.LoadTiles(Level.Obj6EInit);
      Level.DecompressObjectMain[110] = new Level.LoadTiles(Level.Obj6EMain);
      Level.DecompressObjectInit[111] = new Level.LoadTiles(Level.Obj6FInit);
      Level.DecompressObjectMain[111] = new Level.LoadTiles(Level.Obj6FMain);
      Level.DecompressObjectInit[112] = new Level.LoadTiles(Level.Obj70Init);
      Level.DecompressObjectMain[112] = new Level.LoadTiles(Level.Obj70Main);
      Level.DecompressObjectInit[113] = new Level.LoadTiles(Level.Obj70Init);
      Level.DecompressObjectMain[113] = new Level.LoadTiles(Level.Obj70Main);
      Level.DecompressObjectInit[114] = new Level.LoadTiles(Level.Obj70Init);
      Level.DecompressObjectMain[114] = new Level.LoadTiles(Level.Obj70Main);
      Level.DecompressObjectInit[115] = new Level.LoadTiles(Level.Obj73Init);
      Level.DecompressObjectMain[115] = new Level.LoadTiles(Level.Obj73Main);
      Level.DecompressObjectInit[116] = new Level.LoadTiles(Level.Obj74Init);
      Level.DecompressObjectMain[116] = new Level.LoadTiles(Level.Obj74Main);
      Level.DecompressObjectInit[117] = new Level.LoadTiles(Level.Obj75Init);
      Level.DecompressObjectMain[117] = new Level.LoadTiles(Level.Obj75Main);
      Level.DecompressObjectInit[118] = new Level.LoadTiles(Level.Obj76Init);
      Level.DecompressObjectMain[118] = new Level.LoadTiles(Level.Obj76Main);
      Level.DecompressObjectInit[119] = new Level.LoadTiles(Level.Obj77Init);
      Level.DecompressObjectMain[119] = new Level.LoadTiles(Level.Obj77Main);
      Level.DecompressObjectInit[120] = new Level.LoadTiles(Level.Obj78Init);
      Level.DecompressObjectMain[120] = new Level.LoadTiles(Level.Obj78Main);
      Level.DecompressObjectInit[121] = new Level.LoadTiles(Level.Obj78Init);
      Level.DecompressObjectMain[121] = new Level.LoadTiles(Level.Obj78Main);
      Level.DecompressObjectInit[122] = new Level.LoadTiles(Level.Obj7AInit);
      Level.DecompressObjectMain[122] = new Level.LoadTiles(Level.Obj7AMain);
      Level.DecompressObjectInit[123] = new Level.LoadTiles(Level.Obj7BInit);
      Level.DecompressObjectMain[123] = new Level.LoadTiles(Level.Obj7BMain);
      Level.DecompressObjectInit[124] = new Level.LoadTiles(Level.Obj7CInit);
      Level.DecompressObjectMain[124] = new Level.LoadTiles(Level.Obj7CMain);
      Level.DecompressObjectInit[125] = new Level.LoadTiles(Level.Obj7DInit);
      Level.DecompressObjectMain[125] = new Level.LoadTiles(Level.Obj7DMain);
      Level.DecompressObjectInit[126] = new Level.LoadTiles(Level.Obj57Init);
      Level.DecompressObjectMain[126] = new Level.LoadTiles(Level.Obj57Main);
      Level.DecompressObjectInit[(int) sbyte.MaxValue] = new Level.LoadTiles(Level.Obj7FInit);
      Level.DecompressObjectMain[(int) sbyte.MaxValue] = new Level.LoadTiles(Level.Obj7FMain);
      Level.DecompressObjectInit[128] = new Level.LoadTiles(Level.Obj80Init);
      Level.DecompressObjectMain[128] = new Level.LoadTiles(Level.Obj80Main);
      Level.DecompressObjectInit[129] = new Level.LoadTiles(Level.Obj81Init);
      Level.DecompressObjectMain[129] = new Level.LoadTiles(Level.Obj81Main);
      Level.DecompressObjectInit[130] = new Level.LoadTiles(Level.Obj82Init);
      Level.DecompressObjectMain[130] = new Level.LoadTiles(Level.Obj82Main);
      Level.DecompressObjectInit[131] = new Level.LoadTiles(Level.Obj82Init);
      Level.DecompressObjectMain[131] = new Level.LoadTiles(Level.Obj82Main);
      Level.DecompressObjectInit[132] = new Level.LoadTiles(Level.Obj84Init);
      Level.DecompressObjectMain[132] = new Level.LoadTiles(Level.Obj84Main);
      Level.DecompressObjectInit[133] = new Level.LoadTiles(Level.Obj85Init);
      Level.DecompressObjectMain[133] = new Level.LoadTiles(Level.Obj85Main);
      Level.DecompressObjectInit[134] = new Level.LoadTiles(Level.Obj86Init);
      Level.DecompressObjectMain[134] = new Level.LoadTiles(Level.Obj86Main);
      Level.DecompressObjectInit[135] = new Level.LoadTiles(Level.Obj87Init);
      Level.DecompressObjectMain[135] = new Level.LoadTiles(Level.Obj87Main);
      Level.DecompressObjectInit[136] = new Level.LoadTiles(Level.Obj87Init);
      Level.DecompressObjectMain[136] = new Level.LoadTiles(Level.Obj87Main);
      Level.DecompressObjectInit[137] = new Level.LoadTiles(Level.Obj89Init);
      Level.DecompressObjectMain[137] = new Level.LoadTiles(Level.Obj89Main);
      Level.DecompressObjectInit[138] = new Level.LoadTiles(Level.Obj68Init);
      Level.DecompressObjectMain[138] = new Level.LoadTiles(Level.Obj68Main);
      Level.DecompressObjectInit[139] = new Level.LoadTiles(Level.Obj6EInit);
      Level.DecompressObjectMain[139] = new Level.LoadTiles(Level.Obj6EMain);
      Level.DecompressObjectInit[140] = new Level.LoadTiles(Level.Obj8CInit);
      Level.DecompressObjectMain[140] = new Level.LoadTiles(Level.Obj8CMain);
      Level.DecompressObjectInit[141] = new Level.LoadTiles(Level.Obj8DInit);
      Level.DecompressObjectMain[141] = new Level.LoadTiles(Level.Obj8DMain);
      Level.DecompressObjectInit[142] = new Level.LoadTiles(Level.Obj8EInit);
      Level.DecompressObjectMain[142] = new Level.LoadTiles(Level.Obj8EMain);
      Level.DecompressObjectInit[143] = new Level.LoadTiles(Level.Obj8FInit);
      Level.DecompressObjectMain[143] = new Level.LoadTiles(Level.Obj8FMain);
      Level.DecompressObjectInit[144] = new Level.LoadTiles(Level.Obj90Init);
      Level.DecompressObjectMain[144] = new Level.LoadTiles(Level.Obj90Main);
      Level.DecompressObjectInit[145] = new Level.LoadTiles(Level.Obj91Init);
      Level.DecompressObjectMain[145] = new Level.LoadTiles(Level.Obj91Main);
      Level.DecompressObjectInit[146] = new Level.LoadTiles(Level.Obj91Init);
      Level.DecompressObjectMain[146] = new Level.LoadTiles(Level.Obj92Main);
      Level.DecompressObjectInit[147] = new Level.LoadTiles(Level.Obj93Init);
      Level.DecompressObjectMain[147] = new Level.LoadTiles(Level.Obj93Main);
      Level.DecompressObjectInit[148] = new Level.LoadTiles(Level.Obj94Init);
      Level.DecompressObjectMain[148] = new Level.LoadTiles(Level.Obj94Main);
      Level.DecompressObjectInit[149] = new Level.LoadTiles(Level.Obj94Init);
      Level.DecompressObjectMain[149] = new Level.LoadTiles(Level.Obj94Main);
      Level.DecompressObjectInit[150] = new Level.LoadTiles(Level.Obj94Init);
      Level.DecompressObjectMain[150] = new Level.LoadTiles(Level.Obj94Main);
      Level.DecompressObjectInit[151] = new Level.LoadTiles(Level.Obj94Init);
      Level.DecompressObjectMain[151] = new Level.LoadTiles(Level.Obj94Main);
      Level.DecompressObjectInit[152] = new Level.LoadTiles(Level.Obj98Init);
      Level.DecompressObjectMain[152] = new Level.LoadTiles(Level.Obj98Main);
      Level.DecompressObjectInit[153] = new Level.LoadTiles(Level.Obj99Init);
      Level.DecompressObjectMain[153] = new Level.LoadTiles(Level.Obj99Main);
      Level.DecompressObjectInit[154] = new Level.LoadTiles(Level.Obj9AInit);
      Level.DecompressObjectMain[154] = new Level.LoadTiles(Level.Obj9AMain);
      Level.DecompressObjectInit[155] = new Level.LoadTiles(Level.Obj9BInit);
      Level.DecompressObjectMain[155] = new Level.LoadTiles(Level.Obj9BMain);
      Level.DecompressObjectInit[156] = new Level.LoadTiles(Level.Obj9BInit);
      Level.DecompressObjectMain[156] = new Level.LoadTiles(Level.Obj9CMain);
      Level.DecompressObjectInit[157] = new Level.LoadTiles(Level.Obj9DInit);
      Level.DecompressObjectMain[157] = new Level.LoadTiles(Level.Obj9DMain);
      Level.DecompressObjectInit[158] = new Level.LoadTiles(Level.Obj9EInit);
      Level.DecompressObjectMain[158] = new Level.LoadTiles(Level.Obj9EMain);
      Level.DecompressObjectInit[159] = new Level.LoadTiles(Level.Obj9FInit);
      Level.DecompressObjectMain[159] = new Level.LoadTiles(Level.Obj9FMain);
      Level.DecompressObjectInit[160] = new Level.LoadTiles(Level.ObjA0Init);
      Level.DecompressObjectMain[160] = new Level.LoadTiles(Level.ObjA0Main);
      Level.DecompressObjectInit[161] = new Level.LoadTiles(Level.ObjA0Init);
      Level.DecompressObjectMain[161] = new Level.LoadTiles(Level.ObjA0Main);
      Level.DecompressObjectInit[162] = new Level.LoadTiles(Level.ObjA0Init);
      Level.DecompressObjectMain[162] = new Level.LoadTiles(Level.ObjA0Main);
      Level.DecompressObjectInit[163] = new Level.LoadTiles(Level.ObjA3Init);
      Level.DecompressObjectMain[163] = new Level.LoadTiles(Level.ObjA3Main);
      Level.DecompressObjectInit[164] = new Level.LoadTiles(Level.ObjA3Init);
      Level.DecompressObjectMain[164] = new Level.LoadTiles(Level.ObjA3Main);
      Level.DecompressObjectInit[165] = new Level.LoadTiles(Level.ObjA5Init);
      Level.DecompressObjectMain[165] = new Level.LoadTiles(Level.ObjA5Main);
      Level.DecompressObjectInit[166] = new Level.LoadTiles(Level.ObjA5Init);
      Level.DecompressObjectMain[166] = new Level.LoadTiles(Level.ObjA6Main);
      Level.DecompressObjectInit[167] = new Level.LoadTiles(Level.ObjA7Init);
      Level.DecompressObjectMain[167] = new Level.LoadTiles(Level.ObjA7Main);
      Level.DecompressObjectInit[168] = new Level.LoadTiles(Level.ObjA7Init);
      Level.DecompressObjectMain[168] = new Level.LoadTiles(Level.ObjA8Main);
      Level.DecompressObjectInit[169] = new Level.LoadTiles(Level.ObjA9Init);
      Level.DecompressObjectMain[169] = new Level.LoadTiles(Level.ObjA9Main);
      Level.DecompressObjectInit[170] = new Level.LoadTiles(Level.ObjAAInit);
      Level.DecompressObjectMain[170] = new Level.LoadTiles(Level.ObjAAMain);
      Level.DecompressObjectInit[171] = new Level.LoadTiles(Level.ObjAAInit);
      Level.DecompressObjectMain[171] = new Level.LoadTiles(Level.ObjAAMain);
      Level.DecompressObjectInit[172] = new Level.LoadTiles(Level.ObjACInit);
      Level.DecompressObjectMain[172] = new Level.LoadTiles(Level.ObjACMain);
      Level.DecompressObjectInit[173] = new Level.LoadTiles(Level.ObjACInit);
      Level.DecompressObjectMain[173] = new Level.LoadTiles(Level.ObjACMain);
      Level.DecompressObjectInit[174] = new Level.LoadTiles(Level.ObjAEInit);
      Level.DecompressObjectMain[174] = new Level.LoadTiles(Level.ObjAEMain);
      Level.DecompressObjectInit[175] = new Level.LoadTiles(Level.ObjAEInit);
      Level.DecompressObjectMain[175] = new Level.LoadTiles(Level.ObjAEMain);
      Level.DecompressObjectInit[176] = new Level.LoadTiles(Level.ObjB0Init);
      Level.DecompressObjectMain[176] = new Level.LoadTiles(Level.ObjB0Main);
      Level.DecompressObjectInit[177] = new Level.LoadTiles(Level.ObjB1Init);
      Level.DecompressObjectMain[177] = new Level.LoadTiles(Level.ObjB1Main);
      Level.DecompressObjectInit[178] = new Level.LoadTiles(Level.ObjB2Init);
      Level.DecompressObjectMain[178] = new Level.LoadTiles(Level.ObjB2Main);
      Level.DecompressObjectInit[179] = new Level.LoadTiles(Level.ObjB2Init);
      Level.DecompressObjectMain[179] = new Level.LoadTiles(Level.ObjB3Main);
      Level.DecompressObjectInit[180] = new Level.LoadTiles(Level.ObjB4Init);
      Level.DecompressObjectMain[180] = new Level.LoadTiles(Level.ObjB2Main);
      Level.DecompressObjectInit[181] = new Level.LoadTiles(Level.ObjB4Init);
      Level.DecompressObjectMain[181] = new Level.LoadTiles(Level.ObjB5Main);
      Level.DecompressObjectInit[182] = new Level.LoadTiles(Level.ObjB2Init);
      Level.DecompressObjectMain[182] = new Level.LoadTiles(Level.ObjB6Main);
      Level.DecompressObjectInit[183] = new Level.LoadTiles(Level.ObjB2Init);
      Level.DecompressObjectMain[183] = new Level.LoadTiles(Level.ObjB7Main);
      Level.DecompressObjectInit[184] = new Level.LoadTiles(Level.ObjB4Init);
      Level.DecompressObjectMain[184] = new Level.LoadTiles(Level.ObjB6Main);
      Level.DecompressObjectInit[185] = new Level.LoadTiles(Level.ObjB4Init);
      Level.DecompressObjectMain[185] = new Level.LoadTiles(Level.ObjB9Main);
      Level.DecompressObjectInit[186] = new Level.LoadTiles(Level.ObjBAInit);
      Level.DecompressObjectMain[186] = new Level.LoadTiles(Level.ObjBAMain);
      Level.DecompressObjectInit[187] = new Level.LoadTiles(Level.ObjBAInit);
      Level.DecompressObjectMain[187] = new Level.LoadTiles(Level.ObjBBMain);
      Level.DecompressObjectInit[188] = new Level.LoadTiles(Level.ObjBAInit);
      Level.DecompressObjectMain[188] = new Level.LoadTiles(Level.ObjBCMain);
      Level.DecompressObjectInit[189] = new Level.LoadTiles(Level.ObjBAInit);
      Level.DecompressObjectMain[189] = new Level.LoadTiles(Level.ObjBDMain);
      Level.DecompressObjectInit[190] = new Level.LoadTiles(Level.ObjBEInit);
      Level.DecompressObjectMain[190] = new Level.LoadTiles(Level.ObjBEMain);
      Level.DecompressObjectInit[191] = new Level.LoadTiles(Level.ObjBFInit);
      Level.DecompressObjectMain[191] = new Level.LoadTiles(Level.ObjBFMain);
      Level.DecompressObjectInit[192] = new Level.LoadTiles(Level.ObjC0Init);
      Level.DecompressObjectMain[192] = new Level.LoadTiles(Level.ObjC0Main);
      Level.DecompressObjectInit[193] = new Level.LoadTiles(Level.ObjC0Init);
      Level.DecompressObjectMain[193] = new Level.LoadTiles(Level.ObjC1Main);
      Level.DecompressObjectInit[194] = new Level.LoadTiles(Level.ObjC2Init);
      Level.DecompressObjectMain[194] = new Level.LoadTiles(Level.ObjC2Main);
      Level.DecompressObjectInit[195] = new Level.LoadTiles(Level.ObjC2Init);
      Level.DecompressObjectMain[195] = new Level.LoadTiles(Level.ObjC3Main);
      Level.DecompressObjectInit[196] = new Level.LoadTiles(Level.ObjC4Init);
      Level.DecompressObjectMain[196] = new Level.LoadTiles(Level.ObjC4Main);
      Level.DecompressObjectInit[197] = new Level.LoadTiles(Level.ObjC5Init);
      Level.DecompressObjectMain[197] = new Level.LoadTiles(Level.ObjC5Main);
      Level.DecompressObjectInit[198] = new Level.LoadTiles(Level.ObjC6Init);
      Level.DecompressObjectMain[198] = new Level.LoadTiles(Level.ObjC6Main);
      Level.DecompressObjectInit[199] = new Level.LoadTiles(Level.ObjC4Init);
      Level.DecompressObjectMain[199] = new Level.LoadTiles(Level.ObjC4Main);
      Level.DecompressObjectInit[200] = new Level.LoadTiles(Level.ObjC5Init);
      Level.DecompressObjectMain[200] = new Level.LoadTiles(Level.ObjC5Main);
      Level.DecompressObjectInit[201] = new Level.LoadTiles(Level.ObjC6Init);
      Level.DecompressObjectMain[201] = new Level.LoadTiles(Level.ObjC6Main);
      Level.DecompressObjectInit[202] = new Level.LoadTiles(Level.ObjCAInit);
      Level.DecompressObjectMain[202] = new Level.LoadTiles(Level.ObjCAMain);
      Level.DecompressObjectInit[203] = new Level.LoadTiles(Level.ObjCBInit);
      Level.DecompressObjectMain[203] = new Level.LoadTiles(Level.ObjCBMain);
      Level.DecompressObjectInit[204] = new Level.LoadTiles(Level.ObjCCInit);
      Level.DecompressObjectMain[204] = new Level.LoadTiles(Level.ObjCCMain);
      Level.DecompressObjectInit[205] = new Level.LoadTiles(Level.ObjCCInit);
      Level.DecompressObjectMain[205] = new Level.LoadTiles(Level.ObjCDMain);
      Level.DecompressObjectInit[206] = new Level.LoadTiles(Level.ObjCEInit);
      Level.DecompressObjectMain[206] = new Level.LoadTiles(Level.ObjCEMain);
      Level.DecompressObjectInit[207] = new Level.LoadTiles(Level.ObjCFInit);
      Level.DecompressObjectMain[207] = new Level.LoadTiles(Level.ObjCFMain);
      Level.DecompressObjectInit[208] = new Level.LoadTiles(Level.ObjD0Init);
      Level.DecompressObjectMain[208] = new Level.LoadTiles(Level.ObjD0Main);
      Level.DecompressObjectInit[209] = new Level.LoadTiles(Level.ObjD1Init);
      Level.DecompressObjectMain[209] = new Level.LoadTiles(Level.ObjD1Main);
      Level.DecompressObjectInit[210] = new Level.LoadTiles(Level.ObjD2Init);
      Level.DecompressObjectMain[210] = new Level.LoadTiles(Level.ObjD2Main);
      Level.DecompressObjectInit[211] = new Level.LoadTiles(Level.ObjD3Init);
      Level.DecompressObjectMain[211] = new Level.LoadTiles(Level.ObjD3Main);
      Level.DecompressObjectInit[212] = new Level.LoadTiles(Level.ObjD4Init);
      Level.DecompressObjectMain[212] = new Level.LoadTiles(Level.ObjD4Main);
      Level.DecompressObjectInit[213] = new Level.LoadTiles(Level.ObjD4Init);
      Level.DecompressObjectMain[213] = new Level.LoadTiles(Level.ObjD5Main);
      Level.DecompressObjectInit[214] = new Level.LoadTiles(Level.ObjD4Init);
      Level.DecompressObjectMain[214] = new Level.LoadTiles(Level.ObjD6Main);
      Level.DecompressObjectInit[215] = new Level.LoadTiles(Level.ObjD4Init);
      Level.DecompressObjectMain[215] = new Level.LoadTiles(Level.ObjD7Main);
      Level.DecompressObjectInit[216] = new Level.LoadTiles(Level.ObjD8Init);
      Level.DecompressObjectMain[216] = new Level.LoadTiles(Level.ObjD8Main);
      Level.DecompressObjectInit[217] = new Level.LoadTiles(Level.ObjD8Init);
      Level.DecompressObjectMain[217] = new Level.LoadTiles(Level.ObjD8Main);
      Level.DecompressObjectInit[218] = new Level.LoadTiles(Level.ObjDAInit);
      Level.DecompressObjectMain[218] = new Level.LoadTiles(Level.ObjDAMain);
      Level.DecompressObjectInit[219] = new Level.LoadTiles(Level.ObjDBInit);
      Level.DecompressObjectMain[219] = new Level.LoadTiles(Level.ObjDBMain);
      Level.DecompressObjectInit[220] = new Level.LoadTiles(Level.ObjDCInit);
      Level.DecompressObjectMain[220] = new Level.LoadTiles(Level.ObjDCMain);
      Level.DecompressObjectInit[221] = new Level.LoadTiles(Level.ObjDDInit);
      Level.DecompressObjectMain[221] = new Level.LoadTiles(Level.ObjDDMain);
      Level.DecompressObjectInit[222] = new Level.LoadTiles(Level.ObjDEInit);
      Level.DecompressObjectMain[222] = new Level.LoadTiles(Level.ObjDEMain);
      Level.DecompressObjectInit[223] = new Level.LoadTiles(Level.ObjDFInit);
      Level.DecompressObjectMain[223] = new Level.LoadTiles(Level.ObjDFMain);
      Level.DecompressObjectInit[224] = new Level.LoadTiles(Level.ObjE0Init);
      Level.DecompressObjectMain[224] = new Level.LoadTiles(Level.ObjE0Main);
      Level.DecompressObjectInit[225] = new Level.LoadTiles(Level.ObjE1Init);
      Level.DecompressObjectMain[225] = new Level.LoadTiles(Level.ObjE1Main);
      Level.DecompressObjectInit[226] = new Level.LoadTiles(Level.ObjE2Init);
      Level.DecompressObjectMain[226] = new Level.LoadTiles(Level.ObjE2Main);
      Level.DecompressObjectInit[227] = new Level.LoadTiles(Level.ObjE3Init);
      Level.DecompressObjectMain[227] = new Level.LoadTiles(Level.ObjE3Main);
      Level.DecompressObjectInit[228] = new Level.LoadTiles(Level.ObjE4Init);
      Level.DecompressObjectMain[228] = new Level.LoadTiles(Level.ObjE4Main);
      Level.DecompressObjectInit[229] = new Level.LoadTiles(Level.ObjE5Init);
      Level.DecompressObjectMain[229] = new Level.LoadTiles(Level.ObjE5Main);
      Level.DecompressObjectInit[230] = new Level.LoadTiles(Level.ObjE6Init);
      Level.DecompressObjectMain[230] = new Level.LoadTiles(Level.ObjE6Main);
      Level.DecompressObjectInit[231] = new Level.LoadTiles(Level.ObjE7Init);
      Level.DecompressObjectMain[231] = new Level.LoadTiles(Level.ObjE7Main);
      Level.DecompressObjectInit[232] = new Level.LoadTiles(Level.ObjE8Init);
      Level.DecompressObjectMain[232] = new Level.LoadTiles(Level.ObjE8Main);
      Level.DecompressObjectInit[233] = new Level.LoadTiles(Level.ObjE9Init);
      Level.DecompressObjectMain[233] = new Level.LoadTiles(Level.ObjE9Main);
      Level.DecompressObjectInit[234] = new Level.LoadTiles(Level.ObjEAInit);
      Level.DecompressObjectMain[234] = new Level.LoadTiles(Level.ObjEAMain);
      Level.DecompressObjectInit[235] = new Level.LoadTiles(Level.ObjEBInit);
      Level.DecompressObjectMain[235] = new Level.LoadTiles(Level.ObjEBMain);
      Level.DecompressObjectInit[236] = new Level.LoadTiles(Level.ObjEBInit);
      Level.DecompressObjectMain[236] = new Level.LoadTiles(Level.ObjECMain);
      Level.DecompressObjectInit[237] = new Level.LoadTiles(Level.ObjEDInit);
      Level.DecompressObjectMain[237] = new Level.LoadTiles(Level.ObjEDMain);
      Level.DecompressObjectInit[238] = new Level.LoadTiles(Level.ObjEEInit);
      Level.DecompressObjectMain[238] = new Level.LoadTiles(Level.Obj20Main);
      Level.DecompressObjectInit[239] = new Level.LoadTiles(Level.ObjEEInit);
      Level.DecompressObjectMain[239] = new Level.LoadTiles(Level.Obj20Main);
      Level.DecompressObjectInit[240] = new Level.LoadTiles(Level.ObjF0Init);
      Level.DecompressObjectMain[240] = new Level.LoadTiles(Level.Obj20Main);
      Level.DecompressObjectInit[241] = new Level.LoadTiles(Level.ObjF0Init);
      Level.DecompressObjectMain[241] = new Level.LoadTiles(Level.Obj20Main);
      Level.DecompressObjectInit[242] = new Level.LoadTiles(Level.ObjF0Init);
      Level.DecompressObjectMain[242] = new Level.LoadTiles(Level.Obj20Main);
      Level.DecompressObjectInit[243] = new Level.LoadTiles(Level.ObjF0Init);
      Level.DecompressObjectMain[243] = new Level.LoadTiles(Level.Obj20Main);
      Level.DecompressObjectInit[244] = new Level.LoadTiles(Level.Obj3CInit);
      Level.DecompressObjectMain[244] = new Level.LoadTiles(Level.Obj3CMain);
      Level.DecompressObjectInit[245] = new Level.LoadTiles(Level.ObjF5Init);
      Level.DecompressObjectMain[245] = new Level.LoadTiles(Level.ObjF5Main);
      Level.DecompressObjectInit[246] = new Level.LoadTiles(Level.ObjF6Init);
      Level.DecompressObjectMain[246] = new Level.LoadTiles(Level.ObjF6Main);
    }

    public Level(SNES.ROMFile rom)
    {
      this._YI = rom;
    }

    private static Level.LevelTileList rTileList(int x, int y)
    {
      return Level.sTiles[(int) Level._y + y & 112 | (int) (byte) ((uint) Level._x + (uint) x) >> 4][(int) (byte) ((int) Level._y + y << 4) | (int) Level._x + x & 15];
    }

    private static ushort rTile(int x, int y)
    {
      return Level.sTiles[(int) Level._y + y & 112 | (int) (byte) ((uint) Level._x + (uint) x) >> 4][(int) (byte) ((int) Level._y + y << 4) | (int) Level._x + x & 15][0].tile;
    }

    private static ushort rTileGroup(int x, int y)
    {
      return (ushort) ((uint) Level.rTile(x, y) & 65280U);
    }

    private static unsafe ushort RAMu16(int index)
    {
      return *(ushort*) (Level._RAM + index);
    }

    private static unsafe byte ROMu8(int index)
    {
      return Level._ROM[index];
    }

    private static unsafe ushort ROMu16(int index)
    {
      return *(ushort*) (Level._ROM + index);
    }

    private static unsafe void* GetBank12Ptr(int address)
    {
      if ((address & 32768) != 0)
        return (void*) (Level._ROM + (557056 + address));
      else
        return (void*) (Level._RAM + address);
    }

    private static unsafe void* GetBank13Ptr(int address)
    {
      if ((address & 32768) != 0)
        return (void*) (Level._ROM + (589824 + address));
      else
        return (void*) (Level._RAM + address);
    }

    private static void PutTile(ushort tile)
    {
      if ((uint) Level._y >= 128U)
        return;
      Level.tilePlaced = true;
      if (Level.sTiles[(int) Level.HighLoc][(int) Level.LowLoc][0].id != Level._id)
        Level.sTiles[(int) Level.HighLoc][(int) Level.LowLoc].Insert(0, new Level.LevelTile(tile, Level._id, (byte) 0));
      else
        Level.sTiles[(int) Level.HighLoc][(int) Level.LowLoc][0] = new Level.LevelTile(tile, Level._id, (byte) 0);
    }

    private static void PutrTile(int x, int y, ushort tile)
    {
      if ((uint) Level._y + (uint) y >= 128U)
        return;
      if (Level.rTileList(x, y)[0].id != Level._id)
        Level.rTileList(x, y).Insert(0, new Level.LevelTile(tile, Level._id, (byte) 16));
      else
        Level.rTileList(x, y)[0] = new Level.LevelTile(tile, Level._id, (byte) ((uint) Level.rTileList(x, y)[0].state & 16U));
    }

    private static void PutResizableTile(ushort tile)
    {
      if ((uint) Level._y >= 128U)
        return;
      Level.tilePlaced = true;
      int num = 0;
      if (((int) Level.ROMu8((int) Level._obj.num + 591084) & 1) == 0 && (int) (ushort) ((int) Level._h + ((int) (short) Level._maxw >= 0 ? 1 : -1)) == (int) Level._maxw)
        num |= 1 | ((int) (short) Level._maxw < 0 ? 4 : 0);
      if (((int) Level.ROMu8((int) Level._obj.num + 591084) & 3) != 0 && (int) (ushort) ((int) Level._v + ((int) (short) Level._maxh >= 0 ? 1 : -1)) == (int) Level._maxh)
        num |= 2 | ((int) (short) Level._maxh < 0 ? 8 : 0);
      if (Level.sTiles[(int) Level.HighLoc][(int) Level.LowLoc][0].id != Level._id)
        Level.sTiles[(int) Level.HighLoc][(int) Level.LowLoc].Insert(0, new Level.LevelTile(tile, Level._id, (byte) num));
      else
        Level.sTiles[(int) Level.HighLoc][(int) Level.LowLoc][0] = new Level.LevelTile(tile, Level._id, (byte) num);
    }

    private static void PutrResizableTile(int x, int y, ushort tile)
    {
      if ((uint) Level._y + (uint) y >= 128U)
        return;
      if (Level.rTileList(x, y)[0].id != Level._id)
        Level.rTileList(x, y).Insert(0, new Level.LevelTile(tile, Level._id, (byte) 16));
      else if (((int) Level.rTileList(x, y)[0].state & 16) == 0)
      {
        int num = 0;
        if (((int) Level.ROMu8((int) Level._obj.num + 591084) & 1) == 0 && (int) (ushort) ((int) Level._h + ((int) (short) Level._maxw >= 0 ? 1 : -1)) == (int) Level._maxw)
          num |= 1 | ((int) (short) Level._maxw < 0 ? 4 : 0);
        if (((int) Level.ROMu8((int) Level._obj.num + 591084) & 3) != 0 && (int) (ushort) ((int) Level._v + ((int) (short) Level._maxh >= 0 ? 1 : -1)) == (int) Level._maxh)
          num |= 2 | ((int) (short) Level._maxw < 0 ? 8 : 0);
        Level.rTileList(x, y)[0] = new Level.LevelTile(tile, Level._id, (byte) num);
      }
      else
        Level.rTileList(x, y)[0] = new Level.LevelTile(tile, Level._id, (byte) 16);
    }

    private static unsafe ushort LDABank12(ushort index)
    {
      if ((int) (short) index < 0)
        return *(ushort*) (Level._ROM + 557056 + (int) index);
      else
        return Level.RAMu16((int) index);
    }

    private static unsafe ushort LDAyBank12(ushort index, ushort y_reg)
    {
      if ((int) (short) index < 0)
        return *(ushort*) (Level._ROM + 557056 + (int) index + (int) y_reg);
      else
        return Level.RAMu16((int) index + (int) y_reg);
    }

    private static unsafe ushort LDABank13(ushort index)
    {
      if ((int) (short) index < 0)
        return *(ushort*) (Level._ROM + 589824 + (int) index);
      else
        return Level.RAMu16((int) index);
    }

    private static unsafe ushort LDAyBank13(ushort index, ushort y_reg)
    {
      if ((int) (short) index < 0)
        return *(ushort*) (Level._ROM + 589824 + (int) index + (int) y_reg);
      else
        return Level.RAMu16((int) index + (int) y_reg);
    }

    private unsafe void DecodeLevel(int id, bool ShowErrorMsg)
    {
      if (this.Objects.Count == 0)
        return;
      fixed (VariableByte* variableBytePtr1 = this.YI.ROM)
        fixed (VariableByte* variableBytePtr2 = this.RAM)
        {
          Level._ROM = (byte*) variableBytePtr1;
          Level._RAM = (byte*) variableBytePtr2;
          Level._lvltiles = this._levelTiles;
          Level._sheader = this._header;
          Level._random_seed = this.random_seed;
          for (Level._id = id; Level._id < this.Objects.Count; ++Level._id)
          {
            Level._error_msg = ShowErrorMsg;
            Level._obj = this.Objects[Level._id];
            Level._maxw = Level._obj.width;
            Level._maxh = Level._obj.height;
            Level._vflag = Level._vadj = (ushort) 0;
            Level._x = Level._obj.X;
            Level._srcy = Level._obj.Y;
            Level.tilePlaced = false;
            if ((int) Level._obj.num == 0)
            {
              Level._is_command_object = false;
              Level.DecompressExObjectInit[(int) Level._obj.exnum]();
              if (!Level._is_command_object)
              {
                Level._h = (ushort) 0;
                while ((int) Level._h != (int) Level._maxw)
                {
                  Level._y = Level._srcy;
                  Level._v = (ushort) 0;
                  while ((int) Level._v != (int) Level._maxh)
                  {
                    if ((int) Level._y >= 128)
                    {
                      if (Level._error_msg)
                      {
                        int num = (int) MessageBox.Show("Extended Object " + Level._obj.exnum.ToString("X2") + "\nX : " + Level._obj.X.ToString("X2") + "\nY : " + Level._obj.Y.ToString("X2"), "Object Out of Range");
                        Level._error_msg = false;
                      }
                    }
                    else if (this._levelTiles.IsFreshPage(Level.HighLoc))
                      this._levelTiles.ReserveNewPage(Level.HighLoc, Level._id);
                    Level.DecompressExObjectMain[(int) Level._obj.exnum]();
                    Level._v += (int) (short) Level._maxh < 0 ? ushort.MaxValue : (ushort) 1;
                    Level._y += (int) (short) Level._maxh < 0 ? byte.MaxValue : (byte) 1;
                  }
                  if ((int) Level._vflag != 0)
                  {
                    Level._srcy -= (byte) Level._vadj;
                    if ((int) (short) Level._vflag >= 0 && (int) (Level._maxh += Level._vadj) == 0)
                      break;
                  }
                  Level._h += (int) (short) Level._maxw < 0 ? ushort.MaxValue : (ushort) 1;
                  Level._x += (int) (short) Level._maxw < 0 ? byte.MaxValue : (byte) 1;
                }
              }
            }
            else
            {
              Level.DecompressObjectInit[(int) Level._obj.num]();
              Level._h = (ushort) 0;
              while ((int) Level._h != (int) Level._maxw)
              {
                Level._y = Level._srcy;
                Level._v = (ushort) 0;
                while ((int) Level._v != (int) Level._maxh)
                {
                  if ((int) Level._y >= 128)
                  {
                    if (Level._error_msg)
                    {
                      int num = (int) MessageBox.Show("Standard Object " + Level._obj.num.ToString("X2") + "\nX : " + Level._obj.X.ToString("X2") + "\nY : " + Level._obj.Y.ToString("X2"), "Object Out of Range");
                      Level._error_msg = false;
                    }
                  }
                  else if (this._levelTiles.IsFreshPage(Level.HighLoc))
                    this._levelTiles.ReserveNewPage(Level.HighLoc, Level._id);
                  Level.DecompressObjectMain[(int) Level._obj.num]();
                  Level._v += (int) (short) Level._maxh < 0 ? ushort.MaxValue : (ushort) 1;
                  Level._y += (int) (short) Level._maxh < 0 ? byte.MaxValue : (byte) 1;
                }
                if ((int) Level._vflag != 0)
                {
                  Level._srcy -= (byte) Level._vadj;
                  if ((int) (short) Level._vflag >= 0 && (int) (Level._maxh += Level._vadj) == 0)
                    break;
                }
                Level._h += (int) (short) Level._maxw < 0 ? ushort.MaxValue : (ushort) 1;
                Level._x += (int) (short) Level._maxw < 0 ? byte.MaxValue : (byte) 1;
              }
            }
            if (!Level.tilePlaced)
              Level.sCommandTiles[(int) Level._obj.Y * 256 | (int) Level._obj.X].Insert(0, Level._id);
          }
        }
    }

    private static unsafe void ExObj00Init()
    {
      Level._maxw = (ushort) Level.ROMu8(592007 + (int) Level._obj.exnum);
      Level._maxh = (ushort) 3;
      Level._ushortptr = (ushort*) Level.GetBank12Ptr((int) Level.ROMu16(599132 + (int) Level._obj.exnum * 2));
    }

    private static unsafe void ExObj00Main()
    {
      if ((int) (Level._ushort = (Level._ushortptr + (int) Level._v * (int) Level._maxw)[Level._h]) == 0)
        return;
      Level.PutTile(Level._ushort);
    }

    private static unsafe void ExObj0AInit()
    {
      Level._maxw = Level._maxh = (ushort) 2;
      Level._ushortptr = (ushort*) Level.GetBank12Ptr((int) Level.ROMu16(599237 + ((int) Level._obj.exnum & 1) * 2));
    }

    private static unsafe void ExObj0AMain()
    {
      Level.PutTile((Level._ushortptr + (int) Level._v * 2)[Level._h]);
    }

    private static void ExObj0CInit()
    {
      Level._maxw = (ushort) 2;
      Level._maxh = (ushort) 4;
    }

    private static void ExObj0CMain()
    {
      Level.PutTile((ushort) (((int) Level.sTile == 37398 ? 37395 : (int) Level.ROMu16(599268 + (int) Level._v * 2)) + (int) Level._h));
    }

    private static unsafe void ExObj0DInit()
    {
      Level._maxw = (ushort) 8;
      Level._maxh = (ushort) 16;
      Level._byteptr = (byte*) Level.GetBank12Ptr((int) Level.ROMu16(599563 + ((int) Level._obj.exnum & 2)));
    }

    private static unsafe void ExObj0DMain()
    {
      byte num;
      if ((int) (num = Level._byteptr[(int) Level._v << 3 | (int) Level._h]) == 91)
        return;
      if ((int) num < 70)
        Level.PutTile((ushort) ((uint) num + 38532U));
      else if ((int) num < 84)
        Level.PutTile((ushort) ((uint) num + 40262U));
      else
        Level.PutTile((ushort) ((uint) num + 40240U));
    }

    private static void ExObj0FInit()
    {
    }

    private static void ExObj0FMain()
    {
      Level.PutTile((ushort) 182);
    }

    private static void ExObj10Init()
    {
      Level._maxw = (ushort) 16;
      Level._maxh = (ushort) 32;
    }

    private static void ExObj10Main()
    {
      Level.PutTile((ushort) Level.ROMu8((((int) Level._v & 3) << 2 | (int) Level._h & 3) + 599637 + 33986));
    }

    private static void ExObj11Init()
    {
      Level._maxw = (ushort) 2;
    }

    private static void ExObj11Main()
    {
      Level.PutTile((ushort) ((uint) Level._h + 30615U));
    }

    private static unsafe void ExObj12Init()
    {
      Level._maxw = (ushort) 5;
      Level._ushortptr = (ushort*) (Level._ROM + ((int) Level._obj.exnum == 18 ? 599708 : 599736));
    }

    private static unsafe void ExObj12Main()
    {
      Level.PutTile(Level._ushortptr[Level._h]);
    }

    private static unsafe void ExObj14Init()
    {
      Level._maxw = (ushort) 5;
      Level._maxh = (ushort) 2;
      Level._vadj = Level.ROMu16(592195 + ((int) Level._obj.exnum & 1) * 2);
      Level._vflag = ushort.MaxValue;
      Level._ushortptr = (ushort*) (Level._ROM + ((int) Level._obj.exnum == 20 ? 599764 : 599812));
    }

    private static unsafe void ExObj14Main()
    {
      if ((int) (Level._ushortptr + ((int) Level._h << 1))[Level._v] == 0)
        return;
      Level.PutTile((Level._ushortptr + ((int) Level._h << 1))[Level._v]);
    }

    private static void ExObj16Init()
    {
    }

    private static void ExObj16Main()
    {
      Level.PutTile((ushort) ((uint) (byte) Level.sTile | (uint) Level.RAMu16(7672)));
    }

    private static void ExObj17Init()
    {
    }

    private static void ExObj17Main()
    {
      Level.PutTile((ushort) 41984);
    }

    private static void ExObj18Init()
    {
      Level._maxw = Level._maxh = (ushort) 16;
    }

    private static void ExObj18Main()
    {
      Level.PutTile((ushort) ((int) Level.ROMu8(((int) Level._v << 4 | (int) Level._h) + 599897) | ((int) Level._v >= 12 ? 40192 : 42240)));
    }

    private static unsafe void ExObj19Init()
    {
      if ((int) Level._obj.exnum == 25)
      {
        Level._maxw = (ushort) 24;
        Level._maxh = (ushort) 3;
        Level._byteptr = Level._ROM + 600215;
      }
      else
      {
        Level._maxw = (ushort) 32;
        Level._maxh = (ushort) 12;
        Level._byteptr = Level._ROM + 600311;
      }
      Level._ushortptr = (ushort*) (Level._ROM + 600193 - 84);
    }

    private static unsafe void ExObj19Main()
    {
      byte index;
      if ((int) (index = Level._byteptr[(int) Level._v << 5 | (int) Level._h]) == (int) byte.MaxValue)
        return;
      if ((int) index < 42)
        Level.PutTile((ushort) ((uint) index + 40293U));
      else if ((int) index < 53)
        Level.PutTile(Level.RAMu16((int) Level._ushortptr[index]));
      else
        Level.PutTile((ushort) ((int) index - 53 + 42330));
    }

    private static unsafe void ExObj1BInit()
    {
      Level._maxw = Level._maxh = (ushort) 2;
      Level._ushortptr = (ushort*) Level.GetBank12Ptr((int) Level.ROMu16(((int) Level._obj.exnum - 27 << 1) + 600799));
    }

    private static unsafe void ExObj1BMain()
    {
      if ((int) Level._ushortptr[(int) Level._v << 1 | (int) Level._h] == 0)
        return;
      Level.PutTile(Level._ushortptr[(int) Level._v << 1 | (int) Level._h]);
    }

    private static void ExObj1EInit()
    {
      Level._maxw = (ushort) 8;
      Level._maxh = (ushort) 4;
    }

    private static void ExObj1EMain()
    {
      if ((int) Level._h == 0)
        Level.PutTile((ushort) (((int) Level._v << 1) + 40346));
      else if ((int) Level._h + 1 == (int) Level._maxw)
        Level.PutTile((ushort) (((int) Level._v << 1) + 40347));
      else
        Level.PutTile((ushort) 0);
    }

    private static void ExObj1FInit()
    {
      Level._maxw = Level._maxh = (ushort) 4;
    }

    private static void ExObj1FMain()
    {
      Level.PutTile((ushort) ((uint) Level.ROMu8(((int) Level._v << 2 | (int) Level._h) + 600873) | 38400U));
    }

    private static void ExObj20Init()
    {
    }

    private static void ExObj20Main()
    {
    }

    private static unsafe void ExObj30Init()
    {
      Level._maxw = (ushort) 4;
      Level._maxh = (ushort) 2;
      --Level._x;
      Level._ushortptr = (ushort*) (Level._ROM + 600918);
    }

    private static unsafe void ExObj30Main()
    {
      if ((int) Level._h == 0 || (int) Level._h == 3)
      {
        if ((int) Level.sTile != (int) Level.ROMu16(((int) Level._h & 2) + 600928))
          return;
        Level.PutTile(Level._ushortptr[4]);
      }
      else
        Level.PutTile(Level._ushortptr[(int) Level._h - 1 | (int) Level._v << 1]);
    }

    private static unsafe void ExObj31Init()
    {
      Level._maxw = (ushort) 6;
      Level._maxh = (ushort) 7;
      Level._ushortptr = (ushort*) (Level._ROM + 600985);
    }

    private static unsafe void ExObj31Main()
    {
      Level.PutTile((int) Level._h == 0 ? (ushort) 187 : Level._ushortptr[(int) Level._h & 1]);
    }

    private static void ExObj32Init()
    {
    }

    private static void ExObj32Main()
    {
      Level.PutTile(Level.RAMu16((int) Level.ROMu16(601017 + ((int) Level._obj.exnum - 50 << 1))));
    }

    private static void ExObj46Init()
    {
    }

    private static void ExObj46Main()
    {
      Level.PutTile(Level.ROMu16((Level.random2 & 6) + 601079));
    }

    private static unsafe void ExObj47Init()
    {
      Level._srcy -= (byte) 3;
      Level._maxw = Level._maxh = (ushort) 4;
      Level._ushortptr = (ushort*) (Level._ROM + 601145);
    }

    private static unsafe void ExObj47Main()
    {
      ushort index;
      if ((int) (index = (ushort) ((uint) Level._h | (uint) Level._v << 2)) == 0 || (int) index == 3)
        return;
      Level.PutTile(Level._ushortptr[index]);
    }

    private static unsafe void ExObj48Init()
    {
      Level._srcy -= (byte) 19;
      Level._maxw = (ushort) 4;
      Level._maxh = (ushort) 20;
      Level._ushortptr = (ushort*) (Level._ROM + 601269);
    }

    private static unsafe void ExObj48Main()
    {
      if (((int) Level._h & 2) == 0)
      {
        if ((int) Level._v + 1 == (int) Level._maxh)
          Level.PutTile((ushort) 222);
        else if ((int) Level._h != 0 && (int) Level._v < 16 && ((int) Level._v & 1) != 0)
          Level.PutTile((ushort) 229);
        else
          Level.PutTile(Level.sTile);
      }
      else
        Level.PutTile((ushort) ((uint) Level._ushortptr[Level.vindex] + ((uint) Level._h & 1U)));
    }

    private static unsafe void ExObj49Init()
    {
      --Level._x;
      Level._maxw = (ushort) 3;
      Level._ushortptr = (ushort*) (Level._ROM + 601293);
    }

    private static unsafe void ExObj49Main()
    {
      Level.PutTile(Level._ushortptr[Level._h]);
    }

    private static void ExObj4AInit()
    {
    }

    private static void ExObj4AMain()
    {
      Level.PutTile((ushort) 15692);
      if ((int) Level.rTile(-1, 0) != 15675 && (int) Level.rTile(-1, 0) != 15689 && (int) Level.rTile(-1, 0) != 15690)
        return;
      Level.PutrTile(-1, 0, (ushort) 15676);
    }

    private static void ExObj4BInit()
    {
    }

    private static void ExObj4BMain()
    {
      Level.PutTile((ushort) 15681);
      if ((int) Level.rTile(1, 0) != 15675 && (int) Level.rTile(1, 0) != 15676 && (int) Level.rTile(1, 0) != 15689)
        return;
      Level.PutrTile(1, 0, (ushort) 15690);
    }

    private static void ExObj4CInit()
    {
    }

    private static void ExObj4CMain()
    {
      Level.PutTile(Level.RAMu16(7450));
    }

    private static unsafe void ExObj4DInit()
    {
      Level._maxw = Level._maxh = (ushort) 2;
      Level._ushortptr = (ushort*) (Level._ROM + 601399);
    }

    private static unsafe void ExObj4DMain()
    {
      Level.PutTile(Level._ushortptr[(int) Level._v << 1 | (int) Level._h]);
    }

    private static unsafe void ExObj4EInit()
    {
      Level._maxh = (ushort) 2;
      Level._ushortptr = (ushort*) (Level._ROM + 601433);
    }

    private static unsafe void ExObj4EMain()
    {
      Level.PutTile(Level._ushortptr[Level._v]);
    }

    private static void ExObj4FInit()
    {
    }

    private static void ExObj4FMain()
    {
      Level.PutTile((ushort) 330);
    }

    private static void ExObj50Init()
    {
      Level._maxw = Level._maxh = (ushort) 2;
      Level._ushort = (ushort) (((int) Level._obj.exnum & 8) << 1);
    }

    private static void ExObj50Main()
    {
      Level.PutTile((int) Level.sTile == (int) Level.RAMu16(7260) || (int) Level.sTile == (int) Level.RAMu16(7262) || ((int) Level.sTile == (int) Level.RAMu16(7604) || (int) Level.sTile == (int) Level.RAMu16(7606)) ? Level.RAMu16((int) Level.ROMu16(((int) Level._h << 1 | (int) Level._v << 2 | (int) Level._ushort) + 601469)) : ((int) Level._sheader[1] != 4 || (int) Level._v != 0 ? ((int) Level._sheader[1] == 12 ? Level.ROMu16(((int) Level._h << 1 | (int) Level._v << 2) + 601501 + ((int) Level.sTileGroup == 34048 || (int) Level._v == 0 ? 0 : 4)) : Level.ROMu16(((int) Level._h << 1 | (int) Level._v << 2 | (int) Level._ushort) + 601465)) : Level.ROMu16(((int) Level._h << 1 | (int) Level._ushort >> 2) + 601493)));
    }

    private static void ExObj51Init()
    {
    }

    private static void ExObj51Main()
    {
      Level.PutTile((ushort) 387);
    }

    private static unsafe void ExObj52Init()
    {
      Level._maxw = (ushort) 5;
      Level._maxh = (ushort) 2;
      --Level._x;
      Level._ushortptr = (ushort*) (Level._ROM + 601644);
    }

    private static unsafe void ExObj52Main()
    {
      if ((int) Level._h == 0 || (int) Level._h == 4)
      {
        if ((int) Level.sTile != (int) Level.ROMu16(((int) Level._h >> 1) + 600928))
          return;
        Level.PutTile(Level.ROMu16(601658));
      }
      else
        Level.PutTile(Level._ushortptr[(int) Level._h - 1 | (int) Level._v << 2]);
    }

    private static unsafe void ExObj53Init()
    {
      Level._maxw = (ushort) 5;
      Level._maxh = (ushort) 3;
      Level._ushortptr = (ushort*) (Level._ROM + 601714);
    }

    private static unsafe void ExObj53Main()
    {
      if ((int) Level._h == 0 || (int) Level._h == 4)
      {
        if ((int) Level._v == 2 || (int) Level.sTile != (int) Level.ROMu16(((int) Level._h >> 1) + 600928))
          return;
        Level.PutTile((ushort) 348);
      }
      else if ((int) (short) Level._ushortptr[(int) Level._h - 1 | (int) Level._v << 2] < 0)
      {
        if ((int) Level.sTile != 346)
          return;
        Level.PutTile((ushort) 348);
      }
      else
        Level.PutTile(Level._ushortptr[(int) Level._h - 1 | (int) Level._v << 2]);
    }

    private static unsafe void ExObj54Init()
    {
      Level._maxw = Level._maxh = (ushort) 3;
      Level._ushortptr = (ushort*) Level.GetBank12Ptr((int) Level.ROMu16((((int) Level._obj.exnum & 1) << 1) + 601842));
    }

    private static unsafe void ExObj56Init()
    {
      Level._maxw = (ushort) 5;
      Level._maxh = (ushort) 3;
      Level._ushortptr = (ushort*) Level.GetBank12Ptr((int) Level.ROMu16((((int) Level._obj.exnum & 1) << 1) + 601924));
    }

    private static unsafe void ExObj58Init()
    {
      Level._maxw = (ushort) 3;
      Level._maxh = (ushort) 2;
      Level._ushortptr = (ushort*) Level.GetBank12Ptr((int) Level.ROMu16((((int) Level._obj.exnum & 3) << 1) + 601982));
    }

    private static unsafe void ExObj5BInit()
    {
      Level._maxw = (ushort) 3;
      Level._maxh = (ushort) 2;
      Level._ushortptr = (ushort*) Level.GetBank12Ptr((int) Level.ROMu16(((int) Level._obj.exnum - 91 << 1) + 602041));
    }

    private static unsafe void ExObj54Main()
    {
      ushort tile;
      if ((int) (tile = (Level._ushortptr + (int) Level._v * (int) Level._maxw)[Level._h]) == 0)
        return;
      if ((int) tile == 15775)
        Level.PutTile((int) Level.sTile == 15730 ? (ushort) 15785 : tile);
      else if ((int) tile == 15776)
        Level.PutTile((int) Level.sTile == 15729 ? (ushort) 15784 : tile);
      else
        Level.PutTile(tile);
    }

    private static void ExObj5EInit()
    {
    }

    private static void ExObj5EMain()
    {
      Level.PutTile((ushort) 29954);
    }

    private static unsafe void ExObj5FInit()
    {
      Level._maxw = (ushort) 4;
      Level._maxh = (ushort) 2;
      Level._ushortptr = (ushort*) Level.GetBank12Ptr((int) Level.ROMu16(602337));
    }

    private static unsafe void ExObj60Init()
    {
      Level._maxw = (ushort) 5;
      Level._maxh = (ushort) 3;
      Level._ushortptr = (ushort*) Level.GetBank12Ptr((int) Level.ROMu16(602339));
    }

    private static unsafe void ExObj61Init()
    {
      Level._maxw = (ushort) 3;
      Level._maxh = (ushort) 2;
      Level._ushortptr = (ushort*) Level.GetBank12Ptr((int) Level.ROMu16(602341));
    }

    private static unsafe void ExObj62Init()
    {
      Level._maxw = (ushort) 3;
      Level._maxh = (ushort) 2;
      Level._ushortptr = (ushort*) Level.GetBank12Ptr((int) Level.ROMu16(602343));
    }

    private static unsafe void ExObj63Init()
    {
      Level._maxw = (ushort) 5;
      Level._maxh = (ushort) 4;
      Level._ushortptr = (ushort*) Level.GetBank12Ptr((int) Level.ROMu16(602345));
    }

    private static unsafe void ExObj64Init()
    {
      Level._maxw = (ushort) 5;
      Level._maxh = (ushort) 4;
      Level._ushortptr = (ushort*) Level.GetBank12Ptr((int) Level.ROMu16(602347));
    }

    private static unsafe void ExObj65Init()
    {
      Level._maxw = (ushort) 4;
      Level._maxh = (ushort) 3;
      Level._ushortptr = (ushort*) Level.GetBank12Ptr((int) Level.ROMu16(602349));
    }

    private static unsafe void ExObj66Init()
    {
      Level._maxw = (ushort) 2;
      Level._maxh = (ushort) 2;
      Level._ushortptr = (ushort*) Level.GetBank12Ptr((int) Level.ROMu16(602351));
    }

    private static unsafe void ExObj5FMain()
    {
      ushort index;
      if ((int) (index = (Level._ushortptr + Level._h)[(int) Level._v * (int) Level._maxw]) == 0)
        return;
      Level.PutTile(Level.LDABank12(index));
    }

    private static void ExObj67Init()
    {
    }

    private static unsafe void ExObj67Main()
    {
      ushort sTile = Level.sTile;
      Level._byteptr = Level._ROM + 602414;
      int num = 0;
      while (num < 16)
      {
        if ((int) sTile == (int) Level.LDABank12(*(ushort*) (Level._byteptr + num)))
        {
          Level.PutTile(Level.LDABank12(Level.ROMu16(602430 + num)));
          break;
        }
        else
          num += 2;
      }
    }

    private static void ExObj68Init()
    {
    }

    private static void ExObj68Main()
    {
      Level.PutTile(Level.ROMu16(602485 + (((int) Level._obj.exnum & 1) << 1)));
    }

    private static unsafe void ExObj6AInit()
    {
      Level._maxw = (ushort) 3;
      Level._maxh = (ushort) 2;
      Level._ushortptr = (ushort*) (Level._ROM + 602545);
    }

    private static unsafe void ExObj6BInit()
    {
      Level._maxw = (ushort) 4;
      Level._maxh = (ushort) 3;
      Level._ushortptr = (ushort*) (Level._ROM + 602563);
    }

    private static unsafe void ExObj6CInit()
    {
      Level._maxw = (ushort) 5;
      Level._maxh = (ushort) 3;
      Level._ushortptr = (ushort*) (Level._ROM + 602591);
    }

    private static unsafe void ExObj6AMain()
    {
      Level.PutTile((Level._ushortptr + ((int) Level._v << 2))[Level._h]);
    }

    private static unsafe void ExObj6CMain()
    {
      Level.PutTile((Level._ushortptr + (int) Level._v * (int) Level._maxw)[Level._h]);
    }

    private static unsafe void ExObj6DInit()
    {
      Level._maxw = Level._maxh = (ushort) 2;
      Level._ushort = *(ushort*) (Level._ROM + 602642 + ((int) Level._obj.exnum - 109 << 1));
    }

    private static void ExObj6DMain()
    {
      Level.PutTile((ushort) ((uint) Level._ushort + ((uint) Level._v << 1 | (uint) Level._h)));
    }

    private static void ExObj71Init()
    {
      Level._maxw = (ushort) Level.ROMu8(593141 + ((int) Level._obj.exnum & 15));
      Level._maxh = (ushort) Level.ROMu8(593154 + ((int) Level._obj.exnum & 15));
    }

    private static void ExObj71Main()
    {
      Level.PutTile(Level.ROMu16(602672 + ((int) Level._h << 1)));
    }

    private static void ExObj72Main()
    {
      Level.PutTile(Level.ROMu16(602702 + ((int) Level._h << 1)));
    }

    private static void ExObj73Main()
    {
      Level.PutTile(Level.ROMu16(602725 + ((int) Level._v << 1)));
    }

    private static void ExObj74Main()
    {
      Level.PutTile(Level.ROMu16(602748 + ((int) Level._v << 1)));
    }

    private static void ExObj75Main()
    {
      ushort tile;
      if ((int) (tile = Level.ROMu16(602771 + ((int) Level._h << 3 | (int) Level._v << 1))) == 0)
        return;
      Level.PutTile(tile);
    }

    private static void ExObj76Main()
    {
      ushort tile;
      if ((int) (tile = Level.ROMu16(602811 + ((int) Level._h << 3 | (int) Level._v << 1))) == 0)
        return;
      Level.PutTile(tile);
    }

    private static void ExObj77Main()
    {
      ushort tile;
      if ((int) (tile = Level.ROMu16(602844 + ((int) Level._h << 4 | (int) Level._v << 1))) == 0)
        return;
      Level.PutTile(tile);
    }

    private static void ExObj78Main()
    {
      ushort tile;
      if ((int) (tile = Level.ROMu16(602890 + ((int) Level._h << 4 | (int) Level._v << 1))) == 0)
        return;
      Level.PutTile(tile);
    }

    private static void ExObj79Main()
    {
      ushort tile;
      if ((int) (tile = Level.ROMu16(602937 + ((int) Level._h << 2 | (int) Level._v << 1))) == 0)
        return;
      Level.PutTile(tile);
    }

    private static void ExObj7AMain()
    {
      ushort tile;
      if ((int) (tile = Level.ROMu16(602970 + ((int) Level._h << 2 | (int) Level._v << 1))) == 0)
        return;
      Level.PutTile(tile);
    }

    private static void ExObj7BMain()
    {
      ushort tile;
      if ((int) (tile = Level.ROMu16(603003 + ((int) Level._h << 2 | (int) Level._v << 1))) == 0)
        return;
      Level.PutTile(tile);
    }

    private static void ExObj7CMain()
    {
      ushort tile;
      if ((int) (tile = Level.ROMu16(603044 + ((int) Level._h << 2 | (int) Level._v << 1))) == 0)
        return;
      Level.PutTile(tile);
    }

    private static void ExObj7DMain()
    {
      Level.PutTile(Level.ROMu16(603085 + ((int) Level._h << 1)));
    }

    private static void ExObj7EInit()
    {
    }

    private static void ExObj7EMain()
    {
      Level.PutTile(Level.ROMu16(603101 + (((int) Level._obj.exnum & 1) << 1)));
    }

    private static void ExObj80Init()
    {
    }

    private static void ExObj80Main()
    {
      Level.PutTile((ushort) 16);
    }

    private static void ExObj81Init()
    {
      Level._maxw = (ushort) 4;
    }

    private static void ExObj81Main()
    {
      Level.PutTile((ushort) ((uint) Level._h + 28416U));
    }

    private static void ExObj82Init()
    {
      Level._srcy -= (byte) 4;
      Level._maxw = (ushort) 8;
      Level._maxh = (ushort) 5;
    }

    private static void ExObj82Main()
    {
      Level.PutTile(Level.ROMu16(603148 + ((int) Level._h << 1 | (int) Level._v << 4)));
    }

    private static unsafe void ExObj83Init()
    {
      byte num = (byte) ((int) Level._obj.exnum - 131 << 1);
      Level._maxw = Level.ROMu16(593326 + (int) num);
      Level._maxh = Level.ROMu16(593336 + (int) num);
      Level._srcy -= (byte) ((uint) Level.ROMu16((int) num + 593316) >> 4);
      Level._byteptr = (byte*) Level.GetBank12Ptr((int) Level.ROMu16(604399 + (int) num));
    }

    private static unsafe void ExObj83Main()
    {
      byte num = (Level._byteptr + (Level._maxw * (int) Level._v))[(int) Level._h];
      if ((int) num == 0)
        return;
      Level.PutTile((int) num >= 208 ? Level.RAMu16((int) Level.ROMu16(604419 + ((int) num - 208) * 2)) : (ushort) ((int) num - 1 + 33812));
    }

    private static void ExObj88Init()
    {
      Level._maxw = Level._maxh = (ushort) 4;
    }

    private static void ExObj88Main()
    {
      ushort num1;
      byte num2;
      if ((int) Level.rTileGroup(0, 0) == 34048)
      {
        num1 = (ushort) ((uint) Level.sTile - 34123U);
        num2 = (byte) 1;
      }
      else
      {
        num1 = (ushort) ((int) Level.sTile - 30617 & 254);
        num2 = (byte) 0;
      }
      if ((int) Level._v == 0)
      {
        if ((int) num2 == 0)
        {
          if ((int) (Level._ushort = Level.ROMu16(((int) Level._h << 1) + 604600)) != 0)
          {
            if ((int) Level.rTileGroup(0, 0) == 30976)
              Level._ushort = (ushort) 0;
            else
              Level._ushort += Level.ROMu16((int) num1 + 604616);
          }
        }
        else if ((int) (Level._ushort = Level.ROMu16(((int) Level._h << 1) + 604608)) != 0)
          Level._ushort += num1;
      }
      else if ((int) Level._v == 1)
        Level._ushort = (int) num2 != 0 ? (ushort) ((int) Level.ROMu16(((int) Level._h << 1) + 604694) + ((int) Level._h == 0 || (int) Level._h == 3 ? (int) num1 : 0)) : (ushort) ((int) Level.ROMu16(((int) Level._h << 1) + 604686) + ((int) Level._h == 0 || (int) Level._h == 3 ? (int) Level.ROMu16((int) num1 + 604702) : 0));
      else if ((int) Level._v == 2)
        Level._ushort = (int) num2 != 0 ? (ushort) ((int) Level.ROMu16(((int) Level._h << 1) + 604780) + ((int) Level._h == 0 || (int) Level._h == 3 ? (int) num1 : 0)) : (ushort) ((int) Level.ROMu16(((int) Level._h << 1) + 604772) + ((int) Level._h == 0 || (int) Level._h == 3 ? (int) Level.ROMu16((int) num1 + 604702) : 0));
      else if ((int) num2 == 0)
      {
        if ((int) (Level._ushort = Level.ROMu16(((int) Level._h << 1) + 604834)) != 0)
        {
          if ((int) Level.rTileGroup(0, 0) == 30976)
            Level._ushort = (ushort) 0;
          else
            Level._ushort += Level.ROMu16((int) num1 + 604616);
        }
      }
      else if ((int) (Level._ushort = Level.ROMu16(((int) Level._h << 1) + 604842)) != 0)
        Level._ushort += num1;
      if ((int) Level._ushort == 0)
        return;
      Level.PutTile(Level._ushort);
    }

    private static void ExObj89Init()
    {
      Level._ushort = (ushort) (((int) Level._obj.exnum & 7) << 1);
      Level._maxw = Level.ROMu16(593417 + (int) Level._ushort);
      Level._maxh = Level.ROMu16(593425 + (int) Level._ushort);
      Level._ushort = (ushort) (((int) Level._obj.exnum - 1 & 1) << 1);
    }

    private static void ExObj89Main()
    {
      if ((int) Level._obj.exnum <= 138)
      {
        ushort num;
        Level.PutTile((ushort) ((uint) Level.ROMu16((int) Level._ushort + 604901) + (uint) Level._h + (uint) (num = (ushort) ((int) Level.sTile - 30633 & 14))));
        if ((int) num != 0)
          return;
        Level.PutrTile(0, 1, (ushort) ((uint) Level.ROMu16((int) Level._ushort + 604905) + (uint) Level._h));
      }
      else
      {
        ushort num;
        Level.PutTile((ushort) ((uint) Level.ROMu16((int) Level._ushort + 604962) + (uint) Level._v + (uint) (num = (ushort) ((int) Level.sTile - 30617 & 14))));
        if ((int) num != 0)
          return;
        Level.PutrTile(1, 0, (ushort) ((uint) Level.ROMu16((int) Level._ushort + 604966) + (uint) Level._v));
      }
    }

    private static void ExObj8DInit()
    {
    }

    private static void ExObj8DMain()
    {
      ushort num;
      Level.PutTile((ushort) ((uint) (num = (ushort) ((int) Level.sTile - (int) Level.RAMu16(7376) & 1)) + (uint) Level.RAMu16(7438)));
      if ((int) num == 0)
      {
        Level.PutrTile(0, -1, Level.RAMu16(7270));
        Level.PutrTile(-1, 0, (ushort) 0);
        Level.PutrTile(-1, -1, (ushort) 0);
      }
      else
      {
        Level.PutrTile(0, -1, Level.RAMu16(7264));
        Level.PutrTile(1, 0, (ushort) 0);
        Level.PutrTile(1, -1, (ushort) 0);
      }
    }

    private static void ExObj8EInit()
    {
    }

    private static void ExObj8EMain()
    {
      Level.PutTile((ushort) (34576 + ((int) Level._obj.exnum + 2 & 3)));
    }

    private static void ExObj92Init()
    {
      Level._ushort = (ushort) (((int) Level._obj.exnum + 2 & 3) * 2);
      Level._maxw = Level._maxh = (ushort) 2;
    }

    private static void ExObj92Main()
    {
      if ((int) (byte) Level.LDAyBank12(Level.ROMu16(605218 + (int) Level._ushort), (ushort) ((uint) Level._v << 1 | (uint) Level._h)) == 0)
        return;
      Level.PutTile((ushort) (34560U | (uint) (byte) Level.LDAyBank12(Level.ROMu16(605218 + (int) Level._ushort), (ushort) ((uint) Level._v << 1 | (uint) Level._h))));
    }

    private static void ExObj96Init()
    {
      Level._ushort = (ushort) (((int) Level._obj.exnum + 2 & 3) * 2);
      Level._maxw = Level._maxh = (ushort) 8;
    }

    private static void ExObj96Main()
    {
      if ((int) (byte) Level.LDAyBank12(Level.ROMu16(605517 + (int) Level._ushort), (ushort) ((uint) Level._v << 3 | (uint) Level._h)) == 0)
        return;
      Level.PutTile((ushort) (34560U | (uint) (byte) Level.LDAyBank12(Level.ROMu16(605517 + (int) Level._ushort), (ushort) ((uint) Level._v << 3 | (uint) Level._h))));
    }

    private static void ExObj9AInit()
    {
    }

    private static void ExObj9AMain()
    {
      ushort num = (ushort) (((int) Level._obj.exnum - 2 & 3) << 1);
      Level.PutTile(Level.ROMu16(605562 + (int) num));
      if (((int) num & 4) == 0)
        Level.PutrTile(0, -1, Level.ROMu16(605570 + (int) num));
      else
        Level.PutrTile(-1, 0, Level.ROMu16(605570 + (int) num));
    }

    private static void ExObj9EInit()
    {
    }

    private static void ExObj9EMain()
    {
      Level.PutTile((ushort) ((uint) Level.sTile - 34123U + (uint) Level.ROMu16(((int) Level._obj.exnum & 1) * 2 + 605628)));
      Level.PutrTile(0, 1, (ushort) (33028 + ((int) Level._obj.exnum & 1)));
    }

    private static void ExObjA0Init()
    {
      Level._ushort = (ushort) (((int) Level._obj.exnum & 3) * 2);
      Level._maxh = Level._maxw = (ushort) 2;
      Level._x += Level.ROMu8((int) Level._ushort + 593611);
      Level._srcy += (byte) ((uint) Level.ROMu16((int) Level._ushort + 593619) >> 4);
    }

    private static void ExObjA0Main()
    {
      if ((int) Level.rTile(0, -1) == 31042 || (int) Level.rTile(0, -1) == 31043)
        Level.PutrTile(0, -1, (ushort) ((uint) Level.rTile(0, -1) + 3U));
      if ((int) Level.rTile(-1, 0) == 31044 || (int) Level.rTile(-1, 0) == 31051)
        Level.PutrTile(-1, 0, (ushort) ((uint) Level.rTile(-1, 0) + 4U));
      else if ((int) Level.rTile(-1, 0) == 31046 || (int) Level.rTile(-1, 0) == 31053)
        Level.PutrTile(-1, 0, (ushort) ((uint) Level.rTile(-1, 0) + 3U));
      Level.PutTile((ushort) (((int) Level._v << 1 | (int) Level._h) + 31088));
    }

    private static void ExObjA1Main()
    {
      if ((int) Level.rTile(0, 1) == 31048 || (int) Level.rTile(0, 1) == 31049)
        Level.PutrTile(0, 1, (ushort) ((uint) Level.rTile(0, 1) + 3U));
      if ((int) Level.rTile(1, 0) == 31061 || (int) Level.rTile(1, 0) == 31068)
        Level.PutrTile(1, 0, (ushort) ((uint) Level.rTile(1, 0) + 3U));
      else if ((int) Level.rTile(1, 0) == 31063 || (int) Level.rTile(1, 0) == 31070)
        Level.PutrTile(1, 0, (ushort) ((uint) Level.rTile(1, 0) + 2U));
      Level.PutTile((ushort) (((int) Level._v << 1 | (int) Level._h) + 31092));
    }

    private static void ExObjA2Main()
    {
      if ((int) Level.rTile(0, 1) == 31037 || (int) Level.rTile(0, 1) == 31038)
        Level.PutrTile(0, 1, (ushort) ((uint) Level.rTile(0, 1) + 3U));
      if ((int) Level.rTile(-1, 0) == 31074 || (int) Level.rTile(-1, 0) == 31081)
        Level.PutrTile(-1, 0, (ushort) ((uint) Level.rTile(-1, 0) + 4U));
      else if ((int) Level.rTile(-1, 0) == 31076 || (int) Level.rTile(-1, 0) == 31083)
        Level.PutrTile(-1, 0, (ushort) ((uint) Level.rTile(-1, 0) + 3U));
      Level.PutTile((ushort) (((int) Level._v << 1 | (int) Level._h) + 31096));
    }

    private static void ExObjA3Main()
    {
      if ((int) Level.rTile(0, 1) == 31055 || (int) Level.rTile(0, 1) == 31056)
        Level.PutrTile(0, 1, (ushort) ((uint) Level.rTile(0, 1) + 2U));
      if ((int) Level.rTile(1, 0) == 31075 || (int) Level.rTile(1, 0) == 31082)
        Level.PutrTile(1, 0, (ushort) ((uint) Level.rTile(1, 0) + 3U));
      else if ((int) Level.rTile(1, 0) == 31077 || (int) Level.rTile(1, 0) == 31084)
        Level.PutrTile(1, 0, (ushort) ((uint) Level.rTile(1, 0) + 2U));
      Level.PutTile((ushort) (((int) Level._v << 1 | (int) Level._h) + 31100));
    }

    private static void ExObjA4Init()
    {
      Level._maxw = Level._maxh = (ushort) 2;
    }

    private static void ExObjA4Main()
    {
      Level.PutTile((ushort) ((uint) Level.ROMu16(606023 + (int) Level._v * 2) + (uint) Level._h));
    }

    private static void ExObjA5Init()
    {
      Level._ushort = (ushort) (((int) Level._obj.exnum & 1) * 2);
      Level._x -= (byte) Level.ROMu16((int) Level._ushort + 593706);
      Level._srcy -= (byte) ((uint) Level.ROMu16((int) Level._ushort + 593710) >> 4);
      Level._maxw = Level.ROMu16((int) Level._ushort + 593714);
      Level._maxh = Level.ROMu16((int) Level._ushort + 593718);
    }

    private static void ExObjA5Main()
    {
      if ((int) Level.ROMu16(((int) Level._h + (int) Level._v * (int) Level._maxw) * 2 + ((int) Level._ushort != 0 ? 606078 : 606048)) == 0)
        return;
      Level.PutTile(Level.ROMu16(((int) Level._h + (int) Level._v * (int) Level._maxw) * 2 + ((int) Level._ushort != 0 ? 606078 : 606048)));
    }

    private static void ExObjA7Init()
    {
    }

    private static void ExObjA7Main()
    {
      Level.PutTile((ushort) 31132);
    }

    private static unsafe void ExObjA9Init()
    {
      Level._maxh = Level.ROMu16(((int) Level._obj.exnum - 169) * 2 + 593796);
      Level._ushortptr = (ushort*) Level.GetBank12Ptr((int) Level.ROMu16(((int) Level._obj.exnum - 169) * 2 + 606268));
    }

    private static unsafe void ExObjA9Main()
    {
      Level.PutTile((int) Level._v == 0 ? (ushort) 31133 : Level._ushortptr[Level._v]);
    }

    private static unsafe void ExObjADInit()
    {
      byte num = (byte) ((int) Level._obj.exnum - 173 << 1);
      Level._maxw = (ushort) 2;
      Level._maxh = Level.ROMu16((int) num + 593837);
      Level._ushort = Level.ROMu16((Level.random2 & 6) + 593829);
      Level._ushortptr = (ushort*) Level.GetBank12Ptr((int) Level.ROMu16((int) num + 606373));
    }

    private static unsafe void ExObjADMain()
    {
      Level.PutTile((ushort) ((uint) Level._ushortptr[(int) Level._v << 1 | (int) Level._h] + (uint) Level._ushort));
    }

    private static void ExObjB3Init()
    {
    }

    private static void ExObjB3Main()
    {
      Level.PutTile((ushort) 36238);
      Level.PutrTile(1, 0, (ushort) 36239);
    }

    private static unsafe void ExObjB4Init()
    {
      Level._maxw = Level._maxh = (ushort) 2;
      Level._ushortptr = (ushort*) (Level._ROM + ((Level.random2 & 8) + ((int) Level._obj.exnum == 181 ? 606456 : 606440)));
    }

    private static unsafe void ExObjB4Main()
    {
      if ((int) Level._v == 0)
        Level.PutTile(Level.RAMu16((int) Level._ushortptr[Level._h]));
      else
        Level.PutTile((Level._ushortptr + 2)[Level._h]);
    }

    private static unsafe void ExObjB6Init()
    {
      Level._maxw = Level._maxh = (ushort) 3;
      Level._ushortptr = (ushort*) Level.GetBank12Ptr((int) Level.ROMu16((((int) Level._obj.exnum & 1) << 1 | (int) (byte) (Level.random2 & 1) << 1) + 606601));
    }

    private static unsafe void ExObjB6Main()
    {
      if ((int) Level._v != 2)
        Level.PutTile(Level.LDABank12((Level._ushortptr + Level._h)[(int) Level._v * 3]));
      else
        Level.PutTile((Level._ushortptr + Level._h)[6]);
    }

    private static unsafe void ExObjB8Init()
    {
      int num = ((int) Level._obj.exnum & 1) << 1;
      Level._maxw = Level.ROMu16(num + 593974);
      Level._maxh = Level.ROMu16(num + 593978);
      Level._ushortptr = (ushort*) Level.GetBank12Ptr((int) Level.ROMu16(num + 606780));
    }

    private static unsafe void ExObjB8Main()
    {
      ushort num = (Level._ushortptr + Level._h)[(int) Level._v * (int) Level._maxw];
      if ((int) num == 0)
        return;
      if ((int) Level._v + 1 != (int) Level._maxh)
        Level.PutTile(Level.LDABank12(num));
      else
        Level.PutTile(num);
    }

    private static unsafe void ExObjBAInit()
    {
      int num = (int) Level._obj.exnum - 186 << 1;
      Level._maxh = Level.ROMu16(num + 594011);
      Level._ushortptr = (ushort*) Level.GetBank12Ptr((int) Level.ROMu16(num + 606864));
      Level._ushort = (ushort) ((uint) Level.random2 % 3U);
    }

    private static unsafe void ExObjBAMain()
    {
      if ((int) Level._v == 0)
        Level.PutTile((ushort) (((int) Level._obj.exnum >= 189 ? 36165 : 36150) + (int) Level._ushort));
      else
        Level.PutTile((ushort) ((uint) Level._ushortptr[Level._v] + (uint) Level._ushort));
    }

    private static void ExObjC0Init()
    {
      Level._maxw = Level._maxh = (ushort) 2;
    }

    private static void ExObjC0Main()
    {
      if ((int) Level._v == 0)
        Level.PutTile((ushort) (36263U + (uint) Level._h));
      else
        Level.PutTile((ushort) (((int) Level.rTile(0, 1) == 36261 || (int) Level.rTile(0, 1) == 36262 ? 36612 : 5418) + (int) Level._h));
    }

    private static void ExObjC1Init()
    {
      Level._maxw = (ushort) 2;
    }

    private static void ExObjC1Main()
    {
      Level.PutTile((ushort) (36261U + (uint) Level._h));
      if ((int) Level.rTile(0, -1) != 5418 && (int) Level.rTile(0, -1) != 5419)
        return;
      Level.PutrTile(0, -1, (ushort) ((int) Level.rTile(0, -1) - 5418 + 36612));
    }

    private static void ExObjC2Init()
    {
      Level._maxw = Level._maxh = (ushort) 4;
      Level._ushort = (ushort) (((int) Level._obj.exnum & 1) << 5);
    }

    private static void ExObjC2Main()
    {
      Level.PutTile(Level.ROMu16(((int) Level._h << 1 | (int) Level._v << 3 | (int) Level._ushort) + 607029));
    }

    private static void ExObjC4Init()
    {
    }

    private static void ExObjC4Main()
    {
      Level.PutTile((ushort) 24324);
    }

    private static unsafe void ExObjC5Init()
    {
      int num = (int) Level._obj.exnum - 197 << 1;
      Level._maxw = Level.ROMu16(num + 594137);
      Level._maxh = Level.ROMu16(num + 594147);
      Level._byteptr = (byte*) Level.GetBank12Ptr((int) Level.ROMu16(num + 607167));
    }

    private static unsafe void ExObjC5Main()
    {
      if ((int) (Level._byteptr + (Level._v * (int) Level._maxw))[(int) Level._h] == 0)
        return;
      Level.PutTile((ushort) (30976U | (uint) (Level._byteptr + (Level._v * (int) Level._maxw))[(int) Level._h]));
    }

    private static void ExObjCAInit()
    {
    }

    private static void ExObjCAMain()
    {
      Level.PutTile((ushort) ((int) Level._obj.exnum - 202 + 31163));
    }

    private static unsafe void ExObjD4Init()
    {
      int num = (int) Level._obj.exnum - 212;
      Level._maxw = (ushort) Level.ROMu8(num + 594207);
      Level._maxh = (ushort) Level.ROMu8(num + 594219);
      Level._ushortptr = (ushort*) Level.GetBank12Ptr((int) Level.ROMu16(num * 2 + 607832));
    }

    private static unsafe void ExObjD4Main()
    {
      if ((int) (Level._ushortptr + (int) Level._v * (int) Level._maxw)[Level._h] == 0)
        return;
      Level.PutTile((Level._ushortptr + (int) Level._v * (int) Level._maxw)[Level._h]);
      if ((int) Level._v + 1 != (int) Level._maxh)
        return;
      short num = (short) 0;
      while ((int) num < 4)
      {
        if ((int) Level.rTile(0, 1) == (int) Level.ROMu16((int) num + 607880))
        {
          Level.PutrTile(0, 1, Level.ROMu16((int) num + 607884));
          break;
        }
        else
          num += (short) 2;
      }
    }

    private static void ExObjE0Init()
    {
      Level._maxw = Level._maxh = (ushort) 2;
    }

    private static void ExObjE0Main()
    {
      Level.PutTile(Level.ROMu16(607970 + ((int) Level._v << 2 | (int) Level._h << 1)));
    }

    private static void ExObjE1Init()
    {
      Level._is_command_object = true;
    }

    private static void ExObjE1Main()
    {
    }

    private static void ExObjFBInit()
    {
    }

    private static void ExObjFBMain()
    {
    }

    private static void ExObjFCInit()
    {
      Level._is_command_object = true;
    }

    private static void ExObjFCMain()
    {
    }

    private static void ExObjFDInit()
    {
    }

    private static void ExObjFDMain()
    {
      Level.PutTile((ushort) 0);
    }

    private static void ExObjFEInit()
    {
      Level._is_command_object = true;
    }

    private static void ExObjFEMain()
    {
    }

    private static void ExObjFFInit()
    {
      Level._is_command_object = true;
    }

    private static void ExObjFFMain()
    {
    }

    private static void Obj01Init()
    {
      --Level._srcy;
      ++Level._maxh;
    }

    private static void Obj01Main()
    {
      if ((int) Level._v >= 3)
      {
        Level.Obj01MainCode2();
      }
      else
      {
        ushort u = (ushort) ((uint) Level._v << 1);
        if ((int) Level.sTileGroup != (int) Level.RAMu16(7314))
        {
          Level.code138055(ref u);
          Level.PutResizableTile(Level.RAMu16((int) Level.ROMu16((int) u + (((int) Level._h & 1) == 0 ? 622661 : 622669))));
        }
        else
        {
          ushort num;
          if ((int) Level._h == 0)
          {
            if ((int) Level.sTile == (int) Level.RAMu16(7382))
            {
              num = (ushort) 7424;
            }
            else
            {
              Level.code138055(ref u);
              num = Level.ROMu16((int) u + 622756);
            }
          }
          else if ((int) Level.sTile == (int) Level.RAMu16(7380))
          {
            num = (ushort) 7422;
          }
          else
          {
            Level.code138055(ref u);
            num = Level.ROMu16((int) u + 622764);
          }
          Level.PutResizableTile(Level.RAMu16((int) num));
        }
      }
    }

    private static void code138055(ref ushort u)
    {
      if ((int) u != 4 || (int) Level.rTile(0, -1) != (int) Level.RAMu16(7328) && (int) Level.rTile(0, -1) != (int) Level.RAMu16(7330))
        return;
      u += (ushort) 2;
    }

    private static void Obj01MainCode2()
    {
      if ((int) Level.sTile == (int) Level.RAMu16(7412) || (int) Level.sTile == (int) Level.RAMu16(7670) || (int) Level.RAMu16(7380) <= (int) Level.sTile && (int) Level.sTile < (int) Level.RAMu16(7400))
        return;
      if ((int) Level._v + 1 == (int) Level._maxh && ((int) Level.sTile == (int) Level.RAMu16(7350) || (int) Level.sTile == (int) Level.RAMu16(7352)))
      {
        ushort num = (ushort) 7340;
        if ((int) Level.rTile(-1, 0) == (int) Level.RAMu16(7400) || (int) Level.rTile(-1, 0) == (int) Level.RAMu16(7402) || (int) Level.RAMu16(7342) <= (int) Level.rTile(-1, 0) && (int) Level.rTile(-1, 0) < (int) Level.RAMu16(7350))
        {
          Level.PutrResizableTile(0, 1, Level.RAMu16(7362));
          num = (ushort) 7372;
        }
        else if ((int) Level.rTile(1, 0) == (int) Level.RAMu16(7400) || (int) Level.rTile(1, 0) == (int) Level.RAMu16(7402) || (int) Level.RAMu16(7342) <= (int) Level.rTile(1, 0) && (int) Level.rTile(1, 0) < (int) Level.RAMu16(7350))
        {
          Level.PutrResizableTile(0, 1, Level.RAMu16(7364));
          num = (ushort) 7370;
        }
        Level.PutResizableTile(Level.RAMu16((int) num));
      }
      else
      {
        if ((int) Level.rTile(-1, 0) == (int) Level.RAMu16(7340))
        {
          Level.PutrResizableTile(-1, 0, Level.RAMu16(7370));
          Level.PutrResizableTile(0, 1, Level.RAMu16(7364));
        }
        if ((int) Level.rTile(1, 0) == (int) Level.RAMu16(7340))
        {
          Level.PutrResizableTile(1, 0, Level.RAMu16(7372));
          Level.PutrResizableTile(0, 1, Level.RAMu16(7362));
        }
        Level.PutResizableTile(Level.RAMu16((int) Level.ROMu16((Level.random & 14) + 622881)));
      }
    }

    private static void Obj02Init()
    {
      Level._vcount = Level.ROMu16(((int) Level._obj.num << 1) + 594592);
      if ((int) Level._obj.num >= 4)
        return;
      --Level._srcy;
      ++Level._maxw;
      ++Level._maxh;
      if ((int) Level._obj.num == 2)
      {
        --Level._x;
        Level._ushort = Level._maxh;
        Level._maxh = (ushort) 2;
      }
      else
        Level._ushort = (ushort) 2;
    }

    private static void Obj02Main()
    {
      if ((int) Level._v >= (int) Level._vcount)
        Level.Obj02MainCode2((int) Level._obj.num & 1);
      else if ((int) Level._obj.num < 4)
      {
        if ((int) Level._v == 0 && (int) Level._h + 1 == (int) Level._maxw)
          Level._maxh = Level._ushort;
        ushort num1 = (ushort) (((int) Level._obj.num & 1) << 2 | (int) Level._h << 1 | (int) Level._v << 3);
        ushort num2 = Level.ROMu16((int) num1 + 623127);
        if ((int) num2 == 0)
          return;
        if ((int) num1 >= 16 && ((int) Level.sTile == (int) Level.RAMu16(7260) || (int) Level.sTile == (int) Level.RAMu16(7262)))
          num2 = Level.ROMu16((int) num1 + 4 + 623127);
        Level.PutResizableTile(Level.RAMu16((int) num2));
      }
      else
        Level.PutResizableTile(Level.RAMu16((int) Level.ROMu16(((int) Level._obj.num & 1) * 2 + 623660)));
    }

    private static void Obj02MainCode2(int i)
    {
      ushort num = Level.ROMu16((i << 3 | (Level.random & 3) << 1) + 623272);
      if ((int) Level.sTile == (int) Level.RAMu16(7260) || (int) Level.sTile == (int) Level.RAMu16(7262))
      {
        Level.PutResizableTile((ushort) ((uint) Level.RAMu16(7396) + (uint) i));
      }
      else
      {
        if ((int) Level.sTile == (int) Level.RAMu16(7340) || (int) Level.sTile == (int) Level.RAMu16(7350) || (int) Level.sTile == (int) Level.RAMu16(7352))
        {
          if ((int) Level.rTile(0, -1) != (int) Level.RAMu16(7422) && (int) Level.rTile(0, -1) != (int) Level.RAMu16(7424))
            Level.PutrResizableTile(0, -1, (ushort) ((uint) Level.RAMu16(7396) + (uint) i));
          if (((int) Level._obj.num & 1) == 0)
          {
            num = (ushort) 7336;
            if ((int) Level.rTile(1, 0) != (int) Level.RAMu16(7340))
            {
              Level.PutrResizableTile(0, 1, Level.RAMu16(7364));
              num = (ushort) 7330;
            }
          }
          else
          {
            num = (ushort) 7338;
            if ((int) Level.rTile(-1, 0) != (int) Level.RAMu16(7340))
            {
              Level.PutrResizableTile(0, 1, Level.RAMu16(7362));
              num = (ushort) 7328;
            }
          }
        }
        Level.PutResizableTile(Level.RAMu16((int) num));
      }
    }

    private static void Obj04Init()
    {
      --Level._srcy;
      ++Level._maxh;
      Level._vadj = Level.ROMu16((int) (Level._ushort = (ushort) (((int) Level._obj.num & 1) << 1)) + 594616);
      if ((int) Level._ushort == 0)
        return;
      --Level._srcy;
      ++Level._maxh;
    }

    private static void Obj04Main()
    {
      if ((int) Level._v >= 4)
      {
        Level.Obj01MainCode2();
      }
      else
      {
        Level._vflag = (ushort) ((uint) Level._h & 1U);
        Level.PutResizableTile(Level.RAMu16((int) Level.ROMu16(((int) Level._v << 1) + (((int) Level._h & 1) == 0 ? ((int) Level._ushort == 0 ? 623416 : 623424) : ((int) Level._ushort == 0 ? 623445 : 623453)))));
      }
    }

    private static unsafe void Obj06Init()
    {
      --Level._srcy;
      ++Level._maxh;
      if (((int) Level._obj.num & 1) != 0)
      {
        --Level._srcy;
        ++Level._maxh;
      }
      Level._vcount = Level.ROMu16((int) (Level._ushort = (ushort) ((int) Level._obj.num - 4 << 1)) + 594722);
      Level._vadj = Level.ROMu16((int) Level._ushort + 594734);
      Level._vflag = (ushort) 1;
      Level._ushortptr = (ushort*) Level.GetBank13Ptr((int) Level.ROMu16((int) Level._ushort + 623575));
    }

    private static unsafe void Obj06Main()
    {
      if ((int) Level._v >= (int) Level._vcount)
        Level.Obj01MainCode2();
      else
        Level.PutResizableTile(Level.RAMu16((int) Level._ushortptr[Level._v]));
    }

    private static void Obj0CInit()
    {
    }

    private static void Obj0CMain()
    {
      Level.PutResizableTile(Level.LDABank13(Level.ROMu16((((int) Level._obj.num & 3) << 1) + ((int) Level._v == 0 ? 623712 : ((int) Level._v + 1 != (int) Level._maxh ? 623704 : 623720)))));
    }

    private static void Obj0DInit()
    {
    }

    private static void Obj0DMain()
    {
      if ((int) Level.sTileGroup == (int) Level.RAMu16(7290) || (int) Level._h != 0 && (int) Level._h + 1 != (int) Level._maxw)
        Level.PutResizableTile(Level.RAMu16(7292));
      else if ((int) Level._h == 0)
        Level.PutResizableTile(Level.RAMu16((int) Level.sTileGroup == (int) Level.RAMu16(7314) ? 7322 : 7290));
      else
        Level.PutResizableTile(Level.RAMu16((int) Level.sTileGroup == (int) Level.RAMu16(7314) ? 7320 : 7294));
    }

    private static void Obj10Init()
    {
      Level._maxh = (ushort) 2;
      Level._vadj = ushort.MaxValue;
    }

    private static void Obj10Main()
    {
      int num = ((int) Level._h & 1) << 1;
      if ((int) Level._h == 0 || (int) Level._h + ((int) (short) Level._maxw < 0 ? -1 : 1) == (int) Level._maxw)
      {
        if ((int) Level._v != 0)
          return;
        if ((int) Level.sTile == 180 || (int) Level.sTile == 167)
        {
          Level.PutResizableTile((ushort) 167);
          return;
        }
        else
        {
          num |= 8;
          if ((num & 2) == 0)
            goto label_7;
        }
      }
      Level._vflag = Level.ROMu16((num & 2) + 623837);
label_7:
      if ((int) Level.ROMu16((((int) Level._v & 1) << 2 | num) + ((int) (short) Level._maxw >= 0 ? 623809 : 623821)) == 0)
        return;
      Level.PutResizableTile(Level.ROMu16((((int) Level._v & 1) << 2 | num) + ((int) (short) Level._maxw >= 0 ? 623809 : 623821)));
    }

    private static void Obj11Init()
    {
      Level._maxh = Level.ROMu16(((int) Level._obj.num & 2) + 594838);
      Level._vadj = Level.ROMu16(((int) Level._obj.num & 2) + 594842);
    }

    private static void Obj11Main()
    {
      Level._vflag = ushort.MaxValue;
      if ((int) Level._h == 0)
      {
        Level._vflag = (ushort) 0;
        if ((int) Level._v != 0)
          return;
        if ((int) Level.sTile == 180 || (int) Level.sTile == 167)
          Level.PutResizableTile((ushort) 167);
        else
          Level.PutResizableTile(Level.ROMu16(((int) (short) Level._maxw < 0 ? 2 : 0) + 623817));
      }
      else if ((int) Level._h + ((int) (short) Level._maxw < 0 ? -1 : 1) != (int) Level._maxw)
      {
        Level.PutResizableTile(Level.ROMu16((((int) (short) Level._maxw < 0 ? 2 : 0) | (((int) Level._obj.num & 2) << 2) + ((int) Level._v << 2)) + 624063));
      }
      else
      {
        if ((int) Level._v != 0)
          return;
        if ((int) Level.sTile == 180 || (int) Level.sTile == 167)
          Level.PutResizableTile((ushort) 167);
        else
          Level.PutResizableTile(Level.ROMu16(((int) (short) Level._maxw < 0 ? 2 : 0) + 623829));
      }
    }

    private static void Obj13Init()
    {
    }

    private static void Obj13Main()
    {
      if ((int) Level.sTile == 180 || (int) Level.sTile == 167)
        Level.PutResizableTile((ushort) 167);
      else
        Level.PutResizableTile((int) Level._h == 0 ? (ushort) 147 : ((int) Level._h + 1 != (int) Level._maxw ? (ushort) 166 : (ushort) 146));
    }

    private static void Obj14Init()
    {
    }

    private static void Obj14Main()
    {
      ushort u = (int) Level.sTileGroup == (int) Level.RAMu16(7136) ? (ushort) ((int) (byte) Level.sTile + 1 << 1) : (ushort) 0;
      if ((int) Level._maxw == 1)
      {
        Level.code138712(ref u);
        Level.PutResizableTile(Level.LDABank13(Level.ROMu16((int) u + ((int) Level._v == 0 ? 624610 : ((int) Level._v + 1 != (int) Level._maxh ? 624516 : 624704)))));
      }
      else if ((int) Level._maxh == 1)
      {
        if ((int) Level._h == 0 || (int) Level._h + 1 == (int) Level._maxw)
          Level.code138712(ref u);
        Level.PutResizableTile(Level.LDABank13(Level.ROMu16((int) u + ((int) Level._h == 0 ? 624892 : ((int) Level._h + 1 != (int) Level._maxw ? 624798 : 624986)))));
      }
      else
      {
        if ((int) Level._h == 0 || (int) Level._h + 1 == (int) Level._maxw || ((int) Level._v == 0 || (int) Level._v + 1 == (int) Level._maxh))
          Level.code138712(ref u);
        if ((int) Level._h == 0)
        {
          if ((int) Level._v == 0)
          {
            Level.code13873E((ushort) 0);
            Level.PutResizableTile(Level.LDABank13(Level.ROMu16((int) u + 625080)));
          }
          else if ((int) Level._v + 1 != (int) Level._maxh)
            Level.PutResizableTile(Level.LDABank13(Level.ROMu16((int) u + 625174)));
          else
            Level.PutResizableTile(Level.LDABank13(Level.ROMu16((int) u + 625268)));
        }
        else if ((int) Level._h + 1 != (int) Level._maxw)
        {
          if ((int) Level._v == 0)
          {
            Level.code13873E((ushort) 2);
            Level.PutResizableTile(Level.LDABank13(Level.ROMu16((int) u + 625362)));
          }
          else if ((int) Level._v + 1 != (int) Level._maxh)
            Level.PutResizableTile(Level.RAMu16(7172));
          else
            Level.PutResizableTile(Level.LDABank13(Level.ROMu16((int) u + 625456)));
        }
        else if ((int) Level._v == 0)
        {
          Level.code13873E((ushort) 4);
          Level.PutResizableTile(Level.LDABank13(Level.ROMu16((int) u + 625550)));
        }
        else if ((int) Level._v + 1 != (int) Level._maxh)
          Level.PutResizableTile(Level.LDABank13(Level.ROMu16((int) u + 625644)));
        else
          Level.PutResizableTile(Level.LDABank13(Level.ROMu16((int) u + 625738)));
      }
    }

    private static void code138712(ref ushort u)
    {
      if ((int) Level.sTileGroup == (int) Level.RAMu16(7136))
        return;
      u = (ushort) 0;
      int num = 0;
      while (num < 36)
      {
        if ((int) Level.sTile == (int) Level.RAMu16((int) Level.ROMu16(num + 624480)))
        {
          u = (ushort) (num + 40);
          break;
        }
        else
          num += 2;
      }
    }

    private static void code13873E(ushort u)
    {
      if ((int) Level.rTile(0, -1) != (int) Level.RAMu16(7260) && (int) Level.rTile(0, -1) != (int) Level.RAMu16(7262))
        return;
      Level.PutrResizableTile(0, -1, Level.ROMu16((int) u + 624472));
    }

    private static void Obj15Init()
    {
      Level._maxh = (ushort) 2;
    }

    private static void Obj15Main()
    {
      Level.PutResizableTile(Level.ROMu16((Level.hindex | (int) Level._v << 3) + 625832));
    }

    private static void Obj16Init()
    {
    }

    private static void Obj16Main()
    {
      if ((int) Level.sTile != 0)
        return;
      Level.PutResizableTile((ushort) 5632);
    }

    private static void Obj17Init()
    {
      ++Level._maxh;
      --Level._srcy;
    }

    private static void Obj17Main()
    {
      int num1 = (int) Level.sTile == 5632 ? 8 : 0;
      int num2;
      if ((int) Level._v == 0)
      {
        if (num1 != 0)
          return;
        num2 = 0;
      }
      else if ((int) Level._v + 1 != (int) Level._maxh)
      {
        if ((int) Level._v == 1)
        {
          if (num1 == 0)
          {
            num2 = 2;
          }
          else
          {
            Level.PutResizableTile(Level.ROMu16((Level.hindex | num1) + 626009));
            return;
          }
        }
        else
        {
          Level.PutResizableTile(Level.ROMu16((Level.hindex | num1) + 626015));
          return;
        }
      }
      else
      {
        Level.PutResizableTile(Level.ROMu16((Level.hindex | num1) + 626029));
        return;
      }
      Level.PutResizableTile((ushort) (((uint) Level._h & 1U) + (uint) Level.ROMu16(num2 + 626143)));
      if ((int) Level._v == 0 && (int) Level.rTileGroup(0, 1) == 5632)
        return;
      if ((int) Level._h == 0 && (int) Level.rTile(-1, 0) == 0)
        Level.PutrResizableTile(-1, 0, Level.ROMu16(num2 + 626147));
      if ((int) Level._h + 1 != (int) Level._maxw || (int) Level.rTile(1, 0) != 0)
        return;
      Level.PutrResizableTile(1, 0, Level.ROMu16(num2 + 626151));
    }

    private static void Obj18Init()
    {
    }

    private static void Obj18Main()
    {
      Level.PutResizableTile(Level.ROMu16(Level.vindex * 3 + Level.hindex + ((int) Level.sTileGroup == 5632 ? 18 : 0) + 626222));
    }

    private static void Obj19Init()
    {
    }

    private static void Obj19Main()
    {
      if ((int) Level._v < 3)
        Level.PutResizableTile(Level.ROMu16(((int) Level._v << 3 | ((int) Level._h & 3) << 1) + 626320));
      else
        Level.PutResizableTile(Level.ROMu16(((((int) Level._v ^ 1) & 1) << 3 | ((int) Level._h & 3) << 1) + 626344));
    }

    private static void Obj1AInit()
    {
    }

    private static void Obj1AMain()
    {
      if ((int) Level._h == 0)
        Level.PutResizableTile((ushort) 5381);
      else if ((int) Level._h + 1 != (int) Level._maxw)
        Level.PutResizableTile((int) Level.sTile == 25 ? (ushort) 5385 : (ushort) (((int) Level._h & 1) + 5377));
      else
        Level.PutResizableTile((ushort) 5382);
    }

    private static void Obj1BInit()
    {
    }

    private static void Obj1BMain()
    {
      Level.PutResizableTile(Level.ROMu16((((int) Level.sTile == 5377 || (int) Level.sTile == 5378 ? 12 : ((int) Level.sTileGroup == 5632 ? 6 : 0)) | Level.vindex) + 626484));
    }

    private static void Obj1CInit()
    {
      Level._maxw = (ushort) 2;
    }

    private static void Obj1CMain()
    {
      Level.PutResizableTile(Level.ROMu16((((int) Level._h | Level.vindex) << 1) + 626539));
    }

    private static void Obj1DInit()
    {
    }

    private static void Obj1DMain()
    {
      Level.PutResizableTile(Level.ROMu16(((int) Level._obj.num & 2) + 626571));
    }

    private static void Obj1FInit()
    {
    }

    private static void Obj1FMain()
    {
      if ((int) Level._v >= 5)
        Level.PutResizableTile((ushort) 32260);
      else
        Level.PutResizableTile(Level.ROMu16(((int) Level._v << 1) + (((int) Level._h & 1) == 0 ? 626605 : 626615)));
    }

    private static void Obj20Init()
    {
      Level._byte = (byte) (((int) Level._srcy ^ (int) Level._x) & 1);
      Level._ushort = (ushort) 0;
    }

    private static void Obj20Main()
    {
      ushort tile;
      if ((int) Level._v < 3)
      {
        tile = (ushort) ((uint) Level.ROMu16(654327 + ((int) Level._v << 1)) + (uint) Level._byte);
        if ((int) Level._h == 0)
        {
          if ((int) Level._ushort == 32768)
            tile = (ushort) ((uint) Level.ROMu16(654339 + ((int) Level._v << 1)) + (uint) Level._byte);
          else if ((int) Level._byte != 0)
            tile = Level.ROMu16(654333 + ((int) Level._v << 1));
        }
        else if ((int) Level._h + 1 != (int) Level._maxw)
        {
          if ((int) Level._ushort == 32768)
            tile = (ushort) ((uint) Level.ROMu16(654339 + ((int) Level._v << 1)) + (uint) Level._byte);
        }
        else
          tile = (int) Level.rTile(-1, 0) == 41 || (int) Level.rTile(-1, 0) == 45 || ((int) Level.rTile(-1, 0) == 257 || (int) Level.rTile(-1, 0) == 266) || ((int) Level.rTile(-1, 0) == 260 || (int) Level.rTile(-1, 0) == 261) ? Level.ROMu16(((int) Level._ushort == 32768 ? 654345 : 654333) + ((int) Level._v << 1)) : (ushort) ((uint) Level.rTile(-1, 0) + 1U);
      }
      else
      {
        tile = (ushort) ((((int) Level._v ^ (int) Level._byte) & 1) + 264);
        if ((int) Level._h == 0 && (int) tile == 265 && (int) Level.rTile(-1, 0) != 264 || (int) Level._h + 1 == (int) Level._maxw && (int) tile == 264 && (int) Level.rTile(1, 0) != 265)
          tile = (ushort) 262;
        if ((int) Level._ushort != 0)
        {
          if ((int) tile == 262)
          {
            int num;
            tile = Level.ROMu16(((num = (int) Level._v - 3) < 6 ? num & 6 : (Level.random & 2) + 4) + 654500);
          }
          else if ((int) tile == 265 || (int) tile == 31203 || (int) tile == 31206)
          {
            tile = (ushort) ((int) Level.rTile(-1, 0) + ((int) Level.rTile(-1, 0) == 0 || (int) Level.rTile(-1, 0) == 31207 ? 0 : 1));
          }
          else
          {
            int num;
            if ((num = (Level.random & 3) + (int) Level._v << 1) >= 22)
              num = (Level.random & 2) + 18;
            tile = Level.ROMu16(num + 654478);
          }
          if ((int) (short) Level._ushort >= 0 && ((int) tile & 65280) != 30464 && ((int) tile != 0 && (int) tile != 262))
          {
            int num;
            tile = (num = (int) tile == 264 ? 0 : ((int) tile == 265 ? 2 : ((int) tile == 31207 ? 4 : -1))) == -1 ? (ushort) ((int) tile - 31201 + 30604) : Level.ROMu16(num + 654610);
          }
        }
      }
      if ((int) Level._v + 1 == (int) Level._maxh)
        Level._byte ^= (byte) 1;
      Level.PutResizableTile(tile);
    }

    private static void Obj21Init()
    {
      Level._ushort = (ushort) 0;
    }

    private static void Obj21Main()
    {
      if ((int) Level._v < 3)
      {
        int num1 = (int) Level._v << 1;
        if (num1 == 0)
          Level._ushort = (ushort) (Level.random & 3);
        if ((int) Level._v == 0)
        {
          if (((int) Level.sTileGroup == 37888 || (int) Level.sTileGroup == 38144) && ((int) Level._h == 0 || (int) Level._h + 1 == (int) Level._maxw))
          {
            Level.PutrResizableTile(0, 1, Level.ROMu16(((int) Level._h != 0 ? 2 : 0) + 626919));
            byte num2 = Level._y;
            Level._y = (byte) ((int) Level._y & 240 | (int) Level._y + 1 & 15);
            Level.PutrResizableTile(0, 1, Level.ROMu16(((int) Level._h != 0 ? 2 : 0) + 626923));
            Level._y = num2;
            Level.PutResizableTile(Level.ROMu16(((int) Level._h != 0 ? 2 : 0) + 626915));
            return;
          }
        }
        else if ((int) Level._v == 1 && ((int) Level.sTileGroup == 37888 || (int) Level.sTileGroup == 38144))
        {
          if ((int) Level._h == 0 || (int) Level._h + 1 == (int) Level._maxw)
          {
            Level.PutrResizableTile(0, -1, Level.ROMu16(((int) Level._h != 0 ? 2 : 0) + 626787));
            Level.PutrResizableTile(0, 1, Level.ROMu16(((int) Level._h != 0 ? 2 : 0) + 626791));
            Level.PutrResizableTile((int) Level._h == 0 ? -1 : 1, 0, Level.ROMu16(((int) Level._h != 0 ? 2 : 0) + 626795));
            Level.PutResizableTile(Level.ROMu16(((int) Level.sTile >= 38144 ? 2 : 0) + 626783));
            return;
          }
          else
          {
            Level.PutResizableTile((ushort) 0);
            return;
          }
        }
        int num3 = 0;
        while (num3 < 12)
        {
          if ((int) Level.sTile == (int) Level.ROMu16(num3 + 626639))
            return;
          num3 += 2;
        }
        Level.PutResizableTile((ushort) ((uint) Level.ROMu16(num1 + 626651) + (uint) Level._ushort));
      }
      else
        Level.PutResizableTile(Level.ROMu16((Level.random + (int) Level._v & 30) + 626657));
    }

    private static void Obj22Init()
    {
      ++Level._maxw;
    }

    private static void Obj22Main()
    {
      if ((int) Level._h == 0)
      {
        if ((int) Level._v != 1)
          return;
        Level.PutResizableTile((ushort) 38477);
      }
      else if ((int) Level._v < 3)
      {
        Level.PutResizableTile(Level.ROMu16(((int) Level._v << 1) + 627033));
      }
      else
      {
        ushort tile = (ushort) ((Level.random & 1) + 37022);
        ushort u;
        Level.code1391F9(out u);
        if ((int) (short) u >= 0)
          tile = Level.ROMu16((int) u + 627039);
        Level.PutResizableTile(tile);
      }
    }

    private static void code1391F9(out ushort u)
    {
      u = 37376 > (int) Level.sTile || (int) Level.sTile >= 37380 ? (36992 > (int) Level.sTile || (int) Level.sTile >= 36996 ? (37008 > (int) Level.sTile || (int) Level.sTile >= 37012 ? ushort.MaxValue : (ushort) 4) : (ushort) 2) : (ushort) 0;
    }

    private static void Obj23Init()
    {
      ++Level._maxw;
    }

    private static void Obj23Main()
    {
      if ((int) Level._h != 0)
      {
        if ((int) Level._v != 1)
          return;
        Level.PutResizableTile((ushort) 38478);
      }
      else if ((int) Level._v < 3)
      {
        Level.PutResizableTile(Level.ROMu16(((int) Level._v << 1) + 627112));
      }
      else
      {
        ushort tile = (ushort) ((Level.random & 1) + 36962);
        ushort u;
        Level.code1391F9(out u);
        if ((int) (short) u >= 0)
          tile = Level.ROMu16((int) u + 627118);
        Level.PutResizableTile(tile);
      }
    }

    private static void Obj24Init()
    {
    }

    private static void Obj24Main()
    {
      if ((int) Level._v >= 2)
        Level.PutResizableTile(Level.ROMu16((Level.random + (int) Level._v & 30) + 626657));
      else
        Level.PutResizableTile((ushort) ((uint) Level.ROMu16(((int) Level._v << 1) + 627236) + (uint) (Level.random & 3)));
    }

    private static void Obj25Init()
    {
      Level._byte = (byte) ((uint) Level._obj.num & 2U);
    }

    private static void Obj25Main()
    {
      if ((int) Level._v != 0)
      {
        if ((int) Level._byte == 0)
        {
          ushort tile = (ushort) ((Level.random & 1) + 37022);
          ushort u;
          Level.code1391F9(out u);
          if ((int) (short) u >= 0)
            tile = Level.ROMu16((int) u + 627039);
          Level.PutResizableTile(tile);
        }
        else
        {
          ushort tile = (ushort) ((Level.random & 1) + 36962);
          ushort u;
          Level.code1391F9(out u);
          if ((int) (short) u >= 0)
            tile = Level.ROMu16((int) u + 627118);
          Level.PutResizableTile(tile);
        }
      }
      else
      {
        if ((int) Level._byte == 0 && 37008 <= (int) Level.rTile(1, 0) && (int) Level.rTile(1, 0) < 37012)
        {
          Level.PutrResizableTile(1, 0, (ushort) 37007);
          Level.PutrResizableTile(0, -1, (ushort) 38477);
          Level.PutrResizableTile(1, -1, (ushort) 13069);
          Level.PutrResizableTile(1, -2, (ushort) 37380);
        }
        else if (37008 <= (int) Level.rTile(-1, 0) && (int) Level.rTile(-1, 0) < 37012)
        {
          Level.PutrResizableTile(-1, 0, (ushort) 36991);
          Level.PutrResizableTile(0, -1, (ushort) 38478);
          Level.PutrResizableTile(-1, -1, (ushort) 13586);
          Level.PutrResizableTile(-1, -2, (ushort) 37381);
        }
        Level.PutResizableTile(Level.ROMu16((int) Level._byte + 627280));
      }
    }

    private static void Obj27Init()
    {
      Level._vadj = ushort.MaxValue;
      Level._vflag = (ushort) 1;
    }

    private static void Obj27Main()
    {
      if ((int) Level._v >= 3)
      {
        Level.PutResizableTile(Level.ROMu16((Level.random + (int) Level._v & 30) + 626657));
      }
      else
      {
        if ((int) Level._h == 0)
        {
          if (36992 <= (int) Level.sTile && (int) Level.sTile < 36996)
          {
            Level.PutrResizableTile(0, -1, (ushort) 37380);
            Level.PutrResizableTile(-1, 0, (ushort) 38477);
            Level.PutResizableTile((ushort) 13069);
            return;
          }
          else if (37008 <= (int) Level.sTile && (int) Level.sTile < 37012)
          {
            Level.PutResizableTile((ushort) 37007);
            return;
          }
        }
        if ((int) Level._h - 1 == (int) Level._maxw)
        {
          ushort u;
          Level.code1391F9(out u);
          if ((int) (short) u >= 0)
          {
            Level.PutResizableTile(Level.ROMu16((int) u + 627532));
            return;
          }
        }
        if ((int) Level._v == 2)
          Level.PutResizableTile(Level.ROMu16((Level.random + (int) Level._v & 30) + 626657));
        else
          Level.PutResizableTile((ushort) ((uint) (Level.random & 1) + (uint) Level.ROMu16(((int) Level._v << 1) + 627528)));
      }
    }

    private static void Obj28Main()
    {
      if ((int) Level._v >= 3)
      {
        Level.PutResizableTile(Level.ROMu16((Level.random + (int) Level._v & 30) + 626657));
      }
      else
      {
        if ((int) Level._h == 0)
        {
          if (36992 <= (int) Level.sTile && (int) Level.sTile < 36996)
          {
            Level.PutrResizableTile(0, -1, (ushort) 37381);
            Level.PutrResizableTile(1, 0, (ushort) 38478);
            Level.PutResizableTile((ushort) 13586);
            return;
          }
          else if (37008 <= (int) Level.sTile && (int) Level.sTile < 37012)
          {
            Level.PutResizableTile((ushort) 36991);
            return;
          }
        }
        if ((int) Level._h + 1 == (int) Level._maxw)
        {
          ushort u;
          Level.code1391F9(out u);
          if ((int) (short) u >= 0)
          {
            Level.PutResizableTile(Level.ROMu16((int) u + 627684));
            return;
          }
        }
        if ((int) Level._v == 2)
          Level.PutResizableTile(Level.ROMu16((Level.random + (int) Level._v & 30) + 626657));
        else
          Level.PutResizableTile((ushort) ((uint) (Level.random & 1) + (uint) Level.ROMu16(((int) Level._v << 1) + 627680)));
      }
    }

    private static void Obj29Init()
    {
      Level._byte = (byte) (((int) Level._obj.num & 2) << 1);
      Level._vadj = (ushort) 2;
    }

    private static void Obj29Main()
    {
      Level._vflag = (ushort) ((uint) Level._h & 1U);
      if ((int) Level._vflag == 0 && (int) Level._v == 0)
        Level._ushort = (ushort) (Level.random & 2);
      if ((int) -Level._v < 5)
        Level.PutResizableTile(Level.LDAyBank13(Level.ROMu16(((int) Level._byte | (int) Level._ushort) + 627912), (ushort) (((int) -Level._v << 1 | (int) Level._vflag) << 1)));
      else
        Level.PutResizableTile((ushort) 38427);
    }

    private static void Obj2BInit()
    {
    }

    private static void Obj2BMain()
    {
      Level.PutResizableTile((int) Level._maxh != 1 ? (ushort) (((int) Level._v == 0 ? 0 : ((int) Level._v + 1 != (int) Level._maxh ? 1 : 2)) + (int) Level.RAMu16(7630)) : Level.RAMu16(7636));
    }

    private static void Obj2CInit()
    {
      ++Level._maxw;
    }

    private static void Obj2CMain()
    {
      if ((int) Level._v == 0)
        Level.PutResizableTile(Level.ROMu16(((int) Level._h << 1) + 628037));
      else if ((int) Level._h == 0)
        Level.PutResizableTile((ushort) ((Level.random & 6) + 37082));
      else
        Level.PutResizableTile((ushort) ((uint) Level.rTile(-1, 0) + 1U));
    }

    private static void Obj2DInit()
    {
      Level._ushort = (ushort) (Level.random2 & 2);
    }

    private static void Obj2DMain()
    {
      int num = (int) Level._maxh - (int) Level._v - 1;
      if (num >= 2)
      {
        if ((int) Level._v < 4)
        {
          if ((int) Level._ushort == 0)
            Level.PutResizableTile((int) Level._v != 0 || (int) Level.sTile != 37396 ? Level.ROMu16(((int) Level._v << 1) + 628166) : (ushort) 37395);
          else
            Level.PutResizableTile((int) Level._v != 0 || (int) Level.sTile != 37396 ? Level.ROMu16(((int) Level._v << 1) + 628194) : (ushort) 37398);
        }
        else
          Level.PutResizableTile(Level.ROMu16((((int) Level._v & 1) << 1) + (int) Level._ushort + 628102));
      }
      else
        Level.PutResizableTile(Level.LDAyBank13(Level.ROMu16((int) Level._ushort + 628098), (ushort) (num << 1)));
      if ((int) Level._obj.num != 46 || (int) Level._v < 4 || (num < 2 || (Level.random & 2) == 0))
        return;
      if ((int) Level.sTile == 36964)
      {
        Level.PutrResizableTile(-1, 0, (ushort) 36986);
        Level.PutResizableTile((ushort) 36987);
      }
      else
      {
        Level.PutrResizableTile(1, 0, (ushort) 37002);
        Level.PutResizableTile((ushort) 37001);
      }
    }

    private static void Obj2FInit()
    {
    }

    private static void Obj2FMain()
    {
      if ((int) Level._v < 2)
      {
        Level.PutrResizableTile(-1, 0, Level.ROMu16(((int) Level._v << 1) + 628306));
        Level.PutrResizableTile(1, 0, Level.ROMu16(((int) Level._v << 1) + 628314));
        Level.PutResizableTile(Level.ROMu16(((int) Level._v << 1) + 628310));
      }
      else if ((int) Level._v + 1 == (int) Level._maxh)
        Level.PutResizableTile((ushort) 37382);
      else if ((int) Level._v == 2)
        Level.PutResizableTile((ushort) 39178);
      else
        Level.PutResizableTile((ushort) 39179);
    }

    private static void Obj30Init()
    {
      Level._ushort = (Level.random2 & 2) != 0 ? (ushort) 11 : (ushort) 0;
    }

    private static void Obj36Init()
    {
      Level._ushort = (ushort) 11;
    }

    private static void Obj30Main()
    {
      if ((int) Level._v == 0)
      {
        if (39680 <= (int) Level.sTile && (int) Level.sTile < 39684)
          return;
        int num = (int) Level.rTile(0, -1) == 38459 ? 0 : ((int) Level.rTile(0, -1) == 38460 ? 1 : ((int) Level.rTile(0, -1) == 38414 ? 2 : ((int) Level.rTile(0, -1) == 38429 ? 3 : -1)));
        if (num >= 0)
          Level.PutrResizableTile(0, -1, (ushort) (num + 39684));
      }
      int num1 = (int) Level.sTile == 38415 ? 0 : ((int) Level.sTile == 38428 ? 1 : -1);
      if (num1 >= 0)
      {
        Level.PutResizableTile((ushort) (num1 + 39168));
      }
      else
      {
        int num2 = Level.random & 1;
        if ((int) Level._v + 1 != (int) Level._maxh)
          Level.PutResizableTile((ushort) (num2 + (int) Level._ushort + 39176));
        else if ((int) Level.sTileGroup == 37376)
          Level.PutResizableTile((int) Level.sTile < 37391 ? (ushort) 37397 : Level.ROMu16(((int) Level.sTile - 37391 << 1) + 628394));
        else
          Level.PutResizableTile((ushort) (num2 + ((int) Level._ushort != 0 ? 174 : 172)));
      }
    }

    private static void Obj31Main()
    {
      Level.Obj30Main();
      if ((int) Level._v < 2 || (int) Level._v + 1 == (int) Level._maxh)
        return;
      int num = Level.random & 7;
      if (num >= 6)
        return;
      Level.PutResizableTile((ushort) (num + (int) Level._ushort + 39170));
      if ((num & 4) == 0)
        Level.PutrResizableTile(-1, 0, (ushort) (((int) Level._ushort != 0 ? 4 : 0) + (int) Level.ROMu16(((num & 1) << 1) + 628649)));
      if ((num & 2) != 0)
        return;
      Level.PutrResizableTile(1, 0, (ushort) (((int) Level._ushort != 0 ? 4 : 0) + (int) Level.ROMu16(((num & 1) << 1) + 628679)));
    }

    private static void Obj32Init()
    {
    }

    private static void Obj32Main()
    {
      if ((int) Level._v == 0)
      {
        if ((int) Level._obj.num == 50)
          Level.PutResizableTile((int) Level._h == 0 ? (ushort) 37032 : ((int) Level._h + 1 != (int) Level._maxw ? (ushort) ((Level.random & 1) + 37054) : (ushort) 37033));
        else
          Level.PutResizableTile((int) Level._h == 0 ? (ushort) 37034 : ((int) Level._h + 1 != (int) Level._maxw ? (ushort) ((Level.random & 3) + 37056) : (ushort) 37035));
      }
      else if ((int) Level._v + 1 != (int) Level._maxh)
      {
        if ((int) Level._h == 0)
          Level.PutResizableTile((ushort) ((Level.random & 3) + 37046 + (37060 > (int) Level.rTile(-1, 0) || (int) Level.rTile(-1, 0) >= 37064 ? 0 : 4)));
        else if ((int) Level._h + 1 != (int) Level._maxw)
          Level.PutResizableTile((ushort) ((Level.random & 7) + 37074));
        else
          Level.PutResizableTile((ushort) ((Level.random & 3) + 37060 + (37046 > (int) Level.rTile(1, 0) || (int) Level.rTile(1, 0) >= 37050 ? 0 : 4)));
      }
      else if ((int) Level.sTileGroup == 37376)
        Level.PutResizableTile((int) Level._h == 0 ? (ushort) 37068 : ((int) Level._h + 1 != (int) Level._maxw ? (ushort) ((Level.random & 3) + 37070) : (ushort) 37069));
      else
        Level.PutResizableTile((int) Level._h == 0 ? (ushort) 37038 : ((int) Level._h + 1 != (int) Level._maxw ? (ushort) ((Level.random & 3) + 37042) : (ushort) 37039));
    }

    private static void Obj34Init()
    {
      ++Level._maxh;
    }

    private static void Obj34Main()
    {
      if ((int) Level._v == 0)
        Level._ushort = (ushort) (Level.random & 30);
      int num = (int) Level.LDAyBank13(Level.ROMu16((int) Level._ushort + 629098), (ushort) ((uint) Level._v << 1));
      if (num == 0)
        return;
      if ((int) Level._v == 0)
        Level.PutResizableTile((ushort) num);
      else
        Level.PutResizableTile((ushort) (num + (38408 > (int) Level.sTile || (int) Level.sTile >= 38412 ? 0 : 16)));
    }

    private static void Obj35Init()
    {
    }

    private static void Obj35Main()
    {
      if (((int) Level._h & 1) == 0 && (int) Level._v == 0)
        Level._ushort = (ushort) (Level.random & 6);
      ushort tile = (int) Level._v >= 2 ? (ushort) 5672 : Level.LDAyBank13(Level.ROMu16((int) Level._ushort + 629225), (ushort) ((int) Level._v << 2 | ((int) Level._h & 1) << 1));
      if ((int) Level.sTileGroup == 27392 || (int) Level.sTileGroup == 37632 || (int) Level.sTileGroup == 36864)
      {
        Level._ushort = (ushort) 0;
        Level.PutResizableTile((int) Level._v == 0 ? (ushort) 36961 : ((int) Level._v < 2 ? Level.ROMu16((Level.random & 6) + 629233) : (ushort) 37019));
      }
      else if ((int) Level.sTileGroup == 37888)
        Level.PutResizableTile((int) Level._v == 0 ? (ushort) 38656 : (ushort) 38657);
      else if ((int) Level.sTileGroup == 38144)
        Level.PutResizableTile((int) Level._v == 0 ? (ushort) 38912 : (ushort) 38913);
      else
        Level.PutResizableTile(tile);
    }

    private static void Obj37Init()
    {
    }

    private static void Obj37Main()
    {
      if ((int) Level.sTile != 0)
        return;
      Level.PutResizableTile((ushort) 5394);
    }

    private static void Obj38Init()
    {
      Level._ushort = (ushort) (Level.random2 & 2);
    }

    private static void Obj39Init()
    {
      Level._maxw = (ushort) ((int) Level._maxw + 1 & 65534);
      Level._maxh = (ushort) ((int) Level._maxh + 1 & 65534);
    }

    private static void Obj38Main()
    {
      int num;
      if ((int) Level._obj.num == 56)
      {
        num = Level.vindex << 2 | ((int) Level._h == 0 ? 0 : ((int) Level._h + 1 != (int) Level._maxw ? ((int) Level._h + 1 & 1) + 1 << 1 : 6));
        Level.PutResizableTile(Level.ROMu16(num + ((int) Level._ushort == 0 ? 629403 : 629427)));
      }
      else
      {
        Level.PutResizableTile(Level.ROMu16(((int) Level._v << 2 | ((int) Level._h & 1) << 1) + 630643));
        num = (((int) Level._h & 1) != 0 ? 6 : 0) | (((int) Level._v & 1) != 0 ? 16 : 0);
      }
      if (num == 0 && Level.Obj38Cmp(0, -1) && (Level.Obj38Cmp(-1, 0) && Level.Obj38Cmp(-1, -1)))
      {
        Level.code139F64(0, -1);
        Level.code139F64(-1, 0);
        Level.code139F64(-1, -1);
        Level.code139F64();
      }
      else if (num <= 4 && Level.Obj38Cmp(-1, -1) && (Level.Obj38Cmp(1, -1) && Level.Obj38Cmp(0, -1)))
      {
        Level.code139F64(0, -1);
        Level.code139F64();
      }
      else if (num == 6 && Level.Obj38Cmp(0, -1) && (Level.Obj38Cmp(1, 0) && Level.Obj38Cmp(1, -1)))
      {
        Level.code139F64(0, -1);
        Level.code139F64(1, 0);
        Level.code139F64(1, -1);
        Level.code139F64();
      }
      else if (num == 8 && Level.Obj38Cmp(-1, -1) && (Level.Obj38Cmp(-1, 0) && Level.Obj38Cmp(-1, 1)))
      {
        Level.code139F64(-1, 0);
        Level.code139F64();
      }
      else if (num == 14 && Level.Obj38Cmp(1, -1) && (Level.Obj38Cmp(1, 0) && Level.Obj38Cmp(1, 1)))
      {
        Level.code139F64(1, 0);
        Level.code139F64();
      }
      else if (num == 16 && Level.Obj38Cmp(0, 1) && (Level.Obj38Cmp(-1, 0) && Level.Obj38Cmp(-1, 1)))
      {
        Level.code139F64(-1, 1);
        Level.code139F64(0, 1);
        Level.code139F64(-1, 0);
        Level.code139F64();
      }
      else if ((num == 18 || num == 20) && (Level.Obj38Cmp(-1, 1) && Level.Obj38Cmp(0, 1)) && Level.Obj38Cmp(1, 1))
      {
        Level.code139F64(0, 1);
        Level.code139F64();
      }
      else
      {
        if (num != 22 || !Level.Obj38Cmp(0, 1) || (!Level.Obj38Cmp(1, 0) || !Level.Obj38Cmp(1, 1)))
          return;
        Level.code139F64(1, 1);
        Level.code139F64(0, 1);
        Level.code139F64(1, 0);
        Level.code139F64();
      }
    }

    private static void code139F64()
    {
      if ((int) Level.sTileGroup != 40192)
        return;
      Level.PutResizableTile((ushort) (40192U | (uint) Level.ROMu8((int) (byte) Level.sTile + 629451)));
    }

    private static void code139F64(int x, int y)
    {
      Level.PutrResizableTile(x, y, (ushort) (40192U | (uint) Level.ROMu8((int) (byte) Level.rTile(x, y) + 629451)));
    }

    private static bool Obj38Cmp(int x, int y)
    {
      return (int) Level.rTileGroup(x, y) == 40192;
    }

    private static void Obj3AInit()
    {
    }

    private static void Obj3AMain()
    {
      if ((int) Level._h != 0 && (int) Level._v == 0)
      {
        Level._maxh -= (ushort) 2;
        if ((int) (short) Level._maxh <= 0)
          Level._maxh = (ushort) 1;
      }
      int num = (int) Level._maxh - (int) Level._v - 1;
      switch (num)
      {
        case 0:
        case 1:
          Level.PutResizableTile(Level.LDABank13(Level.ROMu16((num << 1) + 630694)));
          break;
        default:
          Level.code13C15F();
          break;
      }
    }

    private static void code13C15F()
    {
      Level.PutResizableTile(Level.LDABank13(Level.ROMu16(((Level.random & 7) << 1) + 622881)));
    }

    private static void Obj3BInit()
    {
      ushort num = (ushort) ((uint) Level._maxh - ((uint) Level._maxw << 1));
      if ((int) (short) num <= 0)
        Level._maxh = (ushort) 1;
      else
        Level._maxh = num;
    }

    private static void Obj3BMain()
    {
      if ((int) Level._h != 0 && (int) Level._v == 0)
        Level._maxh += (ushort) 2;
      int num = (int) Level._maxh - (int) Level._v - 1;
      switch (num)
      {
        case 0:
        case 1:
          Level.PutResizableTile(Level.LDABank13(Level.ROMu16((num << 1) + 630755)));
          break;
        default:
          Level.code13C15F();
          break;
      }
    }

    private static void Obj3CInit()
    {
      Level._maxw = (ushort) 2;
    }

    private static void Obj3CMain()
    {
      Level.PutResizableTile((ushort) ((int) Level._h + (int) Level.ROMu16(((int) Level._v == 0 ? 0 : ((int) Level._v + ((int) (short) Level._maxh < 0 ? -1 : 1) != (int) Level._maxh ? 2 : 4)) + ((int) (short) Level._maxh >= 0 ? ((int) (sbyte) Level._obj.num >= 0 ? 630807 : 630813) : ((int) (sbyte) Level._obj.num >= 0 ? 630819 : 630825)))));
    }

    private static void Obj3DInit()
    {
      Level._maxh = (ushort) 3;
    }

    private static void Obj3DMain()
    {
      if ((int) Level._h == 0)
        Level.PutResizableTile(Level.ROMu16(((int) Level.sTile == 168 || (int) Level.sTile == 169 ? 6 : 0) + Level.vindex + 630988));
      else if ((int) Level._h + 1 != (int) Level._maxw)
        Level.PutResizableTile((ushort) ((uint) (((int) Level._h ^ 1) & 1) + (uint) Level.ROMu16(Level.vindex + 631000)));
      else
        Level.PutResizableTile(Level.ROMu16(Level.vindex + 631006));
    }

    private static void Obj3EInit()
    {
    }

    private static void Obj3EMain()
    {
      if ((int) Level.sTile == 146 || (int) Level.sTile == 147 || (int) Level.sTile == 166)
        Level.PutResizableTile((ushort) 167);
      else
        Level.PutResizableTile(Level.LDABank13(Level.ROMu16(Level.vindex + 631068)));
    }

    private static void Obj3FInit()
    {
    }

    private static void Obj3FMain()
    {
      Level.PutResizableTile(Level.ROMu16(((int) Level._v != 0 ? 2 : 0) + ((int) Level.sTile != 0 ? 2 : 0) + ((int) Level._obj.num & 6) + 631110));
    }

    private static void Obj41Init()
    {
    }

    private static void Obj41Main()
    {
      if (((int) Level._maxh | (int) Level._maxw) == 1)
      {
        Level.PutResizableTile((ushort) 342);
        Level.code13A1D3();
        Level.code13A20A();
        Level.code13A333();
      }
      else
      {
        Level.PutResizableTile(Level.ROMu16(Level.hindex + 631209));
        if ((int) Level._h == 0)
          Level.code13A1D3();
        else if ((int) Level._h + 1 != (int) Level._maxw)
        {
          Level.code13A272();
        }
        else
        {
          Level.code13A20A();
          Level.code13A272();
          Level.code13A333();
        }
      }
    }

    private static void code13A1D3()
    {
      int num = 0;
      while (num < 18)
      {
        if ((int) Level.rTile(0, 1) == (int) Level.ROMu16(num + 631215))
        {
          Level.PutrResizableTile(0, 1, Level.ROMu16(num + 631233));
          break;
        }
        else
          num += 2;
      }
    }

    private static void code13A20A()
    {
      int num = 0;
      while (num < 18)
      {
        if ((int) Level.rTile(1, 0) == (int) Level.ROMu16(num + 631215))
        {
          Level.PutrResizableTile(1, 0, Level.ROMu16(num + 631288));
          break;
        }
        else
          num += 2;
      }
    }

    private static void code13A272()
    {
      int num = 0;
      while (num < 38)
      {
        if ((int) Level.rTile(0, 1) == (int) Level.ROMu16(num + 631334))
        {
          Level.PutrResizableTile(0, 1, Level.ROMu16(num + 631372));
          break;
        }
        else
          num += 2;
      }
    }

    private static void code13A333()
    {
      int num = 0;
      while (num < 18)
      {
        if ((int) Level.rTile(1, 1) == (int) Level.ROMu16(num + 631215))
        {
          Level.PutrResizableTile(1, 1, Level.ROMu16(num + 631585));
          break;
        }
        else
          num += 2;
      }
    }

    private static void Obj42Init()
    {
    }

    private static void Obj42Main()
    {
      if ((int) Level.sTileGroup == 32256)
        return;
      ushort sTile = Level.sTile;
      if ((int) Level._obj.num == 66)
      {
        int num = (int) Level._maxh - (int) Level._v;
        if (num >= 4)
          Level.PutResizableTile(Level.ROMu16((((int) Level._v & 1) << 1) + 631656));
        else
          Level.PutResizableTile(Level.ROMu16((num << 1) + 631658));
      }
      else
        Level.PutResizableTile(Level.ROMu16(Level.vindex + 631711));
      int num1 = (int) Level.sTile - 182 << 1;
      if ((int) sTile == 50 || 132 <= (int) sTile && (int) sTile < 142)
        Level.PutResizableTile(Level.ROMu16(num1 + 631717));
      if ((int) Level._v == 0)
      {
        Level.code13A20A();
      }
      else
      {
        Level.code13A2D1();
        if ((int) Level._v + 1 != (int) Level._maxh)
          return;
        Level.code13A1D3();
        Level.code13A333();
      }
    }

    private static void code13A2D1()
    {
      int num = 0;
      while (num < 38)
      {
        if ((int) Level.rTile(1, 0) == (int) Level.ROMu16(num + 631334))
        {
          Level.PutrResizableTile(1, 0, Level.ROMu16(num + 631467));
          while (num < 58)
          {
            if ((int) Level.rTile(1, 0) == (int) Level.ROMu16(num + 631409))
            {
              if (num >= 48)
                return;
              if ((int) Level._v == 1)
                Level.PutrResizableTile(1, 0, Level.ROMu16((Level.random & 6) + 631447));
              else
                Level.PutrResizableTile(1, 0, (ushort) 49);
            }
            num += 2;
          }
        }
        num += 2;
      }
      if ((int) Level.rTile(1, 0) != 46)
        return;
      Level.PutrResizableTile(1, 0, (ushort) 47);
    }

    private static void Obj44Init()
    {
      Level._ushort = (ushort) 0;
    }

    private static void Obj44Main()
    {
      Level.PutResizableTile((ushort) 194);
      if ((int) Level._h == 0)
      {
        if ((int) Level.rTile(-1, 0) == 346)
          Level.PutrResizableTile(-1, 0, (ushort) 338);
        else if ((int) Level._h + 1 == (int) Level._maxw && (int) Level.rTile(1, 0) == 347)
          Level.PutrResizableTile(1, 0, (ushort) 337);
        Level.code13A47E();
      }
      else if ((int) Level._h + 1 == (int) Level._maxw && (int) Level.rTile(1, 0) == 347)
        Level.PutrResizableTile(1, 0, (ushort) 337);
      if ((int) Level._v != 0)
        return;
      Level.code13A4F8();
    }

    private static void code13A47E()
    {
      if (337 > (int) Level.rTile(-1, 0) || (int) Level.rTile(-1, 0) >= 353)
      {
        if ((int) Level.rTile(0, -1) != 197)
          return;
        Level.PutResizableTile(Level.ROMu16(631932));
      }
      else if (337 <= (int) Level.rTile(0, -1) && (int) Level.rTile(0, -1) < 353)
        Level.PutResizableTile((ushort) 213);
      else
        Level.PutResizableTile(Level.ROMu16(((int) Level.rTile(0, -1) == 194 || (int) Level.rTile(0, -1) == 30694 || (int) Level.rTile(0, -1) == 30695 ? 0 : 2) + 631928));
    }

    private static void code13A4F8()
    {
      ushort num;
      if (337 > (int) Level.rTile(0, -1) || (int) Level.rTile(0, -1) >= 353)
      {
        if ((int) Level._ushort == 0)
          return;
        num = Level._ushort;
        Level._ushort = (ushort) 0;
      }
      else if ((int) Level._ushort == 0)
      {
        num = (ushort) 0;
        Level._ushort = (ushort) 6;
      }
      else
        num = (ushort) 2;
      if ((int) num == 0)
      {
        if ((int) Level.sTile == 213)
          return;
        if ((int) Level.rTile(-1, 0) == 198)
          num = (ushort) 2;
      }
      Level.PutResizableTile(Level.ROMu16((int) num + 632048));
    }

    private static void Obj45Init()
    {
      Level._vadj = Level.ROMu16(((int) Level._obj.num & 2) + 595730);
      --Level._srcy;
      ++Level._maxh;
    }

    private static void Obj45Main()
    {
      if ((int) Level._v >= 2)
      {
        Level.Obj44Main();
      }
      else
      {
        Level._vflag = (ushort) 1;
        int num = ((int) Level._obj.num & 2 | (int) Level._v) << 1;
        if (num != 0 || (int) Level.sTile != 214 && (int) Level.sTile != 215 && ((int) Level.sTile != 30680 && (int) Level.sTile != 30681))
          Level.PutResizableTile(Level.ROMu16(num + 632238));
        if ((int) Level._v == 0)
          num = (int) Level.rTile(0, -1) == 346 || (int) Level.rTile(0, -1) == 347 || ((int) Level.rTile(0, -1) == 337 || (int) Level.rTile(0, -1) == 338) ? (int) Level.ROMu16((((int) Level._obj.num & 2) << 1) + 632246) : ((int) Level.rTile(-1, 0) == 346 || (int) Level.rTile(-1, 0) == 347 || ((int) Level.rTile(-1, 0) == 337 || (int) Level.rTile(-1, 0) == 338) ? (int) Level.ROMu16((((int) Level._obj.num & 2) << 1) + 2 + 632246) : 0);
        else if ((int) Level._v == 1)
          num = (int) Level.rTile(-1, 0) == 346 || (int) Level.rTile(-1, 0) == 347 || ((int) Level.rTile(-1, 0) == 337 || (int) Level.rTile(-1, 0) == 338) ? (int) Level.ROMu16(((int) Level._obj.num & 2) + 632334) : 0;
        if ((int) Level._v != 0 && (int) Level._v != 1 || num == 0)
          Level.code13A47E();
        else
          Level.PutResizableTile((ushort) num);
      }
    }

    private static void Obj47Init()
    {
    }

    private static void Obj47Main()
    {
      if ((int) Level._v == 0)
      {
        int num1 = (int) Level.rTile(0, -1) == 194 ? 0 : ((int) Level.rTile(0, -1) == 197 ? 1 : ((int) Level.rTile(0, -1) == 196 ? 2 : -1));
        int num2;
        if (num1 != -1)
        {
          Level.PutrResizableTile(0, -1, (ushort) (num1 + 46));
          num2 = 0;
        }
        else
        {
          num1 = 0;
          num2 = 5;
        }
        if (num1 != 0)
          Level.PutResizableTile((ushort) 49);
        else
          Level.PutResizableTile((ushort) ((uint) num2 + (uint) Level.ROMu16((Level.random & 14) + 632376)));
      }
      else
        Level.PutResizableTile((ushort) (((int) Level._h & 1) + 32256));
      if ((int) Level._h == 0)
      {
        int num = 0;
        while (num < 8)
        {
          if ((int) Level.rTile(-1, 0) == (int) Level.ROMu16(num + 632534))
          {
            Level.PutrResizableTile(-1, 0, Level.ROMu16(num + 632526));
            break;
          }
          else
            num += 2;
        }
      }
      else if ((int) Level._h + 1 == (int) Level._maxw)
      {
        int num = 0;
        while (num < 8)
        {
          if ((int) Level.rTile(1, 0) == (int) Level.ROMu16(num + 632534))
          {
            Level.PutrResizableTile(1, 0, Level.ROMu16(num + 632569));
            break;
          }
          else
            num += 2;
        }
      }
      if ((int) Level._v + 1 != (int) Level._maxh)
        return;
      int num3 = 0;
      while (num3 < 8)
      {
        if ((int) Level.rTile(0, 1) == (int) Level.ROMu16(num3 + 632534))
        {
          Level.PutrResizableTile(0, 1, Level.ROMu16(num3 + 632604));
          break;
        }
        else
          num3 += 2;
      }
    }

    private static void Obj48Init()
    {
    }

    private static void Obj48Main()
    {
      if (((int) Level._h & 1) == 0)
      {
        int i = 4;
        if ((int) Level._maxw != 1)
        {
          if ((i = Level.code13A887()) == 0)
          {
            if ((int) Level._h + 1 == (int) Level._maxw && (int) Level.rTile(1, 0) != (int) Level.ROMu16(632651))
            {
              if ((int) Level.rTile(1, 0) == (int) Level.ROMu16(632653))
                Level.PutrResizableTile(1, 0, Level.ROMu16(632651));
              else
                i = 4;
            }
          }
          else if ((int) Level._h == 0)
          {
            if ((int) Level.rTile(-1, 0) == (int) Level.ROMu16(632847))
              Level.PutrResizableTile(-1, 0, Level.ROMu16(632649));
            else
              i = 4;
          }
        }
        Level.PutResizableTile((int) Level._h + 1 != (int) Level._maxw || i != 4 ? Level.ROMu16(i + 632649) : (ushort) 338);
        if ((int) Level._h == 0)
        {
          if (46 <= (int) Level.rTile(-1, 0) && (int) Level.rTile(-1, 0) < 51 || 132 <= (int) Level.rTile(-1, 0) && (int) Level.rTile(-1, 0) < 142 || ((int) Level.rTile(-1, 0) == 32256 || (int) Level.rTile(-1, 0) == 32257))
            Level.PutResizableTile(Level.ROMu16(i + 632794));
        }
        else if ((int) Level._h + 1 == (int) Level._maxw)
        {
          i -= 2;
          Level.code13A8AB((ushort) i);
        }
        Level.code13A8DD(ref i);
      }
      else
      {
        int i = 4;
        if ((int) Level._maxw != 1 && (i = Level.code13A887()) != 0 && ((int) Level._h + 1 == (int) Level._maxw && (int) Level.rTile(1, 0) != (int) Level.ROMu16(632843)))
        {
          if ((int) Level.rTile(1, 0) == (int) Level.ROMu16(632847))
            Level.PutrResizableTile(1, 0, Level.ROMu16(632843));
          else
            i = 4;
        }
        Level.PutResizableTile((int) Level._h + 1 != (int) Level._maxw || i != 4 ? Level.ROMu16(i + 632843) : (ushort) 338);
        Level.code13A8AB((ushort) i);
        Level.code13A8DD(ref i);
      }
      if ((int) Level._v + 1 == (int) Level._maxh)
      {
        if ((int) Level._h == 0)
          Level.code13A1D3();
        else
          Level.code13A272();
      }
      if ((int) Level._h + 1 != (int) Level._maxw)
        return;
      if ((int) Level._v == 0)
        Level.code13A20A();
      else
        Level.code13A2D1();
      if ((int) Level._v + 1 != (int) Level._maxh)
        return;
      Level.code13A333();
    }

    private static int code13A887()
    {
      return ((int) Level._x + (int) Level._h & 1 ^ (int) Level._srcy + (int) Level._v & 1) << 1;
    }

    private static void code13A8AB(ushort u)
    {
      if ((int) Level._h + 1 != (int) Level._maxw || (46 > (int) Level.rTile(1, 0) || (int) Level.rTile(1, 0) >= 51) && (132 > (int) Level.rTile(1, 0) || (int) Level.rTile(1, 0) >= 142) && ((int) Level.rTile(1, 0) != 32256 && (int) Level.rTile(1, 0) != 32257))
        return;
      Level.PutResizableTile(Level.ROMu16((int) u + 632997));
    }

    private static void code13A8DD(ref int i)
    {
      if ((int) Level._v != 0)
        return;
      i = 0;
      if ((int) Level.rTile(0, -1) != 32256 && (int) Level.rTile(0, -1) != 32257)
        return;
      Level.PutResizableTile((ushort) ((int) Level.sTile - 346 + 421));
    }

    private static void Obj49Init()
    {
      Level._maxw = (ushort) 2;
    }

    private static void Obj49Main()
    {
      Level.PutResizableTile(Level.ROMu16((((int) Level._obj.num & 2) << 2 | (int) Level._h << 2 | ((int) Level._v != 0 ? 2 : 0)) + 633147));
    }

    private static void Obj4BInit()
    {
      Level._ushort = (ushort) (((int) Level._obj.num & 7) - 3 << 1);
      Level._maxw = Level.ROMu16((int) Level._ushort + 595863);
    }

    private static void Obj4BMain()
    {
      Level.PutResizableTile(Level.ROMu16((int) Level.ROMu16((int) Level._ushort + 633220) + ((int) Level._h << 1) + ((int) Level._v == 0 ? 633226 : ((int) Level._v + 1 != (int) Level._maxh ? 633262 : 633298))));
    }

    private static void Obj4EInit()
    {
    }

    private static void Obj4EMain()
    {
      int i;
      if ((int) Level.sTileGroup != (int) Level.RAMu16(6754) && (int) Level.sTile != 0 && (int) Level.sTile != 194)
      {
        i = 2;
        while (i < 62 && (int) Level.sTile != (int) Level.LDABank13(Level.ROMu16(i + 633917)))
          i += 2;
        if (i == 62)
          return;
      }
      else
        i = 0;
      if ((int) Level._maxw == 1)
      {
        if ((int) Level._maxh == 1)
          i = (int) Level.ROMu16(i + 633979);
        else if ((int) Level._v == 0)
        {
          if (Level.code13AC04())
            Level.Obj4Ejmp(634963, ref i);
          else
            i = (int) Level.ROMu16(i + 634041);
        }
        else if ((int) Level._v + 1 != (int) Level._maxh)
        {
          if (Level.code13AC04())
            Level.Obj4Ejmp(634987, ref i);
          else
            i = (int) Level.ROMu16(i + 634103);
        }
        else if (Level.code13AC04())
          Level.Obj4Ejmp(634999, ref i);
        else
          i = (int) Level.ROMu16(i + 634165);
      }
      else if ((int) Level._maxh == 1)
      {
        if ((int) Level._h == 0)
        {
          if (Level.code13AC04())
            Level.Obj4Ejmp(635029, ref i);
          else
            i = (int) Level.ROMu16(i + 634227);
        }
        else if ((int) Level._h + 1 != (int) Level._maxw)
        {
          if (Level.code13AC04())
            Level.Obj4Ejmp(635059, ref i);
          else
            i = (int) Level.ROMu16(i + 634289);
        }
        else if (Level.code13AC04())
          Level.Obj4Ejmp(635065, ref i);
        else
          i = (int) Level.ROMu16(i + 634351);
      }
      else if ((int) Level._h == 0)
      {
        if ((int) Level._v == 0)
        {
          if (Level.code13AC04())
            Level.Obj4Ejmp(635081, ref i);
          else
            i = (int) Level.ROMu16(i + 634413);
        }
        else if ((int) Level._v + 1 != (int) Level._maxh)
        {
          if (Level.code13AC04())
          {
            Level.code13AC15(ref i);
            i = (int) Level.ROMu16(i + 634661);
          }
          else
            i = (int) Level.ROMu16(i + 634475);
        }
        else if (Level.code13AC04())
          Level.Obj4Ejmp(635111, ref i);
        else
          i = (int) Level.ROMu16(i + 634537);
      }
      else if ((int) Level._h + 1 != (int) Level._maxw)
      {
        if ((int) Level._v == 0)
        {
          if (Level.code13AC04())
          {
            Level.code13AC15(ref i);
            i = (int) Level.ROMu16(i + 634661);
          }
          else
            i = (int) Level.ROMu16(i + 634599);
        }
        else if ((int) Level._v + 1 != (int) Level._maxh)
        {
          if (Level.code13AC04() && i == 0 && ((int) Level.sTileGroup == (int) Level.RAMu16(6754) && (int) (byte) Level.sTile >= 16))
            i += 2;
          i = (int) Level.ROMu16(i + 634661);
        }
        else if (Level.code13AC04())
        {
          Level.code13AC15(ref i);
          i = (int) Level.ROMu16(i + 634661);
        }
        else
          i = (int) Level.ROMu16(i + 634723);
      }
      else if ((int) Level._v == 0)
      {
        if (Level.code13AC04())
          Level.Obj4Ejmp(635137, ref i);
        else
          i = (int) Level.ROMu16(i + 634785);
      }
      else if ((int) Level._v + 1 != (int) Level._maxh)
      {
        if (Level.code13AC04())
        {
          Level.code13AC15(ref i);
          i = (int) Level.ROMu16(i + 634661);
        }
        else
          i = (int) Level.ROMu16(i + 634847);
      }
      else if (Level.code13AC04())
        Level.Obj4Ejmp(635167, ref i);
      else
        i = (int) Level.ROMu16(i + 634909);
      Level.PutResizableTile(Level.LDABank13((ushort) i));
    }

    private static bool code13AC04()
    {
      return (int) Level.sTileGroup == (int) Level.RAMu16(6754);
    }

    private static void code13AC15(ref int i)
    {
      i = 0;
      while (i < 992 && (int) Level.sTile != (int) Level.LDABank13(Level.ROMu16(i + 633979)))
        i += 2;
      Level._ushort = (ushort) (i / 62);
      i %= 62;
    }

    private static void Obj4Ejmp(int addr, ref int i)
    {
      Level.code13AC15(ref i);
      ushort num1 = Level.ROMu16(((int) Level._ushort << 1) + addr);
      if ((uint) num1 <= 43902U)
      {
        if ((uint) num1 <= 43854U)
        {
          if ((int) num1 != 43832)
          {
            if ((int) num1 == 43854)
            {
              i = (int) Level.ROMu16(i + 634475);
              return;
            }
          }
          else
            goto label_15;
        }
        else if ((int) num1 != 43880)
        {
          if ((int) num1 == 43902)
          {
            i = (int) Level.ROMu16(i + 634599);
            return;
          }
        }
        else
        {
          i = (int) Level.ROMu16(i + 634537);
          return;
        }
      }
      else if ((uint) num1 <= 43957U)
      {
        if ((int) num1 != 43935)
        {
          if ((int) num1 == 43957)
          {
            i = (int) Level.ROMu16(i + 634723);
            return;
          }
        }
        else
        {
          i = (int) Level.ROMu16(i + 634661);
          return;
        }
      }
      else if ((int) num1 != 43983)
      {
        if ((int) num1 != 44005)
        {
          if ((int) num1 == 44031)
          {
            i = (int) Level.ROMu16(i + 634909);
            return;
          }
        }
        else
        {
          i = (int) Level.ROMu16(i + 634847);
          return;
        }
      }
      else
      {
        i = (int) Level.ROMu16(i + 634785);
        return;
      }
      if (Level._error_msg)
      {
        int num2 = (int) MessageBox.Show("The current placement of the sand block will cause the level not to be loaded in the game play.", "Illgegal Placement", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      i = 0;
label_15:
      i = (int) Level.ROMu16(i + 634413);
    }

    private static void Obj4FInit()
    {
    }

    private static void Obj4FMain()
    {
      if ((int) Level.rTileGroup(0, -1) == (int) Level.RAMu16(6754))
        Level.PutrResizableTile(0, -1, Level.LDABank13(Level.ROMu16(((int) (byte) Level.rTile(0, -1) << 1) + 635312)));
      if ((int) Level.rTileGroup(0, 1) == (int) Level.RAMu16(6754))
        Level.PutrResizableTile(0, 1, Level.LDABank13(Level.ROMu16(((int) (byte) Level.rTile(0, 1) << 1) + 635694)));
      if ((int) Level.rTileGroup(1, 0) == (int) Level.RAMu16(6754))
        Level.PutrResizableTile(1, 0, Level.LDABank13(Level.ROMu16(((int) (byte) Level.rTile(1, 0) << 1) + 636076)));
      if ((int) Level.rTileGroup(-1, 0) == (int) Level.RAMu16(6754))
        Level.PutrResizableTile(-1, 0, Level.LDABank13(Level.ROMu16(((int) (byte) Level.rTile(-1, 0) << 1) + 636458)));
      Level.PutResizableTile((int) Level.ROMu16(((int) (byte) Level.sTile << 1) + 636840) != 0 ? Level.LDABank13(Level.ROMu16(((int) (byte) Level.sTile << 1) + 636840)) : (ushort) 0);
    }

    private static void Obj50Init()
    {
    }

    private static void Obj50Main()
    {
      Level.PutResizableTile((int) Level.sTile == (int) Level.RAMu16(7260) || (int) Level.sTile == (int) Level.RAMu16(7262) || ((int) Level.sTile == (int) Level.RAMu16(7572) || (int) Level.sTile == (int) Level.RAMu16(7574)) ? Level.RAMu16(7240) : Level.LDABank13(Level.ROMu16((((int) Level._obj.num & 1) << 1) + 637272)));
    }

    private static void Obj52Init()
    {
      Level._vadj = ushort.MaxValue;
      Level._vflag = (ushort) 1;
    }

    private static void Obj52Main()
    {
      if ((int) Level._v >= 2)
        return;
      Level.PutResizableTile(Level.LDABank13(Level.ROMu16(((int) Level._v << 1) + ((int) (short) Level._maxw < 0 ? 4 : 0) + 637317)));
    }

    private static void Obj53Init()
    {
    }

    private static void Obj53Main()
    {
      ushort sTile = Level.sTile;
      if ((int) sTile < 194 || 200 <= (int) sTile)
        return;
      int num = (int) Level._h == 0 ? 0 : ((int) Level._h + 1 != (int) Level._maxw ? (((int) Level._h & 1) != 0 ? 2 : 4) : 6);
      if ((int) Level._h == 0 || (int) Level._h + 1 == (int) Level._maxw)
      {
        if ((int) Level.RAMu16(6618) <= (int) sTile && (int) sTile < (int) Level.RAMu16(6750))
          return;
        if ((int) sTile == 209 || (int) sTile == 210)
          num = 2;
      }
      if (196 <= (int) sTile && (int) sTile < 200 && (int) Level._h != 0)
        Level.PutResizableTile(Level.ROMu16(((int) sTile - 196 << 1) + 637464));
      else
        Level.PutResizableTile(Level.ROMu16(num + 637456));
    }

    private static void Obj54Init()
    {
      Level._vadj = Level.ROMu16((((int) Level._obj.num & 3) << 1) + 596052);
    }

    private static void Obj54Main()
    {
      int num = (int) Level._h != 0 ? 2 : 0;
      if ((int) Level._h != 0 && (int) Level._h + ((int) (short) Level._maxw < 0 ? -1 : 1) != (int) Level._maxw)
      {
        switch (Level._obj.num)
        {
          case (byte) 84:
            if ((int) Level._v >= 2)
              break;
            Level._vflag = (ushort) (((int) Level._h ^ 1) & 1);
            Level.PutResizableTile(Level.LDABank13(Level.ROMu16((((int) (short) Level._maxw < 0 ? 8 : 0) | (int) Level._vflag << 2 | (int) Level._v << 1) + 637654)));
            break;
          case (byte) 85:
            Level._vflag = (ushort) 1;
            if ((int) Level._v >= 2)
              break;
            Level.PutResizableTile(Level.LDABank13(Level.ROMu16((((int) (short) Level._maxw < 0 ? 4 : 0) | (int) Level._v << 1) + 637707)));
            break;
          case (byte) 86:
            Level._vflag = (ushort) 1;
            if ((int) Level._v >= 3)
              break;
            Level.PutResizableTile(Level.LDABank13(Level.ROMu16(((int) (short) Level._maxw < 0 ? 6 : 0) + ((int) Level._v << 1) + 637753)));
            break;
        }
      }
      else
      {
        if ((int) Level._v != 0 || (int) Level.RAMu16(6618) <= (int) Level.sTile && (int) Level.sTile < (int) Level.RAMu16(6750) || ((int) Level.sTile == 5389 || (int) Level.sTile == 5390))
          return;
        if ((int) Level.sTile == 209)
          Level.PutResizableTile(Level.ROMu16(num + 637592));
        else if ((int) Level.sTile == 210)
        {
          Level.PutResizableTile(Level.ROMu16(2 + num + 637592));
        }
        else
        {
          if ((int) (short) Level._maxw < 0)
            num ^= 2;
          Level.PutResizableTile(Level.ROMu16(((int) Level.sTile == 197 ? 4 : num) + 637586));
        }
      }
    }

    private static void Obj57Init()
    {
    }

    private static void Obj57Main()
    {
      int hindex = Level.hindex;
      switch (hindex)
      {
        case 0:
          if ((int) Level.sTile == (int) Level.RAMu16(7160))
          {
            hindex |= 8;
            break;
          }
          else
            break;
        case 4:
          if ((int) Level.sTile == (int) Level.RAMu16(7162))
          {
            hindex |= 8;
            break;
          }
          else
            break;
      }
      Level.PutResizableTile(Level.LDABank13(Level.ROMu16(hindex + ((int) Level._obj.num == 87 ? 637834 : 637848))));
    }

    private static void Obj58Init()
    {
      Level._ushort = (ushort) 0;
    }

    private static void Obj58Main()
    {
      switch (Level.hindex)
      {
        case 0:
          if ((int) (short) Level._ushort < 0)
            break;
          if ((int) Level._ushort != 0 || (int) Level.rTile(0, 1) == (int) Level.RAMu16(7400) || (int) Level.rTile(0, 1) == (int) Level.RAMu16(7402) || (int) Level.RAMu16(7342) <= (int) Level.rTile(0, 1) && (int) Level.rTile(0, 1) < (int) Level.RAMu16(7370))
          {
            Level._ushort = (ushort) 1;
            if ((int) Level._v == 0)
            {
              Level.PutResizableTile(Level.RAMu16(7414));
              break;
            }
            else
            {
              Level.Obj02MainCode2(1);
              if ((int) Level.rTile(1, 0) != 125 && (int) Level.rTile(1, 0) != 126 && ((int) Level.rTile(1, 0) != (int) Level.RAMu16(7260) && (int) Level.rTile(1, 0) != (int) Level.RAMu16(7262)))
                break;
              Level.PutResizableTile(Level.RAMu16(7398));
              break;
            }
          }
          else
          {
            if ((int) Level._v != 0)
              break;
            if ((int) Level.sTile == (int) Level.RAMu16(7408) || (int) Level.sTile == (int) Level.RAMu16(7410) || ((int) Level.sTile == (int) Level.RAMu16(7412) || (int) Level.sTile == (int) Level.RAMu16(7414)) || ((int) Level.sTile == (int) Level.RAMu16(7416) || (int) Level.sTile == (int) Level.RAMu16(7418)))
            {
              Level.PutResizableTile(Level.RAMu16(7410));
              break;
            }
            else
            {
              Level._ushort = ushort.MaxValue;
              if ((int) Level.sTile == (int) Level.RAMu16(7208))
                break;
              Level.PutResizableTile(Level.RAMu16((int) Level.sTile == (int) Level.RAMu16(7158) ? 7208 : 7408));
              break;
            }
          }
        case 2:
          Level._ushort = (ushort) 0;
          if ((int) Level._v != 0 || (int) Level.sTile == (int) Level.RAMu16(7208))
            break;
          int num = 0;
          while (num < 24)
          {
            if ((int) Level.sTile == (int) Level.RAMu16((int) Level.ROMu16(num + 638116)))
            {
              Level.PutResizableTile(Level.RAMu16((int) Level.ROMu16(num + 638140)));
              return;
            }
            else
              num += 2;
          }
          Level.PutResizableTile(Level.RAMu16(7410));
          break;
        case 4:
          if ((int) (short) Level._ushort < 0)
            break;
          if ((int) Level._ushort != 0 || (int) Level.rTile(0, 1) == (int) Level.RAMu16(7400) || (int) Level.rTile(0, 1) == (int) Level.RAMu16(7402) || (int) Level.RAMu16(7342) <= (int) Level.rTile(0, 1) && (int) Level.rTile(0, 1) < (int) Level.RAMu16(7370))
          {
            Level._ushort = (ushort) 1;
            if ((int) Level._v == 0)
            {
              Level.PutResizableTile(Level.RAMu16(7412));
              break;
            }
            else
            {
              Level.Obj02MainCode2(0);
              if ((int) Level.rTile(-1, 0) != 125 && (int) Level.rTile(-1, 0) != 126 && ((int) Level.rTile(-1, 0) != (int) Level.RAMu16(7260) && (int) Level.rTile(-1, 0) != (int) Level.RAMu16(7262)))
                break;
              Level.PutResizableTile(Level.RAMu16(7396));
              break;
            }
          }
          else
          {
            if ((int) Level._v != 0)
              break;
            if ((int) Level.sTile == (int) Level.RAMu16(7408) || (int) Level.sTile == (int) Level.RAMu16(7410) || ((int) Level.sTile == (int) Level.RAMu16(7412) || (int) Level.sTile == (int) Level.RAMu16(7414)) || ((int) Level.sTile == (int) Level.RAMu16(7416) || (int) Level.sTile == (int) Level.RAMu16(7418)))
            {
              Level.PutResizableTile(Level.RAMu16(7410));
              break;
            }
            else
            {
              Level._ushort = ushort.MaxValue;
              if ((int) Level.sTile == (int) Level.RAMu16(7208))
                break;
              Level.PutResizableTile(Level.RAMu16((int) Level.sTile == (int) Level.RAMu16(7158) ? 7208 : 7418));
              break;
            }
          }
      }
    }

    private static void Obj59Init()
    {
      ++Level._maxh;
      Level._maxw += (ushort) 2;
      --Level._srcy;
      --Level._x;
      Level._vadj = Level.ROMu16((((int) Level._obj.num & 3) - 1 << 1) + 596207);
    }

    private static void Obj5CInit()
    {
      Level._maxw += (ushort) 2;
      --Level._x;
      Level._vadj = Level.ROMu16((((int) Level._obj.num & 3) << 1) + 596280);
    }

    private static void Obj59Main()
    {
      if ((int) Level._h == 0)
      {
        Level.code13C175();
        Level._vflag = (ushort) ((uint) Level._obj.num & 4U);
      }
      else if ((int) Level._h + 1 != (int) Level._maxw)
      {
        if ((int) Level._v < 2)
        {
          Level._vflag = (ushort) (((int) Level._h ^ 1) & 1);
          if ((int) Level.sTile != (int) Level.RAMu16(7412) && (int) Level.sTile != (int) Level.RAMu16(7414))
            Level.PutResizableTile(Level.LDABank13(Level.ROMu16((((int) Level._obj.num & 4) << 1 | (int) Level._vflag << 2 | (int) Level._v << 1) + 638455)));
        }
        else
          Level.code13C15F();
      }
      else if ((int) Level._obj.num == 92 || (int) Level._v != 0)
        Level.code13C1F0();
      if ((int) Level._h + 2 != (int) Level._maxw)
        return;
      Level._vflag = (ushort) 0;
    }

    private static void Obj5AMain()
    {
      if ((int) Level._h == 0)
      {
        Level.code13C175();
        Level._vflag = (ushort) ((uint) Level._obj.num & 4U);
      }
      else if ((int) Level._h + 1 != (int) Level._maxw)
      {
        if ((int) Level._v < 2)
        {
          Level._vflag = (ushort) 1;
          if ((int) Level.sTile != (int) Level.RAMu16(7412) && (int) Level.sTile != (int) Level.RAMu16(7414))
            Level.PutResizableTile(Level.LDABank13(Level.ROMu16(((int) Level._obj.num & 4 | (int) Level._v << 1) + 638576)));
        }
        else
          Level.code13C15F();
      }
      else if ((int) Level._obj.num == 93 || (int) Level._v != 0)
        Level.code13C1F0();
      if ((int) Level._h + 2 != (int) Level._maxw)
        return;
      Level._vflag = (ushort) 0;
    }

    private static void Obj5BMain()
    {
      if ((int) Level._h == 0)
      {
        Level.code13C175();
        Level._vflag = (ushort) ((uint) Level._obj.num & 4U);
      }
      else if ((int) Level._h + 1 != (int) Level._maxw)
      {
        if ((int) Level._v < 3)
        {
          Level._vflag = (ushort) 1;
          if ((int) Level.sTile != (int) Level.RAMu16(7412) && (int) Level.sTile != (int) Level.RAMu16(7414))
            Level.PutResizableTile(Level.LDABank13(Level.ROMu16((((int) Level._obj.num & 4) << 1 | (int) Level._v << 1) + 638695)));
        }
        else
          Level.code13C15F();
      }
      else if ((int) Level._obj.num == 92 || (int) Level._v != 0 && (int) Level._v != 1)
        Level.code13C1F0();
      if ((int) Level._h + 2 != (int) Level._maxw)
        return;
      Level._vflag = (ushort) 0;
    }

    private static void code13C175()
    {
      if ((int) Level.sTileGroup != (int) Level.RAMu16(7136))
        return;
      Level.PutResizableTile(Level.LDABank13(Level.ROMu16(((int) (byte) Level.sTile << 1) + 639380)));
    }

    private static void code13C1F0()
    {
      if ((int) Level.sTileGroup != (int) Level.RAMu16(7136))
        return;
      Level.PutResizableTile(Level.LDABank13(Level.ROMu16(((int) (byte) Level.sTile << 1) + 639503)));
    }

    private static void Obj5FInit()
    {
      ushort num = ((int) Level._obj.num & 15) == 0 ? Level._maxw : (ushort) ((uint) Level._maxw >> 1);
      if ((int) (short) num >= (int) (short) Level._maxh)
        Level._maxh = num;
      Level._maxw += (ushort) 2;
      ++Level._maxh;
      --Level._x;
      Level._ushort = (ushort) 0;
      Level._byte = (byte) (((int) Level._obj.num & 32) >> 1);
    }

    private static void Obj5FMain()
    {
      if ((int) Level._h == 0)
      {
        if ((int) Level._v + 1 >= (int) Level._maxh)
          return;
        Level.code13C175();
      }
      else if ((int) Level._h + 1 != (int) Level._maxw)
      {
        int num1 = -1;
        if ((int) Level._byte != 0 && (int) Level._v == 0 && ((int) Level._h != 1 && (int) --Level._maxh == 2))
          num1 = 2;
        else if ((int) Level._h + 2 == (int) Level._maxw && (int) Level._v == 0 && (int) Level._maxh < 3)
          num1 = (int) --Level._maxw == 2 ? 2 : 1;
        else if ((int) (ushort) ((uint) Level._v + 2U) >= (int) Level._maxh)
          num1 = (int) Level._maxh;
        if (num1 != -1)
        {
          int num2;
          if ((num2 = (int) (short) num1 - 1 - (int) (short) Level._v) < 0)
            return;
          int num3 = ((int) Level._h & 1 ^ 1) << 3 | (int) Level._byte | num2 << 1;
          int num4;
          if ((int) Level._sheader[1] == 8)
          {
            if ((num4 = (int) Level.ROMu16(num3 + 638997)) == 0)
              return;
          }
          else
            num4 = (int) Level.ROMu16(num3 + 638965);
          if ((int) Level.LDABank13((ushort) num4) == (int) Level.RAMu16(7198) && (int) Level.sTile != (int) Level.RAMu16(7192) && (int) Level.sTile != (int) Level.RAMu16(7172))
            return;
          Level.PutResizableTile(Level.LDABank13((ushort) num4));
          Level._ushort = (ushort) (num3 & 8);
        }
        else
        {
          Level.code13C15F();
          if ((int) Level._byte != 0 || (int) Level._v != 0 || ((int) Level._h & 1) != 0)
            return;
          --Level._maxh;
        }
      }
      else
      {
        if ((int) Level._byte != 0 && (int) Level._v == 0)
          --Level._maxh;
        if ((int) Level._v + 1 != (int) Level._maxh)
        {
          Level.code13C1F0();
          Level._ushort = (ushort) 0;
        }
        else
        {
          if ((int) Level._ushort != 0 || (int) Level.sTile != (int) Level.RAMu16(7172))
            return;
          Level.PutResizableTile(Level.RAMu16(7198));
        }
      }
    }

    private static void Obj61Init()
    {
      if (((int) Level._obj.num & 2) == 0 || ((int) Level._maxh | (int) Level._maxw) != 1)
      {
        Level._maxw += (ushort) 2;
        if ((int) Level._maxh >= 2)
          Level._maxh = (ushort) ((int) Level._maxh + 2 - (((int) Level._obj.num & 2) != 0 ? (int) Level._maxw : (int) Level._maxw >> 1));
      }
      else
        Level._maxw += (ushort) 2;
      if ((int) (short) Level._maxh <= 0)
        Level._maxh = (ushort) 1;
      --Level._x;
      Level._ushort = (ushort) 0;
      Level._byte = (byte) (((int) Level._obj.num & 2) << 3);
    }

    private static void Obj61Main()
    {
      if ((int) Level._h == 0)
      {
        if ((int) Level._maxh == 1 || (int) Level._v + 1 == (int) Level._maxh)
          return;
        Level.code13C175();
      }
      else if ((int) Level._h + 1 != (int) Level._maxw)
      {
        if (((int) Level._byte != 0 || ((int) Level._h & 1) == 0) && (int) Level._v == 0)
          ++Level._maxh;
        if ((int) Level._v + 2 >= (int) Level._maxh)
        {
          if ((int) (short) ((int) Level._maxh - (int) Level._v) < 0)
            return;
          int num;
          if ((int) Level._sheader[1] == 8)
          {
            if ((num = (int) Level.ROMu16(((int) Level._maxh - (int) Level._v << 1 | ((int) Level._h & 1 ^ 1) << 3 | (int) Level._byte) + 639289)) == 0)
              return;
          }
          else
            num = (int) Level.ROMu16(((int) Level._maxh - (int) Level._v << 1 | ((int) Level._h & 1 ^ 1) << 3 | (int) Level._byte) + 639257);
          if ((int) Level.LDABank13((ushort) num) == (int) Level.RAMu16(7196))
          {
            if ((int) Level.sTile == (int) Level.RAMu16(7172))
              Level.PutResizableTile(Level.LDABank13((ushort) num));
            else if ((int) Level.sTile == (int) Level.RAMu16(7162))
            {
              Level.PutResizableTile(Level.RAMu16(7214));
            }
            else
            {
              if ((int) Level.sTile != (int) Level.RAMu16(7170))
                return;
              Level.PutResizableTile(Level.RAMu16(7216));
            }
          }
          else
            Level.PutResizableTile(Level.LDABank13((ushort) num));
        }
        else
          Level.code13C15F();
      }
      else
      {
        if ((int) Level._v == 0)
          ++Level._maxh;
        if ((int) Level._v + 1 == (int) Level._maxh)
          return;
        if ((int) Level._v + 2 != (int) Level._maxh)
        {
          Level.code13C1F0();
          Level._ushort = (ushort) 0;
        }
        else
        {
          if ((int) Level._ushort != 0 || (int) Level.sTile != (int) Level.RAMu16(7172))
            return;
          Level.PutResizableTile(Level.RAMu16(7198));
        }
      }
    }

    private static void Obj63Init()
    {
    }

    private static void Obj63Main()
    {
      Level.PutResizableTile(Level.ROMu16(Level.hindex + 639595));
    }

    private static void Obj66Init()
    {
    }

    private static void Obj66Main()
    {
      Level.PutResizableTile((ushort) (((int) Level._h & 1 | ((int) Level._v & 1) << 1) + 35072));
    }

    private static void Obj67Init()
    {
    }

    private static void Obj67Main()
    {
      if ((int) Level._sheader[1] != 12)
      {
        Level.code13C15F();
        if ((int) Level._h == 0)
        {
          if ((int) Level._v == 0)
            Level.Obj67ReplaceTile(-1, -1, 639761);
          Level.Obj67ReplaceTile(-1, 0, 639380);
          if ((int) Level._v + 1 == (int) Level._maxh)
            Level.Obj67ReplaceTile(-1, 1, 639853);
        }
        if ((int) Level._v == 0)
          Level.Obj67ReplaceTile(0, -1, 639945);
        if ((int) Level._v + 1 == (int) Level._maxh)
          Level.Obj67ReplaceTile(0, 1, 640037);
        if ((int) Level._h + 1 != (int) Level._maxw)
          return;
        if ((int) Level._v == 0)
          Level.Obj67ReplaceTile(1, -1, 640129);
        Level.Obj67ReplaceTile(1, 0, 639503);
        if ((int) Level._v + 1 != (int) Level._maxh)
          return;
        Level.Obj67ReplaceTile(1, 1, 640221);
      }
      else
      {
        int num = Level.random & 63;
        if (num >= 11)
          Level.PutResizableTile((ushort) 31200);
        else
          Level.PutResizableTile((ushort) (num + 31163));
      }
    }

    private static void Obj67ReplaceTile(int x, int y, int addr)
    {
      if ((int) Level.rTileGroup(x, y) != (int) Level.RAMu16(7136))
        return;
      Level.PutrResizableTile(x, y, Level.LDABank13(Level.ROMu16(addr + ((int) (byte) Level.rTile(x, y) << 1))));
    }

    private static void Obj68Init()
    {
    }

    private static void Obj68Main()
    {
      Level.PutResizableTile(Level.ROMu16(((int) Level._obj.num & 2) + 640709));
    }

    private static void Obj69Init()
    {
      if ((int) Level._maxw < 4)
        Level._maxw = (ushort) 4;
      if ((int) Level._maxh >= 4)
        return;
      Level._maxh = (ushort) 4;
    }

    private static void Obj69Main()
    {
      Level.PutResizableTile(Level.ROMu16(Level.hindex + ((int) Level._v == 0 ? 640790 : ((int) Level._v + 1 != (int) Level._maxh ? 640796 : 640802))));
    }

    private static void Obj6AInit()
    {
    }

    private static void Obj6AMain()
    {
      Level.PutResizableTile((ushort) (((int) Level._h == 0 ? 0 : ((int) Level._h + 1 != (int) Level._maxw ? 1 : 2)) + 25600));
    }

    private static void Obj6BInit()
    {
      ++Level._maxh;
      --Level._srcy;
    }

    private static void Obj6BMain()
    {
      if ((int) Level._v == 0)
      {
        if ((int) Level._h != 0 || (int) Level.rTile(-1, 0) != (int) Level.RAMu16(7260) && (int) Level.rTile(-1, 0) != (int) Level.RAMu16(7262))
          return;
        Level.PutResizableTile(Level.RAMu16(7444));
      }
      else if ((int) Level._v == 1)
      {
        if ((int) Level.rTile(-1, 0) == (int) Level.RAMu16(7350) || (int) Level.rTile(-1, 0) == (int) Level.RAMu16(7352) || ((int) Level.rTile(-1, 0) == (int) Level.RAMu16(7378) || (int) Level.rTile(-1, 0) == (int) Level.RAMu16(7398)))
          Level.PutResizableTile(Level.RAMu16(7420));
        else
          Level.PutResizableTile(Level.ROMu16(Level.hindex + 640934));
      }
      else
        Level.PutResizableTile(Level.ROMu16(Level.hindex + 640940));
    }

    private static void Obj6CInit()
    {
    }

    private static void Obj6CMain()
    {
      Level.PutResizableTile((ushort) 388);
      if ((int) Level._v + 1 == (int) Level._maxh)
      {
        if ((int) Level._h == 0)
          Level.code13A1D3();
        else
          Level.code13A272();
      }
      if ((int) Level._h + 1 != (int) Level._maxw)
        return;
      if ((int) Level._v == 0)
        Level.code13A20A();
      else
        Level.code13A2D1();
      if ((int) Level._v + 1 != (int) Level._maxh)
        return;
      Level.code13A333();
    }

    private static void Obj6DInit()
    {
    }

    private static void Obj6DMain()
    {
      Level.PutResizableTile(Level.LDABank13(Level.ROMu16(Level.vindex + 640994)));
    }

    private static void Obj6EInit()
    {
    }

    private static void Obj6EMain()
    {
      Level.PutResizableTile(Level.ROMu16(((int) Level._obj.num == 139 ? 16 : Level.random & 14) + 641036));
    }

    private static void Obj6FInit()
    {
    }

    private static void Obj6FMain()
    {
      if ((int) Level._v + 1 == (int) Level._maxh && ((int) Level.sTile == (int) Level.RAMu16(7260) || (int) Level.sTile == (int) Level.RAMu16(7262)))
        Level.PutResizableTile((ushort) 15691);
      else
        Level.PutResizableTile(Level.ROMu16((Level.random & 6) + 641096));
    }

    private static void Obj70Init()
    {
      if (((int) Level._maxw & 1) != 0)
        ++Level._maxw;
      Level._maxh = (ushort) 2;
    }

    private static void Obj70Main()
    {
      Level.PutResizableTile(Level.ROMu16((((int) Level._h & 1) << 1 | (int) Level._v << 2) + ((int) Level._obj.num == 112 ? 641143 : ((int) Level._obj.num == 113 ? 641164 : 641185))));
    }

    private static void Obj73Init()
    {
      Level._maxw = (ushort) 3;
      if (((int) Level._maxh & 1) == 0)
        return;
      ++Level._maxh;
    }

    private static void Obj73Main()
    {
      Level.PutResizableTile(Level.ROMu16(((int) Level._h << 1) + (((int) Level._v & 1) != 0 ? 6 : 0) + 641251));
    }

    private static void Obj74Init()
    {
      Level._maxw = (ushort) 3;
    }

    private static void Obj74Main()
    {
      Level.PutResizableTile(Level.ROMu16(((int) Level._h << 1) + 641281));
    }

    private static void Obj75Init()
    {
      Level._maxw = (ushort) 2;
    }

    private static void Obj75Main()
    {
      Level.PutResizableTile(Level.ROMu16(((int) Level._h << 1) + 641305));
    }

    private static void Obj76Init()
    {
      Level._maxw = (ushort) 2;
    }

    private static void Obj76Main()
    {
      Level.PutResizableTile(Level.ROMu16(((int) Level._h << 1) + 641327));
    }

    private static void Obj77Init()
    {
    }

    private static void Obj77Main()
    {
      Level.PutResizableTile((ushort) 15704);
    }

    private static void Obj78Init()
    {
      Level._maxh = (ushort) 2;
      Level._vadj = ushort.MaxValue;
    }

    private static void Obj78Main()
    {
      Level._vflag = (int) Level._v != 0 ? ushort.MaxValue : (ushort) 0;
      int num;
      if ((int) Level._h == 0)
      {
        Level._vflag = (ushort) 0;
        if ((int) Level._v != 0)
          return;
        num = (int) (short) Level._maxw < 0 ? 6 : 2;
      }
      else
      {
        num = (int) Level._v << 1 | ((int) (short) Level._maxw < 0 ? 4 : 0);
        if ((int) Level._h + ((int) (short) Level._maxw < 0 ? -1 : 1) == (int) Level._maxw && (int) Level._v != 0)
          return;
      }
      Level.PutResizableTile(Level.ROMu16(num + ((int) Level._obj.num == 120 ? 641357 : 641377)));
    }

    private static void Obj7AInit()
    {
    }

    private static void Obj7AMain()
    {
      int index = (int) Level._v != 0 ? ((int) Level._v + 1 == (int) Level._maxh ? ((int) Level._h != 0 ? ((int) Level._h + 1 == (int) Level._maxw ? ((int) Level.sTile == (int) Level.RAMu16(7570) || (int) Level.sTile == (int) Level.RAMu16(7572) || (int) Level.sTile == (int) Level.RAMu16(7574) ? ((int) Level.sTile != 0 ? (int) Level.ROMu16((((int) Level._h & 1) << 1) + 641817) : 7600) : ((int) Level.sTile == (int) Level.RAMu16(7562) || (int) Level.sTile == (int) Level.RAMu16(7594) ? 7588 : ((int) Level.sTile != (int) Level.RAMu16(7592) ? 7576 : (int) ushort.MaxValue))) : ((int) Level.sTile != 0 ? (int) Level.ROMu16((((int) Level._h & 1) << 1) + 641817) : 7600)) : ((int) Level.sTile == (int) Level.RAMu16(7572) || (int) Level.sTile == (int) Level.RAMu16(7574) || (int) Level.sTile == (int) Level.RAMu16(7576) ? ((int) Level.sTile != 0 ? (int) Level.ROMu16((((int) Level._h & 1) << 1) + 641817) : 7600) : ((int) Level.sTile == (int) Level.RAMu16(7568) || (int) Level.sTile == (int) Level.RAMu16(7596) ? 7590 : ((int) Level.sTile != (int) Level.RAMu16(7586) ? 7570 : (int) ushort.MaxValue)))) : ((int) Level._h != 0 ? ((int) Level._h + 1 == (int) Level._maxw ? ((int) Level.sTile == (int) Level.RAMu16(7562) || (int) Level.sTile == (int) Level.RAMu16(7564) || ((int) Level.sTile == (int) Level.RAMu16(7566) || (int) Level.sTile == (int) Level.RAMu16(7594)) ? (int) Level.ROMu16((((int) Level._h & 1) << 1) + 641692) : ((int) Level.sTile == (int) Level.RAMu16(7580) || (int) Level.sTile == (int) Level.RAMu16(7582) || (int) Level.sTile == (int) Level.RAMu16(7590) ? (int) ushort.MaxValue : ((int) Level.sTile != (int) Level.RAMu16(7598) ? (int) Level.ROMu16((((int) Level._h & 1) << 1) + 641755) : 7582))) : (int) Level.ROMu16((((int) Level._h & 1) << 1) + 641692)) : ((int) Level.sTile == (int) Level.RAMu16(7564) || (int) Level.sTile == (int) Level.RAMu16(7566) || ((int) Level.sTile == (int) Level.RAMu16(7568) || (int) Level.sTile == (int) Level.RAMu16(7596)) ? (int) Level.ROMu16((((int) Level._h & 1) << 1) + 641692) : ((int) Level.sTile == (int) Level.RAMu16(7580) || (int) Level.sTile == (int) Level.RAMu16(7582) || (int) Level.sTile == (int) Level.RAMu16(7588) ? (int) ushort.MaxValue : ((int) Level.sTile != (int) Level.RAMu16(7598) ? (int) Level.ROMu16((((int) Level._h & 1) << 1) + 641684) : 7580))))) : ((int) Level._h != 0 ? ((int) Level._h + 1 == (int) Level._maxw ? ((int) Level.sTile == (int) Level.RAMu16(7562) || (int) Level.sTile == (int) Level.RAMu16(7594) ? 7580 : ((int) Level.rTile(0, 1) == (int) Level.RAMu16(7582) ? (int) ushort.MaxValue : 7598)) : 7598) : ((int) Level.sTile == (int) Level.RAMu16(7568) || (int) Level.sTile == (int) Level.RAMu16(7596) ? 7582 : ((int) Level.rTile(0, 1) == (int) Level.RAMu16(7580) ? (int) ushort.MaxValue : 7598)));
      if ((int) (short) index < 0)
        return;
      Level.PutResizableTile(Level.RAMu16(index));
    }

    private static void Obj7BInit()
    {
      Level._vadj = ushort.MaxValue;
    }

    private static void Obj7BMain()
    {
      Level._vflag = (ushort) 1;
      int num;
      if ((int) Level._v == 0)
        num = (int) Level.sTile == (int) Level.RAMu16(7598) || (int) Level.sTileGroup != (int) Level.RAMu16(7562) ? 0 : (int) ushort.MaxValue;
      else if ((int) Level._v == 1)
      {
        num = 2;
        if ((int) Level._h + ((int) (short) Level._maxw < 0 ? -1 : 1) == (int) Level._maxw)
        {
          if ((int) Level.sTile != (int) Level.RAMu16(7598))
            num = 6;
          else
            goto label_24;
        }
        if ((int) Level.sTile == (int) Level.RAMu16(7260) || (int) Level.sTile == (int) Level.RAMu16(7262) || ((int) Level.sTile == (int) Level.RAMu16(7570) || (int) Level.sTile == (int) Level.RAMu16(7576)))
          num = 16;
        else if ((int) Level.sTile == (int) Level.RAMu16(7564) || (int) Level.sTile == (int) Level.RAMu16(7566) || ((int) Level.sTile == (int) Level.RAMu16(7580) || (int) Level.sTile == (int) Level.RAMu16(7582)))
          num = (int) ushort.MaxValue;
      }
      else if ((int) Level._v + 1 != (int) Level._maxh)
      {
        num = 8 + (((int) Level._h & 1) << 1);
        if ((int) Level._h + ((int) (short) Level._maxw < 0 ? -1 : 1) == (int) Level._maxw && (int) Level.sTile != (int) Level.RAMu16(7562) && ((int) Level.sTile != (int) Level.RAMu16(7594) && (int) Level.sTile != (int) Level.RAMu16(7568)) && ((int) Level.sTile != (int) Level.RAMu16(7596) && (int) Level.sTile != (int) Level.RAMu16(7564) && (int) Level.sTile != (int) Level.RAMu16(7566)))
        {
          if ((int) Level.sTile == (int) Level.RAMu16(7580) || (int) Level.sTile == (int) Level.RAMu16(7582))
            num = (int) ushort.MaxValue;
          else if ((int) Level.sTile == (int) Level.RAMu16(7598))
            num = 2;
          else
            num -= 4;
        }
      }
      else
      {
        num = 12 + (((int) Level._h & 1) << 1);
        if ((int) Level.sTile != (int) Level.RAMu16(7260) && (int) Level.sTile != (int) Level.RAMu16(7262) && ((int) Level.sTile != (int) Level.RAMu16(7570) && (int) Level.sTile != (int) Level.RAMu16(7572)) && ((int) Level.sTile != (int) Level.RAMu16(7574) && (int) Level.sTile != (int) Level.RAMu16(7576)))
          num -= 4;
        if ((int) Level._h + ((int) (short) Level._maxw < 0 ? -1 : 1) == (int) Level._maxw)
        {
          if ((int) Level.sTile == (int) Level.RAMu16(7260) || (int) Level.sTile == (int) Level.RAMu16(7262))
            num = 16;
          else if ((int) Level.sTileGroup != (int) Level.RAMu16(7562))
            num = 6;
        }
      }
label_24:
      if ((int) (short) num < 0)
        return;
      Level.PutResizableTile(Level.LDABank13(Level.ROMu16(num + ((int) (short) Level._maxw < 0 ? 641944 : 641962))));
    }

    private static void Obj7CInit()
    {
      Level._maxh = (ushort) (Level._maxw < 0 ? -Level._maxw : Level._maxw);
    }

    private static void Obj7CMain()
    {
      if ((int) Level._v == 0 && (int) Level._h != 0)
        --Level._maxh;
      int num;
      if ((int) Level._v + 1 == (int) Level._maxh)
      {
        if ((int) Level.sTile != (int) Level.RAMu16(7570) && (int) Level.sTile != (int) Level.RAMu16(7576) && (int) Level.sTileGroup == (int) Level.RAMu16(7562))
          return;
        num = 0;
      }
      else
        num = (int) Level._v + 2 != (int) Level._maxh ? ((int) Level._h & 1) << 1 ^ ((int) Level._v & 1) + 2 << 1 : 2;
      Level.PutResizableTile(Level.LDABank13(Level.ROMu16(num + ((int) (short) Level._maxw < 0 ? 642338 : 642346))));
    }

    private static void Obj7DInit()
    {
      Level._maxh = (ushort) 2;
    }

    private static void Obj7DMain()
    {
      Level.PutResizableTile(Level.LDABank13(Level.ROMu16((((int) Level.sTile == (int) Level.RAMu16(7562) || (int) Level.sTile == (int) Level.RAMu16(7594) || ((int) Level.sTile == (int) Level.RAMu16(7568) || (int) Level.sTile == (int) Level.RAMu16(7596)) ? 16 : 0) | ((int) Level._v != 0 ? 8 : 0) | ((int) Level._h == 0 ? 0 : ((int) Level._h + 1 != (int) Level._maxw ? ((int) Level._h & 1 ^ 1) + 1 << 1 : 6))) + ((int) Level.sTile == (int) Level.RAMu16(7564) || (int) Level.sTile == (int) Level.RAMu16(7566) ? 642487 : 642455))));
    }

    private static void Obj7FInit()
    {
      if ((int) Level._maxw < 2)
        Level._maxw = (ushort) 2;
      if ((int) Level._maxh >= 2)
        return;
      Level._maxh = (ushort) 2;
    }

    private static unsafe void Obj7FMain()
    {
      if ((int) Level.sTile == 0)
        return;
      if ((int) Level.sTileGroup == (int) Level.RAMu16(7136))
      {
        Level.PutResizableTile(Level.LDABank13(Level.ROMu16(Level.hindex + ((int) Level._v == 0 ? 0 : ((int) Level._v + 1 != (int) Level._maxh ? 6 : 12)) + ((int) Level.sTile == (int) Level.RAMu16(7180) || (int) Level.sTile == (int) Level.RAMu16(7182) ? 643012 : 642994))));
      }
      else
      {
        if ((int) Level.sTileGroup != (int) Level.RAMu16(7562))
          return;
        ushort tile = Level.LDABank13(*(ushort*) ((IntPtr) Level.GetBank13Ptr((int) Level.ROMu16(Level.vindex + ((int) Level._h == 0 ? 0 : ((int) Level._h + 1 != (int) Level._maxw ? 6 : 12)) + 642612)) + (byte) Level.sTile * 2));
        if ((int) (short) tile < 0)
          return;
        Level.PutResizableTile(tile);
      }
    }

    private static void Obj80Init()
    {
      Level._maxh = (ushort) (Level._maxw < 0 ? -Level._maxw : Level._maxw);
    }

    private static void Obj80Main()
    {
      if ((int) Level._v == 0 && (int) Level._h != 0)
        --Level._maxh;
      int num = (int) Level._v + 1 != (int) Level._maxh ? ((int) Level._v + 2 != (int) Level._maxh ? ((int) Level.sTile == 0 || (int) Level.sTileGroup == (int) Level.RAMu16(7562) ? (int) Level.RAMu16((int) Level.ROMu16((((int) Level._h & 1) << 1) + 643220)) : (int) ushort.MaxValue) : (int) Level.RAMu16((int) (short) Level._maxw < 0 ? 7588 : 7590)) : ((int) Level.sTileGroup != (int) Level.RAMu16(7562) ? (int) Level.RAMu16((int) (short) Level._maxw < 0 ? 7586 : 7592) : (int) ushort.MaxValue);
      if ((int) (short) num < 0)
        return;
      Level.PutResizableTile((ushort) num);
    }

    private static void Obj81Init()
    {
      Level._maxh = (ushort)( Level._maxw < 0 ? -Level._maxw : Level._maxw);
      Level._vadj = ushort.MaxValue;
      Level._vflag = (ushort) 1;
    }

    private static void Obj81Main()
    {
      int num = (int) Level._v != 0 ? ((int) Level._v != 1 ? ((int) Level.sTile == 0 || (int) Level.sTileGroup == (int) Level.RAMu16(7562) ? (int) Level.RAMu16((int) Level.ROMu16((((int) Level._h & 1) << 1) + 643220)) : (int) ushort.MaxValue) : (int) Level.RAMu16((int) (short) Level._maxw < 0 ? 7580 : 7582)) : ((int) Level.sTileGroup != (int) Level.RAMu16(7562) ? (int) Level.RAMu16((int) (short) Level._maxw < 0 ? 7578 : 7584) : (int) ushort.MaxValue);
      if ((int) (short) num < 0)
        return;
      Level.PutResizableTile((ushort) num);
    }

    private static void Obj82Init()
    {
    }

    private static void Obj82Main()
    {
      if (((int) Level._obj.num & 1) != 0 && ((int) Level._h & 1) != 0)
        return;
      Level.PutResizableTile((ushort) 41984);
    }

    private static void Obj84Init()
    {
      Level._vadj = ushort.MaxValue;
      Level._vflag = ushort.MaxValue;
    }

    private static void Obj84Main()
    {
      if (((int) Level._h & 1) != 0)
        return;
      Level.PutResizableTile((ushort) 41984);
    }

    private static void Obj85Init()
    {
    }

    private static void Obj85Main()
    {
      if ((int) Level._h != 0 && (int) Level._v == 0)
      {
        Level._maxh -= (ushort) 2;
        if ((int) (short) Level._maxh <= 0)
          Level._maxh = (ushort) 1;
      }
      if ((int) Level._h == 0)
        Level.Obj67ReplaceTile(-1, 0, 639380);
      int num = (int) Level._maxh - (int) Level._v - 1;
      if (num >= 2)
      {
        Level.code13C15F();
        if ((int) Level._h + 1 != (int) Level._maxw)
          return;
        Level.Obj67ReplaceTile(1, 0, 639503);
      }
      else
      {
        Level.PutResizableTile(Level.LDABank13(Level.ROMu16((num << 1) + 643372)));
        if (num == 0)
        {
          if ((int) Level.rTile(0, 1) == (int) Level.RAMu16(7172))
            Level.PutrResizableTile(0, 1, Level.RAMu16(7470));
          if ((int) Level.rTile(-1, 1) != (int) Level.RAMu16(7172))
            return;
          Level.PutrResizableTile(-1, 1, Level.RAMu16(7468));
        }
        else
        {
          if ((int) Level._h + 1 != (int) Level._maxw)
            return;
          Level.PutrResizableTile(1, 0, Level.RAMu16(7470));
        }
      }
    }

    private static void Obj86Init()
    {
      Level._maxh = (int) (short) ((int) Level._maxh - (int) Level._maxw) <= 0 ? (ushort) 1 : (ushort) ((int) Level._maxh - (int) Level._maxw);
    }

    private static void Obj86Main()
    {
      if ((int) Level._h != 0 && (int) Level._v == 0)
        Level._maxh += (ushort) 2;
      if ((int) Level._h + 1 == (int) Level._maxw)
        Level.Obj67ReplaceTile(1, 0, 639503);
      int num = (int) Level._maxh - (int) Level._v - 1;
      if (num >= 2)
      {
        Level.code13C15F();
        if ((int) Level._h != 0)
          return;
        Level.Obj67ReplaceTile(-1, 0, 639380);
      }
      else
      {
        Level.PutResizableTile(Level.LDABank13(Level.ROMu16((num << 1) + 643500)));
        if (num != 0)
          return;
        if ((int) Level.rTile(0, 1) == (int) Level.RAMu16(7172))
          Level.PutrResizableTile(0, 1, Level.RAMu16(7468));
        if ((int) Level._h + 1 != (int) Level._maxw || (int) Level.rTile(1, 1) != (int) Level.RAMu16(7172))
          return;
        Level.PutrResizableTile(1, 1, Level.RAMu16(7470));
      }
    }

    private static void Obj87Init()
    {
    }

    private static void Obj87Main()
    {
      if ((int) Level._v >= 2)
      {
        Level.Obj01MainCode2();
      }
      else
      {
        int num = (int) Level._h != 0 ? 2 : 0;
        if (((int) Level._h == 0 || (int) Level._h + 1 == (int) Level._maxw) && ((int) Level.sTile == (int) Level.RAMu16(7260) || (int) Level.sTile == (int) Level.RAMu16(7262) || ((int) Level.sTile == (int) Level.RAMu16(7350) || (int) Level.sTile == (int) Level.RAMu16(7352))))
        {
          if ((int) Level._v != 0)
            Level.PutResizableTile(Level.ROMu16((num | 4) + 643670));
          else
            Level.PutResizableTile(Level.LDABank13(Level.ROMu16(num + 643670)));
        }
        else if ((int) Level._v == 0)
        {
          if ((int) Level.sTile != (int) Level.RAMu16(7260) && (int) Level.sTile != (int) Level.RAMu16(7262))
            return;
          Level.PutResizableTile((ushort) 0);
        }
        else
          Level.PutResizableTile(Level.ROMu16((Level.random & 6 | (int) Level._obj.num & 8) + 643654));
      }
    }

    private static void Obj89Init()
    {
    }

    private static void Obj89Main()
    {
      if ((int) Level._maxh == 1)
      {
        if ((int) Level._maxw == 1)
          Level.PutResizableTile((ushort) 29197);
        else
          Level.PutResizableTile(Level.ROMu16(Level.hindex + 643845));
      }
      else if ((int) Level._maxw == 1)
        Level.PutResizableTile(Level.ROMu16(((int) Level._v == 0 ? 0 : ((int) Level._v + 1 == (int) Level._maxh ? (((int) Level._v + 1 & 1) << 1) + 2 : 6)) + 643868));
      else
        Level.PutResizableTile(Level.ROMu16(((int) Level._v == 0 ? 0 : ((int) Level._v + 1 != (int) Level._maxh ? (((int) Level._v & 1) != 0 ? 6 : 12) : 18)) + Level.hindex + 643900));
    }

    private static void Obj8CInit()
    {
      Level._maxh = (ushort) 3;
    }

    private static void Obj8CMain()
    {
      if ((int) Level._v >= 2)
      {
        if ((int) Level.sTile == 199 || (int) Level.sTile == 194)
          Level.PutResizableTile((ushort) 198);
        else if ((int) Level.sTile == 197)
        {
          Level.PutResizableTile((ushort) 213);
        }
        else
        {
          if ((int) Level.sTile != 195 || (int) Level._h == 0)
            return;
          Level.PutResizableTile((ushort) 198);
        }
      }
      else
      {
        if (182 <= (int) Level.sTile && (int) Level.sTile < 186)
          return;
        Level.PutResizableTile(Level.ROMu16(((int) Level._v << 2 | ((int) Level._h & 1) << 1) + 643964));
      }
    }

    private static void Obj8DInit()
    {
    }

    private static void Obj8DMain()
    {
      Level.PutResizableTile(Level.ROMu16(((int) Level._v + 1 == (int) Level._maxh ? 4 : (Level.random & 1) << 1) + 644071));
    }

    private static void Obj8EInit()
    {
      Level._maxw = (ushort) ((int) Level._maxw + 1 & 65534);
      Level._maxh = (ushort) 2;
    }

    private static void Obj8EMain()
    {
      Level.PutResizableTile(Level.ROMu16((((int) Level._h & 1) << 1 | (int) Level._v << 2) + 644116));
    }

    private static void Obj8FInit()
    {
      Level._vadj = ushort.MaxValue;
    }

    private static void Obj8FMain()
    {
      if ((int) Level._v >= 3)
        return;
      int num1 = (int) Level._v << 2 | ((int) (short) Level._maxw < 0 ? 2 : 0);
      int num2 = (int) Level.sTile == 0 || (int) Level.sTile == (int) Level.RAMu16(6668) || (int) Level.sTile == (int) Level.RAMu16(6680) ? 0 : ((int) Level.sTile == (int) Level.RAMu16(7260) || (int) Level.sTile == (int) Level.RAMu16(7262) ? 1 : ((int) Level.sTile == 15792 || (int) Level.sTile == 15793 || ((int) Level.sTile == 15801 || (int) Level.sTile == 15802) ? 2 : 3));
      int num3;
      if ((int) Level._h == 0)
      {
        Level._vflag = (ushort) 0;
        if ((int) Level._v >= 2)
        {
          num3 = 0;
        }
        else
        {
          if (num2 != 0)
            num1 += 4;
          num3 = (int) Level._v == 0 ? (int) Level.LDABank13(Level.ROMu16(num1 + 644153)) : (int) Level.ROMu16(num1 + 644153);
        }
      }
      else if (((int) Level._h & 1) != 0)
      {
        Level._vflag = (ushort) 0;
        if ((int) Level._v >= 2 || num2 >= 2)
        {
          num3 = 0;
        }
        else
        {
          if (num2 != 0)
            num1 += 8;
          num3 = (int) Level._v == 0 ? (int) Level.LDABank13(Level.ROMu16(num1 + 644165)) : (int) Level.ROMu16(num1 + 644165);
        }
      }
      else
      {
        Level._vflag = (ushort) 1;
        num3 = num2 != 0 ? (num2 != 1 ? ((int) Level._v == 0 ? (int) Level.LDABank13((ushort) 0) : 0) : ((int) Level._v == 0 ? (int) Level.LDABank13(Level.ROMu16(num1 + 644193)) : (int) Level.ROMu16(num1 + 644193))) : ((int) Level._v == 0 ? (int) Level.LDABank13(Level.ROMu16(num1 + 644181)) : (int) Level.ROMu16(num1 + 644181));
      }
      if (num3 == 0)
        return;
      Level.PutResizableTile((ushort) num3);
    }

    private static void Obj90Init()
    {
      Level._vadj = ushort.MaxValue;
    }

    private static void Obj90Main()
    {
      if ((int) Level._v >= 3)
        return;
      Level._vflag = (ushort) 1;
      int num1 = (int) Level._v << 2 | ((int) (short) Level._maxw < 0 ? 2 : 0);
      int num2;
      if ((int) Level._h == 0)
      {
        Level._vflag = (ushort) 0;
        if ((int) Level.sTile != 0)
        {
          if ((int) Level.sTile != (int) Level.RAMu16(7260) && (int) Level.sTile != (int) Level.RAMu16(7262))
            return;
          num1 += 4;
        }
        num2 = (int) Level._v < 2 ? ((int) Level._v == 0 ? (int) Level.LDABank13(Level.ROMu16(num1 + 644444)) : (int) Level.ROMu16(num1 + 644444)) : 0;
      }
      else
        num2 = (int) Level.sTile == 0 ? ((int) Level._v == 0 ? (int) Level.LDABank13(Level.ROMu16(num1 + 644456)) : (int) Level.ROMu16(num1 + 644456)) : ((int) Level.sTile == (int) Level.RAMu16(7260) || (int) Level.sTile == (int) Level.RAMu16(7262) ? ((int) Level._v == 0 ? (int) Level.LDABank13(Level.ROMu16(num1 + 644571)) : (int) Level.ROMu16(num1 + 644571)) : 0);
      if (num2 == 0)
        return;
      Level.PutResizableTile((ushort) num2);
    }

    private static void Obj91Init()
    {
      Level._maxw = (ushort) 3;
      --Level._x;
    }

    private static void Obj91Main()
    {
      if ((int) Level._v < 2)
      {
        Level.PutResizableTile(Level.ROMu16(((int) Level._v << 3 | (int) Level._h << 1) + 644620));
      }
      else
      {
        if ((int) Level._h == 0 || (int) Level._h + 1 == (int) Level._maxw)
          return;
        if ((int) Level._v + 1 != (int) Level._maxh)
          Level.PutResizableTile((ushort) 15794);
        else if ((int) Level.sTile == (int) Level.RAMu16(6662))
          Level.PutResizableTile(Level.RAMu16(6666));
        else if ((int) Level.sTile == (int) Level.RAMu16(6700))
          Level.PutResizableTile(Level.RAMu16(6704));
        else
          Level.PutResizableTile((ushort) 15788);
      }
    }

    private static void Obj92Main()
    {
      if ((int) Level._v < 2)
      {
        Level.PutResizableTile(Level.ROMu16(((int) Level._v << 3 | (int) Level._h << 1) + 644711));
      }
      else
      {
        if ((int) Level._h == 0 || (int) Level._h + 1 == (int) Level._maxw)
          return;
        if ((int) Level._v + 1 != (int) Level._maxh)
          Level.PutResizableTile((ushort) 15795);
        else if ((int) Level.sTile == (int) Level.RAMu16(6686))
          Level.PutResizableTile(Level.RAMu16(6682));
        else if ((int) Level.sTile == (int) Level.RAMu16(6742))
          Level.PutResizableTile(Level.RAMu16(6738));
        else
          Level.PutResizableTile((ushort) 15789);
      }
    }

    private static void Obj93Init()
    {
      Level._maxw = (ushort) 4;
      --Level._x;
    }

    private static void Obj93Main()
    {
      if ((int) Level._v < 2)
      {
        if ((int) Level.ROMu16(((int) Level._v << 3 | (int) Level._h << 1) + 644802) == 0)
          return;
        Level.PutResizableTile(Level.ROMu16(((int) Level._v << 3 | (int) Level._h << 1) + 644802));
      }
      else
      {
        if ((int) Level._h == 0 || (int) Level._h + 1 == (int) Level._maxw)
          return;
        if ((int) Level._v + 1 == (int) Level._maxh)
        {
          Level.PutResizableTile((ushort) (((int) Level._h + 1 & 1) + 15830));
        }
        else
        {
          if ((int) Level._h >= 2)
            return;
          Level.PutResizableTile((ushort) 15829);
        }
      }
    }

    private static void Obj94Init()
    {
      Level._maxw = (ushort) ((int) Level._maxw + 1 & 65534);
      Level._maxh = (ushort) ((int) Level._maxh + 1 & 65534);
    }

    private static void Obj94Main()
    {
      Level.PutResizableTile(Level.ROMu16((((int) Level._obj.num & 3) << 3 | ((int) Level._h & 1) << 1 | ((int) Level._v & 1) << 2) + 644889));
    }

    private static void Obj98Init()
    {
    }

    private static void Obj98Main()
    {
      if ((int) Level._v == 0)
        Level.PutResizableTile(Level.ROMu16((((int) Level._h & 1) << 1) + 645008));
      else if ((int) Level._v == 1)
      {
        if ((int) Level._maxw == 1)
          Level.PutResizableTile((ushort) 30724);
        else
          Level.PutResizableTile(Level.ROMu16(((int) Level._h + 1 == (int) Level._maxw ? 6 : (((int) Level._h & 1) << 1) + ((int) Level._h != 0 ? 2 : 0)) + 645016));
      }
      else
        Level.PutResizableTile(Level.ROMu16((((int) Level._h + (int) Level._v & 1) << 1) + 645054));
    }

    private static void Obj99Init()
    {
      Level._maxw = (ushort) 3;
      --Level._x;
    }

    private static void Obj99Main()
    {
      if ((int) Level._v >= 2)
      {
        if ((int) Level._h == 0 || (int) Level._h + 1 == (int) Level._maxw)
          return;
        Level.Obj01MainCode2();
      }
      else
        Level.PutResizableTile(Level.ROMu16(((int) Level._v << 3 | (int) Level._h << 1) + 645072));
    }

    private static void Obj9AInit()
    {
      Level._ushort = (ushort) (Level.random2 & 3);
      Level._byte = (byte) (((int) Level._ushort ^ 3) << 1);
      Level._maxw = (ushort) 4;
      Level._x -= (byte) 2;
    }

    private static void Obj9AMain()
    {
      int num1 = ((int) Level._v & 1) << 3;
      int num2;
      if (((int) Level._maxh & 1) != 0)
      {
        if ((int) Level._v < 2)
        {
          if ((num2 = (int) Level.ROMu16(((int) Level._h << 1 | num1) + 645133)) != 0)
            num2 += (int) Level._ushort << 2;
        }
        else
          num2 = (int) Level._v + 1 != (int) Level._maxh ? (((int) Level._v & 1) != 0 ? ((int) Level._h != 2 ? 0 : (int) Level.ROMu16((int) Level._byte + 645173)) : ((int) Level._h != 2 ? 0 : (int) Level.ROMu16((int) Level._byte + 645165))) : ((int) Level._h != 2 ? 0 : (int) Level.ROMu16((int) Level._byte + 645181));
      }
      else if ((int) Level._v < 2)
      {
        if ((num2 = (int) Level.ROMu16(((int) Level._h << 1 | num1) + 645149)) != 0)
          num2 += (int) Level._ushort << 2;
      }
      else
        num2 = (int) Level._v + 1 != (int) Level._maxh ? (((int) Level._v & 1) != 0 ? ((int) Level._h != 1 ? 0 : (int) Level.ROMu16((int) Level._byte + 645165)) : ((int) Level._h != 1 ? 0 : (int) Level.ROMu16((int) Level._byte + 645173))) : ((int) Level._h != 1 ? 0 : (int) Level.ROMu16((int) Level._byte + 645181));
      if (num2 == 0)
        return;
      Level.PutResizableTile((ushort) num2);
    }

    private static void Obj9BInit()
    {
      Level._ushort = (ushort) ((Level.random2 & 3) << 1);
      Level._byte = (byte) ((uint) Level._ushort ^ 6U);
    }

    private static void Obj9BMain()
    {
      int num = ((int) Level._maxh & 1) != 0 ? ((int) Level._v != 0 ? ((int) Level._v + 1 != (int) Level._maxh ? (((int) Level._v & 1) == 0 ? (int) Level.ROMu16((int) Level._byte + 645165) : (int) Level.ROMu16((int) Level._byte + 645173)) : (int) Level.ROMu16((int) Level._byte + 645181)) : (int) Level.ROMu16((int) Level._ushort + 645437)) : ((int) Level._v != 0 ? ((int) Level._v + 1 != (int) Level._maxh ? (((int) Level._v & 1) == 0 ? (int) Level.ROMu16((int) Level._byte + 645173) : (int) Level.ROMu16((int) Level._byte + 645165)) : (int) Level.ROMu16((int) Level._byte + 645181)) : (int) Level.ROMu16((int) Level._ushort + 645429));
      if (num == 0)
        return;
      Level.PutResizableTile((ushort) num);
    }

    private static void Obj9CMain()
    {
      int num = ((int) Level._maxh & 1) != 0 ? ((int) Level._v != 0 ? ((int) Level._v != 1 ? ((int) Level._v + 1 != (int) Level._maxh ? (((int) Level._v & 1) == 0 ? (int) Level.ROMu16((int) Level._byte + 645165) : (int) Level.ROMu16((int) Level._byte + 645173)) : (int) Level.ROMu16((int) Level._byte + 645181)) : (int) Level.ROMu16((int) Level._ushort + 645568)) : (int) Level.ROMu16((int) Level._ushort + 645560)) : ((int) Level._v != 0 ? ((int) Level._v != 1 ? ((int) Level._v + 1 != (int) Level._maxh ? (((int) Level._v & 1) == 0 ? (int) Level.ROMu16((int) Level._byte + 645173) : (int) Level.ROMu16((int) Level._byte + 645165)) : (int) Level.ROMu16((int) Level._byte + 645181)) : (int) Level.ROMu16((int) Level._ushort + 645552)) : (int) Level.ROMu16((int) Level._ushort + 645544));
      if (num == 0)
        return;
      Level.PutResizableTile((ushort) num);
    }

    private static void Obj9DInit()
    {
    }

    private static void Obj9DMain()
    {
      if ((int) Level._v == 0)
        Level.PutResizableTile(Level.ROMu16(Level.hindex + 645649));
      else if ((int) Level._v + 1 == (int) Level._maxh)
        Level.PutResizableTile(Level.ROMu16(Level.hindex + ((int) Level.sTile == (int) Level.RAMu16(7260) || (int) Level.sTile == (int) Level.RAMu16(7262) ? 6 : 0) + 645667));
      else if (((int) Level._v & 1) != 0)
        Level.PutResizableTile(Level.ROMu16(Level.hindex + 645655));
      else
        Level.PutResizableTile(Level.ROMu16(Level.hindex + 645661));
    }

    private static void Obj9EInit()
    {
    }

    private static void Obj9EMain()
    {
      Level.PutResizableTile((ushort) 29954);
    }

    private static void Obj9FInit()
    {
      Level._maxh = (ushort) 2;
      Level._maxw = (ushort) ((int) Level._maxw + 1 & 65534);
    }

    private static void Obj9FMain()
    {
      if (((int) Level._h & 2) != 0)
        return;
      Level.PutResizableTile(Level.ROMu16((((int) Level._h & 1) << 1 | ((int) Level._v & 1) << 2) + 645788));
    }

    private static void ObjA0Init()
    {
      Level._ushort = (ushort) (((int) Level._obj.num & 15) << 1);
      Level._maxw = (ushort) ((int) Level._maxw + 1 & 65534);
    }

    private static void ObjA0Main()
    {
      Level.PutResizableTile((ushort) ((uint) Level.ROMu16((((int) Level._h & 1) << 1) + 645832) + (uint) Level._ushort));
    }

    private static void ObjA3Init()
    {
      Level._ushort = (ushort) ((uint) Level._obj.num & 4U);
      Level._maxw = (ushort) ((int) Level._maxw + 1 & 65534);
      Level._maxh = (ushort) ((int) Level._maxh + 1 & 65534);
    }

    private static void ObjA3Main()
    {
      Level.PutResizableTile((ushort) ((uint) Level.ROMu16((((int) Level._h & 1) << 1 | ((int) Level._v & 1) << 2) + 645860) + (uint) Level._ushort));
    }

    private static void ObjA5Init()
    {
      Level._ushort = (ushort) ((uint) Level._obj.num & 2U);
      if ((int) Level._ushort != 0)
        Level._maxh = (int) Level._sheader[1] == 3 ? Level.ROMu16((int) Level._ushort + 597676) : (ushort) 2;
      else
        Level._maxw = (int) Level._sheader[1] == 3 ? Level.ROMu16((int) Level._ushort + 597676) : (ushort) 2;
    }

    private static void ObjA5Main()
    {
      if ((int) Level._sheader[1] != 3)
      {
        if ((int) Level._v == 0)
        {
          if ((int) Level.sTile != 0 && (int) Level.sTile != 5632)
            return;
          Level.PutResizableTile(Level.ROMu16((((int) Level._h & 1) << 1) + 645966));
        }
        else if ((int) Level._v + 1 != (int) Level._maxh)
        {
          Level.PutResizableTile(Level.ROMu16((((int) Level._h & 1) << 1 | ((int) Level._v & 1) << 2) + 645990));
        }
        else
        {
          if ((int) Level.sTile != 0 && (int) Level.sTile != 5632)
            return;
          Level.PutResizableTile(Level.ROMu16((((int) Level._h & 1) << 1) + 646012));
        }
      }
      else
        Level.PutResizableTile((ushort) ((uint) Level.ROMu16(((int) Level._v == 0 ? 0 : ((int) Level._v + 1 == (int) Level._maxh ? 2 : ((int) Level._v + 2 == (int) Level._maxh ? 4 : 6))) + 646232) + (uint) Level._h));
    }

    private static void ObjA6Main()
    {
      if ((int) Level._sheader[1] != 3)
      {
        if ((int) Level._h == 0)
        {
          if ((int) Level.sTile != 0 && (int) Level.sTile != 5632)
            return;
          Level.PutResizableTile(Level.ROMu16((((int) Level._v & 1) << 1) + 646072));
        }
        else if ((int) Level._h + 1 != (int) Level._maxw)
        {
          Level.PutResizableTile(Level.ROMu16((((int) Level._h & 1) << 1 | ((int) Level._v & 1) << 2) + 646096));
        }
        else
        {
          if ((int) Level.sTile != 0 && (int) Level.sTile != 5632)
            return;
          Level.PutResizableTile(Level.ROMu16((((int) Level._v & 1) << 1) + 646119));
        }
      }
      else if ((int) Level._h == 0)
        Level.PutResizableTile(Level.ROMu16(((int) Level._v << 1) + 646174));
      else if ((int) Level._h + 1 != (int) Level._maxw)
        Level.PutResizableTile(Level.ROMu16(((int) Level._v << 2 | ((int) Level._h & 1) << 1) + 646186));
      else
        Level.PutResizableTile(Level.ROMu16(((int) Level._v << 1) + 646220));
    }

    private static void ObjA7Init()
    {
      --Level._x;
      --Level._srcy;
      Level._maxw += (ushort) 2;
      Level._maxh += (ushort) 2;
    }

    private static void ObjA7Main()
    {
      int num = (int) Level.ROMu16(Level.hindex + ((int) Level._v == 0 ? 0 : ((int) Level._v + 1 != (int) Level._maxh ? 6 : 12)) + 646271);
      if (num == 0)
        return;
      if ((int) Level.sTile == 0 || num == 31744)
      {
        Level.PutResizableTile((ushort) num);
      }
      else
      {
        if ((int) (ushort) ((int) Level.sTile - 30588 - 1) >= 15)
          return;
        Level.PutResizableTile((ushort) ((num - 30588 | (int) Level.sTile - 30588) + 30588));
      }
    }

    private static void ObjA8Main()
    {
      int num1 = (int) Level.ROMu16(Level.hindex + ((int) Level._v == 0 ? 0 : ((int) Level._v + 1 != (int) Level._maxh ? 6 : 12)) + 646271);
      switch (num1)
      {
        case 0:
          break;
        case 31744:
          int num2 = (int) Level.rTile(0, -1) == 31744 ? 8 : 0;
          if ((int) Level._v + 2 == (int) Level._maxh && (int) Level.rTile(0, 1) == 31744)
            num2 |= 4;
          if ((int) Level.rTile(-1, 0) == 31744)
            num2 |= 1;
          if ((int) Level._h + 2 == (int) Level._maxw && (int) Level.rTile(1, 0) == 31744)
            num2 |= 2;
          Level.PutResizableTile(num2 != 0 ? (ushort) (num2 + 30588) : (ushort) 0);
          break;
        default:
          if ((int) Level.sTile == 31744)
            break;
          int num3 = (int) (ushort) ((uint) Level.sTile - 30588U);
          if ((int) (ushort) (num3 - 1) >= 15 || (num1 - 30588 & num3) == 0)
            break;
          Level.PutResizableTile((num1 - 30588 ^ num3) != 0 ? (ushort) ((num1 - 30588 ^ num3) + 30588) : (ushort) 0);
          break;
      }
    }

    private static void ObjA9Init()
    {
      if ((int) Level._sheader[1] != 3)
        return;
      Level._maxw = (ushort) 2;
    }

    private static void ObjA9Main()
    {
      if ((int) Level._sheader[1] != 3)
      {
        if ((int) Level.sTile == 0)
        {
          Level.PutResizableTile((ushort) 131);
        }
        else
        {
          if ((int) Level.sTile != (int) Level.RAMu16(7260) && (int) Level.sTile != (int) Level.RAMu16(7262))
            return;
          Level.PutResizableTile(Level.RAMu16(7288));
        }
      }
      else
      {
        if ((int) Level._v == 0)
          Level._ushort = (ushort) 0;
        if ((int) Level._v < 4)
          Level.PutResizableTile((ushort) ((uint) Level.ROMu16(((int) Level._v << 1) + 646682) + (uint) Level._h));
        else if ((int) Level._maxh - (int) Level._v - 1 >= 3)
          Level.PutResizableTile((ushort) ((uint) Level.ROMu16((int) (Level._ushort = (ushort) (((int) Level._ushort + 2) % 6)) + 646699) + (uint) Level._h));
        else
          Level.PutResizableTile((ushort) ((uint) Level.ROMu16(((int) Level._maxh - (int) Level._v - 1 << 1) + 646725) + (uint) Level._h));
      }
    }

    private static void ObjAAInit()
    {
      Level._maxw = (ushort) 2;
    }

    private static void ObjAAMain()
    {
      ushort u = Level.ROMu16((((int) Level._h & 1) << 1 | ((int) Level._v & 1) << 2) + ((int) Level._obj.num == 170 ? 646908 : 646984));
      Level.code13E0F4(ref u, (int) Level._v < 2 ? 0 : ((int) Level._maxh - (int) Level._v - 1 < 2 ? 1 : 2));
      Level.PutResizableTile(u);
    }

    private static unsafe void code13E0F4(ref ushort u, int i)
    {
      if ((int) Level.sTile == 0)
        return;
      int num1 = 0;
      while (num1 < 32)
      {
        if ((int) u == (int) Level.ROMu16(num1 + 647060))
        {
          ushort* numPtr1 = (ushort*) Level.GetBank13Ptr((int) Level.ROMu16((num1 >> 1 & 14) + 647092) + 14);
          ushort* numPtr2 = (ushort*) Level.GetBank13Ptr((int) Level.ROMu16((num1 >> 1 & 14) + 647108));
          int num2 = 14;
          while (num2 >= 0)
          {
            if ((int) Level.sTile == (int) *numPtr1--)
            {
              if ((int) numPtr2[num2 & 12 | i] == (int) ushort.MaxValue)
                break;
              u = (int) numPtr2[num2 & 12 | i] != 0 ? numPtr2[num2 & 12 | i] : Level.sTile;
            }
            num2 -= 2;
          }
          return;
        }
        else
          num1 += 2;
      }
      throw new NotImplementedException();
    }

    private static void ObjACInit()
    {
      if ((int) Level._sheader[1] != 11)
        return;
      Level._maxh = (ushort) 2;
    }

    private static void ObjACMain()
    {
      if ((int) Level._obj.num == 172 && (int) Level._sheader[1] != 11)
      {
        Level.PutResizableTile(Level.ROMu16((Level.random & 6) + 601079));
      }
      else
      {
        ushort u = Level.ROMu16((((int) Level._h & 1) << 1 | ((int) Level._v & 1) << 2) + ((int) Level._obj.num == 172 ? 646745 : 646832));
        Level.code13E0F4(ref u, (int) Level._h < 2 ? 0 : ((int) Level._maxw - (int) Level._h - 1 < 2 ? 1 : 2));
        Level.PutResizableTile(u);
      }
    }

    private static void ObjAEInit()
    {
      if ((int) Level._obj.num == 174)
        Level._maxw = (ushort) 2;
      else
        Level._maxh = (ushort) 2;
    }

    private static void ObjAEMain()
    {
      Level.PutResizableTile(Level.ROMu16((((int) Level._h & 1) << 1 | ((int) Level._v & 1) << 2) + ((int) Level._obj.num == 174 ? 647488 : 647528)));
    }

    private static void ObjB0Init()
    {
    }

    private static void ObjB0Main()
    {
      if ((int) Level.sTile != 0)
        return;
      Level.PutResizableTile(Level.ROMu16(((int) Level._h == 0 ? 0 : ((int) Level._h + 1 != (int) Level._maxw ? (((int) Level._h + 1 & 1) << 1) + 2 : 6)) + ((int) Level._v == 0 ? 0 : ((int) Level._v + 1 != (int) Level._maxh ? (((int) Level._v & 1) << 3) + 8 : 24)) + 647568));
    }

    private static void ObjB1Init()
    {
    }

    private static void ObjB1Main()
    {
      if ((int) Level.sTile >= 30649)
      {
        int num = 0;
        while (num < 24)
        {
          if ((int) Level.sTile == (int) Level.ROMu16(num + 647678))
          {
            Level.PutResizableTile(Level.ROMu16(num + 647702));
            break;
          }
          else
            num += 2;
        }
      }
      else
        Level.PutResizableTile(Level.ROMu16(((int) Level.sTile - 30649 & 14) + 647726));
    }

    private static void ObjB2Init()
    {
      Level._vflag = Level._vadj = ushort.MaxValue;
      Level._maxh = (ushort) 3;
    }

    private static void ObjB2Main()
    {
      if ((int) Level.sTile != 0)
        return;
      Level.PutResizableTile(Level.ROMu16(((int) Level._v << 1) + 647801));
    }

    private static void ObjB3Main()
    {
      if ((int) Level.sTile != 0)
        return;
      Level.PutResizableTile(Level.ROMu16(((int) Level._v << 1) + 647836));
    }

    private static void ObjB4Init()
    {
      Level._vflag = Level._vadj = ushort.MaxValue;
      Level._maxh = (ushort) 4;
    }

    private static void ObjB5Main()
    {
      if ((int) Level.sTile != 0)
        return;
      Level.PutResizableTile(Level.ROMu16(((int) Level._v << 1) + 647869));
    }

    private static void ObjB6Main()
    {
      if ((int) Level.sTile != 0)
        return;
      if ((int) Level.ROMu16(((int) Level._v << 1) + 647904) == 23308 && ((int) Level.rTile(0, 1) == 30623 || (int) Level.rTile(0, 1) == 30624))
        Level.PutResizableTile((ushort) 23309);
      else
        Level.PutResizableTile(Level.ROMu16(((int) Level._v << 1) + 647904));
    }

    private static void ObjB7Main()
    {
      if ((int) Level.sTile != 0)
        return;
      if ((int) Level.ROMu16(((int) Level._v << 1) + 647975) == 2606 && ((int) Level.rTile(0, -1) == 30617 || (int) Level.rTile(0, -1) == 30618))
        Level.PutResizableTile((ushort) 2607);
      else
        Level.PutResizableTile(Level.ROMu16(((int) Level._v << 1) + 647975));
    }

    private static void ObjB9Main()
    {
      if ((int) Level.sTile != 0)
        return;
      if ((int) Level.ROMu16(((int) Level._v << 1) + 648044) == 2606 && ((int) Level.rTile(0, -1) == 30617 || (int) Level.rTile(0, -1) == 30618))
        Level.PutResizableTile((ushort) 2607);
      else
        Level.PutResizableTile(Level.ROMu16(((int) Level._v << 1) + 648044));
    }

    private static void ObjBAInit()
    {
    }

    private static void ObjBAMain()
    {
      Level.PutResizableTile(Level.ROMu16(((int) Level._h == 0 ? 0 : ((int) Level._h + 1 != (int) Level._maxw ? (((int) Level._h + 1 & 1) << 1) + 2 : 6)) + 648115));
    }

    private static void ObjBBMain()
    {
      Level.PutResizableTile(Level.ROMu16(((int) Level._h == 0 ? 0 : ((int) Level._h + 1 != (int) Level._maxw ? (((int) Level._h + 1 & 1) << 1) + 2 : 6)) + 648162));
    }

    private static void ObjBCMain()
    {
      Level.PutResizableTile(Level.ROMu16(((int) Level._v == 0 ? 0 : ((int) Level._v + 1 != (int) Level._maxh ? (((int) Level._v + 1 & 1) << 1) + 2 : 6)) + 648256));
    }

    private static void ObjBDMain()
    {
      Level.PutResizableTile(Level.ROMu16(((int) Level._v == 0 ? 0 : ((int) Level._v + 1 != (int) Level._maxh ? (((int) Level._v + 1 & 1) << 1) + 2 : 6)) + 648209));
    }

    private static void ObjBEInit()
    {
    }

    private static void ObjBEMain()
    {
      if ((int) Level._v == 0)
      {
        int num = 86;
        while (num >= 0)
        {
          if ((int) Level.sTile == (int) Level.ROMu16(num + 648303))
          {
            Level.PutResizableTile(Level.ROMu16(num + 648391));
            break;
          }
          else
            num -= 2;
        }
      }
      else if ((int) Level._v + 2 == (int) Level._maxh)
      {
        int num = 26;
        while (num >= 0)
        {
          if ((int) Level.sTile == (int) Level.ROMu16(num + 648693))
          {
            Level.PutResizableTile(Level.ROMu16(num + 648721));
            return;
          }
          else
            num -= 2;
        }
        Level.PutResizableTile((ushort) 33027);
      }
      else if ((int) Level._v + 1 == (int) Level._maxh)
      {
        int num = 46;
        while (num >= 0)
        {
          if ((int) Level.sTile == (int) Level.ROMu16(num + 648479))
          {
            Level.PutResizableTile(Level.ROMu16(num + 648527));
            break;
          }
          else
            num -= 2;
        }
      }
      else
      {
        int num = 10;
        while (num >= 0)
        {
          if ((int) Level.sTile == (int) Level.ROMu16(num + 648567))
          {
            Level.PutResizableTile((ushort) 5399);
            return;
          }
          else
            num -= 2;
        }
        Level.PutResizableTile((ushort) 33025);
      }
    }

    private static void ObjBFInit()
    {
    }

    private static void ObjBFMain()
    {
      if ((int) Level._v == 0)
      {
        if ((int) Level.sTile == 30650)
        {
          Level.PutResizableTile((ushort) 30655);
        }
        else
        {
          if ((int) Level.sTileGroup == 34048)
            return;
          Level.PutResizableTile((ushort) 30656);
        }
      }
      else if ((int) Level._v == 1)
      {
        if ((int) Level.sTile == 30623 || (int) Level.sTile == 30624)
          Level.PutResizableTile((ushort) 33024);
        else if ((int) Level.sTile == 5395 || (int) Level.sTile == 5398)
          Level.PutResizableTile((ushort) 5399);
        else
          Level.PutResizableTile((ushort) 33026);
      }
      else if ((int) Level._v + 1 == (int) Level._maxh)
      {
        int num1 = 26;
        while (num1 >= 0)
        {
          if ((int) Level.sTile == (int) Level.ROMu16(num1 + 648693))
          {
            Level.PutResizableTile(Level.ROMu16(num1 + 648721));
            return;
          }
          else
            num1 -= 2;
        }
        int num2 = 46;
        while (num2 >= 0)
        {
          if ((int) Level.sTile == (int) Level.ROMu16(num2 + 648479))
          {
            Level.PutResizableTile(Level.ROMu16(num2 + 648527));
            return;
          }
          else
            num2 -= 2;
        }
        Level.PutResizableTile((ushort) 33025);
      }
      else if ((int) Level._v + 2 == (int) Level._maxh)
      {
        int num = 46;
        while (num >= 0)
        {
          if ((int) Level.rTile(0, 1) == (int) Level.ROMu16(num + 648479))
          {
            Level.PutResizableTile((ushort) 33027);
            return;
          }
          else
            num -= 2;
        }
        Level.PutResizableTile((ushort) 33025);
      }
      else
      {
        int num = 10;
        while (num >= 0)
        {
          if ((int) Level.sTile == (int) Level.ROMu16(num + 648567))
          {
            Level.PutResizableTile((ushort) 5399);
            return;
          }
          else
            num -= 2;
        }
        Level.PutResizableTile((ushort) 33025);
      }
    }

    private static void ObjC0Init()
    {
      Level._maxh = (ushort) 2;
    }

    private static void ObjC2Init()
    {
      Level._maxh = (ushort) 2;
      Level._vadj = Level._vflag = ushort.MaxValue;
    }

    private static void ObjC0Main()
    {
      if ((int) Level._v == 0)
      {
        if ((int) Level.sTile == 34122)
        {
          Level.PutResizableTile((ushort) 34128);
        }
        else
        {
          if ((int) Level._h == 0)
          {
            if ((int) Level.rTile(-1, 0) == 33025)
            {
              if ((int) (ushort) ((uint) Level.sTile - 34123U) < 4)
              {
                Level.PutResizableTile((ushort) ((int) Level.sTile - 34123 + 34134));
                return;
              }
              else
              {
                Level.PutResizableTile((ushort) 30699);
                return;
              }
            }
          }
          else if ((int) Level.rTile(1, 0) == 33025)
          {
            if ((int) (ushort) ((uint) Level.sTile - 34123U) < 4)
            {
              Level.PutResizableTile((ushort) ((int) Level.sTile - 34123 + 34154));
              return;
            }
            else
            {
              Level.PutResizableTile((ushort) 30672);
              return;
            }
          }
          int num = 24;
          while (num >= 0)
          {
            if ((int) Level.sTile == (int) Level.ROMu16(num + 648936))
            {
              Level.PutResizableTile(Level.ROMu16(num + 648962));
              break;
            }
            else
              num -= 2;
          }
        }
      }
      else
      {
        int num = 46;
        while (num >= 0)
        {
          if ((int) Level.sTile == (int) Level.ROMu16(num + 648479))
          {
            Level.PutResizableTile(Level.ROMu16(num + 648988));
            break;
          }
          else
            num -= 2;
        }
      }
    }

    private static void ObjC1Main()
    {
      if ((int) Level._v == 0)
      {
        if ((int) Level.sTile == 34118)
        {
          Level.PutResizableTile((ushort) 34129);
        }
        else
        {
          if ((int) Level._h == 0)
          {
            if ((int) Level.rTile(-1, 0) == 33025)
            {
              if ((int) (ushort) ((uint) Level.sTile - 34123U) < 4)
              {
                Level.PutResizableTile((ushort) ((int) Level.sTile - 34123 + 34158));
                return;
              }
              else
              {
                Level.PutResizableTile((ushort) 30673);
                return;
              }
            }
          }
          else if ((int) Level.rTile(1, 0) == 33025)
          {
            if ((int) (ushort) ((uint) Level.sTile - 34123U) < 4)
            {
              Level.PutResizableTile((ushort) ((int) Level.sTile - 34123 + 34130));
              return;
            }
            else
            {
              Level.PutResizableTile((ushort) 30672);
              return;
            }
          }
          int num = 24;
          while (num >= 0)
          {
            if ((int) Level.sTile == (int) Level.ROMu16(num + 648936))
            {
              Level.PutResizableTile(Level.ROMu16(num + 649171));
              break;
            }
            else
              num -= 2;
          }
        }
      }
      else
      {
        int num = 46;
        while (num >= 0)
        {
          if ((int) Level.sTile == (int) Level.ROMu16(num + 648479))
          {
            Level.PutResizableTile(Level.ROMu16(num + 649197));
            break;
          }
          else
            num -= 2;
        }
      }
    }

    private static void ObjC2Main()
    {
      if ((int) Level._v == 0)
      {
        Level.PutResizableTile((ushort) 30655);
      }
      else
      {
        if ((int) Level.sTile != (int) Level.ROMu16(649378) && (int) Level.sTile != (int) Level.ROMu16(649380))
          return;
        Level.PutResizableTile((ushort) 32512);
      }
    }

    private static void ObjC3Main()
    {
      if ((int) Level._v == 0)
      {
        Level.PutResizableTile((ushort) 30656);
      }
      else
      {
        int num = 6;
        while (num >= 0)
        {
          if ((int) Level.sTile == (int) Level.ROMu16(num + 649425))
          {
            Level.PutResizableTile(ushort.MaxValue);
            break;
          }
          else
            num -= 2;
        }
      }
    }

    private static void ObjC4Init()
    {
      Level._byte = (int) Level._obj.num == 199 ? (byte) 2 : (byte) 0;
    }

    private static void ObjC4Main()
    {
      if (((int) Level._h & 1) != 0)
        return;
      Level.PutResizableTile(Level.ROMu16((int) Level._byte + 640709));
    }

    private static void ObjC5Init()
    {
      Level._byte = (int) Level._obj.num == 200 ? (byte) 2 : (byte) 0;
    }

    private static void ObjC5Main()
    {
      if (((int) Level._v & 1) != 0)
        return;
      Level.PutResizableTile(Level.ROMu16((int) Level._byte + 640709));
    }

    private static void ObjC6Init()
    {
      Level._byte = (int) Level._obj.num == 201 ? (byte) 2 : (byte) 0;
      Level._vadj = Level._vflag = ushort.MaxValue;
    }

    private static void ObjC6Main()
    {
      if (((int) Level._h & 1) != 0)
        return;
      Level.PutResizableTile(Level.ROMu16((int) Level._byte + 640709));
    }

    private static void ObjCAInit()
    {
    }

    private static unsafe void ObjCAMain()
    {
      if ((int) Level._v == 0)
      {
        if ((int) Level.sTile == 33025)
        {
          Level.PutResizableTile((ushort) 33027);
        }
        else
        {
          int num1;
          if ((int) Level.rTile(-1, 0) == 33027)
          {
            num1 = 2;
          }
          else
          {
            if ((int) Level.rTile(1, 0) != 33027 && (int) Level.rTile(1, 0) != 33025)
              return;
            num1 = 0;
          }
          byte* numPtr = (byte*) Level.GetBank13Ptr((int) Level.ROMu16(num1 + 649714));
          int num2 = 86;
          while (num2 >= 0)
          {
            if ((int) Level.sTile == (int) Level.ROMu16(num2 + 648303))
              Level.PutResizableTile(*(ushort*) (numPtr + num2));
            num2 -= 2;
          }
        }
      }
      else
        Level.PutResizableTile((int) Level._v == 1 ? (ushort) 5663 : (ushort) 5664);
    }

    private static void ObjCBInit()
    {
      Level._ushort = (ushort) 0;
    }

    private static void ObjCBMain()
    {
      Level.PutResizableTile(Level.ROMu16(Level.hindex + 650224));
      if ((int) Level._v != 0)
        return;
      if ((int) Level._h == 0 || (int) Level._h + 1 == (int) Level._maxw)
      {
        if (339 <= (int) Level.rTile(0, -1) && (int) Level.rTile(0, -1) < 353)
        {
          Level.PutResizableTile(Level.ROMu16(Level.hindex + 650230));
          Level._ushort = (ushort) 6;
        }
        else
          Level.code13A4F8();
      }
      else
        Level.code13A4F8();
    }

    private static void ObjCCInit()
    {
      Level._ushort = (ushort) 0;
      Level._vadj = (ushort) 1;
    }

    private static void ObjCCMain()
    {
      ushort sTile = Level.sTile;
      int num = (int) Level._v == 0 ? 0 : ((int) Level._v == (int) ushort.MaxValue ? 2 : 4);
      if (num != 0 || (int) sTile == 0)
        Level.PutResizableTile(Level.ROMu16(num + 650078));
      Level._vflag = (ushort) 1;
      if (num >= 4)
      {
        if ((int) Level._h - 1 == (int) Level._maxw)
          Level.code13EADC();
        if ((int) Level._v - 1 != (int) Level._maxh)
          return;
        Level._ushort = (int) sTile == 213 || 339 > (int) Level.rTile(-1, -1) || (int) Level.rTile(-1, -1) >= 353 ? (ushort) 0 : (ushort) 6;
        Level.code13A4F8();
      }
      else
        Level.code13EB2C(num | 4);
    }

    private static void ObjCDMain()
    {
      ushort sTile = Level.sTile;
      int i = (int) Level._v == 0 ? 0 : ((int) Level._v == (int) ushort.MaxValue ? 2 : 4);
      if (i != 0 || (int) sTile == 0)
        Level.PutResizableTile(Level.ROMu16(i + 649812));
      Level._vflag = (ushort) 1;
      if (i >= 4)
      {
        if ((int) Level._h == 0)
          Level.code13EADC();
        if ((int) Level._v - 1 != (int) Level._maxh)
          return;
        Level._ushort = (int) sTile == 213 || 339 > (int) Level.rTile(-1, -1) || (int) Level.rTile(-1, -1) >= 353 ? (ushort) 0 : (ushort) 6;
        Level.code13A4F8();
      }
      else
        Level.code13EB2C(i);
    }

    private static void code13EADC()
    {
      if ((339 > (int) Level.rTile(-1, 0) || (int) Level.rTile(-1, 0) >= 353) && (339 <= (int) Level.rTile(-1, -1) && (int) Level.rTile(-1, -1) < 355))
        Level.PutResizableTile((ushort) 199);
      Level.code13A47E();
    }

    private static void code13EB2C(int i)
    {
      if (339 <= (int) Level.rTile(0, -1) && (int) Level.rTile(0, -1) < 353)
      {
        Level.PutResizableTile(Level.ROMu16(i + 650012));
      }
      else
      {
        if (339 > (int) Level.rTile(-1, 0) || (int) Level.rTile(-1, 0) >= 353)
          return;
        Level.PutResizableTile(Level.ROMu16(i + 650020));
      }
    }

    private static void ObjCEInit()
    {
      Level._ushort = (int) (short) Level._maxw < 0 ? (ushort) 34560 : (ushort) 34561;
      Level._vadj = Level._vflag = ushort.MaxValue;
    }

    private static void ObjCEMain()
    {
      Level.PutResizableTile(Level._ushort);
    }

    private static void ObjCFInit()
    {
      Level._byte = (int) (short) Level._maxw < 0 ? (byte) 0 : (byte) 2;
      Level._vadj = ushort.MaxValue;
    }

    private static void ObjCFMain()
    {
      Level._vflag = ((int) Level._h & 1) != 0 ? ushort.MaxValue : (ushort) 0;
      Level.PutResizableTile((ushort) ((uint) Level.ROMu16((int) Level._byte + 650338) + ((uint) Level._h & 1U)));
    }

    private static void ObjD0Init()
    {
      Level._byte = (int) (short) Level._maxw < 0 ? (byte) 0 : (byte) 2;
      Level._vadj = ushort.MaxValue;
    }

    private static void ObjD0Main()
    {
      int num = ((int) (short) Level._maxw < 0 ? (int) -Level._h : (int) Level._h) & 3;
      Level._vflag = num != 3 ? (ushort) 0 : ushort.MaxValue;
      Level.PutResizableTile((ushort) ((uint) Level.ROMu16((int) Level._byte + 650365) + (uint) num));
    }

    private static void ObjD1Init()
    {
    }

    private static void ObjD1Main()
    {
      Level.PutResizableTile((ushort) 34575);
    }

    private static void ObjD2Init()
    {
    }

    private static void ObjD2Main()
    {
      Level.PutResizableTile((ushort) 34574);
    }

    private static void ObjD3Init()
    {
    }

    private static void ObjD3Main()
    {
      Level.PutResizableTile((ushort) (((int) Level._x + (((int) Level._v & 1) << 1) & 3) + 34123));
    }

    private static void ObjD4Init()
    {
      Level._ushort = (ushort) 0;
    }

    private static void ObjD4Main()
    {
      if ((int) Level._v == 0)
      {
        Level.PutrResizableTile(0, -1, (ushort) 31104);
        Level.PutrResizableTile(-1, 0, (ushort) 31105);
        Level.PutResizableTile((ushort) 31106);
      }
      else if ((int) Level._v + 1 == (int) Level._maxh)
      {
        Level.PutrResizableTile(0, 1, (ushort) 31112);
        Level.PutrResizableTile(-1, 0, (ushort) 31110);
        Level.PutResizableTile((ushort) 31111);
      }
      else
      {
        int num1 = 0;
        while (num1 < 24)
        {
          if ((int) Level.sTile == (int) Level.ROMu16(num1 + 650487))
          {
            Level.PutResizableTile(Level.ROMu16(num1 + 650511));
            Level._ushort = (ushort) 0;
            return;
          }
          else
            num1 += 2;
        }
        if ((int) Level._ushort != 0)
        {
          Level.PutResizableTile(Level.ROMu16((int) Level._ushort + 650708));
          if ((int) Level._ushort < 14)
            Level.PutrResizableTile(-1, 0, (ushort) 31037);
          Level._ushort = (ushort) 0;
        }
        else
        {
          int num2 = Level.random & 14;
          if (num2 >= 12 && (int) Level._v + 2 == (int) Level._maxh)
            num2 &= 6;
          Level.PutResizableTile(Level.ROMu16(num2 + 650463));
          if (num2 < 8)
            return;
          Level.PutrResizableTile(-1, 0, Level.ROMu16(num2 + 650471));
          if (num2 < 12)
            return;
          Level._ushort = (ushort) num2;
        }
      }
    }

    private static void ObjD5Main()
    {
      if ((int) Level._v == 0)
      {
        Level.PutrResizableTile(0, -1, (ushort) 31107);
        Level.PutrResizableTile(1, 0, (ushort) 31109);
        Level.PutResizableTile((ushort) 31108);
      }
      else if ((int) Level._v + 1 == (int) Level._maxh)
      {
        Level.PutrResizableTile(0, 1, (ushort) 31115);
        Level.PutrResizableTile(1, 0, (ushort) 31114);
        Level.PutResizableTile((ushort) 31113);
      }
      else
      {
        int num1 = 0;
        while (num1 < 24)
        {
          if ((int) Level.sTile == (int) Level.ROMu16(num1 + 650487))
          {
            Level.PutResizableTile(Level.ROMu16(num1 + 650777));
            Level._ushort = (ushort) 0;
            return;
          }
          else
            num1 += 2;
        }
        if ((int) Level._ushort != 0)
        {
          Level.PutResizableTile(Level.ROMu16((int) Level._ushort + 650974));
          if ((int) Level._ushort < 14)
            Level.PutrResizableTile(1, 0, (ushort) 31056);
          Level._ushort = (ushort) 0;
        }
        else
        {
          int num2 = Level.random & 14;
          if (num2 >= 12 && (int) Level._v + 2 == (int) Level._maxh)
            num2 &= 6;
          Level.PutResizableTile(Level.ROMu16(num2 + 650753));
          if (num2 < 8)
            return;
          Level.PutrResizableTile(1, 0, Level.ROMu16(num2 + 650761));
          if (num2 < 12)
            return;
          Level._ushort = (ushort) num2;
        }
      }
    }

    private static void ObjD6Main()
    {
      if ((int) Level._h == 0)
      {
        Level.PutrResizableTile(0, -1, (ushort) 31104);
        Level.PutrResizableTile(-1, 0, (ushort) 31105);
        Level.PutResizableTile((ushort) 31106);
      }
      else if ((int) Level._h + 1 == (int) Level._maxw)
      {
        Level.PutrResizableTile(0, -1, (ushort) 31107);
        Level.PutrResizableTile(1, 0, (ushort) 31109);
        Level.PutResizableTile((ushort) 31108);
      }
      else
      {
        int num1 = 0;
        while (num1 < 26)
        {
          if ((int) Level.sTile == (int) Level.ROMu16(num1 + 651043))
          {
            Level.PutResizableTile(Level.ROMu16(num1 + 651069));
            Level._ushort = (ushort) 0;
            return;
          }
          else
            num1 += 2;
        }
        if ((int) Level._ushort != 0)
        {
          Level.PutResizableTile(Level.ROMu16((int) Level._ushort + 651273));
          Level.PutrResizableTile(0, -1, Level.ROMu16((int) Level._ushort + 651277));
          Level._ushort = (ushort) 0;
        }
        else
        {
          int num2 = Level.random & 14;
          if (num2 >= 12 && (int) Level._h + 2 == (int) Level._maxw)
            num2 &= 6;
          Level.PutResizableTile(Level.ROMu16(num2 + 651019));
          if (num2 < 8)
            return;
          Level.PutrResizableTile(0, -1, Level.ROMu16(num2 + 651027));
          if (num2 < 12)
            return;
          Level._ushort = (ushort) num2;
        }
      }
    }

    private static void ObjD7Main()
    {
      if ((int) Level._h == 0)
      {
        Level.PutrResizableTile(0, 1, (ushort) 31112);
        Level.PutrResizableTile(-1, 0, (ushort) 31110);
        Level.PutResizableTile((ushort) 31111);
      }
      else if ((int) Level._h + 1 == (int) Level._maxw)
      {
        Level.PutrResizableTile(0, 1, (ushort) 31115);
        Level.PutrResizableTile(1, 0, (ushort) 31114);
        Level.PutResizableTile((ushort) 31113);
      }
      else
      {
        int num1 = 0;
        while (num1 < 26)
        {
          if ((int) Level.sTile == (int) Level.ROMu16(num1 + 651043))
          {
            Level.PutResizableTile(Level.ROMu16(num1 + 651346));
            Level._ushort = (ushort) 0;
            return;
          }
          else
            num1 += 2;
        }
        if ((int) Level._ushort != 0)
        {
          Level.PutResizableTile(Level.ROMu16((int) Level._ushort + 651550));
          Level.PutrResizableTile(0, 1, Level.ROMu16((int) Level._ushort + 651554));
          Level._ushort = (ushort) 0;
        }
        else
        {
          int num2 = Level.random & 14;
          if (num2 >= 12 && (int) Level._h + 2 == (int) Level._maxw)
            num2 &= 6;
          Level.PutResizableTile(Level.ROMu16(num2 + 651322));
          if (num2 < 8)
            return;
          Level.PutrResizableTile(0, 1, Level.ROMu16(num2 + 651330));
          if (num2 < 12)
            return;
          Level._ushort = (ushort) num2;
        }
      }
    }

    private static void ObjD8Init()
    {
      Level._maxh = Level.ROMu16((((int) Level._obj.num & 1) << 1) + 598390);
      Level._byte = (byte) (((int) Level._obj.num & 1) << 4);
    }

    private static void ObjD8Main()
    {
      Level.PutResizableTile(Level.ROMu16(((int) Level._v << 2 | ((int) Level._h & 1) << 1 | (int) Level._byte) + 651595));
    }

    private static void ObjDAInit()
    {
    }

    private static void ObjDAMain()
    {
      Level.PutResizableTile((ushort) 35328);
    }

    private static void ObjDBInit()
    {
    }

    private static void ObjDBMain()
    {
      if ((int) Level._v == 0)
      {
        if ((int) Level.sTile != 0)
          return;
        Level.PutResizableTile(Level.ROMu16((Level.random & 6) + 651668));
      }
      else
      {
        int num = (int) Level._v - 1 << 1;
        Level.PutResizableTile(num >= 6 ? (ushort) 35853 : (ushort) ((int) Level.ROMu16(num + 651676) + ((int) Level._h & 1)));
      }
    }

    private static void ObjDCInit()
    {
    }

    private static void ObjDCMain()
    {
      if ((int) Level._v == 0)
      {
        int hindex;
        if ((hindex = Level.hindex) == 2)
          Level.PutrResizableTile(0, -1, (ushort) 0);
        Level.PutResizableTile(Level.ROMu16(hindex + 651744));
      }
      else
      {
        int num = (int) Level._v >= 4 ? 16 : (int) Level._v << 2;
        if ((int) Level._h == 0 || (int) Level._h + 1 == (int) Level._maxw)
          Level.PutResizableTile(Level.ROMu16(num + ((int) Level._h != 0 ? 2 : 0) + 651746));
        else
          Level.PutResizableTile(Level.ROMu16(num + (((int) Level._h & 1) << 1) + 651762));
      }
    }

    private static void ObjDDInit()
    {
      Level._byte = (byte) (Level.random2 & 7);
    }

    private static void ObjDDMain()
    {
      if ((int) Level._v == 0)
      {
        Level.PutResizableTile((ushort) (36236 + ((int) Level._h & 1)));
      }
      else
      {
        if ((int) Level._h == 0)
          Level.PutrResizableTile(-1, 0, (ushort) (31128 + ((int) Level._v != 1 ? 1 : 0)));
        else if ((int) Level._h + 1 == (int) Level._maxw)
          Level.PutrResizableTile(1, 0, (ushort) (31130 + ((int) Level._v != 1 ? 1 : 0)));
        Level.PutResizableTile((int) Level._v < 6 ? Level.ROMu16((((int) Level._h + (int) Level._byte & 7) << 1 | (int) Level._v - 1 << 4) + 651886) : (ushort) 31127);
      }
    }

    private static void ObjDEInit()
    {
      ++Level._maxw;
    }

    private static void ObjDEMain()
    {
      Level.PutResizableTile((int) Level._v < 2 ? (ushort) ((int) Level.ROMu16(((int) Level._v << 1) + 652083) + (int) Level._h) : Level.ROMu16(((int) Level._h << 1) + 652087));
    }

    private static void ObjDFInit()
    {
      ++Level._maxh;
    }

    private static void ObjDFMain()
    {
      Level.PutResizableTile(Level.ROMu16(((int) Level._v << 3 | ((int) Level._h == 0 ? 0 : ((int) Level._h + 1 != (int) Level._maxw ? ((int) Level._h & 1) + 1 << 1 : 6))) + 652126));
    }

    private static void ObjE0Init()
    {
    }

    private static void ObjE0Main()
    {
      Level.PutResizableTile((int) Level._v != 0 ? (ushort) 42502 : (ushort) 42501);
    }

    private static void ObjE1Init()
    {
      Level._ushort = (ushort) 0;
      if ((int) (Level._byte = (byte) ((Level.random2 & 3) << 3)) != 24)
        return;
      Level._byte = (byte) 0;
    }

    private static void ObjE1Main()
    {
      if ((int) Level._v == 0)
        Level.PutResizableTile((ushort) ((int) Level.ROMu16(((int) Level._byte | (int) Level._ushort) + 652232) + (36138 > (int) Level.sTile || (int) Level.sTile >= 36142 ? 0 : 1)));
      else if ((int) Level._ushort == 2)
      {
        if ((int) Level._v + 1 == (int) Level._maxh)
          Level.PutResizableTile((ushort) (36142 + ((int) Level._v & 3 ^ 2) + (36240 > (int) Level.sTile || (int) Level.sTile >= 36244 ? 0 : 4)));
        else if ((int) Level._v == 1)
          Level.PutResizableTile((ushort) 36137);
        else
          Level.PutResizableTile(Level.ROMu16((((int) Level._v - 2 & 3) << 1) + 652254));
      }
      if ((int) Level._v + 1 != (int) Level._maxh)
        return;
      Level._ushort = (ushort) (((int) Level._ushort + 2) % 6);
    }

    private static void ObjE2Init()
    {
      Level._maxw = (ushort) 4;
    }

    private static void ObjE2Main()
    {
      if ((int) Level.ROMu16(((int) Level._v < 8 ? 652388 : 652452) + (((int) Level._v & 7) << 3 | (int) Level._h << 1)) == 0)
        return;
      Level.PutResizableTile(Level.ROMu16(((int) Level._v < 8 ? 652388 : 652452) + (((int) Level._v & 7) << 3 | (int) Level._h << 1)));
    }

    private static void ObjE3Init()
    {
    }

    private static void ObjE3Main()
    {
      Level.PutResizableTile((int) Level._h == 0 || (int) Level._h + 1 == (int) Level._maxw ? (ushort) ((int) Level.ROMu16(((int) Math.Min((ushort) 2, Level._v) << 1) + 652555) + ((int) Level._h != 0 ? 0 : 3)) : (ushort) 0);
      if ((int) Level._v != 0)
        return;
      Level.PutrResizableTile(0, -1, (ushort) 0);
    }

    private static void ObjE4Init()
    {
      Level._srcy -= (byte) 2;
      Level._maxh += (ushort) 2;
    }

    private static void ObjE4Main()
    {
      if ((int) Level._v >= 3)
      {
        Level.code13F654((int) Level._v - 3 << 1);
      }
      else
      {
        if (((int) Level._h & 1) == 0 && (int) Level._v == 0)
          Level._ushort = (ushort) (Level.random & 30);
        if ((int) Level.LDAyBank13(Level.ROMu16((int) Level._ushort + 652750), (ushort) ((int) Level._v << 2 | ((int) Level._h & 1) << 1)) == 0)
          return;
        Level.PutResizableTile(Level.LDAyBank13(Level.ROMu16((int) Level._ushort + 652750), (ushort) ((int) Level._v << 2 | ((int) Level._h & 1) << 1)));
      }
    }

    private static void code13F654(int i)
    {
      int num = i + (Level.random & 15);
      Level.PutResizableTile(Level.ROMu16((num >= 15 ? 30 : num << 1) + 652852));
    }

    private static void ObjE5Init()
    {
      Level._srcy -= (byte) 2;
      Level._maxh += (ushort) 2;
      Level._vadj = ushort.MaxValue;
    }

    private static void ObjE5Main()
    {
      if ((int) Level._v == 1 && (int) Level._h == 0)
        Level.code13F813();
      else if ((int) Level._v == 2 && (int) Level._h - 1 == (int) Level._maxw)
        Level.code13F7FE();
      Level._vflag = ((int) Level._h & 1) == 0 || (int) Level._v + 1 != (int) Level._maxh ? (ushort) 0 : (ushort) 1;
      if (((int) Level._h & 1) == 0 && (int) Level._v == 0 && ((int) (Level._ushort = (ushort) (Level.random & 14)) == 4 || (int) Level._ushort == 8) && (36864 <= (int) Level.sTile && (int) Level.sTile < 36944))
        Level._ushort = (ushort) 0;
      if ((int) Level._v >= 4)
      {
        Level.code13F654((int) Level._v - 4 << 1);
      }
      else
      {
        if ((int) Level.LDAyBank13(Level.ROMu16((int) Level._ushort + 652994), (ushort) ((int) Level._v << 2 | ((int) Level._h & 1) << 1)) == 0)
          return;
        Level.PutResizableTile(Level.LDAyBank13(Level.ROMu16((int) Level._ushort + 652994), (ushort) ((int) Level._v << 2 | ((int) Level._h & 1) << 1)));
      }
    }

    private static void code13F7FE()
    {
      if ((int) Level.rTile(-1, 0) != 31192 && (int) Level.rTile(-1, 0) != 31193)
        return;
      Level.PutrResizableTile(-1, 0, (ushort) 31177);
    }

    private static void code13F813()
    {
      if ((int) Level.rTile(1, 0) != 31190 && (int) Level.rTile(1, 0) != 31191)
        return;
      Level.PutrResizableTile(-1, 0, (ushort) 31176);
    }

    private static void ObjE6Init()
    {
      Level._srcy -= (byte) 2;
      Level._maxh += (ushort) 2;
      Level._vadj = ushort.MaxValue;
      Level._vflag = (ushort) 1;
    }

    private static void ObjE6Main()
    {
      if ((int) Level._v == 2 && (int) Level._h - 1 == (int) Level._maxw)
        Level.code13F7FE();
      if ((int) Level._v == 0)
        Level._ushort = (ushort) (Level.random & 14);
      if ((int) Level._v >= 4)
      {
        Level.code13F654((int) Level._v - 4 << 1);
      }
      else
      {
        if ((int) Level.LDAyBank13(Level.ROMu16((int) Level._ushort + 653159), (ushort) ((uint) Level._v << 1)) == 0)
          return;
        Level.PutResizableTile(Level.LDAyBank13(Level.ROMu16((int) Level._ushort + 653159), (ushort) ((uint) Level._v << 1)));
      }
    }

    private static void ObjE7Init()
    {
      --Level._srcy;
      ++Level._maxh;
      Level._vadj = (ushort) 65534;
      Level._vflag = (ushort) 1;
    }

    private static void ObjE7Main()
    {
      if ((int) Level._v == 0)
        Level._ushort = (ushort) (Level.random & 14);
      if ((int) Level._v >= 4)
      {
        Level.code13F654((int) Level._v - 4 << 1);
      }
      else
      {
        if ((int) Level.LDAyBank13(Level.ROMu16((int) Level._ushort + 653263), (ushort) ((uint) Level._v << 1)) == 0)
          return;
        Level.PutResizableTile(Level.LDAyBank13(Level.ROMu16((int) Level._ushort + 653263), (ushort) ((uint) Level._v << 1)));
      }
    }

    private static void ObjE8Init()
    {
      Level._srcy -= (byte) 2;
      Level._maxh += (ushort) 2;
      Level._vadj = ushort.MaxValue;
    }

    private static void ObjE8Main()
    {
      if ((int) Level._v == 1 && (int) Level._h == 0)
        Level.code13F7FE();
      else if ((int) Level._v == 2 && (int) Level._h + 1 == (int) Level._maxw)
        Level.code13F813();
      Level._vflag = ((int) Level._h & 1) == 0 || (int) Level._v + 1 != (int) Level._maxh ? (ushort) 0 : (ushort) 1;
      if (((int) Level._h & 1) == 0 && (int) Level._v == 0 && ((int) (Level._ushort = (ushort) (Level.random & 14)) == 4 || (int) Level._ushort == 8) && (36864 <= (int) Level.sTile && (int) Level.sTile < 36944))
        Level._ushort = (ushort) 0;
      if ((int) Level._v >= 4)
      {
        Level.code13F654((int) Level._v - 4 << 1);
      }
      else
      {
        if ((int) Level.LDAyBank13(Level.ROMu16((int) Level._ushort + 653432), (ushort) ((int) Level._v << 2 | ((int) Level._h & 1) << 1)) == 0)
          return;
        Level.PutResizableTile(Level.LDAyBank13(Level.ROMu16((int) Level._ushort + 653432), (ushort) ((int) Level._v << 2 | ((int) Level._h & 1) << 1)));
      }
    }

    private static void ObjE9Init()
    {
      Level._srcy -= (byte) 2;
      Level._maxh += (ushort) 2;
      Level._vadj = ushort.MaxValue;
      Level._vflag = (ushort) 1;
    }

    private static void ObjE9Main()
    {
      if ((int) Level._v == 2 && (int) Level._h + 1 == (int) Level._maxw)
        Level.code13F813();
      if ((int) Level._v == 0)
        Level._ushort = (ushort) (Level.random & 14);
      if ((int) Level._v >= 4)
      {
        Level.code13F654((int) Level._v - 4 << 1);
      }
      else
      {
        if ((int) Level.LDAyBank13(Level.ROMu16((int) Level._ushort + 653631), (ushort) ((uint) Level._v << 1)) == 0)
          return;
        Level.PutResizableTile(Level.LDAyBank13(Level.ROMu16((int) Level._ushort + 653631), (ushort) ((uint) Level._v << 1)));
      }
    }

    private static void ObjEAInit()
    {
      --Level._srcy;
      ++Level._maxh;
      Level._vadj = (ushort) 65534;
      Level._vflag = (ushort) 1;
    }

    private static void ObjEAMain()
    {
      if ((int) Level._v == 0)
        Level._ushort = (ushort) (Level.random & 14);
      if ((int) Level._v >= 4)
      {
        Level.code13F654((int) Level._v - 4 << 1);
      }
      else
      {
        if ((int) Level.LDAyBank13(Level.ROMu16((int) Level._ushort + 653735), (ushort) ((uint) Level._v << 1)) == 0)
          return;
        Level.PutResizableTile(Level.LDAyBank13(Level.ROMu16((int) Level._ushort + 653735), (ushort) ((uint) Level._v << 1)));
      }
    }

    private static void ObjEBInit()
    {
      --Level._srcy;
      ++Level._maxh;
    }

    private static void ObjEBMain()
    {
      if ((int) Level._v < 3)
      {
        if ((int) Level._v == 0)
          Level._ushort = (ushort) (Level.random & 14);
        if ((int) Level.LDAyBank13(Level.ROMu16((int) Level._ushort + 653263), (ushort) ((uint) Level._v << 1)) == 0)
          return;
        Level.PutResizableTile(Level.LDAyBank13(Level.ROMu16((int) Level._ushort + 653263), (ushort) ((uint) Level._v << 1)));
      }
      else
      {
        Level.PutResizableTile((ushort) (31190 + ((int) Level._v & 1)));
        if ((int) Level.rTileGroup(1, 0) == 30976)
          Level.PutrResizableTile(1, 0, Level.ROMu16((Level.random & 6) + 653817));
        if ((int) Level._v + 1 != (int) Level._maxh)
          return;
        int num = 0;
        while (num < 12 && (int) Level.rTileGroup(-1, 0) != (int) Level.ROMu16(num + 653825))
          num += 2;
        if (num == 12 && (34216 > (int) Level.rTile(-1, 0) || (int) Level.rTile(-1, 0) >= 34224))
          return;
        Level.PutResizableTile((ushort) 31176);
      }
    }

    private static void ObjECMain()
    {
      if ((int) Level._v < 3)
      {
        if ((int) Level._v == 0)
          Level._ushort = (ushort) (Level.random & 14);
        if ((int) Level.LDAyBank13(Level.ROMu16((int) Level._ushort + 653735), (ushort) ((uint) Level._v << 1)) == 0)
          return;
        Level.PutResizableTile(Level.LDAyBank13(Level.ROMu16((int) Level._ushort + 653735), (ushort) ((uint) Level._v << 1)));
      }
      else
      {
        Level.PutResizableTile((ushort) (31192 + ((int) Level._v & 1)));
        if ((int) Level.rTileGroup(-1, 0) == 30976)
          Level.PutrResizableTile(-1, 0, Level.ROMu16((Level.random & 6) + 653817));
        if ((int) Level._v + 1 != (int) Level._maxh)
          return;
        int num = 0;
        while (num < 12 && (int) Level.rTileGroup(1, 0) != (int) Level.ROMu16(num + 653825))
          num += 2;
        if (num == 12 && (34216 > (int) Level.rTile(1, 0) || (int) Level.rTile(1, 0) >= 34224))
          return;
        Level.PutResizableTile((ushort) 31177);
      }
    }

    private static void ObjEDInit()
    {
      Level._byte = (byte) (((int) Level._srcy ^ (int) Level._x) & 1);
    }

    private static void ObjEDMain()
    {
      ushort num1 = (ushort)-Level._v;
      ushort num2 = (int) num1 < 5 ? (ushort) ((uint) num1 & 6U) : (ushort) 4;
      if ((int) (Level._ushort = Level.ROMu16((int) num2 + 654087)) < 6 && ((int) Level._v & 1) != 0 && (Level.random & 2) != 0)
        Level._ushort += (ushort) 3;
      ushort num3 = (ushort) ((((int) Level._v ^ (int) Level._h ^ (int) Level._byte) & 1) << 1);
      ushort num4;
      if ((int) Level._h == 0)
        num4 = Level.ROMu16((int) num3 + 654198);
      else if ((int) num3 != 0)
      {
        Level._ushort = (ushort) ((uint) Level.rTile(-1, 0) - 31209U);
        num4 = (ushort) 31210;
      }
      else
        num4 = (int) Level._h + 1 != (int) Level._maxw ? (ushort) 31209 : (ushort) 31208;
      Level.PutResizableTile((int) Level._v == 0 ? (ushort) ((int) num4 - 31208 + 15625) : (ushort) ((int) num4 + (int) Level._ushort));
    }

    private static void ObjEEInit()
    {
      Level._byte = (byte) (((int) Level._srcy ^ (int) Level._x) & 1);
      if ((int) (Level._ushort = (ushort) ((int) Level._obj.num & 1 ^ 1)) != 0)
        return;
      Level._ushort = ushort.MaxValue;
    }

    private static void ObjF0Init()
    {
      Level._byte = (byte) (((int) Level._srcy ^ (int) Level._x) & 1);
      Level._ushort = ushort.MaxValue;
    }

    private static void ObjF5Init()
    {
    }

    private static void ObjF5Main()
    {
      Level.PutResizableTile((int) Level._v == 0 ? (ushort) 33811 : (ushort) 10512);
    }

    private static void ObjF6Init()
    {
    }

    private static void ObjF6Main()
    {
      Level.PutResizableTile((ushort) 40331);
    }

    public unsafe void LoadLevel(byte LevelNumber, bool SaveCheck)
    {
      this._number = LevelNumber;
      uint num1 = this.YI.AddressSNEStoPC(this.YI.ROM[784323 + (int) this.Number * 6].u24);
      uint num2 = this.YI.AddressSNEStoPC(this.YI.ROM[784323 + (int) this.Number * 6 + 3].u24);
      fixed (VariableByte* variableBytePtr = &this.YI.ROM[0])
      {
        if ((int) num1 != 0)
        {
          this.LoadLevelInfo((byte*) ((IntPtr) variableBytePtr + (int) num1));
        }
        else
        {
          this.LoadTilesetSpecificTiles();
          this.removeOldObject = false;
        }
        if ((int) num2 != 0)
          this.LoadSpriteInfo((byte*) ((IntPtr) variableBytePtr + (int) num2));
        else
          this.removeOldSprite = false;
        this.LoadGraphics(this.Header);
        this.LoadPalette(this.Header);
        this.LoadAnimation(this.Header[10]);
      }
    }

    private unsafe void LoadLevelInfo(byte* data)
    {
      byte num1 = (byte) 0;
      if ((int) this.Number != 56)
      {
        fixed (VariableByte* variableBytePtr = &this.YI.ROM[527109])
        {
          byte* numPtr = (byte*) variableBytePtr;
          byte num2 = (byte) 0;
          byte num3 = (byte) 1;
          for (; (int) *numPtr != 0; ++numPtr)
          {
            this.Header[(int) num2] = (byte) 0;
            for (byte index = *numPtr; (int) index != 0; --index)
            {
              if ((int) --num3 == 0)
              {
                num1 = *data++;
                num3 = (byte) 8;
              }
              this.Header[(int) num2] = (byte) ((int) this.Header[(int) num2] << 1 | ((int) (sbyte) num1 < 0 ? 1 : 0));
              num1 <<= 1;
            }
            ++num2;
          }
        }
      }
      this.LoadTilesetSpecificTiles();
      this._objectID = 0U;
      this.Objects.Clear();
      Level.Object @object = new Level.Object();
      while (true)
      {
        @object.num = *data++;
        @object.locH = *data++;
        if ((int) @object.num != (int) byte.MaxValue)
        {
          @object.locL = *data++;
          @object.id = this._objectID++;
          if ((int) @object.num != 0)
          {
            @object.exnum = (byte) 0;
            byte num2 = (byte) ((uint) this.YI.ROM[591084 + (int) @object.num].u8 & 3U);
            @object.width = (int) num2 == 1 ? (ushort) 1 : ((int) this.Header[1] == 2 || ((int) *data & 128) == 0 ? (ushort) ((int) *data++ + 1) : (ushort) (((int) *data++ | 65280) - 1));
            @object.height = (int) num2 == 0 ? (ushort) 1 : (((int) *data & 128) == 0 ? (ushort) ((int) *data++ + 1) : (ushort) (((int) *data++ | 65280) - 1));
            this.Objects.Add(@object);
          }
          else
          {
            @object.exnum = *data++;
            @object.width = @object.height = (ushort) 1;
            this.Objects.Add(@object);
          }
        }
        else
          break;
      }
      for (int index = 0; index < this.Exits.Length; ++index)
        this.Exits[index].dest = byte.MaxValue;
      fixed (Level.ScreenExit* screenExitPtr = this.Exits)
        Memory.Clear((void*) screenExitPtr, this.Exits.Length * sizeof (Level.ScreenExit));
      for (byte index = @object.locH; (int) (sbyte) index >= 0; index = *data++)
      {
        fixed (Level.ScreenExit* screenExitPtr = &this.Exits[(int) index])
          *(int*) screenExitPtr = (int) *(uint*) data;
        this.Exits[(int) index].enabled = true;
        data += 4;
      }
      this._levelTiles.Clear();
      this.DecodeLevel(0, true);
    }

    private unsafe void LoadTilesetSpecificTiles()
    {
      uint num = 841242U;
      while ((int) this.YI.ROM[num].u8 != 0)
      {
        byte u8 = this.YI.ROM[num].u8;
        fixed (VariableByte* variableBytePtr = &this.RAM[(int) this.YI.ROM[(num + 1U)].u16])
        {
          ushort* numPtr = (ushort*) variableBytePtr;
          ushort u16 = this.YI.ROM[(long) (num + 3U) + (long) ((int) this.Header[1] << 1)].u16;
          for (; (int) u8 != 0; --u8)
            *numPtr++ = u16++;
        }
        num += 35U;
      }
    }

    public void ReloadLevel()
    {
      this.LoadTilesetSpecificTiles();
      this._levelTiles.Clear();
      this.DecodeLevel(0, false);
      this.LoadGraphics(this.Header);
      this.LoadPalette(this.Header);
      this.LoadAnimation(this.Header[10]);
    }

    public void RedecodeLevel(int id)
    {
      for (int index1 = 0; index1 <= this._levelTiles.PageCount; ++index1)
      {
        for (int index2 = 0; index2 < this._levelTiles.InternalTiles[index1].Length; ++index2)
        {
          for (int index3 = this._levelTiles.InternalTiles[index1][index2].Count - 1; index3 >= 0; --index3)
          {
            if (this._levelTiles.InternalTiles[index1][index2][index3].id >= id)
            {
              this._levelTiles.InternalTiles[index1][index2].RemoveRange(0, index3 + 1);
              break;
            }
          }
        }
      }
      for (int index1 = 0; index1 < this.CommandTiles.Length; ++index1)
      {
        for (int index2 = this.CommandTiles[index1].Count - 1; index2 >= 0; --index2)
        {
          if (this.CommandTiles[index1][index2] >= id)
          {
            this.CommandTiles[index1].RemoveRange(0, index2 + 1);
            break;
          }
        }
      }
      this._levelTiles.ResetPages(id);
      this.DecodeLevel(id, false);
    }

    private unsafe void LoadSpriteInfo(byte* data)
    {
      Level.Sprite sprite = new Level.Sprite();
      this.Sprites.Clear();
      ushort num;
      while ((int) (num = *(ushort*) data) != (int) ushort.MaxValue)
      {
        sprite.num = (ushort) ((uint) num & 511U);
        sprite.y = (byte) ((uint) num >> 9);
        sprite.x = data[2];
        sprite.id = this._spriteID++;
        this.Sprites.Add(sprite);
        data += 3;
      }
    }

    private unsafe void LoadGraphics(byte[] header)
    {
      Memory.Clear(this.SpriteTileRow, 442);
      int index1 = (int) (11629L + ((int) header[9] == 10 ? 394L : 0L));
      int num1 = 0;
      int num2;
      while ((num2 = (int) this.YI.ROM[index1].u8) != (int) byte.MaxValue)
      {
        int num3 = (int) this.YI.ROM[index1 + 1].u16;
        if (num2 >= 240)
        {
          switch (num2 & 15)
          {
            case 0:
              num2 = (int) this.YI.ROM[(long) this.BG1GraphicTable + (long) ((int) header[1] * 3)].u8;
              break;
            case 1:
              num2 = (int) this.YI.ROM[(long) this.BG1GraphicTable + (long) ((int) header[1] * 3) + 1L].u8;
              break;
            case 2:
              num2 = (int) this.YI.ROM[(long) this.BG1GraphicTable + (long) ((int) header[1] * 3) + 2L].u8;
              break;
            case 3:
              num2 = (int) this.YI.ROM[12185L + (long) ((int) header[3] * 2)].u8;
              break;
            case 4:
              num2 = (int) this.YI.ROM[12185L + (long) ((int) header[3] * 2) + 1L].u8;
              break;
            case 5:
              num2 = (int) this.YI.ROM[12249L + (long) ((int) header[5] * 2)].u8;
              break;
            case 6:
              num2 = (int) this.YI.ROM[12249L + (long) ((int) header[5] * 2) + 1L].u8;
              break;
            case 7:
              num2 = (int) this.YI.ROM[12345L + (long) ((int) header[7] * 6)].u8;
              break;
            case 8:
              num2 = (int) this.YI.ROM[12345L + (long) ((int) header[7] * 6) + 1L].u8;
              break;
            case 9:
              num2 = (int) this.YI.ROM[12345L + (long) ((int) header[7] * 6) + 2L].u8;
              break;
            case 10:
              num2 = (int) this.YI.ROM[12345L + (long) ((int) header[7] * 6) + 3L].u8;
              break;
            case 11:
              num2 = (int) this.YI.ROM[12345L + (long) ((int) header[7] * 6) + 4L].u8;
              break;
            case 12:
              num2 = (int) this.YI.ROM[12345L + (long) ((int) header[7] * 6) + 5L].u8;
              break;
          }
        }
        if ((int) (short) num3 < 0)
        {
          fixed (VariableByte* variableBytePtr = &this.YI.ROM[this.YI.AddressSNEStoPC(this.YI.ROM[228473L + (long) (num2 * 3)].u24)])
            fixed (byte* dest = &this.VRAM[(num3 & (int) short.MaxValue) * 2])
              Decompress.LZ1((byte*) variableBytePtr, dest, (uint) this.YI.ROM[index1 + 4].u8 * 4U);
          index1 += 2;
        }
        else
        {
          fixed (VariableByte* variableBytePtr = &this.YI.ROM[this.YI.AddressSNEStoPC(this.YI.ROM[227678L + (long) (num2 * 3)].u24)])
            fixed (byte* dest = &this.VRAM[(num3 & (int) short.MaxValue) * 2])
              Decompress.LZ0((byte*) variableBytePtr, dest, 4096U);
        }
        index1 += 3;
        ++num1;
      }
      fixed (VariableByte* variableBytePtr = &this.YI.ROM[12345 + (int) header[7] * 6])
      {
        for (int index2 = 0; index2 < 442; ++index2)
        {
          for (int index3 = 5; index3 >= 0; --index3)
          {
            if ((int) ((byte*) variableBytePtr)[index3] == (int) this.YI.ROM[index2 * 2 + 337686].u16)
              this._spriteTileRow[index2] = (ushort) (index3 * 32 | 256);
          }
        }
      }
      if ((int) header[9] == 10)
        return;
      fixed (VariableByte* variableBytePtr = &this.YI.ROM[this.YI.AddressSNEStoPC(this.YI.ROM[(long) ((int) this.YI.ROM[(uint) ((int) this.YI.ROM[(long) ((int) header[3] * 2) + 59153L].u8 + 59217 + 1)].u8 * 3) + 227678L].u24)])
        fixed (byte* dest = &this.VRAM[28672])
          Decompress.LZ0((byte*) variableBytePtr, dest, 4096U);
      if ((int) header[5] == 0)
      {
        fixed (byte* numPtr1 = &this.VRAM[26624])
        {
          ushort* numPtr2 = (ushort*) numPtr1;
          for (int index2 = 0; index2 < 1024; ++index2)
            *numPtr2++ = (ushort) 462;
        }
      }
      else
      {
        int num3;
        if ((num3 = (int) this.YI.ROM[59655L + (long) ((int) header[5] * 3)].u16) == 0)
          return;
        fixed (VariableByte* variableBytePtr = &this.YI.ROM[this.YI.AddressSNEStoPC(this.YI.ROM[(long) (num3 * 3) + 227678L].u24)])
          fixed (byte* dest = &this.VRAM[26624])
            Decompress.LZ0((byte*) variableBytePtr, dest, 2048U);
      }
    }

    public unsafe void LoadPalette(byte[] header)
    {
      fixed (ushort* numPtr = this.CGRAM)
        Memory.Clear((void*) numPtr, 512);
      this.LoadRegularPalette(header, this.YoshiColor, this._cgram);
      this.LoadAnimatedPalette(header[11], this._cgram, 0U, 0U);
      this.LoadGradientPalette(header[0]);
    }

    public void LoadRegularPalette(byte[] header, byte YoshiColor, ushort[] dest)
    {
        ushort num2;
        VariableByte[] numArray = new VariableByte[0x10];
        uint index = 0;
        if (header[9] == 10)
        {
            index = 0x3862;
            dest[0] = 0;
            numArray[0].u16 = this.YI.ROM[0x3a14 + (YoshiColor * 2)].u16;
            numArray[2].u16 = this.YI.ROM[0x39f4 + (header[8] * 2)].u16;
        }
        else
        {
            index = 0x378a;
            numArray[0].u16 = (ushort)((header[0] * 2) + 0x130);
            numArray[2].u16 = this.YI.ROM[this.BG1PaletteTable + (header[2] * 2)].u16;
            numArray[4].u16 = this.YI.ROM[0x38f4 + (header[4] * 2)].u16;
            numArray[6].u16 = this.YI.ROM[0x3974 + (header[6] * 2)].u16;
            numArray[8].u16 = this.YI.ROM[0x39f4 + (header[8] * 2)].u16;
            numArray[10].u16 = (ushort)(this.YI.ROM[this.BG1PaletteTable + (header[2] * 2)].u16 + 60);
            numArray[12].u16 = this.YI.ROM[0x3a14 + (YoshiColor * 2)].u16;
        }
        while ((num2 = this.YI.ROM[index].u16) != 0xffff)
        {
            ushort num3 = this.YI.ROM[index + 2].u8;
            ushort num4 = this.YI.ROM[index + 3].u8;
            if (((short)num2) < 0)
            {
                num2 = numArray[num2 & 0x7fff].u16;
            }
            int num5 = num2 + 0x1fa000;
            int num6 = 0;
            while (num6 < (num4 & 240))
            {
                int num7 = num4 & 15;
                int num8 = num3 + num6;
                for (int i = 0; i < num7; i++)
                {
                    dest[num8++] = this.YI.ROM[num5 + (i * 2)].u16;
                }
                num6 += 0x10;
                num5 += (ushort)((num4 & 15) * 2);
            }
            index += 4;
        }
    }

    public unsafe void LoadAnimatedPalette(byte header, ushort[] dest, uint frame0B73, uint frame7974)
    {
      fixed (VariableByte* variableBytePtr = this.YI.ROM)
      {
        switch (header)
        {
          case (byte) 0:
            break;
          case (byte) 1:
            ushort* numPtr1 = (ushort*) ((IntPtr) variableBytePtr + (2031616 | (int) this.YI.ROM[(uint) (50303 + ((int) frame0B73 & 7) * 2)].u16));
            int num1 = 67;
            for (int index = 0; index < 13; ++index)
              dest[num1 + index] = *numPtr1++;
            break;
          case (byte) 2:
            ushort* numPtr2 = (ushort*) ((IntPtr) variableBytePtr + (2072976 + ((int) frame0B73 & 3) * 6));
            int num2 = 5;
            for (int index = 0; index < 3; ++index)
              dest[num2 + index] = *numPtr2++;
            break;
          case (byte) 3:
            ushort* numPtr3 = (ushort*) ((IntPtr) variableBytePtr + (2084074 + ((int) frame7974 & 3) * 32));
            int num3 = 112;
            for (int index = 0; index < 16; ++index)
              dest[num3 + index] = *numPtr3++;
            break;
          case (byte) 4:
            ushort* numPtr4 = (ushort*) ((IntPtr) variableBytePtr + (2031616 | (int) this.YI.ROM[(uint) (50548 + ((int) frame7974 & 7) * 2)].u16));
            int num4 = 113;
            for (int index = 0; index < 15; ++index)
              dest[num4 + index] = *numPtr4++;
            break;
          case (byte) 5:
            if (((int) this.Header[1] & 7) == 0)
            {
              ushort* numPtr5 = (ushort*) ((IntPtr) variableBytePtr + (2031616 | (int) this.YI.ROM[(uint) (50740 + ((int) frame7974 & 7) * 2)].u16));
              int num5 = 67;
              for (int index = 0; index < 13; ++index)
                dest[num5 + index] = *numPtr5++;
              int num6 = 2;
              for (int index = 0; index < 6; ++index)
                dest[num6 + index] = *numPtr5++;
            }
            ushort* numPtr6 = (ushort*) ((IntPtr) variableBytePtr + (2087424 + ((int) frame0B73 & 7) * 16));
            int num7 = 113;
            for (int index = 0; index < 8; ++index)
              dest[num7 + index] = *numPtr6++;
            break;
          case (byte) 6:
          case (byte) 7:
            ushort* numPtr7 = (ushort*) ((IntPtr) variableBytePtr + (2087424 + ((int) frame0B73 & 7) * 16));
            int num8 = 113;
            for (int index = 0; index < 8; ++index)
              dest[num8 + index] = *numPtr7++;
            ushort* numPtr8 = (ushort*) ((IntPtr) variableBytePtr + (2031616 | (int) this.YI.ROM[(uint) (50740 + ((int) frame7974 & 7) * 2)].u16));
            int num9 = 67;
            for (int index = 0; index < 13; ++index)
              dest[num9 + index] = *numPtr8++;
            ushort* numPtr9 = (ushort*) ((IntPtr) variableBytePtr + (2031616 | (int) this.YI.ROM[(uint) (50666 + ((int) frame7974 & 3) * 2)].u16));
            int num10 = 83;
            for (int index = 0; index < 4; ++index)
              dest[num10 + index] = *numPtr9++;
            break;
          case (byte) 8:
            ushort* numPtr10 = (ushort*) ((IntPtr) variableBytePtr + (2031616 | (int) this.YI.ROM[(uint) (50810 + ((int) frame7974 & 3) * 2)].u16));
            int num11 = 83;
            for (int index = 0; index < 4; ++index)
              dest[num11 + index] = *numPtr10++;
            break;
          case (byte) 9:
            ushort* numPtr11 = (ushort*) ((IntPtr) variableBytePtr + (2031616 | (int) this.YI.ROM[(uint) (50859 + ((int) frame0B73 & 7) * 2)].u16));
            dest[1] = dest[9] = *numPtr11;
            break;
          case (byte) 10:
            ushort* numPtr12 = (ushort*) ((IntPtr) variableBytePtr + (2031616 | (int) this.YI.ROM[(uint) (50938 + ((int) frame7974 & 3) * 2)].u16));
            int num12 = 83;
            for (int index = 0; index < 4; ++index)
              dest[num12 + index] = *numPtr12++;
            break;
          case (byte) 11:
            ushort* numPtr13 = (ushort*) ((IntPtr) variableBytePtr + (2031616 | (int) this.YI.ROM[(uint) (50968 + ((int) frame0B73 & 7) * 2)].u16));
            int num13 = 1;
            for (int index = 0; index < 3; ++index)
              dest[num13 + index] = *numPtr13++;
            break;
          case (byte) 12:
            ushort* numPtr14 = (ushort*) ((IntPtr) variableBytePtr + (2031616 | (int) this.YI.ROM[(uint) (51059 + ((int) frame0B73 & 7) * 2)].u16));
            int num14 = 1;
            for (int index = 0; index < 3; ++index)
              dest[num14 + index] = *numPtr14++;
            break;
          case (byte) 13:
            ushort* numPtr15 = (ushort*) ((IntPtr) variableBytePtr + (2031616 | (int) this.YI.ROM[(((int) this.Header[6] & 1) == 0 ? 51154L : 51170L) + (long) (uint) (((int) frame0B73 & 7) * 2)].u16));
            int num15 = 1;
            for (int index = 0; index < 3; ++index)
              dest[num15 + index] = *numPtr15++;
            break;
          case (byte) 14:
            if ((int) this.Header[1] != 8)
            {
              ushort* numPtr5 = (ushort*) ((IntPtr) variableBytePtr + (2031616 | (int) this.YI.ROM[(uint) (50666 + ((int) frame7974 & 3) * 2)].u16));
              int num5 = 83;
              for (int index = 0; index < 4; ++index)
                dest[num5 + index] = *numPtr5++;
            }
            else
            {
              ushort* numPtr5 = (ushort*) ((IntPtr) variableBytePtr + (2031616 | (int) this.YI.ROM[(uint) (50938 + ((int) frame7974 & 3) * 2)].u16));
              int num5 = 83;
              for (int index = 0; index < 4; ++index)
                dest[num5 + index] = *numPtr5++;
            }
            ushort* numPtr16 = (ushort*) ((IntPtr) variableBytePtr + (2031616 | (int) this.YI.ROM[(uint) (51254 + ((int) frame7974 & 7) * 2)].u16 + ((int) this.Header[4] & 1) * 16));
            int num16 = (int) this.YI.ROM[51270 + ((int) this.Header[4] & 1) * 2].u16 / 2;
            for (int index = 0; index < 8; ++index)
              dest[num16 + index] = *numPtr16++;
            break;
          case (byte) 15:
            ushort* numPtr17 = (ushort*) ((IntPtr) variableBytePtr + (2031616 | (int) this.YI.ROM[(uint) (51343 + ((int) frame7974 & 3) * 2)].u16));
            int num17 = 5;
            for (int index = 0; index < 3; ++index)
              dest[num17 + index] = *numPtr17++;
            break;
          case (byte) 16:
            ushort* numPtr18 = (ushort*) ((IntPtr) variableBytePtr + (2031616 | (int) this.YI.ROM[(uint) (51379 + ((int) frame7974 & 7 ^ 7) * 2)].u16));
            int num18 = 73;
            for (int index = 0; index < 7; ++index)
              dest[num18 + index] = *numPtr18++;
            break;
          case (byte) 17:
            this.LoadAnimatedPalette((byte) 14, dest, frame0B73, frame7974);
            ushort* numPtr19 = (ushort*) ((IntPtr) variableBytePtr + (2095454 + ((int) frame0B73 & 15) * 8));
            int num19 = 0;
            for (int index = 0; index < 4; ++index)
              dest[num19 + index] = *numPtr19++;
            break;
          case (byte) 18:
            this.LoadAnimatedPalette((byte) 10, dest, frame0B73, frame7974);
            this.LoadAnimatedPalette((byte) 16, dest, frame0B73, frame7974);
            ushort* numPtr20 = (ushort*) ((IntPtr) variableBytePtr + (2095582 + ((int) frame0B73 & 15) * 8));
            int num20 = 0;
            for (int index = 0; index < 4; ++index)
              dest[num20 + index] = *numPtr20++;
            break;
          case (byte) 19:
          case (byte) 20:
            this.LoadAnimatedPalette((byte) 2, dest, frame0B73, frame7974);
            ushort* numPtr21 = (ushort*) ((IntPtr) variableBytePtr + (2031616 | (int) this.YI.ROM[(uint) (51254 + ((int) frame7974 & 7) * 2)].u16 + ((int) this.Header[4] & 1) * 16));
            int num21 = (int) this.YI.ROM[51270 + ((int) this.Header[4] & 1) * 2].u16 / 2;
            for (int index = 0; index < 8; ++index)
              dest[num21 + index] = *numPtr21++;
            ushort* numPtr22 = (ushort*) ((IntPtr) variableBytePtr + (2031616 | (int) this.YI.ROM[(uint) (50740 + ((int) frame7974 & 7) * 2)].u16));
            int num22 = 67;
            for (int index = 0; index < 13; ++index)
              dest[num22 + index] = *numPtr22++;
            break;
          default:
            // ISSUE: __unpin statement
            //__unpin(variableBytePtr);
            break;
        }
      }
    }

    private unsafe void LoadGradientPalette(byte header)
    {
        //if (this._customGradient.enabled || (int) header >= 16)
        //{
        //  fixed (VariableByte* variableBytePtr = &this.YI.ROM[this.YI.AddressSNEStoPC((uint) this.YI.ROM[54579 + ((int) header << 2)].u16 << 16 | (uint) this.YI.ROM[54581 + ((int) header << 2)].u16)])
        //    fixed (uint* numPtr1 = this._gradient)
        //      fixed (ushort* numPtr2 = this._customGradient.color)
        //      {
        //        ushort* numPtr3;
        //        if (!this._customGradient.enabled)
        //        {
        //          numPtr3 = (ushort*) variableBytePtr;
        //          Memory.Copy((void*) numPtr2, (void*) numPtr3, 48);
        //        }
        //        else
        //          numPtr3 = numPtr2;
        //        ushort* numPtr4 = numPtr3 + 23;
        //        Memory.Set(this._gradient, 72, SNES.Color.ToRGB(*numPtr4));
        //        //uint* numPtr5 = (uint*) (numPtr1 + new IntPtr(288));
        //        uint* numPtr5 = (uint*)(numPtr1 + 288);
        //        uint num1 = (uint) (((int) *numPtr4 & 31) << 16);
        //        uint num2 = (uint) (((int) *numPtr4 & 992) << 16);
        //        uint num3 = (uint) (((int) *numPtr4 & 31744) << 16);
        //        for (int index1 = 0; index1 < 23; ++index1)
        //        {
        //          uint num4 = num1;
        //          uint num5 = num2;
        //          uint num6 = num3;
        //          num1 = (uint) (((int) *--numPtr4 & 31) << 16);
        //          num2 = (uint) (((int) *numPtr4 & 992) << 16);
        //          num3 = (uint) (((int) *numPtr4 & 31744) << 16);
        //          int num7 = (int) num1 - (int) num4;
        //          int num8 = (int) num2 - (int) num5;
        //          int num9 = (int) num3 - (int) num6;
        //          int num10 = num7 / 16;
        //          int num11 = num8 / 16;
        //          int num12 = num9 / 16;
        //          for (int index2 = 0; index2 < 16; ++index2)
        //            *numPtr5++ = SNES.Color.ToRGB((ushort) ((long) num4 + (long) (index2 * num10) >> 16 & 31L | (long) num5 + (long) (index2 * num11) >> 16 & 992L | (long) num6 + (long) (index2 * num12) >> 16 & 31744L));
        //        }
        //        uint num13 = *(numPtr5 - 1);
        //        for (int index = 0; index < 72; ++index)
        //          *numPtr5++ = num13;
        //      }
        //}
        //else
        //{
        //  Memory.Set(this._customGradient.color, 24, this._cgram[0]);
        //  Memory.Set(this._gradient, this._gradient.Length, SNES.Color.ToRGB(this._cgram[0]));
        //}

        if (this._customGradient.enabled || (header >= 0x10))
        {
            if (this._customGradient.enabled || (int)header >= 16)
            {
                fixed (VariableByte* variableBytePtr = &this.YI.ROM[this.YI.AddressSNEStoPC((uint)this.YI.ROM[54579 + ((int)header << 2)].u16 << 16 | (uint)this.YI.ROM[54581 + ((int)header << 2)].u16)])
                fixed (uint* numPtr1 = this._gradient)
                fixed (ushort* numPtr2 = this._customGradient.color)
                {
                    ushort* numPtr3;
                    if (!this._customGradient.enabled)
                    {
                        numPtr3 = (ushort*)variableBytePtr;
                        Memory.Copy((void*)numPtr2, (void*)numPtr3, 48);
                    }
                    else
                        numPtr3 = numPtr2;
                    ushort* numPtr4 = numPtr3 + 23;
                    Memory.Set(this._gradient, 72, SNES.Color.ToRGB(*numPtr4));
                    uint* numPtr5 = numPtr1 + 72;
                    uint num1 = (uint)(((int)*numPtr4 & 31) << 16);
                    uint num2 = (uint)(((int)*numPtr4 & 992) << 16);
                    uint num3 = (uint)(((int)*numPtr4 & 31744) << 16);
                    for (int index1 = 0; index1 < 23; ++index1)
                    {
                        uint num4 = num1;
                        uint num5 = num2;
                        uint num6 = num3;
                        num1 = (uint)(((int)*--numPtr4 & 31) << 16);
                        num2 = (uint)(((int)*numPtr4 & 992) << 16);
                        num3 = (uint)(((int)*numPtr4 & 31744) << 16);
                        int num7 = (int)num1 - (int)num4;
                        int num8 = (int)num2 - (int)num5;
                        int num9 = (int)num3 - (int)num6;
                        int num10 = num7 / 16;
                        int num11 = num8 / 16;
                        int num12 = num9 / 16;
                        for (int index2 = 0; index2 < 16; ++index2)
                            *numPtr5++ = SNES.Color.ToRGB((ushort)((long)num4 + (long)(index2 * num10) >> 16 & 31L | (long)num5 + (long)(index2 * num11) >> 16 & 992L | (long)num6 + (long)(index2 * num12) >> 16 & 31744L));
                    }
                    uint num13 = *(numPtr5 - 1);
                    for (int index = 0; index < 72; ++index)
                        *numPtr5++ = num13;
                }
            }
            else
            {
                Memory.Set(this._customGradient.color, 24, this._cgram[0]);
                Memory.Set(this._gradient, this._gradient.Length, SNES.Color.ToRGB(this._cgram[0]));
            }
        }
    }
    private void LoadAnimation(byte type)
    {
      if ((int) type == 4)
        return;
      this.LoadRegularAnimation();
      this.LoadSpecificAnimation(type);
    }

    private unsafe void LoadRegularAnimation()
    {
      fixed (VariableByte* variableBytePtr = this.YI.ROM)
      {
        int num = 0;
        while (num < 16)
        {
          this.CopyAnimation((byte*) variableBytePtr, 5373952 | (int) *(ushort*) ((byte*) variableBytePtr + num + 21981), (int) *(ushort*) ((byte*) variableBytePtr + num + 21917), 128);
          num += 4;
        }
      }
    }

    private unsafe void LoadSpecificAnimation(byte type)
    {
      fixed (VariableByte* variableBytePtr = this.YI.ROM)
      {
        switch (type)
        {
          case (byte) 0:
            int num1 = 0;
            while (num1 < 8)
            {
              this.CopyAnimation((byte*) variableBytePtr, 5420032, num1 * 128 + 4096, 256);
              num1 += 2;
            }
            break;
          case (byte) 1:
            this.CopyAnimation((byte*) variableBytePtr, 5636096 | (int) *(ushort*) ((byte*) variableBytePtr + 22283), 12032, 256);
            break;
          case (byte) 2:
            int num2 = 0;
            while (num2 < 8)
            {
              this.CopyAnimation((byte*) variableBytePtr, 5373952 | (int) *(ushort*) ((byte*) variableBytePtr + num2 + 22341), (int) *(ushort*) ((byte*) variableBytePtr + 22325), 256);
              this.CopyAnimation((byte*) variableBytePtr, 5373952 | (int) *(ushort*) ((byte*) variableBytePtr + num2 + 22341) + 256, (int) *(ushort*) ((byte*) variableBytePtr + 8 + 22325), 256);
              num2 += 2;
            }
            break;
          case (byte) 3:
            this.CopyAnimation((byte*) variableBytePtr, 5636096 | (int) *(ushort*) ((byte*) variableBytePtr + 22420), 12032, 512);
            break;
          case (byte) 5:
            this.CopyAnimation((byte*) variableBytePtr, 5636096 | (int) *(ushort*) ((byte*) variableBytePtr + 22485), 12032, 512);
            break;
          case (byte) 6:
            this.CopyAnimation((byte*) variableBytePtr, 5636096 | (int) *(ushort*) ((byte*) variableBytePtr + 22485), (int) this.Header[9] == 10 ? 32512 : 12032, 512);
            break;
          case (byte) 7:
            int num3 = (int) this.Header[1] == 10 ? 8 : 0;
            int num4 = num3 != 0 ? 5636096 : 5373952;
            this.CopyAnimation((byte*) variableBytePtr, num4 | (int) *(ushort*) ((byte*) variableBytePtr + 22616 + num3), 4096, 256);
            this.CopyAnimation((byte*) variableBytePtr, num4 | (int) *(ushort*) ((byte*) variableBytePtr + 22632 + num3), 4352, 256);
            this.CopyAnimation((byte*) variableBytePtr, num4 | (int) *(ushort*) ((byte*) variableBytePtr + 22648 + num3), 4224, 256);
            this.CopyAnimation((byte*) variableBytePtr, num4 | (int) *(ushort*) ((byte*) variableBytePtr + 22664 + num3), 4480, 256);
            break;
          case (byte) 8:
            this.CopyAnimation((byte*) variableBytePtr, 5373952 | (int) *(ushort*) ((byte*) variableBytePtr + 22813), 4096, 256);
            this.CopyAnimation((byte*) variableBytePtr, 5373952 | (int) *(ushort*) ((byte*) variableBytePtr + 22821), 4352, 256);
            break;
          case (byte) 9:
            this.CopyAnimation((byte*) variableBytePtr, 5636096 | (int) *(ushort*) ((byte*) variableBytePtr + 32768), 12032, 512);
            break;
          case (byte) 10:
            this.CopyAnimation((byte*) variableBytePtr, 5636096 | (int) *(ushort*) ((byte*) variableBytePtr + 45056), 12032, 512);
            break;
          case (byte) 11:
            this.CopyAnimation((byte*) variableBytePtr, 5636096 | (int) *(ushort*) ((byte*) variableBytePtr + 22974), 12032, 512);
            goto case 2;
          case (byte) 12:
            this.CopyAnimation((byte*) variableBytePtr, 5373952 | (int) *(ushort*) ((byte*) variableBytePtr + 23081), 4096, 256);
            this.CopyAnimation((byte*) variableBytePtr, 5373952 | (int) *(ushort*) ((byte*) variableBytePtr + 23081 + 2), 4352, 256);
            this.CopyAnimation((byte*) variableBytePtr, 5373952 | (int) *(ushort*) ((byte*) variableBytePtr + 23105), 4224, 256);
            this.CopyAnimation((byte*) variableBytePtr, 5373952 | (int) *(ushort*) ((byte*) variableBytePtr + 23105 + 2), 4480, 256);
            break;
          case (byte) 13:
            this.LoadSpecificAnimation((byte) 7);
            goto case 5;
          case (byte) 14:
            this.LoadSpecificAnimation((byte) 12);
            goto case 5;
          case (byte) 15:
            this.CopyAnimation((byte*) variableBytePtr, 5636096 | (int) *(ushort*) ((byte*) variableBytePtr + 23316), 12032, 512);
            break;
          case (byte) 16:
            this.CopyAnimation((byte*) variableBytePtr, 5636096 | (int) *(ushort*) ((byte*) variableBytePtr + 22852), 12032, 128);
            this.CopyAnimation((byte*) variableBytePtr, 5636096 | (int) *(ushort*) ((byte*) variableBytePtr + 22860), 12160, 128);
            break;
          case (byte) 17:
            this.LoadSpecificAnimation((byte) 3);
            goto case 12;
          default:
            // ISSUE: __unpin statement
            //__unpin(variableBytePtr);
            break;
        }
      }
    }

    private unsafe void CopyAnimation(byte* ptr, int src_addr, int dest_addr, int size)
    {
      Marshal.Copy((IntPtr) ((void*) (ptr + (int) this.YI.AddressSNEStoPC((uint) src_addr))), this.VRAM, dest_addr << 1, size);
    }

    private delegate void LoadTiles();

    public struct Object
    {
      public byte num;
      public byte exnum;
      public byte locL;
      public byte locH;
      public ushort width;
      public ushort height;
      public uint id;

      public byte X
      {
        get
        {
          return (byte) ((int) this.locL & 15 | ((int) this.locH & 15) << 4);
        }
        set
        {
          this.locL = (byte) ((int) this.locL & 240 | (int) value & 15);
          this.locH = (byte) ((int) this.locH & 240 | (int) value >> 4);
        }
      }

      public byte Y
      {
        get
        {
          return (byte) ((int) this.locL >> 4 | (int) this.locH & 240);
        }
        set
        {
          this.locL = (byte) ((int) this.locL & 15 | (int) value << 4);
          this.locH = (byte) ((int) this.locH & 15 | (int) value & 240);
        }
      }
    }

    public struct Sprite
    {
      public ushort num;
      public byte y;
      public byte x;
      public uint id;
    }

    public struct ScreenExit
    {
      public byte dest;
      public byte x;
      public byte y;
      public byte type;
      public bool enabled;
    }

    public struct LevelTile
    {
      public const int HorzResizable = 1;
      public const int VertResizable = 2;
      public const int NegHorzResizable = 4;
      public const int NegVertResizable = 8;
      public const int Replaced = 16;
      public ushort tile;
      public int id;
      public byte state;

      public LevelTile(ushort tile, int id, byte state)
      {
        this.tile = tile;
        this.id = id;
        this.state = state;
      }
    }

    public class LevelTileList : List<Level.LevelTile>
    {
      private readonly Level.LevelTile NullTile = new Level.LevelTile((ushort) 0, -1, (byte) 0);

      public new Level.LevelTile this[int index]
      {
        get
        {
          if ((uint) index >= (uint) this.Count)
            return this.NullTile;
          else
            return base[index];
        }
        set
        {
          base[index] = value;
        }
      }
    }

    public class LevelCommandList : List<int>
    {
      public new int this[int index]
      {
        get
        {
          if ((uint) index >= (uint) this.Count)
            return -1;
          else
            return base[index];
        }
        set
        {
          base[index] = value;
        }
      }
    }

    public class LevelTiles
    {
      private Level.LevelTileList[][] _Tiles = new Level.LevelTileList[129][];
      private bool[] _PageUsed = new bool[129];
      private Level.LevelTileList[][] _TilesPtr = new Level.LevelTileList[128][];
      private int[] _PageFirstID = new int[128];
      private int[] _OriginalPageFirstID = new int[128];
      private Level.LevelCommandList[] _CommandTiles = new Level.LevelCommandList[32768];
      private int _PageCount;

      public Level.LevelTileList[][] InternalTiles
      {
        get
        {
          return this._Tiles;
        }
      }

      public Level.LevelTileList[][] Tiles
      {
        get
        {
          return this._TilesPtr;
        }
      }

      public int[] PageFirstID
      {
        get
        {
          return this._PageFirstID;
        }
      }

      public int[] OriginalPageFirstID
      {
        get
        {
          return this._OriginalPageFirstID;
        }
      }

      public int PageCount
      {
        get
        {
          return this._PageCount;
        }
        set
        {
          this._PageCount = value;
        }
      }

      public Level.LevelCommandList[] CommandTiles
      {
        get
        {
          return this._CommandTiles;
        }
      }

      public LevelTiles()
      {
        for (int index1 = 0; index1 < this._Tiles.Length; ++index1)
        {
          this._Tiles[index1] = new Level.LevelTileList[256];
          for (int index2 = 0; index2 < this._Tiles[index1].Length; ++index2)
            this._Tiles[index1][index2] = new Level.LevelTileList();
        }
        for (int index = 0; index < this._TilesPtr.Length; ++index)
          this._TilesPtr[index] = this._Tiles[0];
        for (int index = 0; index < this._CommandTiles.Length; ++index)
          this._CommandTiles[index] = new Level.LevelCommandList();
      }

      public void Clear()
      {
        for (int index1 = 0; index1 < this._Tiles.Length; ++index1)
        {
          for (int index2 = 0; index2 < 256; ++index2)
            this._Tiles[index1][index2].Clear();
        }
        for (int index = 0; index < this._CommandTiles.Length; ++index)
          this._CommandTiles[index].Clear();
        for (int index = 0; index < this._TilesPtr.Length; ++index)
        {
          this._TilesPtr[index] = this._Tiles[0];
          this._PageFirstID[index] = -1;
          this._OriginalPageFirstID[index] = -1;
        }
        this._PageCount = 0;
      }

      public bool IsFreshPage(byte page)
      {
        return this._TilesPtr[(int) page] == this._Tiles[0];
      }

      public void ReserveNewPage(byte page, int id)
      {
        this._TilesPtr[(int) page] = this._Tiles[++this._PageCount];
        this._OriginalPageFirstID[(int) page] = this._PageFirstID[(int) page] = id;
      }

      public void CopyPage(byte destPage, byte srcPage)
      {
        this._TilesPtr[(int) destPage] = this._TilesPtr[(int) srcPage];
        this._PageFirstID[(int) destPage] = this._PageFirstID[(int) srcPage];
      }

      public void ResetPages(int id)
      {
        this._PageCount = 0;
        for (int index = 0; index < 128; ++index)
        {
          if (this._PageFirstID[index] != -1)
          {
            if (this._PageFirstID[index] >= id)
            {
              this._TilesPtr[index] = this._Tiles[0];
              this._PageFirstID[index] = -1;
              this._OriginalPageFirstID[index] = -1;
            }
            else
              ++this._PageCount;
          }
        }
      }
    }

    public class Headers
    {
      public const int BGColor = 0;
      public const int BG1Tile = 1;
      public const int BG1Palette = 2;
      public const int BG2Tile = 3;
      public const int BG2Palette = 4;
      public const int BG3Tile = 5;
      public const int BG3Palette = 6;
      public const int SprTile = 7;
      public const int SprPalette = 8;
      public const int LevelMode = 9;
      public const int Animation = 10;
      public const int PalAnimation = 11;
      public const int BGScroll = 12;
      public const int Music = 13;
      public const int ItemMemory = 14;
    }

    public class CustomGradient
    {
      public ushort[] color = new ushort[24];
      public bool enabled;

      public Level.CustomGradient Clone()
      {
        Level.CustomGradient customGradient = this.MemberwiseClone() as Level.CustomGradient;
        customGradient.color = this.color.Clone() as ushort[];
        return customGradient;
      }
    }

    public class SpriteInformation
    {
      public static string[] Label = new string[501]
      {
        "000\t\tLog, floating on water / lava",
        "001\t\tClosed door",
        "002\t\tNaval Piranha's stalk",
        "003\t\tCrate, key",
        "004\t\tItem from Star Mario block",
        "005\t\tIcy watermelon",
        "006\t\tChill",
        "007\t\tWatermelon",
        "008\t\tRubble",
        "009\t\tFire watermelon",
        "00A\t\tKaboomba",
        "00B\t\tCannonball of Kaboomba",
        "00C\t\tRaphael the Raven",
        "00D\t\tGoal",
        "00E\t\tG O A L !",
        "00F\t\tBONUS CHALLENGE",
        "010\t\tCaged Ghost, round mound",
        "011\t\tItem Card",
        "012\t\tBoss Door",
        "013\t\tBoss Explosion",
        "014\t\tKey from defeated boss",
        "015\t\tTorpedo of Yoshi Submarine",
        "016\t\tBigger Boo",
        "017\t\tFrog Pirate",
        "018\t\tFlame of Red Watermelon",
        "019\t\tBubble",
        "01A\t\tSki lift",
        "01B\t\tVertical log, floating on lava",
        "01C\t\tDr. Freezegood, nothing / 6 stars / 1-up / Bumpty",
        "01D\t\tDr. Freezegood, with ski lift",
        "01E\t\tShy Guy, green / red / yellow / purple",
        "01F\t\tRotating Doors",
        "020\t\tBandit",
        "021\t\t? bucket",
        "022\t\tFlashing Egg",
        "023\t\tRed Egg",
        "024\t\tYellow Egg",
        "025\t\tGreen Egg",
        "026\t\tGiant Egg, for battle with Bowser",
        "027\t\tKey",
        "028\t\tHuffin' Puffin, running away",
        "029\t\tGiant Egg, for battle with Prince Froggy?",
        "02A\t\tRed Giant Egg",
        "02B\t\tGreen Giant Egg",
        "02C\t\tLunge Fish",
        "02D\t\tSalvo the Slime",
        "02E\t\tSalve the Slime's eyes",
        "02F\t\tLittle Mouser's Nest",
        "030\t\tLittle Mouser",
        "031\t\tPotted Spiked Fun Guy",
        "032\t\tLittle Mouser, looking around, in nest / behind stuff",
        "033\t\tLittle Mouser, from nest",
        "034\t\tRogger the Potted Ghost",
        "035\t\tFalling down Rogger the Potted Ghost?",
        "036\t\t(BG3) Falling down wall",
        "037\t\tGrim Leecher",
        "038\t\tFlame spat by Rogger the Potted Ghost",
        "039\t\t(BG3) Spinning wooden platform",
        "03A\t\t3 Mini-Ravens",
        "03B\t\tMini-Raven",
        "03C\t\tTap-Tab the Red Nose",
        "03D\t\t(BG3) Seesaw",
        "03E\t\tSkinny platform",
        "03F\t\tSlime",
        "040\t\tBaby Luigi",
        "041\t\tStork",
        "042\t\tVertical pipe entrance",
        "043\t\tRed Giant Shy Guy",
        "044\t\tGreen Giant Shy Guy",
        "045\t\tPrince Froggy, throat / before fight / throat with uvula / after fight",
        "046\t\tBurt the Bushful",
        "047\t\tShy Guy for Rogger the Potted Ghost",
        "048\t\tKamek, for scenes before boss fights",
        "049\t\tThe head of fire of the Thunder Lakitu",
        "04A\t\tFire of Thunder Lakitu",
        "04B\t\tHypocenter of the thunder.",
        "04C\t\tUpside down Blow Hard",
        "04D\t\tunknown",
        "04E\t\tLocked door",
        "04F\t\tMiddle ring",
        "050\t\t(BG3) Board",
        "051\t\t(BG3) Large log",
        "052\t\tBalloon",
        "053\t\tKamek, says \"OH MY!!!\"",
        "054\t\tUpside down Wild Piranha",
        "055\t\tGreen Pinwheel",
        "056\t\tPink Pinwheel",
        "057\t\t(BG3) Sewer ghost with Flatbed Ferry on its head",
        "058\t\tGreen Solo Toady",
        "059\t\tContinuous Super Star",
        "05A\t\tSpark of Raphael the Raven.",
        "05B\t\tCoin Bandit",
        "05C\t\tPink Toadie",
        "05D\t\t[CRASH]",
        "05E\t\t(BG3) Plank",
        "05F\t\t(BG3) Plank",
        "060\t\tBomb",
        "061\t\tBaby Mario",
        "062\t\tGoomba",
        "063\t\tMuddy Buddy",
        "064\t\tPink Pinwheel, (X: direction) (Y: size)",
        "065\t\tRed coin",
        "066\t\tWild Piranha",
        "067\t\tHidden Winged Cloud, stars / seed / flower / 1-up",
        "068\t\tFlashing Egg Block",
        "069\t\tRed Egg Block",
        "06A\t\tYellow Egg Block",
        "06B\t\tHit green Egg Block",
        "06C\t\tLarge Spring Ball",
        "06D\t\tHootie the Blue Fish, clockwise",
        "06E\t\tHootie the Blue Fish, anticlockwise",
        "06F\t\tSpring Ball",
        "070\t\tClawdaddy",
        "071\t\tBig Boo with 3 Boos / Big Boo / Big Boo with 3 Boos / Boo",
        "072\t\tTrain Bandit",
        "073\t\t(BG3) Balloon Pumper with red balloon",
        "074\t\tSpike",
        "075\t\tSpiked ball",
        "076\t\tPiro Dangle, clockwise",
        "077\t\tPiro Dangle, anticlockwise",
        "078\t\tBiting Bullet Bill Blaster",
        "079\t\tBouncing Bullet Bill Blaster",
        "07A\t\tBullet Bill Blaster",
        "07B\t\tBiting Bullet Bill",
        "07C\t\tBouncing Bullet Bill",
        "07D\t\tBullet Bill",
        "07E\t\tDent of castella",
        "07F\t\tLog seesaw",
        "080\t\tLava Bubble",
        "081\t\tLava Bubble, jumps across",
        "082\t\tChain Chomp",
        "083\t\tCloud",
        "084\t\tTeleport sprite",
        "085\t\tHarry Hedgehog",
        "086\t\t[CRASH]",
        "087\t\tRed Egg, gives 1-up",
        "088\t\tSuper Star",
        "089\t\tRed Flatbed Ferry, moving horizontally",
        "08A\t\tPink Flatbed Ferry, moving vertically",
        "08B\t\tMock Up, green / red",
        "08C\t\tYoshi, at the Goal",
        "08D\t\tFly Guy, 5 stars / red coin / 1-up / 1-up",
        "08E\t\tKamek, at Bowser's room",
        "08F\t\tSwing of Grinders",
        "090\t\t(BG3) Dangling Ghost",
        "091\t\t4 Toadies",
        "092\t\tMelon Bug",
        "093\t\tDoor",
        "094\t\tExpansion Block",
        "095\t\tBlue checkered block",
        "096\t\tRed checkered block",
        "097\t\tPOW",
        "098\t\tYoshi Block",
        "099\t\tSpiny Egg",
        "09A\t\tChained green Flatbed Ferry",
        "09B\t\tMace Guy",
        "09C\t\tMace",
        "09D\t\t!-switch",
        "09E\t\tChomp Rock",
        "09F\t\tWild Ptooie Piranha, spits 1 / 3 Needlenose",
        "0A0\t\tTulip",
        "0A1\t\tPot of Potted Spiked Fun Guy",
        "0A2\t\tFireball of Thunder Lakitu",
        "0A3\t\tBandit, getting under cover, left",
        "0A4\t\tBandit, getting under cover, right",
        "0A5\t\tNep-Enut / Gargantua Blargg",
        "0A6\t\tIncoming Chomp",
        "0A7\t\tFlcok of Incoming Chomps",
        "0A8\t\tFalling Incoming Chomp",
        "0A9\t\tShadow of falling Incoming Chomp",
        "0AA\t\tShy Guy in background",
        "0AB\t\tFill Eggs",
        "0AC\t\tSign Arrow and Shadow",
        "0AD\t\tHint Block",
        "0AE\t\tHookbill the Koopa",
        "0AF\t\tMorph Bubble, Car",
        "0B0\t\tMorph Bubble, Mole Tank",
        "0B1\t\tMorph Bubble, Helicopter",
        "0B2\t\tMorph Bubble, Train",
        "0B3\t\tWind of Fuzzy",
        "0B4\t\tMorph Bubble, Submarine",
        "0B5\t\tHidden Winged Cloud, 1-up / 5 stars / !-switch / 5 stars",
        "0B6\t\tWinged Cloud, 8 coins",
        "0B7\t\tWinged Cloud, bubbled 1-up",
        "0B8\t\tWinged Cloud, flower",
        "0B9\t\tWinged Cloud, POW",
        "0BA\t\tWinged Cloud, stairs, right / left",
        "0BB\t\tWinged Cloud, platform, right / left",
        "0BC\t\tWinged Cloud, Bandit",
        "0BD\t\tWinged Cloud, coin ",
        "0BE\t\tWinged Cloud, 1-up",
        "0BF\t\tWinged Cloud, key",
        "0C0\t\tWinged Cloud, 3 stars",
        "0C1\t\tWinged Cloud, 5 stars",
        "0C2\t\tWinged Cloud, door",
        "0C3\t\tWinged Cloud, ground eater",
        "0C4\t\tWinged Cloud, watermelon",
        "0C5\t\tWinged Cloud, fire watermelon",
        "0C6\t\tWinged Cloud, icy watermelon",
        "0C7\t\tWinged Cloud, seed of sunflower with 3 leaves",
        "0C8\t\tWinged Cloud, seed of sunflower with 6 leaves",
        "0C9\t\tWinged Cloud, [CRASH]",
        "0CA\t\tBoss Door of Bowser's room",
        "0CB\t\tWinged Cloud, random item.",
        "0CC\t\tWinged Cloud, !-switch / !-switch",
        "0CD\t\tBaron Von Zeppelin, Giant Egg",
        "0CE\t\tBowser's flame",
        "0CF\t\tBowser's quake",
        "0D0\t\tHorizontal entrance, towards right",
        "0D1\t\tHidden entrance, revealed by an ! switch",
        "0D2\t\tMarching Milde",
        "0D3\t\tGiant Milde",
        "0D4\t\tLarge Milde",
        "0D5\t\tMoutain backgrounds at fight with Hookbill the Koopa",
        "0D6\t\t(BG3) Ghost with Flatbed Ferry on its head",
        "0D7\t\tSluggy the Unshaven",
        "0D8\t\tChomp signboard.",
        "0D9\t\tFishin' Lakitu",
        "0DA\t\tFlower pot, key / 6 stars / 6 coins / nothing",
        "0DB\t\t(BG3) Soft thing",
        "0DC\t\tSnowball",
        "0DD\t\tCloser, in Naval Piranha's room",
        "0DE\t\tFalling Rock",
        "0DF\t\tPiscatory Pete, Blue / Gold",
        "0E0\t\tPerying Mantas",
        "0E1\t\tLoch Nestor",
        "0E2\t\tBoo Blah, normal / upside down",
        "0E3\t\tBoo Blah with Piro Dangle, normal / upside down",
        "0E4\t\tHeading cactus",
        "0E5\t\tGreen Needlenose",
        "0E6\t\tGusty, left / right / infinite right / infinite left",
        "0E7\t\tBurt, two / one",
        "0E8\t\tGoonie, right / towards Yoshi / generator right / generator left",
        "0E9\t\t3 Flightless Goonies",
        "0EA\t\tCloud Drop, moving vertically",
        "0EB\t\tCloud Drop, moving horizontally",
        "0EC\t\tFlamer Guy, jumping around",
        "0ED\t\tFlamer Guy, walking around",
        "0EE\t\tEggo-Dill",
        "0EF\t\tEggo-Dill's face",
        "0F0\t\tPetal of Eggo-Dill",
        "0F1\t\tBubble-Plant",
        "0F2\t\tStilt Guy, green / red / yellow / purple",
        "0F3\t\tWoozy Guy, green / red / yellow / purple",
        "0F4\t\tEgg-Plant / Needlenose-Plant",
        "0F5\t\tSlugger",
        "0F6\t\tParent and children of Huffin' Puffins",
        "0F7\t\tBarney Bubble",
        "0F8\t\tBlow Hard",
        "0F9\t\tYellow Needlenose",
        "0FA\t\tFlower",
        "0FB\t\tSpear Guy, long spear",
        "0FC\t\tSpear Guy, short spear",
        "0FD\t\tZeus Guy",
        "0FE\t\tEnergy of Zeus Guy",
        "0FF\t\tPoochy",
        "100\t\tBubbled 1-up",
        "101\t\tSpiky mace",
        "102\t\tSpiky mace, double-ended",
        "103\t\tBoo Guys spinning spiky mace",
        "104\t\tJean de Fillet, right / left",
        "105\t\tBoo Guys, carrying bombs towards left.",
        "106\t\tBoo Guys, carrying bombs towards right",
        "107\t\tSeed of watermelon",
        "108\t\tMilde",
        "109\t\tTap-Tap",
        "10A\t\tTap-Tap, stays on ledges",
        "10B\t\tHopping Tap-tap",
        "10C\t\tChained spike ball, controlled by Boo Guy",
        "10D\t\tBoo Guy, rotating a pulley, right / left",
        "10E\t\tCrate, 6 stars",
        "10F\t\tBoo Man Bluff",
        "110\t\tFlower",
        "111\t\tGeorgette Jelly",
        "112\t\tSplashed Georgette Jelly",
        "113\t\tSnifit",
        "114\t\tBullet, shot by Snifit",
        "115\t\tCoin, gravity affected",
        "116\t\tFloating round platform on water",
        "117\t\tDonut Lift",
        "118\t\tGiant Donut Lift",
        "119\t\tSpooky",
        "11A\t\tGreen Glove",
        "11B\t\tLakitu, one / two",
        "11C\t\tLakitu's cloud",
        "11D\t\tSpiny Egg",
        "11E\t\tBrown Arrow Wheel",
        "11F\t\tBlue Arrow Wheel",
        "120\t\tDouble-ended arrow lift",
        "121\t\tExplosion of Number Platform",
        "122\t\t? bueket, Bandit",
        "123\t\t? bucket, 5 coins",
        "124\t\tStretch, green / red / yellow / purple",
        "125\t\tKamek, for the ending scene / flying and chases",
        "126\t\tSpiked log held by chain and pulley",
        "127\t\t? Pulley",
        "128\t\tGround shake",
        "129\t\tFuzzy",
        "12A\t\tShy Guy, with Bandit hidden",
        "12B\t\tFat Guy, red / green",
        "12C\t\tFly Guy carrying red coin / Whirly Fly Guy",
        "12D\t\tYoshi, in the intro scene",
        "12E\t\tunknown",
        "12F\t\tLava Drop, moving horizontally",
        "130\t\tLava Drop, moving vertically",
        "131\t\tLocked door",
        "132\t\tLemon Drop",
        "133\t\tLantern Ghost",
        "134\t\tBaby Bowser",
        "135\t\tRaven, always circling, anticlockwise / clockwise",
        "136\t\tRaven, anticlockwise / clockwise initially",
        "137\t\t3x6 Falling Rock",
        "138\t\t3x3 Falling Rock",
        "139\t\t3x9 Falling Rock",
        "13A\t\t6x3 Falling Rock",
        "13B\t\tStomach Acid",
        "13C\t\tFlipper, downwards",
        "13D\t\tFang, dangling",
        "13E\t\tFang, flying wavily",
        "13F\t\tFlopsy Fish, swimming around",
        "140\t\tFlopsy Fish, swimming and occasionally jumps vertically",
        "141\t\tFlopsy Fish, swimming and jumps in an arc",
        "142\t\tFlopsy Fish, jumps 3 times in an arc, right / left",
        "143\t\tSpray Fish",
        "144\t\tFlipper, rightwards / leftwards",
        "145\t\tBlue Sluggy, falling down / crawing ceiling",
        "146\t\tPink Sluggy, falling down / crawing ceiling but doesn't move",
        "147\t\tHorizontal entrance, towards left",
        "148\t\tLarge Spring Ball",
        "149\t\tArrow cloud, up",
        "14A\t\tArrow cloud, up right",
        "14B\t\tArrow cloud, right",
        "14C\t\tArrow cloud, down right",
        "14D\t\tArrow cloud, down",
        "14E\t\tArrow cloud, down left",
        "14F\t\tArrow cloud, left",
        "150\t\tArrow cloud, up left",
        "151\t\tArrow cloud, rotating",
        "152\t\tFlutter",
        "153\t\tGoonie with Shy Guy",
        "154\t\tShark Chomp",
        "155\t\tVery Goonie",
        "156\t\tCactus Jack, one / three",
        "157\t\tWall Lakitu",
        "158\t\tBowling Goonie",
        "159\t\tGrunt, walking",
        "15A\t\tGrunt, running",
        "15B\t\tDancing Spear Guy",
        "15C\t\tGreen switch for green spiked platform",
        "15D\t\tRed switch for red spiked platform",
        "15E\t\tPink Pinwheel with Shy Guys, clockwise / anticlockwise",
        "15F\t\tGreen spiked platform",
        "160\t\tRed spiked platform",
        "161\t\tBonus Item, red coin / key / flower / door",
        "162\t\tTwo spiked platforms with one switch in the center",
        "163\t\tBouncing green Needlenose",
        "164\t\tNipper Plant",
        "165\t\tNipper Spore",
        "166\t\tThunder Lakitu, one / two",
        "167\t\tGreen Koopa shell",
        "168\t\tRed Koopa shell",
        "169\t\tGreen Beach Koopa",
        "16A\t\tRed Beach Koopa",
        "16B\t\tGreen Koopa",
        "16C\t\tRed Koopa",
        "16D\t\tGreen Para Koopa, jumping forth.",
        "16E\t\tRed Para Koopa, flying horizontally",
        "16F\t\tRed Para Koopa, flying vertically",
        "170\t\tAqua Lakitu",
        "171\t\tNaval Piranha",
        "172\t\tNaval Bud",
        "173\t\tBaron Von Zeppelin, red Suy Guy",
        "174\t\tBaron Von Zeppelin, Needlenose",
        "175\t\tBaron Von Zeppelin, bomb",
        "176\t\tBaron Von Zeppelin, Bandit",
        "177\t\tBaron Von Zeppelin, large Spring Ball",
        "178\t\tBaron Von Zeppelin, 1-up",
        "179\t\tBaron Von Zeppelin, key",
        "17A\t\tBaron Von Zeppelin, 5 coins",
        "17B\t\tBaron Von Zeppelin, watermelon",
        "17C\t\tBaron Von Zeppelin, fire watermelon",
        "17D\t\tBaron Von Zeppelin, icy watermelon",
        "17E\t\tBaron Von Zeppelin, crate, 6 stars.",
        "17F\t\tBaron Von Zeppelin",
        "180\t\tSpinning Log",
        "181\t\tCrazee Dayzee",
        "182\t\tDragonfly",
        "183\t\tButterfly",
        "184\t\tBumpty",
        "185\t\tActive line guided green Flatbed Ferry, left",
        "186\t\tActive line guided green Flatbed Ferry, right",
        "187\t\tActive line guided yellow Flatbed Ferry, left",
        "188\t\tActive line guided yellow Flatbed Ferry, right",
        "189\t\tLine guided green Flatbed Ferry, left",
        "18A\t\tLine guided green Flatbed Ferry, right",
        "18B\t\tLine guided yellow Flatbed Ferry, left",
        "18C\t\tLine guided yellow Flatbed Ferry, right",
        "18D\t\tLine guided red Flatbed Ferry, left",
        "18E\t\tLine guided red Flatbed Ferry, right",
        "18F\t\tWhirling lift",
        "190\t\tFalling icicle",
        "191\t\tSparrow",
        "192\t\tMufti Guy, green / red / yellow / purple",
        "193\t\tCaged Ghost, squeezing in sewer",
        "194\t\tBlargg",
        "195\t\tunknown",
        "196\t\tUnbalanced snowy platform",
        "197\t\tArrow sign, up / right / left / down",
        "198\t\tDiagonal arrow sign, up left / up right / down left / down right",
        "199\t\tDizzy Dandy",
        "19A\t\tBoo Guy",
        "19B\t\tBumpty, tackles at Yoshi",
        "19C\t\tFlying Bumpty, flying aronnd / flying straightly",
        "19D\t\tSkeleton Goonie",
        "19E\t\tFlightless Skeleton Goonie",
        "19F\t\tSkeleton Goonie with a bomb",
        "1A0\t\tFirebar, double-ended, clockwise / anticlockwise",
        "1A1\t\tFirebar, clockwise / anticlockwise",
        "1A2\t\tStar",
        "1A3\t\tLittle Skull Mouser",
        "1A4\t\tCork, seals 3D pipe",
        "1A5\t\tGrinder, runs away",
        "1A6\t\tGrinder, spits seeds of watermelon",
        "1A7\t\tShort Fuse / Seedy Sally, right / left",
        "1A8\t\tGrinder, grasps Baby Mario",
        "1A9\t\tGrinder, climbing, spits seeds of watermelon",
        "1AA\t\tHot Lips",
        "1AB\t\tBoo Balloon, coin / !-switch",
        "1AC\t\tFrog",
        "1AD\t\tKamek, shoots magic at Yoshi.",
        "1AE\t\tKamek's magic",
        "1AF\t\tCoin",
        "1B0\t\t(BG3) Balloon",
        "1B1\t\tCoin Cannon for Mini Battle",
        "1B2\t\tCoin for Mini Battle",
        "1B3\t\tBandit for Mini Battle",
        "1B4\t\tCheckered Platform for Mini Battle",
        "1B5\t\tBandit for Mini Battle",
        "1B6\t\tRed Balloon for Mini Battle",
        "1B7\t\tBandit for Mini Battle",
        "1B8\t\tWatermelon Pot for Mini Battle",
        "1B9\t\tpossibly Bandit for Mini Battle?",
        "1BA\t\tGraphic / Palette Changer 00",
        "1BB\t\tGraphic / Palette Changer 01",
        "1BC\t\tGraphic / Palette Changer 02",
        "1BD\t\tGraphic / Palette Changer 03",
        "1BE\t\tGraphic / Palette Changer 04",
        "1BF\t\tGraphic / Palette Changer 05",
        "1C0\t\tGraphic / Palette Changer 06",
        "1C1\t\tGraphic / Palette Changer 07",
        "1C2\t\tGraphic / Palette Changer 08",
        "1C3\t\tGraphic / Palette Changer 09",
        "1C4\t\tGraphic / Palette Changer 0A",
        "1C5\t\tGraphic / Palette Changer 0B",
        "1C6\t\tGraphic / Palette Changer 0C",
        "1C7\t\tGraphic / Palette Changer 0D",
        "1C8\t\tGraphic / Palette Changer 0E",
        "1C9\t\tGraphic / Palette Changer 0F",
        "1CA\t\tExtremely slow auto-scroll",
        "1CB\t\tSpecial auto-scroll 0",
        "1CC\t\tSpecial auto-scroll 1",
        "1CD\t\tSpecial auto-scroll 2",
        "1CE\t\tSpecial auto-scroll 3",
        "1CF\t\tSpecial auto-scroll 4",
        "1D0\t\tSpecial auto-scroll 5",
        "1D1\t\tSpecial auto-scroll 6",
        "1D2\t\tSpecial auto-scroll 7",
        "1D3\t\tSpecial auto-scroll 8",
        "1D4\t\tSlow auto-scroll",
        "1D5\t\tunknown",
        "1D6\t\tLock horizontal scroll",
        "1D7\t\tGusty generator",
        "1D8\t\tGusty generator stopper",
        "1D9\t\tLakitu stopper",
        "1DA\t\tFuzzy generator stopper",
        "1DB\t\tunknown",
        "1DC\t\tFang generator, from right",
        "1DD\t\tFang generator stopper",
        "1DE\t\tFang generator, from both sides",
        "1DF\t\tFang generator stopper",
        "1E0\t\tWall Lakitu generator?",
        "1E1\t\tunknown",
        "1E2\t\tDancing Spear Guy trigger",
        "1E3\t\tunknown",
        "1E4\t\tThunder Lakitu stopper",
        "1E5\t\tFlutter generator",
        "1E6\t\tFlutter generator stopper",
        "1E7\t\tNipper Spore generator",
        "1E8\t\tNipper Spore generator stopper",
        "1E9\t\tBaron Von Zeppelin with Needlenose generator",
        "1EA\t\tBaron Von Zeppelin with Needlenose generator stopper",
        "1EB\t\tBaron Von Zeppelin with bomb generator",
        "1EC\t\tBaron Von Zeppelin with bomb generator stopper",
        "1ED\t\tBalloon generator",
        "1EE\t\tBalloon generator stopper",
        "1EF\t\tFour yellow line guided Flatbed Ferries generator",
        "1F0\t\tLemon Drop generator",
        "1F1\t\tLemon Drop generator stopper",
        "1F2\t\tTurn off dizzy effect",
        "1F3\t\tunknown",
        "1F4\t\tFuzzy generator"
      };
      public static string[] Description = new string[501]
      {
        "A log can float on water or lava. If Yoshi steps on an edge of it, it will list and goes towards the direction it listed.",
        "A closed door Yoshi cannot enter. If the coordinates Yoshi first enters a level matched to this sprite's, there'll be an extra animation of Yoshi getting out of the door.",
        "A part of Naval Piranha's stalk. It hurts Yoshi.",
        "A crate that is breakable by Ground Pound. This sprite affects Item Memory.",
        "An item spawned from a Star Mario block.",
        "An icy watermelon. If Yoshi swallows it, he can spits out cold air 3 times to freeze enemies.",
        "Chill which can freeze enemies, spat by Yoshi thanks to an Icy Watermelon.",
        "A watermelon. If Yoshi swallows it, he can spits out 30 seeds.",
        "A rubble used for the battle with Giant Baby Bowser",
        "A fire watermelon. If Yoshi swallows it, he can spits out flame 3 times.",
        "A walking cannon.",
        "A cannonball shot by Kaboomba. It explodes after a little while.",
        "Raphael the Raven.",
        "A goal. Pass through to beat a level.",
        "A word, G O A L !.",
        "A signboard of BONUS CHALLENGE.",
        "A Caged Chost in the shape of a round mound. It spits out green Shy Guys if Yoshi doesn't have enough eggs.",
        "An item card which is a booty of Mini Battle.",
        "A red door leads Yoshi to a boss room.",
        "Boss explosion. Subsequently, Yoshi passes a level.",
        "A key from a defeated boss. Subsequently, Yoshi passes a level.",
        "A torpedo shot by Yoshi Submarine.",
        "Bigger Boo.",
        "A frog that has a very long tongue.",
        "Flame which Yoshi can spit thanks to a Red Watermelon",
        "A bubble. It pops up if touched.",
        "A ski lift Yoshi can ride on.",
        "A vertical log floating on lava. Even if Yoshi stands on it, it won't sink into lava entirely.",
        "A snowman. If Yoshi jumps on it, it spawns nothing, 6 stars, 1-up, or a Bumpty. Except the one containing nothing, this sprite affects Item Memory.",
        "A snowman on a ski lift.",
        "A creature that is masking to hide its face. The colour depends on its initial coordinates.",
        "Four rotating doors. If one of them is hit, other three doors will disappear and Yoshi can then enter the one hit. Depending on the number painted on the doors, it leads Yoshi to a different room.",
        "A creature trying to kidnap Baby Mario.",
        "A ? bucket that is empty, however, it can float on water or lava and Yoshi can ride in.",
        "A Flashing Egg that will spawn a red coin if hits an enemy. This sprite affects Item Memory.",
        "A Red Egg that will spawn 2 stars if hits an enemy. This sprite affects Item Memory.",
        "A Yellow Egg that will spawn a coin if hits an enemy. This sprite affects Item Memory.",
        "A Green Egg.",
        "A Giant Egg used for the battle with Bowser.",
        "A key that can unlock a locked door. This sprite affects Item Memory.",
        "A young Huffin' Puffin running away from Yoshi.",
        "A Giant Egg possibly used for the battle with Prince Froggy.",
        "A reg Giant Egg that is so heavy that it shakes grounds and it turns most of the enemies into a star.",
        "A green Giant Egg that is so heavy that it shakes grounds and it turns most of the enemies into a star.",
        "A large fish that tries to swallow Yoshi.",
        "Salvo the Slime.",
        "Salvo the Slime's eyes.",
        "The nest which Little Mouser inhabits. From this, it tries to attack Yoshi.",
        "A mouse that steals Yoshi's eggs.",
        "A cactus in a pot that is hopping around.",
        "A Little Mouser looking around (X:0) in its nest or (X:1) from behind stuff. This sprite is just a decoration.",
        "A Little Mouser that makes a surprise attack on Yoshi from its nest.",
        "Rogger the Potted Ghost.",
        "Possibly defeated Rogger the Potted Ghost.",
        "A large wooden wall that will fall down if Yoshi gets close to it.",
        "A purple ghost. If Yoshi got possessed by it, the right and the left key of the controller gets reversed.",
        "Flame spat out by Rogger the Potted Ghost.",
        "A spinning wooden platform.",
        "Three Mini-Ravens.",
        "Mini-Raven that rounds walls and ceilings.",
        "Tap-Tap the Red Nose.",
        "A seesaw using BG3.",
        "A skinny platform that lowers a little if stepped on. It can be broken by Ground Pound.",
        "A Slime that holding a key mimicking to a checker block. This sprite affects Item Memory.",
        "Baby Luigi used for the ending scene.",
        "The Stork used for the ending scene.",
        "A vertical pipe entrance. It makes tiles where this was placed enterable from the top.",
        "A red Giant Shy Guy possibly used for the battle with Prince Froggy.",
        "A green Giant Shy Guy possibly used for the battle with Prince Froggy.",
        "Prince Froggy. Depending on its initial coordinates, it will have different functions.",
        "Burt the Bushful.",
        "Shy Guys pushing Rogger the Potted Ghost.",
        "Kamek used for scenes before boss fights. Basically it will work if a boss was placed separately.",
        "The head of fire of the Thunder Lakitu which generats some fire on the ground on the way it passed.",
        "The hypocenter of Thunder Lakitu's thunder.",
        "The fire of the Thuner Lakitu.",
        "An upside down Blow Hard.",
        "An unknown sprite. It's either this is unused or it functions if generated by other sprite.",
        "A locked door. Once it's unlocked, it will be no longer open. This is used to lead Yoshi to Mini Battles. This sprite affects Item Memory.",
        "A middle ring. This sprite affects Item Memory.",
        "A board.",
        "A large wooden log.",
        "A balloon that is ridable.",
        "Kamek used for the scene where Naval Piranha was defeated without transforming.",
        "An upside down Wilde Piranha.",
        "A green Pinwheel that will begin spinning if being put on Yoshi's weight.",
        "A pink Pinwheel that will begin spinning if being put on Yoshi's weight. A small version of a green Pinwheel.",
        "A sewer ghost with a Flatbed Ferry on its head.",
        "A green Solo Toady flying around that tries to kidnap Baby Mario.",
        "A Super Star to continue its power. Only appears if Mario has the power.",
        "Spark generated by Raphael the Raven.",
        "A Bandit carrying a red coin on its head. Acts like a normal Bandit once jumped on. This sprite affects Item Memory.",
        "A pink Toadie. Swoops down as soon as Yoshi loses Baby Mario and tries to kidnap him.",
        "Do not use.",
        "A plank which will be tilted when Yoshi rides on.",
        "A plank which rotates periodically.",
        "A bomb.",
        "Baby Mario. This sprite is handled by the game specially, and should not be placed directly in a level.",
        "A Goomba. This one doesn't die even if jumped on. Can be killed by an egg, a enemy spat out, and Ground Pound.",
        "A purple mud-like creature. Yoshi can walk accross spikes if being on this creature.",
        "A pink Pinwheel always spinning. The direction depends on its initial X coordinate, and its size depends on its initial Y coordinate, respectively.",
        "A red coin. This sprite affects Item Memory.",
        "A Wild Piranha.",
        "A hidden Winged Cloud that will reveal if touched by a Chomp Rock, whose content depends on its initial coordinates. Except the one containing a seed, this sprite affects Item Memory.",
        "A Flashing Egg Block turns into a flashing egg if hit. This sprite affects Item Memory.",
        "A red Egg Block turns into a red egg if hit. This sprite affects Item Memory.",
        "A yellow Egg Block turns into a yellow egg if hit. This sprite affects Item Memory.",
        "A green Egg Block being hit. This sprite shouldn't be placed directly in a level.",
        "A large Spring Ball allows Yoshi to jump very high.",
        "A blue creature patrols around walls clockwise.",
        "A blue creature patrols around walls anticlockwise.",
        "A Spring Ball allows Yoshi to jump high.",
        "A crab has claws that can be enlarged. Takes 3 hits to be defeated.",
        "Has a different type depending on its initial coordinates. more than 2 'Big Boo with 3 Boos' should not appear simultaneously in the same screen.",
        "A grafitto on the walls attacks Train Yoshi if he's running on walls.",
        "A balloon pumper with a red balloon.",
        "A creature that pulls a large spiked ball out of its stomach.",
        "A spiked ball thrown by the Spike.",
        "Wisps of fire that circles around walls clockwise.",
        "Wisps of fire that circles around walls anticlockwise.",
        "A red Bill Blaster fires Bullet Bills chase Yoshi.",
        "A yellow Bill Blaster fires Bullet Bills recochet off of walls.",
        "A green Bill Blaster fires Bullet Bills.",
        "A red Bullet Bill chases Yoshi.",
        "A yellow Bullet Bill recochets off of walls.",
        "A green Bullet Bill goes straight horizontally.",
        "A dent of a castella. This sprite should not be placed directly in a level.",
        "A log seesaw. It will fall down if it tilted too much.",
        "A Lava Bubble, jumps out of lava straightly.",
        "A Lava Bubble jumps out of lava in an arc towards Yoshi.",
        "A Chain Chomp.",
        "Cloud drifting towards right, used for the battle against Giant Baby Bowser.",
        "Activates screen exit if Yoshi touched this sprite.",
        "A hedgehog with blue spines. Swells to a huge size if Yoshi gets close to it.",
        "Do not use.",
        "A red egg gives Yoshi 1-up.",
        "A Super Star gives Baby Mario Star Power.",
        "A red platform moving horizontally.",
        "A pink platform moving vertically.",
        "A balloon that gives Yoshi 1-up if he eats it, or pops up and a Fly Guy makes a surprise attack on Yoshi. This sprite affects Item Memory.",
        "Yoshi used for the Goal scene.",
        "A Fly Guy carrying an item which depends on its initial coordinates. This sprite affects Item Memory.",
        "Kamek at Bowser's room.",
        "A swing of Grinders.",
        "A Dangling Ghost attempts to grab Baby Mario.",
        "Four Toadies that try to kidnap Baby Mario. This sprite should not be placed directly in a level.",
        "A Melon Bug. You can roll it to kill most of the enemies.",
        "A door.",
        "A block that expands its size if hit from below.",
        "A blue checkered block that turns into a platform moves horizontally if hit.",
        "A red checkered block that turns into a platform moves vertically if hit.",
        "Turns most of the enemies into a star if hit. Since the count it's hit is shared by any POWs in a level, do not place more than 2 POWs in the same screen simultaneously.",
        "A Yoshi Block which makes Yoshi return back to its normal status from morphing status.",
        "A Spiny Egg thrown by a Lakitu.",
        "A chained green Flatbed Ferry that is spinning.",
        "A Shy Guy swinging a mace.",
        "A mace swung by a Mace Guy.",
        "An !-switch",
        "A Chomp Rock. You can roll to kill enemies and even use it to stand on to reach higher.",
        "A Wild Ptooie Piranha, spits Needlenoses. The count it spits out them at once depends on its initial X coordinate.",
        "A Tulip spits out 8 stars if Yoshi throws an enemy into it. This sprite affects Item Memory.",
        "A pot that Spiked Fun Guy can be in.",
        "A fireball thrown by the Thunder Lakitu. Once it tounches the ground, it'll burn down the ground.",
        "Bandit getting under cover and looking around from left side of stuff.",
        "Bandit getting under cover and looking around from right side of stuff.",
        "A giant creature that resides in water / lava whose colour depends on its initial X coordinate.",
        "An Incoming Chomp that will jumps off of backgrounds and destroy grounds.",
        "A flock of Incoming Chomps.",
        "A falling down Incoming Chomp.",
        "Shadow of a falling Incoming Chomp, which tells you where it will fall.",
        "Shy Guy wandering around in backgrounds, used as a decoration.",
        "Fills up slots of eggs, the effect of the item card.",
        "A sign arrow which tells the player where a rock will fall, used for the battle against Giant Baby Bowser",
        "A block that tells Yoshi messages. Depending on its initial coordinates, it will tell different messages.",
        "Hookbill the Koopa.",
        "A Morph Bubble that turns Yoshi into the Car that has different states depending on its initial coordinates. (X:0-Y:0) Is in Winged Cloud, (X:1-Y:0) normal state, (X:0-Y:1) seems unavailable, and (X:1-Y:1) floats towards Yoshi.",
        "A Morph Bubble that turns Yoshi into the Mole Tank that has different states depending on its initial coordinates. (X:0-Y:0) Is in Winged Cloud, (X:1-Y:0) normal state, (X:0-Y:1) seems unavailable, and (X:1-Y:1) floats towards Yoshi.",
        "A Morph Bubble that turns Yoshi into the Helicopter that has different states depending on its initial coordinates. (X:0-Y:0) Is in Winged Cloud, (X:1-Y:0) normal state, (X:0-Y:1) seems unavailable, and (X:1-Y:1) floats towards Yoshi.",
        "A Morph Bubble that turns Yoshi into the Train that has different states depending on its initial coordinates. (X:0-Y:0) Is in Winged Cloud, (X:1-Y:0) normal state, (X:0-Y:1) seems unavailable, and (X:1-Y:1) floats towards Yoshi.",
        "Wind that is broken when Yoshi eats a Fuzzy. It can kill some enemies or hit Winged Clouds.",
        "A Morph Bubble that turns Yoshi into the Submarine that has different states depending on its initial coordinates. (X:0-Y:0) Is in Winged Cloud, (X:1-Y:0) normal state, (X:0-Y:1) seems unavailable, and (X:1-Y:1) floats towards Yoshi.",
        "A hidden Winged Cloud will reveal if touched whose content depends on its initial coordinates. This sprite affects Item Memory.",
        "A Winged Cloud generates 8 coins around it. This sprite affects Item Memory.",
        "A Winged Cloud containing a bubbled 1-up which will affect Item Memory.",
        "A Winged Cloud containing a flower which will affect Item Memory.",
        "A Winged Cloud causes an instant POW which will turn most of the enemies into a star.",
        "A Winged Cloud creates stairs whose direction depends on its initial X coordinate.",
        "A Winged Cloud creates red platforms whose direction depends on its initial X coordinate.",
        "A Winged Cloud containing a Bandit.",
        "A Winged Cloud generates a coin. This sprite affects Item Memory.",
        "A Winged Cloud gives Yoshi 1-up. This sprite affects Item Memory.",
        "A Winged Cloud containing a key that will affect Item Memory.",
        "A Winged Cloud containing 3 stars. This sprite affects Item Memory.",
        "A Winged Cloud containing 5 stars. This sprite affects Item Memory.",
        "A Winged Cloud containing a door.",
        "A Winged Cloud eats ground.",
        "A Winged Cloud containing a watermelon.",
        "A Winged Cloud containing a fire watermelon.",
        "A Winged Cloud containing an icy watermelon.",
        "A Winged Cloud containing a seed that will grow into a sunflower with 3 leaves.",
        "A Winged Cloud containing a seed that will grow into a sunflower with 6 leaves.",
        "Do not use.",
        "A giant boss door of Bowser's room.",
        "A Winged Cloud containing a coin, a star, or 1-up randomly.",
        "(X:0) A Winged Cloud containing !-switch or (X:1) !-switch that will never reappear. Both of them affect Item Memory.",
        "A Baron Von Zeppelin carrying a Giant Egg used for the battle with Baby Bowser.",
        "Bowser's flame.",
        "Quake caused by Bowser which causes rocks to fall down.",
        "A horizontal entrance, towards right.",
        "A hidden entrance that will reveal by an !-switch.",
        "Marching Milde.",
        "A giant Milde that spawns 2 Large Mildes if Ground Pounded.",
        "A Large Milde that spawns 4 Mildes if Ground Pounded.",
        "Mountain backgrounds used for the battle with Hookbill the Koopa.",
        "A ghost with a green Flatbed Ferry on its head. Periodically stops moving and expands itself vertically.",
        "Sluggy the Unshaven.",
        "A Chomp signboard that tells Yoshi that in this area there are Incoming Chomps.",
        "Lakitu that is fishing to grab Baby Mario with it.",
        "A flower pot whose content depends on its initial coordinates. Except the one containing nothing, it will affect Item Memory.",
        "A soft thing that can be expanded by Ground Pound.",
        "A snowball. The more Yoshi rolls it, the larger it gets.",
        "The closer used in the battle with Naval Piranha. It shuts Yoshi into her room.",
        "A falling rock which can crush Yoshi to death.",
        "A fish can be killed by a torpedo of Yoshi Submarine.",
        "A jellyfish.",
        "A red fish takes 3 hits to be defeated.",
        "A Boo Blah.",
        "Boo Blah with Piro Dangle.",
        "A heading cactus.",
        "A green Needlenose.",
        "A Gusty whose direction and status depend on its initial coordinates.",
        "A Burt. The number depends on its initial X coordinate.",
        "A Goonie.",
        "Three Flightless Goonies.",
        "A Cloud Drop moving vertically.",
        "A Cloud Dtop moving horizontally.",
        "A Flamer Guy jumping around.",
        "A Flamer Guy walking around.",
        "A giant flower with five yellow petals.",
        "Egg-Dill's face. Don't place this sprite directly.",
        "A petal of Eggo-Dill.",
        "A plant spits out bubbles.",
        "A Stilt Guy whose colour depends on its initial coordinates.",
        "A Woozy Guy jumping around whose colour depends on its initial coordinates.",
        "A plant spits out (X:0) eggs or (X:1) Needlenoses.",
        "A batter who hits back eggs or seeds of a watermelon.",
        "A parent and children of Huffin' Puffins.",
        "A purple creature that spits out bubbles if stepped on.",
        "A creature of a cactus that shoots out yellow Needlenose at Yoshi.",
        "A yellow Needlenose.",
        "A flower uses bitmap for its graphic.",
        "A Shy Guy that has a long spear and a shield.",
        "A Shy Guy that has a short spear and a shield.",
        "A Bandit wearing Judo wear that shoots yellow energy.",
        "Energy of a Zeus Guy.",
        "A dog follows Yoshi and kills most of the enemies.",
        "A bubbled 1-up.",
        "A spiky mace spinning.",
        "A double-ended spiky mace spinning.",
        "Boo Guys spinning a spiky mace.",
        "A bone fish whose initial direction depends on its initial X coordinate.",
        "Boo Guys carrying bombs towards left in the ceiling and drop them towards Yoshi.",
        "Boo Guys carrying bombs towards right in the ceiling and drop them towards Yoshi.",
        "A seed of a watermelon.",
        "A Milde that pops up if stepped on.",
        "A Tap-Tap.",
        "A Tap-Tap says on ledges.",
        "A hopping Tap-Tap.",
        "A chained spik ball controlled by a Boo Guy.",
        "A Boo Guy rotating a pulley whose direction depends on its initial X coordinate.",
        "A crate containing 6 stars. This sprite affects Item Memory.",
        "A blindfolded Boo attacks Yoshi relying on sound.",
        "A flower.",
        "A pudding creature.",
        "A splashed Georgette Jelly.",
        "A Snifit shoots out a bullet at Yoshi.",
        "A bullet shot by Snifit.",
        "A coin.",
        "A floating round platform that lists if stepped on.",
        "A Donut Lift.",
        "A giant Donut Lift.",
        "A Shy Guy or a Bandit disguises into a ghost.",
        "A pitcher.",
        "A Lakitu. The number depends on its initial X coordinate.",
        "A Lakitu's cloud.",
        "A Spiny Egg thrown by a Lakitu.",
        "A brown Arrow Wheel that is rotating if not ridden on.",
        "A blue Arrow Wheel that is rotating if not ridden on. After a while, it will disappear.",
        "A double-ended arrow lift. If hit by an egg, it will rotate and point to another direction.",
        "Explosion of a Number Platform.",
        "A ? bucket containing a Bandit.",
        "A ? bucket containing 5 coins.",
        "A tall Shy Guy that spits out seeds of a watermelon if stepped on, whose colour depends on its initial coordinates.",
        "(X:0) Kamek for the ending scene after defeated Baby Bowser or (X:1) flying in backgrounds and then chases Yoshi.",
        "A spiked log held by chains and a pulley that question mark is painted.",
        "A pulley with the question mark painted, generated by the sprite #126. Don't place this sprite directly.",
        "Ground shake occured when ground-pounding the floor of Baby Bowser's room.",
        "A Fuzzy. If touched this, Yoshi gets dizzy.",
        "A green Shy Guy with hidden Bandit. If Yoshi tries to goes through this guy, a Bandit suddenly appears and kidnaps Baby Mario.",
        "A Fat Guy whose colour depends on its initial X coordinate.",
        "(X:0) A Fly Guy carrying a red coin or (X:1) Whirly Fly Guy that gives Yoshi coins and 1-ups if hit. This sprite affects Item Memory.",
        "Yoshi used in the intro scene. Don't place this sprite in the level.",
        "An unknown sprite. It's either this is unused or it functions if generated by other sprite.",
        "A Lava Drop moving horizontally.",
        "A Lava Drop moving vertically.",
        "A locked door. Once it's unlocked, it keeps opening. This sprite affects Item Memory.",
        "A yellow slime drops off of ceilings.",
        "A Lanter Ghost that has the same movement as Shy Guys'.",
        "Baby Bowser.",
        "A Raven circling always whose directio depends on its initial X coordinate.",
        "A Raven occasionally stops moving whose initial direction depends on its initial X coordinate.",
        "A 3x6 falling rock.",
        "A 3x3 falling rock.",
        "A 3x9 falling rock.",
        "A 6x3 falling rock.",
        "Stomach Acid of Prince Froggy.",
        "A flipper facing downwards.",
        "A Fang dangling and begins flying if Yoshi gets close to it.",
        "A Fang flying wavily.",
        "A Flopsy Fish swimming around.",
        "A Flopsy Fish swimming and occasionally jumps vertically.",
        "A Flopsy Fish swimming around and periodically jumps in an arc.",
        "A Flopsy Fish jumps 3 times in an arc whose direction depends on its initial X coordinate.",
        "A Spray Fish shoots out a jet of water that Yoshi cannot pass through.",
        "A flipper whose direction depends on its initial X coordinate.",
        "A blue Sluggy.",
        "A pink Sluggy.",
        "A horizonta entrance, towards left.",
        "A large Spring Ball possibly generated by a Baron Von Zeppelin carrying one. It reminds its coordinates, you should use another (06C) generally.",
        "An arrow cloud that leads an egg towards up.",
        "An arrow cloud that leads an egg towards up right.",
        "An arrow cloud that leads an egg towards right.",
        "An arrow cloud that leads an egg towards down right.",
        "An arrow cloud that leads an egg towards down.",
        "An arrow cloud that leads an egg towards down left.",
        "An arrow cloud that leads an egg towards left.",
        "An arrow cloud that leads an egg towards up left.",
        "An arrow cloud that leads an egg towards the direction it's currently pointing to.",
        "An image of a Wiggler.",
        "A Goonie carrying a green Shy Guy.",
        "A giant Chomp that eats sand blocks.",
        "A fat goonie that cannot fly satisfactorily apparently.",
        "A round cactus. The number depends on its initial X coordinate.",
        "A Wall Lakitu.",
        "A rolling flightless fat goonie.",
        "A creature waring a spiked helmet on its head that is walking.",
        "A creature waring a spiked helmet on its head that is running.",
        "A Dancing Spear Guy.",
        "A green switch that will reverse green spiked platforms.",
        "A red switch that will reverse red spiked platforms.",
        "A pink Pinwheel with Shy Guys, whose direction depends on its initial X coordinate.",
        "A green spiked platform.",
        "A red spiked platform.",
        "A bonus item that will appear after all enemies in the screen got defeated. The item type depends on its initial coordinates. This sprite affects Item Memory.",
        "Two spiked platforms with one switch in the center.",
        "A bouncing green Needlenose.",
        "A Nipper Plant.",
        "A Nipper Spore that turns into a Nipper Plant if it lands on.",
        "Thunder Lakitu. The number depends on its initial X coordinate.",
        "A green Koopa shell.",
        "A red Koopa shell.",
        "A green Beach Koopa.",
        "A red Beach Koopa.",
        "A green Koopa.",
        "A red Koopa.",
        "A green Para Koopa, jumping forth.",
        "A red Para Koopa, flying horizontally.",
        "A red Para Koopa, flying vertically.",
        "An Aqua Lakitu that resides in sewer.",
        "Naval Piranha.",
        "A Naval Bud.",
        "A Baron Von Zeppelin carrying a red Shy Guy.",
        "A Baron Von Zeppelin carring a Needlenose.",
        "A Baron Von Zeppelin carring a bomb.",
        "A Baron Von Zeppelin carring a Bandit.",
        "A Baron Von Zeppelin carring a large Spring Ball.",
        "A Baron Von Zeppelin carring 1-up. This sprite affects Item Memory.",
        "A Baron Von Zeppelin carring a key. This sprite affects Item Memory.",
        "A Baron Von Zeppelin carring 5 coins. This sprite affects Item Memory.",
        "A Baron Von Zeppelin carring a watermelon.",
        "A Baron Von Zeppelin carring a fire watermelon.",
        "A Baron Von Zeppelin carring an icy watermelon.",
        "A Baron Von Zeppelin carring a crate containing 6 stars. This sprite affects Item Memory.",
        "A Baron Von Zeppelin that has released what it carried.",
        "A Spinning Log.",
        "A Crazee Dayzee.",
        "A dragonfly used as a decoration.",
        "A butterfly used as a decoration.",
        "A Bumpty wandering around.",
        "A line guided green Flatbed Ferry always moving, initially goes left.",
        "A line guided green Flatbed Ferry always moving, initially goes right.",
        "A line guided yellow Flatbed Ferry always moving, initially goes left.",
        "A line guided yellow Flatbed Ferry always moving, initially goes right.",
        "A line guided green Flatbed Ferry begins moving if stepped on, initially goes left.",
        "A line guided green Flatbed Ferry begins moving if stepped on, initially goes right.",
        "A line guided yellow Flatbed Ferry begins moving if stepped on, initially goes left.",
        "A line guided yellow Flatbed Ferry begins moving if stepped on, initially goes right.",
        "A line guided red Flatbed Ferry begins moving if stepped on, initially goes left.",
        "A line guided red Flatbed Ferry begins moving if stepped on, initially goes right.",
        "A line guided round whirling lift.",
        "Makes an icicle fall down if Yoshi gets close to it.",
        "A sparrow used as a decoration.",
        "A Shy Guy wearing flowers for a camouflage.",
        "A Caged Ghost squeezing in sewer.",
        "A blargg resides in lava.",
        "An unknown sprite. It's either this is unused or it functions if generated by other sprite.",
        "An unbalanced snowy platform. If stepped on, it will fall down.",
        "An arrow sign whose direction depends on its initial coordinates.",
        "A diagonal arrow sign whose direction depends on its initial coordinates.",
        "A creature in the shape of a flower that will roll towards Yoshi if he gets close to it.",
        "A ghost Shy Guy.",
        "A Bumpty tries to tackle at Yoshi.",
        "A flying Bumpty (X:0) flying around or (X:1) flying straightly.",
        "A Skeleton Goonie.",
        "A Flightless Skeleton Goonie.",
        "A Skeleton Goonie carrying a bomb.",
        "A double-ended firebar whose direction depends on its initial X coordinate.",
        "A firebar whose direction depends on its initial X coordinate.",
        "A star, increases 1 point.",
        "A Little Skull Mouser that is jumping around.",
        "A cork sealing a 3D pipe.",
        "A monkey running away from Yoshi.",
        "A monkey spits seeds of a watermelon at Yoshi.",
        "(Y:0) A monkey throws bombs or (Y:1) Needlenoses, whose direction depends on its initial X coordinate.",
        "A monkey grasps Baby Mario.",
        "A monkey climbing and spits seeds of a watermelon.",
        "A Hot Lips shoots lava that kills Yoshi in an instant.",
        "A Boo Balloon whose content depends on its initial X coordinate.",
        "A frog used as a decoration.",
        "Kamek shoots magic at Yoshi.",
        "Kamek's magic.",
        "A stationary coin.",
        "A red balloon.",
        "The cannon shoots coins. Used in the Mini Battle, \"GATHER COINS\".",
        "A coin shot by a cannon. Used in the Mini Battle, \"GATHER COINS\".",
        "A Bandit trying to gather coins. Used in the Mini Battle, \"GATHER COINS\".",
        "A checkered platform. Used in the Mini Battle, \"POPPING BALLOONS\".",
        "A Bandit trying to pop red balloons. Used in the Mini Battle, \"POPPING BALLOONS\".",
        "A red balloon which can be popped by ground-pounding. Used in the Mini Battle, \"POPPING BALLOONS\".",
        "A Bandit wearing a mask of Yoshi. Used in the Mini Battle, \"WATERMELON SEED SPITTING CONTEST\".",
        "A pot generates a watermelon, and occasionally a fire watermelon. Used in the Mini Battle, \"WATERMELON SEED SPITTING CONTEST\".",
        "",
        "(X:0) Changes the current tileset to Cave 1, or (X:1) changes current palettes to Silver Cave.",
        "(X:0) Changes the current tileset to Forest 1, or (X:1) changes current palettes to Green Forest.",
        "(X:0) Changes the current tileset to Pond, or (X:1) changes current palettes to Pond.",
        "(X:0) Changes the current tileset to 3D stone, or (X:1) changes current palettes to Stone.",
        "(X:0) Changes the current tileset to Snow, or (X:1) changes current palettes to Snow.",
        "(X:0) Changes the current tileset to Jungle, or (X:1) changes current palettes to Green Jungle.",
        "(X:0) Changes the current tileset to Brick Castle, or (X:1) changes current palettes to Dark-Red Brick.",
        "(X:0) Changes the current tileset to Grass 1, or (X:1) changes current palettes to Blue-Green Grass.",
        "(X:0) Changes the current tileset to Cave 2, or (X:1) changes current palettes to\x007FStone Castle.",
        "(X:0) Changes the current tileset to Forest 2, or (X:1) changes current palettes to Yellow Flower Garden.",
        "(X:0) Changes the current tileset to Wooden Castle, or (X:1) changes current palettes to Yellow Grass.",
        "(X:0) Changes the current tileset to Sewer, or (X:1) changes current palettes to Sewer.",
        "(X:0) Changes the current tileset to Flower Garden, or (X:1) changes current palettes to Icy Cave.",
        "(X:0) Changes the current tileset to Sky, or (X:1) changes current palettes to Sky.",
        "(X:0) Changes the current tileset to Stone Castle, or (X:1) changes current palettes to Wooden Castle.",
        "(X:0) Changes the current tileset to Grass 2, or (X:1) changes current palettes to Green Flower Garden.",
        "Activates extremely slow auto-scroll towards right.",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "",
        "Activates slow auto-scroll towards right.",
        "An unknown command.",
        "Locks horizontal scroll.",
        "Generates Gusties.",
        "Stops generating Gusties.",
        "Stops Lakitu from chasing Yoshi.",
        "Stop generating Fuzzies.",
        "An unknown command.",
        "Generates Fangs from the right side of the display.",
        "Stops generating Fangs.",
        "Generates Fangs.",
        "Stops generating Fangs.",
        "Possibly Wall Lakitu generator. Apparently used with the Extended Object 80?",
        "An unknown command.",
        "Triggers Dancing Spear Guys to appear?",
        "An unknown command.",
        "Stops Thunder Lakitu from chasing Yoshi.",
        "Generates Flutters.",
        "Stops generating Flutters.",
        "Generates Nipper Spores.",
        "Stops generating Nipper Spores.",
        "Generates Baron Von Zeppelins carrying a Needlenose.",
        "Stops generating Baron Von Zeppelin carrying a Needlenose.",
        "Generates Baron Von Zeppelins carrying a bomb.",
        "Stops generating Baron Von Zeppelins carrying a bomb.",
        "Generates ridable balloons.",
        "Stops generating balloons.",
        "Possibly four line guided Flatbed Ferries. Their coordinates are possibly hardcoded.",
        "Generates Lemon Drops.",
        "Stops generating Lemon Drops.",
        "Turns off the dizzy effect.",
        "An unknown command.",
        "Generates Fuzzies."
      };
      public static byte[] ItemFlag = new byte[126]
      {
        (byte) 64,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 2,
        (byte) 80,
        (byte) 65,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 64,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 80,
        (byte) 0,
        (byte) 0,
        (byte) 64,
        (byte) 0,
        (byte) 0,
        (byte) 132,
        (byte) 21,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 64,
        (byte) 4,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 1,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 84,
        (byte) 1,
        (byte) 84,
        (byte) 5,
        (byte) 0,
        (byte) 0,
        (byte) 1,
        (byte) 0,
        (byte) 0,
        (byte) 32,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 16,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 1,
        (byte) 4,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 4,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 21,
        (byte) 16,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0
      };
    }

    [Flags]
    public enum ObjectFilter
    {
      OBJ = 1,
      EXOBJ = 2,
      CAVE1 = 4,
      FOREST1 = 8,
      POND = 16,
      THREE_D = 32,
      SNOW = 64,
      JUNGLE = 128,
      CASTLE1 = 256,
      GRASS1 = 512,
      CAVE2 = 1024,
      FOREST2 = 2048,
      CASTLE2 = 4096,
      SEWER = 8192,
      FLOWER = 16384,
      SKY = 32768,
      CASTLE3 = 65536,
      GRASS2 = 131072,
      KAMEK = 262144,
      ANIMATED = 524288,
      MISC = 1048576,
    }

    public class ObjectInformation
    {
      public static string[] Label = new string[246];
      public static string[] Description = new string[246];
      public static Level.ObjectFilter[] Filter = new Level.ObjectFilter[246];
      public static byte[] DefaultSize = new byte[246]
      {
        (byte) 68,
        (byte) 20,
        (byte) 20,
        (byte) 68,
        (byte) 66,
        (byte) 36,
        (byte) 34,
        (byte) 38,
        (byte) 35,
        (byte) 20,
        (byte) 20,
        (byte) 19,
        (byte) 49,
        (byte) 20,
        (byte) 20,
        (byte) 65,
        (byte) 65,
        (byte) 49,
        (byte) 65,
        (byte) 68,
        (byte) 65,
        (byte) 51,
        (byte) 51,
        (byte) 51,
        (byte) 67,
        (byte) 65,
        (byte) 19,
        (byte) 20,
        (byte) 19,
        (byte) 19,
        (byte) 69,
        (byte) 69,
        (byte) 68,
        (byte) 20,
        (byte) 20,
        (byte) 68,
        (byte) 19,
        (byte) 19,
        (byte) 212,
        (byte) 52,
        (byte) 204,
        (byte) 76,
        (byte) 19,
        (byte) 20,
        (byte) 22,
        (byte) 22,
        (byte) 21,
        (byte) 20,
        (byte) 20,
        (byte) 67,
        (byte) 52,
        (byte) 65,
        (byte) 67,
        (byte) 20,
        (byte) 65,
        (byte) 67,
        (byte) 66,
        (byte) 53,
        (byte) 51,
        (byte) 19,
        (byte) 20,
        (byte) 20,
        (byte) 19,
        (byte) 19,
        (byte) 65,
        (byte) 21,
        (byte) 20,
        (byte) 68,
        (byte) 51,
        (byte) 49,
        (byte) 67,
        (byte) 67,
        (byte) 20,
        (byte) 20,
        (byte) 19,
        (byte) 20,
        (byte) 21,
        (byte) 68,
        (byte) 51,
        (byte) 20,
        (byte) 65,
        (byte) 52,
        (byte) 65,
        (byte) 99,
        (byte) 67,
        (byte) 51,
        (byte) 65,
        (byte) 65,
        (byte) 50,
        (byte) 51,
        (byte) 36,
        (byte) 49,
        (byte) 49,
        (byte) 33,
        (byte) 35,
        (byte) 52,
        (byte) 35,
        (byte) 53,
        (byte) 65,
        (byte) 65,
        (byte) 65,
        (byte) 68,
        (byte) 68,
        (byte) 68,
        (byte) 68,
        (byte) 65,
        (byte) 84,
        (byte) 67,
        (byte) 19,
        (byte) 67,
        (byte) 20,
        (byte) 65,
        (byte) 65,
        (byte) 65,
        (byte) 18,
        (byte) 18,
        (byte) 18,
        (byte) 18,
        (byte) 18,
        (byte) 65,
        (byte) 65,
        (byte) 67,
        (byte) 52,
        (byte) 65,
        (byte) 65,
        (byte) 65,
        (byte) 67,
        (byte) 65,
        (byte) 65,
        (byte) 68,
        (byte) 81,
        (byte) 81,
        (byte) 36,
        (byte) 36,
        (byte) 68,
        (byte) 68,
        (byte) 68,
        (byte) 68,
        (byte) 68,
        (byte) 81,
        (byte) 20,
        (byte) 65,
        (byte) 84,
        (byte) 69,
        (byte) 21,
        (byte) 21,
        (byte) 21,
        (byte) 33,
        (byte) 33,
        (byte) 33,
        (byte) 33,
        (byte) 52,
        (byte) 20,
        (byte) 21,
        (byte) 21,
        (byte) 21,
        (byte) 68,
        (byte) 65,
        (byte) 33,
        (byte) 19,
        (byte) 19,
        (byte) 19,
        (byte) 68,
        (byte) 68,
        (byte) 20,
        (byte) 65,
        (byte) 34,
        (byte) 34,
        (byte) 19,
        (byte) 20,
        (byte) 20,
        (byte) 65,
        (byte) 65,
        (byte) 20,
        (byte) 65,
        (byte) 68,
        (byte) 65,
        (byte) 193,
        (byte) 193,
        (byte) 193,
        (byte) 193,
        (byte) 65,
        (byte) 65,
        (byte) 65,
        (byte) 65,
        (byte) 65,
        (byte) 65,
        (byte) 20,
        (byte) 20,
        (byte) 21,
        (byte) 21,
        (byte) 20,
        (byte) 20,
        (byte) 193,
        (byte) 65,
        (byte) 81,
        (byte) 21,
        (byte) 81,
        (byte) 81,
        (byte) 21,
        (byte) 81,
        (byte) 68,
        (byte) 67,
        (byte) 220,
        (byte) 60,
        (byte) 65,
        (byte) 65,
        (byte) 65,
        (byte) 20,
        (byte) 65,
        (byte) 68,
        (byte) 20,
        (byte) 20,
        (byte) 65,
        (byte) 65,
        (byte) 65,
        (byte) 65,
        (byte) 68,
        (byte) 68,
        (byte) 84,
        (byte) 68,
        (byte) 20,
        (byte) 65,
        (byte) 20,
        (byte) 52,
        (byte) 24,
        (byte) 84,
        (byte) 67,
        (byte) 196,
        (byte) 196,
        (byte) 228,
        (byte) 68,
        (byte) 68,
        (byte) 36,
        (byte) 20,
        (byte) 20,
        (byte) 68,
        (byte) 68,
        (byte) 68,
        (byte) 68,
        (byte) 68,
        (byte) 68,
        (byte) 68,
        (byte) 19,
        (byte) 67,
        (byte) 51
      };
    }

    public class ExObjectInformation
    {
      public static string[] Label = new string[256];
      public static string[] Description = new string[256];
      public static Level.ObjectFilter[] Filter = new Level.ObjectFilter[256];
    }
  }
}
