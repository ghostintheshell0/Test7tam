using UnityEngine;
using LeopotamGroup.Globals;
using Leopotam.Ecs;

namespace Test7tam
{
	public class BombButton : MonoBehaviour
	{
		public void Click()
		{
			var ent = Service<EcsWorld>.Get().NewEntity();
			ent.Get<SpawnBombCommand>();
		}
	}
}