using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPatrullarEnemigo : StateMachineBehaviour
{
    ControladorEnemigo controlador;
    [SerializeField] int destino = 0;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log("Entró a patrullar");
        controlador = animator.GetComponent<ControladorEnemigo>();
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log(controlador.Agt.remainingDistance);
        ////Debug.Log("Esta patrullar");
        //controlador.Agt.SetDestination(controlador.PosicionesPatrullaje[0].position);
        if (controlador.Agt.remainingDistance < 1) {
            destino++;

            if (destino > controlador.PosicionesPatrullaje.Count - 1) {
                destino = 0;

            }


           controlador.Agt.SetDestination(controlador.PosicionesPatrullaje[destino].position);


        }
        //controlador.Agt.remainingDistance();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log("Dejó de patrullar");

    }











    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
