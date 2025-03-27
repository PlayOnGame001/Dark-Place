using UnityEngine;

public class HeroRotation : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera; 

    void Update()
    {
        RotateHeroToMouse();
    }

    void RotateHeroToMouse()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        // ѕолучаем позицию курсора мыши в мире
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            Vector3 targetPosition = hit.point;
            targetPosition.y = transform.position.y; 

            transform.LookAt(targetPosition);
        }
    }
}
