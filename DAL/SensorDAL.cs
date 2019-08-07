using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Arduino.Models;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace Arduino.DAL
{
    public class SensorDAL
    {
        /// <summary>
        /// Get All Sensors
        /// </summary>
        /// <returns></returns>
        public List<Arduino_Sensor_Master> GetAllSensors()
        {
            using (SqlConnection con = new SqlConnection(Database.ConnectionString))
            {
                var para = new DynamicParameters();
                para.Add("@pMode", 1);
                return con.Query<Arduino_Sensor_Master>("USP_IUD_Sensor", para, null, true, 0, System.Data.CommandType.StoredProcedure).ToList();
            }
        }

        /// <summary>
        /// Get Sensor by Sensor ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Arduino_Sensor_Master GetSensor(int id)
        {
            using (SqlConnection con = new SqlConnection(Database.ConnectionString))
            {
                var para = new DynamicParameters();
                para.Add("@pMode", 2);
                para.Add("@pSensorID", id);
                return con.Query<Arduino_Sensor_Master>("USP_IUD_Sensor", para, null, true, 0, System.Data.CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        /// <summary>
        /// Search Sensor
        /// </summary>
        /// <param name="oArduino_Sensor_Master"></param>
        /// <returns></returns>
        public List<Arduino_Sensor_Master> SearchSensor(Arduino_Sensor_Master oArduino_Sensor_Master)
        {
            using (SqlConnection con = new SqlConnection(Database.ConnectionString))
            {
                var para = new DynamicParameters();
                para.Add("@pMode", 7);
                para.Add("@pSensorID", oArduino_Sensor_Master.SensorID);
                para.Add("@pSensorName", oArduino_Sensor_Master.SensorName);
                para.Add("@pSensorLocation", oArduino_Sensor_Master.SensorLocation);
                para.Add("@pSensorIP", oArduino_Sensor_Master.SensorIP);
                para.Add("@pisActive", oArduino_Sensor_Master.isActive);
                para.Add("@pCreatedDateTime", oArduino_Sensor_Master.CreatedDateTime);
                para.Add("@pCreatedby", oArduino_Sensor_Master.Createdby);
                para.Add("@pUpdatedDateTime", oArduino_Sensor_Master.UpdatedDateTime);
                para.Add("@pUpdatedby", oArduino_Sensor_Master.Updatedby);
                return con.Query<Arduino_Sensor_Master>("USP_IUD_Sensor", para, null, true, 0, System.Data.CommandType.StoredProcedure).ToList();
            }
        }

        /// <summary>
        /// Save Sensor 
        /// </summary>
        /// <param name="oArduino_Sensor_Master"></param>
        /// <returns></returns>
        public int SaveSensor(Arduino_Sensor_Master oArduino_Sensor_Master)
        {
            int res = -1;
            using (SqlConnection objcon = new SqlConnection(Database.ConnectionString))
            {
                SqlCommand objcommand = new SqlCommand("USP_IUD_Sensor", objcon);
                objcommand.CommandType = CommandType.StoredProcedure;
                objcommand.Parameters.AddWithValue("@pMode", "3");
                objcommand.Parameters.AddWithValue("@pSensorID", oArduino_Sensor_Master.SensorID);
                objcommand.Parameters.AddWithValue("@pSensorName", oArduino_Sensor_Master.SensorName);
                objcommand.Parameters.AddWithValue("@pSensorLocation", oArduino_Sensor_Master.SensorLocation);
                objcommand.Parameters.AddWithValue("@pSensorIP", oArduino_Sensor_Master.SensorIP);
                objcommand.Parameters.AddWithValue("@pisActive", oArduino_Sensor_Master.isActive);
                objcommand.Parameters.AddWithValue("@pCreatedDateTime", oArduino_Sensor_Master.CreatedDateTime);
                objcommand.Parameters.AddWithValue("@pCreatedby", oArduino_Sensor_Master.Createdby);
                objcommand.Parameters.AddWithValue("@pUpdatedDateTime", oArduino_Sensor_Master.UpdatedDateTime);
                objcommand.Parameters.AddWithValue("@pUpdatedby", oArduino_Sensor_Master.Updatedby);
                objcon.Open();
                res = objcommand.ExecuteNonQuery();
                objcon.Close();
            }
            return res;
        }

        /// <summary>
        /// Update Sensor
        /// </summary>
        /// <param name="oArduino_Sensor_Master"></param>
        /// <returns></returns>
        public int UpdateSensor(Arduino_Sensor_Master oArduino_Sensor_Master)
        {
            int res = -1;
            using (SqlConnection objcon = new SqlConnection(Database.ConnectionString))
            {
                SqlCommand objcommand = new SqlCommand("USP_IUD_Sensor", objcon);
                objcommand.CommandType = CommandType.StoredProcedure;
                objcommand.Parameters.AddWithValue("@pMode", "4");
                objcommand.Parameters.AddWithValue("@pSensorID", oArduino_Sensor_Master.SensorID);
                objcommand.Parameters.AddWithValue("@pSensorName", oArduino_Sensor_Master.SensorName);
                objcommand.Parameters.AddWithValue("@pSensorLocation", oArduino_Sensor_Master.SensorLocation);
                objcommand.Parameters.AddWithValue("@pSensorIP", oArduino_Sensor_Master.SensorIP);
                objcommand.Parameters.AddWithValue("@pisActive", oArduino_Sensor_Master.isActive);
                objcommand.Parameters.AddWithValue("@pCreatedDateTime", oArduino_Sensor_Master.CreatedDateTime);
                objcommand.Parameters.AddWithValue("@pCreatedby", oArduino_Sensor_Master.Createdby);
                objcommand.Parameters.AddWithValue("@pUpdatedDateTime", oArduino_Sensor_Master.UpdatedDateTime);
                objcommand.Parameters.AddWithValue("@pUpdatedby", oArduino_Sensor_Master.Updatedby);
                objcon.Open();
                res = objcommand.ExecuteNonQuery();
                objcon.Close();
            }
            return res;
        }

        /// <summary>
        /// Delete Sensor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteSensor(int id)
        {
            int res = -1;
            using (SqlConnection objcon = new SqlConnection(Database.ConnectionString))
            {
                SqlCommand objcommand = new SqlCommand("USP_IUD_Sensor", objcon);
                objcommand.CommandType = CommandType.StoredProcedure;
                objcommand.Parameters.AddWithValue("@pMode", "5");
                objcommand.Parameters.AddWithValue("@pSensorID", id);                
                objcon.Open();
                res = objcommand.ExecuteNonQuery();
                objcon.Close();
            }
            return res;
        }
    }
}