namespace Assets.Project.Scripts.Infrastructure.EventBus.EventHandlers
{
    public interface IPlayerCloneEventHandler : IGlobalSubscriber
    {
        void CloneHandle();
    }
}
