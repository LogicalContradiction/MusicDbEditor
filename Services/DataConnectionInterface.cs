using MusicDbEditor.Models;

namespace MusicDbEditor.Services
{
    internal interface DataConnectionInterface
    {

        public List<Track> GetTrackData();

        #region Album Data

        public List<Album> GetAlbumData();

        public Album InsertAlbum(Album album);

        #endregion

        #region Source Media Commands

        public List<SourceMedia> GetSourceMediaData();

        #endregion

    }
}
