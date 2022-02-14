using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Vector2 moveVector { private set; get; }
    public static Vector2 mousePos { private set; get; }

    #region Actions
    public static Action OnRightClickStart;
    public static Action OnRightClickPerformed;
    public static Action OnRightClickCanceled;
    #endregion

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    public void OnMousePositionInput(InputAction.CallbackContext context)
    {
        mousePos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }

    public void OnRightClickInput(InputAction.CallbackContext context)
    {

    }
}