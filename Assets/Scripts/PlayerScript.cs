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
        gameManager.SessionEndEvent += EndSession;
        gameManager.RestartEvent += Restart;
    }

    private void Start()
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
        Debug.Log("FirstRelease");
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
            //This is hardcoded based on box, needs to be calculated as (platform.meshCollider.Bounds.extents.x - platform.boxCollider.Bounds.size.x - throwable.meshCollider.Bounds.extents.x)
            //Not too hard to fix but dealing with potential issues just to fix this is too much work for this project given my time limits
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.25f, 3.25f), transform.position.y, transform.position.z);
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
        inputManager.UnsubscribeRelease(OnRelease);
    }

    private void Init()
    {
        currentData = gameManager.GetThrowableData();
        inputManager.SubscribePress(OnPress);
        inputManager.SubscribeRelease(OnRelease);
        inputManager.SubscribeRelease(FirstRelease);
        UpdateThrowable(currentData);
    }

    public void Restart()
    {
        Init();
    }
}
