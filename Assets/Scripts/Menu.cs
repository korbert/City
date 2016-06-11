using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    [SerializeField]
    MenuType menuType;

    [SerializeField]
    RectTransform border;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void OnClick()
    {
        switch (menuType)
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

    void SetAnchor(float minHeight, float maxHeight)
    {
        border.anchorMin = new Vector2(.8f, minHeight);
        border.anchorMax = new Vector2(1, maxHeight);
    }
}
