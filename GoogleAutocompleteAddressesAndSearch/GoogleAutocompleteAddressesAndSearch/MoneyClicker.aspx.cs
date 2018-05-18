using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;
using System.ComponentModel;
using System.Data;
using System.Xml.Linq;

namespace GoogleAutocompleteAddressesAndSearch
{
    public partial class MoneyClicker : System.Web.UI.Page
    {
        private string path = "C:\\Users\\dev3\\Desktop\\Test Projects\\Google API Examples\\GoogleAutocompleteAddressesAndSearch\\GoogleAutocompleteAddressesAndSearch\\userInfo.xml";
        public double totalCoins { get; set; }
        public double coinsPerClick { get; set; }
        public double coinsPerHour { get; set; }
        public DateTime lastLoggedIn { get; set; }

        string lastUpgradeLevel = string.Empty;
        private List<clickerUpgrades> clickerList = new List<clickerUpgrades>();
        private List<propertyUpgrades> propertyList = new List<propertyUpgrades>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                homeTab.Visible = true;
                clickerTab.Visible = false;
                upgradesTab.Visible = false;
                extrasTab.Visible = false;

                ReadXmlData();

                double hoursOffline = (DateTime.Now - Convert.ToDateTime(Session["lastLoggedIn"])).TotalHours;

                double coinsEarnedWhileOffline = Math.Floor(hoursOffline) * coinsPerHour;

                totalCoins = totalCoins + coinsEarnedWhileOffline;
                lblTotalCoinsEarned.Text = "You earned a total of " + coinsEarnedWhileOffline + " coins while you were away!";

                Session["coinsPerClick"] = coinsPerClick;
                Session["coinsPerHour"] = coinsPerHour;
                Session["totalCoins"] = totalCoins;
            }

            lblTotalCoins.Text = Session["totalCoins"].ToString();
            lblCoinsPerClick.Text = Session["coinsPerClick"].ToString();
            lblCoinsPerHour.Text = Session["coinsPerHour"].ToString();
        }

        protected void imgbtnCoin_Click(object sender, ImageClickEventArgs e)
        {
            Session["totalCoins"] = Convert.ToDouble(Session["totalCoins"]) + Convert.ToDouble(Session["coinsPerClick"]);
        }

        private void ReadXmlData()
        {
            if (!File.Exists(path))
            {
                try
                {
                    XDocument doc = new XDocument(
                        new XElement("moneyClickerInfo",
                            new XElement("UserInfo",
                                new XElement("totalCoins", "0"),
                                new XElement("coinsPerClick", "1"),
                                new XElement("coinsPerHour", "0"),
                                new XElement("lastLoggedInDateTime", DateTime.Now.ToString())),
                            new XElement("ClickerInfo",
                                new XElement("upgradeLevel",
                                    new XElement("upgradeName", "Basic"),
                                    new XElement("addCoinsPerClick", "2"),
                                    new XElement("CostForUpgrade", "25"),
                                    new XElement("bought", "0")),
                                new XElement("upgradeLevel",
                                    new XElement("upgradeName", "Basic V2"),
                                    new XElement("addCoinsPerClick", "5"),
                                    new XElement("CostForUpgrade", "100"),
                                    new XElement("bought", "0")),
                                new XElement("upgradeLevel",
                                    new XElement("upgradeName", "Basic V3"),
                                    new XElement("addCoinsPerClick", "10"),
                                    new XElement("CostForUpgrade", "500"),
                                    new XElement("bought", "0")),
                                new XElement("upgradeLevel",
                                    new XElement("upgradeName", "Advanced V1"),
                                    new XElement("addCoinsPerClick", "25"),
                                    new XElement("CostForUpgrade", "5000"),
                                    new XElement("bought", "0")),
                                new XElement("upgradeLevel",
                                    new XElement("upgradeName", "Advanced V2"),
                                    new XElement("addCoinsPerClick", "50"),
                                    new XElement("CostForUpgrade", "15000"),
                                    new XElement("bought", "0")),
                                new XElement("upgradeLevel",
                                    new XElement("upgradeName", "Advanced V3"),
                                    new XElement("addCoinsPerClick", "100"),
                                    new XElement("CostForUpgrade", "50000"),
                                    new XElement("bought", "0")),
                                new XElement("upgradeLevel",
                                    new XElement("upgradeName", "Epic V1"),
                                    new XElement("addCoinsPerClick", "150"),
                                    new XElement("CostForUpgrade", "100000"),
                                    new XElement("bought", "0")),
                                new XElement("upgradeLevel",
                                    new XElement("upgradeName", "Epic V2"),
                                    new XElement("addCoinsPerClick", "250"),
                                    new XElement("CostForUpgrade", "500000"),
                                    new XElement("bought", "0")),
                                new XElement("upgradeLevel",
                                    new XElement("upgradeName", "Epic V3"),
                                    new XElement("addCoinsPerClick", "500"),
                                    new XElement("CostForUpgrade", "1000000"),
                                    new XElement("bought", "0")),
                                new XElement("upgradeLevel",
                                    new XElement("upgradeName", "Legendary"),
                                    new XElement("addCoinsPerClick", "1000"),
                                    new XElement("CostForUpgrade", "1000000000"),
                                    new XElement("bought", "0"))),
                            new XElement("PropertyInfo",
                                new XElement("propertyLevel",
                                    new XElement("upgradeName", "Studio Apartment"),
                                    new XElement("addCoinsPerHour", "50"),
                                    new XElement("costForUpgrade", "1000"),
                                    new XElement("bought", "0")),
                                new XElement("propertyLevel",
                                    new XElement("upgradeName", "Home w/ Office"),
                                    new XElement("addCoinsPerHour", "100"),
                                    new XElement("costForUpgrade", "10000"),
                                    new XElement("bought", "0")),
                                new XElement("propertyLevel",
                                    new XElement("upgradeName", "Small Office"),
                                    new XElement("addCoinsPerHour", "200"),
                                    new XElement("costForUpgrade", "100000"),
                                    new XElement("bought", "0")),
                                new XElement("propertyLevel",
                                    new XElement("upgradeName", "Corporate Office"),
                                    new XElement("addCoinsPerHour", "500"),
                                    new XElement("costForUpgrade", "500000"),
                                    new XElement("bought", "0")),
                                new XElement("propertyLevel",
                                    new XElement("upgradeName", "Business Park"),
                                    new XElement("addCoinsPerHour", "1000"),
                                    new XElement("costForUpgrade", "1000000"),
                                    new XElement("bought", "0")),
                                new XElement("propertyLevel",
                                    new XElement("upgradeName", "City"),
                                    new XElement("addCoinsPerHour", "2500"),
                                    new XElement("costForUpgrade", "100000000"),
                                    new XElement("bought", "0")),
                                new XElement("propertyLevel",
                                    new XElement("upgradeName", "State"),
                                    new XElement("addCoinsPerHour", "5000"),
                                    new XElement("costForUpgrade", "1000000000"),
                                    new XElement("bought", "0")),
                                new XElement("propertyLevel",
                                    new XElement("upgradeName", "Country"),
                                    new XElement("addCoinsPerHour", "10000"),
                                    new XElement("costForUpgrade", "5000000000"),
                                    new XElement("bought", "0")),
                                new XElement("propertyLevel",
                                    new XElement("upgradeName", "World"),
                                    new XElement("addCoinsPerHour", "25000"),
                                    new XElement("costForUpgrade", "10000000000"),
                                    new XElement("bought", "0")),
                                new XElement("propertyLevel",
                                    new XElement("upgradeName", "Galaxy"),
                                    new XElement("addCoinsPerHour", "50000"),
                                    new XElement("costForUpgrade", "15000000000"),
                                    new XElement("bought", "0")))));
                    doc.Save(path);

                    XmlDocument xmldoc = new XmlDocument();
                    XmlNodeList xmlnode;
                    int i = 0;
                    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    xmldoc.Load(fs);
                    xmlnode = xmldoc.GetElementsByTagName("upgradeLevel");
                    for (i = 0; i <= xmlnode.Count - 1; i++)
                    {
                        clickerUpgrades clicker = new clickerUpgrades();
                        clicker.name = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                        clicker.clickIncrease = Convert.ToInt32(xmlnode[i].ChildNodes.Item(1).InnerText.Trim());
                        clicker.cost = Convert.ToDouble(xmlnode[i].ChildNodes.Item(2).InnerText.Trim());
                        clicker.bought = Convert.ToInt32(xmlnode[i].ChildNodes.Item(3).InnerText.Trim());

                        clickerList.Add(clicker);
                    }

                    XmlNodeList xmlnode2 = xmldoc.GetElementsByTagName("UserInfo");
                    for (i = 0; i <= xmlnode2.Count - 1; i++)
                    {
                        totalCoins = Convert.ToDouble(xmlnode2[i].ChildNodes.Item(0).InnerText.Trim());
                        coinsPerClick = Convert.ToDouble(xmlnode2[i].ChildNodes.Item(1).InnerText.Trim());
                        coinsPerHour = Convert.ToDouble(xmlnode2[i].ChildNodes.Item(2).InnerText.Trim());
                        lastLoggedIn = Convert.ToDateTime(xmlnode2[i].ChildNodes.Item(3).InnerText.Trim());
                    }

                    XmlNodeList xmlnode3 = xmldoc.GetElementsByTagName("propertyLevel");
                    for (i = 0; i <= xmlnode3.Count - 1; i++)
                    {
                        propertyUpgrades property = new propertyUpgrades();
                        property.name = xmlnode3[i].ChildNodes.Item(0).InnerText.Trim();
                        property.hourlyIncrease = Convert.ToInt64(xmlnode3[i].ChildNodes.Item(1).InnerText.Trim());
                        property.cost = Convert.ToDouble(xmlnode3[i].ChildNodes.Item(2).InnerText.Trim());
                        property.bought = Convert.ToInt32(xmlnode3[i].ChildNodes.Item(3).InnerText.Trim());

                        propertyList.Add(property);
                    }
                    fs.Flush();
                    fs.Close();
                }
                catch (Exception ex)
                {
                    
                }
            }
            else
            {
                XmlDocument xmldoc = new XmlDocument();
                XmlNodeList xmlnode;
                int i = 0;
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                xmldoc.Load(fs);
                xmlnode = xmldoc.GetElementsByTagName("upgradeLevel");
                for (i = 0; i <= xmlnode.Count - 1; i++)
                {
                    clickerUpgrades clicker = new clickerUpgrades();
                    clicker.name = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                    clicker.clickIncrease = Convert.ToInt32(xmlnode[i].ChildNodes.Item(1).InnerText.Trim());
                    clicker.cost = Convert.ToDouble(xmlnode[i].ChildNodes.Item(2).InnerText.Trim());
                    clicker.bought = Convert.ToInt32(xmlnode[i].ChildNodes.Item(3).InnerText.Trim());

                    clickerList.Add(clicker);
                }

                XmlNodeList xmlnode2 = xmldoc.GetElementsByTagName("UserInfo");
                for (i = 0; i <= xmlnode2.Count - 1; i++)
                {
                    totalCoins = Convert.ToDouble(xmlnode2[i].ChildNodes.Item(0).InnerText.Trim());
                    coinsPerClick = Convert.ToDouble(xmlnode2[i].ChildNodes.Item(1).InnerText.Trim());
                    coinsPerHour = Convert.ToDouble(xmlnode2[i].ChildNodes.Item(2).InnerText.Trim());
                    lastLoggedIn = Convert.ToDateTime(xmlnode2[i].ChildNodes.Item(3).InnerText.Trim());
                }

                XmlNodeList xmlnode3 = xmldoc.GetElementsByTagName("propertyLevel");
                for (i = 0; i <= xmlnode3.Count - 1; i++)
                {
                    propertyUpgrades property = new propertyUpgrades();
                    property.name = xmlnode3[i].ChildNodes.Item(0).InnerText.Trim();
                    property.hourlyIncrease = Convert.ToInt64(xmlnode3[i].ChildNodes.Item(1).InnerText.Trim());
                    property.cost = Convert.ToDouble(xmlnode3[i].ChildNodes.Item(2).InnerText.Trim());
                    property.bought = Convert.ToInt32(xmlnode3[i].ChildNodes.Item(3).InnerText.Trim());

                    propertyList.Add(property);
                }
                fs.Flush();
                fs.Close();
            }

            Session["lastLoggedIn"] = lastLoggedIn;
            Session["propertyList"] = propertyList;
            Session["ClickerList"] = clickerList;
            dgClickerList.DataSource = clickerList;
            dgClickerList.DataBind();
            dgPropertyList.DataSource = propertyList;
            dgPropertyList.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNode node1 = doc.SelectSingleNode("moneyClickerInfo/UserInfo/totalCoins");
            node1.InnerText = Session["totalCoins"].ToString();

            XmlNode node2 = doc.SelectSingleNode("moneyClickerInfo/UserInfo/coinsPerClick");
            node2.InnerText = Session["coinsPerClick"].ToString();

            XmlNode node3 = doc.SelectSingleNode("moneyClickerInfo/UserInfo/coinsPerHour");
            node3.InnerText = Session["coinsPerHour"].ToString();

            XmlNode node4 = doc.SelectSingleNode("moneyClickerInfo/UserInfo/lastLoggedInDateTime");
            node4.InnerText = DateTime.Now.ToString();

            XmlNodeList nodeList = doc.SelectNodes("moneyClickerInfo/ClickerInfo/upgradeLevel");

            for (int i = 0; i <= nodeList.Count - 1; i++)
            {
                XmlNode node = nodeList.Item(i);

                List<clickerUpgrades> upgrades = (List<clickerUpgrades>)Session["clickerList"];

                node["upgradeName"].InnerText = upgrades[i].name;
                node["addCoinsPerClick"].InnerText = upgrades[i].clickIncrease.ToString();
                node["CostForUpgrade"].InnerText = upgrades[i].cost.ToString();
                node["bought"].InnerText = upgrades[i].bought.ToString();
            }

            XmlNodeList nodeList2 = doc.SelectNodes("moneyClickerInfo/ClickerInfo/propertyLevel");

            for (int i = 0; i <= nodeList2.Count - 1; i++)
            {
                XmlNode node = nodeList2.Item(i);

                List<propertyUpgrades> upgrades = (List<propertyUpgrades>)Session["propertyList"];

                node["upgradeName"].InnerText = upgrades[i].name;
                node["addCoinsPerHour"].InnerText = upgrades[i].hourlyIncrease.ToString();
                node["costForUpgrade"].InnerText = upgrades[i].cost.ToString();
                node["bought"].InnerText = upgrades[i].bought.ToString();
            }

            doc.Save(path);
        }

        protected void homeTab_Click(object sender, EventArgs e)
        {
            homeTab.Visible = true;
            clickerTab.Visible = false;
            upgradesTab.Visible = false;
            extrasTab.Visible = false;
        }

        protected void clickerTab_Click(object sender, EventArgs e)
        {
            homeTab.Visible = false;
            clickerTab.Visible = true;
            upgradesTab.Visible = false;
            extrasTab.Visible = false;
        }

        protected void PurchaseClickerIncrease_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectClicker")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = dgClickerList.Rows[index];
                TableCell bought = selectedRow.Cells[3];
                string totalOwned = (Convert.ToInt32(bought.Text) + 1).ToString();
                List<clickerUpgrades> clickerList = new List<clickerUpgrades>();

                clickerList = (List<clickerUpgrades>)Session["ClickerList"];

                if (index > -1)
                {
                    if (Convert.ToInt32(Session["totalCoins"]) >= clickerList[index].cost)
                    {
                        Session["totalCoins"] = Convert.ToInt32(Session["totalCoins"]) - clickerList[index].cost;
                        lblTotalCoins.Text = Session["totalCoins"].ToString();
                        clickerList[index].bought = Convert.ToInt32(totalOwned);
                        clickerList[index].cost = clickerList[index].cost * 1.25;
                        Session["coinsPerClick"] = Convert.ToInt32(Session["coinsPerClick"]) + clickerList[index].clickIncrease;
                        lblCoinsPerClick.Text = Session["coinsPerClick"].ToString();
                    }
                    else
                    {
                        lblErrorMessage.Text = "Not enough funds!";
                    }
                }

                dgClickerList.DataSource = clickerList;
                dgClickerList.DataBind();
            }
            else if (e.CommandName == "SelectProperty")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = dgClickerList.Rows[index];
                TableCell bought = selectedRow.Cells[3];
                string totalOwned = (Convert.ToInt32(bought.Text) + 1).ToString();
                List<propertyUpgrades> propertyList = new List<propertyUpgrades>();

                propertyList = (List<propertyUpgrades>)Session["propertyList"];

                if (index > -1)
                {
                    if (Convert.ToInt32(Session["totalCoins"]) >= propertyList[index].cost)
                    {
                        Session["totalCoins"] = Convert.ToInt32(Session["totalCoins"]) - propertyList[index].cost;
                        lblTotalCoins.Text = Session["totalCoins"].ToString();
                        propertyList[index].bought = Convert.ToInt32(totalOwned);
                        propertyList[index].cost = propertyList[index].cost * 1.25;
                        Session["coinsPerHour"] = Convert.ToInt32(Session["coinsPerHour"]) + propertyList[index].hourlyIncrease;
                        lblCoinsPerHour.Text = Session["coinsPerHour"].ToString();
                    }
                    else
                    {
                        lblErrorMessage.Text = "Not enough funds!";
                    }
                }

                dgPropertyList.DataSource = propertyList;
                dgPropertyList.DataBind();
            }
        }

        protected void upgradesTab_Click(object sender, EventArgs e)
        {
            homeTab.Visible = false;
            clickerTab.Visible = false;
            upgradesTab.Visible = true;
            extrasTab.Visible = false;
        }

        protected void extrasTab_Click(object sender, EventArgs e)
        {
            homeTab.Visible = false;
            clickerTab.Visible = false;
            upgradesTab.Visible = false;
            extrasTab.Visible = true;
        }
    }

    public class clickerUpgrades
    {
        public string name { get; set; }
        public double cost { get; set; }
        public int clickIncrease { get; set; }
        public int bought { get; set; }

        public clickerUpgrades()
        {
            name = string.Empty;
            cost = 0.00;
            clickIncrease = 0;
            bought = 0;
        }
    }

    public class propertyUpgrades
    {
        public string name { get; set; }
        public double cost { get; set; }
        public Int64 hourlyIncrease { get; set; }
        public int bought { get; set; }

        public propertyUpgrades()
        {
            name = string.Empty;
            cost = 0.00;
            hourlyIncrease = 0;
            bought = 0;
        }
    }
}