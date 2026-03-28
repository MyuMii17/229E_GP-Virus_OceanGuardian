using System;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FuelSystem : MonoBehaviour
{
    public float maxFuel = 100f;
    public float currentFuel = 0.0f;
    public float consumeRate = 5f;
    [SerializeField]private PhysicsPlayerController playerController;
    [SerializeField]private FuelBar fuelBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentFuel += maxFuel;
        playerController = GetComponent<PhysicsPlayerController>();
    }
    void Update()
    {
        Consume(consumeRate);
        fuelBar.SetFuel(currentFuel,maxFuel);
    }
    public void Consume(float amount)
    {
        if (playerController.IsMoving())
        {
            currentFuel -= amount * Time.deltaTime;
            currentFuel = Mathf.Clamp(currentFuel, 0, maxFuel);
        }
    }
    public bool HasFuel()
    {
        return currentFuel > 0;
    }
}
