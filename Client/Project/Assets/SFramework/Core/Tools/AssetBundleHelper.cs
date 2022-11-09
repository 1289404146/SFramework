// 用于字符串转换，减少GC
using System.Collections.Generic;

public static class AssetBundleHelper
{
	public static readonly Dictionary<int, string> IntToStringDict = new Dictionary<int, string>();
	public static readonly Dictionary<string, string> StringToABDict = new Dictionary<string, string>();
	public static readonly Dictionary<string, string> BundleNameToLowerDict = new Dictionary<string, string>()
		{
			{ "StreamingAssets", "StreamingAssets" }
		};

	public static string IntToString(int value)
	{
		string result;

		if (IntToStringDict.TryGetValue(value, out result))
		{
			return result;
		}

		result = value.ToString();
		IntToStringDict[value] = result;
		return result;
	}

	public static string StringToAB(string value)
	{
		string result;

		if (StringToABDict.TryGetValue(value, out result))
		{
			return result;
		}

		result = value + ".unity3d";
		StringToABDict[value] = result;
		return result;
	}

	public static string IntToAB(int value)
	{
		return StringToAB(IntToString(value));
	}

	public static string BundleNameToLower(string value)
	{
		string result;

		if (BundleNameToLowerDict.TryGetValue(value, out result))
		{
			return result;
		}

		result = value.ToLower();
		BundleNameToLowerDict[value] = result;
		return result;
	}
}