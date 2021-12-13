using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private Canvas canvas;
    private bool isShowing;
    private DialogueManager manager;

    private void Start() {
        canvas = GetComponent<Canvas>();
        manager = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {
        if (Input.GetKeyUp("f"))
        {
            TriggerDialogue();
            //canvas.enabled = !canvas.enabled;
        }   
        if (Input.GetMouseButtonDown(0))
        {
            manager.DisplayNextSentence();
        }
    }

    public void TriggerDialogue()
    {
        manager.StartDialogue(dialogue);
    }
}
