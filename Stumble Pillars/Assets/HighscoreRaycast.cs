using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreRaycast : MonoBehaviour
{
    int realScore;
    float fakeScore;

    void Update()
    {
        RaycastHit2D hit;
        if (hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity))
        {
            Debug.Log(hit.distance);

        }

    }
}
