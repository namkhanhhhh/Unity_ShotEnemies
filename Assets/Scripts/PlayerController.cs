using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float currentHp;
    [SerializeField]
    private float maxHp = 100;
    [SerializeField]
    private Image hpFill;

    public static int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHp = maxHp;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //nếu hết máu thì game over
        if (currentHp <= 0) DisplayGameOver();
    }

    //giảm hp player 
    public void ReduceHP(float amount)
    {
        if (currentHp > 0) {
            currentHp -= amount;
            hpFill.fillAmount = currentHp / maxHp;
            Debug.Log("HP giảm còn: " + currentHp);
        }
    }

    //hiển thị scenes gameover
    public void DisplayGameOver()
    {

        int currentScore = PlayerController.score; // Lấy điểm số ván hiện tại

        // Lấy điểm số cũ trước khi cập nhật điểm mới
        int lastScore = PlayerPrefs.GetInt("Score", 0);

        PlayerPrefs.SetInt("PreviousScore", lastScore); // Lưu điểm số của ván trước
        PlayerPrefs.SetInt("Score", currentScore); // Lưu điểm số hiện tại
        PlayerPrefs.Save();

        Debug.Log("Game Over");
        SceneManager.LoadScene("GameOver");
    }

}
