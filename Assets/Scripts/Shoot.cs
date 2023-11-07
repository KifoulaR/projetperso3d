using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.Rendering;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] InputActionReference _shoot;
    [SerializeField] CursorPos _aimCursor;
    [SerializeField] float _fireRate;
    [SerializeField] GameObject _projectile;
    [SerializeField] Transform _spawnPoint;
    

    [SerializeField] UnityEvent _onShoot;

    [Header("Animator")]
    [SerializeField] Animator _animator;

    Coroutine ShootRoutine { get; set; }

    private void Start()
    {
        Debug.Log("start");
        _shoot.action.started += ShootStart;
        _shoot.action.performed += ShootStart;
        _shoot.action.canceled += ShootStop;
    }

    private void Update()
    {
        UpdateAnimator();
    }

    private void ShootStart(InputAction.CallbackContext obj)
    {
        Debug.Log("efefef");
        if (ShootRoutine != null) return;
        ShootRoutine = StartCoroutine(Shoot());
        IEnumerator Shoot()
        {
            var waiter = new WaitForSeconds(_fireRate);
            while (true)
            {
                _onShoot?.Invoke();
                GameObject p = Instantiate(_projectile, _spawnPoint.position, Quaternion.identity);
                p.GetComponent<FireDirection>().SetDirection(_aimCursor);
                yield return waiter;
            }
        }
    }

    private void ShootStop(InputAction.CallbackContext obj)
    {
        if (ShootRoutine == null) return;
        StopCoroutine(ShootRoutine);
        ShootRoutine = null;
    }
    private void UpdateAnimator()
    {
        if (_shoot.action.WasPressedThisFrame() ) 
        {
            _animator.SetBool("isAttacking", true);
        }
        else
        {
            _animator.SetBool("isAttacking", false);
        }
    }








}