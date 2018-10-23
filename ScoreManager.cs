using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    private string connectionString;
    private List<HighScore> highscores = new List<HighScore>();
    public GameObject scorePrefab;
    public Transform ScoreParent;
    public int topScores;
    public InputField enterName;
    public GameObject nameDialog;

	// Use this for initialization
	void Start () {

        connectionString = "URI=file:" + Application.dataPath + "/Highscore_db.sqlite";
        CreateTable();      
        DisplayScores();
	}
	
	// Update is called once per frame
	void Update () {
        //press esc to enter the name
        if (Input.GetKeyDown(KeyCode.Escape)) {
            nameDialog.SetActive(!nameDialog.activeSelf);
        }
	}
    //
    private void CreateTable() {

        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {

            dbConnection.Open();

            using (IDbCommand dbCommand = dbConnection.CreateCommand())
            {

                string sql = String.Format("CREATE TABLE if not exists Highscore (playerID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL UNIQUE,name Text NOT NULL,score INTEGER NOT NULL)");
                dbCommand.CommandText = sql;
                dbCommand.ExecuteScalar();
                dbConnection.Close();
            }
        }
    }

    public void EnterName() {

        // Ensure that the name is not null
        if (enterName.text != string.Empty) {

            //generating random scores
            int score = UnityEngine.Random.Range(1, 500);
            InsertScore(enterName.text, score);
            // Text field will be empty after enter a name
            enterName.text = string.Empty;

            DisplayScores();
        }
    }
    //to insert the score
    private void InsertScore(string name, int newScore)
    {
        // set up database connection
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {

            dbConnection.Open();
            //using sql statement to insert a score
            using (IDbCommand dbCommand = dbConnection.CreateCommand())
            {
               
                string sql = String.Format("INSERT INTO Highscore(Name,Score) VALUES(\"{0}\",\"{1}\")",name,newScore);
                dbCommand.CommandText = sql;
                dbCommand.ExecuteScalar();
                dbConnection.Close();
            }
        }
    }

    // to read scores from database
    private void GetScores() {

        highscores.Clear();

        using (IDbConnection dbConnection = new SqliteConnection(connectionString)) {

            dbConnection.Open();

            using (IDbCommand dbCommand = dbConnection.CreateCommand()) {

                string sql = "SELECT * FROM Highscore";
                dbCommand.CommandText = sql;

                using (IDataReader reader = dbCommand.ExecuteReader()) {

                    while (reader.Read()) {

                        highscores.Add(new HighScore(reader.GetInt32(0), reader.GetInt32(2), reader.GetString(1)));
            
                    }

                    dbConnection.Close();
                    reader.Close();
                }
            }
        }

        highscores.Sort();
    }
    //to delete a a score with its id
    private void DeleteScore(int id) {
        //set up connections to the database
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {

            dbConnection.Open();

            using (IDbCommand dbCommand = dbConnection.CreateCommand())
            {

                string sql = String.Format("DELETE from Highscore WHERE playerID = \"{0}\"", id);
                dbCommand.CommandText = sql;
                dbCommand.ExecuteScalar();
                dbConnection.Close();
            }
        }

    }

    //to display the score on the page
    private void DisplayScores() {

        GetScores();
        // delete the remaining score first
        foreach (GameObject score in GameObject.FindGameObjectsWithTag("Score")) {

            Destroy(score);
        }
        //read the scores
        for (int i = 0; i < topScores; i++) {

            if (i <= highscores.Count - 1) {

                GameObject gameObject = Instantiate(scorePrefab);
                HighScore tempScore = highscores[i];

                gameObject.GetComponent<ScoreScript>().SetScore(tempScore.Name, tempScore.score.ToString(), "No." + (i + 1).ToString());
                gameObject.transform.SetParent(ScoreParent);
                gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            }

            
        }
    }
}


