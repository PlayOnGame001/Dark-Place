using UnityEngine;

public class OilTrap : MonoBehaviour
{
    public float slowMultiplier = 0.5f; // ��������� ����������� �������� (0.5 = � 2 ���� ���������)
    public float slowDuration = 2f; // ������������ ���������� ����� ������

    private void OnTriggerEnter(Collider other)
    {
        HeroScripts hero = other.GetComponent<HeroScripts>();
        if (hero != null)
        {
            hero.speed *= slowMultiplier; // ��������� ��������
        }
    }

    private void OnTriggerExit(Collider other)
    {
        HeroScripts hero = other.GetComponent<HeroScripts>();
        if (hero != null)
        {
            StartCoroutine(RestoreSpeed(hero)); // ����� ����� ������� �������� �������� 
        }
    }

    private System.Collections.IEnumerator RestoreSpeed(HeroScripts hero)
    {
        yield return new WaitForSeconds(slowDuration);
        hero.speed /= slowMultiplier; // �������� � ����� )
    }
}
