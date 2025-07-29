using MusicDbEditor.Models;

namespace MusicDbEditor.Services
{
    internal interface DataConnectionInterface
    {

        public List<Track> GetTrackData();

        public List<Album> GetAlbumData();

        public Album InsertAlbum(Album album);

    }
}
