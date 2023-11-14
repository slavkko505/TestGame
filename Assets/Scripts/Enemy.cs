using UnityEngine;

public class Enemy : MonoBehaviour 
{
	[SerializeField] private ParticleSystem boom;
	[SerializeField] private CapsuleCollider collider;
	[SerializeField] private MeshRenderer meshCapsule;
	
	private void OnDestroy() {
		GameManager.instance.enemies.Remove(this);
		GameManager.instance.pathLine.enemiesInRange.Remove(this);
		LeanTween.cancel(gameObject, false);
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Bullet")) {
			LeanTween.delayedCall(gameObject, 0.1f, () => {
				if (other != null)
					Destroy(other.gameObject);
				meshCapsule.enabled = false;
				collider.enabled = false;
				if(!boom.isPlaying)
					boom.Play();
				Destroy(gameObject, 1.2f);
			});
		}
	}
	
}
