using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public Vector3 startPos;
    public float speed;
    public float restartPos;

    private bool _stoped = false;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    public void Stop()
    {
        _stoped = true;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (_stoped) return;
        if(transform.position.x < -restartPos)
        {
            transform.position = startPos;
        }
        transform.position = new Vector3(transform.position.x + speed * -0.01f, transform.position.y, transform.position.z); 
    }
}
