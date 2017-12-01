using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController2 : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;

    private int waveCount;
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
        levelText.text = "Level 2";
        restartText.text = "";
        gameOverText.text = "";
        UpdateScore();

        waveCount = 1;
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
            System.Random ran = new System.Random();
            int pickPattern = 0;
            int lastPattern = 5;
            pickPattern = ran.Next(1, 4);
            while (pickPattern == lastPattern)
            {
                pickPattern = ran.Next(1, 4);
            }

            if (pickPattern == 1)
            {
                for (int i = 0; i < 16; i++)
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
                    Instantiate(hazard, spawnPosition, spawnRotation);
                    Instantiate(hazard, spawnPosition2, spawnRotation);
                    yield return new WaitForSeconds(spawnWait / 2);
                }
                yield return new WaitForSeconds(2);
            }

            if (pickPattern == 2)
            {
                for (int i = 1; i <= 25; i++)
                {
                    GameObject hazard = hazards[Random.Range(0, hazards.Length)];

                    Vector3 spawnPosition = new Vector3(0, 0, 0);

                    if ((i + 5) % 6 == 0)
                    {
                        spawnPosition = new Vector3(-6, spawnValues.y, spawnValues.z);
                    }
                    else if ((i + 4) % 6 == 0)
                    {
                        spawnPosition = new Vector3(-2, spawnValues.y, spawnValues.z);
                    }
                    else if ((i + 3) % 6 == 0)
                    {
                        spawnPosition = new Vector3(2, spawnValues.y, spawnValues.z);
                    }
                    else if ((i + 2) % 6 == 0)
                    {
                        spawnPosition = new Vector3(6, spawnValues.y, spawnValues.z);
                    }
                    else if ((i + 1) % 6 == 0)
                    {
                        spawnPosition = new Vector3(2, spawnValues.y, spawnValues.z);
                    }
                    else
                    {
                        spawnPosition = new Vector3(-2, spawnValues.y, spawnValues.z);
                    }

                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait / 4);
                }
                yield return new WaitForSeconds(2);
            }
            
            if (pickPattern == 3)
            {
                for (int i = 1; i <= 28; i++)
                {
                    GameObject hazard = hazards[Random.Range(0, hazards.Length)];

                    Vector3 spawnPosition = new Vector3(0, 0, 0);

                    if ((i + 6) % 7 == 0)
                    {
                        spawnPosition = new Vector3(-6, spawnValues.y, spawnValues.z);
                    }
                    else if ((i + 5) % 7 == 0)
                    {
                        spawnPosition = new Vector3(-4, spawnValues.y, spawnValues.z);
                    }
                    else if ((i + 4) % 7 == 0)
                    {
                        spawnPosition = new Vector3(-2, spawnValues.y, spawnValues.z);
                    }
                    else if ((i + 3) % 7 == 0)
                    {
                        spawnPosition = new Vector3(0, spawnValues.y, spawnValues.z);
                    }
                    else if ((i + 2) % 7 == 0)
                    {
                        spawnPosition = new Vector3(2, spawnValues.y, spawnValues.z);
                    }
                    else if ((i + 1) % 7 == 0)
                    {
                        spawnPosition = new Vector3(4, spawnValues.y, spawnValues.z);
                    }
                    else
                    {
                        spawnPosition = new Vector3(6, spawnValues.y, spawnValues.z);
                    }

                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait / 4);
                }
                yield return new WaitForSeconds(2);
            }
            
            if (pickPattern == 4)
            {
                for (int i = 1; i <= 25; i++)
                {
                    GameObject hazard = hazards[Random.Range(0, hazards.Length)];

                    Vector3 spawnPosition = new Vector3(0, 0, 0);

                    if ((i + 7) % 8 == 0)
                    {
                        spawnPosition = new Vector3(-6, spawnValues.y, spawnValues.z);
                    }
                    else if ((i + 6) % 8 == 0)
                    {
                        spawnPosition = new Vector3(6, spawnValues.y, spawnValues.z);
                    }
                    else if ((i + 5) % 8 == 0)
                    {
                        spawnPosition = new Vector3(-3, spawnValues.y, spawnValues.z);
                    }
                    else if ((i + 4) % 8 == 0)
                    {
                        spawnPosition = new Vector3(3, spawnValues.y, spawnValues.z);
                    }
                    else if ((i + 3) % 8 == 0)
                    {
                        spawnPosition = new Vector3(0, spawnValues.y, spawnValues.z);
                    }
                    else if ((i + 2) % 8 == 0)
                    {
                        spawnPosition = new Vector3(3, spawnValues.y, spawnValues.z);
                    }
                    else if ((i + 1) % 8 == 0)
                    {
                        spawnPosition = new Vector3(-3, spawnValues.y, spawnValues.z);
                    }
                    else
                    {
                        spawnPosition = new Vector3(6, spawnValues.y, spawnValues.z);
                    }

                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait / 4);
                }
                yield return new WaitForSeconds(2);
            }

            if (PlayerData.data.gameOver)
            {
                restartText.text = "Press 'R' to Restart";
                gameOverText.text = "Game Over!";
                restart = true;
                break;
            }

            if (waveCount == hazardCount)
            {
                SceneManager.LoadScene("Level 3");
            }
            waveCount++;
        }
    }
   

    void UpdateScore()
    {
        scoreText.text = "Score: " + PlayerData.data.score;
        currentScore = PlayerData.data.score;
    }
}