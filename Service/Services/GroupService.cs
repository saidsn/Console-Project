using Repository.Repositories;
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


        public Group Delete(int id)
        {
            Group group = GetById(id);
            if (group == null) return null;
            _groupRepository.Delete(group);
            return group;
        }
       

        public List<Group> GetAll()
        {
            return _groupRepository.GetAll();
        }


        public Group GetById(int id)
        {
            var group = _groupRepository.Get(m =>m.Id == id);
            if (group == null) return null;
            return group;
        }


        public List<Group> Search(string name)
        {
            return _groupRepository.GetAll(m => m.Name.Trim().ToLower().StartsWith(name.ToLower().Trim()));
        }


        public Group Update(int id, Group group)
        {
            Group dbgroup = GetById(id);
            if (dbgroup is null) return null;
            group.Id = dbgroup.Id;
            _groupRepository.Update(group);
            return dbgroup;
        }


        public List<Group> GetByTeacher(string teacher)
        {
            return _groupRepository.GetAll(m => m.Teacher.Trim().ToLower() == teacher.Trim().ToLower());
        }


        public List<Group> GetByRoom(string room)
        {
            return _groupRepository.GetAll(m => m.Room.Trim().ToLower() == room.Trim().ToLower());
        }

        






    }
}
