using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

public class XLuaManager : SingletonPatternMonoAutoBase_DontDestroyOnLoad<XLuaManager>
{
    private LuaEnv luaEnv = null;
    private const string luaScriptsFolder = "LuaScripts";
    private const string luaAssetbundleAssetName = "Lua";
    private const string gameMainScriptName = "GameMain";
    protected override void Awake()
    {
        base.Awake();
        luaEnv = new LuaEnv();
        luaEnv.AddLoader(CustomLoader);
    }
    
    public void SafeDoString(string scriptContent)
    {
        if (luaEnv != null)
        {
            try
            {
                luaEnv.DoString(scriptContent);
            }
            catch (System.Exception ex)
            {
                string msg = string.Format("xLua exception : {0}\n {1}", ex.Message, ex.StackTrace);
                Debug.LogError(msg);
            }
        }
    }
    
    private static byte[] SafeReadAllBytes(string inFile)
    {
        try
        {
            if (string.IsNullOrEmpty(inFile))
            {
                return null;
            }

            if (!File.Exists(inFile))
            {
                return null;
            }

            File.SetAttributes(inFile, FileAttributes.Normal);
            return File.ReadAllBytes(inFile);
        }
        catch (System.Exception ex)
        {
            // Logger.LogError(string.Format("SafeReadAllBytes failed! path = {0} with err = {1}", inFile, ex.Message));
            return null;
        }
    }
    
    private static byte[] CustomLoader(ref string filepath)
    {
        string scriptPath = string.Empty;
        filepath = filepath.Replace(".", "/") + ".lua";
#if UNITY_EDITOR
        scriptPath = Path.Combine(Application.dataPath, luaScriptsFolder);
        scriptPath = Path.Combine(scriptPath, filepath);
        //Logger.Log("Load lua script : " + scriptPath);
        return SafeReadAllBytes(scriptPath);
#endif

        // scriptPath = string.Format("{0}/{1}.bytes", luaAssetbundleAssetName, filepath);
        // string assetbundleName = null;
        // string assetName = null;
        // bool status = AssetBundleManager.Instance.MapAssetPath(scriptPath, out assetbundleName, out assetName);
        // if (!status)
        // {
        //     #if UNITY_EDITOR
        //     Logger.LogError("MapAssetPath failed : " + scriptPath);
        //     #endif
        //     return null;
        // }
        // XLuaManager.Instance._loader.Bundle.LoadAsset<Bytes>()
        // assetName = assetName.Replace("Lua/", "");
        //var asset = AssetBundleManager.Instance.GetAssetCache(assetName) as TextAsset;
        // string assetsPath = AssetBundleUtility.PackagePathToAssetsPath(scriptPath);
        // var asset = Instance._loader.Bundle.LoadAsset<TextAsset>(assetsPath);
        // if (asset != null)
        // {
        //     //Logger.Log("Load lua script : " + scriptPath);
        //     return asset.bytes;
        // }
        // Logger.LogError("Load lua script failed : " + scriptPath + ", You should preload lua assetbundle first!!!");
        return null;
    }

    public void StartGame()
    {
        LoadScript(gameMainScriptName);
        SafeDoString("GameMain.Start()");
    }
    
    void LoadScript(string scriptName)
    {
        SafeDoString(string.Format("require('{0}')", scriptName));
    }

void Update()
        {
            if (luaenv != null)
            {
                luaenv.Tick();
            }
        }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        luaEnv.Dispose();
        luaEnv = null;
    }
}
