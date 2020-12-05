using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : ScriptableObject, GameInput.IMenuActions, GameInput.IGameplayActions, GameInput.IDialogueActions
{
    // Gameplay
    public event UnityAction<Vector2> moveEvent;
    public event UnityAction<Vector2> cameraMoveEvent;
    public event UnityAction attackEvent;
    public event UnityAction jumpEvent;
    public event UnityAction jumpCanceledEvent;
    public event UnityAction pauseEvent;
    public event UnityAction interactEvent; // Used to talk, pickup objects, interact with tools/items/people

    // Menu & Dialogue
    public event UnityAction onMoveSelectionEvent = delegate { };
    public event UnityAction onConfirmSelectionEvent = delegate { };
    public event UnityAction onCancelSelectionEvent = delegate { };

    private GameInput gameInput;

    private void OnEnable()
    {
        if (gameInput == null)
        {
            gameInput = new GameInput();
            gameInput.Gameplay.SetCallbacks(this);
            gameInput.Dialogue.SetCallbacks(this);
            gameInput.Menu.SetCallbacks(this);
        }
        EnableGameplayInput();
    }

    private void OnDisable()
    {
        DisableAllInput();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        cameraMoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            attackEvent?.Invoke();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            interactEvent?.Invoke();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            jumpEvent?.Invoke();

        if (context.phase == InputActionPhase.Canceled)
            jumpCanceledEvent?.Invoke();
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            pauseEvent?.Invoke();
    }

    public void OnMoveSelection(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            onMoveSelectionEvent?.Invoke();
    }

    public void OnConfirm(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            onConfirmSelectionEvent?.Invoke();
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            onCancelSelectionEvent?.Invoke();
    }

    public void EnableDialogueInput()
    {
        gameInput.Gameplay.Disable();
        gameInput.Dialogue.Enable();
        gameInput.Menu.Disable();
    }

    public void EnableGameplayInput()
    {
        gameInput.Gameplay.Enable();
        gameInput.Dialogue.Disable();
        gameInput.Menu.Disable();
    }

    public void EnableMenuInput()
    {
        gameInput.Gameplay.Disable();
        gameInput.Dialogue.Disable();
        gameInput.Menu.Enable();
    }

    public void DisableAllInput()
    {
        gameInput.Gameplay.Disable();
        gameInput.Dialogue.Disable();
        gameInput.Menu.Disable();
    }
}
