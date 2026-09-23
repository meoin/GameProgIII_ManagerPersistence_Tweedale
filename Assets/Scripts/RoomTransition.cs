using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;

public class RoomTransition : MonoBehaviour
{
    public string SceneName;
    public string DestinationID = "DEFAULT";
    public bool maintainY = true;

    private void Start()
    {
        GarbageCollector.GCMode = GarbageCollector.Mode.Enabled;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            GameManager.Instance.MaintainY = maintainY;
            GameManager.Instance.TransitionPoint = DestinationID;

            GameObject.Find(GameManager.Instance.CurrentRoom).GetComponent<RoomActivation>().DisableRoom();
            GameManager.Instance.CurrentRoom = SceneName;
            GameObject.Find(SceneName).GetComponent<RoomActivation>().ActivateRoom();
        }
    }

    private void OnDrawGizmos()
    {
        DrawGizmo();
    }

    private void DrawGizmo()
    {
        Gizmos.color = Color.purple;

        // Get the BoxCollider component
        BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();

        // Set the matrix for Gizmos to the transform's local-to-world matrix
        Gizmos.matrix = transform.localToWorldMatrix;

        // Get the local position and size of the BoxCollider
        Vector3 localPosition = collider.offset;
        Vector3 size = collider.size;

        // Draw the gizmo cube at the local position and with the collider size
        Gizmos.DrawCube(localPosition, size);
    }
}
