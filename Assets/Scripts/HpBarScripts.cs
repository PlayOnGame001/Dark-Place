using System;
using UnityEngine;
using UnityEngine.UI;

public class HpBarScripts : MonoBehaviour
{
    public Image healthBarImage; // Полоска здоровья
    private float maxHealth = 100f;//напиши хоть 200 хоть 300 ничего не поменяется 
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Фулл хп
        UpdateHealthBar();
    }

    //ТЕСТ
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) // Уменьшить здоровье на 10 при нажатии H
        {
            TakeDamage(10);
        }
    }


    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // получение урона
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Не может упасть ниже 0 (то-есть отрицательное хп не увидим) 
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        float fillValue = currentHealth / maxHealth;
        Debug.Log("Значение fillAmount: " + fillValue); // Проверяем, меняется ли fillAmount (другого решения я не нашел) 
        healthBarImage.fillAmount = fillValue;
    }

    internal void SetHealth(float currentHealth, float maxHealth)
    {
        this.currentHealth = currentHealth;
        this.maxHealth = maxHealth;
        UpdateHealthBar();
    }
}
