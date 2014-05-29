using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Xml;

namespace FromXmlToDataSet {
    class Program {
        static void Main(string[] args) {
            string filePath = @"C:\Users\UserName\Desktop\E-InvoiceSample.xml";
            ImportFromXml(filePath);
        }

        public static DataSet ImportFromXml(string fromPath) {
            FileInfo xmlFile = new FileInfo(fromPath);
            DataSet dsXML = null;

            if (xmlFile.Exists) {
                FileStream fsReadXml = new FileStream(fromPath, FileMode.Open);
                XmlTextReader myXmlReader = new XmlTextReader(fsReadXml);
                dsXML = new DataSet();

                dsXML.ReadXml(myXmlReader);
                myXmlReader.Close();
                int s = dsXML.Tables["HAWB"].Rows.Count;
                for (int i = 0; i < s; i++) {
                    string sub = dsXML.Tables["HAWB"].Rows[i]["Cube"].ToString();
                }
            }
            return dsXML;
        }
    }
}
