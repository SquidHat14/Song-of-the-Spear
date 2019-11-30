using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBox : MonoBehaviour
{

    public Animator animate;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        animate = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        transform.position = new Vector2(player.position.x + (Mathf.Sign(player.localScale.x) * .35f), player.position.y + .5f);
    }}
