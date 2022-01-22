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
    public class LessonService: ILessonService
    {
        private readonly Lazy<IRepository<Lesson>> _lessonRepository;
        private readonly Lazy<IRepository<Discipline>> _disciplineRepository;
        private readonly Lazy<IRepository<Group>> _groupRepository;
        private readonly Lazy<IRepository<Teacher>> _teacherRepository;        

        public LessonService(Lazy<IRepository<Lesson>> lessonRepository,
            Lazy<IRepository<Discipline>> disciplineRepository,
            Lazy<IRepository<Group>> groupRepository,
            Lazy<IRepository<Teacher>> teacherRepository)
        {
            _lessonRepository = lessonRepository;
            _disciplineRepository = disciplineRepository;
            _groupRepository = groupRepository;
            _teacherRepository = teacherRepository;
        }
        public List<Lesson> GetEntities()
        {
            return _lessonRepository.Value.GetQuery().ToList();
        }

        public Lesson Create()
        {
            return new Lesson();
        }
        public void Create(Lesson model)
        {
            
            

            if (model.GroupIds != null && model.GroupIds.Any())
            {
                var group = _groupRepository.Value.GetQuery().Where(s => model.GroupIds.Contains(s.Id)).ToList();
                model.Groups = group;
            }
                       

            _lessonRepository.Value.Add(model);
            _lessonRepository.Value.SaveChanges();
        }
        public void Delete(int id)
        {
            var lesson = _lessonRepository.Value.FirstOrDefault(x => x.Id == id);
            if (lesson == null)
                throw new Exception("Lesson not found");

            _lessonRepository.Value.Delete(lesson);
            _lessonRepository.Value.SaveChanges();
        }
        public Lesson Edit(int id)
        {
            var lesson = _lessonRepository.Value.FirstOrDefault(x => x.Id == id);
            if (lesson == null)
                throw new Exception("Lesson not found");

            return lesson;
        }
        public void Edit(Lesson model)
        {
            var lesson = _lessonRepository.Value.FirstOrDefault(x => x.Id == model.Id);
            if (lesson == null)
                throw new Exception("Lesson not found");

            

            MappingLesson(model, lesson);

            _lessonRepository.Value.Update(lesson);
            _lessonRepository.Value.SaveChanges();
        }        

        private void MappingLesson(Lesson sourse, Lesson destination)
        {
            destination.Number = sourse.Number;
            destination.DisciplineId = sourse.DisciplineId;
            destination.Discipline = sourse.Discipline;
            destination.TeacherId = sourse.TeacherId;
            destination.Teacher = sourse.Teacher;

            if (destination.Groups != null)
                destination.Groups.Clear();

            if (sourse.GroupIds != null && sourse.GroupIds.Any())
                destination.Groups = _groupRepository.Value.GetQuery().Where(s => sourse.GroupIds.Contains(s.Id)).ToList();



        }
    }
}
