using System.Collections;
using UnityEngine;

public class WallSpikes : MonoBehaviour
{
    public float extendDistance = 0.15f; // �������� ���������� �����
    public float moveSpeed = 2f; // �������� �������� �����
    public float delayBeforeRepeat = 2f; // ����� ����� ��������
    public float damage = 1f; // ���� �����

    private Vector3 startPosition;
    private Vector3 extendedPosition;
    private bool hasDealtDamage = false; // ��������, �������� �� ����

    private void Start()
    {
        startPosition = transform.position;
        extendedPosition = startPosition + transform.forward * extendDistance;
        StartCoroutine(SpikeLoop());
    }

    private IEnumerator SpikeLoop()
    {
        while (true)
        {
            hasDealtDamage = false; // ���������� ���� ����� ����� ������
            yield return MoveToPosition(extendedPosition); // ��������� ����
            yield return new WaitForSeconds(0.5f);
            yield return MoveToPosition(startPosition); // ���� ������������� 
            yield return new WaitForSeconds(delayBeforeRepeat);
        }
    }

    private IEnumerator MoveToPosition(Vector3 target) //����������� � ����������� ������� 
    {
        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasDealtDamage && other.CompareTag("Player"))
        {
            HeroScripts player = other.GetComponent<HeroScripts>();
            if (player != null)
            {
                player.TakeDamage(damage);
                hasDealtDamage = true; // ���� ��� �� ���� 
            }
        }
    }
}
