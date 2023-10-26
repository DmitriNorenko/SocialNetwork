using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class FriendServise
    {
        IUserRepository userRepository;
        IFriendRepository friendRepository;
        public FriendServise()
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }
        public void AddToFriends(DataAddFriend dataAddFriend)
        {
            if (String.IsNullOrEmpty(dataAddFriend.RecipientEmail))
                throw new ArgumentNullException();
            var findUserEntity = this.userRepository.FindByEmail(dataAddFriend.RecipientEmail);
            if (findUserEntity is null) throw new UserNotFoundException();
            var friendEntity = new FriendEntity
            {
                friend_id = findUserEntity.id,
                user_id = dataAddFriend.user_id,
            };
            if (friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }
    }
}
