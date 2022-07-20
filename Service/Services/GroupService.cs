﻿using Repository.Repositories;
using Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private GroupRepository _groupRepository;
        private int _count;

        public GroupService()
        {
            _groupRepository = new GroupRepository();
        }

        public Group Create(Group group)
        {
            group.Id = _count;
            _groupRepository.Create(group);
            _count++;
            return group;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAll()
        {
            throw new NotImplementedException();
        }

        public Group GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Group Update(int id, Group group)
        {
            throw new NotImplementedException();
        }
    }
}
