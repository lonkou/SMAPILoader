﻿using Newtonsoft.Json.Linq;
using System.IO;
using System.Text.Json.Nodes;

namespace SMAPIGameLoader.Launcher;

public class ModItemView
{
    public string NameText = "Unknow";
    public string VersionText = "Unknow";
    public string FolderPathText = "Unknow";

    public readonly string modName;
    public readonly string modVersion;
    public readonly string modFolderPath;

    public ModItemView(string manifestFilePath, int modListIndex)
    {
        var manifestText = File.ReadAllText(manifestFilePath);
        var manifest = JObject.Parse(manifestText);

        this.modName = manifest["Name"].ToString();
        this.modVersion = manifest["Version"].ToString();

        this.NameText = $"[{modListIndex + 1}]: {modName}";
        this.VersionText = $"Version: {modVersion}";
        var manifestDir = Path.GetDirectoryName(manifestFilePath);
        this.modFolderPath = manifestDir;

        var relativeModDir = modFolderPath.Substring(modFolderPath.IndexOf("/Mods") + 5);
        FolderPathText = $"Folder: {relativeModDir}";
    }
}
