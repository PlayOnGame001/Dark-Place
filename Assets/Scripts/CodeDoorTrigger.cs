using UnityEngine;

public class CodeDoorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject codePanel; // ������ UI
    [SerializeField] private GameObject door; // �����

    private void Start()
    {
        codePanel.SetActive(false); // ������ ������ ��� ������
    }

    // ����� ����� ������ � ������� (������ ���� �������� Collider � ������� Trigger)
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ���� ��� �����
        {
            // ������� ������ UI
            codePanel.SetActive(true);
        }
    }

    // ����� ����� ������� �� ��������
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // ���� ��� �����
        {
            // ������� ������ UI
            codePanel.SetActive(false);
        }
    }
}
