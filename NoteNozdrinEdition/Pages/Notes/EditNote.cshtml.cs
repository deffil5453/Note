using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NoteNozdrinEdition.Data;
using NoteNozdrinEdition.Models;

namespace NoteNozdrinEdition.Pages.Notes
{
    public class EditNoteModel : PageModel
    {
        private readonly NoteDbContext _context;

        public EditNoteModel(NoteDbContext context)
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
            Note = note;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Note).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(Note.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CustomerExists(int id)
        {
            return (_context.Notes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
