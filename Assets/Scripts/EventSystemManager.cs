using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemManager : MonoBehaviour
{
    public WinEvent goalEvent;
    public UnityEvent onLeftWin;
    public UnityEvent onRightWin;
    public UnityEvent onTie;


    private void Awake()
    {
        goalEvent = new WinEvent();
        onLeftWin = new UnityEvent();
        onRightWin = new UnityEvent();
        onTie = new UnityEvent();
    }
}

[Serializable]
public class WinEvent : UnityEvent<GoalSide>
{
    
}

[Serializable]
public enum GoalSide
{
    Left, Right
}
