using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public Transform target;

    public float distance = 5f;
    public float sensitivity = 3f;

    public float minPitch = -30f;
    public float maxPitch = 60f;

    private float yaw = 0f;
    private float pitch = 20f;

    void LateUpdate()
    {
        if (target == null)
            return;

        // Rotation avec la souris
        if (Input.GetMouseButton(0))
        {
            yaw += Input.GetAxis("Mouse X") * sensitivity;
            pitch -= Input.GetAxis("Mouse Y") * sensitivity;
        }

        // Limite de rotation verticale
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        // Calcul de la rotation
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);

        // Position de la caméra
        Vector3 position = target.position - rotation * Vector3.forward * distance;

        transform.position = position;

        // La caméra regarde le Player
        transform.LookAt(target);
    }
}