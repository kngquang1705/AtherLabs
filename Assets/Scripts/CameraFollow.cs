using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float cameraHeight;
    public float cameraDistance;
    public float cameraSpeed;

    [SerializeField] private GameObject target;

    private void FixedUpdate()
    {
        Vector3 targetPosition = target.transform.position;

        targetPosition.y += cameraHeight;
        targetPosition.z -= cameraDistance;

        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
    }
}
