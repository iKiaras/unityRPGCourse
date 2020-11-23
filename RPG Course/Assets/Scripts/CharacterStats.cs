using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private string characterName;
    [SerializeField] private int playerLevel = 1;
    [SerializeField] private int currentEXP;
    [SerializeField] private List<int> expToNextLevel= new List<int>();
    [SerializeField] private int baseEXP = 1000;
    [SerializeField] private int maxLevel = 100;
    [SerializeField] private int currentHP;
    [SerializeField] private int maxHP = 100;
    [SerializeField] private int currentMP;
    [SerializeField] private int maxMP;
    [SerializeField] private List<int> maxMPLevelIncrease;
    [SerializeField] private int strength;
    [SerializeField] private int defence;
    [SerializeField] private int weaponPower;
    [SerializeField] private int armorPower;
    [SerializeField] private string equippedWeaponName;
    [SerializeField] private string equippedArmorName;
    [SerializeField] private Sprite charImage;
    // Start is called before the first frame update
    void Start()
    {
        expToNextLevel[1] = baseEXP;

        for (int i = 2; i < maxLevel; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i-1] * 1.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddExp(int expToAdd)
    {
        currentEXP += expToAdd;
        if (playerLevel >= maxLevel)
        {
            currentEXP = 0; //Fix infinite grind.
        }
        else  if (currentEXP > expToNextLevel[playerLevel])
        {
            currentEXP -= expToNextLevel[playerLevel];
            playerLevel++;

            //Increase stats

            maxHP = Mathf.FloorToInt(maxHP * 1.05f);
            currentHP = maxHP;
            
            maxMP = Mathf.FloorToInt(maxMP * 1.05f); //Think about this, array or flat?
            currentMP = maxMP;
        }
    }
    
    public string CharacterName
    {
        get => characterName;
        set => characterName = value;
    }

    public int PlayerLevel
    {
        get => playerLevel;
        set => playerLevel = value;
    }

    public int CurrentExp
    {
        get => currentEXP;
        set => currentEXP = value;
    }

    public List<int> ExpToNextLevel
    {
        get => expToNextLevel;
        set => expToNextLevel = value;
    }

    public int BaseExp
    {
        get => baseEXP;
        set => baseEXP = value;
    }

    public int MaxLevel
    {
        get => maxLevel;
        set => maxLevel = value;
    }

    public int CurrentHp
    {
        get => currentHP;
        set => currentHP = value;
    }

    public int MaxHp
    {
        get => maxHP;
        set => maxHP = value;
    }

    public int CurrentMp
    {
        get => currentMP;
        set => currentMP = value;
    }

    public int MaxMp
    {
        get => maxMP;
        set => maxMP = value;
    }

    public List<int> MaxMpLevelIncrease
    {
        get => maxMPLevelIncrease;
        set => maxMPLevelIncrease = value;
    }

    public int Strength
    {
        get => strength;
        set => strength = value;
    }

    public int Defence
    {
        get => defence;
        set => defence = value;
    }

    public int WeaponPower
    {
        get => weaponPower;
        set => weaponPower = value;
    }

    public int ArmorPower
    {
        get => armorPower;
        set => armorPower = value;
    }

    public string EquippedWeaponName
    {
        get => equippedWeaponName;
        set => equippedWeaponName = value;
    }

    public string EquippedArmorName
    {
        get => equippedArmorName;
        set => equippedArmorName = value;
    }

    public Sprite CharImage
    {
        get => charImage;
        set => charImage = value;
    }
}
