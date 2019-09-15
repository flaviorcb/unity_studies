using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreGameArea : MonoBehaviour
{
    private Defender defender;

    private void OnMouseDown()
    {
        if (defender)
        {
            AttemptToPlaceDefenderAt(GetSquareClicked());
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return SnapToGrid(worldPos);

    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarsDisplay>();
        int defenderCost = defender.GetStarCost();
        if (starDisplay.haveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            starDisplay.SpendStars(defenderCost);
        }
    }

    private void SpawnDefender(Vector2 worldPos)
    {
        Defender newDefender = Instantiate(defender, worldPos, Quaternion.identity) as Defender;
        Shooter shooter = newDefender.GetComponent<Shooter>();
        if (shooter != null)
        {
            shooter.SetLane(worldPos.y);

        }
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        int x = Mathf.RoundToInt(rawWorldPos.x);
        int y = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(x, y);

    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }
}

