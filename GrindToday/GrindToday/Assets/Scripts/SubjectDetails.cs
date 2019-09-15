using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubjectDetails : MonoBehaviour
{


    ProgramController programController;
    public Button backButton;
    public Text titleText;
    // Start is called before the first frame update
    void Start()
    {
        programController = FindObjectOfType<ProgramController>();
        backButton.onClick.AddListener(()=>programController.LoadMainScene());
        titleText.text = programController.GetSubject().getName();


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
