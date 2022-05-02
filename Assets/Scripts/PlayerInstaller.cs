using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Player playerPrefab;
    [SerializeField] private Transform playerPrefabPosition;
    public override void InstallBindings()
    {
        var playerInstance = Container.InstantiatePrefabForComponent<Player>
            (playerPrefab, playerPrefabPosition.position, Quaternion.identity, null);

        Container.Bind<Player>().FromInstance(playerInstance).AsCached().NonLazy();
    }
}