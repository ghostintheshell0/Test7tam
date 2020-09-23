using Leopotam.Ecs;

namespace Test7tam
{
	public class MovingSystem : IEcsRunSystem
	{
		private readonly EcsFilter<MovingComponent, PlayerComponent> _filter = default;

        public void Run ()
		{
			foreach(var i in _filter)
			{
				ref var movingData = ref _filter.Get1(i);
				ref var playerData = ref _filter.Get2(i);

				var velocity = movingData.Direction * playerData.View.Speed;
				playerData.View.Body.velocity = velocity;

				_filter.GetEntity(i).Del<MovingComponent>();
			}
        }
    }
}