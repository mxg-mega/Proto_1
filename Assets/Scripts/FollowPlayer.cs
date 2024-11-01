using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0, 2, -3);
    [SerializeField] private Quaternion offsetRotation = Quaternion.Euler(0, 0, 0);

    void LateUpdate()
    {
        // Calculate the position with offset
        Vector3 targetPosition = player.transform.position + offset;
        transform.position = targetPosition;

        // Apply offset rotation
        transform.rotation = offsetRotation;
    }
}
