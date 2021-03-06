// Digx7
// This script activates an event if it detected something in its collider or trigger
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectSensor : MonoBehaviour {

    public enum mode { Collider, Trigger }

    [Header("Main")]
    [Tooltip("Collider: for if you have a generic 2D box collider attached.\nTrigger: for if you have the collider set as a trigger.")]
    [SerializeField] private mode sensorMode = mode.Collider;

    [Tooltip("Set this is you want to detect everything regardless of any tags.")]
    [SerializeField] private bool detectEverything = false;

    [Tooltip("Set the tag of any objects this sensor is looking for.")]
    [SerializeField] private List<string> tagsToListenFor;

    [Space]
    [Header("Events")]
    [SerializeField] private UnityEvent detectedSomething;

    private Collision2D lastCollision2D;
    private Collider2D lastCollider2D;

    // --- Events ----------------------------------------------

    public void InvokeDetectedSomething() {
        detectedSomething.Invoke();
    }

    // --- Confermation Functions ------------------------------

    public bool isThisAnObjectToWatchFor_Collision(Collision2D col) {
        foreach (string _tag in tagsToListenFor) {
            if (col.gameObject.tag == _tag) return true;
        }
        return false;
    }

    public bool isThisAnObjectToWatchFor_Collider(Collider2D col) {
        foreach (string _tag in tagsToListenFor) {
            if (col.gameObject.tag == _tag) return true;
        }
        return false;
    }

    // --- Get variables -------------------------------------------

    public Collision2D getLastCollision2D() {
        return lastCollision2D;
    }

    public Collider2D getLastCollider2D() {
        return lastCollider2D;
    }

    public bool getDetectEverything() {
        return detectEverything;
    }

    // --- Collisions --------------------------------------------

    public void OnCollisionEnter2D(Collision2D col) {
        if (getDetectEverything() || isThisAnObjectToWatchFor_Collision(col))
            InvokeDetectedSomething();
    }

    // Triggers when the player collides with a trigger
    public void OnTriggerEnter2D(Collider2D col) {
        if (getDetectEverything() || isThisAnObjectToWatchFor_Collider(col))
            InvokeDetectedSomething();
    }
}