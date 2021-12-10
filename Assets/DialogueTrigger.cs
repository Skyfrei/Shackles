using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private Canvas canvas;
    private bool isShowing;

    private void Start() {
        canvas = GetComponent<Canvas>();
    }

    void Update()
    {
        if (Input.GetKeyUp("f"))
        {
            TriggerDialogue();
            canvas.enabled = !canvas.enabled;
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
