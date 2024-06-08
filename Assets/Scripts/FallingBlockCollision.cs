
using UnityEngine;

public class FallingBlockCollision : MonoBehaviour
{
	Rigidbody2D rigidBody;
	BoxCollider2D box;
	AudioSource audioSource;
	LayerMask groundMask;
	int groundLayer;


	void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();
		box = GetComponent<BoxCollider2D>();
		audioSource = GetComponent<AudioSource>();

		groundMask = LayerMask.GetMask("Ground");
		groundLayer = LayerMask.NameToLayer("Ground");
	}

	public void Fall()
	{
		rigidBody.bodyType = RigidbodyType2D.Dynamic;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != groundLayer)
            return;

        Vector3 pos = rigidBody.position;
        RaycastHit2D hit;

        hit = Physics2D.Raycast(pos, Vector2.down, 1f, groundMask);
        pos.y = hit.point.y + .5f;
        transform.position = pos;

        box.isTrigger = false;
        Destroy(rigidBody);

        audioSource.Play();

    }
	
}
