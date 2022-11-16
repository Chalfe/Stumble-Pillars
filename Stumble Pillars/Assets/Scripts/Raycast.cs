using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public float boxWidth;
    public float pieceDistance;
    public float maxPieceDistance;
    Vector3 cameraPosition = Vector3.zero;
    Vector3 currentSpeed = Vector3.zero;
    private void Update()
    {
        RaycastHit2D hit;
        if (hit = Physics2D.BoxCast(transform.position, new Vector2(boxWidth, 1), 0, Vector2.down, Mathf.Infinity))
        {
            if (hit.transform.tag != "CurrentPiece" && hit.distance < pieceDistance)
            {
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(0, cameraPosition.y + pieceDistance + 4, -10), ref currentSpeed, 1);
                cameraPosition = transform.position;
            }

            if (hit.transform.tag != "CurrentPiece" && hit.distance > maxPieceDistance)
            {
                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(0, cameraPosition.y - maxPieceDistance, -10), ref currentSpeed, 1);
                cameraPosition = transform.position;
            }
            
        }  
    }
}
