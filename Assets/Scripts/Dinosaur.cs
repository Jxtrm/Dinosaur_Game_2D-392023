using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaur : MonoBehaviour
{

    private Rigidbody2D rbDinosaur;
    [SerializeField] private float dinoJump;
    [SerializeField] private Transform cCenter;
    [SerializeField] private float cRadius;
    [SerializeField] private LayerMask ground;


    // Start is called before the first frame update
    void Start()
    {
        rbDinosaur = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bool isGrounded= Physics2D.OverlapCircle(cCenter.position, cRadius, ground);

            if (isGrounded)
            {
                rbDinosaur.AddForce(Vector2.up * dinoJump);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(cCenter.position, cRadius);
    }
}
