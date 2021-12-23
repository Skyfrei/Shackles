using UnityEngine;
using TMPro;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

public class CharacterJson
{
    [JsonProperty("character")]
    public List<CharacterStory> Character { get; set; }
}
public class CharacterStory
{
    [JsonProperty("characterName")]
    public string CharacterName { get; set; }

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("pastStory")]
    public bool pastStory { get; set; }

    [JsonProperty("story")]
    public List<string> story { get; set; }
    
    [JsonProperty("repeat")]
    public string repeat { get; set; }
}

public class DialogueUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text character_name_text;

    [SerializeField]
    private TMP_Text dialogue_text; 
    private TypewriterEffect typeWriterObj;
    private string storydata;
    private CharacterJson data;

    private void Start()
    {
        typeWriterObj = GetComponent<TypewriterEffect>();
        storydata = File.ReadAllText($"{Application.dataPath}/story.json");
        data = JsonConvert.DeserializeObject<CharacterJson>(storydata);
    }

    private void Update()
    {
        if (Input.GetKeyUp("f"))
        {
            ShowChat(0);
        }
    }

    public void ShowChat(int enemyId)
    {
        foreach(CharacterStory character in data.Character)
        {
            if (character.Id == enemyId)
            {
                typeWriterObj.TypeCharName(character.CharacterName, character_name_text);
                character.pastStory = false; //MAKE IT EDITABLEEEEEe
                // for(int i = 0; i < character.story.Count; i++)
                // {
                //     typeWriterObj.Run("HEYYY", dialogue_text);
                // }
                
                
                break;
            }
        }
    }
}
