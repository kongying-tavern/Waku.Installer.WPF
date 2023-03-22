using System.Collections.Generic;

namespace WpfApp.Constants;

// TODO: Auto gen list.
public static class SkinList
{
    private const string IconsResourceDictionary = "Skins/Icons.xaml";
    private const string StylesResourceDictionary = "Skins/Styles.xaml";
    private const string LightSkinResourceDictionary = "Skins/LightSkin.xaml";
    private const string DarkSkinResourceDictionary = "Skins/DarkSkin.xaml";

    public static List<string> LightSkinList { get; } =
        new() { IconsResourceDictionary, StylesResourceDictionary, LightSkinResourceDictionary };

    public static List<string> DarkSkinList { get; } =
        new() { IconsResourceDictionary, StylesResourceDictionary, DarkSkinResourceDictionary };
}