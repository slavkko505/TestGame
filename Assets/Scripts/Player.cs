using UnityEngine;

public class Player : MonoBehaviour 
{
	[SerializeField] float bulletSpeed = 5.0f;
	[SerializeField] Transform bulletSpawnPos;
	[SerializeField] GameObject bulletPrefab;
	[SerializeField] Vector3 minScale = new Vector3(0.2f, 0.2f, 0.2f);

	public bool IsCanShoot { get; private set; } = true;
	GameObject bullet;

	
	public float GetPathWidth() {
		return transform.localScale.x + 0.3f;
	}

	public float GetBulletWidth() {
		return bullet != null ? bullet.transform.localScale.x : 0;
	}

	public void InitShoot() {
		bullet = Instantiate(bulletPrefab, bulletSpawnPos.position, Quaternion.identity, null);
		bullet.transform.localScale = minScale;
		transform.localScale -= minScale;
	}

	public void OnHold(float holdTime, float coef) {
		if (bullet == null)
			return;

		Vector3 scaleChange = Vector3.one * holdTime / 100f;
		bullet.transform.localScale += scaleChange;
		transform.localScale -= scaleChange * coef;

		if (transform.localScale.x < minScale.x) {
			Destroy(bullet);
			GameManager.instance.OnLose();
		}
	}

	public void Shoot(Vector3 pos) {
		
		if (bullet == null)
			return;

		Rigidbody rb = bullet.GetComponent<Rigidbody>();
		Vector3 velocity = (pos - rb.transform.position).normalized;
		velocity.y = 0.0f;
		rb.velocity = velocity.normalized * bulletSpeed;
		bullet = null;
	}
}
