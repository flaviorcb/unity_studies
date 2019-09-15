using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    [SerializeField] GameObject[] columns;
    Game game;
    bool isPlaying = true;

    int selectedColumn = 0;

    void Start()
    {
        game = FindObjectOfType<Game>();
        transform.position = columns[0].transform.position;

    }

    public void SetIsPlaying(bool isPlaying)
    {
        this.isPlaying = isPlaying;
    }

    // Update is called once per frame
    void Update()
    {

        if (!isPlaying) return;

        if (Input.GetKeyDown("right"))
        {
            selectedColumn = selectedColumn + 1;
            if (selectedColumn > 6) selectedColumn = 0;
        }

        if (Input.GetKeyDown("left"))
        {
            selectedColumn = selectedColumn - 1;
            if (selectedColumn < 0) selectedColumn = 6;
        }

        if (Input.GetKeyDown("return"))
        {
            Debug.Log("Jogou");
            game.HandleMove(selectedColumn);
        }

        transform.position = columns[selectedColumn].transform.position;
    }

}

