using UnityEngine;
using UnityEngine.UIElements;

public class FollowCamera : MonoBehaviour
{
    public float MoveSpeed;
    public Transform Target;
    private Rigidbody2D _rb;
    private Bounds _cameraBounds;
    private Vector3 _targetPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Target = GameManager.Instance.Player.transform;
    }

    private void Update()
    {
        _targetPosition = Target.position;

        //_rb.MovePosition(Vector3.MoveTowards(transform.position, _targetPosition, MoveSpeed * Time.deltaTime));

        transform.position = GetBounds();
    }

    public void SetBounds(Bounds bounds)
    {
        float height = Camera.main.orthographicSize;
        float width = height * Camera.main.aspect;

        float minX = bounds.min.x + width;
        float maxX = bounds.max.x - width;
        float minY = bounds.min.y + height;
        float maxY = bounds.max.y - height;

        _cameraBounds = new Bounds();

        _cameraBounds.SetMinMax(
            new Vector3(minX, minY, 0.0f),
            new Vector3(maxX, maxY, 0.0f)
            );

        Debug.Log(_cameraBounds);
    }

    private Vector3 GetBounds()
    {
        return new Vector3(
            Mathf.Clamp(_targetPosition.x, _cameraBounds.min.x, _cameraBounds.max.x),
            Mathf.Clamp(_targetPosition.y, _cameraBounds.min.y, _cameraBounds.max.y),
            transform.position.z
        );
    }
}
