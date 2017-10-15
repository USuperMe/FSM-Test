using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.UI;

public class ShopState :ASState
{

    [Header("商店系统")]
    private Text shopText;
    [SerializeField]
    private string stateName;

    public override void Enter(ASState from)
    {
        this.gameObject.SetActive(true);
        shopText = transform.GetChild(0).GetComponent<Text>();
        shopText.text = "我是老板，有什么东西找我买...";
    }

    public override void Exit(ASState to)
    {
        this.gameObject.SetActive(false);
        shopText.text = "谢谢惠顾，欢迎下次光临.....";
    }

    public override string GetName()
    {
       return stateName;
    }

    public void GoToTaskState()
    {
        stateManager.SwitchState("task");
    }

    public void GoToIntegralState()
    {
        stateManager.SwitchState("integral");
    }
}
