
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
class BuildConfig:EditorWindow
{
    [MenuItem("Tools/导表工具")]
    public static void BuildGameConfig()
    {
        // GetWindow(typeof(BuildEditor));
       GetWindow<BuildConfig>(true, "导表工具");

    }
	string fileName1= "bat.bat";

	private void OnGUI()
    {
		try
		{
			const string clientPath = "./Assets/Res/Config";

			if (GUILayout.Button("导出客户端配置"))
			{
				//this.isClient = true;

				//ExportAll(clientPath);

				//ExportAllClass(@"./Assets/Model/Module/Demo/Config", "namespace ETModel\n{\n");
				//ExportAllClass(@"./Assets/Hotfix/Module/Demo/Config", "using ETModel;\n\nnamespace ETHotfix\n{\n");
				var p = @"E:\Demo\SimpleFM\Client\Luban\" + fileName1;
				Debug.Log(Application.dataPath);

				Application.OpenURL(p);
				//Log.Info($"导出客户端配置完成!");
			}

			if (GUILayout.Button("导出服务端配置"))
			{
				//this.isClient = false;

				//ExportAll(ServerConfigPath);

				//ExportAllClass(@"../Server/Model/Module/Demo/Config", "namespace ETModel\n{\n");

				//Log.Info($"导出服务端配置完成!");
			}
		}
		catch (Exception e)
		{
			//Log.Error(e);
		}
	}
}
