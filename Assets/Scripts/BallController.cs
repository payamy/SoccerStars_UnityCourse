using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameManager gameManager;
    public EventSystemManager eventSystemManager;
    public Rigidbody2D rb;
    
    private void Update()
    {
        if (!rb) return;
        if (rb.velocity.magnitude < 0.005f)
            rb.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            GoalController goalController = collision.gameObject.GetComponent<GoalController>();
            var goalSide = goalController.isLeft ? GoalSide.Left : GoalSide.Right;
            GameManager.Instance.BallEnteredGoal(goalSide);
            eventSystemManager.goalEvent.Invoke(goalSide);
        }
    }
}
