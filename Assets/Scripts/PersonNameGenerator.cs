using System.Collections.Generic;
using UnityEngine;

public class PersonNameGenerator
{
	static string[] _maleFirstNames;
	static string[] _femaleFirstNames;
	static string[] _lastNames;

	public PersonNameGenerator(TextAsset maleText, TextAsset femaleText, TextAsset lastText)
	{
		if (_maleFirstNames == null)
			_maleFirstNames = maleText.text.Split ('\n');

		if (_femaleFirstNames == null)
			_femaleFirstNames = femaleText.text.Split ('\n');

		if (_lastNames != null)
			return;

		_lastNames = lastText.text.Split ('\n');
	}

	bool RandomlyPickIfNameIsMale
	{
		get { return Random.Range(0, 2) == 0; }
	}

	public string GenerateRandomFirstAndLastName()
	{
		return GenerateRandomFirstName() + ' ' + GenerateRandomLastName();
	}

	public string GenerateRandomLastName()
	{
		var index = Random.Range(0, _lastNames.Length);

		return _lastNames[index];
	}

	public string GenerateRandomFirstName()
	{
		return !RandomlyPickIfNameIsMale
			? GenerateRandomFemaleFirstName()
			: GenerateRandomMaleFirstName();
	}

	public string GenerateRandomFemaleFirstName()
	{
		var index = Random.Range(0, _femaleFirstNames.Length);

		return _femaleFirstNames[index];
	}

	public string GenerateRandomMaleFirstName()
	{
		var index = Random.Range(0, _maleFirstNames.Length);

		return _maleFirstNames[index];
	}

	public IEnumerable<string> GenerateMultipleFirstAndLastNames(int count)
	{
		var list = new List<string>();

		for (var index = 0; index < count; ++index)
			list.Add(GenerateRandomFirstAndLastName());

		return list;
	}

	public IEnumerable<string> GenerateMultipleLastNames(int count)
	{
		var list = new List<string>();

		for (var index = 0; index < count; ++index)
			list.Add(GenerateRandomLastName());

		return list;
	}

	public IEnumerable<string> GenerateMultipleFemaleFirstAndLastNames(int count)
	{
		var list = new List<string>();

		for (var index = 0; index < count; ++index)
			list.Add(GenerateRandomFemaleFirstAndLastName());

		return list;
	}

	public IEnumerable<string> GenerateMultipleMaleFirstAndLastNames(int count)
	{
		var list = new List<string>();

		for (var index = 0; index < count; ++index)
			list.Add(GenerateRandomMaleFirstAndLastName());

		return list;
	}

	public IEnumerable<string> GenerateMultipleFemaleFirstNames(int count)
	{
		var list = new List<string>();

		for (var index = 0; index < count; ++index)
			list.Add(GenerateRandomFemaleFirstName());

		return list;
	}

	public IEnumerable<string> GenerateMultipleMaleFirstNames(int count)
	{
		var list = new List<string>();

		for (var index = 0; index < count; ++index)
			list.Add(GenerateRandomMaleFirstName());

		return list;
	}

	public string GenerateRandomFemaleFirstAndLastName()
	{
		return GenerateRandomFemaleFirstName() + GenerateRandomLastName();
	}

	public string GenerateRandomMaleFirstAndLastName()
	{
		return GenerateRandomMaleFirstName() + GenerateRandomLastName();
	}
}