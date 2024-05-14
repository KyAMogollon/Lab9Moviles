using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    Rigidbody2D _rb;
    [SerializeField] LayerMask mylayermask;
    [SerializeField] private float distanceRay;
    public float speed;
    private Vector3 movimiento = Vector3.zero;
    [SerializeField] SandController sand;
    [SerializeField] GameManager _gm;
    [SerializeField] GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.velocity = new Vector2(movimiento.x * speed, _rb.velocity.y);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distanceRay,mylayermask);

        Debug.DrawRay(transform.position, Vector2.down* distanceRay, Color.red);
        if (hit)
        {
            Debug.Log("Salto");
            _rb.velocity = new Vector2 (_rb.velocity.x, jumpForce);
            sand.CreateANewPlatform();
            _gm.SetScore(1);
        }
    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        float movement = context.ReadValue<float>();
        movimiento = new Vector2(movement, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Garbage"))
        {
            panel.SetActive(true);
        }
    }
}
