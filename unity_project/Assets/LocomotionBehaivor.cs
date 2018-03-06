using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionBehaivor : StateMachineBehaviour
{

    public float m_Damping = 0.15f;

    private readonly int m_HorizontalParameter = Animator.StringToHash("Horizontal");
    private readonly int m_VerticalParameter = Animator.StringToHash("Vertical");

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 input = new Vector2(horizontal, vertical).normalized; 
        animator.SetFloat(m_HorizontalParameter, input.x, m_Damping, Time.deltaTime);
        animator.SetFloat(m_VerticalParameter, input.y, m_Damping, Time.deltaTime);
    }
}
