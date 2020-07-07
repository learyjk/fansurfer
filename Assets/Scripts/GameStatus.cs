using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    static GameStatus instance;
    public static GameStatus GetInstance() { return instance; }

    public int score;
    public float speed = 4.5f;

    void Awake()
    {
        Application.targetFrameRate = 300;
    }

    void Start()
    {

        //Singleton - There should only ever be ONE GameStatus!
        if (instance != null)
        {
            //instance already set!
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        GameStatus.DontDestroyOnLoad(this.gameObject);
    }

    public void AddToScore(int amt)
    {
        score += amt;
        if (score % 5 == 0)
        {
            RaiseSpeed(0.5f);
        } 
    }

    public string GetScore()
    {
        return score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
        speed = 4.5f;
    }

    public void GameOver() {
        LoadScene("GameOver");
    }

    public void Retry() {
        LoadScene("PlayScene");
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void RaiseSpeed(float amount)
    {
        speed += amount;
    }   
}
