using Assets.Project.Scripts.Infrastructure.EventBus;
using Assets.Project.Scripts.Infrastructure.EventBus.EventHandlers.SubcriberGroups;
using UnityEngine;
using Zenject;

public class PlayerBehaviour : MonoBehaviour, IPlayerEventsSubcriber
{
    private IEventBus _eventBus;

    [Inject]
    private void Construct(IEventBus eventBus)
    {
        _eventBus = eventBus;

        _eventBus.Subscribe(this);
    }

    public void ChangeGravitationHandle()
    {
        Debug.Log("��������� ����������");
    }

    public void CloneHandle()
    {
        Debug.Log("������������");
    }

    public void JumpHandle()
    {
        Debug.Log("������");
    }

    public void LookHandle(Vector2 value)
    {
        Debug.Log("��������� ����� �������");
    }

    public void MoveHandle(Vector2 value)
    {
        Debug.Log("��������: " + value.ToString());
    }

    public void SwitchCloneHandle()
    {
        Debug.Log("���� �������");
    }
}
