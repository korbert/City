using UnityEngine;
using System.Collections.Generic;

public class ShuffleList<T>
{
	public List<T> Elements;
	List<T> m_elementsPrepared;
	bool m_endOflist;
	T m_lastElement;

	/// <summary>
	/// Initializes a new instance of the <see cref="ShuffleList`1"/> class.
	/// </summary>
	public ShuffleList()
	{
		Elements = new List<T>();
		m_elementsPrepared = new List<T>();
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="ShuffleList`1"/> class. Passa list on collection to add directly to Elements list
	/// </summary>
	/// <param name="collection">Collection.</param>
	public ShuffleList(IEnumerable<T> collection)
	{
		Elements = new List<T>(collection);
		m_elementsPrepared = new List<T>(collection);
	}

	/// <summary>
	/// Add the specified element. If the element is already in the list, it does nothing
	/// </summary>
	/// <param name="element">Element.</param>
	public void Add(T element)
	{
		if (!Elements.Contains(element))
		{
			Elements.Add(element);
			//			m_elementsPrepared.Add(element);
		}
	}

	/// <summary>
	/// Remove the specified element. If the element isn't in the list, it does nothing
	/// </summary>
	/// <param name="element">Element.</param>
	public void Remove(T element)
	{
		if (Elements.Contains(element))
		{
			Elements.Remove(element);
			m_elementsPrepared.Remove(element);
		}
	}

	/// <summary>
	/// Return a random element from the list without repeating any element. When we haven't any element available restart the list
	/// </summary>
	public T Shuffle()
	{
		if (Elements.Count == 0 && m_elementsPrepared.Count == 0)
			return default(T);


		T element = m_lastElement;

		if (m_elementsPrepared.Count == 0)
		{
			m_elementsPrepared = new List<T>(Elements);
			m_endOflist = true;
			m_lastElement = element;
		}

		if (m_endOflist && m_elementsPrepared.Count > 1)
		{
			while (element.Equals(m_lastElement))
			{
				element = m_elementsPrepared[Random.Range(0, m_elementsPrepared.Count)];
			}
			m_elementsPrepared.Remove(element);
			m_endOflist = false;
		}
		else
		{
			element = m_elementsPrepared[Random.Range(0, m_elementsPrepared.Count)];
			m_elementsPrepared.Remove(element);
		}

		return element;
	}
}