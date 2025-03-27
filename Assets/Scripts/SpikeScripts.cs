using UnityEngine;
using System.Collections;

public class SpikeScripts : MonoBehaviour // Напольные колючки
{
    public float damage = 1f;  // Урон от шипов
    public float damageCooldown = 1f; // Задержка между уронами
    private bool isPlayerOnSpikes = false; // Проверка на наличие игрока в шипах 

    private void OnTriggerEnter(Collider other)
    {
        HeroScripts hero = other.GetComponent<HeroScripts>();
        if (hero != null && !isPlayerOnSpikes && !hero.IsDeads()) // Проверка на жив ли игрок
        {
            isPlayerOnSpikes = true;
            hero.TakeDamage(damage); // Первый урон
            StartCoroutine(DamageOverTime(hero));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        HeroScripts hero = other.GetComponent<HeroScripts>();
        if (hero != null)
        {
            isPlayerOnSpikes = false; // Игрок ушел с шипов - останавливаем урон (был баг что урон был всегда даже после ухода с зоны шипов) 
        }
    }

    private IEnumerator DamageOverTime(HeroScripts hero)
    {
        while (isPlayerOnSpikes && hero != null && hero.gameObject.activeSelf && !hero.IsDeads())
        {
            yield return new WaitForSeconds(damageCooldown);
            if (isPlayerOnSpikes && !hero.IsDeads()) // Дополнительная проверка на смерть
            {
                hero.TakeDamage(damage);
            }
        }
    }
}
