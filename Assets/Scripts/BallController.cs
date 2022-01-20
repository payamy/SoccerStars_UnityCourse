using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameManager gameManager;
    public EventSystemManager eventSystemManager;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            GoalController goalController = collision.gameObject.GetComponent<GoalController>();

            if (goalController.isLeft)
            {
                gameManager.rightPoint++;
                eventSystemManager.OnLeftGoalEnter.Invoke();
            }
            else
            {
                gameManager.leftPoint++;
                eventSystemManager.OnRightGoalEnter.Invoke();
            }

            transform.position = new Vector3(0, 0, 0);
        }
    }
}
