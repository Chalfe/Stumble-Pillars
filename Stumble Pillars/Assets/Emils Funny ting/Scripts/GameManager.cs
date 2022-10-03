using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region variables
    public List<GameObject> pieceList = new List<GameObject>();
    private GameObject playerOneCamera;
    Vector3 playerOneCameraPosition = Vector3.zero;
    private int livesPlayerOne;
    private int livesPlayerTwo;
    private int currentPiece;
    private int nextPiece;
    private int pieceCount;
    #endregion
    private void Start() { newGame(); }
    private void Update() { if (GameObject.FindGameObjectWithTag("CurrentPiece") == null) newPiece(); }
    private void newGame()
    {
        playerOneCamera = GameObject.Find("Main Camera");
        pieceCount = 0;
        nextPiece = 1;
        setLivesPlayerOne(3);
        setLivesPlayerTwo(3);
        pieceListGeneration();
        newPiece();
    }
    public void newPiece()
    {
        spawnPiece(pieceList[currentPiece]);
        showPiece(pieceList[nextPiece]);
        if (currentPiece < 13) currentPiece++; else currentPiece = 0;
        if (nextPiece < 13) nextPiece++; else nextPiece = 0;
        if (pieceCount > 4) 
        {
            playerOneCameraPosition = playerOneCamera.transform.position;
            playerOneCameraPosition.y += 1f;
            playerOneCamera.transform.position += Vector3.up;
            pieceCount = 0;
        }
    }
    #region lives 
    private void setLivesPlayerOne(int livesPlayerOne)
    {
        this.livesPlayerOne = livesPlayerOne;
    }

    private void setLivesPlayerTwo(int livesPlayerTwo)
    {
        this.livesPlayerTwo = livesPlayerTwo;
    }
    #endregion 
    private void pieceListGeneration()
    {
        for (int i = 0; i < pieceList.Count; i++)
        {
            GameObject temp = pieceList[i];
            int randomIndex = Random.Range(i, pieceList.Count);
            pieceList[i] = pieceList[randomIndex];
            pieceList[randomIndex] = temp;
        }
    }
    private void spawnPiece(GameObject pieceToBeSpawned)
    {
        GameObject go = (GameObject)Instantiate(pieceToBeSpawned, new Vector2(-6.5f, 4 + playerOneCameraPosition.y), Quaternion.identity);
        go.AddComponent(typeof(PieceScript));
        go.tag = "CurrentPiece";
        pieceCount++;
    }
    private void showPiece(GameObject pieceToBeShown)
    {
        GameObject go = (GameObject)Instantiate(pieceToBeShown, new Vector2(7, 4), Quaternion.identity);
        go.tag = "Icon";
    }
}
