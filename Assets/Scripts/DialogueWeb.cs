using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Linq;

public class DialogueWeb : MonoBehaviour
{

    //list of questions and questions that can be asked next
    //looks like: a can go to b, c, d
    public Dictionary<string, List<string>> questionsDict = new Dictionary<string, List<string>>();

    //list of responses to those questions
    //looks like: a gets "nice to meet you"
    public Dictionary<string, string> responsesDict = new Dictionary<string, string>();

    public List<string> questionPredecessors = new List<string>();

    public DialogueScriptableObject data;


    public TMP_Text responseText;
    public TMP_Text lastQuestionText;

    //the question just asked
    public string lastQuestion = "a";

    #region Button Variables
    public QuestionButton qButton;
    public List<QuestionButton> buttonList = new List<QuestionButton>();
    private GameObject buttonAnchor;
    public float buttonOffset;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
        buttonAnchor = GameObject.Find("buttonAnchor");

        assembleDictionaries();

        UIUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void UIUpdate()
    {
        lastQuestionText.SetText(lastQuestion);

        responseText.SetText(responsesDict[lastQuestion]);
        Debug.Log("current response: " + responsesDict[lastQuestion]);
        Debug.Log("current response: " + responsesDict[lastQuestion]);

        List<string> connections = questionsDict[lastQuestion];
       

        for(int i = 0; i < buttonList.Count; i++)
        {
            GameObject button = buttonList[i].gameObject;
            Destroy(button.gameObject);
        }

        buttonList.Clear();

        float offSet = 35;

        foreach(string s in connections)
        {
            //do a check for if its in predecessors 
            if (questionPredecessors.Contains(s))
            {
                //do nothing
            }
            else
            {
                QuestionButton button = Instantiate(qButton, buttonAnchor.transform.position, Quaternion.identity);
                button.transform.SetParent(GameObject.Find("Canvas").transform, true);
                button.GetComponent<RectTransform>().anchoredPosition = new Vector2(button.GetComponent<RectTransform>().anchoredPosition.x, button.GetComponent<RectTransform>().anchoredPosition.y - offSet);
                button.question = s;
                button.name = "button: " + s;
                buttonList.Add(button);
                offSet += buttonOffset;
            }
        }

    }


    public void SetLastQuestion(string newLast)
    {
        lastQuestion = newLast;
        Debug.Log("NEW QUESTIONS AVALIABLE: ");
        List<string> connections = questionsDict[lastQuestion];
        foreach(string s in connections)
        {
            Debug.Log(s);
        }
        questionPredecessors.Add(lastQuestion);
        UIUpdate();

    }


    private void assembleDictionaries()
    {
        string readFromFilePath = Application.streamingAssetsPath + "/" + data.textFile + ".txt";

        List<string> fileLines = File.ReadAllLines(readFromFilePath).ToList();

        foreach(string line in fileLines)
        {
            List<string> splitLine = line.Split("*	").ToList();
            List<string> connections = new List<string>();
            for(int i = 2; i < splitLine.Count; i++)
            {
                if (i != 0)
                {
                    string cleanedString = splitLine[i];
                    cleanedString = cleanedString.Replace("	", string.Empty);
                    connections.Add(cleanedString);
                }
            }
            Debug.Log(splitLine[0] + " connections : ");
            for(int i = 0; i < connections.Count; i++)
            {
                Debug.Log(connections[i]);
            }
            questionsDict.Add(splitLine[0], connections);
            responsesDict.Add(splitLine[0], splitLine[1]);
        }
        
    }

}
