using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit_Stuff : MonoBehaviour
{
    private float time_passed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time_passed += Time.deltaTime;


            if (Input.GetKeyDown(KeyCode.D) && time_passed > 2f)
            {
              SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

        }

            if (Input.GetKeyDown(KeyCode.A) && time_passed > 2f)
            {
              SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

    }

}
