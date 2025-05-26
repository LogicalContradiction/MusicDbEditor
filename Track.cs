using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDbEditor
{
    /// <summary>
    /// Represents info needed to display in Track tab
    /// </summary>
    class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameInStreamPlayer { get; set; }
        public string AlbumName { get; set; }
        public string Link { get; set; }
        public string Notes { get; set; }
        public string SourceMediaName { get; set; }

        /// <summary>
        /// Constructs a Track object.
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


    }
}
