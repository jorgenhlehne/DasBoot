using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkingTest : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Sink");
        }
    }
}
