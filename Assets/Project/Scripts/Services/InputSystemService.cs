using Assets.Project.Scripts.Infrastructure.EventBus;
using Assets.Project.Scripts.Infrastructure.EventBus.EventHandlers;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemService
{
    private InputSystem_Actions _inputActions;
    private IEventBus _eventBus;

    public InputSystemService(InputSystem_Actions inputActions, IEventBus eventBus)
    {
        Debug.Log("123");

        _inputActions = inputActions;
        _eventBus = eventBus;

        Enable();
    }

    #region Actions

    private void MoveAction(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        _eventBus.TryRaiseEvent<IPlayerMoveEventHandler>(h => h.MoveHandle(value));
    }

    private void JumpAction(InputAction.CallbackContext context)
    {
        _eventBus.TryRaiseEvent<IPlayerJumpEventHandler>(h => h.JumpHandle());
    }

    private void LookAction(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        _eventBus.TryRaiseEvent<IPlayerLookEventHandler>(h => h.LookHandle(value));
    }

    private void CloneAction(InputAction.CallbackContext context)
    {
        _eventBus.TryRaiseEvent<IPlayerCloneEventHandler>(h => h.CloneHandle());
    }

    private void SwitchCloneAction(InputAction.CallbackContext context)
    {
        _eventBus.TryRaiseEvent<IPlayerSwithCloneEventHanlder>(h => h.SwitchCloneHandle());
    }

    private void ChangeGravitation(InputAction.CallbackContext context)
    {
        _eventBus.TryRaiseEvent<IPlayerChangeGravitationHandle>(h => h.ChangeGravitationHandle());
    }

    #endregion

    private void SubscribeInputActions()
    {
        _inputActions.Gameplay.Move.performed += MoveAction;
        _inputActions.Gameplay.Move.canceled += MoveAction;

        _inputActions.Gameplay.Jump.performed += JumpAction;

        _inputActions.Gameplay.Look.performed += LookAction;

        _inputActions.Gameplay.Clone.performed += CloneAction;

        _inputActions.Gameplay.CloneSwtich.performed += SwitchCloneAction;

        _inputActions.Gameplay.ChangeGravitation.performed += ChangeGravitation;
    }

    private void UnsubscribeInputActions()
    {
        _inputActions.Gameplay.Move.performed -= MoveAction;
        _inputActions.Gameplay.Move.canceled -= MoveAction;

        _inputActions.Gameplay.Jump.performed -= JumpAction;

        _inputActions.Gameplay.Look.performed -= LookAction;

        _inputActions.Gameplay.Clone.performed -= CloneAction;

        _inputActions.Gameplay.CloneSwtich.performed -= SwitchCloneAction;

        _inputActions.Gameplay.ChangeGravitation.performed -= ChangeGravitation;
    }

    public void Enable()
    {
        _inputActions.Enable();
        SubscribeInputActions();
    }

    public void Disable()
    {
        _inputActions.Disable();
        UnsubscribeInputActions();
    }
}
