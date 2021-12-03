using System.Collections.Generic;
using UnityEngine;
using Skills;
using ItemsEquipped;

public class Character : MonoBehaviour, IItemsEquipped
{
    // Start is called before the first frame update
    private Rigidbody2D controller;
    public float player_speed;
    public Vector2 Position { get; set; }
    public static Character player;

    //Stats
    public float HP { get; set; }
    public float Armor { get; set; }
    public float ATK { get; set; }
    public float Mana { get; set; }
    public float CritChance { get; set; }
    public int Gold { get; set; }
    // public float CritDamage{get; set;}
    // private float critChance = 10.0f;
    public List<int> enemiesFough;

    ///<summary>
    ///  Character inventory, which also holds which item is equipped.
    ///</summary>
    public List<Item> inventory;
    public List<Item> equipped;

    //Items Equipped
    public int HelmetId { get; set; }
    public int WeaponId { get; set; }
    public int RingId { get; set; }
    public int ArmorId { get; set; }
    public byte Level { get; set; }

    void Start()
    {   
        controller = GetComponent<Rigidbody2D>();
        Gold = 300;
        Level = 1;
        HP = 150;
        Armor = 100;
        ATK = 100;
        Mana = 100;
        CritChance = 0.15f;
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
    ///<summary>
    /// Getting items from inventory scriptable object list to inventory. Converts item scriptable object into item.
    ///</summary>
    
    public void AddToInventory(ItemsScriptableObject itemSo)
    {
        inventory.Add(new Item(itemSo));
    }
    
    public void AddToInventory(Item item)
    {
        inventory.Add(item);
    }


    ///<summary>
    /// Get currently equipped gear.
    ///</summary>
    public void GetEquippedItems()
    {
        
    }

    public void EquipItem()
    {

    }

    public void UnequippItem()
    {

    }


    ///<summary>
    /// Functions allows to change gear during combat.
    ///</summary>
    public void ChangeGear()
    {

    }

    ///<summary>
    /// Changes player stats whenever player changes equipped gear. 
    ///</summary>
    public void ChangeStats()
    {

    }

    //Skills
    public float BasicAttack()
    {
        var randomNumber = Random.Range(0.0f, 1.0f);
        bool criticalStruck = false;
        float damage = 0.0f;

        if (criticalStruck = randomNumber <= CritChance ? true : false == true)
        {
            damage =  ATK + (ATK * 0.5f);
        }
        else
        {
            damage = ATK;
        }
        return damage;
    }

    public void ProcBattleEffect(params float[] numbers)
    {
        foreach(Item item in equipped)
            {
                if (item.ItemType == ItemType.Weapon)
                {
                    foreach(EffectScriptableObject effect in item.itemEffects)
                    {
                        effect.BattleEffect(numbers);
                    }
                }
            }
    }

    public void Skill2()
    {
        foreach(Item item in equipped)
            {
                if (item.ItemType == ItemType.Helmet)
                {
                    item.itemEffects[0].NonBattleEffect(this);
                }
            }
    }

    public void Skill3()
    {
        foreach(Item item in equipped)
            {
                if (item.ItemType == ItemType.Armor)
                {
                    item.itemEffects[0].NonBattleEffect(this);
                }
            }
    }

    public float Skill4()
    {
        foreach(Item item in equipped)
        {
            if (item.ItemType == ItemType.Ring)
            {
                foreach(EffectScriptableObject effect in item.itemEffects)
                {
                    effect.BattleEffect();
                    effect.NonBattleEffect(this);
                }
            }
        }        
        return 0.0f;
    }

    public void LevelUp()
    {
        this.Level++;
        this.HP += 100;
        this.Armor += 15;
        this.ATK += 15;
        this.Mana += 10;
    }
}
