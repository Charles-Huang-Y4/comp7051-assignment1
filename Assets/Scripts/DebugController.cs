using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DebugController : MonoBehaviour
{
    bool showConsole;
    string input;
    private InputActions _UIActions;
    private InputAction _openDebug;
    private InputAction _closeDebug;
    private InputAction _enterDebug;

    public static DebugCommand KILL_PADDLES;
    public static DebugCommand BG_COLOR_RED;

    public List<object> commandList;

    void Awake()
    {
        _UIActions = new InputActions();

        KILL_PADDLES = new DebugCommand("kill_paddles", "Removes all paddles from scene.", "kill_paddles", () =>
        {
            GameManager.Instance.DeleteAllPaddles();
        });

        BG_COLOR_RED = new DebugCommand("bg_color_red", "Change bg color to red.", "bg_color_red", () =>
        {
            GameObject field = GameObject.Find("Floor");
            field.GetComponent<Renderer>().material.color = new Color(0.78f, 0, 0, 1);
        });

        commandList = new List<object>
        {
            KILL_PADDLES,
            BG_COLOR_RED
        };
    }

    public void OnEnable()
    {
        this.enabled = true;
        _openDebug = _UIActions.UI.OpenDebug;
        _closeDebug = _UIActions.UI.CloseDebug;
        _enterDebug = _UIActions.UI.Enter;
        _UIActions.UI.OpenDebug.performed += OnOpenDebug;
        _UIActions.UI.CloseDebug.performed += OnCloseDebug;
        _UIActions.UI.Enter.performed += OnReturn;
        _openDebug.Enable();
        _closeDebug.Enable();
        _enterDebug.Enable();
    }

    public void OnOpenDebug(InputAction.CallbackContext obj)
    {
        showConsole = true;
    }

    public void OnCloseDebug(InputAction.CallbackContext obj)
    {
        showConsole = false;
    }

    public void OnReturn(InputAction.CallbackContext obj)
    {
        if (showConsole)
        {
            HandleInput();
            input = "";
        }
    }

    public void OnDisable()
    {
        _openDebug.Disable();
        _closeDebug.Disable();
        _enterDebug.Disable();
        _UIActions.UI.OpenDebug.Disable();
        _UIActions.UI.CloseDebug.Disable();
        _UIActions.UI.Enter.Disable();
    }

    private void OnGUI()
    {
        if (!showConsole) { return; }
        float y = 0f;
        GUI.Box(new Rect(0, y, Screen.width, 30), "");
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);
    }

    private void HandleInput()
    {
        for(int i=0; i<commandList.Count; i++)
        {
            DebugCommandBase commandBase = commandList[i] as DebugCommandBase;

            if (input.Contains(commandBase.commandID))
            {
                if(commandList[i] as DebugCommand != null)
                {
                    (commandList[i] as DebugCommand).Invoke();
                }
            }
        }
    }
}
