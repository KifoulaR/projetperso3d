using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnEnemy : MonoBehaviour
{
    [SerializeField] int _damageAmount;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            Debug.Log($"aie {collision.gameObject.tag}");
                var lifes = collision.gameObject.GetComponent<Lifes>();
            
                lifes.TakeDamage(_damageAmount);
                Destroy(gameObject);
            
        }
            
    }
            
            
           

       


}