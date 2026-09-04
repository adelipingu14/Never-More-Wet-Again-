using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float boundaryOffset = 0.05f;

    private float moveDirection = 1f;
    private Camera mainCamera;

    private SpriteRenderer spriteRenderer;

    private float leftBoundary;
    private float rightBoundary;

    private void Awake()
    {
        mainCamera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        Vector3 leftEdge =
            mainCamera.ViewportToWorldPoint(new Vector3(0f, 0.5f, 0f));

        Vector3 rightEdge =
            mainCamera.ViewportToWorldPoint(new Vector3(1f, 0.5f, 0f));

        float halfWidth = spriteRenderer.bounds.extents.x;

        leftBoundary = leftEdge.x + halfWidth - boundaryOffset;
        rightBoundary = rightEdge.x - halfWidth + boundaryOffset;
    }

    private void Update()
    {
        Move();
        CheckBoundary();

        if (Input.GetMouseButtonDown(0))
        {
            ChangeDirection(-moveDirection);

        }
    }

    private void Move()
    {
        transform.position += Vector3.right
                            * moveDirection
                            * moveSpeed
                            * Time.deltaTime;
    }

    private void CheckBoundary()
    {
        if (transform.position.x >= rightBoundary)
        {
            ChangeDirection(-1f);
        }

        if (transform.position.x <= leftBoundary)
        {
            ChangeDirection(1f);
        }
    }

    private void ChangeDirection(float direction)
    {
        moveDirection = direction;
        spriteRenderer.flipX = direction < 0f;
    }
}