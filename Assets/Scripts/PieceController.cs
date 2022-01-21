using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    public float power = 10f;

    public bool turn;
    public bool movePermission;
    public Transform arrow;

    public Rigidbody2D rb;

    Vector2 force;

    private PlayerController player;
    private Vector3 arrowFirstScale;
    
    void Start()
    {
        movePermission = false;
        player = FindObjectOfType<PlayerController>();
        arrowFirstScale = arrow.localScale;
    }
    
    void Update()
    {
        if (movePermission && player.isReleased && !GameManager.Instance.turnStarted)
        {   
            force = new Vector2(player.startPoint.x - player.endPoint.x, player.startPoint.y - player.endPoint.y);
            arrow.gameObject.SetActive(false);
            rb.AddForce(force * power, ForceMode2D.Impulse);
            GameManager.Instance.turnStarted = true;
            arrow.localScale = arrowFirstScale;
            player.isReleased = false;
            movePermission = false;
        }
        else if (movePermission && !player.isReleased)
        {
            
            arrow.gameObject.SetActive(true);
            var endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // endPoint.z = 15;
            arrow.rotation = Quaternion.FromToRotation(Vector3.down,
                new Vector2(player.startPoint.x - endPoint.x, player.startPoint.y - endPoint.y));
            var arrowScale = arrow.localScale;
            arrowScale.y = new Vector2(player.startPoint.x - endPoint.x, player.startPoint.y - endPoint.y).magnitude;
            arrow.localScale = arrowScale;
        }

        if (rb.velocity.magnitude < 0.005f)
            rb.velocity = Vector2.zero;

    }
}
