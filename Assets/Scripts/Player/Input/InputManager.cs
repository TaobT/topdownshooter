using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Vector2 MoveVector { private set; get; }
    public static Vector2 MousePos { private set; get; }

    #region Actions
    public static Action OnRightClickStart;
    public static Action OnRightClickPerformed;
    public static Action OnRightClickCanceled;

    public static Action OnLeftClickStart;
    public static Action OnLeftClickPerformed;
    public static Action OnLeftClickCanceled;

    public static Action OnUseStart;
    public static Action OnUsePerformed;
    public static Action OnUseCanceled;
    #endregion

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        MoveVector = context.ReadValue<Vector2>();
    }

    public void OnMousePositionInput(InputAction.CallbackContext context)
    {
        MousePos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }

    public void OnUseInput(InputAction.CallbackContext context)
    {
        if (context.started) OnUseStart?.Invoke();
        else if (context.performed) OnUsePerformed?.Invoke();
        else if (context.canceled) OnUseCanceled?.Invoke();
    }

    public void OnLeftClickInput(InputAction.CallbackContext context)
    {
        if (context.started) OnLeftClickStart?.Invoke();
        else if (context.performed) OnLeftClickPerformed?.Invoke();
        else if (context.canceled) OnLeftClickCanceled?.Invoke();
    }

    public void OnRightClickInput(InputAction.CallbackContext context)
    {
        if (context.started) OnRightClickStart?.Invoke();
        else if (context.performed) OnRightClickPerformed?.Invoke();
        else if (context.canceled) OnRightClickCanceled?.Invoke();
    }
}