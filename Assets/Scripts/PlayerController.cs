using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    
    public float jumpHeight;
    public float rotateSpeed;
    public Animator animator;
    public GameObject sprite;
    public GameObject gameManager;
    
    public void setStartedFlag(bool flag)
    {
        _startedFlag = flag;
    }
    public void StateTransition(int stateCode)
    {
        switch (stateCode){
            case 0:
                {
                    animator.SetInteger("StateCode", 0);
                    _rigbody.simulated = false;
                    break;
                }
            case 1:
                {
                    animator.SetInteger("StateCode", 1);
                    _rigbody.simulated = false;
                    break;
                }
            case 2:
                {
                    animator.SetInteger("StateCode", 1);
                    _rigbody.simulated = true;
                    break;
                } 
        }
        return;
                
                
        
    }

    // Start is called before the first frame update
    void Start()
    {
        _rigbody = this.GetComponent<Rigidbody2D>();
        _jump = new Vector2(0, jumpHeight);
        //animator.SetInteger("state", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!_startedFlag) return;
        if(Input.GetMouseButtonDown(0) && EventSystem.current.currentSelectedGameObject == null)
        {
            _rigbody.velocity = _jump;
        }
        sprite.transform.DORotateQuaternion(Quaternion.Euler(0, 0, _rigbody.velocity.y * rotateSpeed), 0.3f);
        

    }
     


    private Rigidbody2D _rigbody;
    private Vector2 _jump;
    private bool _startedFlag = false;
}
