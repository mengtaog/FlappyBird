using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesManager : MonoBehaviour
{
    public GameObject prefab;
    public GameObject Pipes;
    public float generationGap;
    private bool _started = false;
    private float _timer;
    private List<GameObject> _pipes = new List<GameObject>();

    public void GenerateNewPipe()
    {
        GameObject newPipe = PipePool.instance.GetFromPool();
    }

    public void Stop()
    {
        //Time.timeScale = 0f;
    }

    public void Continue()
    {
        Time.timeScale = 1f;
    }

    private void Start()
    {
        _timer = generationGap;
    }

    public void setStarted(bool started)
    {
        _started = started;
    }
    
    private void Update()
    {
        if (!_started) return;
        _timer -= Time.deltaTime;
        if(_timer <= 0)
        {
            GenerateNewPipe();
            _timer = generationGap;
        }
        
    }
}
