//Add a new UI Text object to the scene, and position it on the screen wherever you want the "game over" message to be displayed. 
//Also add a new UI Text object to display the number of lives.

//Add new public Text fields to the GameControllerScript to reference the game over and lives text objects,
// and to keep track of the number of lives:

public class GameControllerScript : MonoBehaviour
{
    public Text gameoverText; // Drag and drop the game over text object onto this field in the Inspector
    public Text livesText; // Drag and drop the lives text object onto this field in the Inspector
    private int numLives = 3;

    // Rest of the code...
}


//3,In the Inspector window, drag and drop the game over and lives text objects
// from the Hierarchy onto the appropriate fields in the GameControllerScript component.

//4,Modify the UpdateLivesText() method in the GameControllerScript to update the lives text:

void UpdateLivesText()
{
    livesText.text = "Lives: " + numLives + " / 3";
}


//Modify the PlayerDied() method in the GameControllerScript to reduce the number of lives,
// update the lives text, and either end the game or respawn the player:

public void PlayerDied()
{
    numLives--;
    UpdateLivesText();

    if (numLives <= 0)
    {
        player.SetActive(false); // Deactivate the player object
        gameoverText.gameObject.SetActive(true); // Activate the game over text object
    }
    else
    {
        // Respawn the player
        player.transform.position = lastCoinPosition; // Move the player to the last coin position
        player.SetActive(true); // Reactivate the player object
    }
}

//Add your code to the GameControllerScript's RespawnPlayer() method to reset the number of lives and update the lives text:

void RespawnPlayer()
{
    numLives = 3; // Reset the number of lives
    UpdateLivesText(); // Update the lives text

    // Add your code here to respawn the player
}

//Modify the GameOver() method in the GameControllerScript to display the game over text and deactivate the player object:

void GameOver()
{
    player.SetActive(false); // Deactivate the player object
    gameoverText.gameObject.SetActive(true); // Activate the game over text object
}


//Certainly! Here's an updated PlayerControllerScript that includes code to inform the GameControllerScript when the player dies:
public class PlayerControllerScript : MonoBehaviour
{
    private GameControllerScript gameController;
    private Rigidbody rb;

    // Rest of the code...

    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameControllerScript>();
        rb = GetComponent<Rigidbody>();
    }

    // Rest of the code...

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            lastCoinPosition = other.transform.position;
            numCoins++;

            // Increase the car speed when a coin is picked up
            carSpeed += speedIncreasePerCoin;
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            gameController.PlayerDied(); // Inform the game controller that the player has died
        }
    }

    // Rest of the code...
}
