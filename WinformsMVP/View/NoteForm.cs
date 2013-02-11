using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinformsMVP.Presenter;

namespace WinformsMVP.View
{
    public partial class NoteForm : Form, INoteView
    {
        public NoteForm()
        {
            InitializeComponent();
        }

        public IList<string> NotesList
        {
            get { return (IList<string>) listBoxNotes.DataSource; }
            set { listBoxNotes.DataSource = value; }
        }

        public string SelectedNote
        {
            get { return listBoxNotes.SelectedItem as string; }
            set { listBoxNotes.SelectedItem = value; }
        }

        public string Title
        {
            get { return textBoxTitle.Text; }
            set { textBoxTitle.Text = value; }
        }

        public string NoteText
        {
            get { return textBoxNote.Text; }
            set { textBoxNote.Text = value; }
        }

        public NotePresenter Presenter { private get; set; }

        private void ButtonNewNoteClick(object sender, EventArgs e)
        {
            Presenter.SaveNote();
        }

        private void ButtonDeleteNoteClick(object sender, EventArgs e)
        {
            Presenter.DeleteNote();
        }

        private void ListBoxNotesSelectedIndexChanged(object sender, EventArgs e)
        {
            Presenter.NoteSelect();
        }
    }
}
