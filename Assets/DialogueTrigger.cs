using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    void Update()
    {
        if (Input.GetKeyUp("f"))
        {
            TriggerDialogue();
        }   
        if (Input.GetMouseButtonDown(0))
        {
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
