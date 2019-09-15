using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] bool active = false;
    [SerializeField] Defender defenderPrefab;

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
           
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<CoreGameArea>().SetSelectedDefender(defenderPrefab);
    }
}

  
