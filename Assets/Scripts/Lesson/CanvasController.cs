using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject panelRoot;

    [SerializeField] private GameObject[] emptyStars;

    [SerializeField] private GameObject[] fullStars;
    [SerializeField] private Transform[] points;
    private Transform[] shootingStars;
    private float timer;
    
    void Start()
    {
        foreach (var fullStar in fullStars)
        {
            fullStar.SetActive(false);
        }
        panelRoot.SetActive(false);
    }
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            panelRoot.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivateStars(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivateStars(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActivateStars(3);
        }
        if(shootingStars ==null||timer>1f)
            return;
        for (var i = 0; i < shootingStars.Length; i++)

        {

            shootingStars[i].position = Vector3.Lerp(points[i].position, emptyStars[i].transform.position, timer);

        }

        timer += Time.deltaTime;

        if (timer < 1f)

            return;
        var amount = shootingStars.Length;
        for (var i = 0; i < emptyStars.Length; i++)

        {

            emptyStars[i].SetActive(i >= amount);

        }


        shootingStars = null;
    }

    private void ActivateStars(int amount)
    {
        for (int i = 0; i < emptyStars.Length; i++)
        {
            fullStars[i].SetActive(i < amount);
        }

        if (amount == 0)
        {
            return;
        }

        shootingStars = new Transform[amount];
        for (int i = 0; i < amount; i++)
        {
            shootingStars[i] = fullStars[i].transform;
        }
    }
}
