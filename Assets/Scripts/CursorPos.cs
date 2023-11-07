using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorPos : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] InputActionReference _cursorPos;

    private void Update()
    {
        var c = _cursorPos.action.ReadValue<Vector2>();
        Debug.Log(c);
        Vector3 newPos = _camera.ScreenToWorldPoint(c);
        transform.position = newPos;
    }

}