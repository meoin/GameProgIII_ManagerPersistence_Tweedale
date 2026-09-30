using UnityEngine;

public class TransitionPoint : MonoBehaviour
{
    public string ID = "DEFAULT";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        if (GameManager.Instance.TransitionPoint == ID) 
        {
            Debug.Log($"Transition point {ID} found.");

            Vector3 newPlayerPosition = transform.position;

            if (GameManager.Instance.MaintainY) newPlayerPosition.y = GameManager.Instance.Player.transform.position.y;

            Debug.Log($"Player currently at {GameManager.Instance.Player.transform.position}");
            Debug.Log($"Putting player at {newPlayerPosition}");

            GameManager.Instance.Player.transform.position = newPlayerPosition;

            Debug.Log($"Player now at {GameManager.Instance.Player.transform.position}");
        }   
    }

    private void OnDrawGizmos()
    {
        DrawGizmo();
    }

    private void DrawGizmo()
    {
        Color color = Color.green;
        color.a = 0.5f;

        Gizmos.color = color;

        Gizmos.DrawWireSphere(transform.position, 0.2f);

        #if UNITY_EDITOR

        GUIStyle style = new GUIStyle();
        style.alignment = TextAnchor.MiddleCenter;
        style.normal.textColor = Color.white;

        // Draw the text at the position (offset slightly upward so it doesn't overlap)
        Vector3 textPosition = transform.position + Vector3.down * 0.5f;
        UnityEditor.Handles.Label(textPosition, ID, style);
        #endif
    }
}
