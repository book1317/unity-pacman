using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public FoodManager theFoodManager;
    [SerializeField] private GameObject WinText;
    void Start()
    {

    }

    void Update()
    {

    }

    public void CheckWin()
    {
        if (theFoodManager.allFood.Count <= 0)
            Win();
    }

    void Win()
    {
        WinText.SetActive(true);
        Time.timeScale = 0;
    }
}
