using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class ClockScript : MonoBehaviour
{
    public TextMeshProUGUI timeDisplay;
    public float gameTime = 6f; // Начало дня c 6:00 утра
    public float realtime = 10f; // 10 минут реального времени

    private float realtogame; 
    private float elapsedTime = 0f;

    void Start()
    {
        realtogame = 24f / (realtime * 60f); 
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        gameTime += Time.deltaTime * realtogame; // Увеличение игрового времени

        if (gameTime >= 24f) gameTime = 0f; // Сброс дня после 24:00

        
        if (timeDisplay != null)
            timeDisplay.text = GetFormattedTime();
    }

    
    private string GetFormattedTime()
    {
        int hours = Mathf.FloorToInt(gameTime);
        int minutes = Mathf.FloorToInt((gameTime - hours) * 60);
        return $"{hours:D2}:{minutes:D2}";
    }
}
