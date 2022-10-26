using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public enum Language
{
    Chinese = 0,
    English,
    Japanese,
    Korean

}
public class LocalizationManager : BaseMono,IManager
{

    private void Awake()
    {
        InitLocalizationManager(chinese);
    }
    private string chinese = "Chinese";
    private string english = "English";
    private Language languageState = Language.Chinese;
    public Language LanguageState
    {
        get { return languageState; }
        set { languageState = value; }
    }



    //选择自已需要的本地语言  
    public string language;


    private Dictionary<int, string> dic = new Dictionary<int, string>();
    private Dictionary<int, List<string>> dics = new Dictionary<int, List<string>>();

    /// <summary>  
    /// 读取配置文件，将文件信息保存到字典里  
    /// </summary>  
    public void  InitLocalizationManager(string language)
    {
        dics.Clear();
        TextAsset ta1 = Resources.Load<TextAsset>("Language/Language");
        string text1 = ta1.text;
        Debug.Log(text1);
        string[] lines1 = text1.Split('\n');
        foreach (string line in lines1)
        {
            if (line == null)
            {
                continue;
            }
            string[] keyAndValue = line.Split('=');
            string[] strs=new string[keyAndValue.Length-1];
            Array.Copy(keyAndValue,1, strs,0, keyAndValue.Length - 1);
            dics.Add(int.Parse(keyAndValue[0]),new List<string>(strs));
        }
        dic.Clear();
        TextAsset ta = Resources.Load<TextAsset>("Language/" + language);
        string text = ta.text;
        Debug.Log(text);

        string[] lines = text.Split('\n');
        foreach (string line in lines)
        {
            if (line == null)
            {
                continue;
            }
            string[] keyAndValue = line.Split('=');
            dic.Add(int.Parse(keyAndValue[0]), keyAndValue[1]);
        }
    }

    /// <summary>  
    /// 获取value  
    /// </summary>  
    /// <param name="key"></param>  
    /// <returns></returns>  
    public string GetValue(int key)
    {
        if (dic.ContainsKey(key) == false)
        {
            return null;
        }
        if (languageState == Language.Chinese)
        {

        }
        else if(languageState == Language.English)
        {
            
        }
        string value = null;
        dic.TryGetValue(key, out value);
        return value;
    }
    public string GetLanguageByID(int key)
    {
        if (dics.ContainsKey(key) == false)
        {
            return null;
        }
        List<string> value = null;
        dics.TryGetValue(key, out value);
        return value[(int)languageState];
    }

    public void Initilize()
    {
        Debug.Log("LocalizationManager------Initilize");
    }

    public void DeInitilize()
    {
        Debug.Log("LocalizationManager------DeInitilize");
    }
}
