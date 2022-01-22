using Common.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebAppAspNetMvcAutofac.DataModel;

namespace WebAppAspNetMvcAutofac.Services.Abstractions
{
    public class GroupService : IGroupService
    {
        private readonly Lazy<IRepository<Group>> _groupRepository;

        public GroupService(Lazy<IRepository<Group>> groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public List<Group> GetEntities()
        {
            return _groupRepository.Value.GetQuery().ToList();
        }

        public Group Create()
        {
            return new Group();
        }
        public void Create(Group model)
        {
            _groupRepository.Value.Add(model);
            _groupRepository.Value.SaveChanges();
        }
        public void Delete(int id)
        {
            var group = _groupRepository.Value.FirstOrDefault(x => x.Id == id);
            if (group == null)
                throw new Exception("Group not found");

            _groupRepository.Value.Delete(group);
            _groupRepository.Value.SaveChanges();
        }
        public Group Edit(int id)
        {
            var group = _groupRepository.Value.FirstOrDefault(x => x.Id == id);
            if (group == null)
                throw new Exception("Group not found");

            return group;
        }
        public void Edit(Group model)
        {
            var group = _groupRepository.Value.FirstOrDefault(x => x.Id == model.Id);
            if (group == null)
                throw new Exception("Group not found");

            MappingGroup(model, group);

            _groupRepository.Value.Update(group);
            _groupRepository.Value.SaveChanges();
        }

        private void MappingGroup(Group sourse, Group destination)
        {
            destination.GroupName = sourse.GroupName;
            destination.NumberOfStudents = sourse.NumberOfStudents;
        }
    }
}
