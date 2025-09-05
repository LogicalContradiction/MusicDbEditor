using MusicDbEditor.Models;
using System.ComponentModel;

namespace MusicDbEditor.ViewModels.DataViewModels
{
    class TagViewModel : INotifyPropertyChanged
    {
        #region Interface Methods

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        #endregion

        #region Properties

        /// <summary>
        /// The Tag object this viewmodel represents
        /// </summary>
        private Tag Tag {  get; set; }

        /// <summary>
        /// The text representing this label.
        /// </summary>
        public string Name
        {
            get
            {
                return Tag.Name;
            }
            set
            {
                Tag.Name = value;
            }
        }

        /// <summary>
        /// The category this tag is a member of.
        /// </summary>
        public string Category
        {
            get
            {
                return Tag.Category;
            }
            set
            {
                Tag.Category = value;
            }
        }

        /// <summary>
        /// Text description of the tag.
        /// </summary>
        public string Description
        {
            get
            {
                return Tag.Description;
            }
            set
            {
                Tag.Description = value;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor. Creates a view model to represent the supplied Tag.
        /// </summary>
        /// <param name="tag">Tag object to be represented by this view model.</param>
        public TagViewModel(Tag tag)
        {
            Tag = tag;
        }

        #endregion



    }
}
