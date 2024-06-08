using UnityEngine;
using System.Collections;

public class FallingBlock : MonoBehaviour
{
	public FallingBlockCollision block;

	Animator anim;
	BoxCollider2D box;
	AudioSource audioSource;
	int playerLayer;
	int fallParamID;


	void Start()
	{
		anim = GetComponent<Animator>();
		box = GetComponent<BoxCollider2D>();
		audioSource = GetComponent<AudioSource>();

		playerLayer = LayerMask.NameToLayer("Player");
		fallParamID = Animator.StringToHash("Activate");
	}

	public void Fall()
	{
		block.Fall();
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer != playerLayer)
			return;

		box.enabled = false;
		audioSource.Play();
		anim.SetTrigger(fallParamID);
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);

    }
}
