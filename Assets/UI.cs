using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private Canvas canvas;
    private bool isShowing;

    private void Start() {
        canvas = GetComponent<Canvas>();
    }
    private void Update() {
        if (Input.GetKeyUp("i"))
        {
            canvas.enabled = !canvas.enabled;
        }    
    }
}