using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diamond.Control
{
    public class _ColliderActivator : MonoBehaviour
    {
        public float x = 0;
        Diamond.Core.GameManager gm;
        _PlayerStacking playerStacking;

        private void Start()
        {
            gm = FindObjectOfType<Diamond.Core.GameManager>();
            playerStacking = FindObjectOfType<_PlayerStacking>();
        }
        void Update()
        {
            if (x >= 0 || playerStacking.ClothObject.Count - 1 >= gm.StackingLimit || gm.StackingLimit == 0)
            {
                GetComponent<Collider>().enabled = false;
                x -= Time.deltaTime;
            }

            if (x <= 0 &&  playerStacking.ClothObject.Count - 1 < gm.StackingLimit && gm.StackingLimit !=0)
                GetComponent<Collider>().enabled = true;
        }
    }
}
