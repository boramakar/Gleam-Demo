using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using TMPro;

class UIScript : SerializedMonoBehaviour, IUISCript
{
    [SerializeField]
    GameObject errorDisplay;
    [SerializeField]
    TextMeshProUGUI errorTitle;
    [SerializeField]
    TextMeshProUGUI errorMessage;
    [SerializeField]
    GameObject leaderboardDisplay;
    [SerializeField]
    Transform globalLeaderboardContent;
    [SerializeField]
    Transform dailyLeaderboardContent;
    [SerializeField]
    GameObject background;

    public void DisplayLeaderboards(LeaderboardData data)
    {
        for(int i = 0; i < 10; i++)
        {
            globalLeaderboardContent.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = "#" + data.globalList[i].rank;
            globalLeaderboardContent.GetChild(i).GetChild(1).GetComponent<TextMeshProUGUI>().text = data.globalList[i].points.ToString();
            globalLeaderboardContent.GetChild(i).GetChild(2).GetComponent<TextMeshProUGUI>().text = data.globalList[i].name;
            dailyLeaderboardContent.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = "#" + data.dailyList[i].rank;
            dailyLeaderboardContent.GetChild(i).GetChild(1).GetComponent<TextMeshProUGUI>().text = data.dailyList[i].points.ToString();
            dailyLeaderboardContent.GetChild(i).GetChild(2).GetComponent<TextMeshProUGUI>().text = data.dailyList[i].name;
        }

        globalLeaderboardContent.GetChild(10).GetChild(0).GetComponent<TextMeshProUGUI>().text = "#" + data.globalRank;
        globalLeaderboardContent.GetChild(10).GetChild(1).GetComponent<TextMeshProUGUI>().text = data.globalPoints.ToString();
        globalLeaderboardContent.GetChild(10).GetChild(2).GetComponent<TextMeshProUGUI>().text = "YOU";
        dailyLeaderboardContent.GetChild(10).GetChild(0).GetComponent<TextMeshProUGUI>().text = "#" + data.dailyRank;
        dailyLeaderboardContent.GetChild(10).GetChild(1).GetComponent<TextMeshProUGUI>().text = data.dailyPoints.ToString();
        dailyLeaderboardContent.GetChild(10).GetChild(2).GetComponent<TextMeshProUGUI>().text = "YOU";

    }

    public void DisplayError(string title, string message)
    {
        errorTitle.text = title;
        errorMessage.text = message;
        errorDisplay.SetActive(true);
    }
}

