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
        Debug.Log(data);
        background.SetActive(true);
        leaderboardDisplay.SetActive(true);
        errorDisplay.SetActive(false);
        for(int i = 0; i < 10; i++)
        {
            globalLeaderboardContent.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = "#" + data.users_all_data[i].sort;
            globalLeaderboardContent.GetChild(i).GetChild(1).GetComponent<TextMeshProUGUI>().text = data.users_all_data[i].name;
            globalLeaderboardContent.GetChild(i).GetChild(2).GetComponent<TextMeshProUGUI>().text = data.users_all_data[i].point.ToString();
            dailyLeaderboardContent.GetChild(i).GetChild(0).GetComponent<TextMeshProUGUI>().text = "#" + data.users_daily_data[i].sort;
            dailyLeaderboardContent.GetChild(i).GetChild(1).GetComponent<TextMeshProUGUI>().text = data.users_daily_data[i].name;
            dailyLeaderboardContent.GetChild(i).GetChild(2).GetComponent<TextMeshProUGUI>().text = data.users_daily_data[i].point.ToString();
        }

        globalLeaderboardContent.GetChild(10).GetChild(0).GetComponent<TextMeshProUGUI>().text = "#" + data.current_user.general_sort;
        globalLeaderboardContent.GetChild(10).GetChild(1).GetComponent<TextMeshProUGUI>().text = data.current_user.name;
        globalLeaderboardContent.GetChild(10).GetChild(2).GetComponent<TextMeshProUGUI>().text = data.current_user.point.ToString();
        dailyLeaderboardContent.GetChild(10).GetChild(0).GetComponent<TextMeshProUGUI>().text = "#" + data.current_user.daily_sort;
        dailyLeaderboardContent.GetChild(10).GetChild(1).GetComponent<TextMeshProUGUI>().text = data.current_user.name;
        dailyLeaderboardContent.GetChild(10).GetChild(2).GetComponent<TextMeshProUGUI>().text = data.current_user.monthly_point.ToString();

    }

    public void DisplayError(string title, string message)
    {
        errorTitle.text = title;
        errorMessage.text = message;
        errorDisplay.SetActive(true);
    }

    public void Restart()
    {
        errorDisplay.SetActive(false);
        leaderboardDisplay.SetActive(false);
        background.SetActive(false);
    }
}

