using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDirection : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] int _damage;
    Vector3 _direction;

    internal void SetDirection(CursorPos aimCursor)
    {
        _direction = (transform.position - Camera.main.transform.position ).normalized;
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        #region 
        
        #endregion

        if (collision.TryGetComponent(out Lifes enemy) && enemy.IsPlayer == false)
        {
            Debug.Log("projectile hit");
            enemy.TakeDamage(_damage);

            Destroy(gameObject);
        }
    }

}