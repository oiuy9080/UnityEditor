using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorLayoutMgr : EditorWindow
{

[MenuItem("MyFunction/Example")]
static void Open()
    {
        GetWindow<EditorLayoutMgr>();
    }

    bool toggleValue;

    private void OnGUI()
    {
        EditorGUI.BeginChangeCheck();

        toggleValue = EditorGUILayout.ToggleLeft("Toggle", toggleValue);
        toggleValue = EditorGUILayout.BeginToggleGroup("Toggle", toggleValue);
        toggleValue = EditorGUILayout.ToggleLeft("Toggle", toggleValue);
        toggleValue = EditorGUILayout.ToggleLeft("Toggle", toggleValue);
        toggleValue = EditorGUILayout.ToggleLeft("Toggle", toggleValue);
        EditorGUILayout.EndToggleGroup();

        if (EditorGUI.EndChangeCheck())
        {
            if(toggleValue)
            {
                Debug.Log("toggleValue가 true 로 된 순간 호출됨.");
            }
        }

        //EditorGUILayout.LabelField("Example Label");


    }

}
