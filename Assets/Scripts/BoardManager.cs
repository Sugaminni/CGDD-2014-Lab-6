using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{

    private Pieces[,] board; // 2D array to represent the chess board

    // Start is called before the first frame update
    void Start()
    {
        board = new Pieces[8, 8]; // Initialize the board
    }

     private enum Pieces
    {
        None = -1,
        BLACK_KING, BLACK_QUEEN, BLACK_BISHOP, BLACK_KNIGHT, BLACK_ROOK, BLACK_PAWN,
        WHITE_KING, WHITE_QUEEN, WHITE_BISHOP, WHITE_KNIGHT, WHITE_ROOK, WHITE_PAWN
    }

    // Update is called once per frame
    void Update()
    {

    }

}

