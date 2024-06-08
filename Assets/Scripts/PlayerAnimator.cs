using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private PlayerMovement mov;
    private Combat combat;
/*    private AudioManager audioManager;*/
    private Animator anim;
    private SpriteRenderer spriteRend;
    public PlayerData Data;
    private string currentState;
    public float x;
    public float y;


    //Animaton State
    const string PLAYER_IDLE = "Player_idle";
    const string PLAYER_RUN = "Player_run";
    const string PLAYER_JUMP = "Player_jump";
    const string PLAYER_DODGE = "Player_dodge";
    const string PLAYER_LAND = "Player_fall";
    const string PLAYER_DASH = "Player_dash";
    const string PLAYER_ATTACK = "Player_attack";




    /*    [Header("Particle FX")]
        [SerializeField] private GameObject jumpFX;
        [SerializeField] private GameObject landFX;
        private ParticleSystem _jumpParticle;
        private ParticleSystem _landParticle;*/


    private void Start()
    {
        mov = GetComponent<PlayerMovement>();
        spriteRend = GetComponentInChildren<SpriteRenderer>();
        anim = spriteRend.GetComponent<Animator>();
        combat = GetComponent<Combat>();
/*        audioManager = GetComponent<AudioManager>();*/

    }

    private void Update()
    {
        x = Mathf.Abs(mov.RB.velocity.x);
        y = Mathf.Abs(mov.RB.velocity.y);
    }

    private void LateUpdate()
    {
    

        CheckAnimationState();


    }

    private void ChangeAnimationState(string newState)
    {
        //stop the same animation
        if (currentState == newState) return;

        //play the animation
        anim.Play(newState);

        //reasing current animation state
        currentState = newState;
    }

    private void CheckAnimationState()
    {

        if(mov.IsJumping && mov.RB.velocity.y < 0)
        {
            ChangeAnimationState(PLAYER_LAND);
        }



        float absVelX = Mathf.Abs(mov.RB.velocity.x);
        if(!mov.IsJumping && !mov.IsDashing && !mov.IsSliding && mov.IsGrounded)
        {
            if (absVelX > 1)
            {
                ChangeAnimationState(PLAYER_RUN);
               

            }
            else
            {
                ChangeAnimationState(PLAYER_IDLE);
            }
        }
/*
        if (!mov.IsGrounded)
        {
            ChangeAnimationState(PLAYER_LAND);
        }*/

        if(mov.IsJumping && !mov.IsDashing && !mov.IsSliding)
        {
            ChangeAnimationState(PLAYER_JUMP);

        }  
        
        if(!mov.IsJumping && mov.IsDashing && !mov.IsSliding)
        {
            ChangeAnimationState(PLAYER_DODGE);
        }

    }

    public void StepAudio()
    {
        //Tell the Audio Manager to play a footstep sound
        AudioManager.PlayFootstepAudio();
    }

    public void JumpAudio()
    {
        //Tell the Audio Manager to play a footstep sound
        AudioManager.PlayJumpAudio();
    }

    public void attack()
    {
        AudioManager.PlaypipAttackAudio();
    }
}
