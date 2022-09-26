using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceGenerator : MonoBehaviour
{
    public List<GameObject> pieceList = new List<GameObject>();
    public GameObject pieceSpawner;
    public GameObject nextPieceInList;
    private int currentPieceNumber;
    private int nextPiece;
    private void Start()
    {
        pieceListGeneration();
        currentPieceNumber = -1;
        nextPiece = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {            
            if (currentPieceNumber < 13)
            {
                currentPieceNumber++;
                nextPiece++;
            }
            else
            {
                pieceListGeneration();
                currentPieceNumber = 0;
                nextPiece = 0;
            }
            Instantiate(pieceList[nextPiece], nextPieceInList.transform.position, Quaternion.identity);
            spawnNextPiece(pieceList[currentPieceNumber]);
        }
    }
    void pieceListGeneration()
    {
        for (int i = 0; i < pieceList.Count; i++)
        {
            GameObject temp = pieceList[i];
            int randomIndex = Random.Range(i, pieceList.Count);
            pieceList[i] = pieceList[randomIndex];
            pieceList[randomIndex] = temp;
        }            
    }
    void spawnNextPiece(GameObject pieceName)
    {
        GameObject go = (GameObject)Instantiate(pieceName, pieceSpawner.transform.position, Quaternion.identity);
        go.AddComponent(typeof(PieceScript));
    }
}