using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public float boxWidth;
    public float pieceDistance;
    Vector3 cameraPosition = Vector3.zero;
    Vector3 currentSpeed = Vector3.zero;
    private void Update()
    {
        RaycastHit2D hit;
        if (hit = Physics2D.BoxCast(transform.position, new Vector2(boxWidth, 1), 0, Vector2.down, Mathf.Infinity))
        {
            if (hit.transform.tag == "PlacedPiece" && hit.distance < pieceDistance)
            {
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(0, cameraPosition.y+5, -10), ref currentSpeed, 5);
                cameraPosition = transform.position;
            }
        }  
    }
}
