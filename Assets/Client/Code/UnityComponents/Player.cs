using UnityEngine;

namespace Test7tam
{
	[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
	public class Player : MonoBehaviour
	{
		public float Speed;
		public Bomb BombTemplate;
		[HideInInspector]
		public Rigidbody2D Body;
		[HideInInspector]
		public CircleCollider2D Collider;

		private void OnValidate()
		{
			Body = GetComponent<Rigidbody2D>();
			Collider = GetComponent<CircleCollider2D>();
		}
	}
}