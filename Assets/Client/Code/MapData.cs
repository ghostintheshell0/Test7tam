using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;

namespace Test7tam
{
	public class MapData
	{
		public Dictionary<Vector2Int, EcsEntity> Bombs = new Dictionary<Vector2Int, EcsEntity>();
	}
}