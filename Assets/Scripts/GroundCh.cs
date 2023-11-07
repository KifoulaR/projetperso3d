using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundCh : MonoBehaviour
{
    [SerializeField] bool _isGrounded;
    [SerializeField] int _groundContactNumber;
    [SerializeField] UnityEvent _onGrounded;

    public bool IsGrounded { get => _isGrounded; }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (_isGrounded == false && Time.time > 1f)
            {
                _onGrounded.Invoke();
            }

            _isGrounded = true;
            _groundContactNumber++;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _groundContactNumber--;
            if (_groundContactNumber <= 0)
            {
                _isGrounded = false;
            }
        }


    }
}
