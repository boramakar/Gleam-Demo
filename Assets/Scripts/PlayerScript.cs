using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerScript : SerializedMonoBehaviour
{
    [TabGroup("Tabs", "Values")]
    [TitleGroup("Tabs/Values/Movement")]
    [SerializeField]
    float maxMovementPerFrame;

    [TitleGroup("Tabs/Values/Preview")]
    [SerializeField]
    float zoomInDuration;
    [TitleGroup("Tabs/Values/Preview")]
    [SerializeField]
    float waitAfterThrowDuration;

    GameManager gameManager;
    InputManager inputManager;
    bool isPressed;
    bool canShoot;

    GameObject objectPreview;
    IThrowable previewScript;
    ThrowableData currentData;

    private void Awake()
    {
        gameManager = GameManager.Instance;
        inputManager = InputManager.Instance;
        objectPreview = Instantiate(gameManager.GetPreview(), transform);
        previewScript = objectPreview.GetComponent<IThrowable>();
        previewScript.LockTransformations();
        currentData = gameManager.GetThrowableData();
        UpdateThrowable(currentData);
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    void OnPress()
    {
        isPressed = true;
    }

    void OnRelease()
    {
        isPressed = false;
        if (canShoot)
            ShootThrowable();
    }

    void FirstRelease()
    {
        gameManager.StartTimer();
        inputManager.UnsubscribeRelease(FirstRelease);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            var inputDelta = inputManager.GetDelta();
            transform.Translate(new Vector3(inputDelta.x * maxMovementPerFrame * Time.deltaTime, 0, 0));
        }
    }

    void ShootThrowable()
    {
        canShoot = false;
        objectPreview.SetActive(false);
        var obj = gameManager.GetThrowable();
        obj.transform.position = transform.position;
        obj.transform.rotation = Quaternion.identity;
        var script = obj.GetComponent<IThrowable>();
        script.UpdateData(currentData);
        script.Throw();
        StartCoroutine(PrepareNextThrowable());
    }

    IEnumerator PrepareNextThrowable()
    {
        yield return new WaitForSeconds(waitAfterThrowDuration);
        UpdateThrowable(GameManager.Instance.GetThrowableData());
    }

    void UpdateThrowable(ThrowableData data)
    {
        if (currentData.prefab != data.prefab)
        {
            Destroy(objectPreview);
            objectPreview = Instantiate(data.prefab, transform.position, Quaternion.identity, transform);
            previewScript = objectPreview.GetComponent<IThrowable>();
        }
        previewScript.UpdateData(data);
        currentData = data;
        ShowPreview();
    }

    void ShowPreview()
    {
        StartCoroutine(PreviewZoomIn());
    }

    IEnumerator PreviewZoomIn()
    {
        objectPreview.SetActive(true);
        float elapsedTime = 0f;
        float duration = zoomInDuration;
        float progress;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            progress = elapsedTime / duration;
            progress *= progress;
            progress = Mathf.Clamp01(progress);
            objectPreview.transform.localScale = Vector3.one * progress;
            yield return null;
        }
        canShoot = true;
    }

    void EndSession()
    {
        inputManager.UnsubscribePress(OnPress);
        inputManager.UnsubscribePress(OnRelease);
    }

    private void Init()
    {
        inputManager.SubscribePress(OnPress);
        inputManager.SubscribeRelease(OnRelease);
        inputManager.SubscribeRelease(FirstRelease);
        gameManager.SessionEndEvent += EndSession;
        gameManager.RestartEvent += Restart;
    }

    public void Restart()
    {
        Init();
    }
}
