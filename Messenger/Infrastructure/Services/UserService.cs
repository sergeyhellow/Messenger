using Messenger.Data;
using Messenger.Models;
using Messenger.ModelShells;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;

namespace Messenger.Infrastructure.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService()
        {
            _context = new AppDbContext();
        }

        public async Task<int> AddNewUser(User user)
        {

            var list = new ObservableCollection<FriendList>();
            list.Add(new FriendList() { Name = "FirstLists" });
            user.FriendLists = list;
            var res = _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return res.Id;

        }

        /// <summary>
        ///  временный метод для заполнения фото, не использовать
        /// </summary>
        /// <param name="user">пользователь чей FriendList мы берем для заполнения фото у друзей</param>
        /// <returns>успешна ли операция</returns>

        public async Task<bool> AppPhotoSourse(User user)
        {
            var fl = await GetFrienList(user);
            foreach (var item in fl)
            { 
                item.Photo = @"C:\Users\User\Pictures\Saved Pictures\rika.jpg";
            }
          await  _context.SaveChangesAsync();
            return true;
        }


        public async Task<User> GetUser(int id)
        {

            return await _context.Users.Include("FriendLists").Include("Messages").FirstOrDefaultAsync(u => u.Id == id);

        }

        public async Task<bool> AddNewFriend(User mainUser, User friend)
        {

           
                var userTemp = _context.Users.Include("FriendLists").FirstOrDefault(u => u.Id == mainUser.Id);
                var friendTemp = _context.Users.Include("FriendLists").FirstOrDefault(u => u.Id == friend.Id);
                userTemp.FriendLists.FirstOrDefault().Friends.Add(friendTemp);
                var res = await _context.SaveChangesAsync();
          

            
                if (res > 0)
            {
                return true;

            }
            return false;   

        }

        public async Task<ObservableCollection<User>> GetFrienList(User user)
        {
            var userList = user.Id;
            var userFriendListId = user.FriendLists.FirstOrDefault().Id;
            ObservableCollection<User> res=null;
          await  Task.Run(() =>
            {
              res = new ObservableCollection<User>(_context.Users.Include("FriendLists").Include("Messages").
                  Where(u => u.FriendLists.FirstOrDefault().Id == userFriendListId)
                  .Select(u => u)
                  .ToList());
            });



           
            return res;
        }



        public async Task<bool> SendMessage(Message message)
        {
             (await _context.Users.FirstOrDefaultAsync(u => u.Id ==message.Sender.Id)).Messages.Add(message);

            _context.Messages.Add(message);

            await _context.SaveChangesAsync();
            return true;
        
        }



        public async Task<ObservableCollection<Message>> GetMessageWithList(User mainUser, User friend)
        {
            var res = new ObservableCollection<Message>(await _context.Messages.Where(m => m.Receiver.Id == friend.Id && m.Sender.Id == mainUser.Id
                 || m.Receiver.Id == mainUser.Id && m.Sender.Id == friend.Id)
                     .Select(s => s).ToListAsync());
            foreach (var item in res)
            {
                if (item.Sender == mainUser)
                {
                    item.Sender.IsMain = true;
                }
                else if (item.Receiver==mainUser)
                {
                    item.Receiver.IsMain = true;
                }
            
            }

            return res;

      
        }


        public async Task<ObservableCollection<UserAddFriendShell>> GetAllUsersForAddFriend(User mainUser)
        {
            var res = new List<UserAddFriendShell>();
            var allUsers = await _context.Users.Include("Messages").Include("FriendLists").ToListAsync();

            allUsers.ForEach(u => res.Add(new UserAddFriendShell
            {
                Id = u.Id,
                FirstName=u.FirstName,
                LastName=u.LastName,
                Photo=u.Photo,
                IsFriend = mainUser.FriendLists.Any(fl => fl.Friends.Any(f=>f.Id==u.Id))

            }));

            return new ObservableCollection<UserAddFriendShell>(res);
        }


    }

}
