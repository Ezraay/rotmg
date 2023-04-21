#region

using System;
using UnityEngine;

#endregion

namespace Core
{
	public class Projectile : MonoBehaviour
	{
		[field: SerializeField] public float Distance { get; private set; }
		[field: SerializeField] public float Speed { get; private set; }

		private int minDamage;
		private int maxDamage;

		public float AverageDamage => (maxDamage + this.minDamage) / 2f;
		
		public void SetDamage(int minDamage, int maxDamage)
		{
			this.minDamage = minDamage;
			this.maxDamage = maxDamage;
		}

		private void Update()
		{
			float delta = Speed * Time.deltaTime;
			transform.Translate(Vector2.up * delta);
			Distance -= delta;
			if (Distance <= 0) Destroy(gameObject);
		}
	}
}