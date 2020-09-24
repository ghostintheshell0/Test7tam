using Leopotam.Ecs;
using LeopotamGroup.Globals;
using UnityEngine;

namespace Test7tam
{
	public partial class SpawnBombSystem : IEcsRunSystem
	{
		private readonly EcsWorld _world = default;
		private readonly EcsFilter<SpawnBombCommand> _command = default;
		private readonly EcsFilter<ControllableComponent, PlayerComponent> _controllables = default;

		public void Run()
		{
			if (_command.GetEntitiesCount() == 0) return;

			foreach(var i in _controllables)
			{
				ref var player = ref _controllables.Get2(i);
				var bombEnt = _world.NewEntity();
				ref var bombData = ref bombEnt.Get<BombComponent>();
				bombData.Position = Service<LevelData>.Get().WorldToMap(player.View.transform.position);
				var bombPosition = Service<LevelData>.Get().MapToWorld(bombData.Position);
				bombData.View = ObjectPool.Spawn(player.View.BombTemplate, bombPosition, Quaternion.identity);
			}
		}
	}
}
