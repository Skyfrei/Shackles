using System.Collections.Generic;
using UnityEngine;
using Skills;
using ItemsEquipped;

public class Character : MonoBehaviour, ISkills, IItemsEquipped
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

    ///<summary>
    ///  Character inventory, which also holds which item is equipped.
    ///</summary>
    public List<Items> items;

    //Items Equipped
    public int ShoesId { get; set; }
    public int HelmetId { get; set; }
    public int WeaponId { get; set; }
    public int RingId { get; set; }
    public int NecklaceId { get; set; }
    public int ArmorId { get; set; }


    void Start()
    {   
        controller = GetComponent<Rigidbody2D>();
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

    public void GetEquippedItems()
    {
        items.Add(GameObject.Find("Weapon").GetComponent<Items>());
        // for (int i = 0; i < 2; i++)
        // {
        //     items.Add(GameObject.FindObjectOfType<Items>());
        // }
    }

    //Skills
    public void Skill1()
    {
        
    }
    public void Skill2()
    {

    }
    public void Skill3()
    {

    }
    public void Skill4()
    {

    }

    // private void OnCollisionStay2D(Collision2D other) {
    //     if (other.gameObject.name == "Door")
    //     {
    //         Debug.Log("asd");
    //     }
    // }
}
