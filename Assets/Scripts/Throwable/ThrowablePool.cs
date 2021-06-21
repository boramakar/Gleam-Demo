using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Sirenix.OdinInspector;

class ThrowablePool : SerializedMonoBehaviour
{
    [SerializeField]
    int initialPoolSize;
    [AssetsOnly]
    [PreviewField(100)]
    public GameObject throwablePrefab;

    List<IThrowable> pool;
    List<IThrowable> used;

    private void Awake()
    {
        pool = new List<IThrowable>();
        used = new List<IThrowable>();
    }

    public GameObject GetThrowable()
    {
        GameObject obj;
        if (pool.Count == 0)
        {
            obj = Instantiate(throwablePrefab, Vector3.zero, Quaternion.identity, transform);
            used.Add(obj.GetComponent<IThrowable>());
        }
        else
        {
            var elem = pool[0];
            used.Add(elem);
            pool.RemoveAt(0);
            obj = elem.GetGameObject();
        }

        obj.SetActive(true);
        return obj;
    }

    public void ReturnThrowable(GameObject throwable)
    {
        throwable.SetActive(false);
        int index = used.FindIndex(x => (x == throwable.GetComponent<IThrowable>()));
        pool.Add(used[index]);
        used.RemoveAt(index);
    }

    public void FillPool()
    {
        Debug.Log("Filling pool");
        pool.Clear();
        used.Clear();

        GameObject obj;
        for (int i = 0; i < initialPoolSize; i++)
        {
            obj = Instantiate(throwablePrefab, Vector3.zero, Quaternion.identity, transform);
            pool.Add(obj.GetComponent<IThrowable>());
            obj.SetActive(false);
        }
    }

    public void ResetPools()
    {
        while(used.Count > 0)
        {
            var usedThrowable = used[0];
            usedThrowable.GetGameObject().SetActive(false);
            used.Remove(usedThrowable);
            pool.Add(usedThrowable);
        }
    }
}