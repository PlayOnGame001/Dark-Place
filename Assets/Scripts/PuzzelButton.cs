using UnityEngine;

public class PuzzelButton : MonoBehaviour
{
    public int plateIndex; // ������ �����
    private Vector3 initialPosition; // ��������� ������� ������
    private bool isPressed = false; // ������ ������
    private Vector3 pressedPosition; // ����������� ������� ������
    private float pressCooldown = 1f; // ����� �������� ����� ���������
    private float lastPressTime = 0f; // ����� ���������� �������

    private void Start()
    {
        initialPosition = transform.position;
        pressedPosition = new Vector3(initialPosition.x, initialPosition.y - 0.1f, initialPosition.z); // ������� ������ �� 0.1 �������
    }

    public void PressPlate()
    {
        // ��������, ����� �� ������ ����� (������ �� ���������� �������)
        if (Time.time - lastPressTime < pressCooldown)
            return; // ���� ���, �� �������� �����

        lastPressTime = Time.time; // ��������� ����� ���������� �������
        isPressed = true;
        transform.position = pressedPosition; // ������� ������
        Debug.Log("������ ������! ������: " + plateIndex); // �����

        PuzzleManager.Instance.PlatePressed(this); // ���������� PuzzleManager � ������� �����
    }

    public void ResetPlate()
    {
        isPressed = false;
        transform.position = initialPosition; // ��������������� ������ � �������� ���������
        Debug.Log("������ ��������. ������: " + plateIndex); // �����
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ���� ����� �������� �� �����
        {
            Debug.Log("����� �������� �� �����! ������: " + plateIndex); // �����
            PressPlate(); // �������� ������
        }
    }
}
