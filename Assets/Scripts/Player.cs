using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _JumpForce;
    [SerializeField] private GameController _gameController;
    private bool _isGrounded = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            _gameController.Score();
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {

            _rigidbody2D.AddForce(Vector2.up * _JumpForce, ForceMode2D.Impulse);
        }
    }
}
