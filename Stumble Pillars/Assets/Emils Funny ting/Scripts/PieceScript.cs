using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceScript : MonoBehaviour
{
    Rigidbody2D rb2D;

    private void Start()
    {
        GameObject myGameObject = gameObject;
        rb2D = myGameObject.AddComponent<Rigidbody2D>();
        Collider2D col2D = gameObject.AddComponent<BoxCollider2D>();
        rb2D.gravityScale = 0f;
        gameObject.AddComponent(typeof(PieceMovement));
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeadZone")
        {
            Destroy(gameObject);
        }

        
        rb2D.gravityScale = 1f;
        Destroy(gameObject.GetComponent(typeof(PieceMovement)));
    }
}
