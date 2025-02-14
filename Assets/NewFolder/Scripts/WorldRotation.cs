using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotation : MonoBehaviour
{
    private Transform worldTransform;

    [SerializeField]
    private int speedRotation;

    // Start is called before the first frame update
    void Start()
    {
        worldTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.left * speedRotation * Time.deltaTime);
    }
}
