using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public float moveSpeed;
    public float lifeCycle;

    private float _timer;
    private Transform _parentTransform;
    //private bool _moving = true;

    private void Awake()
    {
        //_parentTransform = gameObject.transform.parent;
        //ResetPos();
    }


    private void OnEnable()
    {
        _parentTransform = gameObject.transform.parent;
        _timer = lifeCycle;
        ResetPos();
        //_moving = true;
    }
    public void ResetPos()
    {
        //[-0.74,4.31]
        
        float randY = Random.Range(-0.74f, 4.31f);
        transform.position = new Vector3(_parentTransform.position.x, randY, _parentTransform.position.z);
    }
    
    private void FixedUpdate()
    {
        _timer -= Time.fixedDeltaTime;
        if(_timer < 0)
        {
            //gameObject.SetActive(false);
            PipePool.instance.ReturnPool(this.gameObject);
        }
        transform.Translate(-0.03f * moveSpeed, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
    }


}
