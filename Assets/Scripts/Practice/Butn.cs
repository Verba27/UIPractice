using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Butn : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameObject[] empty;
    [SerializeField] private GameObject[] full;
    //private GameLevelSaver _gameLevelSaver;
    public void StarsShine(int stars)
    {
        for (int i = 0; i < full.Length; i++)
        {
            full[stars-1].gameObject.SetActive(true);
            empty[stars-1].gameObject.SetActive(false);
        }
    }

    public void PlayStart()
    {
        
        //_gameLevelSaver.AddLevel(Int32.Parse(gameObject.name));
        
    }
    
}
