using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diamond.Control
{
    public class _PlayerStacking : MonoBehaviour
    {
        public GameObject Stone;

        public List<GameObject> ClothObject = new List<GameObject>();
        public GameObject StackingPlace;

        public GameObject pooflEffect;

		private Diamond.Core.AudioManager Am;
		private void Start()
		{
			Am = FindObjectOfType<Diamond.Core.AudioManager>();
		}
		void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                //addClothToStack(DummyCloth, 0);
            }




            if (ClothObject.Count <= 0)
                poof = false;

            StackingClothListing();
            StackingPlace.transform.rotation = Quaternion.Euler(StackingPlace.transform.eulerAngles.x, StackingPlace.transform.eulerAngles.y, 0);            
        }
        bool poof;
        public void resetStacking()
        {
            if (!poof && ClothObject.Count > 0)
            {
                Destroy(Instantiate(pooflEffect, StackingPlace.transform.position, Quaternion.identity), 2);
                poof = true;
            }

            if (ClothObject.Count > 0)
            {
                for (int i = 0; i <= ClothObject.Count - 1; i++)
                {
                    if (ClothObject[i] != null)
                    {
                        Destroy(ClothObject[i]);
                    }

                    if (ClothObject[i] == null)
                    {
                        ClothObject.Remove(ClothObject[i]);
                    }
                }
            }

        }

        public void addClothToStack(GameObject stone)
        {
            if (ClothObject.Count <= 0)
            {
                stone.transform.parent = StackingPlace.transform;
                stone.transform.localScale = new Vector3(0.8f, 0.4f, 0.8f);
                stone.transform.rotation = Quaternion.Euler(0, 0, 0);
				stone.GetComponent<StackingObejcts>().ifPlayerCarry = true;

            }

            if (ClothObject.Count > 0)
            {
                stone.transform.parent = StackingPlace.transform;
                stone.transform.localScale = new Vector3(0.8f, 0.4f, 0.8f);
                stone.transform.rotation = Quaternion.Euler(0, 0, 0);
				stone.GetComponent<StackingObejcts>().ifPlayerCarry = true;
			}
        }


        public void RemoveCloth(GameObject other, int needCode)
        {
            if (ClothObject.Count > 0)
            {
                for (int i = 0; i <= ClothObject.Count - 1;)
                {
                    if (i >= ClothObject.Count - 1 && ClothObject[i].GetComponent<StackingObejcts>().ObjectId != needCode)
                    {
                        return;
                    }

                    if (ClothObject[i].GetComponent<StackingObejcts>().ObjectId != needCode)
                    {
                        i++;
                    }

                    if (ClothObject[i].GetComponent<StackingObejcts>().ObjectId == needCode)
                    {
                        ClothObject[i].transform.parent = null;
                        ClothObject[i].GetComponent<StackingObejcts>().TargetPos = other.transform.position;
						ClothObject[i].GetComponent<StackingObejcts>().ifPlayerCarry = false;
                        ClothObject.Remove(ClothObject[i]);
                        /*other.gameObject.GetComponent<Sneaker.Control._CustomerControl>().isPlayerNear = true;
                        other.gameObject.GetComponent<Sneaker.Control._CustomerControl>().clothTookFromPlayer = true;*/
                        //Instantiate(gm.customerUI, other.transform.position + customerUISpwanOffset, Quaternion.identity);
                        break;
                    }

                }
            }
        }

        public void RemoveOreForFilter(Transform parant,Vector3 transform, int needCode)
        {
            if (ClothObject.Count > 0)
            {
                for (int i = 0; i <= ClothObject.Count - 1;)
                {
                    if (i >= ClothObject.Count - 1 && ClothObject[i].GetComponent<StackingObejcts>().ObjectId != needCode)
                    {
                        return;
                    }

                    if (ClothObject[i].GetComponent<StackingObejcts>().ObjectId != needCode)
                    {
                        i++;
                    }

                    if (ClothObject[i].GetComponent<StackingObejcts>().ObjectId == needCode)
                    {
						Am.source.PlayOneShot(Am.DropItem);
						ClothObject[i].transform.parent = parant;
                        ClothObject[i].GetComponent<StackingObejcts>().TargetPos = transform;
						ClothObject[i].GetComponent<StackingObejcts>().ifPlayerCarry = true;
						ClothObject.Remove(ClothObject[i]);
                        break;
                    }
                }
            }
        }

		public bool RemovebleDiamond(int ID)
		{
			if (ClothObject.Count > 0)
			{
				for (int i = 0; i <= ClothObject.Count - 1;)
				{
					if (i >= ClothObject.Count - 1 && ClothObject[i].GetComponent<StackingObejcts>().ObjectId != ID)
					{
						return (false);
					}

					if (ClothObject[i].GetComponent<StackingObejcts>().ObjectId != ID)
					{
						i++;
					}

					if (ClothObject[i].GetComponent<StackingObejcts>().ObjectId == ID)
					{
						return (true);
					}
				}
			}
			return false;
		}

		float x = 0.05f;
		public void RemoveStoneForSell(GameObject other)
		{
			if (ClothObject.Count > 0)
			{
				for (int i = 0; i <= ClothObject.Count - 1;i++)
				{
					if (x >= 0)
						x -= Time.deltaTime;
					if (x <= 0)
					{
						Am.source.PlayOneShot(Am.BrakeItem, 0.5f);
						ClothObject[i].transform.parent = null;
						ClothObject[i].GetComponent<StackingObejcts>().TargetPos = other.transform.position;
						ClothObject[i].GetComponent<StackingObejcts>().ifPlayerCarry = false;
						ClothObject.Remove(ClothObject[i]);
						x = 0.05f;
					}									

				}
			}
		}

		public void stack()
        {
        }

        public void StackingClothListing()
        {
            foreach (Transform T in StackingPlace.transform)
            {
                if (!ClothObject.Contains(T.gameObject) && ClothObject.Count <= 0)
                {
                    ClothObject.Add(T.gameObject);                    
                }
                if (!ClothObject.Contains(T.gameObject) && ClothObject.Count > 0)
                {
                    ClothObject.Add(T.gameObject);                    
                }
            }

            if (ClothObject.Count > 0)
            {
                for (int i = 0; i <= ClothObject.Count - 1; i++)
                {
                    if (ClothObject[i] == null)
                    {
                        ClothObject.Remove(ClothObject[i]);
                    }
                }
            }
        }
    }
}
