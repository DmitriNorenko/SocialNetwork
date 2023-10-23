using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System.Threading.Channels;

namespace SocialNetwork
{
    public class Program
    {
        public static UserService userService = new UserService();
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в социальную сеть.");
            while (true)
            {
                Console.WriteLine("Для регистрации пользователя введите имя:");

                string firstName = Console.ReadLine();

                Console.Write("Фамилия:");

                string lastName = Console.ReadLine();

                Console.Write("пароль:");

                string password = Console.ReadLine();

                Console.Write("почтовый адрес:");

                string email = Console.ReadLine();

                UserRegistrationData registrationData = new UserRegistrationData()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Password = password,
                    Email = email
                };

                try
                {
                    userService.Register(registrationData);
                    Console.WriteLine("Регистрация произошла успешно!");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Введите корректное значение.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла ошибка при регистрации.");
                    Console.WriteLine(ex.Message);
                }

                Console.ReadKey();
            }
        }
    }
}