using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class TimerSet : MonoBehaviour
{
    [SerializeField]private TMP_Text timer;
    [SerializeField]private GameObject timeUp;
    public float timeRemaining = 600f;
    public bool isRunning = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRunning) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdataTimeDisplay(timeRemaining);
        }
        else
        {
            isRunning = false;
            TimeUP();
            UpdataTimeDisplay(0);
        }
    }

    public void UpdataTimeDisplay(float time)
    {
        int timerSet = Mathf.FloorToInt(time);
        string timerString = timerSet.ToString();
        timer.text = $"{timerString}";
    }
    public void TimeUP()
    {
        GameManager.Instance.SetOffOpenUI();
        GameManager.Instance.PauseGame(timeUp);
    }
}
