using ConsoleApp1.DAL;
using ConsoleApp1.Entities;

namespace ConsoleApp1
{
    public class StudentService
    {
        private StudentRepository _studentRepository;
        public StudentService()
        {
            _studentRepository = new StudentRepository();
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll().ToList();
        }

        public List<Student> GetAllById(int id)
        {


            return _studentRepository.GetAll()
                                        .Where(s => s.Id == id)
                                        .ToList();
        }

        public List<Student> GetAllByName(string name)
        {
            return _studentRepository.GetAll()
                                        .Where(s => s.Name == name)
                                        .ToList();
        }

        public Student? GetByName(string name)
        {
            return _studentRepository.GetAll()
                                        .FirstOrDefault(s => s.Name == name);
        }
        public Student Add(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student object cannot be null");
            }
            _studentRepository.Add(student);
            return student;

        }



        public Student Update(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student object cannot be null");
            }
            _studentRepository.Update(student);
            return student;
        }

        public Student UpdateById(int studentId, string name)
        {
            var student = _studentRepository.GetAll()
                                      .FirstOrDefault(s => s.Id == studentId);
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student id cannot be null");
            }
            student.Name = name;
            _studentRepository.Update(student);
            return student;
        }

        public Student UpdateByName(string currentName, string newName)
        {
            var student = _studentRepository.GetAll()
                                      .FirstOrDefault(s => s.Name == currentName);
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student name cannot be null");
            }
            student.Name = newName;
            _studentRepository.Update(student);
            return student;
        }

        public Student Delete(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student object cannot be null");
            }
            _studentRepository.Delete(student);
            return student;
        }

        public Student DeleteById(int studentId)
        {
            var student = _studentRepository.GetAll()
                                             .FirstOrDefault(s => s.Id == studentId);
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student id cannot be null");
            }
            _studentRepository.Delete(student);
            return student;
        }

        public Student DeleteByName(string studentName)
        {
            var student = _studentRepository.GetAll()
                                             .FirstOrDefault(s => s.Name == studentName);
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student name cannot be null");
            }
            _studentRepository.Delete(student);
            return student;
        }

    }
}
