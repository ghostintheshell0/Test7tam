using UnityEngine;

namespace Test7tam
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class Player : MonoBehaviour
	{
		public float Speed;
		public Transform BombTemplate;
		[HideInInspector]
		public Rigidbody2D Body;

		private void OnValidate()
		{
			Body = GetComponent<Rigidbody2D>();
		}
	}
}