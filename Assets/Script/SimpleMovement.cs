using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleMovement : MonoBehaviour
{
    //Besoin d'un character controller, ce script fonctionne avec "OrientationSouris" pour bouger la cam avec la souris
    public float moveSpeed;
    [HideInInspector] public bool CanMove = true;
    private CharacterController characterController; 
    private Animator _animator;
    float moveDirectionX;
    float moveDirectionZ;

    [HideInInspector] public float movespedLimitUp;
    [HideInInspector] public float movespedLimitDown;
    [HideInInspector] public float _moveSpeedSave;
    private void Awake()
    {
        
    }

    void Start()
    {
        LimiteDeVitesse();
        _animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Q oressé = -1, D pressé = 1
        moveDirectionX = Input.GetAxis("Horizontal"); 
        moveDirectionZ = Input.GetAxis("Vertical");
        
        SpressedSpeed();
        AnimationMovement();
        InputExplication();

        //Explication
        //transform.right = (1,0,0) si moveDirectionX = -1, transform.right * moveDirectionX = (1,0,0) * -1  = (-1,0,0) <- vecteur horizal,
        //transform.forward * moveDirectionZ = (0,0,1) * 1 = (0,0,1) <- vecteur vertical =  (-1,0,0) + (0,0,1) = (-1,0,1) <- addiction des 2 vectuers

        Vector3 move = transform.right * moveDirectionX /2 + transform.forward * moveDirectionZ;
        if(CanMove)
        {
            characterController.Move(move * moveSpeed * Time.deltaTime);
        }
        
    }

    void AnimationMovement()
    {
        //Si tu es en l'air 
        if(!GetComponent<JumpWithGravity>().isGrounded)
        {
            _animator.SetBool("IsRunningFront", false);
            _animator.SetBool("IsLeft", false);
            _animator.SetBool("IsRight", false);
        }

        //Si t'es pas en l'air
        else
        {
            //Si tu avances et que tu regardes a gauche || Si tu avances et que tu regardes a droite
            if (Mathf.Abs(moveDirectionZ - 1f) < 0.1f && Mathf.Abs(moveDirectionX - 1f) < 0.1f || (Mathf.Abs(moveDirectionZ - 1f) < 0.1f && Mathf.Abs(moveDirectionX + 1f) < 0.1f))
            {
                _animator.SetBool("IsRunningFront", true);
                _animator.SetBool("IsLeft", false);
                _animator.SetBool("IsRight", false);
            }
            //Si tu recules et que tu regardes a gauche || Si tu recules et que tu regardes a droite
            else if (Mathf.Abs(moveDirectionZ + 1f) < 0.1f && Mathf.Abs(moveDirectionX - 1f) < 0.1f || Mathf.Abs(moveDirectionZ + 1f) < 0.1f && Mathf.Abs(moveDirectionX + 1f) < 0.1f)
            {
                _animator.SetBool("IsRunningBack", true);
                _animator.SetBool("IsLeft", false);
                _animator.SetBool("IsRight", false);
            }
            else
            {

                if (moveDirectionX == -1)
                {

                    _animator.SetBool("IsLeft", true);
                }
                else if (moveDirectionX == 1)
                    _animator.SetBool("IsRight", true);
                else
                {
                    _animator.SetBool("IsLeft", false);
                    _animator.SetBool("IsRight", false);
                }

                if (moveDirectionZ == -1)
                {
                    _animator.SetBool("IsRunningBack", true);
                }
                else if (moveDirectionZ == 1)
                    _animator.SetBool("IsRunningFront", true);
                else
                {
                    _animator.SetBool("IsRunningBack", false);
                    _animator.SetBool("IsRunningFront", false);
                }
            }

        }

       



    }

    void SpressedSpeed()
    {
        // Aller moins vite avec S
        if (Input.GetKeyDown(KeyCode.S))
        {
            moveSpeed = moveSpeed * 0.5f;
            print("S");
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            moveSpeed = _moveSpeedSave;
        }
    }
    void InputExplication()
    {
        // QUEL TOUCH EST PRESSE DECOMMENTER POUR SAVOIR ZQSD
        //Ca fait la diffenrec entre moveDirectionZ et 1f avec une tolerence de 0.1f
        //if (Mathf.Abs(moveDirectionZ + 1f) < 0.1f)
        //{
        //    print("moveDirectionZ -1");
        //    //S
        //}

        //if (Mathf.Abs(moveDirectionZ - 1f) < 0.1f && Mathf.Abs(moveDirectionX - 1f) < 0.1f || Mathf.Abs(moveDirectionX + 1f) < 0.1f)
        //{
        //    print("Z D Q ");
        //    //S
        //} 
        //if (Mathf.Abs(moveDirectionZ - 1f) < 0.1f)
        //{
        //    print("moveDirectionZ 1");
        //    //Z
        //}
        //if (Mathf.Abs(moveDirectionX + 1f) < 0.1f)
        //{
        //    print("moveDirectionX -1");
        //    //Q
        //}
        //if (Mathf.Abs(moveDirectionX - 1f) < 0.1f)
        //{
        //    print("moveDirectionX 1");
        //    //D
        //}

        //if (moveDirectionZ == -1 && moveDirectionX == -1)
        //{
        //    print("2 touches");
        //}
    }

   void  LimiteDeVitesse()
    {
        movespedLimitUp = moveSpeed * 1.3f;
        movespedLimitDown = moveSpeed * 0.7f;
        _moveSpeedSave = moveSpeed;
    }
}
