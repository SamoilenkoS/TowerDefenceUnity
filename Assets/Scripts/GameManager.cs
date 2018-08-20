using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public static bool GameIsOver;

    #region Unity methods
    private void Start()
    {
        GameIsOver = false;
    }

	private void Update ()
    {
        if(GameIsOver)
        {
            return;
        }
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
	}

    #endregion

    private void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }
}
