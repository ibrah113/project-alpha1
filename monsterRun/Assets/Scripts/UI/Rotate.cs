using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Rotate(1, 4, 2);
    }
}
