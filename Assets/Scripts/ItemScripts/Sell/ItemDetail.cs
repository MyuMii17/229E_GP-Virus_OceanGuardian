using UnityEngine;

public class ItemDetail : MonoBehaviour
{
    public int currentItemPrice;
    public int currentItemMass;
    private Rigidbody _rb;
    [SerializeField]private ItemData itemData;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        currentItemPrice = Random.Range(itemData.minPrice, itemData.maxPrice);
        currentItemMass = Random.Range(itemData.minMass, itemData.maxMass);
        _rb.mass = currentItemMass;
    }
}
