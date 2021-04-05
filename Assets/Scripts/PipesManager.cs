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
    // Start is called before the first frame update
    public void CreateSinglePipe()
    {
        GameObject newPipe = GameObject.Instantiate(prefab, Pipes.transform);
        newPipe.GetComponent<PipeController>().randPos();
        //Destroy(newPipe, 5);
        _pipes.Add(newPipe);
    }

    public void Stop()
    {
        _started = false;
        foreach (var pipe in _pipes)
        {
            pipe.GetComponent<PipeController>().setStarted(false);
            
        }
    }

    public void Continue()
    {
        _started = true;
        foreach (var pipe in _pipes)
        {
            pipe.GetComponent<PipeController>().setStarted(true);
            
        }
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
            CreateSinglePipe();
            _timer = generationGap;
        }
        
    }
}
