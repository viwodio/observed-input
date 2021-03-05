using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using viwodio.InputSystem;

public class Turn : MonoBehaviour
{
    [SerializeField] private string inputKey = "turn";
    [SerializeField] private float turnSpeed = 6f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Axis1D.GetAxis1D(inputKey).GetValue() * turnSpeed * Time.deltaTime);
    }
}
