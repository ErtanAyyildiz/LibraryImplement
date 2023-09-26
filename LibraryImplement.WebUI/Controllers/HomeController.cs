using AutoMapper;
using LibraryImplement.Business.Abstracts;
using LibraryImplement.Models;
using LibraryImplement.Models.DTOs.Books;
using LibraryImplement.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp.Formats.Jpeg;
using System.Diagnostics;
using X.PagedList;

namespace LibraryImplement.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IBorrowedBookService _borrowedBookService;
        private readonly IMapper _mapper;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IBookService bookService, IBorrowedBookService borrowedBookService, IMapper mapper, ILogger<HomeController> logger)
        {
            _bookService = bookService;
            _borrowedBookService = borrowedBookService;
            _mapper = mapper;
            _logger = logger;
            _logger.LogInformation("Home Controller Cagirildi.");
        }

        public IActionResult Index(int page = 1)
        {
            try
            {
                _logger.LogInformation("Home/Index Get Metodu Cagirildi");
                var books = _bookService.GetAll().OrderBy(book => book.Title);
                const int pageSize = 5;

                var booksDto = _mapper.Map<ICollection<BookListDTO>>(books);

                var pagedBooks = booksDto.ToPagedList(page, pageSize);


                ViewBag.TotalItemCount = booksDto.Count;

                return View(pagedBooks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Lend(int kitapId)
        {
            _logger.LogInformation("Home/Lend Get Metodu Cagirildi");
            var book = _bookService.GetByID(kitapId);
            ViewBag.BookImage = book.ImagePath;
            return View(kitapId);
        }
        [HttpPost]
        public IActionResult Lend(int bookId, string barrowName, DateTime dueDate)
        {
            _logger.LogInformation("Home/Lend Post Metodu Cagirildi");

            try
            {
                var book = _bookService.GetByID(bookId);
                if (book != null)
                {
                    book.IsInLibrary = false;
                    _bookService.Update(book);
                }

                var borrowedBook = new BorrowedBook
                {
                    BookId = bookId,
                    BorrowerName = barrowName,
                    BorrowDate = DateTime.Now,
                    DueDate = dueDate
                };

                _borrowedBookService.Add(borrowedBook);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult CreateBook()
        {
            _logger.LogInformation("Home/CreateBook Post Metodu Cagirildi");

            return View();
        }

        [HttpPost]
        public IActionResult CreateBook(BookCreateDTO model, IFormFile ImageFile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (ImageFile != null)
                    {
                        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                        var fileExtension = Path.GetExtension(ImageFile.FileName).ToLower();
                        if (allowedExtensions.Contains(fileExtension))
                        {
                            using (var stream = new MemoryStream())
                            {
                                ImageFile.CopyTo(stream);
                                stream.Seek(0, SeekOrigin.Begin);


                                using (var image = Image.Load(stream))
                                {
                                    var minSize = Math.Min(image.Width, image.Height);
                                    var newWidth = Math.Max(minSize, 100);
                                    var newHeight = newWidth;

                                    image.Mutate(x => x.Resize(newWidth, newHeight));

                                    // Boyutlandırılmış resmi kaydet
                                    var path = $"/images/{Guid.NewGuid()}.jpg";
                                    var imagePath = $"wwwroot{path}";
                                    image.Save(imagePath, new JpegEncoder());
                                    model.ImagePath = path;
                                }
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("ImageFile", "Lütfen sadece .jpg, .jpeg veya .png uzantılı dosyaları yükleyin.");
                            return View();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("ImageFile", "Dosya seçilmedi.");
                        return View();
                    }

                    var book = _mapper.Map<Book>(model);
                    book.IsInLibrary = true;

                    _bookService.Add(book);

                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return RedirectToAction("Index");
            }

        }
    }
}