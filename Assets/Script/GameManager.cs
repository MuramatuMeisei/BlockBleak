using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] GameObject ballPrefab;
	[SerializeField] int ballCount = 3;
	[SerializeField] float leftTime = 30;

	[SerializeField] UIManager uiManager;

	private int score = 0;
	private bool inGame = true;
	private int brokenObjectCount;
	private int highScore = 0;

	[SerializeField] string nextSceneName = "Stage02";

	private void Start()
	{
		uiManager.HideResult();
		uiManager.SetScoreText(score);

		brokenObjectCount = FindObjectsOfType<Broken>().Length;
	}

	private void Update()
	{
		if (inGame)
		{
			leftTime -= Time.deltaTime;
			uiManager.SetTimerText(leftTime);

			if (leftTime <= 0)
			{
				inGame = false;
				uiManager.SetTimerText(0);
				uiManager.ShowGameOver();
			}
		}
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
		int totalScore = score + Mathf.RoundToInt(leftTime) * 100 + ballCount * 500;

		if (highScore < totalScore)
		{
			highScore = totalScore;
		}

		uiManager.ShowResult(score, leftTime, ballCount, totalScore, highScore);
	}

	public void OnTapRetry()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void OnTapNextScene()
	{
		SceneManager.LoadScene(nextSceneName);
	}
}
