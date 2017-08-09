﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
    public abstract class User : IUser
    {
        private string username;

        public User(string username)
        {
            this.Username = username;
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3 || value.Length > 16)
                {
                    throw new ArgumentException("User's username should be between 3 and 16 symbols long!");
                }
                this.username = value;
            }
        }
    }
}
