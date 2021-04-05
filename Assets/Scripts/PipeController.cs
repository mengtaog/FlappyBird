using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public float moveSpeed;
    private bool _started = true;
    public void randPos()
    {
        //[-0.74,4.31]
        float randY = Random.Range(-0.74f, 4.31f);
        transform.position = new Vector3(transform.position.x, randY, transform.position.z);
    }

    public void setStarted(bool started)
    {
        _started = started;
        
    }
    
    private void FixedUpdate()
    {
        if (!_started) return;
        transform.Translate(-0.03f * moveSpeed, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
    }


}
