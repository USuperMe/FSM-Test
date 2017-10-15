using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntegralState:ASState
{

    [Header("计分系统")]
    private Text integralText;
    [SerializeField]
    private string stateName;

    void Start()
    {
        
    }
    public override void Enter(ASState @from)
    {
        this.gameObject.SetActive(true);
        integralText = transform.GetChild(0).GetComponent<Text>();
        integralText.text = "我是计分系统，你的分数由我主宰";
    }

    public override void Exit(ASState to)
    {
        this.gameObject.SetActive(false);
        integralText.text = "我要退出了";
    }

    public override string GetName()
    {
       return stateName;
    }
    public void GoToTaskState()
    {
        stateManager.SwitchState("task");
    }

    public void GoToShopState()
    {
        stateManager.SwitchState("shop");
    }
}
