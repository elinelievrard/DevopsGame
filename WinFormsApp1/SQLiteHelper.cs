using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using Dapper;

namespace T_Rex
{
    public static class SQLiteHelper
    {
        // For extra info, make sure you look at the ouput view for the debug.

        // Put the database in the current directory
        private static string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MyDatabase.db");
        private static string connectionString = $"Data Source={databasePath};Version=3;";

        public static void InitializeDatabase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Create a Scores table if it doesn't exist
                string createTableQuery = "CREATE TABLE IF NOT EXISTS Scores (ID INTEGER PRIMARY KEY AUTOINCREMENT, Score INTEGER)";
                using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            // output to show where the database is initialized
            System.Diagnostics.Debug.WriteLine($"Database Initialized. Path: {databasePath}");
        }

        // Function to clear all the scores so that you can set a new high score every time the application starts.
        public static void ClearScores()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM Scores";
                connection.Execute(deleteQuery);

                // Output to confirm all the scores are deleted
                System.Diagnostics.Debug.WriteLine("All scores deleted from the database.");
            }
        }

        public static void InsertScore(int scoreValue)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO Scores (Score) VALUES (@score)";
                connection.Execute(insertQuery, new { score = scoreValue });

                // output to confirm the scores are inserted in the database
                System.Diagnostics.Debug.WriteLine($"Score {scoreValue} inserted into the database.");
            }
        }

        public static int GetHighScore()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT MAX(Score) FROM Scores";
                return connection.ExecuteScalar<int>(selectQuery);
            }
        }
    }
}
