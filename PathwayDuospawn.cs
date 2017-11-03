using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Done_GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	
	private bool gameOver;
	private bool restart;
	private int score;
	
	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}
	
	void Update ()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 1; i <= hazardCount; i++)
			{
				GameObject hazard = hazards[Random.Range(0, hazards.Length)];

                Vector3 spawnPosition = new Vector3(0, 0, 0);
                Vector3 spawnPosition2 = new Vector3(0, 0, 0);

                if ((i + 11) % 12 == 0)
                {
                    spawnPosition = new Vector3(-3, spawnValues.y, spawnValues.z);
                    spawnPosition2 = new Vector3(3, spawnValues.y, spawnValues.z);
                }
                else if ((i + 10) % 12 == 0)
                {
                    spawnPosition = new Vector3(-2, spawnValues.y, spawnValues.z);
                    spawnPosition2 = new Vector3(4, spawnValues.y, spawnValues.z);
                }
                else if ((i + 9) % 12 == 0)
                {
                    spawnPosition = new Vector3(-1, spawnValues.y, spawnValues.z);
                    spawnPosition2 = new Vector3(5, spawnValues.y, spawnValues.z);
                }
                else if ((i + 8) % 12 == 0)
                {
                    spawnPosition = new Vector3(0, spawnValues.y, spawnValues.z);
                    spawnPosition2 = new Vector3(6, spawnValues.y, spawnValues.z);
                }
                else if ((i + 7) % 12 == 0)
                {
                    spawnPosition = new Vector3(-1, spawnValues.y, spawnValues.z);
                    spawnPosition2 = new Vector3(5, spawnValues.y, spawnValues.z);
                }
                else if ((i + 6) % 12 == 0)
                {
                    spawnPosition = new Vector3(-2, spawnValues.y, spawnValues.z);
                    spawnPosition2 = new Vector3(4, spawnValues.y, spawnValues.z);
                }
                else if ((i + 5) % 12 == 0)
                {
                    spawnPosition = new Vector3(-3, spawnValues.y, spawnValues.z);
                    spawnPosition2 = new Vector3(3, spawnValues.y, spawnValues.z);
                }
                else if ((i + 4) % 12 == 0)
                {
                    spawnPosition = new Vector3(-4, spawnValues.y, spawnValues.z);
                    spawnPosition2 = new Vector3(2, spawnValues.y, spawnValues.z);
                }
                else if ((i + 3) % 12 == 0)
                {
                    spawnPosition = new Vector3(-5, spawnValues.y, spawnValues.z);
                    spawnPosition2 = new Vector3(1, spawnValues.y, spawnValues.z);
                }
                else if ((i + 2) % 12 == 0)
                {
                    spawnPosition = new Vector3(-6, spawnValues.y, spawnValues.z);
                    spawnPosition2 = new Vector3(0, spawnValues.y, spawnValues.z);
                }
                else if ((i + 1) % 12 == 0)
                {
                    spawnPosition = new Vector3(-5, spawnValues.y, spawnValues.z);
                    spawnPosition2 = new Vector3(1, spawnValues.y, spawnValues.z);
                }
                else 
                {
                    spawnPosition = new Vector3(-4, spawnValues.y, spawnValues.z);
                    spawnPosition2 = new Vector3(2, spawnValues.y, spawnValues.z);
                }


                Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
                Instantiate (hazard, spawnPosition2, spawnRotation);
                yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			
			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}
	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}
	
	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}