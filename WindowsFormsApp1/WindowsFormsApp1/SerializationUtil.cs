using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    public class SerializationUtil
    {
        public void SerializeXML(Users users)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Users));

            using (FileStream fs = new FileStream("Users.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, users);
            }
        }
        public Users DeserializeXML()
        {
            XmlSerializer xml = new XmlSerializer(typeof(Users));

            using (FileStream fs = new FileStream("Users.xml", FileMode.OpenOrCreate))
            {
                return (Users)xml.Deserialize(fs);
            }
        }
    }
}
