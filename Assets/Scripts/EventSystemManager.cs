using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemManager : MonoBehaviour
{
    public GoalEvent goalEvent;
    public UnityEvent onLeftWin;
    public UnityEvent onRightWin;
    public UnityEvent onTie;


    private void Awake()
    {
        goalEvent = new GoalEvent();
        onLeftWin = new UnityEvent();
        onRightWin = new UnityEvent();
        onTie = new UnityEvent();
    }
}

[Serializable]
public class GoalEvent : UnityEvent<GoalSide> { }

[Serializable]
public enum GoalSide
{
    Left, Right
}
