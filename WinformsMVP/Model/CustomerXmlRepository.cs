using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WinformsMVP.Model
{
    public class CustomerXmlRepository : ICustomerRepository
    {
        private readonly XmlSerializer _serializer;
        private readonly string _xmlFile;
        private readonly Lazy<List<Customer>> _customers;

        public CustomerXmlRepository()
        {
            _serializer = new XmlSerializer(typeof(List<Customer>));
            _xmlFile = Path.GetDirectoryName(Application.ExecutablePath) + @"\customers.xml";

            if (!File.Exists(_xmlFile))
            {
                CreateXml();
            }

            _customers = new Lazy<List<Customer>>(() =>
            {
                using (var reader = new StreamReader(_xmlFile))
                {
                    return (List<Customer>)_serializer.Deserialize(reader);
                }
            });
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customers.Value;
        }

        public Customer Get(int id)
        {
            return _customers.Value[id];
        }

        public void Create(Customer customer)
        {
            _customers.Value.Add(customer);
            Save(_customers.Value);
        }

        public void Delete(int id)
        {
            _customers.Value.RemoveAt(id);
            Save(_customers.Value);
        }

        private void Save(List<Customer> customers)
        {
            using (var writer = new StreamWriter(_xmlFile, false))
            {
                _serializer.Serialize(writer, customers);
            }
        }

        private void CreateXml()
        {
            Save(new List<Customer>());
        }
    }
}
