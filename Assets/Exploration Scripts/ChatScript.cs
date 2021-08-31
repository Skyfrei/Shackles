using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Canvas canvas;
    private bool isShowing;

    private void Start() {
        canvas = GetComponent<Canvas>();
    }
    private void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            canvas.enabled = !canvas.enabled;
        }    
    }
}
