using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();    
    }

    // Start is called before the first frame update
    public void StartDialogue(Dialogue dialouge)
    {
        Debug.Log("Starting conversation with " + dialouge.name);

        sentences.Clear();

        foreach(string sentence in dialouge.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
    }

    private void EndDialogue()
    {
        Debug.Log("End of conversation.");
    }
}
