// This script handles detecting collisions with traps and telling the Game Manager
// when the player dies

using System.Collections;

using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
	
	public GameObject deathVFXPrefab;   //The visual effects for player death
    public float startingHealth;
    public float currentHealth { get; private set; }
    bool isAlive = true;				//Stores the player's "alive" state
	int trapsLayer;
    private Animator anim;
    private bool dead;

    [Header("Iframe")]
    [SerializeField] private float IframesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer sprite;


	void Start()
	{
        currentHealth = startingHealth;
        //Get the integer representation of the "Traps" layer
        trapsLayer = LayerMask.NameToLayer("Traps");
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
	}

    private void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.P))
        {
            takeDamage(1);
        }
    }

    public void takeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
            StartCoroutine(Invisibility());
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("Die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
                StartCoroutine(beforeDead());   
            }
            
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
	{
		//If the collided object isn't on the Traps layer OR if the player isn't currently
		//alive, exit. This is more efficient than string comparisons using Tags
		if (collision.gameObject.layer != trapsLayer || !isAlive)
			return;
		DeadPlayer();
		
	}

	public void DeadPlayer()
	{
        //Trap was hit, so set the player's alive state to false
        isAlive = false;

        //Instantiate the death particle effects prefab at player's location
        Instantiate(deathVFXPrefab, transform.position, transform.rotation);

        //Disable player game object
        gameObject.SetActive(false);

        //Tell the Game Manager that the player died and tell the Audio Manager to play
        //the death audio
        GameManager.PlayerDied();
        AudioManager.PlayDeathAudio();
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private IEnumerator Invisibility()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++) {
            sprite.color = new Color(1, 1, 1, 0.5f);
            yield return new WaitForSeconds(IframesDuration/ (numberOfFlashes *2));
            sprite.color = Color.white;
            yield return new WaitForSeconds(IframesDuration / (numberOfFlashes * 2));
        }

        Physics2D.IgnoreLayerCollision(10, 11, false);
    }

    private IEnumerator beforeDead()
    {
        yield return new WaitForSeconds(1f);
        DeadPlayer();
    }
}
