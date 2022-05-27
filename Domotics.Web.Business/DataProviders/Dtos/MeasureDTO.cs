namespace Domotics.Web.Business.DataProviders.Dtos
{
    using System;

    public sealed class MeasureDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; }

        public decimal Value { get; set; }
    }
}
