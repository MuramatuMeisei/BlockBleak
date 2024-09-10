using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] GameObject ballPrefab;
	[SerializeField] int ballCount = 3;
	[SerializeField] GameObject gameOverText;
	[SerializeField] GameObject clearText;

	[SerializeField] TextMeshProUGUI scoreText;
	[SerializeField] TextMeshProUGUI timerText;

	private int score = 0;
	[SerializeField] private float leftTime = 30;
	private bool inGame = true;

	private int brokenObjectCount;

	[SerializeField] TextMeshProUGUI resultScore;
	[SerializeField] TextMeshProUGUI resultTime;
	[SerializeField] TextMeshProUGUI resultLife;
	[SerializeField] TextMeshProUGUI resultTotalScore;

	[SerializeField] GameObject resultRoot;

	[SerializeField] TextMeshProUGUI highScoreUI;

	private int highScore = 0;

	[SerializeField] string nextSceneName = "Stage02";

	private void SetScoreText()
	{
		scoreText.text = "Score: " + score;
	}

	public void AddScore(int point)
	{
		score += point;
		SetScoreText();
	}

	public void OnBroken()
	{
		brokenObjectCount--;
		if (brokenObjectCount <= 0)
		{
			inGame = false;
			clearText.SetActive(true);
			ShowResult();
		}
	}

	public void OnTapRetry()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	private void ShowResult()
	{
		resultRoot.SetActive(true);
		resultScore.text = "Score: " + score;
		resultTime.text = "Time: " + Mathf.RoundToInt(leftTime) + "x 100 = " + Mathf.RoundToInt(leftTime) * 100;
		resultLife.text = "Life: " + ballCount + "x 500 = " + ballCount * 500;

		int toralScore = score + Mathf.RoundToInt(leftTime) * 100 + ballCount * 500;
		resultTotalScore.text = "Total Score: " + toralScore;

		if (highScore < toralScore)
		{
			highScore = toralScore;
			highScoreUI.text = "High Score: " + highScore;
		}
	}

	private void Start()
	{
		gameOverText.SetActive(false);
		clearText.SetActive(false);
		SetScoreText();

		brokenObjectCount = FindObjectsOfType<Broken>().Length;
		resultRoot.SetActive(false);
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
			gameOverText.SetActive(true);
		}
	}

	public void OnTapNextScene()
	{
		SceneManager.LoadScene(nextSceneName);
	}

	private void Update()
	{
		if (inGame == true)
		{
			leftTime -= Time.deltaTime;
			timerText.text = "Time: " + Mathf.RoundToInt(leftTime);
			if (leftTime <= 0)
			{
				inGame = false;
				timerText.text = "Time: 0";
				gameOverText.SetActive(true);
			}
		}
	}

}
