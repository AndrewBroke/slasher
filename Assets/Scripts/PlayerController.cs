using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private float speed;
    [SerializeField] private float jumpStrength = 5;
    [SerializeField] private GameObject groundPoint;
    [SerializeField] private Vector2 groundPointSize;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private KeyCode attackKey = KeyCode.Mouse0;
    [SerializeField] private GameObject attackPoint;
    [SerializeField] private float attackPointRadius;

    private Rigidbody2D rb;
    private Animator animator;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        // (x, y) -> (1, 0)

        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(moveX));

        Vector3 t = transform.localScale;
        if (moveX > 0)
        {
            t.x = Mathf.Abs(t.x);
        }
        else if (moveX < 0)
        {
            t.x = -Mathf.Abs(t.x);
        }
        transform.localScale = t;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(transform.up * jumpStrength, ForceMode2D.Impulse);
        }

        Attack();
    }

    private void OnDrawGizmos()
    {
        // Прямоугольник для проверки isGround
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(groundPoint.transform.position, groundPointSize);

        // Круг для проверки атаки и врагов
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.transform.position, attackPointRadius);

    }

    bool IsGrounded()
    {
        // Скастовать прямоугольник
        // BoxCast(центр, размер, угол поворота, направление, дистанция, слой)
        RaycastHit2D hit = Physics2D.BoxCast(groundPoint.transform.position, groundPointSize, 0, Vector2.zero, 0, groundLayerMask);
        // Проверить, соприкасается ли он с землей
        return hit.collider != null;
    }

    private void Attack()
    {
        string currentAnimState = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        if (Input.GetKeyDown(attackKey) && currentAnimState != "attack")
        {
            animator.SetTrigger("Attack");
        }
    }
}
