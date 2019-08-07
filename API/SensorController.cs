using Arduino.DAL;
using Arduino.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Arduino.API
{
    public class SensorController : ApiController
    {
        SensorDAL oSensorDAL;
        public SensorController()
        { 
            oSensorDAL = new SensorDAL();
        }

        // Get All The Arduino_Sensor_Master        
        public List<Arduino_Sensor_Master> Get()
        {
            return oSensorDAL.GetAllSensors();
        }

        // Get Arduino_Sensor_Master by id
        public Arduino_Sensor_Master Get(int id)
        {
            Arduino_Sensor_Master oArduino_Sensor_Master = oSensorDAL.GetSensor(id);
            if (oArduino_Sensor_Master == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return oArduino_Sensor_Master;
        }

        // Get All The Arduino_Sensor_Master      
        [Route("API/Sensor/GetSearch")]
        public List<Arduino_Sensor_Master> GetSearch(Arduino_Sensor_Master oArduino_Sensor_Master)
        {            
            return oSensorDAL.SearchSensor(oArduino_Sensor_Master);
        }

        // Insert Arduino_Sensor_Master
        public IHttpActionResult Post(Arduino_Sensor_Master oArduino_Sensor_Master)
        {
            return Ok(oSensorDAL.SaveSensor(oArduino_Sensor_Master));
        }

        // Update Arduino_Sensor_Master
        public IHttpActionResult Put(Arduino_Sensor_Master oArduino_Sensor_Master)
        {            
            return Ok(oSensorDAL.UpdateSensor(oArduino_Sensor_Master));
        }

        // Delete Arduino_Sensor_Master By Id
        public IHttpActionResult Delete(int id)
        {
            return Ok(oSensorDAL.DeleteSensor(id));            
        }
    }
}
