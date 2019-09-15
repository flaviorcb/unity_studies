using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] GameObject bluePiece;
    [SerializeField] GameObject yellowPiece;
    [SerializeField] GameObject[] cells;
    [SerializeField] Text text;
    [SerializeField] Button buttonNewGame;
    Make4Engine engine;
    Arrow arrow;

    // Start is called before the first frame update
    void Start()
    {
        engine = FindObjectOfType<Make4Engine>();
        arrow = FindObjectOfType<Arrow>();
        NewGame();

    }


    private int BoardPositionToViewPosition(int row, int col)
    {
        return row * 7 + col;
    }


    private void UpdateBoard()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (engine.GetPieceAt(i, j) == Make4Engine.Piece.Blue)
                {

                    Instantiate(bluePiece, cells[BoardPositionToViewPosition(i, j)].transform.position, Quaternion.identity);
                }
                else if (engine.GetPieceAt(i, j) == Make4Engine.Piece.Yellow)
                    Instantiate(yellowPiece, cells[BoardPositionToViewPosition(i, j)].transform.position, Quaternion.identity);
                {

                }
            }

        }

    }

    internal void HandleMove(int column)
    {
        engine.ExecuteMove(column, Make4Engine.Piece.Blue);
        UpdateBoard();

        if (engine.GetGameStatus() != Make4Engine.GameStatus.Playing)
        {
            HandleEndOfGame();
        }

        engine.DoMove(Make4Engine.Piece.Yellow);
        UpdateBoard();

        if (engine.GetGameStatus() != Make4Engine.GameStatus.Playing)
        {
            HandleEndOfGame();
        }
    }

    private void HandleEndOfGame()
    {
        arrow.SetIsPlaying(false);
        if (engine.GetGameStatus() == Make4Engine.GameStatus.Won)
        {
            var pieces = engine.GetWinnerSequence();
            Debug.Log(pieces[0]);
            Debug.Log(engine.GetPieceAt(pieces[0].x, pieces[0].y));

            if (engine.GetPieceAt(pieces[0].x, pieces[0].y) == Make4Engine.Piece.Blue)
            {
                text.text = "You Won!";
            }
            else
            {
                text.text = "You Lose!";
            }

            text.gameObject.SetActive(true);
            buttonNewGame.interactable = true;
        }
    }

    public void NewGame()
    {
        engine.Reset();
        ResetBoard();
        buttonNewGame.interactable = false;
        arrow.SetIsPlaying(true);
    }

    private void ResetBoard()
    {
        Piece[] pieces = FindObjectsOfType<Piece>();
        foreach(Piece piece in  pieces)
        {
            Destroy(piece.gameObject);
        }
    }
}
