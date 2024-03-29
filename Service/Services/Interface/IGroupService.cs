﻿using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Service.Services.Interface
{
    public interface IGroupService
    {
        Group Create(Group group);

        Group Update(int id, Group group);

        Group Delete(int id);

        Group GetById(int id);

        List<Group> GetAll();

        List<Group> Search(string name);

        public List<Group> GetByTeacher(string teacher);

        public List<Group> GetByRoom(string room);


    }
}
