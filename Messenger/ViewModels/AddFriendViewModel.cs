﻿using Messenger.Infrastructure.Services;
using Messenger.ModelShells;
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
    public class AddFriendViewModel : BaseViewModel
    {
        #region Properties
        private string name;
		public string Name
        {
			get { return name; }
			set { name = value; UpdateValue<string>(ref name, value); }
		}


		private string lastName;
		public string LastName
        {
			get { return lastName; }
			set { lastName = value; UpdateValue<string>(ref lastName, value); }
		}

		private ObservableCollection<UserAddFriendShell> allUsers;

		public ObservableCollection<UserAddFriendShell> AllUsers
		{
			get => allUsers; 
			set
			{
				UpdateValue(ref allUsers, value);	
			}
		}

		private readonly UserService _userService;


		#endregion

		#region Commands

		public ActionCommand AddFriendCommand => new ActionCommand(x => MessageBox.Show("Cheked"));
        public ActionCommand CloseWindowCommand => new ActionCommand(x => Application.Current.Windows[Application.Current.Windows.Count-1].Close());

        #endregion

        public AddFriendViewModel()
		{

			_userService = new UserService();
			LoadInfo().GetAwaiter();
		}

		private async Task LoadInfo()
		{
			AllUsers = await _userService.GetAllUsersForAddFriend(await _userService.GetUser(15));

		}



	}
}
