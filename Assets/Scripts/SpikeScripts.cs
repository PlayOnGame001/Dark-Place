using UnityEngine;
using System.Collections;

public class SpikeScripts : MonoBehaviour // ��������� �������
{
    public float damage = 1f;  // ���� �� �����
    public float damageCooldown = 1f; // �������� ����� �������
    private bool isPlayerOnSpikes = false; // �������� �� ������� ������ � ����� 

    private void OnTriggerEnter(Collider other)
    {
        HeroScripts hero = other.GetComponent<HeroScripts>();
        if (hero != null && !isPlayerOnSpikes && !hero.IsDeads()) // �������� �� ��� �� �����
        {
            isPlayerOnSpikes = true;
            hero.TakeDamage(damage); // ������ ����
            StartCoroutine(DamageOverTime(hero));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        HeroScripts hero = other.GetComponent<HeroScripts>();
        if (hero != null)
        {
            isPlayerOnSpikes = false; // ����� ���� � ����� - ������������� ���� (��� ��� ��� ���� ��� ������ ���� ����� ����� � ���� �����) 
        }
    }

    private IEnumerator DamageOverTime(HeroScripts hero)
    {
        while (isPlayerOnSpikes && hero != null && hero.gameObject.activeSelf && !hero.IsDeads())
        {
            yield return new WaitForSeconds(damageCooldown);
            if (isPlayerOnSpikes && !hero.IsDeads()) // �������������� �������� �� ������
            {
                hero.TakeDamage(damage);
            }
        }
    }
}
