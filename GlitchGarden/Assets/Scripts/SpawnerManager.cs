using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{

    //TODO serialize for debug purposes
    [SerializeField] int attackersNumber = 0;
    // Start is called before the first frame update
   

    public void addAttacker()
    {
        attackersNumber++;
    }

    public void removeAttacker()
    {
        attackersNumber--;
    }

    public int GetNumberOfAttackers()
    {
        return attackersNumber;
    }

    public void timeIsZero()
    {
        if(attackersNumber == 0)
        {
            Debug.Log("End Level");
        }
    }
}
