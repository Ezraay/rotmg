namespace Core
{
	public interface IClassData
	{
		public ClassType ClassType { get; }
		public int GetBaseValue(StatisticType type);
		public int GetMaxValue(StatisticType type);
	}
}