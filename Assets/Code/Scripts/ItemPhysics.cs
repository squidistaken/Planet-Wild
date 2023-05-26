using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPhysics : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    public float gravityFactor = 1f;

    void Update()
    {
        rb.AddForce(new Vector3(0, -1, 0) * gravityFactor, ForceMode.Acceleration);
    }
}
