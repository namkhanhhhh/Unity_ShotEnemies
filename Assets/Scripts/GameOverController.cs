using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    Text txtScore;
    [SerializeField]
    Text txtOverOrWinner;

    private int NewScore;
    private int PreviousScore;
    void Start()
    {
        NewScore = PlayerPrefs.GetInt("Score", 0); // Nếu không có, mặc định là 0

        PreviousScore = PlayerPrefs.GetInt("PreviousScore", 0); // Nếu không có, mặc định là 0

        Debug.Log($"Previous Score: {PreviousScore}, New Score: {NewScore}");

        DisplayScore();
    }
    void Update()
    {
        
    }

    public void HandlePlayAgain()
    {
        PlayerController.score = 0;
        SceneManager.LoadScene("Gameplay");
    }

    void DisplayScore()
    {
        txtScore.text = NewScore > PreviousScore ? $"High score: {NewScore.ToString()} wowww! Play Again?" :  $"Your score: {NewScore.ToString()}! Try again?";

        txtOverOrWinner.text = NewScore > PreviousScore ? "Winner" : "Game Over";
    }
}
