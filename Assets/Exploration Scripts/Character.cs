using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D controller;
    public float player_speed;
    public Vector2 Position{get; set;}
    public static Character player;
    //Stats
    public float HP{get; set;}
    public float Armor{get; set;}
    public float ATK{get; set;}
    public float Mana{get; set;}
    // public float CritDamage{get; set;}
    // private float critChance = 10.0f;
    public List<int> enemiesFough;
    private RectTransform rt;
    private float width;
    private float height;

    void Start()
    {   
        rt = (RectTransform)player.transform;
        controller = GetComponent<Rigidbody2D>();
        width = rt.rect.width;
        height = rt.rect.height;
        HP = 150;
        Armor = 100;
        ATK = 100;
        Mana = 100;
    }

    private void Awake() {
        if (player == null)
        {
            player = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        controller.position += move * Time.deltaTime * player_speed;
        Position = controller.position;
    }

    public bool CollisionDetection(RectTransform structurePosition)
    {
        float structWidth = structurePosition.rect.width;
        float structHeight = structurePosition.rect.width;

        //Collision detection 
        if (player.Position.x < structurePosition.position.x + structWidth &&
            player.Position.x + player.width > structurePosition.position.x &&
            player.Position.y < structurePosition.position.y + structHeight &&
            player.Position.y + player.height > structurePosition.position.y)
            {
                return true;
            }
        return false;
    }
}
