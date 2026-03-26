using UnityEngine;
using UnityEngine.UI;

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
    public float price;
    [TextArea]
    public string description;
    
    [Header("Equipment Setting")]
    public bool canEquip;
    public bool isItem;

    void OnEnable()
    {
        price = Random.Range(10,30);
    }
}
