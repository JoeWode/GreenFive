using UnityEngine;
using System.Collections;

namespace G5
{
    public class GameManager_PseudoPause : MonoBehaviour 
    {
	
		private GameManager_Master gameManagerMaster;
		private GameObject[] animatedObjs;
		private GameObject[] enemyObjs;
		private Animator[] anims;
		private Animator[] enemyAnims;
		private NavMeshAgent[] navAgents;
		private GameObject[] particleObjs;
		private ParticleSystem[] particles;
		public bool isPseudoPaused = false;

		void OnEnable()
		{
			SetInitialReferences();
			gameManagerMaster.FungusEvent += TogglePseudoPause;
		}

		void OnDisable()
		{
			gameManagerMaster.FungusEvent -= TogglePseudoPause;
		}

		void SetInitialReferences()
		{
			gameManagerMaster = GetComponent<GameManager_Master>();

			animatedObjs = GameObject.FindGameObjectsWithTag ("pausable");
			enemyObjs = GameObject.FindGameObjectsWithTag ("Enemy");
			particleObjs = GameObject.FindGameObjectsWithTag("Particles");

			anims = new Animator[animatedObjs.Length];
			for(int i=0; i<animatedObjs.Length; i++)
			{
				anims[i] = animatedObjs[i].GetComponent<Animator>();
			}

			particles = new ParticleSystem[particleObjs.Length];
			for(int i=0; i<particleObjs.Length; i++)
			{
				particles[i] = particleObjs[i].GetComponent<ParticleSystem>();
			}
			
			enemyAnims = new Animator[enemyObjs.Length];
			for(int i = 0; i<enemyObjs.Length; i++)
			{
				enemyAnims[i] = enemyObjs[i].GetComponent<Animator>();
			}
			
			navAgents = new NavMeshAgent[enemyObjs.Length];
			for(int i = 0; i<enemyObjs.Length; i++)
			{
				if(enemyObjs[i].GetComponent<NavMeshAgent>() != null)
				{
					navAgents[i] = enemyObjs[i].GetComponent<NavMeshAgent>();
				}
			}
		}

		void TogglePseudoPause()
		{
			foreach(Animator anim in anims)
			{
				if(anim != null)
				{
					anim.enabled = !anim.enabled;
					if(anim.enabled)
					{
						foreach(ParticleSystem particle in particles)
						{
							if(particle != null)
							{
								particle.Pause();
							}
						}
					}
					else
					{
						foreach(ParticleSystem particle in particles)
						{
							if(particle != null)
							{
								particle.Play();
							}
						}
					}
				}
			}
			foreach(NavMeshAgent agent in navAgents)
			{
				if(agent != null)
				{
					agent.enabled = !agent.enabled;
				}
			}
			
			foreach(Animator anim in enemyAnims)
			{
				if(anim != null)
				{
					anim.enabled = !anim.enabled;
				}
			}
		}
    }
}

