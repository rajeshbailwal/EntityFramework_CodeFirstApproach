using System.Collections.Generic;
using DAO_EFCORE.DAL.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DAO_EFCORE.DAL.Persistence
{
    public class NoteRepository : INoteRepository
    {
        IKeepNoteContext keepNoteDbConext = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">KeepNoteContext </param>
        public NoteRepository(IKeepNoteContext context)
        {
            keepNoteDbConext = context;
        }

        /// <summary>
        /// Adding checklist items
        /// </summary>
        /// <param name="checklist">checklist record with NoteId</param>
        /// <returns>returns new label with ChecklistId</returns>
        public Checklist AddChecklist(Checklist checklist)
        {
            keepNoteDbConext.Checklists.Add(checklist);
            keepNoteDbConext.SaveChanges();
            return checklist;
        }

        /// <summary>
        /// Adding label
        /// </summary>
        /// <param name="label">Label record with NoteId</param>
        /// <returns>returns new label with LabelId</returns>
        public Label AddLabel(Label label)
        {
            keepNoteDbConext.Labels.Add(label);
            keepNoteDbConext.SaveChanges();
            return label;
        }

        /// <summary>
        /// Adding note
        /// </summary>
        /// <param name="note">Note record</param>
        /// <returns>returns new node with NoteId</returns>
        public Note AddNote(Note note)
        {
            keepNoteDbConext.Notes.Add(note);
            keepNoteDbConext.SaveChanges();
            return note;
        }

        /// <summary>
        /// Get all checklist item to specific note
        /// </summary>
        /// <param name="noteId">contains note id</param>
        /// <returns>List of CheckList items</returns>
        public List<Checklist> GetAllCheckListItems(int noteId)
        {
            return keepNoteDbConext.Checklists.ToList();
        }

        /// <summary>
        /// Get all Labels item to specific note
        /// </summary>
        /// <param name="noteId">contains note id</param>
        /// <returns>List of Labels</returns>
        public List<Label> GetAllLabels(int noteId)
        {
            return keepNoteDbConext.Labels.ToList();
        }

        /// <summary>
        /// Get all notes
        /// </summary>
        /// <returns>List of Notes</returns>
        public List<Note> GetAllNotes()
        {
            return keepNoteDbConext.Notes.ToList();
        }

        /// <summary>
        /// Get note to specific noteId
        /// </summary>
        /// <param name="noteId">contains note id</param>
        /// <returns>Note record</returns>
        public Note GetNote(int noteId)
        {
            return keepNoteDbConext.Notes.Where(x => x.NoteId == noteId).FirstOrDefault();
        }

        /// <summary>
        /// Removing check list item
        /// </summary>
        /// <param name="id">contains checklist Id</param>
        /// <returns>true for success, false for failure</returns>
        public bool RemoveChecklist(int id)
        {
            var item = keepNoteDbConext.Checklists.First(x => x.ChecklistId == id);
            keepNoteDbConext.Checklists.Remove(item);
            int result = keepNoteDbConext.SaveChanges();
            if (result > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Removing Label
        /// </summary>
        /// <param name="id">contains Label Id</param>
        /// <returns>true for success, false for failure</returns>
        public bool RemoveLabel(int id)
        {
            var item = keepNoteDbConext.Labels.First(x => x.LabelId == id);
            keepNoteDbConext.Labels.Remove(item);
            int result = keepNoteDbConext.SaveChanges();
            if (result > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Removing Note
        /// </summary>
        /// <param name="id">contains Note Id</param>
        /// <returns>true for success, false for failure</returns>
        public bool RemoveNote(int id)
        {
            var item = keepNoteDbConext.Notes.First(x => x.NoteId == id);
            keepNoteDbConext.Notes.Remove(item);
            int result = keepNoteDbConext.SaveChanges();
            if (result > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Updating check list item
        /// </summary>
        /// <param name="id">contains checklist Id</param>
        /// <returns>true for success, false for failure</returns>
        public bool UpdateChecklist(Checklist checklist)
        {
            var existingChild = keepNoteDbConext.Checklists.Where(c => c.ChecklistId == checklist.ChecklistId)
                .SingleOrDefault();

            existingChild.Content = checklist.Content;
            int result = keepNoteDbConext.SaveChanges();

            if (result > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Updating Label
        /// </summary>
        /// <param name="id">contains Label Id</param>
        /// <returns>true for success, false for failure</returns>
        public bool UpdateLabel(Label label)
        {
             var existingChild = keepNoteDbConext.Labels.Where(c => c.LabelId == label.LabelId)
                .SingleOrDefault();

            existingChild.Content = label.Content;

            int result = keepNoteDbConext.SaveChanges();

            if (result > 0)
                return true;
            else
                return false;
        }
    }
}
