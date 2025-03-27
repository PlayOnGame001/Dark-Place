using System.Collections;
using UnityEngine;

public class IllusoryWall : MonoBehaviour
{
    //�� � ����� ��� ��������� 
    public Collider triggerCollider; // ������� (Is Trigger = true)
    public Collider solidCollider; // ���������� ��������� �����
    public Renderer wallRenderer; // �������� �����
    public float fadeDuration = 1.5f; // ������������ ������������

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
            //Debug.Log("����� �� ������!");
            return;
        }

        if (!player.IsDashing())
        {
           // Debug.Log("����� �� ������ Dash.");
            return;
        }

        //Debug.Log("����� ������ Dash! ��������� ������������ �����.");
        StartCoroutine(FadeOutWall());
    }

    private IEnumerator FadeOutWall()
    {
        isFading = true;
        solidCollider.enabled = false; // ��������� ���������� ���������
        //Debug.Log("��������� ����� ��������!");

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            wallMaterial.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        wallMaterial.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        triggerCollider.enabled = false; // ��������� �������
       //Debug.Log("������� ����� ��������!");
    }
}
