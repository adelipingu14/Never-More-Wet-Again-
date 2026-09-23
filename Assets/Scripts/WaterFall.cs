using UnityEngine;

public class WaterFall : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("충돌감지");
            GameManager.Instance.GameOver();
        }

        if (collision.gameObject.CompareTag("DestroyZone"))
        { 
            Destroy(gameObject);
        }
    }
}
