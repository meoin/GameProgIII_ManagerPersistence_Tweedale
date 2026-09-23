using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    private void OnEnable()
    {
        Bounds bounds = GetComponent<Collider2D>().bounds;
        GameManager.Instance.Camera.SetBounds(bounds);
    }
}
