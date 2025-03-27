using UnityEngine;
using TMPro; // ���������� TextMeshPro

public class HintSign : MonoBehaviour
{
    public TextMeshProUGUI hintDisplay; // ������ �� ��������� TextMeshPro

    private void Start()
    {
        hintDisplay.gameObject.SetActive(false); // ��������, ��� ��������� ������ ��� ������
    }

    // ����� ����� ������ � �������
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ���� ��� �����
        {
            hintDisplay.gameObject.SetActive(true); // ���������� ���������
        }
    }

    // ����� ����� ������� �� ��������
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // ���� ��� �����
        {
            hintDisplay.gameObject.SetActive(false); // ������ ���������
        }
    }
}
