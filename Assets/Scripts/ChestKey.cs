using UnityEngine;
using TMPro; // ���������� TextMeshPro ��� UI

public class ChestKey : MonoBehaviour
{
    public static int keysCollected = 0; // ���������� ��������� ������
    public int chestID; // ���������� ID �������

    public static TextMeshProUGUI keyCounterText; // UI-�������
    public static int totalKeys = 4; // ����� ���������� ������

    void Start()
    {
        if (keyCounterText == null)
        {
            keyCounterText = GameObject.Find("KeyCounter")?.GetComponent<TextMeshProUGUI>();
        }
        UpdateKeyCounterUI();

        // ��������� ���������� ������ ��� ������ (������ ���� ���)
        if (PlayerPrefs.HasKey("KeysCollected"))
        {
            keysCollected = PlayerPrefs.GetInt("KeysCollected");
        }

        // ���������, ��� �� ��� ������ ���� ������
        if (PlayerPrefs.GetInt($"Chest_{chestID}_Opened", 0) == 1)
        {
            Destroy(gameObject); // ������� ������, ���� �� ��� ��� ������
        }

        UpdateKeyCounterUI(); // ��������� UI ��� ������
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            keysCollected++; // ����������� ���������� ������
            UpdateKeyCounterUI(); // ��������� UI

            // ��������� ��������� ������� � ������
            PlayerPrefs.SetInt($"Chest_{chestID}_Opened", 1);
            PlayerPrefs.SetInt("KeysCollected", keysCollected);
            PlayerPrefs.Save();

            Debug.Log($"������ {chestID} ������. �����: {keysCollected}/{totalKeys}");

            Destroy(gameObject); // ������� ������ ����� �����
        }
    }

    public static void UpdateKeyCounterUI()
    {
        if (keyCounterText != null)
        {
            keyCounterText.text = $"�����: {keysCollected}/{totalKeys}";
        }
    }
}
