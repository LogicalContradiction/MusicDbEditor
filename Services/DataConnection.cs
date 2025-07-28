using Microsoft.Data.Sqlite;
using MusicDbEditor.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MusicDbEditor.Services
{
    
    internal class DataConnection : DataConnectionInterface
    {
        #region Properties
        /// <summary>
        /// Singleton instance
        /// </summary>
        //public static DataConnection Instance { get; } = new DataConnection();

        /// <summary>
        /// Path the the SQLite database.
        /// </summary>
        public string DataSource { get; set; }

        /// <summary>
        /// Mode to open the database in.
        /// </summary>
        public SqliteOpenMode Mode { get; set; }

        /// <summary>
        /// The connection string to connect to the database
        /// </summary>
        public SqliteConnectionStringBuilder ConnectionString { get; private set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Private singleton constructor.
        /// </summary>
        public DataConnection()
        {
            DataSource = @"tests/testDB.db";
            Mode = SqliteOpenMode.ReadOnly; 

            ConnectionString = BuildSqliteConnectionString();
        }

        #endregion

        #region Static accessor
        /// <summary>
        /// Static accessor for singleton.
        /// </summary>
        //static DataConnection() { }

        #endregion 

        #region Helper Methods

        /// <summary>
        /// Builds the SQLite connection string based on
        /// </summary>
        private SqliteConnectionStringBuilder BuildSqliteConnectionString()
        {
            return new SqliteConnectionStringBuilder()
            {
                DataSource = DataSource,
                Mode = Mode,
            };
        }

        #endregion

        #region Data Retrieveal Methods

        /// <summary>
        /// Queries the database for track info. Also left joins on album and source media to get their names
        /// </summary>
        /// <returns>A list of Track objects representing the tracks in the database</returns>
        public List<Track> GetTrackData()
        {
            List<Track> result = new List<Track>();

            try
            {
                using (var connection = new SqliteConnection(ConnectionString.ToString()))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText =
                        @"
                            SELECT 
                                track.id, track.name, track.name_in_stream_player, album.name, track.link, track.notes, source_media.name
                            FROM track
                            LEFT JOIN album
                            ON track.album_id = album.id
                            LEFT JOIN source_media
                            ON track.source_media_id = source_media.id;";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Track()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                NameInStreamPlayer = reader.GetString(2),
                                AlbumName = reader.GetString(3),
                                Link = reader.GetString(4),
                                Notes = reader.GetString(5),
                                SourceMediaName = reader.GetString(6),
                            });
                        }
                    }
                }
            }
            catch (SqliteException e)
            {
                MessageBox.Show($"There was an error when accessing the database.\nError text: '{e}'");
            }
            return result;
        }

        /// <summary>
        /// Queries the database for album information
        /// </summary>
        /// <returns>A list of Album objects representing the albums in the database</returns>
        public List<Album> GetAlbumData()
        {
            List<Album> result = new List<Album>();

            try
            {
                // open connection to db
                using (var connection = new SqliteConnection(ConnectionString.ToString()))
                {
                    connection.Open();

                    // create and execute the query
                    var command = connection.CreateCommand();
                    command.CommandText =
                        @"
                            SELECT
                                id, name, sort_name, database_link, purchase_link
                            FROM album;";

                    // read the results into objects and put them into a list
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Album()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                SortName = reader.GetString(2),
                                DatabaseLink = reader.GetString(3),
                                PurchaseLink = reader.GetString(4),
                            });
                        }
                    }
                }
            }
            catch (SqliteException e) 
            {
                MessageBox.Show($"There was an error when accessing the database.\nError text: '{e}'");
            }
            return result;

        }


        #endregion

        #region Insert Data Methods

        /// <summary>
        /// Inserts a row into the Album table with the provided info.
        /// </summary>
        /// <param name="album">The album data that is being inserted.</param>
        public void InsertAlbum(Album album)
        {
            try
            {
                // open db connection
                using (var connection = new SqliteConnection(ConnectionString.ToString()))
                {
                    connection.Open();

                    // create and execute the insertion
                    var command = connection.CreateCommand();
                    command.CommandText =
                        @"
                            INSERT INTO
                                album
                            VALUES
                                (@name, @sortName, @databaseLink, @purchaseLink);
                        ";

                    // bind the values to the parameters
                    command.Parameters.AddWithValue("@name", album.Name);
                    command.Parameters.AddWithValue("@sortName", album.SortName);
                    command.Parameters.AddWithValue("@databaseLink", album.DatabaseLink);
                    command.Parameters.AddWithValue("@purchaseLink", album.PurchaseLink);

                    // execute statement
                    var numRowInserted = command.ExecuteNonQuery();
                }
            }
            catch (SqliteException e)
            {
                MessageBox.Show($"There was an error inserting the row.\nError text:\n{e}");
            }

        }

        #endregion
    }
}
