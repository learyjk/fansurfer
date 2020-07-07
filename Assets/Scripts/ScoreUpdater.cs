using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    private void Start() 
    {
        GetComponent<Text>().text = GameStatus.GetInstance().GetScore();
        GameStatus.GetInstance().ResetScore();
    }

    void Update()
    {
        GetComponent<Text>().text = GameStatus.GetInstance().GetScore();
    }
}
