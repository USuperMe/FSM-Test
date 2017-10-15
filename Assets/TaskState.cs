using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskState:ASState
{

    [Header("任务系统")]
    private Text taskText;
    [SerializeField]
    private string stateName;

    void Start()
    {
        
    }
    public override void Enter(ASState @from)
    {
        this.gameObject.SetActive(true);
        taskText = transform.GetChild(0).GetComponent<Text>();
        taskText.text = "我是任务系统：你的任务就是了解有限状态机.....";
    }

    public override void Exit(ASState to)
    {
        this.gameObject.SetActive(false);
        taskText.text = "结束任务，我要退出舞台了";
    }

    public override string GetName()
    {
        return stateName;
    }
    public void GoToShopState()
    {
        stateManager.SwitchState("shop");
    }

    public void GoToIntegralState()
    {
        stateManager.SwitchState("integral");
    }
}
