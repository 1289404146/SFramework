using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;

public class GenerateUICode : EditorWindow
{
    [MenuItem("Tools/生成UI")]
    public static void GenerateUI()
    {
       GetWindow<GenerateUICode>("自动绑定UI代码");
    }
}
