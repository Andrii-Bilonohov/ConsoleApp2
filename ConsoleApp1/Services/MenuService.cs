using ConsoleApp1.Entities;

namespace ConsoleApp1.Services
{
    public class MenuService
    {
        private readonly StudentService _studentService;

        public MenuService(StudentService studentService)
        {
            _studentService = studentService;
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
                    break;
                case "2":
                    AddStudents();
                    break;
                case "3":
                    UpdateStudent();
                    break;
                case "4":
                    DeleteStudent();
                    break;
                case "5":
                    GetAllStudents();
                    break;
                case "6":
                    GetStudentById();
                    break;
                case "7":
                    GetStudentByName();
                    break;
                default:
                    Console.WriteLine("Невірний вибір");
                    break;
            }
        }
        private void AddStudent()
        {
            Console.WriteLine("Введіть ім'я студента:");
            var name = Console.ReadLine();
            _studentService.AddStudent(new Student { Name = name });
            Console.WriteLine("Студента додано!");
        }
        private void AddStudents()
        {
            Console.WriteLine("Скільки студентів ви хочете додати?");
            if (int.TryParse(Console.ReadLine(), out var count)) { }
            else
            {
                Console.WriteLine("Invalid input.");
            }

            var students = new List<Student>();

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Введіть ім'я студента {i + 1}:");
                var name = Console.ReadLine();
                students.Add(new Student { Name = name });
            }

            _studentService.AddStudents(students);
            Console.WriteLine("Студенти успішно додані!");
        }

        private void UpdateStudent()
        {
            Console.WriteLine("Введіть Id студуента для оновлення: ");
            if (int.TryParse(Console.ReadLine(), out var id))
            {
                Console.WriteLine("Поточний студент: ");
                _studentService.GetStudentById(id);

                Console.WriteLine("Що ви хочете змінти?");
                Console.WriteLine("1. Ім'я");
                Console.WriteLine("2. Опис");
                if (int.TryParse(Console.ReadLine(), out var variant))
                {
                    switch (variant)
                    {
                        case 1:
                            Console.WriteLine("Введіть ім'я для заміни: ");
                            string name = Console.ReadLine();
                            _studentService.UpdateName(id, name);
                            Console.WriteLine("Дані оновлені");
                            break;
                        case 2:
                            Console.WriteLine("Введіть опис для заміни: ");
                            string desc = Console.ReadLine();
                            _studentService.UpdateDesc(id, desc);
                            Console.WriteLine("Дані оновлені");
                            break;
                        default:
                            Console.WriteLine("Невірний вибір");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }

        private void DeleteStudent()
        {
            Console.WriteLine("1. Id");
            Console.WriteLine("2. Ім'я");
            Console.WriteLine("Введіть спосіб індентифікації студента: ");
            if (int.TryParse(Console.ReadLine(), out var choise))
            {
                switch (choise)
                {
                    case 1:
                        Console.WriteLine("Введіть Id: ");
                        if (int.TryParse(Console.ReadLine(), out var id))
                        {
                            _studentService.GetStudentById(id);
                            _studentService.DeleteById(id);
                            Console.WriteLine("Студента видалено: ");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input.");
                        }

                        break;
                    case 2:
                        Console.WriteLine("Введіть ім'я: ");
                        string name = Console.ReadLine();
                        _studentService.GetStudentByName(name);
                        _studentService.DeleteByName(name);
                        Console.WriteLine("Студента видалено: ");
                        break;
                    default:
                        Console.WriteLine("Невірний вибір");
                        break;

                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }

        private void GetStudentById()
        {
            Console.WriteLine("Введіть ID студента:");
            if (int.TryParse(Console.ReadLine(), out var id))
            {
                Console.WriteLine($"ID is: {id}");
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
            var student = _studentService.GetStudentById(id);
            if (student != null)
            {
                Console.WriteLine($"ID: {student.Id}, Ім'я: {student.Name}, Опис: {student.Description}");
            }
            else
            {
                Console.WriteLine("Студента не знайдено.");
            }
        }

        private void GetAllStudents()
        {
            var students = _studentService.GetAllStudents();
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Ім'я: {student.Name}, Опис: {student.Description}");
            }
        }

        private void GetStudentByName()
        {
            Console.WriteLine("Введіть ім'я студента:");
            string  name = Console.ReadLine();
            var student = _studentService.GetStudentByName(name);
            if (student != null)
            {
                Console.WriteLine($"ID: {student.Id}, Ім'я: {student.Name}, Опис: {student.Description}");
            }
            else
            {
                Console.WriteLine("Студента не знайдено.");
            }
        }
    }
}
