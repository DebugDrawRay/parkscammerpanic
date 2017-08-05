using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : AiController
{
    public Transform itemContainer;
    private GameObject currentItem;

    public bool hasItem
    {
        get
        {
            return currentItem != null;
        }
    }
    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        UpdateWander();
        Leave();
    }

	public void Leave()
	{
		if(hasItem && !Utils.IsVisibleFrom(GetComponentInChildren<Renderer>(), Camera.main))
        {
            Destroy(gameObject);
        }
	}
    public void GiveItem(GameObject item)
    {
        currentItem = item;
		currentItem.layer = 0;
        currentItem.transform.position = itemContainer.position;
        currentItem.transform.SetParent(itemContainer);
    }
}
