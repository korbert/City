using System;
using System.Collections.Generic;

public static class Extensions
{
	public static T PopAt<T>(this List<T> list, int index)
	{
		T r = list[index];
		list.RemoveAt(index);
		return r;
	}
}

