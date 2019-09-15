using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HealthDisplay : MonoBehaviour
{
    int healthPoints = 10;
    [SerializeField] TextMeshProUGUI text;


    private void Awake()
    {
        healthPoints = PlayerPrefsController.GetDifficulty();
        Debug.Log("Health points: " + healthPoints);
        UpdateDisplay();
    }


    
    public void EnemyEscaped()
    {
        healthPoints--;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        text.text = healthPoints.ToString();
    }

    public int GetHealthPoints()
    {
        return healthPoints; 
    }


    public void SetHealthPoints(int value)
    {
        healthPoints = value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colisão ocorreu");
        Destroy(collision.gameObject);
        EnemyEscaped();
        if(healthPoints <= 0)
        {

            //TODO perdeu a partida tem de colocar uma mensagem de perda de partida
            FindObjectOfType<LevelController>().HandleLoseCondition();           
        }
    }
}
