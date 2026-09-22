using UnityEngine;
using UnityEngine.UIElements;

public class FollowCamera : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 movePosition = transform.position;

        movePosition.x = target.position.x;

        transform.position = movePosition;
    }
}
