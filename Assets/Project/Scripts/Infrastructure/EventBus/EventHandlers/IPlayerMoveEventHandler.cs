using UnityEngine;

namespace Assets.Project.Scripts.Infrastructure.EventBus.EventHandlers
{
    public interface IPlayerMoveEventHandler : IGlobalSubscriber
    {
        void MoveHandle(Vector2 value);
    }
}
