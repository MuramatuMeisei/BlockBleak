using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] int ballCount = 3;

    [SerializeField] UIManager uiManager;
    [SerializeField] TimerManager timerManager;
    [SerializeField] SceneLoader sceneLoader;

    private int score = 0;
    private bool inGame = true;
    private int brokenObjectCount;
    private int highScore = 0;

    [SerializeField] string nextSceneName = "Stage02";

    private void OnEnable()
    {
        Broken.OnScoreAdded += AddScore;
        Broken.OnObjectBroken += OnBroken;
        Kill.OnObjectKill += OnKillBall;
    }

    private void OnDisable()
    {
        Broken.OnScoreAdded -= AddScore;
        Broken.OnObjectBroken -= OnBroken;
        Kill.OnObjectKill -= OnKillBall;
    }

    private void Start()
    {
        uiManager.HideResult();
        uiManager.SetScoreText(score);

        brokenObjectCount = FindObjectsOfType<Broken>().Length;

        timerManager.StartTimer();
        timerManager.OnTimerEnd += HandleTimerEnd;
    }

    private void Update()
    {
        if (inGame)
        {
            uiManager.SetTimerText(timerManager.GetLeftTime());
        }
    }

    private void HandleTimerEnd()
    {
        inGame = false;
        uiManager.SetTimerText(0);
        uiManager.ShowGameOver();
    }

    public void AddScore(int point)
    {
        score += point;
        uiManager.SetScoreText(score);
    }

    public void OnBroken()
    {
        brokenObjectCount--;
        if (brokenObjectCount <= 0)
        {
            inGame = false;
            uiManager.ShowClear();
            ShowResult();
        }
    }

    public void OnKillBall()
    {
        ballCount--;

        if (ballCount > 0)
        {
            GameObject newBall = Instantiate(ballPrefab);
            newBall.name = ballPrefab.name;
        }
        else
        {
            inGame = false;
            uiManager.ShowGameOver();
        }
    }

    private void ShowResult()
    {
        int totalScore = score + Mathf.RoundToInt(timerManager.GetLeftTime()) * 100 + ballCount * 500;

        if (highScore < totalScore)
        {
            highScore = totalScore;
        }

        uiManager.ShowResult(score, timerManager.GetLeftTime(), ballCount, totalScore, highScore);
    }

    public void OnTapRetry()
    {
        sceneLoader.ReloadCurrentScene();
    }

    public void OnTapNextScene()
    {
        sceneLoader.LoadSceneByName(nextSceneName);
    }
}
