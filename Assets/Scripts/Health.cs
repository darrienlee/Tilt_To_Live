using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameOverScreen GameOverScreen;

    //public ScoreScript score;
    public float maxHealth = 3;
    public float currentHealth;

    private bool isInvincible = false;

    [SerializeField] // lets you edit private members through unity inspector without making them public
    private float invincibilityDuration; // in seconds

    [SerializeField]
    private float invincibilityDeltaTime; // time to take for each flash in invincibility animation in seconds

    //[SerializeField]
    public GameObject model; // model of our player sprite to flash while invincible

    private IEnumerable coroutine;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        if (isInvincible) return;

        if (!isInvincible)
        {
            currentHealth -= amount;
            // coroutine = tempInvincible();
            // StartCoroutine(coroutine);
            StartCoroutine(tempInvincible());
            // tempInvincible();
        }

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            // Destroy(collision.gameObject);
            // play death animation and game over screen
            Pause();
            GameOver();
        }
    }

    public void GameOver() {
        //GameObject score = GameObject.Find("Score");
        //ScoreScript points = score.GetComponent<ScoreScript>();
        GameOverScreen.Setup(ScoreScript.scoreValue);
    }

    public void Pause() {
        //pauseMenuUI.SetActive(true);
        model.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Time.timeScale = 0f;
    }

    private IEnumerator tempInvincible()
    {
        isInvincible = true;
        //private float x = 0.1f;
        Vector3 flash1 = new Vector3(0.1f, 0.1f, 0.1f); // (x, x, x);

        for (float i = 0; i < invincibilityDuration; i += invincibilityDeltaTime)
        {
            // Alternate between 0 and 1 scale to simulate flashing
            if (model.transform.localScale == flash1)
            {
                ScaleModelTo(Vector3.zero);
            }
            else
            {
                ScaleModelTo(flash1);
            }
            yield return new WaitForSeconds(invincibilityDeltaTime);
        }

        //yield return new WaitForSeconds(invincibilityDuration);
        ScaleModelTo(flash1);
        isInvincible = false;
    }

    private void ScaleModelTo(Vector3 scale)
    {
        model.transform.localScale = scale;
    }
}
