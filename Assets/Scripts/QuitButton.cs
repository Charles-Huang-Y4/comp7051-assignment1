using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuitButton : MonoBehaviour
{
    private InputActions _controls;
    private InputAction ui;
    // Start is called before the first frame update
    void Awake()
    {
        _controls = new InputActions();

    }

    public void OnEnable()
    {
        this.enabled = true;
        ui = _controls.UI.Quit;
        _controls.UI.Quit.performed += DoQuit;
        ui.Enable();
    }

    private void DoQuit(InputAction.CallbackContext obj)
    {
        Debug.Log("Load Main menu");
        GetComponent<LoadLevel>().LoadTheLevel("Main Menu");
    }

    public void OnDisable()
    {
        ui.Disable();
        _controls.UI.Quit.Disable();
    }
}
