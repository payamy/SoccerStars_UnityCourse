using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    public float power = 10f;

    public Vector2 minPower;
    public Vector2 maxPower;

    public bool turn;
    public bool movePermission;
    public Transform arrow;

    public Rigidbody2D rb;

    Vector2 force;

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        movePermission = false;
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movePermission && player.isReleased && !GameManager.Instance.turnStarted)
        {
            //force = new Vector2(Mathf.Clamp(player.startPoint.x - player.endPoint.x, minPower.x, maxPower.x),
            //    Mathf.Clamp(player.startPoint.y - player.endPoint.y, minPower.y, maxPower.y));
            
            force = new Vector2(player.startPoint.x - player.endPoint.x, player.startPoint.y - player.endPoint.y);
            arrow.gameObject.SetActive(false);
            rb.AddForce(force * power, ForceMode2D.Impulse);
            GameManager.Instance.turnStarted = true;
            player.isReleased = false;
            movePermission = false;
        }
        else if (movePermission && !player.isReleased)
        {
            
            arrow.gameObject.SetActive(true);
            var endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            print(endPoint);
            endPoint.z = 15;
            arrow.rotation = Quaternion.FromToRotation(Vector3.down,
                new Vector2(player.startPoint.x - endPoint.x, player.startPoint.y - endPoint.y));
            var arrowScale = arrow.localScale;
            arrowScale.y = new Vector2(player.startPoint.x - endPoint.x, player.endPoint.y - endPoint.y).magnitude;
            arrow.localScale = arrowScale;
        }

        if (rb.velocity.magnitude < 0.001f)
        {
            rb.velocity = Vector2.zero;
        }

    }
}
