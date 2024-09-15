using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpWithGravity : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public float gravity;
    public float groundCheckDistance;
    public LayerMask groundMask;

    private CharacterController characterController;
    private Vector3 velocity;
    private Vector3 velocitySave;
    [HideInInspector] public bool isGrounded;
    private Animator _animator;

    void Start()
    {
        velocitySave.y = velocity.y;
        _animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Vérification si le personnage est au sol
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        // Réinitialisation de la vitesse verticale si le personnage touche le sol
        if (isGrounded && velocity.y < 2)
        {
            velocity.y = 0f;
        }

        // Gérer le saut
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            _animator.SetBool("IsJumpingUp", true);
            _animator.SetBool("IsJumpingDown", false);
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Détection du pic du saut
        if (velocitySave.y > 0 && velocity.y < 0)
        {
            _animator.SetBool("IsJumpingUp", false); 
            _animator.SetBool("IsJumpingDown", true); 
        }

        //Je determine quand est ce que le perso arrete de monter (pic du saut)
        velocitySave.y = velocity.y;

        // Appliquer la gravité
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
        //print(isGrounded + "isgrounded");
    }


    // private void OnDrawGizmos()
    // {
    //     Gizmos.DrawSphere(transform.position, groundCheckDistance);
    // }
}
