using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    static GameStatus instance;
    public static GameStatus GetInstance() { return instance; }

    protected int score;

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
    }

    public string GetScore()
    {
        return score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
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

    
}
