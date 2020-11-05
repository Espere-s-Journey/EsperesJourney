﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlate : MonoBehaviour {

    [SerializeField] private GameObject door;
    [SerializeField] private Key.KeyType keyType;
    private ITriggerable triggeredItem;

    private void Start() {
        triggeredItem = door.GetComponent<ITriggerable>();
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        KeyHolder keyHolder = collider.GetComponent<KeyHolder>();
        if (keyHolder != null && keyHolder.ContainsKey(keyType)) {
            triggeredItem.TriggerExecute();
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        KeyHolder keyHolder = collider.GetComponent<KeyHolder>();
        if (keyHolder != null) {
            triggeredItem.TriggerRelease();
        }
 
    }
}
