using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetMan.CoreBusiness;
using AssetMan.UseCases.RepositoryPlugins;
using AssetMan.Plugins.Repository.SqliteDb.DataAccess;

namespace AssetMan.Plugins.Repository.SqliteDb
{
    public class ContactRepository : IContactRepository
    {

        private SqlDataAcess db = new SqlDataAcess();

        private readonly string ConnectionString = DataConnects.GetConnectionString();

        #region Listing 
        //Listing
        public async Task<List<Contact>> GetAllContacts()
        {
            string sql = "SELECT * FROM Contacts";
            return await db.LoadData<Contact, dynamic>(sql, new { }, ConnectionString);
        }

        //Get Contact
        public async Task<Contact> GetContactById(int id)
        {
            string sql = "SELECT * FROM Contacts WHERE ID = @ID";
            Contact output;
            output = await Task.Run(()=> db.LoadData<Contact, dynamic>(sql, new { ID = id }, ConnectionString).Result.FirstOrDefault());

            if (output == null)
            {
                //Do something

                return null;
            }

            return output;

        }
        //write 
        public async Task CreateContact(Contact contact)
        {
            string sql = "INSERT INTO Contacts (Employee_ID, WorkingTeam, LastName, FirstName, EmailAddress, JobTitle, BusinessPhone, HomePhone,"
                + "	MobilePhone, FaxNumber, Address, District, CityProvince, PostalCode, Notes, Attachments, Department, Company)"
                + " VALUES (@Employee_ID, @WorkingTeam, @LastName, @FirstName, @EmailAddress, @JobTitle, @BusinessPhone, @HomePhone,"
                + "	@MobilePhone, @FaxNumber, @Address, @District, @CityProvince, @PostalCode, @Notes, @Attachments, @Department, @Company);";

            await db.SavingData(sql, new
            {
                contact.Employee_ID,
                contact.WorkingTeam,
                contact.LastName,
                contact.FirstName,
                contact.EmailAddress,
                contact.JobTitle,
                contact.BusinessPhone,
                contact.HomePhone,
                contact.MobilePhone,
                contact.FaxNumber,
                contact.Address,
                contact.District,
                contact.CityProvince,
                contact.PostalCode,
                contact.Notes,
                contact.Attachments,
                contact.Department,
                contact.Company
            }, ConnectionString); 


        }
        //update Contact 
        public async Task UpdateContact(Contact asset)
        {
            string sql = "UPDATE Contacts SET Employee_ID = @Employee_ID, WorkingTeam = @WorkingTeam, LastName = @LastName, FirstName = @FirstName,"
                + " EmailAddress = @EmailAddress, JobTitle = @JobTitle, BusinessPhone = @BusinessPhone, HomePhone = @HomePhone, MobilePhone = @MobilePhone,"
                + " FaxNumber = @FaxNumber, Address = @Address, District = @District, CityProvince = @CityProvince, PostalCode  = @PostalCode,"
                + " Notes = @Notes, Attachments = @Attachments, Department = @Department,  Company = @Company"
                + " WHERE ID = @ID ";

            await db.SavingData(sql, asset, ConnectionString);

        }

        //remove Contact 
        public async Task RemoveContact(int id)
        {
            string sql = "DELETE from Contacts WHERE ID = @ID;";

            await db.SavingData(sql, new { ID = id }, ConnectionString);

        }
        #endregion


    }
}
