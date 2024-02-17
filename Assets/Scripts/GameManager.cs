using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public float score = 0f;
    [SerializeField] private TextMeshProUGUI scoreBalls;
    public static GameManager Instance { get { return instance; } }
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    // Updates score for the player and changes it on screen
    public void UpdateScore(float ball)
    {
        score += ball;
        scoreBalls.SetText("DRAGON BALLS: " + score);

        if (score == 7f)
        {
            Debug.Log("<b><color=yellow>GOKU: HE REUNIDOS LAS 7 BOLAS DE DRAGÓN :D</color></b>");
        }
    }
}
