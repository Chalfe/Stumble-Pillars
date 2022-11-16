using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieceScript : MonoBehaviour
{
    Rigidbody2D rb2D;
    public GameObject PieceDestroyer;
    private float minusOne = -1f;


    private void Start()
    {
        GameObject myGameObject = gameObject;
        rb2D = myGameObject.AddComponent<Rigidbody2D>();
        rb2D.gravityScale = 0f;
        rb2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        gameObject.AddComponent(typeof(PieceMovement));
        PieceDestroyer = GameObject.FindGameObjectWithTag("DeadZone");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeadZone")
        {
            Destroy(gameObject);
            PieceDestroyer.GetComponent<Health>().health = PieceDestroyer.GetComponent<Health>().health - 1; 
        }
        rb2D.gravityScale = 1f;
        Destroy(gameObject.GetComponent(typeof(PieceMovement)));


    }
}
