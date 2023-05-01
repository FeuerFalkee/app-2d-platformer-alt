// Bibliotheken importieren
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Klasse anlegen (erbt von Klasse MonoBehavior)
public class PlayerFollower : MonoBehaviour
{
    // Referenziert die Figur, der die Kamera folgt
    public GameObject player;
    // Faktor der "weichen Bewegung" (Glättung) der Kameraführung
    public float smoothTime = 0.3F;

    // Bewegungsgeschwindigkeit der Kamera
    private Vector3 velocity = Vector3.zero;

    // Funktion, die bei jedem Frame ausgeführt wird
    void Update()
    {
        // Berechnung der Kameraposition
        Vector3 targetPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        // "Weiche Bewegung" der Kamera ausführen
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
