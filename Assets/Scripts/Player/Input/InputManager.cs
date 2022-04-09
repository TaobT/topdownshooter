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

    public static Action OnReloadStart;
    public static Action OnReloadPerformed;
    public static Action OnReloadCanceled;
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

    public void OnReloadInput(InputAction.CallbackContext context)
    {
        if (context.started) OnReloadStart?.Invoke();
        else if (context.performed) OnReloadPerformed?.Invoke();
        else if (context.canceled) OnReloadCanceled?.Invoke();
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