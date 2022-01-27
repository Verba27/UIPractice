using System;
using UnityEngine;
using UnityEngine.UI;

public class TestButton : MonoBehaviour
{
    [SerializeField] private Button button;

    private void Start()
    {
        button.onClick.AddListener(TestInside);
    }

    public void Test()
    {
        print("Button click");
    }

    private void TestInside()
    {
        print("Button click INSIDE");
        button.onClick.RemoveAllListeners();
    }
}
