using MusicDbEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDbEditor.ViewModels
{
    internal class TrackViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// The Track data object.
        /// </summary>
        public Track Track { get; set; }

        /// <summary>
        /// The name of this Track
        /// </summary>
        public string Name {
            get
            {
                return Track.Name;
            }
            set {
                Track.Name = value;
            }
        }

        /// <summary>
        /// The name in the steam player for this track
        /// </summary>
        public string NameInStreamPlayer
        {
            get
            {
                return Track.NameInStreamPlayer;
            }
            set
            {
                Track.NameInStreamPlayer = value;
            }
        }

        /// <summary>
        /// The name of the album this track is from
        /// </summary>
        public string AlbumName
        {
            get
            {
                return Track.AlbumName;
            }
            set
            {
                Track.AlbumName = value;
            }
        }

        /// <summary>
        /// A link to listen to this track at.
        /// </summary>
        public string Link
        {
            get
            {
                return Track.Link;
            }
            set
            {
                Track.Link = value;
            }
        }

        /// <summary>
        /// Arbitrary text the user decided was important enough to write down
        /// </summary>
        public string Notes
        {
            get
            {
                return Track.Notes;
            }
            set
            {
                Track.Notes = value;
            }
        }

        /// <summary>
        /// The name of the piece of media this track originates from
        /// </summary>
        public string SourceMediaName
        {
            get
            {
                return Track.SourceMediaName;
            }
            set
            {
                Track.SourceMediaName = value;
            }
        }

        #endregion


        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="track">The track data object this view model represents.</param>
        public TrackViewModel(Track track)
        {
            Track = track;
        }
    }
}
