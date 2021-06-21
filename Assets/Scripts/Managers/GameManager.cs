using System;
using System.Collections;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.SceneManagement;

class GameManager : Singleton<GameManager>
{
    public event Action SessionEndEvent;
    public event Action RestartEvent;

    [BoxGroup("Parameters")]
    public float sessionDuration = 20;
    [BoxGroup("Parameters")]
    public int startingValue = 2;

    [BoxGroup("References")]
    public IThrowableGenerator throwableGenerator;
    [BoxGroup("References")]
    public ThrowablePool throwablePool;

    [BoxGroup("Forces")]
    public float throwForce;
    [BoxGroup("Forces")]
    public Vector3 forceOffset;
    [BoxGroup("Forces")]
    public float jumpForce;
    [BoxGroup("Forces")]
    public float magnetForce;
    [BoxGroup("Forces")]
    public float magnetRadius;

    //InputManager inputManager; //Doesn't require initialization
    NetworkManager networkManager;
    UIManager uiManager;

    int maxProducedValue;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        //inputManager = InputManager.Instance;
        networkManager = NetworkManager.Instance;
        uiManager = UIManager.Instance;
        maxProducedValue = startingValue;
    }

    private void Start()
    {
        networkManager.Init(InitializeSystems, DisplayNetworkError);
    }

    void InitializeSystems()
    {
        //Populate Pool
        throwablePool.FillPool();
        //Move to game after everything is ready
        MoveToGameScene();
    }

    void DisplayNetworkError()
    {
        Debug.Log("Network error");
        uiManager.DisplayError("Network Error", "Could not connect to the server.");
    }

    void MoveToGameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public ThrowableData GetThrowableData()
    {
        return throwableGenerator.GenerateThrowable(startingValue, maxProducedValue);
    }

    public GameObject GetThrowable()
    {
        return throwablePool.GetThrowable();
    }

    public void ReturnThrowable(GameObject throwable)
    {
        throwablePool.ReturnThrowable(throwable);
    }

    public void UpdateMaxProducedValue(int value)
    {
        if (value > maxProducedValue)
            maxProducedValue = value;
    }

    public GameObject GetPreview()
    {
        return throwablePool.throwablePrefab;
    }

    public void StartTimer()
    {
        StartCoroutine(SessionTimer());
    }

    IEnumerator SessionTimer()
    {
        yield return new WaitForSeconds(sessionDuration);
        EndSession();
    }

    void EndSession()
    {
        if (SessionEndEvent != null)
            SessionEndEvent();
    }

    public void Restart()
    {
        if(RestartEvent != null)
            RestartEvent();
    }
}
