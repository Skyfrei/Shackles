using System.Collections.Generic;
using UnityEngine;
using Skills;
using ItemsEquipped;

//Changing gear
public interface IChangeWeapons
{
    void ChangeGear();
}

public class Character : MonoBehaviour, ISkills, IItemsEquipped, IChangeWeapons
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
        items.Clear();
        items.Add(GameObject.Find("Weapon").GetComponent<Items>());
        items.Add(GameObject.Find("Armor").GetComponent<Items>());
        items.Add(GameObject.Find("Ring").GetComponent<Items>());
        items.Add(GameObject.Find("Necklace").GetComponent<Items>());
        items.Add(GameObject.Find("Boots").GetComponent<Items>());
        items.Add(GameObject.Find("Helmet").GetComponent<Items>());
    }

    ///<summary>
    /// Functions allows to change gear during combat.
    ///</summary>
    public void ChangeGear()
    {

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
}
