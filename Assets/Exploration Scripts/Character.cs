using System.Collections.Generic;
using UnityEngine;
using Skills;
using ItemsEquipped;

public abstract class Units : MonoBehaviour
{
    public abstract float HP { get; set; }
    public abstract float MaxHealth { get; set; }
    public abstract float Armor { get; set; }
    public abstract float ATK { get; set; }
    public abstract float Mana { get; set; }
    public abstract float CritChance { get; set; }
}

public class Character : Units, IItemsEquipped
{
    // Start is called before the first frame update
    public Rigidbody2D controller;
    public float player_speed;
    public Vector2 Position { get; set; }
    public static Character player;

    //Stats
    public override float HP { get; set; }
    public override float MaxHealth { get; set; }
    public override float Armor { get; set; }
    public override float ATK { get; set; }
    public override float Mana { get; set; }
    public override float CritChance { get; set; }
    public float Experience { get; set; }
    public float MaxExperienceLevel { get; set; }
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
    
    public Canvas pressF;

    void Start()
    {   
        controller = GetComponent<Rigidbody2D>();
        Gold = 300;
        Level = 1;
        HP = 100;
        MaxHealth = 100;
        Armor = 50;
        ATK = 50;
        Mana = 100;
        Experience = 0.0f;
        MaxExperienceLevel = 100.0f;
        CritChance = 0.15f;
        pressF = GameObject.Find("PressF").GetComponent<Canvas>();
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

    // private void Update() {
    //     if (Input.GetKeyDown(KeyCode.L))
    //     {
    //         this.UseHPotion();
    //     }
    // }

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

    public void UnequipItem()
    {

    }


    ///<summary>
    /// Functions allows to change gear during combat.
    ///</summary>
    public void ChangeGear()
    {

    }

    private void UseHPotion()
    {
        foreach(Item item in inventory)
            {
                if (item.ItemType == ItemType.Potion)
                {
                    foreach(HealScriptableObject effect in item.itemEffects)
                    {
                        effect.PotionEffect(this);
                    }
                }
                inventory.Remove(item);
            }
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
            Debug.Log("Crit hit!");
        }
        else
        {
            damage = ATK;
        }
        return damage;
    }

    public void ProcBattleEffect(Enemy enemy, params float[] numbers)
    {
        foreach(Item item in equipped)
            {
                if (item.ItemType == ItemType.Weapon)
                {
                    foreach(EffectScriptableObject effect in item.itemEffects)
                    {
                        effect.BattleEffect(this, enemy);
                    }
                }
                if (item.ItemType == ItemType.Ring)
                {
                    foreach(EffectScriptableObject effect in item.itemEffects)
                    {
                        effect.BattleEffect(player, enemy);
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
                    foreach(EffectScriptableObject effect in item.itemEffects)
                    {
                        effect.NonBattleEffect(this);
                    }
                }
            }
    }

    public void Skill3()
    {
        foreach(Item item in equipped)
        {
            if (item.ItemType == ItemType.Armor)
            {
                foreach(EffectScriptableObject effect in item.itemEffects)
                {
                    effect.NonBattleEffect(this);
                }
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
                        effect.NonBattleEffect(this);
                    }
                }
            }
            
        return 0.0f;
    }

    public void LevelUp()
    {
        this.Level++;
        this.Experience = Experience - MaxExperienceLevel;
        this.HP = MaxHealth;
        this.Armor += 15;
        this.ATK += 15;
        this.Mana += 10;
        MaxHealth += 50;
        MaxExperienceLevel += 50.0f;
    }
}
