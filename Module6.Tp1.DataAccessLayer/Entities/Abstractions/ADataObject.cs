using System;

namespace Module6.Tp1.DataAccessLayer.Entities.Abstractions
{
    public abstract class ADataObject
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
