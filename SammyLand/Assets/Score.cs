using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private static int totalScore;

    public static int getScore()
    {
        return totalScore;
    }

    public static void setScore(int newScore)
    {
        totalScore = newScore;
    }

}
