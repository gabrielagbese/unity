//Start by creating a new C# script in Unity and naming it something like "CarController". 
//Add the following code to define the "gameStarted" variable and control the car's movement:

public class CarController : MonoBehaviour
{
    private bool gameStarted = false;

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {
            // Allow the car to be controlled
            // Add your code here to move the car
        }
        else
        {
            // Wait for the player to press the Enter key to start the game
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gameStarted = true;
            }
        }
    }
}

//Add a UI text object to the scene and name it "StartText". Set its position, font size, and color as desired. 
//Add the following code to the CarController script to display the "START THE GAME [ENTER]" message:

public Text startText;

void Start()
{
    startText.text = "START THE GAME [ENTER]";
}


// Add three obstacle objects to the scene, positioning them at different locations on the road.

// Use Unity's Random class to generate five different locations for the coins each time the game runs. 
// Add a new script to the coin object and name it something like "CoinController".
//  Add the following code to generate the random locations and keep track of the number of coins collected:

public class CoinController : MonoBehaviour
{
    private int numCoinsCollected = 0;
    private int maxCoins = 5;
    private Vector3[] coinLocations = new Vector3[5];

    void Start()
    {
        // Generate five random locations for the coins
        for (int i = 0; i < maxCoins; i++)
        {
            float x = Random.Range(-5.0f, 5.0f);
            float y = 0.5f;
            float z = Random.Range(-5.0f, 5.0f);
            coinLocations[i] = new Vector3(x, y, z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Update the number of coins collected and speed of the car
            numCoinsCollected++;
            other.gameObject.GetComponent<CarController>().UpdateSpeed(numCoinsCollected);

            // Respawn the coin at a new random location
            if (numCoinsCollected < maxCoins)
            {
                transform.position = coinLocations[numCoinsCollected];
            }
            else
            {
                // All coins have been collected
                gameObject.SetActive(false);
            }
        }
    }
}


//Make sure the car cannot fall off the track by adding a collider to the road and setting it as a trigger. 
//Add the following code to the CarController script to respawn the car at the last coin collected if it falls off:

void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("OutOfBounds"))
    {
        // Respawn at the last coin collected
        transform.position = coinLocations[numCoinsCollected - 1];
    }
}

//Add a UI text object to the scene and name it "LivesText". Set its position, font size, and color as desired.
// Add the following code to the CarController script to display the current number of lives:

public Text livesText;
private int numLives = 3;

void Start()
{
    UpdateLivesText();
}

void UpdateLivesText()
{
    lives
}