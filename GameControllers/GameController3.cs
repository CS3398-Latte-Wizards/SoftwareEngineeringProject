using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController3 : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;

    //private int waveCount;
    private int currentScore;

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;
    public GUIText levelText;

    public float spawnWait;
    public float startWait;
    public float wavewait;
    private bool restart;
   

    void Start()
    {
        restart = false;
        levelText.text = "Level 3";
        restartText.text = "";
        gameOverText.text = "";
        UpdateScore();

        //waveCount = 1;
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {

        if (PlayerData.data.score != currentScore)
        {
            UpdateScore();
        }


        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Destroy(PlayerData.data);
                SceneManager.LoadScene("Menu");
            }
        }

    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];

                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(wavewait);

            if (PlayerData.data.gameOver)
            {
                restartText.text = "Press 'R' to Restart";
                gameOverText.text = "Game Over!";
                restart = true;
                break;
            }

            /*if (waveCount % 2 == 0)
            {
                SceneManager.LoadScene("Level 2");
            }
            waveCount++;*/

        }
    }
   

    void UpdateScore()
    {
        scoreText.text = "Score: " + PlayerData.data.score;
        currentScore = PlayerData.data.score;
    }

    


}
