using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastScore : MonoBehaviour
{

    float raycastLenght;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
 


        if (Input.GetKey(KeyCode.Space))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
            Debug.DrawRay(transform.position, Vector2.down, Color.red);

            if (hit)
            {
                Debug.Log(hit.distance);
            }
        }
    }
}
