using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diamond.Control
{
    public class CollisionChecker : MonoBehaviour
    {
        private _PlayerStacking playerStacking;
        private StackingObejcts stackingObejcts;

        private void Start()
        {
            playerStacking = FindObjectOfType<_PlayerStacking>();
            stackingObejcts = GetComponent<StackingObejcts>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {               
            }
        }
    }
}
