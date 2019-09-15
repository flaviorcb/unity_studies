using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    Make4Engine engine;
    
    // Start is called before the first frame update
    void Start()
    {
        engine = new Make4Engine();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public int EvaluateAllLegalMoves(Make4Engine engine, Make4Engine.Piece turn, int deep=0, int maxDeep = 2)
    {

        if (deep >= maxDeep) return 0;
        
        
        List<int> moves = engine.GenerateLegalMoves();

        return 0;

        
    }


}
