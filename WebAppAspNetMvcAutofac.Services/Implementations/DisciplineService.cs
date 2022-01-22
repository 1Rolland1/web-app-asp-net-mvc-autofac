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
    public class DisciplineService : IDisciplineService
    {
        private readonly Lazy<IRepository<Discipline>> _disciplineRepository;

        public DisciplineService(Lazy<IRepository<Discipline>> disciplineRepository)
        {
            _disciplineRepository = disciplineRepository;
        }
        public List<Discipline> GetEntities()
        {
            return _disciplineRepository.Value.GetQuery().ToList();
        }

        public Discipline Create()
        {
            return new Discipline();
        }
        public void Create(Discipline model)
        {
            _disciplineRepository.Value.Add(model);
            _disciplineRepository.Value.SaveChanges();
        }
        public void Delete(int id)
        {
            var discipline = _disciplineRepository.Value.FirstOrDefault(x => x.Id == id);
            if (discipline == null)
                throw new Exception("Discipline not found");

            _disciplineRepository.Value.Delete(discipline);
            _disciplineRepository.Value.SaveChanges();
        }
        public Discipline Edit(int id)
        {
            var discipline = _disciplineRepository.Value.FirstOrDefault(x => x.Id == id);
            if (discipline == null)
                throw new Exception("Discipline not found");

            return discipline;
        }
        public void Edit(Discipline model)
        {
            var discipline = _disciplineRepository.Value.FirstOrDefault(x => x.Id == model.Id);
            if (discipline == null)
                throw new Exception("Discipline not found");

            MappingDiscipline(model, discipline);

            _disciplineRepository.Value.Update(discipline);
            _disciplineRepository.Value.SaveChanges();
        }

        private void MappingDiscipline(Discipline sourse, Discipline destination)
        {
            destination.Name = sourse.Name;
            destination.DisciplineGoal = sourse.DisciplineGoal;
            destination.DisciplineObjectives = sourse.DisciplineObjectives;
            destination.MainSections = sourse.MainSections;
        }
    }
}
