using UnityEngine;
using UnityEngine.UI; // ���������� UI ����������

public class CodeImage : MonoBehaviour
{
    public RawImage codeImage; // ������ �� ��������� RawImage

    private void Start()
    {
        codeImage.gameObject.SetActive(false); // ��������, ��� ����������� ������ ��� ������
    }

    // ����� ����� ������ � �������
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ���� ��� �����
        {
            codeImage.gameObject.SetActive(true); // ���������� �����������
        }
    }

    // ����� ����� ������� �� ��������
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // ���� ��� �����
        {
            codeImage.gameObject.SetActive(false); // ������ �����������
        }
    }
}
