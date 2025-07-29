using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDbEditor.Models
{
    /// <summary>
    /// Represents info needed to display in Track tab
    /// </summary>
    internal class Track
    {

        #region Properties

        /// <summary>
        /// The id of this track from the database
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of this Track
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name in the steam player for this track
        /// </summary>
        public string NameInStreamPlayer { get; set; }

        /// <summary>
        /// The name of the album this track is from
        /// </summary>
        public string AlbumName { get; set; }

        /// <summary>
        /// A link to listen to this track at.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Arbitrary text the user decided was important enough to write down
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// The name of the piece of media this track originates from
        /// </summary>
        public string SourceMediaName { get; set; }

        #endregion

        /// <summary>
        /// Constructs a Track object with given parameters.
        /// </summary>
        /// <param name="id">The primary key from the record.</param>
        /// <param name="name">The name of the track.</param>
        /// <param name="nameInStreamPlayer">The name in the stream player of the track.</param>
        /// <param name="albumName">The name of the album the track is on.</param>
        /// <param name="link">A link to listen to the track.</param>
        /// <param name="notes">The notes about a track.</param>
        /// <param name="sourceMediaName">The name of the source media this track is from.</param>
        public Track(int id, string name, string nameInStreamPlayer, string albumName,
            string link, string notes, string sourceMediaName)
        {
            Id = id;
            Name = name;
            NameInStreamPlayer = nameInStreamPlayer;
            AlbumName = albumName;
            Link = link;
            Notes = notes;
            SourceMediaName = sourceMediaName;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Track() { }


    }
}
