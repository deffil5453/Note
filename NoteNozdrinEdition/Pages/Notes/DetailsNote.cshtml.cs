using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NoteNozdrinEdition.Data;
using NoteNozdrinEdition.Models;

namespace NoteNozdrinEdition.Pages.Notes
{
    public class DetailsNoteModel : PageModel
    {
        private readonly NoteDbContext _context;

        public DetailsNoteModel(NoteDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Note Note { get; set; }
        public IActionResult OnGet(int id)
        {
            var note = _context.Notes.FirstOrDefault(Note => Note.Id == id);
            if (note == null)
            {
                return NotFound();
            }
            else
            {
                Note = note;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            
            return RedirectToPage("./IndexNote");
        }
    }
}
