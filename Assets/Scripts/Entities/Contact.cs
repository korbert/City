using UnityEngine;

public class Contact
{
	/// <summary>
	/// Need to add 555 at the beginning. Also format it as (555)XXX-XXXX
	/// </summary>
	public int Phone;
	public string Name;

	public Contact()
	{
		Phone = GetRandomNumber();
		Name = GetRandomName();
	}

	int GetRandomNumber()
	{
		return UnityEngine.Random.Range(0, 9999999);
	}

	string GetRandomName()
	{
		string name = NameGenerator.GenerateRandomFirstAndLastName();
		return name;
	}

	static PersonNameGenerator _nameGenerator;
	static PersonNameGenerator NameGenerator
	{
		get
		{
			if (_nameGenerator == null)
				_nameGenerator = new PersonNameGenerator(
					Resources.Load ("male", typeof(TextAsset)) as TextAsset,
					Resources.Load ("female", typeof(TextAsset)) as TextAsset,
					Resources.Load ("last", typeof(TextAsset)) as TextAsset);
			return _nameGenerator;
		}
	}
}