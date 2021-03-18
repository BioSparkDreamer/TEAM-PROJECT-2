using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Rune : MonoBehaviour
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	private void OnTriggerEnter(Collider other)
    {
        PlayerRunes controller = other.GetComponent<PlayerRunes>();
		if (controller != null)
        {
            Destroy(gameObject);
            controller.ChangeRunes();
            controller.PlayAudioForRunes();
        }
    }
}