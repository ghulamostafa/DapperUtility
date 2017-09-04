using Dapper;
using DapperUtility.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static DapperUtility.TheEnumModel;

namespace DapperUtility
{
    /// <summary>
    /// This is going to be used for multiple basic and important things in the future. This will show good magic.
    /// </summary>
    public class Utility
    {
        #region The Resources

        static string theConString = "Sooq7Entity";

        #endregion

        /// <summary>
        /// Sends back the response class object including result and message
        /// </summary>
        /// <param name="responseObj"></param>
        /// <returns></returns>
        public static IEnumerable<ResponseModel> GetResponseObject(DynamicParameters responseObj)
        {
            var resp = new List<ResponseModel>();
            try
            {
                resp.Add(new ResponseModel(responseObj.Get<int>("result"), responseObj.Get<string>("message")));
            }
            catch (Exception e)
            {
                resp.Add(new ResponseModel(0, e.ToString()));
            }

            return resp;
        }

        /// <summary>
        /// This method uses the Dapper Library to get multiple result sets from SQL Server and return it in a single Base Class Object so that one method is all what is required.
        /// </summary>
        /// <param name="StoredProcedure">The Stored Procedure Name</param>
        /// <param name="Mode">The types of responses from a dapper SqlMapper.QueryMultiple query</param>
        /// <param name="paramList">The paramwithvalues class array</param>
        /// <returns></returns>
        public static IEnumerable<MainResponseObject> DapperRepo(string StoredProcedure,
                                                                                    ResponseMode Mode,
                                                                                    params paramWithValues[] paramList)
        {
            // This is SQL Connection only, do not mess with it
            SqlConnection con;
            string constr = ConfigurationManager.ConnectionStrings[theConString].ToString();
            con = new SqlConnection(constr);
            con.Open();

            // These are argument related only
            DynamicParameters args = new DynamicParameters(new { });
            int result = 0;
            string message = "";

            // Take all from paramWithValues list and turn in to Dapper Arguments
            foreach (paramWithValues item in paramList)
            {
                args.Add(item.param, item.value, item.dbType, item.paramDirection);
            }
            args.Add("@result", result, DbType.Int32, ParameterDirection.Output);
            args.Add("@message", message, DbType.String, ParameterDirection.Output);

            var objDetails = SqlMapper.QueryMultiple(con, StoredProcedure, param: args, commandType: CommandType.StoredProcedure);

            MainResponseObject ObjMaster = new MainResponseObject();

            // This will switch and call the appropriate function
            // The Mode object will identify which function to call and a return type of an inherited class of MainResponseObject is set
            switch (Mode)
            {
                default:
                    break;
            }

            ObjMaster.Response = GetResponseObject(args).ToList();

            List<MainResponseObject> MainResponseObject = new List<MainResponseObject>();
            MainResponseObject.Add(ObjMaster);
            con.Close();

            return MainResponseObject;
        }

        /// <summary>
        /// This method uses the Dapper Library to get multiple result sets from SQL Server and return it in a single Base Class Object so that one method is all what is required. Stored Procedure as Enum
        /// </summary>
        /// <param name="StoredProcedure">The Stored Procedure Name as Enum</param>
        /// <param name="Mode">The types of responses from a dapper SqlMapper.QueryMultiple query</param>
        /// <param name="paramList">The paramwithvalues class array</param>
        /// <returns></returns>
        public static IEnumerable<MainResponseObject> DapperRepo(SP StoredProcedure,
                                                                                    ResponseMode Mode,
                                                                                    params paramWithValues[] paramList)
        {
            // This is SQL Connection only, do not mess with it
            SqlConnection con;
            string constr = ConfigurationManager.ConnectionStrings[theConString].ToString();
            con = new SqlConnection(constr);
            con.Open();

            // These are argument related only
            DynamicParameters args = new DynamicParameters(new { });
            int result = 0;
            string message = "";

            // Take all from paramWithValues list and turn in to Dapper Arguments
            foreach (paramWithValues item in paramList)
            {
                args.Add(item.param, item.value, item.dbType, item.paramDirection);
            }
            args.Add("@result", result, DbType.Int32, ParameterDirection.Output);
            args.Add("@message", message, DbType.String, ParameterDirection.Output);

            var objDetails = SqlMapper.QueryMultiple(con, StoredProcedure.ToString(), param: args, commandType: CommandType.StoredProcedure);

            MainResponseObject ObjMaster = new MainResponseObject();

            // This will switch and call the appropriate function
            // The Mode object will identify which function to call and a return type of an inherited class of MainResponseObject is set
            switch (Mode)
            {
                default:
                    break;
            }

            ObjMaster.Response = GetResponseObject(args).ToList();

            List<MainResponseObject> MainResponseObject = new List<MainResponseObject>();
            MainResponseObject.Add(ObjMaster);
            con.Close();

            return MainResponseObject;
        }
        
    }
}
