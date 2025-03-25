using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    Text txtPause;
    [SerializeField]
    Text txtTime;
    [SerializeField]
    int totalTime;
    [SerializeField] 
    Text txtScore; 


    private int remainTime;
    private float time = 0;
    private bool isRuning;
    void Start()
    {
        isRuning = true;       
        
        remainTime = totalTime;

        txtTime.text = $"Time: {remainTime.ToString()} ";
    }

    void Update()
    {
        DisplayTime();
    }

    private void DisplayTime()
    {
        time += Time.deltaTime;
        if (time > 1)
        {
            remainTime -= 1;
            txtTime.text = $"Time: {remainTime.ToString()} ";
            time = 0;
        }
        if (remainTime <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

    }
    public void HandleBtnPause()
    {
        if (isRuning)
        {
            Pause();
        }
        else
        {
            Resume();
        }

    }

    void Pause()
    {
        Time.timeScale = 0;
        txtPause.text = "Resume";
        isRuning = false;
    } 

    void Resume()
    {
        Time.timeScale = 1;
        txtPause.text = "Pause";
        isRuning = true;
    }

    private void UpdateScoreDisplay()
    {
        txtScore.text = $"Score: {PlayerController.score}";
    }

}
