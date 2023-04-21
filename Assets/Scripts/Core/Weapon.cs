#region

using System;
using UnityEngine;

#endregion

namespace Core
{
	[CreateAssetMenu(menuName = "Create New Weapon", fileName = "New Weapon", order = 0)]
	public class Weapon : ScriptableObject
	{
		public const float BaseAttackSpeed = 1.5f;

		[SerializeField] private int tier;
		[SerializeField] private ProjectileData[] projectiles;

		public void Attack(Entity author, float angle)
		{
			foreach (ProjectileData projectileData in this.projectiles)
			{
				Quaternion rotation = Quaternion.Euler(0, 0, angle + projectileData.angle);
				Projectile projectile = Instantiate(projectileData.projectile, author.transform.position, rotation);
				projectile.SetDamage(projectileData.minDamage, projectileData.maxDamage);
			}
		}
	}

	[Serializable]
	internal struct ProjectileData
	{
		public Projectile projectile;
		public int angle;
		public int minDamage;
		public int maxDamage;

		public ProjectileData(Projectile projectile, int angle, int minDamage, int maxDamage)
		{
			this.projectile = projectile;
			this.angle = angle;
			this.minDamage = minDamage;
			this.maxDamage = maxDamage;
		}
	}
}