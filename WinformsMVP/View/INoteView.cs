using System.Collections.Generic;

namespace WinformsMVP.View
{
    public interface INoteView
    {
        IList<string> NotesList { get; set; }
        string SelectedNote { get; set; }
        string Title { get; set; }
        string NoteText { get; set; }
        Presenter.NotePresenter Presenter { set; }
    }
}
