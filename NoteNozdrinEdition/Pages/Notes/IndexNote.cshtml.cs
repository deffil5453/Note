using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NoteNozdrinEdition.Data;
using NoteNozdrinEdition.Models;

namespace NoteNozdrinEdition.Pages.Notes
{
    public class IndexNoteModel : PageModel
    {
        private readonly NoteDbContext _noteDbContext;

        public IndexNoteModel(NoteDbContext noteDbContext)
        {
            _noteDbContext = noteDbContext;
        }
        public List<Note> Notes { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public async Task OnGet()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                Notes = await _noteDbContext.Notes.Where(note => note.LastName == SearchString).ToListAsync();
            }
            else
            {
                Notes = await _noteDbContext.Notes.ToListAsync();
            }
        }
    }
}