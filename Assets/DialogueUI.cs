using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text character_name_text;

    [SerializeField]
    private TMP_Text dialogue_text; 
    private TypewriterEffect typeWriterObj;

    private void Start()
    {
        typeWriterObj = GetComponent<TypewriterEffect>();
    }

    private void Update()
    {
        if (Input.GetKeyUp("f"))
        {
            ShowChat();
        }
    }

    public void ShowChat()
    {

        typeWriterObj.Run("HEYYY",character_name_text);
        typeWriterObj.Run("BADUMMMMMMMMMMMMMMMMMMMMMMMMMM TSS",dialogue_text);
    }

}
