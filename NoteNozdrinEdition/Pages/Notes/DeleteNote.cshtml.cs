using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NoteNozdrinEdition.Data;
using NoteNozdrinEdition.Models;

namespace NoteNozdrinEdition.Pages.Notes
{
    public class DeleteNoteModel : PageModel
    {
        private readonly NoteDbContext _context;

        public DeleteNoteModel(NoteDbContext context)
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
        public  async Task<IActionResult> OnPostAsync(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
            return RedirectToPage("./IndexNote");
        }

    }
}
