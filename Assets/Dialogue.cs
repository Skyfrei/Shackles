using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name; //NPC name

    [TextArea(3, 10)]
    public string[] sentences; //Strings that will be inserted into the queue
}