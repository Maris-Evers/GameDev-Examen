using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameWinUI;
    private bool isGameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverUI.activeInHierarchy || gameWinUI.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            GameObject.FindWithTag("Player").GetComponent<Player>().enabled = false;
            GameObject.FindWithTag("Player").GetComponent<PlayerFuel>().enabled = false;
            GameObject.Find("DistanceText").GetComponent<DistanceCalculator>().enabled = false;
            gameOverUI.SetActive(true);
            isGameOver = true;
        }
    }

    public void GameWin()
    {
        if (!isGameOver)
        {
            GameObject.FindWithTag("Player").GetComponent<Player>().enabled = false;
            GameObject.FindWithTag("Player").GetComponent<PlayerFuel>().enabled = false;
            GameObject.Find("DistanceText").GetComponent<DistanceCalculator>().enabled = false;
            gameWinUI.SetActive(true);
            isGameOver = true;
            OnResetOrWin();
        }
    }

    public void Restart()
    {
        OnResetOrWin();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        OnResetOrWin();
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void OnResetOrWin()
    {
        GameObject.Find("SpawnManager").GetComponent<SpawnManager>().OnResetOrWin();
    }
}
