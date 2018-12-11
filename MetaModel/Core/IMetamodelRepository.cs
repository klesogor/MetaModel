using MetaModel.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetaModel.Core
{
    //there are no real need in this, I just described which operations we need to implement
    public interface IMetamodelRepository<T> where T: Base
    {
        IEnumerable<T> GetAll();

        T GetById(Guid id);

        void Save(T entity);

        void Delete(T entity);
    }
}
