using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePool : MonoBehaviour
{
    public static PipePool instance;
    public float pipeNums;
    public GameObject prefab;
    private int _index;
    private Queue<GameObject> _pipePool;
    
    private void Awake()
    {
        _pipePool = new Queue<GameObject>();
        instance = this;
        FillPool();
    }

    public void FillPool()
    {
        for (int i = 0; i < pipeNums; ++i)
        {
            GameObject pipe = Instantiate(prefab, transform);
            
            ReturnPool(pipe);
        }
    }

    public void ReturnPool(GameObject obj)
    {
        obj.SetActive(false);
        _pipePool.Enqueue(obj);
    }

    public GameObject GetFromPool()
    {
        if (_pipePool.Count == 0) FillPool();
        GameObject obj = _pipePool.Dequeue();
        obj.SetActive(true);
        return obj;
    }


}
