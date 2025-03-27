using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class ClockScript : MonoBehaviour
{
    public TextMeshProUGUI timeDisplay;
    public float gameTime = 6f; // ������ ��� c 6:00 ����
    public float realtime = 10f; // 10 ����� ��������� �������

    private float realtogame; 
    private float elapsedTime = 0f;

    void Start()
    {
        realtogame = 24f / (realtime * 60f); 
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        gameTime += Time.deltaTime * realtogame; // ���������� �������� �������

        if (gameTime >= 24f) gameTime = 0f; // ����� ��� ����� 24:00

        
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
