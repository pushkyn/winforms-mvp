using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WinformsMVP.Model;
using WinformsMVP.Presenter;
using WinformsMVP.View;

namespace WinformsMVP.Tests
{
    [TestClass]
    public class NotePresenterTest
    {
        private readonly List<string> _notes = new List<String> {"One", "Two"};

        [TestMethod]
        public void CanLoadCustomers()
        {
            // arrange
            var repo = new Mock<INoteRepository>();
            var view = new Mock<INoteView>();
            repo.Setup(m => m.NoteCards)
                .Returns(_notes).Verifiable();

            var presenter = new NotePresenter(view.Object, repo.Object);

            // act

            // assert
            repo.Verify();
            view.VerifySet(m => m.NotesList = _notes.ToList());
        }
    }
}
