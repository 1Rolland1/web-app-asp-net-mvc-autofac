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
    public class TeacherService : ITeacherService
    {
        private readonly Lazy<IRepository<Teacher>> _teacherRepository;
        private readonly Lazy<IRepository<TeacherImage>> _teacherImageRepository;

        public TeacherService(Lazy<IRepository<Teacher>> teacherRepository,
            Lazy<IRepository<TeacherImage>> teacherImageRepository)
        {
            _teacherRepository = teacherRepository;
            _teacherImageRepository = teacherImageRepository;
        }
        public List<Teacher> GetEntities()
        {
            return _teacherRepository.Value.GetQuery().ToList();
        }

        public Teacher Create()
        {
            return new Teacher();
        }
        public void Create(Teacher model)
        {
            if (model.TeacherImageFile != null)
            {
                var data = new byte[model.TeacherImageFile.ContentLength];
                model.TeacherImageFile.InputStream.Read(data, 0, model.TeacherImageFile.ContentLength);

                model.TeacherImage = new TeacherImage()
                {
                    Guid = Guid.NewGuid(),
                    DateChanged = DateTime.Now,
                    Data = data,
                    ContentType = model.TeacherImageFile.ContentType,
                    FileName = model.TeacherImageFile.FileName
                };
            }


            _teacherRepository.Value.Add(model);
            _teacherRepository.Value.SaveChanges();
        }
        public void Delete(int id)
        {
            var teacher = _teacherRepository.Value.FirstOrDefault(x => x.Id == id);
            if (teacher == null)
                throw new Exception("Teacher not found");

            _teacherRepository.Value.Delete(teacher);
            _teacherRepository.Value.SaveChanges();
        }
        public Teacher Edit(int id)
        {
            var teacher = _teacherRepository.Value.FirstOrDefault(x => x.Id == id);
            if (teacher == null)
                throw new Exception("Teacher not found");

            return teacher;
        }
        public void Edit(Teacher model)
        {
            var teacher = _teacherRepository.Value.FirstOrDefault(x => x.Id == model.Id);
            if (teacher == null)
                throw new Exception("Teacher not found");

            MappingTeacher(model, teacher);

            _teacherRepository.Value.Update(teacher);
            _teacherRepository.Value.SaveChanges();
        }

        public TeacherImage GetImage(int id, HttpServerUtilityBase server)
        {
            var image = _teacherImageRepository.Value.FirstOrDefault(x => x.Id == id);
            if (image == null)
            {
                FileStream fs = System.IO.File.OpenRead(server.MapPath(@"~/Content/Images/not-foto.png"));
                byte[] fileData = new byte[fs.Length];
                fs.Read(fileData, 0, (int)fs.Length);
                fs.Close();

                image = new TeacherImage()
                {
                    ContentType = "image/jpeg",
                    Data = fileData
                };
            }

            return image;
        }

        private void MappingTeacher(Teacher sourse, Teacher destination)
        {
            destination.Name = sourse.Name;
            destination.Sex = sourse.Sex;
            destination.Position = sourse.Position;

            if (sourse.TeacherImageFile != null)
            {
                var image = _teacherImageRepository.Value.FirstOrDefault(x => x.Id == sourse.Id);
                if (image != null)
                {
                    _teacherImageRepository.Value.Delete(image);
                    _teacherImageRepository.Value.SaveChanges();
                }


                var data = new byte[sourse.TeacherImageFile.ContentLength];
                sourse.TeacherImageFile.InputStream.Read(data, 0, sourse.TeacherImageFile.ContentLength);

                destination.TeacherImage = new TeacherImage()
                {
                    Guid = Guid.NewGuid(),
                    DateChanged = DateTime.Now,
                    Data = data,
                    ContentType = sourse.TeacherImageFile.ContentType,
                    FileName = sourse.TeacherImageFile.FileName
                };
            }
        }
    }
}
