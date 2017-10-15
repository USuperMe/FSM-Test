using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    //状态管理器的单例模式
    private static StateManager _instance;
    public static StateManager Instance
    {
        get { return _instance; }
    }
    public ASState[] states;
    protected List<ASState> m_StateList=new List<ASState>();
    protected Dictionary<string,ASState> m_StateDict=new Dictionary<string, ASState>();
    void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        for (int i = 0; i < states.Length; i++)
        {
            states[i].stateManager = this;
            m_StateDict.Add(states[i].GetName(),states[i]);
        }
        PushState(states[0].GetName());
    }
    public void SwitchState(string newState)
    {
        ASState state = FindState(newState);
        if (state == null)
        {
            Debug.Log("不能找到，是不是名字出错了");
            return;
        }
        m_StateList[m_StateList.Count-1].Exit(state);
        state.Enter(m_StateList[m_StateList.Count-1]);
        m_StateList.RemoveAt(m_StateList.Count-1);
        m_StateList.Add(state);
    }
    public void PushState(string name)
    {
        ASState state;
        if (!m_StateDict.TryGetValue(name, out state))
        {
            Debug.LogError("没有找到状态的名字");
            return;
        }
        if (m_StateList.Count > 0)
        {
            //保证m_StateList集合中始终只有一个状态存在，即不能多个状态同时启用
            m_StateList[m_StateList.Count-1].Exit(state);
            state.Enter(m_StateList[m_StateList.Count-1]);
        }
        else
        {
           state.Enter(null);
        }
        m_StateList.Add(state);
    }
    private ASState FindState(string stateName)
    {
        ASState state = null;
        if (!m_StateDict.TryGetValue(stateName, out state))
        {
            Debug.LogError("不存在次状态");
            return null;
        }
        return state;
    }
}
