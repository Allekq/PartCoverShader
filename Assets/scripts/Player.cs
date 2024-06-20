using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float speed = 3;

    [SerializeField]
    private Transform light;

    // Start is called before the first frame update
    void Start()
    {
        if(rb == null) rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (move.sqrMagnitude > 1) move = move.normalized;
        rb.velocity = new Vector2(move.x * speed, move.y * speed);
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        light.up= (pos - transform.position);
    }
}
