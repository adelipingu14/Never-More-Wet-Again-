using UnityEngine;

public class FallingSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Start()
    {
        InvokeRepeating("ObstacleRain", 0f, 1f);
    }

    void ObstacleRain()
    { 
        float randomX = Random.Range(0f, 1f);

        Vector3 topEdge =
            mainCamera.ViewportToWorldPoint(new Vector3(randomX, 1.5f, 0f));

        topEdge.z = 0f;

        Instantiate(obstacle, topEdge, Quaternion.identity);
    }


}
