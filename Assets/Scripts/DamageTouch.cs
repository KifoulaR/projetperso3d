using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTouch : MonoBehaviour
{
    [SerializeField] int _damageAmount;

    private void OnCollisionEnter (Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            var lifes = collision.gameObject.GetComponent<Lifes>();
            lifes.TakeDamage(_damageAmount);
            Destroy(gameObject);
        }

        //if (collision.gameObject.TryGetComponent(out Lifes pc) && pc.IsPlayer)
        {

           // pc.TakeDamage(_damageAmount);
           //Destroy(gameObject);

        }


    }
}