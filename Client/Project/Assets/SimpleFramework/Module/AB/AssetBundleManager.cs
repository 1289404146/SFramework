using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using Object = UnityEngine.Object;

public class AssetBundleManager : MonoBehaviour
{
	// AB包管理器目的是：让外部更方便地进行资源加载
	// AB包不能重复加载，重复加载会报错，其中的资源不限制
	// 用字典来存储加载过的AB包
	private Dictionary<string, AssetBundle> abDic = new Dictionary<string, AssetBundle>();
	// 主包和相关配置文件只需要加载一次即可，因此声明相关变量
	// 主包
	private AssetBundle mainAB = null;
	// 依赖包获取用的配置文件
	private AssetBundleManifest manifest = null;


	// AB包存放路径，方便修改
	private string PathUrl
	{
		get { return Application.streamingAssetsPath + "/";; }// @"http://localhost:80/cube.unity3d"; }//Application.streamingAssetsPath + "/";  /* 假设是该路径 */ }
	}

	// 主包名，方便修改
	private string MainABName
	{
		get
		{
#if UNITY_IOS
			return "IOS";
#elif UNITY_ANDROID
			return "Andriod";
#else
			return "PC";
#endif
		}
	}

	// 确保了每个包都只加载了一次
	public void LoadAB(string abName)
	{
		// 加载AB主包和其中的关键配置文件
		if (mainAB == null)
		{
            mainAB = AssetBundle.LoadFromFile(PathUrl + "StreamingAssets");
            //UnityWebRequest webRequest = UnityWebRequestAssetBundle.GetAssetBundle(PathUrl);
            //yield return webRequest.SendWebRequest();
            //   mainAB = DownloadHandlerAssetBundle.GetContent(webRequest);
            manifest = mainAB.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
		}

		// 获取依赖包的信息
		AssetBundle ab = null;
		string[] strs = manifest.GetAllDependencies(abName);

		for (int i = 0; i < strs.Length; ++i)
		{
			if (!abDic.ContainsKey(strs[i]))
			{
				ab = AssetBundle.LoadFromFile(PathUrl + strs[i]);
				abDic.Add(strs[i], ab);
			}
		}

		// 加载资源来源包
		// 如果没有加载过，再加载
		if (!abDic.ContainsKey(abName))
		{
			ab = AssetBundle.LoadFromFile(PathUrl + abName);
			abDic.Add(abName,ab);
		}
	}



	// 对同步加载进行重载，因为通过泛型可以避免as转换，并且Lua不支持泛型，
	// 因此还需要使用type重载
	// 同步加载, 不指定类型
	// 加载abName包中的resName资源
	public Object LoadRes(string abName, string resName)
	{
		// 加载AB包
		LoadAB(abName);
		// 加载资源
		Object obj = abDic[abName].LoadAsset(resName);
		// 为了外面方便，再加载资源时，判断一下资源是不是GameObject
		// 如果是，直接实例化，否则返回给外部
		if (obj is GameObject)
			return Instantiate(obj);
		else
			return obj;
	}

	// 同步加载，根据type指定类型
	public Object LoadRes(string abName, string resName, System.Type type)
	{
		// 加载AB包
		LoadAB(abName);
		// 加载资源
		Object obj = abDic[abName].LoadAsset(resName, type);
		// 为了外面方便，再加载资源时，判断一下资源是不是GameObject
		// 如果是，直接实例化，否则返回给外部
		if (obj is GameObject)
			return Instantiate(obj);
		else
			return obj;
	}

	// 同步加载，根据泛型指定类型
	// 必须要加约束，因为LoadAsset<T>方法带有约束
	public T LoadRes<T>(string abName, string resName) where T : Object
	{
		// 加载AB包
		LoadAB(abName);
		// 加载资源
		T obj = abDic[abName].LoadAsset<T>(resName);
		// 为了外面方便，再加载资源时，判断一下资源是不是GameObject
		// 如果是，直接实例化，否则返回给外部
		if (obj is GameObject)
			return Instantiate(obj);
		else
			return obj;
	}

	// 异步加载的方法，由于异步加载无法马上使用资源，需要使用委托
	// 来知道资源加载完后应该怎样使用资源
	// 这里的异步加载，AB包并没有使用异步加载
	// 只是从AB包中加载资源时，使用异步
	// 和同步一样重载
	// 根据名字异步加载资源
	public void LoadResAsync(string abName, string resName, UnityAction<Object> callBack)
	{
		StartCoroutine(ReallyLoadResAsync(abName, resName, callBack));
	}

	private IEnumerator ReallyLoadResAsync(string abName, string resName, UnityAction<Object> callBack)
	{
		LoadAB(abName);
		AssetBundleRequest abr = abDic[abName].LoadAssetAsync(resName);
		yield return abr;

		// 异步加载结束后，通过委托传递给外部来使用
		if (abr.asset is GameObject)
			callBack(Instantiate(abr.asset));
		else
			callBack(abr.asset);
	}

	// 根据type异步加载资源
	public void LoadResAsync(string abName, string resName, System.Type type, UnityAction<Object> callBack)
	{
		StartCoroutine(ReallyLoadResAsync(abName, resName, type, callBack));
	}

	private IEnumerator ReallyLoadResAsync(string abName, string resName, System.Type type, UnityAction<Object> callBack)
	{
		LoadAB(abName);
		AssetBundleRequest abr = abDic[abName].LoadAssetAsync(resName, type);
		yield return abr;

		// 异步加载结束后，通过委托传递给外部来使用
		if (abr.asset is GameObject)
			callBack(Instantiate(abr.asset));
		else
			callBack(abr.asset);
	}

	// 根据泛型异步加载资源
	public void LoadResAsync<T>(string abName, string resName, UnityAction<T> callBack) where T : Object
	{
		StartCoroutine(ReallyLoadResAsync<T>(abName, resName, callBack));
	}

	private IEnumerator ReallyLoadResAsync<T>(string abName, string resName, UnityAction<T> callBack) where T : Object
	{
		LoadAB(abName);
		AssetBundleRequest abr = abDic[abName].LoadAssetAsync<T>(resName);
		yield return abr;

		// 异步加载结束后，通过委托传递给外部来使用
		if (abr.asset is GameObject)
			callBack(Instantiate(abr.asset) as T);
		else
			callBack(abr.asset as T);
	}


	// 单个包的卸载
	public void UnLoad(string abName)
	{
		if (abDic.ContainsKey(abName)) {
			abDic[abName].Unload(false);
			abDic.Remove(abName);
		}
	}

	// 所有包的卸载
	public void ClearAB()
	{
		AssetBundle.UnloadAllAssetBundles(false);
		abDic.Clear();
		mainAB = null;
		manifest = null;
	}









	private void Start()
    {
        //StartCoroutine(FromWebRequest());
    }
    private IEnumerator FromWebRequest()
    {
        // http://localhost:80/chuwan2.unity3d
      //  string path = @"http://localhost:80/cube.unity3d";
        string path = @"E:\Demo\SimpleFM\Unity\Project\Assets\StreamingAssets\cube.unity3d";
        string path1 = Application.streamingAssetsPath+@"\cube.unity3d";
        string path2 = @"http://localhost:80/cube.unity3d";


        UnityWebRequest webRequest = UnityWebRequestAssetBundle.GetAssetBundle(path2);
        yield return webRequest.SendWebRequest();
        AssetBundle assetBundle = DownloadHandlerAssetBundle.GetContent(webRequest);
        //object obj = assetBundle.LoadAsset("Image");
        //Instantiate((GameObject)obj, FindObjectOfType<Canvas>().transform);
        object[] objects = assetBundle.LoadAllAssets();
        foreach (var item in objects)
        {
            Instantiate((GameObject)item, FindObjectOfType<Canvas>().transform);
            Debug.Log(webRequest);
        }
        yield return null;
    }
}

