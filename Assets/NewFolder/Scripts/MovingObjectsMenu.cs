using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingObjectsMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private int speed;
    private Vector3 dir = Vector3.forward;
    private Transform transform_player;

    // Start is called before the first frame update
    void Start()
    {
        transform_player = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform_player.Translate(dir * speed * Time.deltaTime);
    }
}
