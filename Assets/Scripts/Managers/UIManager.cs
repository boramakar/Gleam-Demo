using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using TMPro;

class UIManager : Singleton<UIManager>
{
    [SerializeField]
    IUISCript uiScript;
    GameManager gameManager;
    NetworkManager networkManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;
        networkManager = NetworkManager.Instance;
        transform.GetChild(0).GetComponent<IUISCript>();
        gameManager.RestartEvent += Restart;
    }

    public void DisplayError(string title, string message)
    {
        uiScript.DisplayError(title, message);
    }

    public void DisplayLeaderboards(LeaderboardData data)
    {
        uiScript.DisplayLeaderboards(data);
    }

    void Restart()
    {
        uiScript.Restart();
    }
}
