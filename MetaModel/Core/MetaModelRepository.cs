using MetaModel.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using MetaModel.Core;
using Microsoft.EntityFrameworkCore;

namespace MetaModel.Core
{
    public class MetaModelRepository<T>: IMetamodelRepository<T> where T: Base
    {
        private readonly ApplicationDBContext _context;

        private static MetaModelRepository<T> _instance;

        private MetaModelRepository()
        {
            _context = new ApplicationDBContext();
            _context.Database.EnsureCreated();
        }

        public static MetaModelRepository<T> GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MetaModelRepository<T>();
            }
            return _instance;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Types
                .Include(t => t.Objects)
                .ThenInclude(o => o.Values)
                .ThenInclude(v => v.Attribute)
                .SingleOrDefault(x => x.Name == typeof(T).FullName)
                .Objects
                .Select(x => _loadObject(x));
        }

        public T GetById(Guid id)
        {
            return _loadObject(_context.Objects
                .Include(o => o.Values)
                .ThenInclude(v => v.Attribute)
                .Single(x => x.Id == id));
        }

        public void Save(T entity)
        {
            //check if current repository type exists
            var type = _ensureTypeCreated();
            var obj = _context.Objects.Find(entity.Id);
            if (!(obj is null)) _saveExisting(entity, obj);
            _saveNew(entity,type);
        }

        private Entities.Type _ensureTypeCreated()
        {
            var className = typeof(T).FullName;
            var item = _context.Types
                .Include(x => x.Attributes)
                .SingleOrDefault(x => x.Name == className);
            if (item != null) return item;

            //create type and attributes
            item = new Entities.Type() { Name = className };
            _context.Types.Add(item);

            var props = typeof(T)
                .GetProperties();
            var attributes = typeof(T)
                .GetProperties()
                .Where(x => x.Name.ToLower() != "id")
                .Select(x => new Entities.Attribute() { Name = x.Name, Type = item })
                .ToArray();

            //save metadata
            _context.Attributes.AddRange(attributes);
            _context.SaveChanges();
            return item;
        }

        private void _saveExisting(T entity, Entities.Object obj)
        {
            foreach (var value in obj.Values)
            {
                object attrVal = entity.GetType().GetProperty(value.Attribute.Name)?.GetValue(entity);
                value.Data = Converter.StringFromObject(attrVal);
            }
            _context.SaveChanges();
        }

        private void _saveNew(T entity, Entities.Type type)
        {
            var obj = new Entities.Object() { Type = type };
            _context.Objects.Add(obj);
            entity.Id = obj.Id;
            foreach (var attribute in type.Attributes)
            {
                object attrVal = entity.GetType().GetProperty(attribute.Name).GetValue(entity);
                var value = new Value() {
                    Attribute = attribute,
                    Data = Converter.StringFromObject(attrVal),
                    Object = obj
                };
                _context.Values.Add(value);
            }
            _context.SaveChanges();
        }

        private T _loadObject(Entities.Object obj)
        {
            var entity = Activator.CreateInstance<T>();
            entity.Id = obj.Id;
            foreach (var val in obj.Values)
            {
                var prop = entity.GetType().GetProperty(val.Attribute.Name);
                prop.SetValue(entity,Converter.ObjectFromString(prop.PropertyType, val.Data));
            }
            return entity;
        }
    }
}
