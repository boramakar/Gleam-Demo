using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using TMPro;

class UIManager : Singleton<UIManager>
{
    IUISCript uiScript;

    private void Awake()
    {
        transform.GetChild(0).GetComponent<IUISCript>();
    }

    public void DisplayError(string title, string message)
    {
        uiScript.DisplayError(title, message);
    }

    public void DisplayLeaderboards(LeaderboardData data)
    {
        uiScript.DisplayLeaderboards(data);
    }
}
