using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(SpriteRenderer))]
public class DragAndDrop : MonoBehaviour
{
    private bool _isDragging;
    private Rigidbody2D _rigidbody;
    private Collider2D _collider;
    private SpriteRenderer _spriteRenderer;
    private float _overlapRadius;

    public LayerMask standSurfaceLayer;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        //Вычисление радиуса в зависимости от размера коллайдера
        _overlapRadius = transform.localScale.x * _collider.bounds.size.x/2; 
    }

    void Update()
    {
        if (_isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
    }

    void OnMouseDown()
    {
        _isDragging = true;
        _rigidbody.bodyType = RigidbodyType2D.Kinematic;
        
        //Перемещение на передний план 
        _spriteRenderer.sortingOrder = 1; 
    }

    void OnMouseUp()
    {
        _isDragging = false;
        //Перемещение на второй план 
        _spriteRenderer.sortingOrder = 0;
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;

        CheckForSurface();
    }

    private void CheckForSurface()
    {
        // Проверяем, пересекается ли коллайдер объекта с коллайдером поверхности
        Collider2D[] overlappingColliders = Physics2D.OverlapCircleAll(transform.position, _overlapRadius, standSurfaceLayer);

        if (overlappingColliders.Length > 0)
        {
            SnapToSurface();
        }
    }

    private void SnapToSurface()
    {
        _rigidbody.bodyType = RigidbodyType2D.Kinematic;
        _rigidbody.linearVelocity = Vector2.zero;
    }
}
