using System.Runtime.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    [SerializeField]private Image fuelbar;
    [SerializeField]private FuelSystem fuel;
    void Start()
    {
        
    }
    public void SetFuel(float current, float max)
    {
        fuelbar.fillAmount = current / max;
    }
}
