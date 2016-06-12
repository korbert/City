using System;

public static class Utils
{
	public static int GetEnumCount(Type enumType)
	{
		return Enum.GetNames(enumType).Length;
	}
}