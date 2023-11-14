using UnityEngine;

public class Bullet : MonoBehaviour 
{
	[SerializeField] ParticleExplosion explodePrefab;
	[SerializeField] private float coefSize;
	bool isExplode = false;

	private void OnDestroy() {
		if (isExplode)
			return;
		isExplode = true;
		
		ParticleExplosion explode = Instantiate(explodePrefab, transform.position, Quaternion.identity, null);
		explode.transform.position = new Vector3(transform.position.x,0.15f, transform.position.z);
		explode.SetParticleWidth(transform.localScale.x / coefSize);
		explode.StartExplosion();
	}
}
