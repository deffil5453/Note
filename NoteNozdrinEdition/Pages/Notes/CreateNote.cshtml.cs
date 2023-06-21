using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NoteNozdrinEdition.Data;
using NoteNozdrinEdition.Models;

namespace NoteNozdrinEdition.Pages.Notes
{
    public class CreateNoteModel : PageModel
    {
        private readonly NoteDbContext _context;

        public CreateNoteModel(NoteDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Note Note { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }   
        
        public async Task<IActionResult> OnPostAsync()
        {
            _context.Notes.Add(Note);
            await _context.SaveChangesAsync();
            return RedirectToPage("./IndexNote");
        }
    }
}