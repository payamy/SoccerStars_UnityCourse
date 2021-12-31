using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemManager : MonoBehaviour
{
    public UnityEvent OnRightGoalEnter;
    public UnityEvent OnLeftGoalEnter;
    public UnityEvent OnLeftWin;
    public UnityEvent OnRightWin;


    private void Awake()
    {
        OnRightGoalEnter = new UnityEvent();
        OnLeftGoalEnter = new UnityEvent();
        OnLeftWin = new UnityEvent();
        OnRightWin = new UnityEvent();
    }
}
