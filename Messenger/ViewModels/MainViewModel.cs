using Messenger.Infrastructure.Services;
using Messenger.Models;
using Messenger.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Messenger.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        #region Commands
        public ActionCommand WindowMinimiseCommand => new ActionCommand(x => WindowMinimize());
        public ActionCommand WindowMaximiseCommand => new ActionCommand(x => WindowMaximize());
        public ActionCommand SendMessageCommand => new ActionCommand(x => MessageBox.Show("NewText"));
        public ActionCommand AppCloseCommand => new ActionCommand(x => Application.Current.Shutdown());



        #endregion

        #region Property
        private string newText;

        public string NewText
        {
            get => newText;
            set
            {
                newText = value;
                OnPropertyChanged();
            
            }
        }

        private User selectedFriend;
        public User SelectedFriend
        {
            get { return selectedFriend; }
            set 
            { 
                selectedFriend = value;
                Chat();

                OnPropertyChanged();
            }
        }




        private event Action Chat;
         
        private User mainUserTemp;



        private ObservableCollection<Message> chatWithUser;
        public ObservableCollection<Message> ChatWithUser
        {
            get => chatWithUser;
            set
            {
                chatWithUser = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<User> friends;

        public ObservableCollection<User> Friends
        {
            get { return friends; }
            set
            { 
                 friends = value;
                OnPropertyChanged();
            }
        }




        private UserService userService; 

        #endregion

        public MainViewModel()
        {
            
            
            Chat += ChatWU;
            LoadMeth().GetAwaiter();

        }




        private async void ChatWU()
        {
            ChatWithUser = await userService.GetMessageWithList(mainUserTemp, selectedFriend);
        }



        private async Task LoadMeth()
        {

            #region

            /*   var user2 = new User
               {
                   FirstName = "Second",

               };

               var user4 = new User
               {
                   FirstName = "forth",

               };*/

            #endregion

            userService = new UserService();
       
            mainUserTemp = await userService.GetUser(15);


            //  await userService.AppPhotoSourse(await userService.GetUser(15));

            ObservableCollection<User> tempUsers = await userService.GetFrienList(await userService.GetUser(15));
     
         
            foreach (var item in tempUsers)
            {
              var  tempMessages = await userService.GetMessageWithList(mainUserTemp, item);
                item.LastMessage = tempMessages.LastOrDefault()?.Text;

            }
            Friends = tempUsers;
            #region
            /*  var res = await userService.GetMessageWithList(await userService.GetUser(17), await userService.GetUser(16));
              string text = "";

               foreach (var item in res)
                {
                    text+= item.Text+"\n";
                }
                MessageBox.Show(text);*/

            //   await userService.AddNewUser(user1);//так как медот асинхронный , а констурктор нет.
            //  await userService.AddNewUser(user2);
            //    await userService.AddNewFriend(await userService.GetUser(15), await userService.GetUser(17));

            /*
                    
                        Message mes1 = new Message
                        {
                            Text = "lkjlkj",
                            DateOfSend = DateTime.Now,
                            Sender = await userService.GetUser(16),
                            Receiver = await userService.GetUser(17)
                        };

                        Message mes2 = new Message
                        {
                            Text = "lkjlkj",
                            DateOfSend = DateTime.Now,
                            Sender = await userService.GetUser(15),
                            Receiver = await userService.GetUser(17)
                        };

                        await userService.SendMessage(mes);




               */

 /*           Message mes = new Message
            {
                Text = "Проверка  ",
                DateOfSend = DateTime.Now,
                Sender = await userService.GetUser(17),
                Receiver = await userService.GetUser(15)
            };
            await userService.SendMessage(mes);*/



            #endregion
        }


        private void WindowMinimize()
        { 
        Application.Current.MainWindow.WindowState=WindowState.Minimized;
        }

        private void WindowMaximize()
        {
            if (Application.Current.MainWindow.WindowState == WindowState.Normal)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
        
        
        }


        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
        
        if(PropertyChanged!=null) PropertyChanged(this, new PropertyChangedEventArgs(property));    
        }

    }
}
