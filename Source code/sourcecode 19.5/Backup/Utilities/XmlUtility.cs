using System;
using System.Collections;
using System.IO;
using System.Web;
using System.Xml;
using Logger;

namespace Utilities
{
    public class XmlUtility
    {
        private string XmlPath = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "xml\\dbconnect.xml");
        private string XmlPathRoles = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "xml\\moreroles.xml");
        XmlDocument xmlDoc = new XmlDocument();

        public bool InsertConnectionString(string key, string value)
        {
            try
            {
                xmlDoc.Load(XmlPath);
                XmlNodeList parent = xmlDoc.GetElementsByTagName("connectionstrings");
                XmlNode part = xmlDoc.CreateNode(XmlNodeType.Element, "portals", null);
                parent[0].AppendChild(part);
                //write key
                XmlNode xmlkey = xmlDoc.CreateNode(XmlNodeType.Element, "key", null);
                xmlkey.InnerXml = key;
                part.AppendChild(xmlkey);
                //write value
                XmlNode xmlvalue = xmlDoc.CreateNode(XmlNodeType.Element, "value", null);
                xmlvalue.InnerXml = value;
                part.AppendChild(xmlvalue);
                xmlDoc.Save(XmlPath);
                return true;
            }
            catch (Exception ex)
            {
                Log.info("InsertConnectionString err: " + ex.Message);
                return false;
            }
        }
        public bool UpdateConnectionString(string key, string value)
        {
            try
            {
                xmlDoc.Load(XmlPath);

                XmlNodeList portals = xmlDoc.GetElementsByTagName("portals");
                foreach (XmlNode node in portals)
                {
                    XmlNodeList childnode = node.ChildNodes;
                    if (childnode[0].InnerText == key)
                    {
                        childnode[1].RemoveAll();
                        childnode[1].InnerText = value;
                    }
                }
                xmlDoc.Save(XmlPath);
                return true;
            }
            catch (Exception ex)
            {
                Log.info("UpdateConnectionString err: " + ex.Message);
                return false;
            }
        }
        public string GetConnectionStrings(string key)
        {
            try
            {
                xmlDoc.Load(XmlPath);

                XmlNodeList portals = xmlDoc.GetElementsByTagName("portals");
                foreach (XmlNode node in portals)
                {
                    XmlNodeList childnode = node.ChildNodes;
                    if (childnode[0].InnerText == key)
                        return childnode[1].InnerText;
                }
                return null;
            }
            catch (Exception ex)
            {
                Log.info("GetConnectionStrings err: " + ex.Message);
                return null;
            }
        }

        public bool InsertRoles(int PortalID, int UserID, int DelMultiJob, int EmailManage)
        {
            try
            {
                xmlDoc.Load(XmlPathRoles);
                XmlNodeList parent = xmlDoc.GetElementsByTagName("adminroles");
                XmlNode part = xmlDoc.CreateNode(XmlNodeType.Element, "Portals", null);
                parent[0].AppendChild(part);
                //write PortalID
                XmlNode _PortalID = xmlDoc.CreateNode(XmlNodeType.Element, "PortalID", null);
                _PortalID.InnerXml = PortalID.ToString();
                part.AppendChild(_PortalID);
                //write UserID
                XmlNode _UserID = xmlDoc.CreateNode(XmlNodeType.Element, "UserID", null);
                _UserID.InnerXml = UserID.ToString();
                part.AppendChild(_UserID);
                //write DelMultiJob
                XmlNode _DelMultiJob = xmlDoc.CreateNode(XmlNodeType.Element, "DelMultiJob", null);
                _DelMultiJob.InnerXml = DelMultiJob.ToString();
                part.AppendChild(_DelMultiJob);
                //write EmailManage
                XmlNode _EmailManage = xmlDoc.CreateNode(XmlNodeType.Element, "EmailManage", null);
                _EmailManage.InnerXml = EmailManage.ToString();
                part.AppendChild(_EmailManage);
                xmlDoc.Save(XmlPath);
                return true;
            }
            catch (Exception ex)
            {
                Log.info("InsertConnectionString err: " + ex.Message);
                return false;
            }
        }
        public bool UpdateRoles(int PortalID, int UserID, int DelMultiJob, int EmailManage)
        {
            try
            {
                xmlDoc.Load(XmlPathRoles);

                XmlNodeList portals = xmlDoc.GetElementsByTagName("Portals");
                foreach (XmlNode node in portals)
                {
                    XmlNodeList childnode = node.ChildNodes;
                    if (childnode[0].InnerText == PortalID.ToString() && childnode[1].InnerText == UserID.ToString())
                    {
                        childnode[2].RemoveAll();
                        childnode[2].InnerText = DelMultiJob.ToString();

                        childnode[3].RemoveAll();
                        childnode[3].InnerText = EmailManage.ToString();
                    }
                }
                xmlDoc.Save(XmlPath);
                return true;
            }
            catch (Exception ex)
            {
                Log.info("UpdateRoles err: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// GetRoles[0]: role manage del multi jobs
        /// GetRoles[1]: role manage email + sms
        /// </summary>
        /// <param name="PortalID"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public string[] GetRoles(int PortalID, int UserID)
        {
            try
            {
                xmlDoc.Load(XmlPathRoles);
                string[] kq=new string[2];
                XmlNodeList portals = xmlDoc.GetElementsByTagName("Portals");
                foreach (XmlNode node in portals)
                {
                    XmlNodeList childnode = node.ChildNodes;
                    if (childnode[0].InnerText == PortalID.ToString() && childnode[1].InnerText == UserID.ToString())
                    {
                        kq[0] = childnode[2].InnerText;
                        kq[1] = childnode[3].InnerText;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Log.info("GetRoles err: " + ex.Message);
                return null;
            }
        }
    }
}
