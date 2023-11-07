using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class interraction : MonoBehaviour
{

    [SerializeField] Camera _cam;
    [SerializeField] InputActionReference _interaction;


    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        
        Vector2 centerScreen = new Vector2(Screen.width / 2, Screen.height / 2);

        
        Ray cameraRay = _cam.ScreenPointToRay(centerScreen);

        
        Debug.DrawRay(cameraRay.origin, cameraRay.direction, Color.red);
        if (Physics.Raycast(cameraRay, out RaycastHit hit, 2f))
        {
            Debug.Log($"touché {hit.collider.name}!");
            hit.collider.GetComponent<MeshRenderer>()?.sharedMaterial.SetFloat("_OutlineEnabled", 1);

           
            if (_interaction.action.WasPressedThisFrame())
            {
                if (hit.collider.TryGetComponent(out IInteractable usable))
                {
                    usable.Use();
                }
            }
        }
    }

}