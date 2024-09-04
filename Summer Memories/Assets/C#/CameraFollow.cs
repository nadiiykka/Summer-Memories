using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public float smoothSpeed = 0.125f; 
    public Vector3 offset; 
    public bool followX = true; 
    public bool followY = false; 
    public float fixedY = 0f; 
    public float fixedX = 0f; 
    public float minX; 
    public float maxX; 


    void LateUpdate()
    {
        float targetX = followX ? target.position.x + offset.x : fixedX;
        float targetY = followY ? target.position.y + offset.y : fixedY;
        float targetZ = target.position.z + offset.z;

        targetX = Mathf.Clamp(targetX, minX, maxX);

        Vector3 desiredPosition = new Vector3(targetX, targetY, targetZ);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
