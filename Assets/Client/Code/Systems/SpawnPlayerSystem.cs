using Leopotam.Ecs;
using LeopotamGroup.Globals;

namespace Test7tam
{
	public class SpawnPlayerSystem : IEcsInitSystem
	{
		public void Init()
		{
			var playerEnt = Service<EcsWorld>.Get().NewEntity();
			ref var playerData = ref playerEnt.Get<PlayerComponent>();
			playerData.View = Service<LevelData>.Get().Player;
		}
	}
}