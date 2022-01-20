using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Diamond.Movement
{
    public class LookAtCamera : MonoBehaviour
    {
        void Update()
        {
            transform.forward = -Camera.main.transform.forward;
        }
    }
}
