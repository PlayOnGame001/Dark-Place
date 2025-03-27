using UnityEngine;

public class CodePlite : MonoBehaviour
{
    public int plateIndex; // ������ �����
    private Vector3 initialPosition; // ��������� ������� ������
    private bool isPressed = false; // ������ ������
    private Vector3 pressedPosition; // ����������� ������� ������
    private float pressCooldown = 1f; // ����� �������� ����� ���������
    private float lastPressTime = 0f; // ����� ���������� �������
    private bool isBlocked = false; // ���� ���������� ������

    private void Start()
    {
        initialPosition = transform.position;
        pressedPosition = new Vector3(initialPosition.x, initialPosition.y - 0.1f, initialPosition.z); // ������� ������ �� 0.1 �������
    }

    [System.Obsolete]
    public void PressPlate()
    {
        if (isBlocked)
            return; // ���� ������ �������������, �� �������� �

        // ��������, ����� �� ������ ����� (������ �� ���������� �������)
        if (Time.time - lastPressTime < pressCooldown)
            return; // ���� ���, �� �������� �����

        lastPressTime = Time.time; // ��������� ����� ���������� �������
        isPressed = true;
        transform.position = pressedPosition; // ������� ������
        Debug.Log("������ ������! ������: " + plateIndex); // �����

        CodeDoorManager.Instance.PlatePressed(this); // ���������� CodeDoorManager � ������� �����
    }

    public void ResetPlate()
    {
        isPressed = false;
        transform.position = initialPosition; // ��������������� ������ � �������� ���������
        Debug.Log("������ ��������. ������: " + plateIndex); // �����
    }

    public void BlockPlate(float cooldown)
    {
        isBlocked = true;
        Debug.Log("������ ������������� �� " + cooldown + " ������.");
    }

    public void UnblockPlate()
    {
        isBlocked = false;
        Debug.Log("������ ��������������.");
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ���� ����� �������� �� �����
        {
            Debug.Log("����� �������� �� �����! ������: " + plateIndex); // �����
            PressPlate(); // �������� ������
        }
    }
}
