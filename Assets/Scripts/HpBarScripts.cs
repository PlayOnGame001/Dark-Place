using System;
using UnityEngine;
using UnityEngine.UI;

public class HpBarScripts : MonoBehaviour
{
    public Image healthBarImage; // ������� ��������
    private float maxHealth = 100f;//������ ���� 200 ���� 300 ������ �� ���������� 
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // ���� ��
        UpdateHealthBar();
    }

    //����
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) // ��������� �������� �� 10 ��� ������� H
        {
            TakeDamage(10);
        }
    }


    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // ��������� �����
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // �� ����� ������ ���� 0 (��-���� ������������� �� �� ������) 
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        float fillValue = currentHealth / maxHealth;
        Debug.Log("�������� fillAmount: " + fillValue); // ���������, �������� �� fillAmount (������� ������� � �� �����) 
        healthBarImage.fillAmount = fillValue;
    }

    internal void SetHealth(float currentHealth, float maxHealth)
    {
        this.currentHealth = currentHealth;
        this.maxHealth = maxHealth;
        UpdateHealthBar();
    }
}
