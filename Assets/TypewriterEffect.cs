using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField]
    private float typeWriterSpeed = 50f;

    public void Run(string textToType, TMP_Text textLabel)
    {
        StartCoroutine(TypeText(textToType, textLabel));
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {
        yield return new WaitForSeconds(2);
        
        float t = 0;
        int charIndex = 0;

        while(charIndex < textToType.Length)
        {
            t += Time.deltaTime * typeWriterSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textLabel.text = textToType.Substring(0, charIndex);

            yield return null;
        }
        textLabel.text = textToType;
    }
    public void TypeCharName(string charName, TMP_Text textLabel)
    {
        textLabel.text = charName;
    }
}
