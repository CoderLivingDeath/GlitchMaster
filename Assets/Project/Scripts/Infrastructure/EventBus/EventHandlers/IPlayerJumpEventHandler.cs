namespace Assets.Project.Scripts.Infrastructure.EventBus.EventHandlers
{
    public interface IPlayerJumpEventHandler : IGlobalSubscriber
    {
        void JumpHandle();
    }
}
