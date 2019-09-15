using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSlider : MonoBehaviour
{

    [Tooltip("Our level time in seconds")]
    [SerializeField] float levelTime = 10f;
    bool levelFinished = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!levelFinished)
        {
            GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

            bool timerFinished = Time.timeSinceLevelLoad >= levelTime;

            if (timerFinished)
            {
                levelFinished = true;
                FindObjectOfType<LevelController>().LevelTimerFinished();
            }
        }
    }
}
