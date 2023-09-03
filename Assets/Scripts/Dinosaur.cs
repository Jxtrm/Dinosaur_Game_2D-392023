using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaur : MonoBehaviour
{

    [SerializeField] private float dinoJump;
    [SerializeField] private Transform cCenter;
    [SerializeField] private float cRadius;
    [SerializeField] private LayerMask ground;
    private Rigidbody2D rbDinosaur;
    private Animator dAnimator;

    // Start is called before the first frame update
    void Start()
    {
        rbDinosaur = GetComponent<Rigidbody2D>();
        dAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isGrounded= Physics2D.OverlapCircle(cCenter.position, cRadius, ground);
        dAnimator.SetBool("IsGrounded", isGrounded);

        if (Input.GetKeyDown(KeyCode.Space))
        {

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.ShowGameOverScreen();
            dAnimator.SetTrigger("Die");
            Time.timeScale = 0f;
        }
    }
}
