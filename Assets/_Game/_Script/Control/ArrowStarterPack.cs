using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowStarterPack : MonoBehaviour
{
	public Diamond.Control.Rack R;
	public GameObject otherObject;
	public bool isDestroyed;

    void Start()
    {
        
    }

    
    void Update()
    {

		if (R.Obj.Count <= 0 || isDestroyed || R == null)
		{
			if (!isDestroyed)
				isDestroyed = true;
			otherObject.SetActive(true);
			Destroy(this.gameObject, 0.15f);
		}
    }
}
