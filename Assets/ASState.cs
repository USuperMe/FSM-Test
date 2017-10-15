using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ASState : MonoBehaviour {
    [HideInInspector]
    public StateManager stateManager;

    public abstract void Enter(ASState from);

	public abstract void Exit(ASState to);

    public abstract string GetName();
}
