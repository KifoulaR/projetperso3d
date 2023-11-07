using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{

    [SerializeField] Rigidbody _rb;
    [SerializeField] float _speed;

    private void Update()
    {
        if (move.Instance == null) return;

        GameObject.Find("Player");


        var dir = (move.Instance.transform.position - transform.position).normalized;

        _rb.velocity = dir * _speed;

    }
}
