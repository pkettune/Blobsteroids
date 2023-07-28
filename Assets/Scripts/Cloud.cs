using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
	public Sprite[] sprites;
	public float size = 1.0f;
	public float minSize = 0.4f;
	public float maxSize = 1.6f;
	public float speed = 50.0f;
	public float maxLifetime = 30.0f;
	private SpriteRenderer _spriterenderer;
	private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _spriterenderer = GetComponent<SpriteRenderer>();
		_rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _spriterenderer.sprite = sprites[Random.Range(0, sprites.Length)];
		//										(x, y, z)
		this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
		this.transform.localScale = Vector3.one * this.size;

		_rigidbody.mass = this.size * 2;
    }

	public void SetTrajectory(Vector2 direction)
	{
		_rigidbody.AddForce(direction * this.speed);

		Destroy(this.gameObject, this.maxLifetime);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Bullet")
		{
			if ((this.size * 0.5f) >= this.minSize)
			{
				CreateSplit();
				CreateSplit();
			}
			Destroy(this.gameObject);
		}
	}

	private void CreateSplit()
	{
		Vector2 position = this.transform.position;
		position += Random.insideUnitCircle * 0.5f;
		
		Cloud half = Instantiate(this, position, this.transform.rotation);
		half.size = this.size * 0.6f;
		half.SetTrajectory(Random.insideUnitCircle.normalized * this.speed);
	}
}