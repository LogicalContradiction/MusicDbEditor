namespace MusicDbEditor.Models
{
    
    /// <summary>
    /// Represents info needed to display in Album tab
    /// </summary>
    class Album
    {
        #region Properties

        /// <summary>
        /// The id of this album from the database
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of this album
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name used when sorting the albums alphabetically
        /// </summary>
        public string SortName { get; set; }

        /// <summary>
        /// A link to an external database containing information about this album
        /// </summary>
        public string DatabaseLink { get; set; }

        /// <summary>
        /// A link to a site to purchase this album
        /// </summary>
        public string PurchaseLink { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs an album with the given values.
        /// </summary>
        /// <param name="id">The id of this album in the database</param>
        /// <param name="name">The name of the album</param>
        /// <param name="sortName">The name used to sort alphabetically</param>
        /// <param name="databaseLink">A link to an external database with information on this album</param>
        /// <param name="purchaselink">A link to purchase this album</param>
        public Album(int id, string name, string sortName, string databaseLink, string purchaselink)
        {
            Id = id;
            Name = name;
            SortName = sortName;
            DatabaseLink = databaseLink;
            PurchaseLink = purchaselink;

        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Album() { }

        #endregion

    }
}
