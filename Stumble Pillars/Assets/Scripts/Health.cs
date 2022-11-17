using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float health = 4;
    public int numOfHearts = 4;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public GameObject GameOverMenu;
    public Text ScoreText;
    public Text highScoreText;
    public GameManager THING;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {

            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if ( health < 1)
        {
            gameOver();
        }

        void gameOver()
        {
            GameOverMenu.SetActive(true);       
            THING = FindObjectOfType<GameManager>();
            ScoreText.text = "Your score was " + THING.score;
            THING.GetComponent<GameManager>().enabled = false;
            highScoreText.text = "Highscore: " + GameManager.highscore;
            
            
        }


    }
}
