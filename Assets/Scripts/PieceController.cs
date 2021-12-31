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

    private Rigidbody2D rb;

    Vector2 force;

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        movePermission = false;
        player = FindObjectOfType<PlayerController>();

        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movePermission && player.isReleased)
        {
            //force = new Vector2(Mathf.Clamp(player.startPoint.x - player.endPoint.x, minPower.x, maxPower.x),
            //    Mathf.Clamp(player.startPoint.y - player.endPoint.y, minPower.y, maxPower.y));
            
            force = new Vector2(player.startPoint.x - player.endPoint.x, player.startPoint.y - player.endPoint.y);

            rb.AddForce(force * power, ForceMode2D.Impulse);

            player.isReleased = false;
            movePermission = false;
        }

    }
}
