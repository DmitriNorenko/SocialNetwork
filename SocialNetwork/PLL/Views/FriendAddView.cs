using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class FriendAddView
    {
        UserService userService;
        FriendServise friendServise;
        public FriendAddView(UserService userService,FriendServise friendServise)
        {
            this.userService = userService;
            this.friendServise = friendServise;
        }
       public void Show(User user)
        {
            DataAddFriend dataAddFriend = new DataAddFriend();
            Console.WriteLine("Введите почту пользователя:");
            dataAddFriend.RecipientEmail = Console.ReadLine();
            dataAddFriend.user_id = user.Id;
            try
            {
               friendServise.AddToFriends(dataAddFriend);
                SuccessMessage.Show("Пользователь добавлен в друзья!");
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
            }

            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при отправке сообщения!");
            }
        }
    }
}
