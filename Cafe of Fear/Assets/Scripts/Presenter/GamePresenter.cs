using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CafeOfFear
{
    public class GamePresenter : MonoBehaviour
    {
        private NPC_Main _NPC_Main;

        [Inject]
        public void Counstruct(NPC_Main npc_Main)
        {
            _NPC_Main = npc_Main;
        }

        public void Init()
        {
            _NPC_Main.gameObject.SetActive(false);

            StartCoroutine(StartEventWhitWait(5.0f, () =>
            {
                _NPC_Main.gameObject.SetActive(true);
                _NPC_Main.StartWalkToPlayer();                
            }));
        }

        private IEnumerator StartEventWhitWait(float waitTime, Action callback)
        {
            yield return new WaitForSeconds(waitTime);

            callback?.Invoke();
        }
    }
}
