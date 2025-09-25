

namespace MusicDbEditor.Models
{
    public class SourceMedia
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public string SortName { get; set; }

        #endregion

        #region Constructors

        public SourceMedia(int id, string name, string sortName)
        {
            Id = id;
            Name = name;
            SortName = sortName;
        }

        public SourceMedia() { }

        #endregion



        public override string ToString()
        {
            return $"Source Media: id='{Id}', name='{Name}', sort name='{SortName}'";
        }

    }
}
