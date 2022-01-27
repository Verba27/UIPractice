using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject choseLevelCanvas;
    [SerializeField] private GameObject playCanvas;
    [SerializeField] private GameObject victoryPopup;
    [SerializeField] private Button[] buttonsActive;
    [SerializeField] private Button[] buttonsClosed;
    [SerializeField] private GameObject[] emptyStarsVictory;
    [SerializeField] private GameObject[] fullStarsVictory;
    [SerializeField] private SuperGame game;
    [SerializeField] private GameObject choseLevelScaler;
    [SerializeField] private float timeToScale = 2f;
    [SerializeField] private CreateButtons createButtons;
    private int levelsActive = 1;

    public void MainScreen()
    {
        mainMenuCanvas.SetActive(true);
        choseLevelCanvas.SetActive(false);
        victoryPopup.SetActive(false);
    }
    
    
    public void ChoseLevelWindow()
    {
        StartCoroutine(Scaler());
        mainMenuCanvas.SetActive(false);
        choseLevelCanvas.SetActive(true);
        StartCoroutine(Fader());
        //createButtons.ResumeButtons(levelsActive);
        for (int i = 0; i < buttonsActive.Length; i++)
        {
            buttonsActive[levelsActive-1].gameObject.SetActive(true);
            buttonsClosed[levelsActive-1].gameObject.SetActive(false);
        }
    }

    public void BeginGame(int level)
    {
        choseLevelCanvas.SetActive(false);
        victoryPopup.SetActive(false);
        playCanvas.SetActive(true);
        game.ResetStars();
        if (level == levelsActive)
        {
            levelsActive++;
        }
        
    }

    public void PassedLevelStars(int stars)
    {
        buttonsActive[levelsActive-2].GetComponent<MyButton>().StarsOnButtonLevel(stars);
    }
    public void FinishGame(int stars)
    {
        Victory(stars+1);
        PassedLevelStars(stars);
        Debug.Log(stars);
    }

    public void Victory(int stars)
    {
        victoryPopup.GetComponent<CanvasGroup>().alpha = 1;
        playCanvas.SetActive(false);
        victoryPopup.SetActive(true);
        
        for (int i = 0; i < emptyStarsVictory.Length; i++)
        {
            fullStarsVictory[i].SetActive(i < stars);
            
        }
    }

    private IEnumerator Scaler()
    {
        float timer = 0;
        var startScale = Vector3.zero;
        var endScale = Vector3.one;
        while (timer < timeToScale)
        {
            timer += Time.deltaTime;
            choseLevelScaler.transform.localScale = Vector3.Lerp(startScale, endScale, timer / timeToScale);
            yield return null;
        }
    }

    private IEnumerator Fader()
    {
        float timer = 0;
        var startFade = 1;
        var endFade = 0;
        while (timer < timeToScale)
        {
            timer += Time.deltaTime;
            victoryPopup.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(startFade, endFade, timer / timeToScale);
            yield return null;
        }
        victoryPopup.SetActive(false);
    }
}
