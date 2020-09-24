using UnityEngine;
using System.Collections;

namespace Test7tam
{
	public class LevelData : MonoBehaviour
	{
		public Player Player;
		public Joystick Joystick;
		[Tooltip("Degrees")]
		public Vector2 MapAngle;
		public Vector2Int MapSize;
		public Vector3 CellSize;
		public Transform WorldOffset;

		public Vector3 MapToWorld(Vector2Int mapPos)
		{
			var result = new Vector3(mapPos.x * CellSize.x, mapPos.y * CellSize.y) + WorldOffset.position + CellSize * 0.5f;
			result = Incline(result);
			return result;
		}

		public Vector2Int WorldToMap(Vector3 worldPos)
		{
			var pos = worldPos - WorldOffset.position;
			var result = new Vector2Int(Mathf.FloorToInt(pos.x / CellSize.x), Mathf.FloorToInt(pos.y / CellSize.y));
			return result;
		}

		public Vector3 Incline(Vector3 vec)
		{
			var result = vec;
			result.x += Mathf.Tan(MapAngle.y * Mathf.Deg2Rad) * vec.y;
			result.y += Mathf.Tan(MapAngle.x * Mathf.Deg2Rad) * vec.x;
			return result;
		}
	}
}