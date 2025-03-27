using UnityEngine;

public class CilinderRotateScripts : MonoBehaviour
{
    public float rotationSpeed = 100f; // Скорость вращения 

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
