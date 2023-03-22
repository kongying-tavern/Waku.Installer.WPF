using System;
using System.Collections.Generic;
using System.Windows;

using WpfApp.Constants;

namespace WpfApp;

public partial class App
{
    private void SkinsLoader()
    {
        // New key will replace old key.
        ResourceDictionary lightSkinResourceDictionary = CreateSkinResourceDictionary(SkinList.LightSkinList);
        // New key will replace old key.
        ResourceDictionary darkSkinResourceDictionary = CreateSkinResourceDictionary(SkinList.DarkSkinList);
        // Set resources to app properties.
        Properties[Global.LightSkinName] = lightSkinResourceDictionary;
        Properties[Global.DarkSkinName] = darkSkinResourceDictionary;
    }

    private static ResourceDictionary CreateSkinResourceDictionary(List<string> skinList)
    {
        ResourceDictionary skinResourceDictionary = new();
        MergedDictionaries(skinResourceDictionary, skinList);
        return skinResourceDictionary;
    }

    private static void MergedDictionaries(ResourceDictionary resDic, List<string> dicNames)
    {
        foreach (string dicName in dicNames)
        {
            // LoadComponent is NOT thread safe.
            resDic.MergedDictionaries.Add(
                (ResourceDictionary)LoadComponent(new Uri(dicName, UriKind.Relative)));
        }
    }
}