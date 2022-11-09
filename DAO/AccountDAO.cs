using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance 
        { 
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            } 
            private set => instance = value; 
        }

        private AccountDAO() { }
        public bool Login(string UserName, string Password, int type)
        {
            string CommandText = "USP_Login @userName ,  @passWord  , @accountType";
            DataTable result = DataProvider.Instance.ExecuteQuery(CommandText, new object[] {UserName.Trim(), Password.Trim(), type});

            return result.Rows.Count > 0;
        }
    }
}
