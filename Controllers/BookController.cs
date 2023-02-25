using Microsoft.AspNetCore.Mvc;
using libraryAPI.Services;
using libraryAPI.Models;

namespace libraryAPI.Controllers; 

[Controller]
[Route("api/[controller]")]

public class BookController : Controller {
    private libraryService _libService;

    public BookController(libraryService ls) {
        _libService = ls;
    }

    [HttpGet]
    public async Task<List<Book>> Get() {
        return await _libService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Book book) {
        await _libService.CreateAsync(book);
        return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AddBook(string id, [FromBody] Book book) {
        await _libService.AddBook(id, book.itemsAvailable);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id) {
        await _libService.DeleteAsync(id);
        return NoContent();
    }
}