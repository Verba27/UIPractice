using System;
using TMPro;
using UnityEngine;

public class MyButton : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    private int level;
    [SerializeField]
    private TextMeshProUGUI buttonNumber;
    [SerializeField] private GameObject[] emptyStars;
    [SerializeField] private GameObject[] fullStars;
    
    public void EnterGame()
    {
        level = Int32.Parse(buttonNumber.text);
        uiManager.BeginGame(level);
    }

    public void StarsOnButtonLevel(int stars)
    {
        for (int i = 0; i < stars+1; i++)
        {
            fullStars[i].SetActive(true);
        }
    }
}
