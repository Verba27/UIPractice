using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreateButtons : MonoBehaviour
{
    [SerializeField] private GameObject parentOff;
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject buttonOffPrefab;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Transform[] positions;
    [SerializeField] private List<GameObject> buttonsOff;
    [SerializeField] public List<GameObject> buttons;
    public void ResumeButtons(int levels)
    {
        for (int i = 0; i < positions.Length; i++)
        {
            GameObject button = Instantiate(buttonOffPrefab, parentOff.transform);
            button.name = (i+1).ToString();
            button.transform.position = positions[i].position;
            button.GetComponentInChildren<TextMeshProUGUI>().text = (i+1).ToString();
            buttonsOff.Add(button);
        }
        for (int i = 0; i < levels; i++)
        {
            buttonsOff[i].SetActive(false);
            GameObject button = Instantiate(buttonPrefab, parent.transform);
            button.name = (i+1).ToString();
            button.transform.position = positions[i].position;
            button.GetComponentInChildren<TextMeshProUGUI>().text = (i+1).ToString();
            buttons.Add(button);
        }
    }
}
