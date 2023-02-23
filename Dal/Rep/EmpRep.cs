using Dal.Dal;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Rep
{
    public class EmpRep
    {
        public ErrorMessages RegisterAssetDetails(Emloyee employee)
        {
            try
            {
                return new EmpDal().RegisterAssetDetails(employee);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
