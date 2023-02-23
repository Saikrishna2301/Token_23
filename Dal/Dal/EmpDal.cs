using Model.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace Dal.Dal
{
   public class EmpDal
    {
    public ErrorMessages RegisterAssetDetails(Emloyee   employee)
        {

            ErrorMessages Response = new ErrorMessages();
            using (DataBaseManager databaseManager = new DataBaseManager())
            {
                using (SqlTransaction transaction = databaseManager.sqlConnection.BeginTransaction("RegisterAssets"))
                {
                    try
                    {
                        databaseManager.sqlCommand = new SqlCommand("[dbo].[Sp_UserForm]", databaseManager.sqlConnection, transaction);
                        databaseManager.sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        databaseManager.sqlCommand.Parameters.Add("@First_Name", SqlDbType.VarChar).Value = employee.FirstName;
                        databaseManager.sqlCommand.Parameters.Add("@last_Name", SqlDbType.VarChar).Value = employee.Lastname;
                        databaseManager.sqlCommand.Parameters.Add("@User_Id", SqlDbType.VarChar).Value = employee.UserId;
                        databaseManager.sqlCommand.Parameters.Add("@User_Password", SqlDbType.VarChar).Value = employee.Passcode;
                        databaseManager.sqlCommand.Parameters.Add("@Full_Name", SqlDbType.VarChar).Value = employee.PreferredName;
                        databaseManager.sqlCommand.Parameters.Add("@Phone_Number", SqlDbType.VarChar).Value = employee.Phonenumber;
                        //Regex phoneRegex = new Regex(@"^\+?\d{0,2}\s?\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}$");
                         //Regex phoneRegex = new Regex(@"^[9876]\d{9}$");
                         Regex phoneRegex = new Regex("(0|91)?[7-9][0-9]{9}");
                        if (!phoneRegex.IsMatch(employee.Phonenumber))
                        {
                            throw new ArgumentException("Invalid phone number format");
                        }
                        databaseManager.sqlCommand.Parameters.Add("@Email_id", SqlDbType.VarChar).Value = employee.MailId;
                        Regex gmailRegex = new Regex(@"^[a-zA-Z0-9_.+-]+@gmail\.com$");
                        if (!string.IsNullOrEmpty(employee.MailId) && !Regex.IsMatch(employee.MailId, @"^[a-zA-Z0-9._%+-]+@gmail\.com$"))
                        {
                            throw new Exception("Email address must be a valid Gmail address.");

                        }
                        //else
                        //{
                        //    
                        //}
                        databaseManager.sqlCommand.Parameters.Add("@Address", SqlDbType.VarChar).Value = employee.Address;
                        databaseManager.sqlCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = employee.gender;
                        databaseManager.sqlCommand.Parameters.Add("@DOB", SqlDbType.VarChar).Value = employee.bod;
                        int result = databaseManager.sqlCommand.ExecuteNonQuery();
                        if (result == -1)
                        {
                            throw new EntityExistsException("AssetId is Already Exists");
                        }
                        transaction.Commit();
                        Response.Status = "Success";
                        Response.Message = " Data Inserted successfully";
                        return Response;
                    }

                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }


        }
    }
}
