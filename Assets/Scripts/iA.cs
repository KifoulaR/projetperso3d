using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using static UnityEditor.Experimental.GraphView.GraphView;

public class iA : MonoBehaviour
{
    #region
    [SerializeField] GameObject _mage;

    [Header("IA")]
    [SerializeField] InputActionReference _move;
    [SerializeField] InputActionReference _walk;
    [SerializeField] InputActionReference _attack;
    [SerializeField] GroundCh _Ground;
    [SerializeField] Rigidbody _rb;
    [SerializeField] Lifes _lifes;
    

    [Header("IA Animation")]
    [SerializeField] Animator _animator;

    [Header("IA Audio")]
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _audioClip;

    [SerializeField] int _damage;
    public int Damage { get => _damage; set => _damage = value; }

    Vector3 _dir;
    

    #endregion
    
    #region Enumerator

    enum State
    {
        Idle,
        Aggro,
        Walk,
        Attack,
        Death,
    }
        
    #region BeforeStart
    private State _currentState = State.Idle;
    private void Reset()
    {
        _Ground = transform.parent.GetComponentInChildren<GroundCh>();
        _animator = transform.parent.GetComponentInChildren<Animator>();
    }
    #endregion


    #endregion

    #region UnityLifeCycle
    private void Start()
    {
        _mage = GameObject.Find("Player");
        Collision collision = new Collision();
    }
    void OnStateEnter()
    {
        switch (_currentState)
        {
            case State.Idle:
                _animator.SetBool("isWalking", false);
                _animator.SetBool("isAttacking", false);
               
                break; 
            case State.Attack:
                break;
            case State.Walk:
                break;
                
            case State.Death:
                _animator.SetTrigger("Death");
                break;
            default:
                break;
        }
            
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ennemy"))
        {
            var damage = other.gameObject.GetComponent<attack>();

            _lifes.TakeDamage(damage.Damage);
        }
        else
        {
            return;
        }
    }
    void OnStateUpdate()
    {
        switch(_currentState) 
        {
            case State.Idle:
                if(_Ground.IsGrounded == true)
                {
                if(GameObject.Find("Player"))
                    {
                        TransitionToState(State.Walk);
                    }    
                    
                }
                break;
            case State.Walk:
                if(_Ground.IsGrounded == true)
                {
                    
                }
                break;
            case State.Attack:
                break;
            case State.Death:
                break;
        }
                
           
    }


    private void TransitionToState(object walk)
    {
        throw new NotImplementedException();
    }

    void OnStateExit()
    {
        switch(_currentState)
            {
            case State.Idle:
                break;
            case State.Walk:
                break;
            case State.Attack:
                break;
            case State.Death:
                break;
        }
           
    }
   
        
    
    #endregion
   
    
     
}
                   

    


    




                
