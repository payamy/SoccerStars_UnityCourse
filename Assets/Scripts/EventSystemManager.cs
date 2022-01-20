using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemManager : MonoBehaviour
{
    public WinEvent winEvent;
    public UnityEvent OnLeftWin;
    public UnityEvent OnRightWin;


    private void Awake()
    {
        winEvent = new WinEvent();
        OnLeftWin = new UnityEvent();
        OnRightWin = new UnityEvent();
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
