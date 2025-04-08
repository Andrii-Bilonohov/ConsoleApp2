using ConsoleApp1.Entities;

namespace ConsoleApp1.DAL
{
    public class StudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository()
        {
            _context = new AppDbContext();
        }
        public IEnumerable<Student> GetAll()
        {
            return _context.Students;
        }


        public void Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            //return student;
        }
        public void Add(List<Student> student)
        {
            _context.Students.AddRange(student);
            _context.SaveChanges();
            //return student;
        }

        public Student Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
            return student;
        }

        public Student Delete(Student student)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
            return student;
        }
    }
}
