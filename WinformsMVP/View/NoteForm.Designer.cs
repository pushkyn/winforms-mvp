namespace WinformsMVP.View
{
    partial class NoteForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.listBoxNotes = new System.Windows.Forms.ListBox();
            this.buttonNewNote = new System.Windows.Forms.Button();
            this.buttonDeleteNote = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelNote = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(213, 12);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(129, 20);
            this.textBoxTitle.TabIndex = 0;
            // 
            // textBoxNote
            // 
            this.textBoxNote.Location = new System.Drawing.Point(213, 38);
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.Size = new System.Drawing.Size(129, 20);
            this.textBoxNote.TabIndex = 1;
            // 
            // listBoxNotes
            // 
            this.listBoxNotes.FormattingEnabled = true;
            this.listBoxNotes.Location = new System.Drawing.Point(12, 12);
            this.listBoxNotes.Name = "listBoxNotes";
            this.listBoxNotes.Size = new System.Drawing.Size(149, 238);
            this.listBoxNotes.TabIndex = 2;
            this.listBoxNotes.SelectedIndexChanged += new System.EventHandler(this.ListBoxNotesSelectedIndexChanged);
            // 
            // buttonNewNote
            // 
            this.buttonNewNote.Location = new System.Drawing.Point(267, 227);
            this.buttonNewNote.Name = "buttonNewNote";
            this.buttonNewNote.Size = new System.Drawing.Size(75, 23);
            this.buttonNewNote.TabIndex = 3;
            this.buttonNewNote.Text = "New";
            this.buttonNewNote.UseVisualStyleBackColor = true;
            this.buttonNewNote.Click += new System.EventHandler(this.ButtonNewNoteClick);
            // 
            // buttonDeleteNote
            // 
            this.buttonDeleteNote.Location = new System.Drawing.Point(170, 227);
            this.buttonDeleteNote.Name = "buttonDeleteNote";
            this.buttonDeleteNote.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteNote.TabIndex = 4;
            this.buttonDeleteNote.Text = "Delete";
            this.buttonDeleteNote.UseVisualStyleBackColor = true;
            this.buttonDeleteNote.Click += new System.EventHandler(this.ButtonDeleteNoteClick);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(167, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(30, 13);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "Title:";
            // 
            // labelNote
            // 
            this.labelNote.AutoSize = true;
            this.labelNote.Location = new System.Drawing.Point(167, 41);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(33, 13);
            this.labelNote.TabIndex = 6;
            this.labelNote.Text = "Note:";
            // 
            // NoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 262);
            this.Controls.Add(this.labelNote);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonDeleteNote);
            this.Controls.Add(this.buttonNewNote);
            this.Controls.Add(this.listBoxNotes);
            this.Controls.Add(this.textBoxNote);
            this.Controls.Add(this.textBoxTitle);
            this.Name = "NoteForm";
            this.Text = "Notes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxNote;
        private System.Windows.Forms.ListBox listBoxNotes;
        private System.Windows.Forms.Button buttonNewNote;
        private System.Windows.Forms.Button buttonDeleteNote;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelNote;
    }
}