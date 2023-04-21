#region

using System.Collections.Generic;
using Core;
using Sirenix.OdinInspector;
using UnityEngine;

#endregion

namespace Data
{
	[CreateAssetMenu(menuName = "Create New Entity", fileName = "New Entity", order = 0)]
	public class ClassData : SerializedScriptableObject, IClassData
	{
		[SerializeField] private Dictionary<StatisticType, int> maxStatValues;
		[SerializeField] private Dictionary<StatisticType, int> statValues;
		[SerializeField] public ClassType ClassType { get; private set; }


		public int GetBaseValue(StatisticType type)
		{
			this.statValues.TryGetValue(type, out int result);
			return result;
		}

		public int GetMaxValue(StatisticType type)
		{
			this.maxStatValues.TryGetValue(type, out int result);
			return result;
		}
	}
}