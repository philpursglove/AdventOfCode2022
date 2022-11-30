namespace AdventUtilities
{
	public static class Utilities
	{
		public static int ManhattanDistance(object point1, object point2, string XPropertyName, string YPropertyName)
		{
			int x1 = getCoordinateValue(point1, XPropertyName);
			int x2 = getCoordinateValue(point2, XPropertyName);

			int y1 = getCoordinateValue(point1, YPropertyName);
			int y2 = getCoordinateValue(point2, YPropertyName);

			return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
		}

		private static int getCoordinateValue(object point1, string PropertyName)
		{
			Type type = point1.GetType();
			return (int) type.GetProperty(PropertyName).GetValue(point1);
		}
	}
}