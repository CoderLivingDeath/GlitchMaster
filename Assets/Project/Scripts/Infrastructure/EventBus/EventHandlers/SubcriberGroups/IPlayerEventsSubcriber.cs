namespace Assets.Project.Scripts.Infrastructure.EventBus.EventHandlers.SubcriberGroups
{
    public interface IPlayerEventsSubcriber : IPlayerMoveEventHandler, IPlayerLookEventHandler, IPlayerJumpEventHandler, IPlayerCloneEventHandler, IPlayerSwithCloneEventHanlder, IPlayerChangeGravitationHandle
    {

    }
}
