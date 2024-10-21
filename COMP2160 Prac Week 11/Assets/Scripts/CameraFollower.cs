using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform marble;

    void Update()
    {
        transform.position = marble.position;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, 0.2f);
    }
}
