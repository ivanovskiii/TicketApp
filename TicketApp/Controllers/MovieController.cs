using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketApp.Domain.DomainModels;
using TicketApp.Service.Interface;

namespace TicketApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Index(string genre)
        {
            // IQueryable<Movie> moviesQuery = _context.Movie.AsQueryable();
            //
            // if (!string.IsNullOrEmpty(genre))
            // {
            //     moviesQuery = moviesQuery.Where(m => m.Genre == genre);
            // }
            //
            // var movies = await moviesQuery.ToListAsync();
            //
            // return View(movies);
            
            return View(_movieService.GetAllMovies());
        }


        // GET: Movie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = _movieService.GetDetailsForMovie(id??0);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Movie movie)
        {
            // if (ModelState.IsValid)
            // {
            //     _context.Add(movie);
            //     await _context.SaveChangesAsync();
            //     return RedirectToAction(nameof(Index));
            // }
            // return View(movie);
            
            _movieService.CreateNewMovie(movie);
            return RedirectToAction("Index");
            
        }

        // GET: Movie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = _movieService.GetDetailsForMovie(id ?? 0);
            if (movie == null)
            {
                return NotFound();
            }
            //ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", ticket.MovieId);
            return View(movie);
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Movie movie)
        {
            // if (id != movie.Id)
            // {
            //     return NotFound();
            // }
            //
            // if (ModelState.IsValid)
            // {
            //     try
            //     {
            //         _context.Update(movie);
            //         await _context.SaveChangesAsync();
            //     }
            //     catch (DbUpdateConcurrencyException)
            //     {
            //         if (!MovieExists(movie.Id))
            //         {
            //             return NotFound();
            //         }
            //         else
            //         {
            //             throw;
            //         }
            //     }
            //     return RedirectToAction(nameof(Index));
            // }
            // return View(movie);
            
            if (id != movie.Id)
            {
                return NotFound();
            }

            _movieService.UpdateExistingMovie(movie);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Movie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = _movieService.GetDetailsForMovie(id??0);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // if (_context.Movie == null)
            // {
            //     return Problem("Entity set 'ApplicationDbContext.Movie'  is null.");
            // }
            // var movie = await _context.Movie.FindAsync(id);
            // if (movie != null)
            // {
            //     _context.Movie.Remove(movie);
            // }
            //
            // await _context.SaveChangesAsync();
            // return RedirectToAction(nameof(Index));
            
            _movieService.DeleteMovie(id);
            return RedirectToAction("Index");
        }

        private bool MovieExists(int id)
        {
            return _movieService.GetDetailsForMovie(id) != null;
        }
    }
}
