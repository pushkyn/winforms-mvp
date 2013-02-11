using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WinformsMVP.Model
{
    public class NoteFileRepository : INoteRepository
    {
        private static string BaseDirectory
        {
            get { return Path.GetDirectoryName(Application.ExecutablePath); }
        }

        public IEnumerable<string> NoteCards
        {
            get
            {
                return
                    from f in Directory.GetFiles(BaseDirectory, "*.note")
                    select Path.GetFileNameWithoutExtension(f);
            }
        }

        public Note GetNote(string title)
        {
            var file = Path.Combine(BaseDirectory, title + ".note");

            return new Note
            {
                Title = title,
                NoteText = File.ReadAllText(file)
            };
        }

        public bool NoteExists(string title)
        {
            var file = Path.Combine(BaseDirectory, title + ".note");

            return File.Exists(file);
        }

        public void Save(Note note)
        {
            var file = Path.Combine(BaseDirectory, note.Title + ".note");

            File.WriteAllText(file, note.NoteText);
        }

        public void Delete(Note note)
        {
            var file = Path.Combine(BaseDirectory, note.Title + ".note");

            File.Delete(file);
        }
    }
}
