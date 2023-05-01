// Bibliotheken importieren
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Klasse anlegen (erbt von Klasse MonoBehavior)
public class PlayerController : MonoBehaviour
{
    // Rigidbody der Figur festlegen
    // Rigidbody 2D ist eine Unity-Komponente, die die Physik für die Figur (Bewegung...) berechnet
    public Rigidbody2D rb2D;

    // Variable: Ist die Figur auf dem Boden?
    private bool grounded = true;
    
    // Funktion, wird aufgerufen, wenn die Figur auf einem Collider (Kollisionserkennung) ist
    private void OnTriggerStay2D(Collider2D collision) 
    {
        // Figur ist auf dem Boden
        grounded = true;
    }

    // Funktion, wird aufgerufen, wenn die Figur einen Collider betritt
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        // Figur betritt den Boden
        grounded = true;
    }

    // Funktion, wird aufgerufen, wenn die Figur einen Collider verlässt (z. B. Springen)
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Figur verlässt den Boden
        grounded = false;
    }

    // Funktion, die bei jedem Frame ausgeführt wird
    void Update()
    {
        // Tastatureingabe verarbeiten
        ProcessInput();
        // Ist die Figur tot?
        CheckIfDead();
    }

    // Funktion, die überprüft, ob die Figur stirbt
    void CheckIfDead()
    {
        // Wenn die Figur unten rausfällt...
        if(transform.position.y < -13f)
        {
            // ... dann von vorne beginnen
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Funktion, für die Tastatureingabe
    void ProcessInput()
    {
        // Figur anhalten (horizontale Geschwindigkeit auf 0)
        rb2D.velocity = new Vector2(0, rb2D.velocity.y);

        // Wenn die rechte Pfeiltaste gedrückt wird...
        if(Input.GetKey(KeyCode.RightArrow))
        {
            // ... horizontale Geschwindigkeit der Figur auf 10 setzen
            rb2D.velocity = new Vector2(10, rb2D.velocity.y);
        }

        // Wenn die linke Pfeiltaste gedrückt wird...
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            // ... horizontale Geschwindigkeit der Figur auf -10 setzen
            rb2D.velocity = new Vector2(-10, rb2D.velocity.y);
        }

        // Wenn die Leertaste gedrückt wird und die Figur auf dem Boden steht...
        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            // ... vertikale Kraft hinzufügen, um die Figur springen zu lassen
            rb2D.AddForce(new Vector2(0, 600));
        }
    }
}
