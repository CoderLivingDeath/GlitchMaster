using Assets.Project.Scripts.Infrastructure.EventBus;
using UnityEngine;
using Zenject;

public class ProjectContextInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<SceneLoaderWithZenject>().AsSingle();
        Container.BindInterfacesAndSelfTo<EventBus>().AsSingle();
        Container.BindInterfacesAndSelfTo<InputSystem_Actions>().AsSingle();
        Container.BindInterfacesAndSelfTo<InputSystemService>().AsSingle().NonLazy();
    }
}
