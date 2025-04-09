using ConsoleApp1.DAL.Repositories;
using ConsoleApp1.Entities;

namespace ConsoleApp1.Services
{
    public class StudentService
    {
        private StudentRepository _studentRepository;
        public StudentService()
        {
            _studentRepository = new StudentRepository();
        }

        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAllStudents().ToList();
        }

        public Student? GetStudentById(int id)
        {
            return _studentRepository.GetStudentById(id);
        }

        public Student? GetStudentByName(string name)
        {
            return _studentRepository.GetStudentByName(name);
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student object cannot be null");
            }
            _studentRepository.AddStudent(student);
        }
        public void AddStudents(List<Student> students)
        {
            if (students == null)
            {
                throw new ArgumentNullException(nameof(students), "Student object cannot be null");
            }
            _studentRepository.AddStudents(students);
        }

        public void UpdateStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student object cannot be null");
            }
            _studentRepository.UpdateStudent(student);
        }

        public void UpdateName(int id, string name)
        {
            var student = _studentRepository.GetAllStudents()
                                      .FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student id cannot be null");
            }
            student.Name = name;
            _studentRepository.UpdateStudent(student);
        }

        public void UpdateDesc(int id, string desc)
        {
            var student = _studentRepository.GetAllStudents()
                                      .FirstOrDefault(s => s.Id== id);
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student desc cannot be null");
            }
            student.Description = desc;
            _studentRepository.UpdateStudent(student);
        }

        public void DeleteStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student object cannot be null");
            }
            _studentRepository.DeleteStudent(student);
        }

        public void DeleteById(int id)
        {
            var student = _studentRepository.GetAllStudents()
                                             .FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student id cannot be null");
            }
            _studentRepository.DeleteStudent(student);
        }

        public void DeleteByName(string name)
        {
            var student = _studentRepository.GetAllStudents()
                                             .FirstOrDefault(s => s.Name == name);
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student name cannot be null");
            }
            _studentRepository.DeleteStudent(student);
        }

    }
}
