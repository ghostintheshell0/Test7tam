using Leopotam.Ecs;
using UnityEngine;
using LeopotamGroup.Globals;

namespace Test7tam
{
    sealed class GameStartup : MonoBehaviour
	{
		[SerializeField]
		private LevelData levelData = default;

        private EcsWorld _world = default;
        private EcsSystems _systems = default;

        private void Start ()
		{
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif

			Service<LevelData>.Set(levelData);
			Service<EcsWorld>.Set(_world);

			_systems
				.Add(new SpawnPlayerSystem())
				.Add(new MovingSystem())
                .Init ();
        }

        private void Update ()
		{
            _systems?.Run ();
        }

        private void OnDestroy ()
		{
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}