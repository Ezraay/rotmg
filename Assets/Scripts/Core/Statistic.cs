#region

using System;
using UnityEngine;

#endregion

public class Statistic
{
	private readonly int baseValue;
	private readonly int maxValue;
	private readonly StatisticType type;
	private int modifier;

	public Statistic(StatisticType type, int baseValue, int maxValue)
	{
		this.type = type;
		this.baseValue = baseValue;
		this.maxValue = maxValue;
	}

	public int Value => this.baseValue + this.modifier;
	public event Action<int> OnChange;

	public void Add(int change)
	{
		this.modifier += change;
		this.modifier = Mathf.Clamp(this.modifier, -this.baseValue, this.maxValue - this.modifier);
		OnChange?.Invoke(change);
	}

	public void Remove(int change)
	{
		Add(-change);
	}
}