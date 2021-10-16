namespace AssetMan.UseCases.DTO
{
    public interface IContactDTO
    {
        string Address { get; set; }
        string Attachments { get; set; }
        string BusinessPhone { get; set; }
        string CityProvince { get; set; }
        string Company { get; set; }
        string Department { get; set; }
        string District { get; set; }
        string EmailAddress { get; set; }
        string Employee_ID { get; set; }
        string FaxNumber { get; set; }
        string FirstName { get; set; }
        string FullName { get; set; }
        string HomePhone { get; set; }
        int ID { get; set; }
        string JobTitle { get; set; }
        string LastName { get; set; }
        string MobilePhone { get; set; }
        string Notes { get; set; }
        string PostalCode { get; set; }
        string WorkingTeam { get; set; }
    }
}