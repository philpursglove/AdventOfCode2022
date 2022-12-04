namespace AdventUtilities
{
	public static class IntExtensions
	{
		public static bool Between(this int a, int lower, int upper)
		{
			if (lower > upper)
			{
				int temp = lower;
				lower = upper;
				upper = temp;
			}

			return (a >= lower) && (a <= upper);
		}
	}
}
