using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HierarchyMgr : MonoBehaviour
{

    [MenuItem("GameObject/MyCategory/Custom Game Object", false, priority: 0)]
    static void CreateCustomGameObject(MenuCommand menuCommand)
    {
        // 1. Custom GameObject 이름으로 새 Object를 만든다.
        GameObject go = new GameObject("Custom Game Object");

        // 2. Hierachy 윈도우에서 어떤 오브젝트를 선택하여 생성시에는 그 오브젝트의 하위 계층으로 생성된다.
        // 그밖의 경우에는 아무일도 일어나지 않는다.
        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);


        // 3. 생성된 오브젝트를 Undo 시스템에 등록한다.
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);

        // 4. 생성한 오브젝트를 선택한다.
        Selection.activeObject = go;
    }

    [MenuItem("GameObject/MyCategory/SetOrigin", false, priority: 0)]
    static void SetOrigin(MenuCommand menuCommand)
    {
        GameObject temp = Selection.activeObject as GameObject;
        if (temp.transform.parent == null)
            temp.transform.GetChild(0).parent = null;
        else
            temp.transform.GetChild(0).parent = temp.transform.parent;

        DestroyImmediate(Selection.activeObject);

    }
}
