using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDbEditor.Models
{
    internal class SourceMedia
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SortName { get; set; }


        public SourceMedia(int id, string name, string sortName)
        {
            Id = id;
            Name = name;
            SortName = sortName;
        }



        public override string ToString()
        {
            return $"Source Media: id='{Id}', name='{Name}', sort name='{SortName}'";
        }

    }
}
