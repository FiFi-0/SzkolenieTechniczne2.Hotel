namespace SzkolenieTechniczne2.Hotel.Common.Entities;

internal interface ISoftDeletable
{
    bool IsDeleted { get; set; }
}
