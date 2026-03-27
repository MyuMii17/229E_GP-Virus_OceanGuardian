using System.Runtime.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    [SerializeField]private GameObject RunOutOffuel;
    [SerializeField]private Image fuelbar;
    [SerializeField]private FuelSystem fuel;
    [SerializeField] int gameMenuSceneIndex = 1;
    public void SetFuel(float current, float max)
    {
        fuelbar.fillAmount = current / max;
    }
    void Update()
    {
        if(fuel.currentFuel == 0)
        {
            GameManager.Instance.SetOffOpenUI();
            GameManager.Instance.PauseGame(RunOutOffuel);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(gameMenuSceneIndex);
        fuel.currentFuel = fuel.maxFuel;
        Time.timeScale = 1f;
    }
}
