using System.Collections.Generic;
using UnityEngine;

namespace VD
{
    public abstract class StateMachineBehavior : MonoBehaviour, IStateMachine
    {
        [SerializeField] private List<GameObject> m_views;
        protected StateMachine stateMachine { private set; get; }

      	void IStateMachine.Init(StateMachine stateMachine)
		{
			this.stateMachine = stateMachine;
		}

		void IStateMachine.Enter()
		{
			gameObject.SetActive(true);
			OnEnter();
		}

		void IStateMachine.Exit()
		{
			gameObject.SetActive(false);
			OnExit();
		}

		public IReadOnlyList<GameObject> GetViews() => m_views;

		protected virtual void OnExit()
		{
			
		}

		protected virtual void OnEnter()
		{
			
		}
    }
}
