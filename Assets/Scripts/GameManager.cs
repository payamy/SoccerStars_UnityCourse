using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int leftPoint;
    public int rightPoint;

    public int maxPoint;

    public EventSystemManager eventSystem;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (leftPoint == maxPoint)
        {
            // call win event
            eventSystem.OnLeftWin.Invoke();

            // make ball fixed
            Destroy(FindObjectOfType<BallController>().GetComponent<Rigidbody2D>());
        }
        if (rightPoint == maxPoint)
        {
            // call lose event
            eventSystem.OnRightWin.Invoke();

            // make ball fixed
            Destroy(FindObjectOfType<BallController>().GetComponent<Rigidbody2D>());
        }
    }
}
