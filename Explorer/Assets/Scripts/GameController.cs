using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class GameController : MonoBehaviour {

	public Player player;
	public GameObject enemyContainer;
	public static bool GameIsPaused = false;
	public GameObject pauseUI;

	public Text healthText;
	public Text ammoText;
	public Text enemyText;
	public Text infoText;

	private bool gameOver = false;
	private float resetTimer = 2f;

	void Start () {
		pauseUI.SetActive(false);
		infoText.gameObject.SetActive (false);
		Cursor.visible = true;
	}

	void Update () {
		healthText.text = "Vida: " + player.Health;
		ammoText.text = "Balas: " + player.Ammo;
		int aliveEnemies = 0;
		foreach (Enemy enemy in enemyContainer.GetComponentsInChildren<Enemy>()) {
			if (enemy.Killed == false) {
				aliveEnemies++;
			}
		}
		enemyText.text = "inimigos: " + aliveEnemies;

		if (aliveEnemies == 0) {
			gameOver = true;
			infoText.gameObject.SetActive (true);
			infoText.text = "Voce ganhou!";
		}

		if (player.Killed == true) {
			gameOver = true;
			infoText.gameObject.SetActive (true);
			infoText.text = "Voce perdeu";
		}

		if (gameOver == true) {
			resetTimer -= Time.deltaTime;
			if (resetTimer <= 0) {
				SceneManager.LoadScene ("Menu");
			}
		}

	  if(Input.GetKeyDown(KeyCode.Escape)){
			if(GameIsPaused){
				Resume();
			}else{
				Pause();
				GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = false;
			}
		}
	}

	public void Resume(){
		pauseUI.SetActive(false);
		GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = true;
		Time.timeScale = 1;
		GameIsPaused = false;
	}

	void Pause(){
		pauseUI.SetActive(true);
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		Time.timeScale = 0;
		GameIsPaused = true;

	}

	public void Menu(){
		GameIsPaused = false;
		SceneManager.LoadScene ("Menu");
		Time.timeScale = 1;
	}
}
