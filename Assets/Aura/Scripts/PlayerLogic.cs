using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerLogic : MonoBehaviour
{
    public float movementSpeed = 5;


    private float m_horizontalInput;

    private float m_forwardInput;

    //Jumping related variables
   [Header("Jumping modifiers")]
   [SerializeField] private float m_jumpHeight = 0.5f;
   [SerializeField] public float m_gravity = 0.045f;
   [SerializeField] private float m_gravityModifier = 1.5f;
    private bool canJump = false;


    private Vector3 m_Movement;

    private CharacterController m_CharController;

    private void Start()
    {
        m_CharController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_forwardInput = Input.GetAxis("Vertical");

        //jumping logic
        if(!canJump && Input.GetButtonDown("Jump"))
        {
            canJump = true;
        }
    }

    private void FixedUpdate()
    {
        m_Movement.x = m_horizontalInput * movementSpeed * Time.deltaTime;
        m_Movement.z = m_forwardInput * movementSpeed * Time.deltaTime;

        /*apply gravity if charcter is jumping(constant gravity going up and coming down)
        if(!m_CharController.isGrounded)
        {
            m_Movement.y -= m_gravity;
        }
        else 
        {
            m_Movement.y = 0f;
        }
        */

        //apply gravity if character is jumping(variable gravity going for up and down phases of jump)

        if (!m_CharController.isGrounded)
        {
            if(m_Movement.y > 0)
            {
               m_Movement.y -= m_gravity;
            }
            else
            {
                m_Movement.y -= m_gravity * m_gravityModifier;
            }
        }


        else
        {
            m_Movement.y = 0f;
        }

        if (canJump)
        {
            //apply upward force
            m_Movement.y = m_jumpHeight;
            //disable ability to jump
            canJump = false;
        }

        m_CharController.Move(m_Movement);
    }
}


