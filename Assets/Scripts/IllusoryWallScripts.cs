using System.Collections;
using UnityEngine;

public class IllusoryWall : MonoBehaviour
{
    //Да у стены два колайдера 
    public Collider triggerCollider; // Триггер (Is Trigger = true)
    public Collider solidCollider; // Физический коллайдер стены
    public Renderer wallRenderer; // Материал стены
    public float fadeDuration = 1.5f; // Длительность исчезновения

    private Material wallMaterial;
    private Color originalColor;
    private bool isFading = false;

    private void Start()
    {
        wallMaterial = wallRenderer.material;
        originalColor = wallMaterial.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        HeroScripts player = other.GetComponent<HeroScripts>();
        if (player == null)
        {
            //Debug.Log("Игрок не найден!");
            return;
        }

        if (!player.IsDashing())
        {
           // Debug.Log("Игрок НЕ делает Dash.");
            return;
        }

        //Debug.Log("Игрок делает Dash! Запускаем исчезновение стены.");
        StartCoroutine(FadeOutWall());
    }

    private IEnumerator FadeOutWall()
    {
        isFading = true;
        solidCollider.enabled = false; // ОТКЛЮЧАЕМ ФИЗИЧЕСКИЙ КОЛЛАЙДЕР
        //Debug.Log("Коллайдер стены отключен!");

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            wallMaterial.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        wallMaterial.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        triggerCollider.enabled = false; // Выключаем триггер
       //Debug.Log("Триггер стены отключен!");
    }
}
