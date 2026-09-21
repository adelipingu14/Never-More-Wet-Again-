using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverAnimation;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private AnimationClip gameOverClip;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0.0f;

        StartCoroutine(GameOverSequence());
    }

    private IEnumerator GameOverSequence()
    {
        gameOverAnimation.SetActive(true);

        yield return new WaitForSecondsRealtime(gameOverClip.length);

        gameOverMenu.SetActive(true);
    }
}
