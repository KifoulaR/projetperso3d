using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookCursor : MonoBehaviour
{

    [SerializeField] Transform _cursor;

    private void Update()
    {

        var direction = _cursor.position - transform.position;
        
        transform.rotation = Quaternion.LookRotation(transform.forward, direction);

    }


}