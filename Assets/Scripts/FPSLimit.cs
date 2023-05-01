// Bibliotheken importieren
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Klasse anlegen (erbt von Klasse MonoBehavior)
public class FPSLimit : MonoBehaviour
{
    // Methode erstellen zum Festlegen der maximalen Bildrate beim Start
    void Start()
    {
        Application.targetFrameRate = 60;
    }

}
