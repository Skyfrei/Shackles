using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D controller;
    public float player_speed = 2.4f;
    public Vector2 Position{get; set;}

    //Stats
    public static Character player;
    public float HP{get; set;}
    public float Armor{get; set;}
    public float ATK{get; set;}
    public float Mana{get; set;}
    public float CritDamage{get; set;}
    private float critChance = 10.0f;

    void Start()
    {   
        controller = GetComponent<Rigidbody2D>();
        HP = 150;
        Armor = 100;
        ATK = 100;
        Mana = 100;
    }

    // private void Awake() {
    //     if (player == null)
    //     {
    //         DontDestroyOnLoad(gameObject);
    //         player = this;
    //     }
    //     else if (player != this)
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        controller.position += move * Time.deltaTime * player_speed;
        Position = controller.position;
        
    }
}
