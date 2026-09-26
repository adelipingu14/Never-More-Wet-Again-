using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverAnimation;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private FallingSpawner fallingSpawner;
    [SerializeField] private AnimationClip gameOverClip;
    [SerializeField] private TMP_Text survivalTimeText;

    private float survivalTime;
    private int currentDifficulty = 0;
    public static GameManager Instance;

    private void Update()
    {
        survivalTime += Time.deltaTime;

        int difficulty = (int)(survivalTime / 15f);

        if (difficulty != currentDifficulty)
        {
            currentDifficulty = difficulty;
            fallingSpawner.RainIncreased();
        }
    }
    private void Start()
    {
        GameStart();
    }
    private void Awake()
    {
        Instance = this;
    }

    public void GameStart()
    { 
        Time.timeScale = 1.0f;
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

        gameOverAnimation.SetActive(false);
        survivalTimeText.text = $"방송 시간 : {survivalTime:F2}초";

        gameOverMenu.SetActive(true);
    }
}
