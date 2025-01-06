using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnesFidanAssignment2.Services
{
    internal class CrudOperationInDataSet
    {

        private SqlConnection conn { get; set; }

        private SqlCommandBuilder cmdBuilder { get; set; }

        private SqlDataAdapter adapter { get; set; }

        private DataSet ds { get; set; }

        public DataTable tblProducts { get; set; }





    }
}
