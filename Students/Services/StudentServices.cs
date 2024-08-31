using ApiCrud.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Students.Services;

public class StudentServices
{
    private readonly AppDbContext _context;

    public StudentServices(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Student>> GetAllStudentsAsync()
    {
        return await _context.Students.ToListAsync();
    }

    public async Task<Student?> GetStudentByNameAsync(string name)
    {
        return await _context.Students.FirstOrDefaultAsync(s => s.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
    }

    public async Task<Student> AddStudentAsync(AddStudentRequest request)
    {
        var newStudent = new Student(request.Name);
        await _context.Students.AddAsync(newStudent);
        await _context.SaveChangesAsync();

        return newStudent;
    }

    public async Task<Student?> UpdateStudentAsync(UpdateStudentRequest request)
    {
        var student = await _context.Students.FindAsync(request.Id);
        
        if(student == null) {
            return null;
        }

        student.Active = request.Active;
        await _context.SaveChangesAsync();

        return student;
    }

    public async Task<bool> DeleteStudentByIdAsync(Guid id)
    {
        var student = await _context.Students.FindAsync(id);

        if(student == null) {
            return false;
        }

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
        return true;
    }
}