using ConsoleApp1.Entities;

namespace ConsoleApp1.Services
{
    public class MenuService
    {
        private readonly StudentService _studentService;

        public MenuService()
        {
            _studentService = new StudentService();
        }


        public void Menu()
        {
            Console.WriteLine("1. Додати студента");
            Console.WriteLine("2. Додати декілька студентів");
            Console.WriteLine("3. Оновити студента");
            Console.WriteLine("4. Видалити студента");
            Console.WriteLine("5. Отримати всіх студентів");
            Console.WriteLine("6. Отримати студента за ID");
            Console.WriteLine("7. Отримати студента за іменем");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddStudent();
                    Console.WriteLine();
                    break;
                case "2":
                    AddStudents();
                    Console.WriteLine();
                    break;
                case "3":
                    UpdateStudent();
                    Console.WriteLine();
                    break;
                case "4":
                    DeleteStudent();
                    Console.WriteLine();
                    break;
                case "5":
                    GetAllStudents();
                    Console.WriteLine();
                    break;
                case "6":
                    GetStudentById();
                    Console.WriteLine();
                    break;
                case "7":
                    GetStudentByName();
                    Console.WriteLine();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Невірний вибір");
                    Console.WriteLine();
                    break;
            }
        }


        private void AddStudent()
        {
            Console.WriteLine("Введіть ім'я студента:");
            var name = Console.ReadLine();

            Console.WriteLine("Введіть опис студента:");
            var desc = Console.ReadLine();
            Student student = new Student
            {
                Name = name,
                Description = desc
            };

            _studentService.AddStudent(student);
            Console.Clear();
            Console.WriteLine("Студента додано!");
        }


        private void AddStudents()
        {
            Console.WriteLine("Скільки студентів ви хочете додати?");
            if (!int.TryParse(Console.ReadLine(), out var count))
            {
                Console.Clear();
                Console.WriteLine("Invalid input.");
            }

            var students = new List<Student>();

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Введіть ім'я студента {i + 1}:");
                var name = Console.ReadLine();

                Console.WriteLine($"Введіть опис студента {i + 1}:");
                var desc = Console.ReadLine();
                Student student = new Student
                {
                    Name = name,
                    Description = desc
                };

                students.Add(student);
            }

            _studentService.AddStudents(students);
            Console.Clear();
            Console.WriteLine("Студенти успішно додані!");
        }


        private void UpdateStudent()
        {
            Console.WriteLine("Введіть Id студуента для оновлення: ");
            if (!int.TryParse(Console.ReadLine(), out var id))
            {
                Console.Clear();
                Console.WriteLine("Invalid input.");
                return;
            }

            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                Console.Clear();
                Console.WriteLine("Студента не знайдено.");
                return;
            }

            Console.WriteLine("Поточний студент: ");
            Console.WriteLine($"ID: {student.Id}, Ім'я: {student.Name}, Опис: {student.Description}");

            Console.WriteLine("Що ви хочете змінти?");
            Console.WriteLine("1. Ім'я");
            Console.WriteLine("2. Опис");

            if (!int.TryParse(Console.ReadLine(), out var variant))
            {
                Console.Clear();
                Console.WriteLine("Invalid input.");
                return;
            }

            switch (variant)
            {
                case 1:
                    Console.WriteLine("Введіть ім'я для заміни: ");
                    string name = Console.ReadLine();
                    _studentService.UpdateName(id, name);

                    Console.Clear();
                    Console.WriteLine("Дані оновлені");
                    break;
                case 2:
                    Console.WriteLine("Введіть опис для заміни: ");
                    string? desc = Console.ReadLine();
                    _studentService.UpdateDesc(id, desc);

                    Console.Clear();
                    Console.WriteLine("Дані оновлені");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Невірний вибір");
                    break;
            }
        }


        private void DeleteStudent()
        {
            Console.WriteLine("1. Id");
            Console.WriteLine("2. Ім'я");
            Console.WriteLine("Введіть спосіб індентифікації студента: ");

            if (!int.TryParse(Console.ReadLine(), out var choise))
            {
                Console.Clear();
                Console.WriteLine("Invalid input.");
                return;
            }

            switch (choise)
            {
                case 1:
                    Console.WriteLine("Введіть Id: ");
                    if (!int.TryParse(Console.ReadLine(), out var id))
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input.");
                    }

                    var studentFindById = _studentService.GetStudentById(id);
                    if (studentFindById == null)
                    {
                        Console.Clear();
                        Console.WriteLine("Студента не знайдено.");
                        return;
                    }
                    
                    _studentService.DeleteById(id);
                    Console.Clear();
                    Console.WriteLine("Студента видалено: ");
                    break;
                case 2:
                    Console.WriteLine("Введіть ім'я: ");
                    string name = Console.ReadLine();
                    var studentFindByName = _studentService.GetStudentByName(name);

                    if (studentFindByName == null)
                    {
                        Console.Clear();
                        Console.WriteLine("Студента не знайдено.");
                        return;
                    }
                    
                    _studentService.DeleteByName(name);
                    Console.Clear();
                    Console.WriteLine("Студента видалено: ");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Невірний вибір");
                    break;
            }
        }


        private void GetStudentById()
        {
            Console.WriteLine("Введіть ID студента:");
            if (!int.TryParse(Console.ReadLine(), out var id))
            {
                Console.Clear();
                Console.WriteLine("Invalid input.");
                return;
            }

            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                Console.Clear();
                Console.WriteLine("Студента не знайдено.");

            }
            Console.Clear();
            Console.WriteLine($"ID: {student.Id}, Ім'я: {student.Name}, Опис: {student.Description}");
        }


        private void GetAllStudents()
        {
            Console.Clear();
            var students = _studentService.GetAllStudents();
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Ім'я: {student.Name}, Опис: {student.Description}");
            }
        }


        private void GetStudentByName()
        {
            Console.WriteLine("Введіть ім'я студента:");
            string name = Console.ReadLine();

            var student = _studentService.GetStudentByName(name);
            if (student == null)
            {
                Console.Clear();
                Console.WriteLine("Студента не знайдено.");
                return;
            }

            Console.Clear();
            Console.WriteLine($"ID: {student.Id}, Ім'я: {student.Name}, Опис: {student.Description}");
        }
    }
}
