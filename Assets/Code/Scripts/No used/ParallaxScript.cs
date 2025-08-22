using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    [SerializeField] private Vector2 speed;
    private Vector2 offset;
    private Material material;
    private Rigidbody2D rb2d;
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
        rb2d = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        offset = (rb2d.velocity.x / 0.1f) * speed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
