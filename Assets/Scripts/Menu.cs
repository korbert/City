using UnityEngine;

public class Menu : MonoBehaviour
{
	[SerializeField]
	GameObject[] menus;

	[SerializeField]
	RectTransform border;

	public void OnClick(int type)
	{
		MenuType menuType = (MenuType)type;
		SetBorderPosition(menuType);
		Show(menuType);
	}

	void SetBorderPosition(MenuType menu)
	{
		switch (menu)
		{
			case MenuType.Major:
				SetAnchor(.92f, 1);
				break;
			case MenuType.Emergency:
				SetAnchor(.82f, .9f);
				break;
			case MenuType.Contracts:
				SetAnchor(.72f, .8f);
				break;
			case MenuType.Call:
				SetAnchor(.408f, .55f);
				break;
			default:
				break;
		}
	}

	void Show(MenuType menu)
	{
		int count = menus.Length;
		for (int i = 0; i < count; i++)
		{
			menus[i].SetActive(i == (int)menu);
		}
	}

	void SetAnchor(float minHeight, float maxHeight)
	{
		border.anchorMin = new Vector2(.8f, minHeight);
		border.anchorMax = new Vector2(1, maxHeight);
	}
}
