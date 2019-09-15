using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Make4Engine : MonoBehaviour
{

    public enum Piece { Blue, Yellow, Empty };
    public enum GameStatus { Playing, Won, Draw };

    const int ROW_COUNT = 6;
    const int COL_COUNT = 7;

    const int TOTAL_OF_PIECES = ROW_COUNT * COL_COUNT;

    int piecesPutted = 0;

    Piece[,] board = new Piece[ROW_COUNT, COL_COUNT];
    int[,] teste = new int[8, 8];


    private void Start()
    {
        Reset();
    }


    public void Reset()
    {
        for (int i = 0; i < ROW_COUNT; i++)
        {
            for (int j = 0; j < COL_COUNT; j++)
            {
                board[i, j] = Piece.Empty;
            }

            piecesPutted = 0;
        }

    }

    public bool IsDraw()
    {
        return piecesPutted == TOTAL_OF_PIECES;
    }

    private int GetRowFreeAtCol(int col)
    {
        for (int row = ROW_COUNT - 1; row >= 0; row--)
        {
            if (board[row, col] == Piece.Empty) return row;
        }
        return -1;
    }


    public GameStatus GetGameStatus()
    {
        if (IsWon(Piece.Blue) || IsWon(Piece.Yellow)) return GameStatus.Won;
        if (IsDraw()) return GameStatus.Draw;
        return GameStatus.Playing;
    }


    public bool ExecuteMove(int col, Piece color)
    {
        int row = GetRowFreeAtCol(col);
        if (row < 0) return false;

        board[row, col] = color;
        piecesPutted++;
        return true;
    }

    public Piece GetPieceAt(int row, int col)
    {
        return board[row, col];
    }

    private bool IsWon(Piece color)
    {
        for (int i = 0; i < ROW_COUNT; i++)
        {
            for (int j = 0; j < COL_COUNT; j++)
            {
                if (board[i, j] == color)
                {
                    if (IsThisPieceMakingFour(new Vector2Int(i, j)))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private bool IsThisPieceMakingFour(Vector2Int pos)
    {
        if (board[pos.x, pos.y] == Piece.Empty) return false;

        if (IsSameColor(pos, new Vector2Int(pos.x, pos.y + 1)) && IsSameColor(pos, new Vector2Int(pos.x, pos.y + 2)) && IsSameColor(pos, new Vector2Int(pos.x, pos.y + 3))) return true;

        if (IsSameColor(pos, new Vector2Int(pos.x + 1, pos.y)) && IsSameColor(pos, new Vector2Int(pos.x + 2, pos.y)) && IsSameColor(pos, new Vector2Int(pos.x + 3, pos.y))) return true;

        if (IsSameColor(pos, new Vector2Int(pos.x + 1, pos.y + 1)) && IsSameColor(pos, new Vector2Int(pos.x + 2, pos.y + 2)) && IsSameColor(pos, new Vector2Int(pos.x + 3, pos.y + 3))) return true;

        if (IsSameColor(pos, new Vector2Int(pos.x + 1, pos.y - 1)) && IsSameColor(pos, new Vector2Int(pos.x + 2, pos.y - 2)) && IsSameColor(pos, new Vector2Int(pos.x + 3, pos.y - 3))) return true;

        return false;
    }

    private bool IsSameColor(Vector2Int pos1, Vector2Int pos2)
    {
        if (pos1.x < 0 || pos1.x >= ROW_COUNT || pos2.x < 0 || pos2.x >= ROW_COUNT) return false;
        if (pos1.y < 0 || pos1.y >= COL_COUNT || pos2.y < 0 || pos2.y >= COL_COUNT) return false;

        return (board[pos1.x, pos1.y] == board[pos2.x, pos2.y]);
    }


    public List<int> GenerateLegalMoves()
    {
        List<int> moves = new List<int>();
        if (board[0, 0] == Piece.Empty) moves.Add(0);
        if (board[0, 1] == Piece.Empty) moves.Add(1);
        if (board[0, 2] == Piece.Empty) moves.Add(2);
        if (board[0, 3] == Piece.Empty) moves.Add(3);
        if (board[0, 4] == Piece.Empty) moves.Add(4);
        if (board[0, 5] == Piece.Empty) moves.Add(5);
        if (board[0, 6] == Piece.Empty) moves.Add(6);

        return moves;
    }


    public bool DoMove(Piece color)
    {
        List<int> moves = GenerateLegalMoves();
        int index = UnityEngine.Random.Range(0, moves.Count);
        return ExecuteMove(moves[index], color);
    }

    public List<Vector2Int> GetWinnerSequence()
    {
        List<Vector2Int> pieces = new List<Vector2Int>();

        for (int i = 0; i < ROW_COUNT; i++)
        {
            for (int j = 0; j < COL_COUNT; j++)
            {
                Vector2Int pos = new Vector2Int(i, j);
                if (IsThisPieceMakingFour(pos))
                {
                    pieces.Add(pos);
                }
            }
        }
        return pieces;
    }


    public void Tests()
    {

        Reset();


        if (piecesPutted != 0)
        {
            throw new Exception("function Reset failed");
        }
        else
        {
            print("function Reset - passed");
        }


        ExecuteMove(0, Piece.Blue);
        ExecuteMove(1, Piece.Blue);
        ExecuteMove(2, Piece.Blue);
        ExecuteMove(3, Piece.Blue);
        if (piecesPutted != 4)
        {
            throw new Exception("function ExecuteMove failed");
        }

        if (IsWon(Piece.Blue))
        {
            print("four blue pieces on the first horizontal passed");
        }
        else
        {
            throw new Exception("function ExecuteMove() and/or IsWon() failed");
        }

        Reset();

        ExecuteMove(0, Piece.Yellow);
        ExecuteMove(0, Piece.Yellow);
        ExecuteMove(0, Piece.Yellow);
        ExecuteMove(0, Piece.Yellow);
        if (piecesPutted != 4)
        {
            throw new Exception("function ExecuteMove failed");
        }

        if (IsWon(Piece.Yellow))
        {
            print("four Yellow pieces on the first col passed");
        }
        else
        {
            throw new Exception("function ExecuteMove() and/or IsWon() failed");
        }


        Reset();

        ExecuteMove(0, Piece.Blue);
        ExecuteMove(1, Piece.Yellow);
        ExecuteMove(1, Piece.Blue);
        ExecuteMove(2, Piece.Yellow);
        ExecuteMove(2, Piece.Yellow);
        ExecuteMove(2, Piece.Blue);
        ExecuteMove(3, Piece.Yellow);
        ExecuteMove(3, Piece.Yellow);
        ExecuteMove(3, Piece.Yellow);
        ExecuteMove(3, Piece.Blue);
        if (piecesPutted != 10)
        {
            throw new Exception("function ExecuteMove failed");
        }

        if (IsWon(Piece.Blue))
        {
            print("four Blue pieces on the diagonal(left and right)  passed");
        }
        else
        {
            throw new Exception("function ExecuteMove() and/or IsWon() failed");
        }

        List<int> moves = GenerateLegalMoves();
        print(moves.Count);
        if (moves.Count != 7)
        {
            print(board.ToString());
            throw new Exception("function GenerateLegalMoves() failed");
        }


        print("OK - ALL tests passed!");
    }
}
