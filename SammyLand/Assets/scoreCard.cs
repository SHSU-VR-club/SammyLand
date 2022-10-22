using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreCard : MonoBehaviour
{
    void Update()
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = Score.getScore().ToString();
    }
}
