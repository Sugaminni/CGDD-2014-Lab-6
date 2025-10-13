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


    // Update is called once per frame
    void Update()
    {

    }

}

