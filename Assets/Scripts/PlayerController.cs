using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;

    private float moveDirection = 1f;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += Vector3.right
                            * moveDirection
                            * moveSpeed
                            * Time.deltaTime;
    }
}