using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Serialization;

[ExecuteInEditMode] // <- 실행중이 아니라도 모노비헤비어 주요함수가 호출.
                    //씬 Asset을 더블클릭해서, 씬을 로드할 때에는 Awake와 Start 함수가,
                    //인스펙터 등에서 컴포넌트의 변수 등을 변경하면 Update가 호출됨. 
                    //또한, OnGUI 에서 설치된 GUI가 에디터의 GUI 렌더링 사이클을 돌면서 표시되는식.

[AddComponentMenu("MyMenu/EditorMgr")] // <- 컴포넌트를 추가할수 있게 한다. 이렇게 할 경우 Script/ 에는 존재하지 않는다.
                                       //경로는 바꿔준것.

[RequireComponent(typeof(Animator))] // <- 이건 적어두고 나면 다시 Attach 해줘야 한다.
[DisallowMultipleComponent] // <- 같은 컴포넌트 2개이상 못넣도록 함.
[SelectionBase] // <- 해당 컴포넌트를 넣어두면 씬에서 오브젝트 클릭시 부모보다 자식이 먼저 선택됨.
public class EditorMgr : MonoBehaviour
{
    [SerializeField]
    [FormerlySerializedAs("name1")] // 변수명이 바뀔때 인스펙트를 안바꾸기 위해 이전의 이름을 적어주는 것.
    private string name;


    [Tooltip("이건 설명해주는 것이다.")]
    public long tooltip;

    [Header("PlayerSetting")]
    [Range(1, 50)]
    public int num;

    [Multiline(3)]
    public string textMultiLine;
    [TextArea(1,3)]
    public string textArea;

    [ContextMenuItem("Second", "Second")]
    [ContextMenuItem("Third", "Third")]
    [ContextMenuItem("First", "First")]
    public int item;

    [ContextMenu("MyFunction/MyReset")] // <- 커넥스트 메뉴랑 호출장소가 다르다.
    private void MyReset()
    {
        Debug.Log("Reset");
    }



    [Header("ColorSetting")]

    public Color col;
    [ColorUsage(false)]
    public Color col2;
    [Space(10)]
    [ColorUsage(true, true, 0, 8, 0.125f, 3)]
    public Color col3;







    private void First()
    {
        Debug.Log("First");
    }
    private void Second()
    {
        Debug.Log("Second");
    }
    private void Third()
    {
        Debug.Log("Third");
    }




    private void Awake()
    {
        Debug.Log("Awake");
    }

    private void Start()
    {
        Debug.Log("Start");
    }

    private void Update()
    {
        Debug.Log("Update");
    }
}
