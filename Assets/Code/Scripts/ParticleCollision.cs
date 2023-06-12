using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
	public ParticleSystem collisionParticleSystem;
	public bool once = true;

	TutorialManager tutorialManager;

	private void OnEnable()
	{
		tutorialManager = FindObjectOfType<TutorialManager>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{

			var em = collisionParticleSystem.emission;
			var dur = collisionParticleSystem.main.duration;

			em.enabled = true;

			collisionParticleSystem.Play();

			once = false;

			tutorialManager.popUpIndex++;
		}
	}
}
