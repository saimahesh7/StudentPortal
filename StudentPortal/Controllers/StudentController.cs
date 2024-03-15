using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Data;
using StudentPortal.Models.Domain;
using StudentPortal.Models.ViewModels;

namespace StudentPortal.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentPortalDbContext dbContext;

        public StudentController(StudentPortalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentRequest addStudentRequest)
        {
            var student = new Student()
            {
                Name = addStudentRequest.Name,
                Email = addStudentRequest.Email,
                Phone = addStudentRequest.Phone,
                Subscribed = addStudentRequest.Subscribed,
            };
             await dbContext.Students.AddAsync(student);
             await dbContext.SaveChangesAsync();
            
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var studentListDomain=await dbContext.Students.ToListAsync();

            return View(studentListDomain);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student=await dbContext.Students.FindAsync(id);

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel)
        {
            var student=await dbContext.Students.FindAsync(viewModel.ID);

            if (student != null)
            {
                student.Name = viewModel.Name;
                student.Email = viewModel.Email;
                student.Phone = viewModel.Phone;
                student.Subscribed = viewModel.Subscribed;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List" ,"Student");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Student viewModel)
        {
            var student=await dbContext.Students.AsNoTracking().FirstOrDefaultAsync(x=>x.ID==viewModel.ID);
            if (student != null)
            {
                 dbContext.Students.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Student");
        }

    }
}
