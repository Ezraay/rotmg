#region

using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

#endregion

public class Entity : SerializedMonoBehaviour
{
	[SerializeField] private IClassData classData;
	[SerializeField] private Weapon weapon;
	private readonly Dictionary<StatisticType, Statistic> stats = new();

	private float attackCooldown;

	private void Awake()
	{
		if (this.classData != null)
			Setup(this.classData);
	}

	private void Update()
	{
		this.attackCooldown -= Time.deltaTime;
	}

	public void Setup(IClassData data)
	{
		this.classData = data;
		foreach (StatisticType type in Enum.GetValues(typeof(StatisticType)).Cast<StatisticType>())
		{
			Statistic statistic = new(type, data.GetBaseValue(type), data.GetMaxValue(type));
			this.stats.Add(type, statistic);
		}
	}

	public Statistic GetStatistic(StatisticType type)
	{
		this.stats.TryGetValue(type, out Statistic result);
		return result;
	}

	public void Attack(float angle)
	{
		if (this.attackCooldown > 0) return;
		
		this.weapon.Attack(this, angle);
		// A/s (attacks per second) = 1.5 + 6.5 * (DEX / 75) = 6.5 * (DEX + 17.3) / 75
		float dexterity = GetStatistic(StatisticType.Dexterity).Value;
		this.attackCooldown = 1 / (Weapon.BaseAttackSpeed + 6.5f * dexterity / 75);
	}
}