using System.Collections.Generic;

namespace WinformsMVP.Model
{
    public interface INoteRepository
    {
        IEnumerable<string> NoteCards { get; }

        Note GetNote(string title);
        bool NoteExists(string title);
        void Save(Note note);
        void Delete(Note note);
    }
}
