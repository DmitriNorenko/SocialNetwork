using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace SocialNetwork.Tests
{
    [TestFixture]
    public class TestEmailFriend
    {
        [Test]
        public void AddToFriend_MustReturnException()
        {
            var friendServise = new FriendServise();
            var dataAddFriends = new DataAddFriend { RecipientEmail = "bob@mail.ru", user_id = 1};
           Assert.Throws<Exception>(() => friendServise.AddFriend(dataAddFriends));
        }
    }
}
