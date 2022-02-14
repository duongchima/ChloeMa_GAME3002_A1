using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int score;
    public Text scoreText;

    void Update()
    {
        scoreText.text = score.ToString();
    }
}
