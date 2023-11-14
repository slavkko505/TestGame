using UnityEngine;

public class ParticleExplosion : MonoBehaviour
{
   [SerializeField] private ParticleSystem mainParticle;
   [SerializeField] private ParticleSystem[] sparks;

   public void SetParticleWidth(float scale)
   {
      foreach (var child in sparks)
      {
         child.transform.localScale = new Vector3(scale, scale, scale);
      }
   }

   public void StartExplosion()
   {
      mainParticle.Play();
   }
}
