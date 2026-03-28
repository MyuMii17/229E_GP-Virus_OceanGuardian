using UnityEngine;

public enum ItemType
{
    KeyItems,
    Equipment
}
[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    [Header("Basic Information")]
    public string itemName;
    public Sprite icon;
    public ItemType itemType;
    public GameObject worldPreFeb;
    public int minPrice;
    public int maxPrice;
    public int minMass;
    public int maxMass;
    public float minAddFuel;
    public float maxAddFuel;

    [TextArea]
    public string description;
    
    [Header("Equipment Setting")]
    public bool canEquip;
    public bool isItem;
}
