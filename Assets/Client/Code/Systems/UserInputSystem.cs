using Leopotam.Ecs;
using UnityEngine;
using LeopotamGroup.Globals;

namespace Test7tam
{
	public class UserInputSystem : IEcsRunSystem
	{
		private readonly EcsFilter<ControllableComponent> _filter = default;

		public void Run()
		{
			var levelData = Service<LevelData>.Get();
			var direction = levelData.Joystick.Direction;
			if (direction.x == 0 && direction.y == 0) return;

			direction = levelData.Incline(direction);

			foreach (var i in _filter)
			{
				ref var ent = ref _filter.GetEntity(i);
				ref var movingData = ref ent.Get<MovingComponent>();
				
				movingData.Direction = direction;
			}

		}
	}
}