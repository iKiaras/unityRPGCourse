using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Type")]
    [SerializeField] private bool isItem;
    [SerializeField] private bool isWeapon;
    [SerializeField] private bool isArmor;
    [Header("Item Details")]
    [SerializeField] private string itemName;
    [SerializeField] private string description;
    [SerializeField] private int value;
    [SerializeField] private Sprite itemSprite;
    [Header("Item Effects")]
    [SerializeField] private int amountToChange;
    [SerializeField] private bool affectHP, affectMP, affectStr, affectArmor;
    [Header("Weapon/Armor Details")]
    [SerializeField] private int wpnStr;
    [SerializeField] private int armorStr;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
