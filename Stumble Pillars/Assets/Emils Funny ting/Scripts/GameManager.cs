using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float boxWidth;
    public float pieceDistance;
    public float maxPieceDistance;
    Vector3 cameraPosition = Vector3.zero;
    Vector3 currentSpeed = Vector3.zero;
    #region variables
    public List<GameObject> pieceList = new List<GameObject>();
    private int livesPlayerOne;
    private int livesPlayerTwo;
    private int currentPiece;
    private int nextPiece;
    private int pieceCount;
    #endregion
    private void Start() { newGame(); }
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

        if (GameObject.FindGameObjectWithTag("CurrentPiece") == null) newPiece(); 
    
    }
    private void newGame()
    {
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
        GameObject go = (GameObject)Instantiate(pieceToBeSpawned, new Vector2(0, transform.position.y + 4), Quaternion.identity);
        go.AddComponent(typeof(PieceScript));
        go.tag = "CurrentPiece";
        pieceCount++;
    }
    private void showPiece(GameObject pieceToBeShown)
    {
        GameObject go = (GameObject)Instantiate(pieceToBeShown, new Vector2(transform.position.x + 7, transform.position.y), Quaternion.identity);
        go.tag = "Icon";
    }
}
