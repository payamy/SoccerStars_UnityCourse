using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PieceController[] pieces;
    
    private Camera cam;
    
    public Vector3 startPoint;
    public Vector3 endPoint;

    public bool isDragged;
    public bool isReleased;
    
    void Start()
    {
        isDragged = false;
        isReleased = false;
        cam = Camera.main;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDragged)
        {
            pieces = FindObjectsOfType<PieceController>();
            Vector3 v3Pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            v3Pos = cam.ScreenToWorldPoint(v3Pos);

            for (int i = 0; i < pieces.Length; i++)
            {
                float distance = Vector2.Distance(v3Pos, pieces[i].transform.position);
                if (distance < 1f && pieces[i].turn)
                {
                    startPoint = pieces[i].transform.position;

                    pieces[i].movePermission = true;
                    isDragged = true;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (isDragged)
            {
                endPoint = cam.ScreenToWorldPoint(Input.mousePosition);

                isDragged = false;
                isReleased = true;
            }
        }

        if (GameManager.Instance.turnStarted && GameManager.Instance.PiecesMoveEnded())
        {
            GameManager.Instance.turnStarted = false;
            GameManager.Instance.ChangeTurn();
        }
    }
}
