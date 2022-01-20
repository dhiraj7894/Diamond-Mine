using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diamond.Control
{
    public class StackingObejcts : MonoBehaviour
    {
        public int ObjectId;
        public Vector3 initPos;
        public Vector3 TargetPos;
        public float movementSpeed = 5;

        public bool isDestroy;
		public bool ifPlayerCarry;
        private Rigidbody rb;

		[Header("Stone")]
		public GameObject stoneID_0;
		public GameObject stoneID_1;
		public GameObject stoneID_2;
		[Header("Diamonds")]
		public GameObject stoneID_3;
		public GameObject stoneID_4;
		public GameObject stoneID_5;
		public GameObject stoneID_6;

        // Start is called before the first frame update
        void Start()
        {
			stoneChanger();
			rb = GetComponent<Rigidbody>();
            initPos = transform.position;
            TargetPos = transform.position;
        }


        void Update()
        {
            move();
			stoneChanger();
			if (isDestroy)
                StartCoroutine(selfDestory(0.2f));

        }

		void stoneChanger()
		{
			if(ObjectId == 0)
			{
				stoneID_0.SetActive(true);
				stoneID_1.SetActive(false);
				stoneID_2.SetActive(false);
				stoneID_3.SetActive(false);
				stoneID_4.SetActive(false);
				stoneID_5.SetActive(false);
				stoneID_6.SetActive(false);
			}
			if (ObjectId == 1)
			{
				stoneID_0.SetActive(false);
				stoneID_1.SetActive(true);
				stoneID_2.SetActive(false);
				stoneID_3.SetActive(false);
				stoneID_4.SetActive(false);
				stoneID_5.SetActive(false);
				stoneID_6.SetActive(false);
			}
			if (ObjectId == 2)
			{
				stoneID_0.SetActive(false);
				stoneID_1.SetActive(false);
				stoneID_2.SetActive(true);
				stoneID_3.SetActive(false);
				stoneID_4.SetActive(false);
				stoneID_5.SetActive(false);
				stoneID_6.SetActive(false);
			}
			if (ObjectId == 3)
			{
				stoneID_0.SetActive(false);
				stoneID_1.SetActive(false);
				stoneID_2.SetActive(false);
				stoneID_3.SetActive(true);
				stoneID_4.SetActive(false);
				stoneID_5.SetActive(false);
				stoneID_6.SetActive(false);
			}
			if (ObjectId == 4)
			{
				stoneID_0.SetActive(false);
				stoneID_1.SetActive(false);
				stoneID_2.SetActive(false);
				stoneID_3.SetActive(false);
				stoneID_4.SetActive(true);
				stoneID_5.SetActive(false);
				stoneID_6.SetActive(false);
			}
			if (ObjectId == 5)
			{
				stoneID_0.SetActive(false);
				stoneID_1.SetActive(false);
				stoneID_2.SetActive(false);
				stoneID_3.SetActive(false);
				stoneID_4.SetActive(false);
				stoneID_5.SetActive(true);
				stoneID_6.SetActive(false);
			}
			if (ObjectId == 6)
			{
				stoneID_0.SetActive(false);
				stoneID_1.SetActive(false);
				stoneID_2.SetActive(false);
				stoneID_3.SetActive(false);
				stoneID_4.SetActive(false);
				stoneID_5.SetActive(false);
				stoneID_6.SetActive(true);
			}
		}
        void move()
        {
            if (initPos == TargetPos && ifPlayerCarry)
			{
				transform.localPosition = new Vector3(TargetPos.x, transform.localPosition.y, TargetPos.z);
			}
			if (initPos == TargetPos)
			{
				return;
			}
			if (initPos != TargetPos)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, TargetPos, movementSpeed * Time.deltaTime);
                GetComponent<Collider>().enabled = false;
                rb.isKinematic = true;
                rb.useGravity = false;
                if (transform.localPosition == TargetPos)
                {
                    GetComponent<Collider>().enabled = true;
                    initPos = TargetPos;
                    rb.isKinematic = false;
                    rb.useGravity = true;
                }
            }
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
      
        IEnumerator selfDestory(float t)
        {
            yield return new WaitForSeconds(t);
            Destroy(this.gameObject);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Collector"))
            {
				if(collision.gameObject.GetComponent<MineMachine>() != null)
				{
					if (collision.gameObject.GetComponent<MineMachine>().isMachineLocked)
					{
						collision.gameObject.GetComponent<MineMachine>().RequreObjects--;
						Destroy(this.gameObject);
					}
					if (!collision.gameObject.GetComponent<MineMachine>().isMachineLocked)
					{
						if (collision.gameObject.GetComponent<MineMachine>().TargetID == ObjectId)
							Destroy(this.gameObject);
					}				
				}
				if(collision.gameObject.GetComponent<FilterMachine>() != null)
				{
					if (collision.gameObject.GetComponent<FilterMachine>().isMachineLocked)
					{
						collision.gameObject.GetComponent<FilterMachine>().RequreObjects--;
						Destroy(this.gameObject);
					}
					if (!collision.gameObject.GetComponent<FilterMachine>().isMachineLocked)
					{
						if (collision.gameObject.GetComponent<FilterMachine>().TargetID == ObjectId)
							Destroy(this.gameObject);
					}
				}

				if (collision.gameObject.GetComponent<shop>() != null)
				{
					if (collision.gameObject.GetComponent<shop>().isMachineUnlocked)
					{
						if(ObjectId == 3 && FindObjectOfType<Diamond.Core.GameManager>().RequreBlueGem>=0)
						{
							FindObjectOfType<Diamond.Core.GameManager>().RequreBlueGem--;
						}
						if (ObjectId == 4 && FindObjectOfType<Diamond.Core.GameManager>().RequreRedGem>=0)
						{
							FindObjectOfType<Diamond.Core.GameManager>().RequreRedGem--;
						}
						if (ObjectId == 5 && FindObjectOfType<Diamond.Core.GameManager>().RequreYellowGem>=0)
						{
							FindObjectOfType<Diamond.Core.GameManager>().RequreYellowGem--;
						}
						if (ObjectId == 6 && FindObjectOfType<Diamond.Core.GameManager>().RequreBlackGem>=0)
						{
							FindObjectOfType<Diamond.Core.GameManager>().RequreBlackGem--;
						}
						Destroy(this.gameObject);
					}
				}

				if (collision.gameObject.GetComponent<SellExtraItem>() != null)
				{
					FindObjectOfType<Diamond.Core.GameManager>().MaxMoney += 5;
					Destroy(this.gameObject);
				}
                             
            }
        }
	}
}
