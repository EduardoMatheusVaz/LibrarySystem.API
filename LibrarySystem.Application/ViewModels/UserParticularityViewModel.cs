﻿using LibrarySystem.Core.Entities;
using System.ComponentModel;

namespace LibrarySystem.Application.ViewModels;

public class UserParticularityViewModel : BaseEntity
{
    public UserParticularityViewModel(int id, string name, string email, string phone)
    {
        Id = id;
        Name = name;
        Email = email;
        Phone = phone;
    }

    public int Id { get; set; }
    public string Name { get;  set; }
    public string Email { get;  set; }
    public string Phone { get;  set; }
}