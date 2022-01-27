using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;

    private int levelsPassed = 0;
    private static bool isPlaying;
    
    
    void Start()
    {
        uiManager.MainScreen();
    }

    
    public void GameStart(int level)
    {
        
    }

    public void CheckLevel()
    {
        
    }
}
