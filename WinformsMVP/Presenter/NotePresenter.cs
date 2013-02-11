using System.Linq;
using WinformsMVP.Model;
using WinformsMVP.View;

namespace WinformsMVP.Presenter
{
    public class NotePresenter
    {
        private readonly INoteView _view;
        private readonly INoteRepository _repository;

        public NotePresenter(INoteView view, INoteRepository repository)
        {
            _view = view;
            _view.Presenter = this;
            _repository = repository;

            LoadNotes();
        }

        private void LoadNotes()
        {
            var notes = _repository.NoteCards.ToList();
            _view.NotesList = notes;
        }

        public void NoteSelect()
        {
            var note = _repository.GetNote(_view.SelectedNote);
            _view.Title = note.Title;
            _view.NoteText = note.NoteText;
        }

        public void SaveNote()
        {
            var note = new Note
                           {
                               Title = _view.Title,
                               NoteText = _view.NoteText
                           };
            _repository.Save(note);
            LoadNotes();
        }

        public void DeleteNote()
        {
            var note = _repository.GetNote(_view.SelectedNote);
            _repository.Delete(note);
            LoadNotes();
        }
    }
}
