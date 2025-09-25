using Microsoft.Data.Sqlite;
using MusicDbEditor.Models;
using System.Runtime.CompilerServices;
using System.Windows;

namespace MusicDbEditor.Services
{
    
    internal class DataConnection : DataConnectionInterface
    {
        #region Properties

        /// <summary>
        /// Private backer for DataSource.
        /// </summary>
        private string _dataSource;

        /// <summary>
        /// Path the the SQLite database.
        /// </summary>
        public string DataSource 
        {
            get {  return _dataSource; } 

            set
            {
                // if current value is the same as new value, no point in updating info
                if (String.Equals(_dataSource, value)) return;
                // update the value
                _dataSource = value;
                // rebuild the connection string
                UpdateSqliteConnectionString();
            }
        }

        /// <summary>
        /// Private backer for Mode.
        /// </summary>
        private SqliteOpenMode _mode;

        /// <summary>
        /// Mode to open the database in.
        /// </summary>
        public SqliteOpenMode Mode
        {
            get { return _mode; }

            set
            {
                // if current value is the same as new value, no point in updating info
                if (_mode == value) return;
                // update the value
                _mode = value;
                // rebuild the connection string
                UpdateSqliteConnectionString();
            }
        }

        /// <summary>
        /// Private backer for CacheMode.
        /// </summary>
        private SqliteCacheMode _cacheMode;

        /// <summary>
        /// Cache mode to be used for the database.
        /// </summary>
        public SqliteCacheMode CacheMode
        {
            get { return _cacheMode; }

            set
            {
                // if current value is the same as new value, no point in updating info
                if (_cacheMode == value) return;
                // update the value
                _cacheMode = value;
                // rebuild the connection string
                UpdateSqliteConnectionString();
            }
        }

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
            Mode = SqliteOpenMode.ReadWriteCreate;
            CacheMode = SqliteCacheMode.Default;

            UpdateSqliteConnectionString();
        }

        #endregion

        #region DB Methods
        public void CreateNewDB()
        {
            try
            {
                // open connection to db
                using (var connection = new SqliteConnection(ConnectionString.ToString()))
                {
                    connection.Open();

                    // create the command that creates the db
                    var command = connection.CreateCommand();
                    command.CommandText =
                        @"
                            CREATE TABLE IF NOT EXISTS album 
                                (id INTEGER PRIMARY KEY, name TEXT NOT NULL, sort_name TEXT, database_link TEXT, purchase_link TEXT);
                            CREATE TABLE IF NOT EXISTS source_media 
                                (id INTEGER PRIMARY KEY, name TEXT NOT NULL, sort_name TEXT);
                            CREATE TABLE IF NOT EXISTS track
                                (
	                                id INTEGER PRIMARY KEY, 
	                                name TEXT NOT NULL, 
	                                name_in_stream_player TEXT, 
	                                album_id INTEGER, 
	                                link TEXT, 
	                                notes TEXT, 
	                                source_media_id INTEGER, 
	                                FOREIGN KEY (album_id) REFERENCES album (id) 
		                                ON UPDATE CASCADE 
		                                ON DELETE RESTRICT, 
	                                FOREIGN KEY (source_media_id) REFERENCES source_media (id) 
		                                ON UPDATE CASCADE 
		                                ON DELETE RESTRICT
	                            );
                        ";
                    var returnValue = command.ExecuteNonQuery();
                }
            }
            catch (SqliteException e)
            {
                MessageBox.Show($"There was an error creating the database.\nError info:\n {e.Message}");
            }

        }

        #endregion 

        #region Helper Methods

        /// <summary>
        /// Builds the SQLite connection string based on
        /// </summary>
        private void UpdateSqliteConnectionString()
        {
            ConnectionString = new SqliteConnectionStringBuilder()
            {
                DataSource = DataSource,
                Mode = Mode,
                Cache = CacheMode,
            };
        }

        /// <summary>
        /// Checks if a string is null or only whitespace and returns an empty string in those cases. Else, returns the string.
        /// </summary>
        /// <param name="value">The string to check for null or only whitespaces.</param>
        /// <returns>An empty string if provided string is null or only whitespace, otherwise the string.</returns>
        internal string GetTextStringForDb(string value)
        {
            return String.IsNullOrWhiteSpace(value) ? "" : value;
        }

        #endregion

        #region Track Methods

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

        #endregion

        #region Album Methods

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

        /// <summary>
        /// Inserts a row into the Album table with the provided info.
        /// </summary>
        /// <param name="album">The album data that is being inserted.</param>
        /// <returns>The album that was inserted if successful. Null otherwise</returns>
        public Album InsertAlbum(Album album)
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
                                (@id, @name, @sortName, @databaseLink, @purchaseLink);
                        ";

                    // bind the values to the parameters
                    /*command.Parameters.AddWithValue("@id", DBNull.Value);
                    command.Parameters.AddWithValue("@name", album.Name);
                    command.Parameters.AddWithValue("@sortName", album.SortName);
                    command.Parameters.AddWithValue("@databaseLink", album.DatabaseLink);
                    command.Parameters.AddWithValue("@purchaseLink", album.PurchaseLink);*/


                    command.Parameters.Add("@id", SqliteType.Integer).Value = DBNull.Value;
                    command.Parameters.Add("@name", SqliteType.Text).Value = album.Name;
                    command.Parameters.Add("@sortName", SqliteType.Text).Value = (String.IsNullOrEmpty(album.SortName) ? "" : album.SortName);
                    command.Parameters.Add("@databaseLink", SqliteType.Text).Value = (String.IsNullOrEmpty(album.DatabaseLink) ? "" : album.DatabaseLink);
                    command.Parameters.Add("@purchaseLink", SqliteType.Text).Value = (String.IsNullOrEmpty(album.PurchaseLink) ? "" : album.PurchaseLink);


                    // execute statement
                    var numRowInserted = command.ExecuteNonQuery();
                    return album;
                }
            }
            catch (SqliteException e)
            {
                MessageBox.Show($"There was an error inserting the row.\nError text:\n{e}");
            }
            return null;
        }


        public Album UpdateAlbum(Album album)
        {
            try
            {
                // open the db
                using (var connection = new SqliteConnection(ConnectionString.ToString()))
                {
                    connection.Open();

                    // create command for update
                    var command = connection.CreateCommand();
                    command.CommandText =
                        @"
                            UPDATE
                                album
                            SET
                                name = @name,
                                sort_name = @sortName,
                                database_link = @databaseLink,
                                purchase_link = @purchaseLink
                            WHERE
                                id = @id;
                        ";
                    // bind the values
                    command.Parameters.Add("@name", SqliteType.Text).Value = GetTextStringForDb(album.Name);
                    command.Parameters.Add("@sortName", SqliteType.Text).Value = GetTextStringForDb(album.SortName);
                    command.Parameters.Add("@databaseLink", SqliteType.Text).Value = GetTextStringForDb(album.DatabaseLink);
                    command.Parameters.Add("@purchaseLink", SqliteType.Text).Value = GetTextStringForDb(album.PurchaseLink);
                    command.Parameters.Add("@id", SqliteType.Integer).Value = album.Id;

                    // execute statement
                    var numRowUpdated = command.ExecuteNonQuery();
                    return album;
                }
            }
            catch (SqliteException e)
            {
                MessageBox.Show($"There was an error updating the row.\nError text:\n{e}");
            }
            return null;
        }


        #endregion

        #region Source Media Methods

        public List<SourceMedia> GetSourceMediaData()
        {
            List<SourceMedia> result = new List<SourceMedia>();

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
                                id, name, sort_name
                            FROM source_media;";

                    // read the results into objects and put them into a list
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new SourceMedia()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                SortName = reader.GetString(2),
                            });
                        }
                    }
                }
            }
            catch (SqliteException e) 
            {
                MessageBox.Show($"There was an error inserting the row.\nError text:\n{e}");
            }
            return result;
        }

        public SourceMedia InsertSourceMedia(SourceMedia sourceMedia)
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
                                source_media
                            VALUES
                                (@id, @name, @sortName);
                        ";

                    // bind the values to the parameters
                    command.Parameters.Add("@id", SqliteType.Integer).Value = DBNull.Value;
                    command.Parameters.Add("@name", SqliteType.Text).Value = sourceMedia.Name;
                    command.Parameters.Add("@sortName", SqliteType.Text).Value = sourceMedia.SortName;

                    // execute statement
                    var numRowInserted = command.ExecuteNonQuery();
                    return sourceMedia;
                }
            }
            catch (SqliteException e)
            {
                MessageBox.Show($"There was an error inserting the row.\nError text:\n{e}");
            }
            return null;
        }

        #endregion
    }
}
