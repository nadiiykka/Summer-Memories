using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // об'єкт, за яким слідує камера (наприклад, гравець)
    public float smoothSpeed = 0.125f; // швидкість згладження
    public Vector3 offset; // зміщення камери відносно гравця
    public bool followX = true; // слідкувати за X
    public bool followY = false; // слідкувати за Y
    public float fixedY = 0f; // зафіксована координата Y
    public float fixedX = 0f; // зафіксована координата X
    public float minX; // мінімальна координата X, яку може зайняти камера
    public float maxX; // максимальна координата X, яку може зайняти камера

    void LateUpdate()
    {
        // Задаємо координати цілі, за якими слідуватиме камера
        float targetX = followX ? target.position.x + offset.x : fixedX;
        float targetY = followY ? target.position.y + offset.y : fixedY;
        float targetZ = target.position.z + offset.z;

        // Обмежуємо targetX межами minX і maxX
        targetX = Mathf.Clamp(targetX, minX, maxX);

        // Створюємо бажану позицію камери
        Vector3 desiredPosition = new Vector3(targetX, targetY, targetZ);

        // Згладжуємо рух камери
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Присвоюємо нову позицію камери
        transform.position = smoothedPosition;
    }
}
