using UnityEngine;

namespace Assets.Project.Scripts.Infrastructure.EventBus.EventHandlers
{
    public interface IPlayerLookEventHandler : IGlobalSubscriber
    {
        void LookHandle(Vector2 value);
    }
}
