using UnityEngine;

public class CameraScrolling : MonoBehaviour
{
    [SerializeField]private float scrollSpeed = 3f;
    [SerializeField]private float edgeThreshold = 0.1f;

    [SerializeField] private Vector2 cameraBoundsMin;
    [SerializeField] private Vector2 cameraBoundsMax;
    private Vector2 _moveDirection;


    void Update()
    {
        var mousePosition = Input.mousePosition;
        _moveDirection = Vector2.zero;

        // ���������, ��������� �� ������ � ����� ������
        if (mousePosition.x < Screen.width * edgeThreshold)
        {
            _moveDirection.x = -1; // ������� ������ �����
        }
        else if (mousePosition.x > Screen.width * (1 - edgeThreshold))
        {
            _moveDirection.x = 1; // ������� ������ ������
        }

        var newPosition = transform.position + (Vector3)_moveDirection * scrollSpeed * Time.deltaTime;

        // ������������ ������� ������ � �������� ����� ������
        newPosition.x = Mathf.Clamp(newPosition.x, cameraBoundsMin.x, cameraBoundsMax.x);
        newPosition.y = Mathf.Clamp(newPosition.y, cameraBoundsMin.y, cameraBoundsMax.y);

        transform.position = newPosition;
    }
}