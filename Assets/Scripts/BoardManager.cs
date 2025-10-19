using UnityEngine;
using System.Text;

public class BoardManager : MonoBehaviour
{
    // Enum representing the chess pieces
    private enum Pieces
    {
        None = -1,
        BLACK_KING, BLACK_QUEEN, BLACK_BISHOP, BLACK_KNIGHT, BLACK_ROOK, BLACK_PAWN,
        WHITE_KING, WHITE_QUEEN, WHITE_BISHOP, WHITE_KNIGHT, WHITE_ROOK, WHITE_PAWN
    }

    private Pieces[,] board;              // 2D array for the chessboard
    private const float TILE_SIZE = 1.1142857f; // Size of each tile on the board

    void Start()
    {
        board = new Pieces[8, 8]; // Initializes 8x8 chessboard
        PopulateBoard();           // Sets up initial chess layout
        PrintBoard();              // Prints layout to console
        SpawnAllPieces();          // Instantiates all pieces into the scene
    }

    // Populates the board with the standard chess setup
    private void PopulateBoard()
    {
        // Clear board first
        for (int x = 0; x < 8; x++)
            for (int y = 0; y < 8; y++)
                board[x, y] = Pieces.None;

        // Place pawns
        for (int x = 0; x < 8; x++)
        {
            board[x, 1] = Pieces.WHITE_PAWN;
            board[x, 6] = Pieces.BLACK_PAWN;
        }

        // White back row
        board[0, 0] = Pieces.WHITE_ROOK;
        board[1, 0] = Pieces.WHITE_KNIGHT;
        board[2, 0] = Pieces.WHITE_BISHOP;
        board[3, 0] = Pieces.WHITE_QUEEN;
        board[4, 0] = Pieces.WHITE_KING;
        board[5, 0] = Pieces.WHITE_BISHOP;
        board[6, 0] = Pieces.WHITE_KNIGHT;
        board[7, 0] = Pieces.WHITE_ROOK;

        // Black back row
        board[0, 7] = Pieces.BLACK_ROOK;
        board[1, 7] = Pieces.BLACK_KNIGHT;
        board[2, 7] = Pieces.BLACK_BISHOP;
        board[3, 7] = Pieces.BLACK_QUEEN;
        board[4, 7] = Pieces.BLACK_KING;
        board[5, 7] = Pieces.BLACK_BISHOP;
        board[6, 7] = Pieces.BLACK_KNIGHT;
        board[7, 7] = Pieces.BLACK_ROOK;
    }

    // Prints the board layout in the console
    private void PrintBoard()
    {
        var sb = new StringBuilder();
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
                sb.Append(((int)board[x, y]).ToString()).Append('|');
            sb.AppendLine();
        }
        Debug.Log(sb.ToString());
    }

    // Instantiates all pieces based on their array positions
    private void SpawnAllPieces()
    {
        for (int y = 0; y < 8; y++)
            for (int x = 0; x < 8; x++)
                SpawnPieceAt(x, y);
    }

    // Spawns a single piece at a given position
    private void SpawnPieceAt(int x, int y)
    {
        var piece = board[x, y];
        if (piece == Pieces.None) return; // Skips empty tiles

        string prefabName = GetPrefabName(piece);
        GameObject prefab = Resources.Load<GameObject>(prefabName);

        if (prefab == null)
        {
            Debug.LogError("Missing prefab: " + prefabName);
            return;
        }

        Instantiate(prefab, new Vector3(x * TILE_SIZE, 0f, y * TILE_SIZE), Quaternion.identity);
    }

    // Maps each enum value to its prefab name
    private string GetPrefabName(Pieces p)
    {
        switch (p)
        {
            case Pieces.BLACK_KING: return "bKing";
            case Pieces.BLACK_QUEEN: return "bQueen";
            case Pieces.BLACK_BISHOP: return "bBishop";
            case Pieces.BLACK_KNIGHT: return "bKnight";
            case Pieces.BLACK_ROOK: return "bRook";
            case Pieces.BLACK_PAWN: return "bPawn";
            case Pieces.WHITE_KING: return "wKing";
            case Pieces.WHITE_QUEEN: return "wQueen";
            case Pieces.WHITE_BISHOP: return "wBishop";
            case Pieces.WHITE_KNIGHT: return "wKnight";
            case Pieces.WHITE_ROOK: return "wRook";
            case Pieces.WHITE_PAWN: return "wPawn";
            default: return "";
        }
    }
}
