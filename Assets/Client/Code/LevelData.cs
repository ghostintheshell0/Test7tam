using UnityEngine;
using System.Collections;

namespace Test7tam
{
	public class LevelData : MonoBehaviour
	{
		public Player Player;
		public Joystick Joystick;
		public Vector2 MapAngle;
		public Vector2Int MapSize;
		public Vector3 CellSize;
		public Transform WorldOffset;

		public Vector3 MapToWorld(Vector2Int mapPos)
		{
			return new Vector3(mapPos.x * CellSize.x, mapPos.y * CellSize.y) + WorldOffset.position + CellSize * 0.5f;
		}

		public Vector2Int WorldToMap(Vector3 worldPos)
		{
			var pos = worldPos - WorldOffset.position;
			return new Vector2Int(Mathf.FloorToInt(pos.x / CellSize.x), Mathf.FloorToInt(pos.y / CellSize.y));
		}
	}
}