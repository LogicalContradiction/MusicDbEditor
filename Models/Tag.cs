

namespace MusicDbEditor.Models
{
    /// <summary>
    /// Represents a piece of data used to label more data
    /// </summary>
    public class Tag
    {
        #region Properties

        /// <summary>
        /// Database-assigned number used to uniquely identify this tag
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The text that represents this label.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of the category this tag belongs to.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// String describing what the tag represents.
        /// </summary>
        public string Description { get; set; }

        #endregion

        #region Constructor

        public Tag() { }

        #endregion

    }
}
