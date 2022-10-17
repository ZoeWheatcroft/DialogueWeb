using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionButton : MonoBehaviour
{

    public string question = "b";

    public DialogueWeb dw;
    public TMP_Text questionText;

    // Start is called before the first frame update
    void Start()
    {
        dw = GameObject.Find("Web Manager").GetComponent<DialogueWeb>();
        questionText.SetText(question);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clicked()
    {
        dw.SetLastQuestion(question);
        //update the current question to the one connected to the original
        question = dw.questionsDict[question][0];
        questionText.SetText(question);
        dw.UIUpdate();
    }
    
}
