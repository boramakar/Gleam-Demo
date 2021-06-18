using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

class NetworkManager : Singleton<NetworkManager>
{
    [SerializeField]
    string api;
    [SerializeField]
    string getProfileEndpoint = "user/get/profile";
    [SerializeField]
    string editProfileEndpoint = "user/edit/profile";
    [SerializeField]
    string setPointEndpoint = "point/set";
    [SerializeField]
    string getListEndpoint = "point/get";

    string deviceID;

    private void Awake()
    {
        deviceID = SystemInfo.deviceUniqueIdentifier;
    }

    public void Init()
    {
        StartCoroutine(_Init());
    }

    IEnumerator _Init()
    {
        UnityWebRequest request = UnityWebRequest.Get(api + getProfileEndpoint + "?device_token=" + deviceID);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            // Show results as text
            Debug.Log(request.downloadHandler.text);

            //Handle response - nothing to handle
        }
    }

    public void EditProfile(string? newName, string? newEmail, string? newGender)
    {
        StartCoroutine(_EditProfile(newName, newEmail, newGender));
    }

    IEnumerator _EditProfile(string? newName, string? newEmail, string? newGender)
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("device_token=" + deviceID));
        if (newName != null)
            formData.Add(new MultipartFormDataSection("name=" + newName));
        if (newEmail != null)
            formData.Add(new MultipartFormDataSection("email=" + newEmail));
        if (newGender != null)
            formData.Add(new MultipartFormDataSection("gender=" + newGender));

        UnityWebRequest request = UnityWebRequest.Post(api + editProfileEndpoint, formData);

        yield return request.SendWebRequest();
    }

    public void SubmitScore(int point)
    {
        StartCoroutine(_SubmitScore(point));
    }

    IEnumerator _SubmitScore(int? point)
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("device_token=" + deviceID));
        if (point != null)
            formData.Add(new MultipartFormDataSection("point=" + point));

        UnityWebRequest request = UnityWebRequest.Post(api + editProfileEndpoint, formData);

        yield return request.SendWebRequest();
    }

    public void GetLeaderboard()
    {
        StartCoroutine(_GetLeaderboard());
    }

    IEnumerator _GetLeaderboard()
    {
        UnityWebRequest request = UnityWebRequest.Get(api + getProfileEndpoint + "?device_token=" + deviceID);
        yield return request.SendWebRequest();
    }
}
