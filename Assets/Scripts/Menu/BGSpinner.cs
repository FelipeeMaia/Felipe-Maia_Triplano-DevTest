using UnityEngine;

public class BGSpinner : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        float rotationVelocity = speed * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(Vector3.forward * rotationVelocity);
        transform.rotation *= rotation;
    }
}
