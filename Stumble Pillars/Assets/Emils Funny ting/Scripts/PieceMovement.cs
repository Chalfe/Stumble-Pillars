using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovement : MonoBehaviour
{
    Vector3 piecePosition = Vector3.zero;
    public int speed = 2;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            piecePosition = transform.position;
            piecePosition.x -= 1f;
            transform.position = piecePosition;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            piecePosition = transform.position;
            piecePosition.x += 1f;
            transform.position = piecePosition;
        }

        transform.Translate(Vector3.down * Time.deltaTime * speed);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        speed = 0;
    }
}
