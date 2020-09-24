using Leopotam.Ecs;
using UnityEngine;
using LeopotamGroup.Globals;
using System.Collections;

namespace Test7tam
{
    sealed class GameStartup : MonoBehaviour
	{
		[SerializeField]
		private LevelData _levelData = default;

        private EcsWorld _world = default;
        private EcsSystems _systems = default;

        private IEnumerator Start ()
		{
			yield return null;
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif

			Service<LevelData>.Set(_levelData);
			Service<EcsWorld>.Set(_world);
			Service<MapData>.Set(new MapData());


			_systems
				.Add(new SpawnPlayerSystem())
				.Add(new MovingSystem())
				.Add(new UserInputSystem())
				.Add(new SpawnBombSystem())

				.OneFrame<SpawnBombCommand>()

                .Init ();
        }

        private void Update ()
		{
            _systems?.Run();
        }

        private void OnDestroy ()
		{
            if (_systems != null)
			{
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }
}