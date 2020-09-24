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
			var mapData = Service<MapData>.Get();
			var levelData = Service<LevelData>.Get();
			foreach(var i in _controllables)
			{
				ref var player = ref _controllables.Get2(i);
				var playerMapPosition = levelData.WorldToMap(player.View.transform.position);

				if(!mapData.Bombs.ContainsKey(playerMapPosition))
				{
					var colliderPos = (Vector2) player.View.transform.position + player.View.Collider.offset;
					var hit = Physics2D.OverlapCircle(colliderPos, player.View.BombTemplate.Radius, levelData.WallsMask);
					if(hit == null)
					{
						var bombEnt = _world.NewEntity();
						ref var bombData = ref bombEnt.Get<BombComponent>();
						bombData.Position = playerMapPosition;
						var bombWorldPosition = levelData.MapToWorld(bombData.Position);
						bombData.View = ObjectPool.Spawn(player.View.BombTemplate, bombWorldPosition, Quaternion.identity);
						mapData.Bombs.Add(playerMapPosition, bombEnt);
					}
					
				}
			}
		}
	}
}