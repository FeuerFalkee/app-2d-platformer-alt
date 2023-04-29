// Importieren von Unity-Bibliotheken
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Definition der Klasse "PlayerController"
public class PlayerController : MonoBehaviour
{
    // Öffentliches Attribut, um den Rigidbody des Spielers festzulegen
    public Rigidbody2D rb2D;

    // Privates Attribut, um zu verfolgen, ob der Spieler auf dem Boden ist
    private bool grounded = true;
    
    // Funktion, die aufgerufen wird, wenn der Spieler auf einem anderen Objekt mit Collider landet und dort bleibt
    private void OnTriggerStay2D(Collider2D collision) 
    {
        // Setzt grounded auf true, um zu zeigen, dass der Spieler auf dem Boden ist
        grounded = true;
    }

    // Funktion, die aufgerufen wird, wenn der Spieler in einen anderen Collider eintritt
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        // Setzt grounded auf true, um zu zeigen, dass der Spieler auf dem Boden ist
        grounded = true;
    }

    // Funktion, die aufgerufen wird, wenn der Spieler den Collider eines anderen Objekts verlässt
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Setzt grounded auf false, um zu zeigen, dass der Spieler nicht auf dem Boden ist
        grounded = false;
    }

    // Funktion, die in jedem Frame ausgeführt wird
    void Update()
    {
        // Verarbeitet die Eingabe des Spielers
        ProcessInput();
        // Überprüft, ob der Spieler tot ist
        CheckIfDead();
    }

    // Funktion, die überprüft, ob der Spieler gestorben ist
    void CheckIfDead()
    {
        // Wenn der Spieler unter eine bestimmte Y-Position fällt...
        if(transform.position.y < -13f)
        {
            // ... lade die aktuelle Szene neu
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Funktion, die die Eingabe des Spielers verarbeitet
    void ProcessInput()
    {
        // Setzt die horizontale Geschwindigkeit des Spielers auf 0, um ihn anzuhalten
        rb2D.velocity = new Vector2(0, rb2D.velocity.y);

        // Wenn die rechte Pfeiltaste gedrückt wird...
        if(Input.GetKey(KeyCode.RightArrow))
        {
            // ... setze die horizontale Geschwindigkeit des Spielers auf 10
            rb2D.velocity = new Vector2(10, rb2D.velocity.y);
        }

        // Wenn die linke Pfeiltaste gedrückt wird...
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            // ... setze die horizontale Geschwindigkeit des Spielers auf -10
            rb2D.velocity = new Vector2(-10, rb2D.velocity.y);
        }

        // Wenn die Leertaste gedrückt wird und der Spieler auf dem Boden steht...
        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            // ... füge eine vertikale Kraft hinzu, um den Spieler zu springen
            rb2D.AddForce(new Vector2(0, 600));
        }
    }
}
