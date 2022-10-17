using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "dso", menuName = "DialogueSO")]
public class DialogueScriptableObject : ScriptableObject
{
    public string hello = "hello";

    public string textFile;

    public List<string> responseKeys;
    public List<string> responseValues;

}
